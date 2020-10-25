using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using System;
using RailRoad.DataPersistence.Repositories;
using System.Linq;

namespace RailRoad.Services.Attendances
{
    public class AttendanceManager : IAttendanceManager
    {
        private IAttendanceRepository AttendaceRepository;

        private ILogger<AttendanceManager> Logger;

        public AttendanceManager(ILogger<AttendanceManager> logger, IAttendanceRepository attendaceRepository)
        {
            this.Logger = logger;
            this.AttendaceRepository = attendaceRepository;
        }

        public Attendance[] RetrieveAttendances(DateTime date, bool includeEmployee = false)
        {
            if (includeEmployee)
                return this.AttendaceRepository.RetrieveAttendancesWithEmployee(date);
            else
                return this.AttendaceRepository.RetrieveAttendances(date);
        }

        public Attendance[] RetrieveEmployeeAttendances(Employee[] employees, DateTime date)
        {
            Attendance[] attendances = this.RetrieveAttendances(date, true);
            Employee[] remainingEmployees = employees.Where(e => !attendances.Any(a => a.EmployeeLicense.Equals(e.License))).ToArray();
            return attendances.Concat(remainingEmployees.Select(e => new Attendance
            {
                EmployeeLicense = e.License,
                Date = date,
                Status = DataPersistence.Enums.AttendanceStatus.ABSENT,
                Employee = e
            })).OrderBy(x => x.Employee.Name).ToArray();
        }

        public void MarkEmployeeAttendance(Attendance attendance)
        {
            Attendance attendance1 = this.AttendaceRepository.RetrieveAttendance(attendance.EmployeeLicense, attendance.Date);
            if (attendance1 == null)
            {
                this.AttendaceRepository.CreateAttendance(attendance);
            }
            else
            {
                attendance1.Status = attendance.Status;
                this.AttendaceRepository.UpdateAttendance(attendance1);
            }
        }
    }
}
