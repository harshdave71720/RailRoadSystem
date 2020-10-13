﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("SITE")]
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SITE_ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]        
        public string Name { get; set; }

        [Column("DEF_TRUCK_CAPACITY")]
        [Required]
        public double DefaultTruckCapacity { get; set; }             
       
        [Required]
        [Column("DISTANCE")]
        public int Distance { get; set; }

        public TripCharges DefaultTripCharges { get; set; }

        [Column("TRIPCHARGES_ID")]
        [ForeignKey("DefaultTripCharges")]
        public int DefaultTripChargesId { get; set; }

        public IEnumerable<TripsRecord> TripsRecords { get; set; }     
    }
}
