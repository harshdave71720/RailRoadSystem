using Microsoft.EntityFrameworkCore;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RailRoad.DataPersistenct.EFCore.Repositories
{
    public class RailRoadRepository : DbContext, ISiteRepository, ITripsRecordRepository, IEmployeeAttendanceRepo
    {        
        public DbSet<Site> Sites { get; set; }
        public DbSet<TripsRecord> TripsRecords { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeePaymentRecord> PaymentRecords { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        private string ConnectionString;

        public RailRoadRepository(DbContextOptions<RailRoadRepository> dbContextOptions) : base(dbContextOptions)
        {                            
        }

        public RailRoadRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public RailRoadRepository()
        {
            this.ConnectionString = "Server = localhost; Database = RailRoad; Uid = root; Pwd = root;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.ConnectionString != null)
            {
                optionsBuilder.UseMySQL(this.ConnectionString);
            }
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create((builder) => builder.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }

        #region ISiteRepository And ITripsRepo Methods        

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

        #region IEmployeeAttendanceRepo methods
        public Employee CreateEmployee(Employee employee)
        {
            this.Employees.Add(employee);
            this.SaveChanges();
            return employee;
        }

        public Employee RetrieveEmployee(string license)
        {
            return this.Employees.Find(license);
        }

        public Employee RetrieveEmployeeWithAttendance(string license)
        {
            return this.Employees.Include(e => e.Attendances).FirstOrDefault(e => e.License == license);
        }

        public Employee[] RetrieveEmployees()
        {
            return this.Employees.ToArray();
        }

        public Employee[] RetrieveEmployeesWithAttendance()
        {
            return this.Employees.Include(e => e.Attendances).ToArray();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            this.Employees.Update(employee);
            this.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(string license)
        {
            Employee employee = this.Employees.Find(license);
            if (employee == null) return employee;

            this.Employees.Remove(employee);           
            this.SaveChanges();
            return employee;
        }


        #endregion
    }
}
