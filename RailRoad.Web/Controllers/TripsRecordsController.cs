using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailRoad.DataPersistence.Entities;
using RailRoad.Services.Sites;
using RailRoad.Services.Trips;
using RailRoad.Web.Models;

namespace RailRoad.Web.Controllers
{
    [Route("TripsRecords")]
    public class TripsRecordsController : Controller
    {
        private ITripsRecordManager TripsRecordManager;
        private ISiteManager SiteManager;

        public TripsRecordsController(ITripsRecordManager tripsRecordManager, ISiteManager siteManager)
        {
            this.TripsRecordManager = tripsRecordManager;
            this.SiteManager = siteManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Add")]
        public IActionResult AddTripsRecord()
        {
            Site[] sites = this.SiteManager.RetrieveSites(true, true);
            Site site = sites.FirstOrDefault() ?? new Site() { SiteCharges = new SiteCharges()};
            return View("AddEditTripsRecord", new AddTripsRecordModel {
                TripsRecord = new TripsRecord() {
                    Date = DateTime.Now,
                    Distance = site.Distance,
                    TruckCapacity = site.DefaultTruckCapacity,
                    TripCharges = new TripsRecordCharges {
                        ExcavationCharge = site.SiteCharges.ExcavationCharge,
                        LntBasicCharge = site.SiteCharges.LntBasicCharge,
                        LntLeadingCharge = site.SiteCharges.LntLeadingCharge
                    },
                    ExcavationDone = true,
                    LntDone = true
                },
                Sites = sites,
                SelectedSite = sites.FirstOrDefault() ?? new Site()
            });
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddTripsRecord(AddTripsRecordModel recordModel)
        {
            if (recordModel.TripsRecord.Id > 0)
            {
                this.TripsRecordManager.UpdateTripsRecord(recordModel.TripsRecord);
            }
            else 
            {
                this.TripsRecordManager.CreateTripsRecord(recordModel.TripsRecord);
            }
            return RedirectToAction("Index");
        }

        [Route("Edit/{id}")]
        public IActionResult EditTripsRecord(int id)
        {
            TripsRecord record = this.TripsRecordManager.RetrieveTripsRecord(id);
               
            if (record == null)
            {
                return RedirectToAction("Index");
            }

            Site[] sites = this.SiteManager.RetrieveSites(true);
            return View("AddEditTripsRecord", new AddTripsRecordModel
            {
                TripsRecord = record,
                Sites = sites,
                SelectedSite = record.Site //?? sites.FirstOrDefault()
            });
        }
    }
}
