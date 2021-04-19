using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.Business;
using APIDemo.DataAccess.Interfaces;
using APIDemo.SharedEntities.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApiWithDapper.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDapper Idapper; //instantiate readonly object of IDapper interface
        public EmployeeController(IDapper idapper)
        {
            Idapper = idapper; //set the Idapper oobject
        }

        /// <summary>
        /// This method is used to get all the employees from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            try
            {
                EmployeeManager employeeManager = new EmployeeManager(Idapper);
                return await employeeManager.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// This method is used to post the new employee information to the database, it takes one paramer i.e. employee which is of Type Employee and its takes the data from body so FromBody attribute is added
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Create([FromBody] Employee employee)
        {
            try
            {
                EmployeeManager employeeManager = new EmployeeManager(Idapper);
                return await employeeManager.CreateNewEmployee(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }


        /// <summary>
        /// This method is used to get a single employee from the database based on the specified employeeid , it takes one parameter Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")] 
        public async Task<Employee> Get(int id)
        {
            try
            {
                EmployeeManager employeeManager = new EmployeeManager(Idapper);
                return await employeeManager.GetEmployeeDetails(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This method is used to delete an employee record from the database based on the specified employeeid , it takes one parameter Id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<int> Delete(int id)
        {
            try
            {
                EmployeeManager employeeManager = new EmployeeManager(Idapper);
                return await employeeManager.DeleteEmployee(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// This method is used tto update the employee record in the database, it takes one paramer i.e. employee which is of Type Employee and its takes the data from body so FromBody attribute is added
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<string> Update([FromBody] Employee employee)
        {
            try
            {
                EmployeeManager employeeManager = new EmployeeManager(Idapper);
                return await employeeManager.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
