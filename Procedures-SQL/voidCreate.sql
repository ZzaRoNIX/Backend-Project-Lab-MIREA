--метод CREATE---------------------------------------------------------------------------------------
alter proc CreateTask @UserName as nvarchar(50),@TaskName as nvarchar(200),@TaskDescr as nvarchar(max)
as
declare @cnt as integer;
set @cnt=(select CurrentCounter from Users where  UserName =@UserName)
update Users set CurrentCounter=@cnt+1 where UserName=@UserName
insert into Tasks values(@UserName,@cnt,getdate(),@TaskName,@TaskDescr,0)
select * from Tasks where @cnt=CurrentCounter and @UserName = UserID
for json path
------------------------------------------------------------------------------------------------------
--for json path    конвертирует ответ в формат json

--метод DELETE----------------------------------------------------------------------------------------
alter proc DeleteTask  @UserID as nvarchar(50),@CurrentCounter as nvarchar(200)
as
delete from Tasks
where (@UserID=UserID and convert(int,@CurrentCounter)=CurrentCounter);
------------------------------------------------------------------------------------------------------


--метод GET, DATA SEARCH----------------------------------------------------------------------------
alter proc SelectTaskDate @UserID as nvarchar(50), @StartDate as nvarchar(50),@EndDate nvarchar(50)
as
set DATEFORMAT 'dmy';
select * from Tasks where (@UserID=UserID) and (StartDate between @StartDate and @EndDate)
union all
select * from TaskArchive.dbo.Tasks where (@UserID=UserID) and (StartDate between @StartDate and @EndDate) 
for json path
------------------------------------------------------------------------------------------------------


--метод UPDATE----------------------------------------------------------------------------------------
alter proc UpdateTask @UserName as nvarchar(50), @CurrentCounter as nvarchar(200), @TaskDescr as nvarchar(max)
as
update Tasks set TaskDescription=@TaskDescr,StartDate=getdate() where UserID=@UserName and CurrentCounter=@CurrentCounter and trim(TaskDescription) <> trim(@TaskDescr)
select * from Tasks where (UserID=@UserName and CurrentCounter=@CurrentCounter )
for json path
------------------------------------------------------------------------------------------------------
 --TRIM убирает все пробелы спереди и сзади

--метод GetAll(by UserID)-----------------------------------------------------------------------------
alter proc GetAllTask @UserName as nvarchar(50), @flag as nvarchar(50)
as
if (@flag='')
select * from Tasks where (UserID=@UserName)
union all
select * from TaskArchive.dbo.Tasks where (UserID=@UserName)
for json path

else if(@flag='1')
select * from TaskArchive.dbo.Tasks where (UserID=@UserName)
for json path

else if (@flag='0')
select * from Tasks where (UserID=@UserName)
for json path
------------------------------------------------------------------------------------------------------



--метод NewUser(PUT)-----------------------------------------------------------------------------------
--alter proc NewUser @UserName as nvarchar(50)
--as
--declare @mess1 as nvarchar(200), @mess2 as nvarchar(200);
--set @mess1 = 'New user created'
--set @mess2 = 'This user exists'
--if not exists(select UserName from Users where UserName=@UserName)
--begin
--insert into Users values(@UserName,0)
--select @mess1, @UserName
--for json path
--end
--else
--select @mess2
--for json path

--не работает, надо допилить

------------------------------------------------------------------------------------------------------
--NewUser 'QWERTY1'


CreateTask 'SADMAN','ИЗМЕНИ МЕНЯ ИЗ ПРОГИ','ХАРОШ'
DeleteTask 'SADMAN','15'
SelectTaskDate 'User002','10-04-2020','16-04-2020'
UpdateTask 'User002','3','изменения работают 2.2'
GetAllTask 'User002',''



select * from Tasks 

select* from  Users 


select * from Tasks
union all
select * from TaskArchive.dbo.Tasks







sp_helptext CreateTask

