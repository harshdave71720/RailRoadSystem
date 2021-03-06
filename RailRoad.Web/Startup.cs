using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.EntityFrameworkCore.Extensions;
using RailRoad.DataPersistence.Repositories;
using RailRoad.DataPersistenct.EFCore.Repositories;
using RailRoad.Services.Attendances;
using RailRoad.Services.Employees;
using RailRoad.Services.Sites;
using RailRoad.Services.Trips;

namespace RailRoad.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<RailRoadRepository>((options) => options.UseMySQL(Configuration.GetConnectionString("MySqlLocalDb")));
            services.AddScoped<ISiteRepository, RailRoadRepository>();
            services.AddScoped<ITripsRecordRepository, RailRoadRepository>();
            services.AddScoped<IEmployeeAttendanceRepo, RailRoadRepository>();
            services.AddScoped<IAttendanceRepository, RailRoadRepository>();

            services.AddScoped<ISiteManager, SiteManager>();
            services.AddScoped<ITripsRecordManager, TripsRecordManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IAttendanceManager, AttendanceManager>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
