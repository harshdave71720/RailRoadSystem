using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.DataPersistence.Repositories
{
    public interface ISiteRepository : RepositoryBase
    {
        public Site SaveSite(Site Site);

        public Site GetSite(int id, bool includeTripCharges = false, bool includeTripsRecords = false);

        public Site[] GetSites(bool includeTripCharges = false, bool includeTripsRecords = false);

        public Site UpdateSite(Site Site);

        public Site DeleteSite(int id);

    }
}
