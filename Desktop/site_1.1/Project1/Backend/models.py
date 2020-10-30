from django.db import models


class Matrix(models.Model):
    A11 = models.IntegerField(verbose_name='11')
    A12 = models.IntegerField(verbose_name='12')
    A13 = models.IntegerField(verbose_name='13')
    A21 = models.IntegerField(verbose_name='21')
    A22 = models.IntegerField(verbose_name='22')
    A23 = models.IntegerField(verbose_name='23')
    A31 = models.IntegerField(verbose_name='31')
    A32 = models.IntegerField(verbose_name='32')
    A33 = models.IntegerField(verbose_name='33')
    DetA = models.SmallIntegerField(verbose_name='Детерминант матрицы А', default=0)
    TransA = models.IntegerField(verbose_name='Транспонированная матраца А')
