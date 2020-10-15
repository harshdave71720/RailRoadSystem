using Microsoft.AspNetCore.Mvc;
using RailRoad.Services.Sites;

namespace RailRoad.REST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private ISiteManager SiteManager;

        public SitesController(ISiteManager siteManager)
        {
            this.SiteManager = siteManager;
        }          
    }
}
