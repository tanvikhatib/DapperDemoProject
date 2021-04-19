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
