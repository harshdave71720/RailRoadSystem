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
            optionsBuilder.UseMySQL("Server = localhost; Database = RailRoad; Uid = root; Pwd = root;");
            base.OnConfiguring(optionsBuilder);
        }

        public Site CreateSite(Site site)
        {
            int id = this.Sites.Add(site).Entity.Id;
            this.SaveChanges();
            return this.RetrieveSite(id);
        }

        public TripsRecord CreateTripsRecord(TripsRecord tripsRecord)
        {
            int id = this.TripsRecords.Add(tripsRecord).Entity.Id;
            this.SaveChanges();
            return this.RetrieveTripsRecord(id);
        }

        public Site DeleteSite(int id)
        {
            Site site = this.RetrieveSite(id);
            if (site == null)
                return site;

            this.Sites.Remove(site);
            this.SaveChanges();
            return site;
        }

        public TripsRecord DeleteTripsRecord(int id)
        {
            TripsRecord record = this.RetrieveTripsRecord(id);

            if (record == null) return record;

            this.TripsRecords.Remove(record);
            this.SaveChanges();
            return record;
        }

        public Site RetrieveSite(int id)
        {
            return this.Sites.Find(id);
        }

        public Site RetrieveSiteWithTripCharges(int id)
        {
            return this.Sites.Include(s => s.DefaultTripCharges).FirstOrDefault(x => x.Id == id);
        }

        public Site[] RetrieveSites()
        {
            return this.Sites.ToArray();
        }

        public Site[] RetrieveSitesWithTripCharges()
        {
            return this.Sites.Include(s => s.DefaultTripCharges).ToArray();
        }

        public TripsRecord RetrieveTripsRecord(int id)
        {
            return this.TripsRecords.Find(id);
        }

        public TripsRecord[] RetrieveTripsRecords()
        {
            return this.TripsRecords.ToArray();
        }

        public Site UpdateSite(Site site)
        {
            this.Sites.Update(site);
            this.SaveChanges();
            return this.RetrieveSite(site.Id);
        }

        public TripsRecord UpdateTripsRecord(TripsRecord tripsRecord)
        {
            this.TripsRecords.Update(tripsRecord);
            this.SaveChanges();
            return this.RetrieveTripsRecord(tripsRecord.Id);
        }
    }
}
