from django.db import models
class Users(models.Model):
	username = models.CharField(max_length=20,primary_key=True)
	mailid = models.EmailField(max_length =254,default="NULL")
	password1 = models.CharField(max_length=12,default="NULL")
	password2 = models.CharField(max_length=12,default="NULL")
	firstName= models.CharField(max_length=15,default="NULL")
	middleName= models.CharField(max_length=15,default="NULL")
	lastName= models.CharField(max_length=15,default="NULL")
	university = models.CharField(max_length=40,default="NULL")
	degree=models.CharField(max_length=20,default="NULL")
	country=models.CharField(max_length=10,default="NULL")
# Create your models here.
class Rank(models.Model):
	username = models.ForeignKey(Users,on_delete=models.CASCADE)
	rank=models.IntegerField(primary_key=True)
	marks=models.IntegerField()
class Question(models.Model):
	question_Id = models.CharField(max_length=20)
	cinput = models.CharField(max_length=20)
	Eoutput = models.CharField(max_length=20)
