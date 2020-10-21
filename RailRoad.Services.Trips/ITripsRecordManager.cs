using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace RailRoad.Services.Trips
{
    public interface ITripsRecordManager
    {
        
        public TripsRecord CreateTripsRecord(TripsRecord tripsRecord);        

        public TripsRecord RetrieveTripsRecord(int id);

        //public TripsRecord RetrieveTripsRecordWithSite(int id);

        public TripsRecord[] RetrieveTripsRecords(bool orderByDate = false);

        public TripsRecord[] RetrieveTripsRecords(bool orderByDate = false, bool includeSiteInfo = false);

        //public TripsRecord[] RetrieveTripsRecords(int[] ids, bool orderByDate = false);

        public TripsRecord[] RetrieveTripsRecordsWithSite(int[] ids, bool orderByDate = false);

        public TripsRecord UpdateTripsRecord(TripsRecord tripsRecord);

        public TripsRecord DeleteTripsRecord(int id);
    }
}
