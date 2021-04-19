using APIDemo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIDemo.SharedEntities.Models
{ 
    /// <summary>
  /// This is an employee class 
  /// </summary>
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string PhoneExtension { get; set; }
        [Required]
        public string Salary { get; set; }
        public string Bonus { get; set; }
    }
}
