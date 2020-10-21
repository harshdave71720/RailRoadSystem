using RailRoad.DataPersistence.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("ATTENDANCE")]
    public class Attendance
    {
        [Key]
        [Required]
        [Column("DATE", TypeName = "DATE", Order = 1)]
        public DateTime Date { get; set; }

        [Required]
        [Key]
        [Column("EMPLOYEE_LICENSE", Order = 2)]
        [ForeignKey("Employee")]
        public string EmployeeLicense { get; set; }

        [Required]
        [Column("STATUS", TypeName = "VARCHAR(30)")]
        public AttendanceStatus Status { get; set; }

        public Employee Employee { get; set; }
    }
}
