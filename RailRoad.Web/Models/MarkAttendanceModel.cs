using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailRoad.Web.Models
{
    public class MarkAttendanceModel
    {
        public DateTime Date { get; set; }

        public Attendance[] Attendances { get; set; }
    }
}
