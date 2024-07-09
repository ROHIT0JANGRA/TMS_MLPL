using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using System.Data;

namespace CodeLock.Areas.Master.Repository
{
    public class LaneRepository : BaseRepository, ILaneRepository, IDisposable
    {
        public LaneRepository()
        {
        }

        public IEnumerable<AutoCompleteResult> GetLaneCustomer(long CompanyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("[dbo].[Usp_MasterCustomer_GetLaneCustomer]", (object)dynamicParameters, "LaneRepository - GetLaneCustomer");
        }
        public List<LaneDetail> GetAll(long CompanyId, long CustomerId, bool? IsActive = null)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            if (IsActive != null)
                dynamicParameters.Add("@IsActive", (object)IsActive, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<LaneDetail>("[dbo].[Usp_LaneMaster_GetList]", (object)dynamicParameters, "LaneRepository - GetAll").ToList();
        }
        public void Insert(long CompanyId, long CustomerId, Lane oLane)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@XmlLane", (object)XmlUtility.XmlSerializeToString((object)oLane), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("[dbo].[Usp_LaneMaster_Insert]", (object)dynamicParameters, "LaneRepository - Insert");
        }
    }
}