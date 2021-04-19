create procedure SPDeleteEmployee(
  @id int
) AS
BEGIN
    DELETE FROM Employee
    WHERE EmployeeId = @id

END
