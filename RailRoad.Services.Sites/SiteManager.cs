using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using RailRoad.DataPersistenct.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RailRoad.Services.Sites
{
    public class SiteManager : ISiteManager
    {
        private ISiteRepository SiteRepository;
        private ILogger<SiteManager> Logger;

        public SiteManager(ILogger<SiteManager> logger, ISiteRepository siteRepository)
        {
            this.Logger = logger;
            this.SiteRepository = siteRepository;
        }

        public Site CreateSite(Site site)
        {
            try
            {
                return this.SiteRepository.CreateSite(site);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }

        public Site RetrieveSite(int id)
        {
            try
            {
                return this.SiteRepository.RetrieveSite(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }

        public Site RetrieveSite(int id, bool includeTripCharges)
        {
            try
            {
                return this.SiteRepository.RetrieveSiteWithCharges(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }

        public Site[] RetrieveSites(bool orderByName = false)
        {
            try
            {
                Site[] sites = this.SiteRepository.RetrieveSites();
                if (orderByName)
                {
                    sites = sites.OrderBy(s => s.Name).ToArray();
                }
                return sites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }

        public Site[] RetrieveSites(bool includeTripCharges, bool orderByName = false)
        {
            try
            {
                Site[] sites = this.SiteRepository.RetrieveSitesWithCharges();
                if (orderByName)
                {
                    sites = sites.OrderBy(s => s.Name).ToArray();
                }
                return sites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }

        public Site[] RetrieveSites(int[] ids, bool orderByName = false)
        {
            throw new NotImplementedException();           
        }

        
        public Site UpdateSite(Site site)
        {
            try
            {
                return this.SiteRepository.UpdateSite(site);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }

        public Site DeleteSite(int id)
        {
            try
            {
                return this.SiteRepository.DeleteSite(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.SiteRepository.Dispose();
            }
        }
    }
}
