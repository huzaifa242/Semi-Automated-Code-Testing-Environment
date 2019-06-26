
from django.urls import path
from CodeBreakersapp.views import index,practice,maxarray,editprofile,update,login,profile,logout, auth_view, home,leaderboard,findremainder,fibonacci
from django.contrib.auth import views as auth_views
from django.conf.urls import url
from . import views

urlpatterns = [
url(r'^index/$', index),    
url(r'^login/$', login),
url(r'^logout/$', logout),
url(r'^auth/$', auth_view),
url(r'^home/$',home),
url(r'^addstudentinfo/$', views.addstudentinfo),
url(r'^register/$', views.register),
url(r'^practice/$', views.practice),
url(r'^profile/$', views.profile),
url(r'^editprofile/$', views.editprofile),
url(r'^update/$', views.update),
url(r'^leaderboard/$', views.leaderboard),
url(r'^practice/maxarray/$',views.maxarray),
url(r'^practice/findremainder/$',views.findremainder),
url(r'^practice/fibonacci/$',views.fibonacci),
url(r'^execute/$',views.execute),
url(r'^code/$',views.code),
]
