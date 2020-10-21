using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using RailRoad.Services.Sites;

namespace RailRoad.Web.Controllers
{
    [Route("Sites")]
    public class SitesController : Controller
    {
        private ISiteManager SiteManager;

        private ILogger<SitesController> Logger;

        public SitesController(ISiteManager siteManager, ILogger<SitesController> logger)
        {
            this.SiteManager = siteManager;
            this.Logger = logger;
        }

        public IActionResult Index()
        {            
            Site[] sites = this.SiteManager.RetrieveSites(true, true);
            return View(sites);
        }

        [Route("AddSite")]
        public IActionResult AddSite()
        {
            return View("AddEditSite", new Site());
        }

        [Route("Edit/{id}")]
        public IActionResult EditSite(int id)
        {
            Site site = this.SiteManager.RetrieveSite(id, true);
            if (site == null)
            {
                return RedirectToAction("Index");
            }
            return View("AddEditSite", site);
        }

        [HttpPost]
        [Route("AddSite")]
        public IActionResult AddSite(Site site)
        {
            if (site.Id > 0)
            {
                this.SiteManager.UpdateSite(site);
            }
            else
            {
                this.SiteManager.CreateSite(site);
            }
            return RedirectToAction("Index");
        }
       
       
        [Route("Delete/{id}")]        
        public IActionResult DeleteSite(int id) 
        {
            this.SiteManager.DeleteSite(id);
            return RedirectToAction("Index");
        }

        [Route("AddTrips")]
        public IActionResult AddTrips(int id)
        {                       
            return RedirectToAction("AddTripsRecord", "TripsRecords", new { siteId =id});
        }
    }
}
