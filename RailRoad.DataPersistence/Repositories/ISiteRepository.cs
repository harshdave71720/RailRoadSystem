using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.DataPersistence.Repositories
{
    public interface ISiteRepository : RepositoryBase
    {
        public Site CreateSite(Site site);

        public Site RetrieveSite(int id);

        public Site[] RetrieveSites();

        public Site UpdateSite(Site site);

        public Site DeleteSite(int id);

    }
}
