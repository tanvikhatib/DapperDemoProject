using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestApiWithDapper.Controllers
{

    /// <summary>
    /// This is a application controller used to display the html page
    /// </summary>
    [Route("api/employeeregister")]
    public class EmployeeRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
