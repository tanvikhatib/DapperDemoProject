
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
