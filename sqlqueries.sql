
CREATE TABLE SampleStudy.dbo.Communication (
	Id bigint IDENTITY(1,1) NOT NULL,
	PersonId bigint NOT NULL,
	Mail varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MobilPhone varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	LocalPhone varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	IsActive int NOT NULL,
	CreatedDate datetime DEFAULT getdate() NOT NULL,
	UpdatedDate datetime NULL,
	CreatedUser varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UpdatedUser varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	IsDeleted int DEFAULT 0 NOT NULL,
	CONSTRAINT Communication_PK PRIMARY KEY (Id)
);




CREATE TABLE SampleStudy.dbo.Department (
	Id bigint IDENTITY(1,1) NOT NULL,
	DepartmentName varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	IsActive int DEFAULT 1 NOT NULL,
	CreatedDate datetime NOT NULL,
	UpdatedDate datetime NULL,
	UpdatedUser varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CreatedUser varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DepartmentCode int NOT NULL,
	IsDeleted int DEFAULT 0 NOT NULL
);




CREATE TABLE SampleStudy.dbo.Person (
	Id bigint IDENTITY(1,1) NOT NULL,
	Name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Surname varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	WorkStartDate datetime NOT NULL,
	WorkFinishDate datetime NULL,
	CreatedDate datetime NULL,
	UpdatedDate datetime NULL,
	IsActive bit DEFAULT 1 NOT NULL,
	Gender int NOT NULL,
	EmployeeCode varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CreatedUser varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UpdatedUser varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DepartmentId bigint NULL,
	IsDeleted int DEFAULT 0 NOT NULL,
	CONSTRAINT Person_PK PRIMARY KEY (Id)
);



create procedure sp_DepartmentInsert
@DepartmentName varchar, 
@IsActive int , 
@CreatedUser datetime,
@DepartmentCode int
as
BEGIN
INSERT INTO SampleStudy.dbo.Department
( DepartmentName, IsActive, CreatedDate ,CreatedUser, DepartmentCode)
VALUES(@DepartmentName, @IsActive, GETDATE(), @CreatedUser, @DepartmentCode);
END


create procedure sp_DepartmentUpdate
@Id bigint,
@DepartmentName varchar, 
@IsActive int, 
@UpdatedUser datetime,
@DepartmentCode int
as
BEGIN
UPDATE SampleStudy.dbo.Department
SET  DepartmentName=@DepartmentName, IsActive=@IsActive, UpdatedDate=GETDATE(), UpdatedUser=@UpdatedUser, DepartmentCode=@DepartmentCode
where Id=@Id
END

Create procedure sp_DepartmentDelete
@Id bigint
@UpdatedUser nvarchar
as
BEGIN
UPDATE SampleStudy.dbo.Department
SET  IsDeleted=1  , UpdatedUser=@UpdatedUser
where Id=@Id
END


create  procedure sp_CommunicationGetAll
as
Begin
	SELECT Id,
	PersonId, 
	Mail, 
	MobilPhone,
	LocalPhone, 
	IsActive, 
	CreatedDate,
	UpdatedDate,
	CreatedUser, 
	UpdatedUser
FROM SampleStudy.dbo.Communication;
END


Alter procedure sp_CommunicationInsert
@PersonId bigint,
@Mail varchar(50),
@MobilPhone varchar(20),
@LocalPhone varchar(20),
@IsActive int,  
@CreatedUser varchar(20)

AS
BEGIN
INSERT INTO SampleStudy.dbo.Communication
(PersonId, Mail, MobilPhone, LocalPhone, IsActive, CreatedDate,CreatedUser)
VALUES(@PersonId, @Mail, @MobilPhone, @LocalPhone, @IsActive, getdate(), @CreatedUser);
END

create procedure sp_CommunicationUpdate
@Id bigint,
@PersonId bigint,
@Mail varchar(50),
@MobilPhone varchar(20),
@LocalPhone varchar(20),
@IsActive int,  
@UpdatedUser varchar(20)

AS
BEGIN
UPDATE SampleStudy.dbo.Communication
SET PersonId=@PersonId, Mail=@Mail, MobilPhone=@MobilPhone, LocalPhone=@LocalPhone, IsActive=@IsActive, UpdatedDate=getdate(), UpdatedUser=@UpdatedUser
WHERE Id=@Id;
END

create procedure sp_CommunicationDelete
@Id bigint,
@UpdatedUser varchar(20)

AS
BEGIN
UPDATE SampleStudy.dbo.Communication
SET  UpdatedDate=getdate(), UpdatedUser=@UpdatedUser , IsDeleted=1
WHERE Id=@Id;
END






create procedure sp_PersonGetAll
as
begin 
select 
p.Id,
p.Name, 
p.Surname, 
p.WorkStartDate,
p.WorkFinishDate, 
p.IsActive, 
p.Gender,
p.EmployeeCode,  
p.DepartmentId,
d.DepartmentCode ,
d.DepartmentName 
from SampleStudy.dbo.Person p
join SampleStudy.dbo.Department d  on p.DepartmentId = d.Id 
end


create procedure sp_PersonGetById
@id bigint
as
begin 
	
select 
p.Id,
p.Name, 
p.Surname, 
p.WorkStartDate,
p.WorkFinishDate, 
p.IsActive, 
p.Gender,
p.EmployeeCode,  
p.DepartmentId,
d.DepartmentCode ,
d.DepartmentName 
from SampleStudy.dbo.Person p
join SampleStudy.dbo.Department d  on p.DepartmentId = d.Id 
where p.id=@id
end 

create procedure  sp_PersonInsert
 @Name nvarchar (50),
 @Surname  nvarchar (50),
 @WorkStartDate datetime, 
 @WorkFinishDate datetime, 
 @IsActive int, 
 @Gender int, 
 @EmployeeCode  nvarchar (10), 
 @CreatedUser  nvarchar (20),
 @DepartmentId bigint
 as
 begin
 INSERT INTO SampleStudy.dbo.Person
(Name, Surname, WorkStartDate, WorkFinishDate, CreatedDate, IsActive,  Gender, EmployeeCode,  CreatedUser, DepartmentId)
VALUES(@Name,@Surname, @WorkStartDate, @WorkFinishDate, getDate(),   @IsActive, @Gender, @EmployeeCode, @CreatedUser,@DepartmentId);
end
 
 
 

create procedure sp_PersonUpdate
 @Id bigint,
 @Name nvarchar (50),
 @Surname  nvarchar (50),
 @WorkStartDate datetime, 
 @WorkFinishDate datetime, 
 @IsActive int, 
 @Gender int, 
 @EmployeeCode  nvarchar (10), 
 @UpdatedUser  nvarchar (20),
 @DepartmentId bigint
 
 as 
 begin 
 	UPDATE SampleStudy.dbo.Person
SET Name=@Name, Surname=@SurName, WorkStartDate=@WorkStartDate, WorkFinishDate=@WorkFinishDate, UpdatedDate=GetDate(), IsActive=@IsActive, Gender=@Gender, EmployeeCode=@EmployeeCode, UpdatedUser=@UpdatedUser, DepartmentId=@DepartmentId
WHERE Id=@Id;
 end
 
 create procedure sp_PersonDelete
 @Id bigint,
 @UpdatedUser  nvarchar (20)
 as 
 begin 
 	UPDATE SampleStudy.dbo.Person
SET  UpdatedUser=@UpdatedUser, IsDeleted=1
WHERE Id=@Id;
 end
 
 
 
 
 
 
