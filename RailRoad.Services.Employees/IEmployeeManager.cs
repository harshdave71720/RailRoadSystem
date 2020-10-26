using RailRoad.DataPersistence.Entities;
using System;

namespace RailRoad.Services.Employees
{
    public interface IEmployeeManager
    {
        public Employee CreateEmployee(Employee employee);

        public Employee RetrieveEmployee(string license, bool includeAttendance = false);
        
        public Employee[] RetrieveEmployees(bool includeAttendance = false);

        public Employee UpdateEmployee(Employee employee);

        public Employee DeleteEmployee(string license);
    }
}
