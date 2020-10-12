using Microsoft.EntityFrameworkCore;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RailRoad.DataPersistenct.EFCore.Repositories
{
    public class SiteTripRepository : DbContext, ISiteRepository, ITripsRecordRepository
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<TripsRecord> TripsRecords { get; set; }
        public DbSet<TripCharges> TripCharges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost:3306;database=RailRoadTemp;user=root");
            base.OnConfiguring(optionsBuilder);
        }

        public TripsRecord DeleteTripsRecord(int id)
        {
            throw new NotImplementedException();
        }

        public TripsRecord GetTripsRecord(int id, bool includeTripCharges = false, bool includeSiteInfo = false)
        {
            throw new NotImplementedException();
        }

        public TripsRecord[] GetTripsRecords(bool includeTripCharges = false, bool includeSiteInfo = false)
        {
            throw new NotImplementedException();
        }

        public TripsRecord SaveTripsRecord(TripsRecord tripsRecord)
        {
            throw new NotImplementedException();
        }

        public TripsRecord UpdateTripsRecord(TripsRecord tripsRecord)
        {
            throw new NotImplementedException();
        }

        public Site DeleteSite(int id)
        {
            throw new NotImplementedException();
        }

        public Site GetSite(int id, bool includeTripCharges = false, bool includeTripsRecords = false)
        {
            throw new NotImplementedException();
        }

        public Site[] GetSites(bool includeTripCharges = false, bool includeTripsRecords = false)
        {
            return this.Sites.ToArray();
        }

        public Site SaveSite(Site Site)
        {
            throw new NotImplementedException();
        }

        public Site UpdateSite(Site Site)
        {
            throw new NotImplementedException();
        }

    }    
}
