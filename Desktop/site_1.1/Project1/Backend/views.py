from django.shortcuts import render
from rest_framework import generics
from .models import Matrix
from .serializer import MatrixSerializer


class MatrixCreateView(generics.CreateAPIView):
    serializer_class = MatrixSerializer
