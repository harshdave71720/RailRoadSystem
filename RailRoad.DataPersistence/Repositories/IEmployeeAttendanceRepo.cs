using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.DataPersistence.Repositories
{
    public interface IEmployeeAttendanceRepo : IRepositoryBase
    {
        public Employee CreateEmployee(Employee employee);

        public Employee RetrieveEmployee(string license);

        public Employee RetrieveEmployeeWithAttendance(string license);

        public Employee[] RetrieveEmployees();

        public Employee[] RetrieveEmployeesWithAttendance();

        public Employee UpdateEmployee(Employee employee);

        public Employee DeleteEmployee(string license);
    
    }
}
