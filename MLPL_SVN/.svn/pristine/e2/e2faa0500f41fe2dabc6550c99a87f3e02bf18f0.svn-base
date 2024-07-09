using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CodeLock.Areas.Master.Repository
{
    public class FSCRateRepository :  BaseRepository, IFSCRateRepository, IDisposable
    {
        public IEnumerable<FSCRateDetail> GetLaneList(short companyId, short? customerId, long? laneId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LaneId", (long)laneId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var lst = DataBaseFactory.QuerySP<FSCRateDetail>("Usp_FSCRate_GetLaneDetails", (object)dynamicParameters, "FSC Rate Master - GetLaneList");
            return lst;
        }
        public IEnumerable<FSCRateDetail> GetFSCRateList(short companyId, short? customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var lst = DataBaseFactory.QuerySP<FSCRateDetail>("Usp_FSCRate_GetList", (object)dynamicParameters, "FSC Rate Master - GetFSCRateList");
            return lst;
        }

        public void Insert(FSCRate oData)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlData", (object)XmlUtility.XmlSerializeToString((object)oData), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)oData.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)oData.CustomerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)oData.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("[dbo].[Usp_FSCRateMaster_Insert]", (object)dynamicParameters, "FSCRateRepository - Insert");
        }
    }
}