from django.shortcuts import render
from django.http import HttpResponse

def index(request):
    return HttpResponse("Database Index.")
def detail(request, Location_id):
    return HttpResponse("You're looking at question %s." % Location_id)

def results(request, Location_id):
    response = "You're looking at the results of question %s."
    return HttpResponse(response % Location_id)

def vote(request, Location_id):
    return HttpResponse("You're voting on question %s." % Location_id)

