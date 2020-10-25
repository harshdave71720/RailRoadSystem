using System;
using System.Collections.Generic;
using System.Text;
using RailRoad.DataPersistence.Entities;

namespace RailRoad.Services.Attendances
{
    public interface IAttendanceManager
    {
        public Attendance[] RetrieveAttendances(DateTime date, bool includeEmployee = false);

        public Attendance[] RetrieveEmployeeAttendances(Employee[] employees, DateTime date);

        public void MarkEmployeeAttendance(Attendance attendance);
    }
}
