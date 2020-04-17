
select * from Tasks
union all
select * from TodoRun.dbo.Tasks



--метод ChangeFlag------------------------------------------------------------------------------------
alter proc ChangeFlag @UserName as nvarchar(50), @CurrentCounter as nvarchar(200)
as
declare @fl as integer;
set @fl=1
insert into Tasks select * from TodoRun.dbo.Tasks where (UserID=@UserName and CurrentCounter=@CurrentCounter)
update Tasks set TaskFlag=@fl where (UserID=@UserName and CurrentCounter=@CurrentCounter)
delete from TodoRun.dbo.Tasks where (UserID=@UserName and CurrentCounter=@CurrentCounter)
select * from Tasks where (UserID=@UserName and CurrentCounter=@CurrentCounter)
for json path
------------------------------------------------------------------------------------------------------

ChangeFlag 'SADMAN','8'