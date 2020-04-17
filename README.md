# Open-source проект для [RTUITLab](https://vk.com/rtuitlab)
# Потребуется [Asp.Net Core](https://dotnet.microsoft.com/download), [SQL Server Management Studio 18](https://docs.microsoft.com/ru-ru/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
# Для работы к проекту надо подключить NuGet System.Data.SqlClient
### В SQL создать базу данных с названием TodoRun и TaskArchive
> Скрипты для создания бд и таблиц приложены здесь
../Backend-Project-Lab-MIREA/SQL Scripts create/
### Хранимые процедуры SQL
> ../Backend-Project-Lab-MIREA/Procedures-SQL/
### Название сервера
DESKTOP-GSFVRI0
### Пароль:
Отсутсвовал
### Проверка подлинности: 
Проверка подлинности Windows
### Port
44330
# [Postman](https://www.postman.com/downloads/)
body -> raw -> JSON
settings -> general -> SSL certificate verification OFF
# Запросы по localhost:44330/api/todo
- [Post] Create 
{
"UserID":"существующий юзер",
"TaskName":"Имя задачи",
“TaskDescription”:”Описание задачи”
}
- [Get] Find 
{
"UserID":"существующий юзер",
“StartDate”:”дд-мм-гггг”,
“EndDate”:”дд-мм-гггг”
}

- [Patch] Update 
{
"UserID":"существующий юзер",
"CurrentCounter":"номер задачи",
"TaskDescription":"ваше измененное описание"
}

- [Put] Archive(пометка как выполненное и архивация) 
{
"UserID":"существующий юзер",
"CurrentCounter":"номер задачи"
}

- [Delete] Delete 
{
"UserID":"существующий юзер",
"CurrentCounter":"номер задачи"
}

# Запросы по localhost:port/api/todo/getall
[Get] GetAll 
{
"UserID":"существующий юзер",
"Flag":""  (0 - невыполненные, 1 - выполненные, если оставить пустым, то выведет всё)
}
