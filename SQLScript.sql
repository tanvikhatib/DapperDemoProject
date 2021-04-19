CREATE TABLE [dbo].[Employee] (
    [EmployeeId]     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (255) NOT NULL,
    [LastName]       NVARCHAR (255) NULL,
    [Department]     NVARCHAR (255) NULL,
    [JobTitle]       NVARCHAR (150) NOT NULL,
    [PhoneExtension] NVARCHAR (4)   NOT NULL,
    [Salary]         NVARCHAR (20)  NOT NULL,
    [Bonus]          NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);


GO
PRINT N'Creating [dbo].[SPDeleteEmployee]...';


GO
create procedure SPDeleteEmployee(
  @id int
) AS
BEGIN
    DELETE FROM Employee
    WHERE EmployeeId = @id

END
GO
PRINT N'Creating [dbo].[SPGetAllEmployeeData]...';


GO
Create PROCEDURE SPGetAllEmployeeData 
as
    select * from Employee;
GO
PRINT N'Creating [dbo].[SPGetParticularEmployee]...';


GO
Create PROCEDURE SPGetParticularEmployee (@id int)
as
    select * from Employee where EmployeeId = @id;
GO
PRINT N'Creating [dbo].[SPInsertEmployee]...';


GO

CREATE PROCEDURE [dbo].[SPInsertEmployee] (
  @FirstName nvarchar(255),
  @LastName nvarchar(255),
  @Department nvarchar(255),
  @JobTitle nvarchar(150),
  @PhoneExtension nvarchar(4),
  @Salary nvarchar(20),
  @Bonus nvarchar(20)
) AS
BEGIN
    INSERT INTO Employee(FirstName,LastName,Department,JobTitle,PhoneExtension,Salary ,Bonus)
    VALUES ( @FirstName, @LastName,@Department,@JobTitle, @PhoneExtension ,@Salary ,@Bonus);
END
GO
PRINT N'Creating [dbo].[SPUpdatEmployee]...';


GO
create procedure SPUpdatEmployee(
  @FirstName nvarchar(255),
  @LastName nvarchar(255),
  @Department nvarchar(255),
  @JobTitle nvarchar(150),
  @PhoneExtension nvarchar(4),
  @Salary nvarchar(20),
  @Bonus nvarchar(20),
  @id int
) AS
BEGIN
    UPDATE Employee set 
	FirstName = @FirstName,
	LastName = @LastName,
	Department = @Department,
	JobTitle =  @JobTitle,
	PhoneExtension = @PhoneExtension,
	Salary = @Salary,
	Bonus = @Bonus
    WHERE EmployeeId = @id

	SELECT 1
END
GO
PRINT N'Update complete.';


GO
