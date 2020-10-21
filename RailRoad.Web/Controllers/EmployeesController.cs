using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using RailRoad.Services.Employees;

namespace RailRoad.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeManager EmployeeManager;

        private ILogger<EmployeesController> Logger;

        public EmployeesController(IEmployeeManager employeeManager, ILogger<EmployeesController> logger)
        {
            this.EmployeeManager = employeeManager;
            this.Logger = logger;
        }
        public IActionResult Index()
        {
            return View(this.EmployeeManager.RetrieveEmployees());
        }

        public IActionResult Add()
        {
            return View("AddEditEmployee", new Employee());
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            this.EmployeeManager.CreateEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
