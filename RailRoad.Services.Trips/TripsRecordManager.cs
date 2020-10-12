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

        public TripsRecordManager(ITripsRecordRepository tripsRecordRepository)
        {
            this.TripsRecordRepository = tripsRecordRepository;
        }

        public TripsRecordManager()
        {
            this.TripsRecordRepository = new SiteTripRepository();
        }

        public TripsRecord CreateTripsRecord(TripsRecord tripsRecord)
        {
            try
            {
                return this.TripsRecordRepository.SaveTripsRecord(tripsRecord);
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
                return this.RetrieveTripsRecord(id);
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
        
        public TripsRecord RetrieveTripsRecordWithSite(int id)
        {
            try
            {
                return this.RetrieveTripsRecordWithSite(id);
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

        public TripsRecord[] RetrieveTripsRecords(bool orderByDate = false)
        {
            try
            {
                TripsRecord[] records = orderByDate ? 
                                        this.TripsRecordRepository.GetTripsRecords().OrderBy(x => x.Date).ToArray() :
                                        this.TripsRecordRepository.GetTripsRecords();
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

        public TripsRecord[] RetrieveTripsRecords(int[] id, bool orderByDate = false)
        {
            try
            {
                TripsRecord[] records = orderByDate ?
                                        this.TripsRecordRepository.GetTripsRecords().OrderBy(x => x.Date).ToArray() :
                                        this.TripsRecordRepository.GetTripsRecords();
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

        public TripsRecord[] RetrieveTripsRecordsWithSite(int[] id, bool orderByDate = false)
        {
            try
            {
                TripsRecord[] records = orderByDate ?
                                       this.TripsRecordRepository.GetTripsRecords(false, true).OrderBy(x => x.Date).ToArray() :
                                       this.TripsRecordRepository.GetTripsRecords(false, true);
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
                return this.UpdateTripsRecord(tripsRecord);
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
                return this.DeleteTripsRecord(id);
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
