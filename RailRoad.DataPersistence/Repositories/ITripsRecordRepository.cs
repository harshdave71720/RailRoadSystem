using RailRoad.DataPersistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailRoad.DataPersistence.Repositories
{
    public interface ITripsRecordRepository : RepositoryBase
    {        

        public TripsRecord CreateTripsRecord(TripsRecord tripsRecord);

        public TripsRecord RetrieveTripsRecord(int id);        

        public TripsRecord[] RetrieveTripsRecords();

        public TripsRecord[] RetrieveTripsRecordsWithSiteInfo();

        public TripsRecord UpdateTripsRecord(TripsRecord tripsRecord);

        public TripsRecord DeleteTripsRecord(int id);        
    }
}
