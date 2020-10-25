using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.DataPersistence.Repositories
{
    public interface IAttendanceRepository : IRepositoryBase
    {
        public Attendance[] RetrieveAttendances(DateTime date);
                
        
        public Attendance[] RetrieveAttendancesWithEmployee(DateTime date);

        public Attendance[] RetrieveAttendance(string employeeLicense);
        
        public Attendance[] RetrieveAttendanceWithEmployee(string employeeLicense);

        public Attendance RetrieveAttendance(string employeeLicense, DateTime date);
        
        public Attendance RetrieveAttendanceWithEmployee(string employeeLicense, DateTime date);        

        public Attendance CreateAttendance(Attendance attendance);

        public Attendance UpdateAttendance(Attendance attendance);
    }
}
