import DOWNLOADS as DOWNLOADS
from django.db import models
from datetime import date


class Animal(models.Model):
    # img = models.ImageField('Аватар', null=True, upload_to=)

    GENDER_TYPES = (
        (1, 'Мальчик'),
        (2, 'Девочка'),
    )

    TYPE_COLOR = (
        (1, 'Монотонная'),
        (2, 'Многоцветная'),
    )

    MONO_COLORS_CHOICES = (
        (1, 'Черная'),
        (2, 'Белая'),
        (3, 'Коричневая'),
        (4, 'Серая'),
        (5, 'Рыжая'),
    )

    MANY_COLORS_CHOICES = (
        (1, 'Полосотая'),
        (2, 'Пятнистая'),
    )

    TYPE_HAIR = (
        (1, 'Пушистая'),
        (2, 'Короткошерстая'),
        (3, 'Лысая'),
    )

    TYPE_STERILIZATION = (
        (1, 'Да'),
        (2, 'Нет'),
    )

    TYPE_TRAINED = (
        (1, 'Да'),
        (2, 'Нет'),
    )

    moniker_animal = models.CharField('Кличка', max_length=100)
    create_at = models.DateField('Дата создания', auto_now_add=True)
    weight_animal = models.IntegerField('Вес', max_length=100)
    height_animal = models.CharField('Рост', max_length=100, default='Неизвестно')
    gender_animal = models.CharField('Пол', choices=GENDER_TYPES, max_length=100, default='Унисекс')
    born_on_animal = models.DateField(verbose_name='Дата рождения', default=date.today)
    # color_animal = можно ли тут сделать в скобках условие
    hair_animal = models.CharField('Шерсть', choices=TYPE_HAIR, max_length=100)
    sterilization_animal = models.CharField('Стерилизован', choices=TYPE_STERILIZATION, max_length=100)
    trained_animal = models.CharField('Дрессирован\приучен к лотку', choices=TYPE_TRAINED, max_length=100)
