using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailRoad.Services.Trips;

namespace RailRoad.Web.Controllers
{
    public class TripsRecordsController : Controller
    {
        private ITripsRecordManager TripsRecordManager;

        public TripsRecordsController(ITripsRecordManager tripsRecordManager)
        {
            this.TripsRecordManager = tripsRecordManager;
        }

        public TripsRecordsController()
        {
            this.TripsRecordManager = new TripsRecordManager();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
