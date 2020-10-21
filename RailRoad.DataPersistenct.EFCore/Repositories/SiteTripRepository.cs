using Microsoft.EntityFrameworkCore;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RailRoad.DataPersistenct.EFCore.Repositories
{
    public class SiteTripRepository : DbContext, ISiteRepository, ITripsRecordRepository
    {        
        public DbSet<Site> Sites { get; set; }
        public DbSet<TripsRecord> TripsRecords { get; set; }

        private string ConnectionString;

        public SiteTripRepository(DbContextOptions<SiteTripRepository> dbContextOptions) : base(dbContextOptions)
        {                            
        }

        public SiteTripRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SiteTripRepository()
        {
            this.ConnectionString = "Server = localhost; Database = RailRoad; Uid = root; Pwd = root;";
        }

        #region ISiteRepository And ITripsRepo Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.ConnectionString != null)
            {
                optionsBuilder.UseMySQL(this.ConnectionString);
            }
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create((builder) => builder.AddConsole()));
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

        public Site RetrieveSiteWithCharges(int id)
        {
            return this.Sites.Include(s => s.SiteCharges).FirstOrDefault(x => x.Id == id);
        }

        public Site[] RetrieveSites()
        {
            return this.Sites.ToArray();
        }

        public Site[] RetrieveSitesWithCharges()
        {
            return this.Sites.Include(s => s.SiteCharges).ToArray();
        }

        public TripsRecord RetrieveTripsRecord(int id)
        {
            return this.TripsRecords.Include(tr => tr.Site).Include(tr => tr.TripCharges).SingleOrDefault(s => s.Id == id);
        }

        public TripsRecord[] RetrieveTripsRecords()
        {
            return this.TripsRecords.Include(tr => tr.TripCharges).ToArray();
        }

        public TripsRecord[] RetrieveTripsRecordsWithSiteInfo()
        {
            return this.TripsRecords.Include(tr => tr.TripCharges).Include(tr => tr.Site).ToArray();
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

        #endregion

        #region

        #endregion
    }
}
