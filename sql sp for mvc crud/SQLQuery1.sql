create database StudentDB
create table tbl_student(
Id int primary key identity(1,1),
Fname nvarchar(max) null,
Lname nvarchar(max) null,
Age int
)
select * from tbl_student