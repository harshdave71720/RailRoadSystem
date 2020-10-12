using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailRoad.Services.Sites;

namespace RailRoad.Web.Controllers
{
    public class SitesController : Controller
    {
        private ISiteManager SiteManager = new SiteManager();

        //public SitesController(ISiteManager siteManager)
        //{
        //    this.SiteManager = siteManager;
        //}

       
        public IActionResult Index()
        {
            var sites = this.SiteManager.RetrieveSites();
            return View(sites);
        }
    }
}
