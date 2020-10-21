using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("EMPLOYEE_PAYMENT_RECORD")]
    public class EmployeePaymentRecord
    {
        [Required]
        [Key]
        [Column("DATE", TypeName = "DATE", Order = 1)]
        public DateTime Date { get; set; }

        [Required]
        [Key]
        [Column("EMPLOYEE_LICENSE", Order = 2)]
        [ForeignKey("Employee")]
        [MaxLength(30)]
        public string EmployeeLicense { get; set; }

        [Required]
        [Column("AMOUNT")]
        public double Amount { get; set; }
        
        [Column("DESCRIPTION")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column("IS_SETTLED")]
        public bool IsSettled { get; set; }

        public Employee Employee { get; set; }
    }
}
