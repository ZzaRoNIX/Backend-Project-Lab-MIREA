from rest_framework import serializers
from .models import Matrix


class MatrixSerializer(serializers.ModelSerializer):

    class Meta:
        model = Matrix
        fields = ('id', 'A11', 'A12', 'A13', 'A21', 'A22', 'A23', 'A31', 'A32', 'A33')
