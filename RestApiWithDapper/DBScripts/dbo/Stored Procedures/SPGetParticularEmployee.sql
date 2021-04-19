Create PROCEDURE SPGetParticularEmployee (@id int)
as
    select * from Employee where EmployeeId = @id;
