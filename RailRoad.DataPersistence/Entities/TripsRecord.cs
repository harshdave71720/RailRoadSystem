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
        [Column("TRIPS_DATE", TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column("TRIPS_COUNT", TypeName = "INT UNSIGNED")]
        public  int TripsCount { get; set; }     

        [Column(TypeName = "DECIMAL(10, 2)")]        
        public double Revenue { get; set; }

        [Required]
        [Column("TRUCK_CAPACITY", TypeName = "DECIMAL(4, 2)")]
        public double TruckCapacity { get; set; }

        [Required]
        [Column("DIESEL_QUANTITY", TypeName = "DECIMAL(6, 2)")]
        public double DieselQuantity { get; set; }

        [Required]
        [Column("DIESEL_PRICE", TypeName = "DECIMAL(6, 2)")]
        public double DieselPrice { get; set; }

        [MaxLength(100)]
        public string Chainage { get; set; }
        
        public Site Site { get; set; }

        [Required]
        [Column("SITE_ID")]
        [ForeignKey("Site")]
        public int SiteId { get; set; }
       
        public TripCharges TripCharges { get; set; }

        [Column("TRIPCHARGES")]
        [ForeignKey("TripCharges")]
        public int TripChargesId { get; set; }
    }
}
