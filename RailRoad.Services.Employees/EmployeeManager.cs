using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.Services.Employees
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeAttendanceRepo EmployeeAttendanceRepo;
        private ILogger<EmployeeManager> Logger;

        public EmployeeManager(ILogger<EmployeeManager> logger, IEmployeeAttendanceRepo employeeAttendanceRepo)
        {
            this.Logger = logger;
            this.EmployeeAttendanceRepo = employeeAttendanceRepo;
        }

        public Employee CreateEmployee(Employee employee)
        {
            try
            {
                return this.EmployeeAttendanceRepo.CreateEmployee(employee);
            }
            catch (Exception ex)
            {
                Logger.LogInformation(string.Format("Cannot Create Employee, Exception Message : {0}", ex.Message));
                throw ex;
            }
            return null;
        }

        public Employee DeleteEmployee(string license)
        {
            try
            {
                return this.EmployeeAttendanceRepo.DeleteEmployee(license);
            }
            catch (Exception ex)
            {
                Logger.LogInformation(string.Format("Cannot Delete Employee (Id : {0}), Exception Message : {1}", license,ex.Message));
                throw ex;
            }
            return null;
        }

        public Employee RetrieveEmployee(string license, bool includeAttendance = false)
        {
            try
            {
                if (includeAttendance)
                {
                    return this.EmployeeAttendanceRepo.RetrieveEmployee(license);
                }
                else 
                {
                    return this.EmployeeAttendanceRepo.RetrieveEmployeeWithAttendance(license);    
                }
            }
            catch (Exception ex)
            {
                Logger.LogInformation(string.Format("Cannot Retrieve Employee (Id : {0}), Exception Message : {1}",license ,ex.Message));
                throw ex;
            }
            return null;
        }

        public Employee[] RetrieveEmployees(bool includeAttendance = false)
        {
            try
            {
                if (includeAttendance)
                {
                    return this.EmployeeAttendanceRepo.RetrieveEmployeesWithAttendance();
                }
                else 
                {
                    return this.EmployeeAttendanceRepo.RetrieveEmployees();
                }
            }
            catch (Exception ex)
            {
                Logger.LogInformation(string.Format("Cannot Retrieve Employees, Exception Message : {0}", ex.Message));
                throw ex;
            }
            return null;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                this.EmployeeAttendanceRepo.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                Logger.LogInformation(string.Format("Cannot Retrieve Employee (Id : {0}), Exception Message : {1}", employee.License, ex.Message));
                throw ex;
            }
            return null;
        }
    }
}
