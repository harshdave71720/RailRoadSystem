using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("TRIPSRECORDCHARGES")]
    public class TripsRecordCharges : OperatingCharges
    {               
        public TripsRecord TripsRecord { get; set; }

        [Required]
        [Column("TRIPSRECORD_ID")]
        [ForeignKey("TripsRecord")]
        public int TripsRecordId { get; set; }
    }
}
