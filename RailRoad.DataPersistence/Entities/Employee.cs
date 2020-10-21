using RailRoad.DataPersistence.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("EMPLOYEE")]
    public class Employee
    {
        [Required]
        [Key]
        [Column("LICENSE_NUMBER")]
        [MaxLength(30)]
        public string License { get; set; }

        [Required]
        [Column("NAME")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("ADHAAR")]
        [MaxLength(12)]
        public string Adhaar { get; set; }

        [Column("MOBILE")]
        [MaxLength(10)]
        public string Mobile { get; set; }

        [Column("ADDRESS")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [Column("SALARY")]
        public double Salary { get; set; }

        [Required]
        [Column("DESIGNATION", TypeName = "VARCHAR(30)")]
        public Designation Designation { get; set; }

        [Column("ISWORKING")]
        public bool IsWorking { get; set; }

        public List<Attendance> Attendances { get; set; }

        public List<EmployeePaymentRecord> PaymentRecords { get; set; }
    }
}
