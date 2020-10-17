using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace RailRoad.Web.Models
{
    public class AddTripsRecordModel
    {
        public TripsRecord TripsRecord { get; set; }

        public Site[] Sites { get; set; }

        public Site SelectedSite { get; set; }

        public int SiteId { get; set; }
    }
}
