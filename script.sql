create database injectionsql
go

use injectionsql
go

create table usuarios (
	codusu int primary key identity(1,1),
	nomusu varchar(25),
	pasusu varbinary(max)
)
go

 
insert into usuarios (nomusu, pasusu) values ('user01', pwdencrypt('123'))
go

select * from usuarios
go

alter proc usp_login
@usu varchar(25),
@pas varchar(25)
as
begin
	SET NOCOUNT on
	select * from usuarios where nomusu = @usu and PWDCOMPARE(@pas, pasusu) = 1;
end;
--
declare @nombre as varchar(25)
select @nombre = [name]  from sys.tables
EXEC ('delete from ' + @nombre)