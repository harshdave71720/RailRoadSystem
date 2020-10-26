using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using RailRoad.Services.Attendances;
using RailRoad.Services.Employees;
using RailRoad.Web.Models;

namespace RailRoad.Web.Controllers
{
    public class AttendancesController : Controller
    {
        private IAttendanceManager AttendanceManager;

        private ILogger<AttendancesController> Logger;

        private IEmployeeManager EmployeeManager;

        public AttendancesController(IAttendanceManager attendanceManager,IEmployeeManager employeeManager, ILogger<AttendancesController> logger)
        {
            this.AttendanceManager = attendanceManager;
            this.EmployeeManager = employeeManager;
            this.Logger = logger;
        }

        public IActionResult Index()
        {
            return MarkAttendance(DateTime.Now.Date);
        }

        public IActionResult MarkAttendance(DateTime date)
        {
            //Attendance[] attendances = this.AttendanceManager.RetrieveAttendances(date, true);
            
            //if (attendances?.Length == 0)
            //{
                
            //    //Employee[] employees = EmployeeManager.RetrieveEmployees();
            //    //attendances = employees.Select(e => new Attendance
            //    //{
            //    //    Date = date.Date,
            //    //    EmployeeLicense = e.License,
            //    //    Status = DataPersistence.Enums.AttendanceStatus.ABSENT,
            //    //    Employee = e
            //    //}).ToArray();
            //}
            Employee[] employees = EmployeeManager.RetrieveEmployees();
            Attendance[] attendances = this.AttendanceManager.RetrieveEmployeeAttendances(employees, date);


            return View("Index", new MarkAttendanceModel() { 
                Date = date.Date,
                Attendances = attendances
            });
        }

        [HttpPost]
        public IActionResult MarkAttendance(Attendance attendance)
        {
            this.AttendanceManager.MarkEmployeeAttendance(attendance);
            return this.MarkAttendance(attendance.Date);
        }
    }
}
