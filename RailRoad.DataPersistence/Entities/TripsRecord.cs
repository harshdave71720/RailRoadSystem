using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("TRIPSRECORD")]
    public class TripsRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRIPSRECORD_ID")]
        public int Id { get; set; }

        [Required]
        [Column("TRIPS_DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column("DISTANCE")]
        public double Distance { get; set; }

        [Required]
        [Column("TRIPS_COUNT")]
        public  int TripsCount { get; set; }     
        
        [Required]
        [Column("TRUCK_CAPACITY")]
        public double TruckCapacity { get; set; }

        [Required]
        [Column("DIESEL_QUANTITY")]
        public double DieselQuantity { get; set; }

        [Required]
        [Column("DIESEL_PRICE")]
        public double DieselPrice { get; set; }

        [Column("CHAINAGE")]
        public string Chainage { get; set; }

        [Column("EXCAVATION_DONE")]
        public bool ExcavationDone { get; set; }

        [Column("LNT_DONE")]
        public bool LntDone { get; set; }

        public Site Site { get; set; }

        [Required]
        [Column("SITE_ID")]
        [ForeignKey("Site")]
        public int SiteId { get; set; }
       
        [Required]
        public TripsRecordCharges TripCharges { get; set; }        
    }
}
