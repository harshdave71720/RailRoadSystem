using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistenct.EFCore.Repositories;
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

        [Route("{siteId}")]
        public IActionResult ShowTripsRecords(int siteId)
        {
            TripsRecord[] tripsRecords = TripsRecordManager.RetrieveTripsRecords(true, true).Where(tr => tr.SiteId == siteId).ToArray() ?? Array.Empty<TripsRecord>();
            foreach (TripsRecord record in tripsRecords) 
            { 
                record.Revenue = this.CalculateRevenue(record); 
            }
            ViewData["SiteId"] = siteId;
            return View("Index",tripsRecords);
        }       
        
        //public IActionResult AddTripsRecord()
        //{
        //    Site[] sites = this.SiteManager.RetrieveSites(true, true);
        //    //Site site = this.SiteManager.RetrieveSite(siteId, true);
        //    Site site = null;
        //    if (site == null)
        //    {
        //        site = sites.FirstOrDefault() ?? new Site() { SiteCharges = new SiteCharges() };
        //    }
        //    return View("AddEditTripsRecord", new AddTripsRecordModel
        //    {
        //        TripsRecord = new TripsRecord()
        //        {
        //            Date = DateTime.Now,
        //            Distance = site.Distance,
        //            TruckCapacity = site.DefaultTruckCapacity,
        //            TripCharges = new TripsRecordCharges
        //            {
        //                ExcavationCharge = site.SiteCharges.ExcavationCharge,
        //                LntBasicCharge = site.SiteCharges.LntBasicCharge,
        //                LntLeadingCharge = site.SiteCharges.LntLeadingCharge
        //            },
        //            ExcavationDone = true,
        //            LntDone = true
        //        },
        //        Sites = sites,
        //        SelectedSite = sites.FirstOrDefault() ?? new Site()
        //    });
        //}

        [HttpGet]
        [Route("Add/{siteId}")]
        public IActionResult AddTripsRecord(int siteId)
        {
            Site site = this.SiteManager.RetrieveSite(siteId, true);
            if (site == null)
            {
                throw new Exception("Site Not Found");
            }
            return View("AddEditTripsRecord", new AddTripsRecordModel
            {
                TripsRecord = new TripsRecord()
                {
                    Date = DateTime.Now,
                    Distance = site.Distance,
                    TruckCapacity = site.DefaultTruckCapacity,
                    TripCharges = new TripsRecordCharges
                    {
                        ExcavationCharge = site.SiteCharges.ExcavationCharge,
                        LntBasicCharge = site.SiteCharges.LntBasicCharge,
                        LntLeadingCharge = site.SiteCharges.LntLeadingCharge
                    },
                    ExcavationDone = true,
                    LntDone = true
                },
                SelectedSite = site,
                SiteId = site.Id,
                Sites = new Site[] { site }
            });
        }
        
        [HttpPost]
        [Route("Add/{siteId}")]        
        public IActionResult AddTripsRecord([FromForm] AddTripsRecordModel recordModel)
        {
            Site site = SiteManager.RetrieveSite(recordModel.TripsRecord.SiteId);
            if (site == null)
            {
                throw new Exception("Site not fount");
            }
            //recordModel.TripsRecord.Site = site;

            if (recordModel.TripsRecord.Id > 0)
            {
                this.TripsRecordManager.UpdateTripsRecord(recordModel.TripsRecord);
            }
            else
            {
                this.TripsRecordManager.CreateTripsRecord(recordModel.TripsRecord);
            }
                        
            return RedirectToAction("ShowTripsRecords", new { siteId = site.Id });
        }

        [Route("Edit/{id}")]
        public IActionResult EditTripsRecord(int id)
        {
            TripsRecord record = this.TripsRecordManager.RetrieveTripsRecord(id);
            record.Revenue = this.CalculateRevenue(record);
            if (record == null)
            {
                return RedirectToAction("Index");
            }

            Site[] sites = this.SiteManager.RetrieveSites(true, false);
            return View("AddEditTripsRecord", new AddTripsRecordModel
            {
                TripsRecord = record,
                Sites = sites,
                SelectedSite = record.Site //?? sites.FirstOrDefault()
            });
        }

        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            this.TripsRecordManager.DeleteTripsRecord(id);
            return RedirectToAction("Index");
        }

        private double CalculateRevenue(TripsRecord record)
        {
            double revenue = 0;
            
            if (record.ExcavationDone)
            {
                revenue += record.TripCharges.ExcavationCharge;
            }
            if (record.Distance <= 0)
            {
                return revenue;
            }
            if (record.LntDone)
            {
                revenue += record.TripCharges.LntBasicCharge;
                revenue += record.TripCharges.LntLeadingCharge * (record.Distance - 1);
            }

            return revenue * record.TruckCapacity * record.TripsCount;
        }
    }
}
