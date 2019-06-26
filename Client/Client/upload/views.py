from django.shortcuts import render,render_to_response
from django.views.generic import TemplateView
from django.http import HttpResponseRedirect
from django.contrib import auth
from django.template.context_processors import csrf
from django.views import generic
from CodeBreakersapp.forms import * 
from CodeBreakersapp.models import Users,Rank,Question
from django.contrib.auth.models import User
from django.contrib.auth.decorators import login_required
from sphere_engine import CompilersClientV3
from sphere_engine.exceptions import SphereEngineException
import time
import requests


def index(request):
    c={}
    c.update(csrf(request))
    if request.session.has_key('username'):
        return render(request,'index.html',c)
    return render_to_response('index.html',c)

def login(request):
    c={}
    c.update(csrf(request))
    if request.session.has_key('username'):
        return HttpResponseRedirect('/index/')
    else:
        if request.GET.get('msg','') is not None:
            return render_to_response('login.html',c)    
        return render_to_response('login.html',c)

def logout(request):
    try:
        del request.session['username']
    except:
        pass
    return HttpResponseRedirect('/index/')

def auth_view(request):
    username=request.POST.get('username','')
    password=request.POST.get('password','')
    user=auth.authenticate(username=username, password=password)
    if user is not None and user.is_active:
        auth.login(request,user)
        request.session['username'] = username
        return HttpResponseRedirect('/home/')
    else:
        return HttpResponseRedirect('/login/?msg=Invalid_Username_or_Password')# Create your views here.
    
def home(request):
    if request.session.has_key('username'):
        return render(request,'home.html')
    else:
        return HttpResponseRedirect('/index/')
    
def register(request):
    c = {}
    c.update(csrf(request))
    if request.session.has_key('username'):
        return render(request,'register.html')       
    #if request.GET.get('msg','') is not None:
     #   return render_to_response('register.html', c)    
    return render_to_response('register.html', c)

def addstudentinfo(request):
    uname = request.POST.get('username', '')
    pwd = request.POST.get('password1', '')
    pwd2 = request.POST.get('password2', '')
    mail = request.POST.get('email', '')
#    ob=Users.objects.filter(username=uname)
  #  if ob is not None:
    #      return HttpResponseRedirect('/register/?msg=Username_already_exist.')   
    form = SignUpForm(request.POST)
    if form.is_valid():
        form.save()
        username= form.cleaned_data.get('username')
        password= form.cleaned_data.get('password1')
        s = Users(username = uname , mailid = mail, password1 = pwd , password2 = pwd2)
        s.save()
        user=auth.authenticate(username=username, password=password)
        auth.login(request,user)
        return HttpResponseRedirect('/login/')
    return HttpResponseRedirect('/register/?msg=Invalid_Details.')

#@login_required(login_url='/login/')        
def practice(request):
    if request.session.has_key('username'):
        return render_to_response('practice.html')
    else:
        return HttpResponseRedirect('/index')
    
def leaderboard(request):
    if request.session.has_key('username'):
        data=Rank.objects.all()
        context={'data':data}
        return render(request,'leaderboard.html',context)
    else:
        return HttpResponseRedirect('/index')

def profile(request):
    if request.session.has_key('username'):
        uname=request.session.get('username')
        data=Users.objects.filter(username = uname)
        return render(request,'profile.html',{'data':data})
    else:
        return HttpResponseRedirect('/index')
    
def editprofile(request):
    if request.session.has_key('username'):
        uname=request.session.get('username')
        data=Users.objects.filter(username = uname)
        return render(request,'editprofile.html',{'data':data})
    else:
        return HttpResponseRedirect('/index')

def update(request):
    if request.session.has_key('username'):
        uname=request.session.get('username')
        data=Users.objects.filter(username = uname)
        firstname = request.POST.get('fname', '')
        middlename =request.POST.get('mname', '')
        lastname = request.POST.get('lname', '')
        mail = request.POST.get('mail', '')
        university = request.POST.get('uni', '')
        degree = request.POST.get('deg', '')
        country = request.POST.get('country', '')
        for i in data:
            i.firstName=firstname
            i.middleName=middlename
            i.lastName=lastname
            i.mailid=mail
            i.university=university
            i.degree=degree
            i.country=country
            i.save()
    return HttpResponseRedirect('/profile/')
        
def maxarray(request):
	c={}
	c.update(csrf(request))
	if request.session.has_key('username'):
		return render_to_response('practice/maxarray.html',c)
	else:
		return HttpResponseRedirect('/index') 
        
def fibonacci(request):
	c={}
	c.update(csrf(request))
	if request.session.has_key('username'):
		return render_to_response('practice/fibonacci.html',c)
	else:
		return HttpResponseRedirect('/index') 

def findremainder(request):
	c={}
	c.update(csrf(request))
	if request.session.has_key('username'):
		return render_to_response('practice/findremainder.html',c)
	else:
		return HttpResponseRedirect('/index')
		
#@login_required(login_url='/login/')
def code(request):
	c={}
	c.update(csrf(request))
	if request.session.has_key('username'):
		request.session['pcode']=request.POST.get('pcode')
		return render_to_response('code.html',c)
	else:
		return HttpResponseRedirect('/index')
		
#@login_required(login_url='/login/')	
def execute(request):
	c={}
	c.update(csrf(request))
	if request.session.has_key('username'):
	# define access parameters
		accessToken='635261e9572cfed16a140f349c08df82'
		# accessToken='8f7022c5db9a91c4fa8c699309094d9e'
		endpoint='e6a34d7a.compilers.sphere-engine.com'
		# initialization
		client = CompilersClientV3(accessToken, endpoint)
		# API usage
		source = request.POST.get('sourcecode')
		compiler = 11 # C language
		y=0
		input1 = Question.objects.filter(question_Id=request.session['pcode'])
		for var in input1:
			input=var.cinput
			try:
				response = client.submissions.create(source, compiler, input)
				x=var.Eoutput
				id=response['id']
				#print(response)
				time.sleep(2)
				response=client.submissions.get(id)
				if(response['result']==11):
					#print(response)
					c['q']="Compilation error"
					return render(request,'code.html',c)
				elif(response['result']==15):
					if(response['time']<=1):
						url = "https://e6a34d7a.compilers.sphere-engine.com/api/v3/submissions/"+str(id)+"/output?access_token=635261e9572cfed16a140f349c08df82"
						response = requests.get(url)
						if(str(x)!=str(response.content.decode("utf-8"))):
							c['q']="Wrong Answer"
							return render(request,'code.html',c)
							#print("success")
						else:
							y=1
					else:
						c['q']="Time limit exceeded"
						return render(request,'code.html',c)
						#print("Time limit exceeded")
				elif(response['result']==12):
					#print(response)
					c['q']="Runtime error"
					return render(request,'code.html',c)
					#print("runtime 9/error")
				elif(response['result']==13):
					c['q']="Time limit exceeded"
					return render(request,'code.html',c)
					#print("Time limit exceeded")
			except SphereEngineException as e:
				print(e)
				if e.code == 401:
					print('Invalid access token')
			if(y==1):
				c['q']="success"
				c['q1']="marks=100"
			else:
				c['q']="empty source code"
		return render_to_response('code.html',c)
	else:
		return HttpResponseRedirect('/index')