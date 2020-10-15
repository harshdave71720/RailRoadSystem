using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using RailRoad.DataPersistence.Entities;
using RailRoad.Services.Sites;

namespace RailRoad.Web.Controllers
{
    [Route("Sites")]
    public class SitesController : Controller
    {
        private ISiteManager SiteManager = new SiteManager();

        //public SitesController(ISiteManager siteManager)
        //{
        //    this.SiteManager = siteManager;
        //}


        //public IActionResult Index()
        //{
        //    var sites = this.SiteManager.RetrieveSites();
        //    return View(sites);
        //}

        public IActionResult Index()
        {
            
            var sites = this.SiteManager.RetrieveSites(true, true);
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
    }
}
