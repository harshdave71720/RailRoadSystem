using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RailRoad.DataPersistence.Entities
{
    [Table("SITECHARGES")]
    public class SiteCharges : OperatingCharges
    {        
        public Site Site { get; set; }

        [Required]
        [Column("SITE_ID")]
        [ForeignKey("Site")]
        public int SiteId { get; set; }
    }
}
