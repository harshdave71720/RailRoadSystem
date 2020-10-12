using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("TRIPCHARGES")]
    public class TripCharges
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("EXCAVATION_CHARGE", TypeName = "DECIMAL(4, 2)")]
        public double ExcavationCharge { get; set; }

        [Column("LNT_BASIC_CHARGE", TypeName = "DECIMAL(4, 2)")]
        public double LntBasicCharge { get; set; }

        [Column("LNT_LEADING_CHARGE", TypeName = "DECIMAL(4, 2)")]
        public double LntLeadingCharge { get; set; }
    }
}
