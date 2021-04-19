using APIDemo.DataAccess.Interfaces;
using APIDemo.SharedEntities.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Business
{
    public class EmployeeManager
    {
        private readonly IDapper Idapper; //instantiate readonly object of IDapper interface
        private string ConnectionString = "DefaultConnection"; //set the name of the connection string mentioned in the appsettings
        public EmployeeManager(IDapper idapper)
        {
            Idapper = idapper; //set the Idapper oobject
        }
     
        /// <summary>
        /// This method is used to get all employees
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllEmployees()
        {
           return  await Task.FromResult(Idapper.RunProcedureForAll<Employee>("SPGetAllEmployeeData", null, ConnectionString)); //get all employees using the GetAll method which is declared in Idapper interface and defined in EmployeeAction class
        }

        /// <summary>
        /// this method is used to get individual employee details
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            var dbparams = new DynamicParameters(); //cretae object of dynamic parameters add all required parameters 
            dbparams.Add("@id", employeeId, DbType.Int32);
            return await Task.FromResult(Idapper.RunProcedureForSingle<Employee>($"SPGetParticularEmployee", dbparams, ConnectionString)); //get individual employee information using the get method which is declared in Idapper interface and defined in EmployeeAction class
        }

        /// <summary>
        /// This method is used to create new employee in the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<string> CreateNewEmployee(Employee employee)
        {
            var dbparams = new DynamicParameters(); //cretae object of dynamic parameters add all required parameters 
            dbparams.Add("@FirstName", employee.FirstName, DbType.String);
            dbparams.Add("@LastName", employee.LastName, DbType.String);
            dbparams.Add("@Department", employee.Department, DbType.String);
            dbparams.Add("@JobTitle", employee.JobTitle, DbType.String);
            dbparams.Add("@PhoneExtension", employee.PhoneExtension, DbType.String);
            dbparams.Add("@Salary", employee.Salary, DbType.String);
            dbparams.Add("@Bonus", employee.Bonus, DbType.String);
            var result = await Task.FromResult(Idapper.RunProcedureForSingle<string>("SPInsertEmployee", dbparams, ConnectionString)); //insert the data using the Insert method which is declared in Idapper interface and defined in EmployeeAction class
            return result;
        }

        /// <summary>
        /// This method is used to update the employee in the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<string> UpdateEmployee(Employee employee)
        {
            var dbparams = new DynamicParameters(); //cretae object of dynamic parameters add all required parameters 
            dbparams.Add("@FirstName", employee.FirstName, DbType.String);
            dbparams.Add("@LastName", employee.LastName, DbType.String);
            dbparams.Add("@Department", employee.Department, DbType.String);
            dbparams.Add("@JobTitle", employee.JobTitle, DbType.String);
            dbparams.Add("@PhoneExtension", employee.PhoneExtension, DbType.String);
            dbparams.Add("@Salary", employee.Salary, DbType.String);
            dbparams.Add("@Bonus", employee.Bonus, DbType.String);
            dbparams.Add("@id", employee.EmployeeId, DbType.Int32);

            return await Task.FromResult(Idapper.RunProcedureForSingle<string>("SPUpdatEmployee", dbparams, ConnectionString)); //insert the data using the Insert method which is declared in Idapper interface and defined in WmployeeAction class
         
        }

        public async Task<int> DeleteEmployee(int employeeId)
        {
            var dbparams = new DynamicParameters(); //cretae object of dynamic parameters add all required parameters 
            dbparams.Add("@id", employeeId, DbType.Int32);
            return await Task.FromResult(Idapper.ItemExecutor($"SPDeleteEmployee", dbparams, ConnectionString)); //delete employee record using the execute method which is declared in Idapper interface and defined in WmployeeAction class

        }

    }
}
