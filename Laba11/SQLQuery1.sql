create database OOP11

use OOP11
create table Tovar
(
names nvarchar(15),
typess nvarchar(15),
cost float ,
info nvarchar(25)
)
create table Zakaz
(
ids int identity (100,2),
namesss  nvarchar(15),
cost float ,
client nvarchar(10),
Photo nvarchar(150)
)

go
create procedure alltovar
as
select  * from Tovar

go
create procedure allzakaz
as
select  * from Zakaz order by  namesss
drop table Zakaz