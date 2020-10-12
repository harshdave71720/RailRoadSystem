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

        public SiteManager(ISiteRepository siteRepository)
        {
            this.SiteRepository = siteRepository;
        }

        public SiteManager()
        {
            this.SiteRepository = new SiteTripRepository();
        }

        public Site CreateSite(Site site)
        {            
            try
            {
                return this.SiteRepository.SaveSite(site);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                this.SiteRepository.Dispose();
            }
        }

        public Site RetrieveSite(int id)
        {            
            try
            {
                return this.SiteRepository.GetSite(id, true);        
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SiteRepository.Dispose();
            }
        }

        public Site[] RetrieveSites(bool orderByName = false)
        {
            try
            {
                Site[] sites =orderByName ? this.SiteRepository.GetSites().OrderBy(x => x.Name).ToArray(): this.SiteRepository.GetSites();
                return sites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SiteRepository.Dispose();
            }
        }

        public Site[] RetrieveSites(int[] ids, bool orderByName = false)
        {
            try
            {
                Site[] sites = orderByName ? this.SiteRepository.GetSites().OrderBy(x => x.Name).ToArray() : this.SiteRepository.GetSites();
                return sites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SiteRepository.Dispose();
            }
        }

        public Site RetrieveSiteWithTripsRecords(int id)
        {
            try
            {
                return this.SiteRepository.GetSite(id, true, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SiteRepository.Dispose();
            }
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
                this.SiteRepository.Dispose();
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
                this.SiteRepository.Dispose();
            }
        }
    }
}
