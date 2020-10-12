using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.DataPersistence.Repositories
{
    public interface ITripsRecordRepository : RepositoryBase
    {        

        public TripsRecord SaveTripsRecord(TripsRecord tripsRecord);

        public TripsRecord GetTripsRecord(int id, bool includeTripCharges = false, bool includeSiteInfo = false);

        public TripsRecord[] GetTripsRecords(bool includeTripCharges = false, bool includeSiteInfo = false);

        //public TripsRecord[] GetTripsRecordsBySite(int siteId);

        public TripsRecord UpdateTripsRecord(TripsRecord tripsRecord);

        public TripsRecord DeleteTripsRecord(int id);

        //public TripsRecord[] DeleteTripsRecrods(int[] ids);
    }
}
