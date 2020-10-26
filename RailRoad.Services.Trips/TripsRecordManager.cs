using Microsoft.Extensions.Logging;
using RailRoad.DataPersistence.Entities;
using RailRoad.DataPersistence.Repositories;
using RailRoad.DataPersistenct.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RailRoad.Services.Trips
{
    public class TripsRecordManager : ITripsRecordManager
    {
        private ITripsRecordRepository TripsRecordRepository;
        private ILogger<TripsRecordManager> Logger;

        public TripsRecordManager(ILogger<TripsRecordManager> logger, ITripsRecordRepository tripsRecordRepository)
        {
            this.Logger = logger;
            this.TripsRecordRepository = tripsRecordRepository;
        }

        public TripsRecord CreateTripsRecord(TripsRecord tripsRecord)
        {
            try
            {
                return this.TripsRecordRepository.CreateTripsRecord(tripsRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }

        public TripsRecord RetrieveTripsRecord(int id)
        {
            try
            {
                return this.TripsRecordRepository.RetrieveTripsRecord(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }

        //public TripsRecord RetrieveTripsRecordWithSite(int id)
        //{
        //    try
        //    {
        //        return this.TripsRecordRepository.RetrieveTripsRecordWithSite(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        this.TripsRecordRepository.Dispose();
        //    }
        //}

        public TripsRecord[] RetrieveTripsRecords(bool orderByDate = false)
        {
            try
            {
                TripsRecord[] records = this.TripsRecordRepository.RetrieveTripsRecords();
                if (orderByDate)
                {
                    records = records.OrderBy(r => r.Date).ToArray();
                }
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }

        public TripsRecord[] RetrieveTripsRecords(bool orderByDate = false, bool includeSiteInfo = false)
        {
            try
            {
                TripsRecord[] records = this.TripsRecordRepository.RetrieveTripsRecordsWithSiteInfo();
                if (orderByDate)
                {
                    records = records.OrderByDescending(r => r.Date).ToArray();
                }
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }

        //public TripsRecord[] RetrieveTripsRecords(int[] id, bool orderByDate = false)
        //{
        //    try
        //    {
        //        TripsRecord[] records = orderByDate ?
        //                                this.TripsRecordRepository.RetrieveTripsRecords().OrderBy(x => x.Date).ToArray() :
        //                                this.TripsRecordRepository.RetrieveTripsRecords();
        //        return records;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        this.TripsRecordRepository.Dispose();
        //    }
        //}

        public TripsRecord[] RetrieveTripsRecordsWithSite(int[] id, bool orderByDate = false)
        {
            try
            {
                TripsRecord[] records = orderByDate ?
                                       this.TripsRecordRepository.RetrieveTripsRecords().OrderByDescending(x => x.Date).ToArray() :
                                       this.TripsRecordRepository.RetrieveTripsRecords();
                return records;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }

        public TripsRecord UpdateTripsRecord(TripsRecord tripsRecord)
        {
            try
            {
                return this.TripsRecordRepository.UpdateTripsRecord(tripsRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }

        public TripsRecord DeleteTripsRecord(int id)
        {
            try
            {
                return this.TripsRecordRepository.DeleteTripsRecord(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.TripsRecordRepository.Dispose();
            }
        }
    }
}
