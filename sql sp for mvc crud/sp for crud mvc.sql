
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE StudentViewOrInsert
@mode nvarchar(max),
@Fname nvarchar(max) =null,
@Lname nvarchar(max) =null,
@Age nvarchar(max) =null,
@StudentId int=null
AS
BEGIN
	SET NOCOUNT ON;
	if(@mode='GetStudentList')
	begin
	select
	Id,
	Fname,
	Lname,
	Age
	from tbl_student
	End

	if(@mode='AddStudent')
	begin
	insert into tbl_student(
	Fname,Lname,Age
	)Values(
	@Fname,@Lname,@Age)
	end
	

	if(@mode='GetStudentById')
	begin
	select
	Id,
	Fname,
	Lname,
	age
	from tbl_student
	where Id=@StudentId
	End
	if(@mode='UpdateStudent')
	begin
	update tbl_student
	set Fname=@Fname,
	Lname=@Lname,
	Age=@Age
	where Id=@StudentId
	End

	if(@mode='DeleteStudent')
	begin
	delete from tbl_student where Id=@StudentId
	End



	End






