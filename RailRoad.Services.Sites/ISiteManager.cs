using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.Services.Sites
{
    public interface ISiteManager
    {
        public Site CreateSite(Site site);

        public Site RetrieveSite(int id);

        public Site RetrieveSite(int id, bool includeTripCharges);

        public Site[] RetrieveSites(bool orderByName = false);

        public Site[] RetrieveSites(bool includeTripCharges, bool orderByName = false);

        public Site[] RetrieveSites(int[] ids, bool orderByName = false);        
       
        //public Site RetrieveSiteWithTripsRecords(int id);

        public Site UpdateSite(Site site);

        public Site DeleteSite(int id);
    }
}
