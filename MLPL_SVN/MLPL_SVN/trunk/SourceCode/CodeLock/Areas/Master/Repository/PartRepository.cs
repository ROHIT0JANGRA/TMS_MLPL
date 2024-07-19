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
    public class PartRepository : BaseRepository, IPartRepository, IDisposable
    {
        public IEnumerable<MasterPart> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterPart>("Usp_MasterPart_GetAll", (object)null, (string)null);
        }
       public long Insert(MasterPart objMasterPart)
       {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlPart", (object)XmlUtility.XmlSerializeToString((object)objMasterPart), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterPart_Insert", (object)dynamicParameters, "Part Master - Insert");
            return dynamicParameters.Get<long>("@PartId"); 
       }
        public bool IsPartNameAvailable(string partName, long partId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PartId", (object)partId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartName", (object)partName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterPart_IsNameAvailable_V1", (object)dynamicParameters, "Part Master - IsPartNameAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }
        public bool IsPartNoAvailable(string partNo, long partId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PartId", (object)partId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartNo", (object)partNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterPart_IsNoAvailable_V1", (object)dynamicParameters, "Part Master - IsPartNoAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public long Update(MasterPart objMasterPart)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlPart", (object)XmlUtility.XmlSerializeToString((object)objMasterPart), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartId", (object)objMasterPart.PartId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterPart_Update", (object)dynamicParameters, "Part Master - Update");
            return objMasterPart.PartId;
        }

        public MasterPart GetById(long id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PartId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var result = DataBaseFactory.QueryMultipleSP<MasterPart, MasterPartDetail>("Usp_MasterPart_GetById", (object)dynamicParameters, "Part Master - GetById");

            MasterPart masterPart= new MasterPart();
            if (result == null)
                return masterPart;
            masterPart = result.Item1.FirstOrDefault<MasterPart>();
            if (result.Item2 != null)
                masterPart.PartDetails.AddRange(result.Item2);
            return masterPart;
        }

        public IEnumerable<AutoCompleteResult> GetPartListByConsignorIdAndConsigneeId(short consignorId,short consigneeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ConsignorId", (object) consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object) consigneeId, new DbType? (DbType.Int16), new ParameterDirection? (), new int? (), new byte? (), new byte? ());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterPart_GetPartListByConsignorIdAndConsigneeId", (object)dynamicParameters, "Part Master - Usp_MasterPart_GetPartListByConsignorIdAndConsigneeId");
        }

        public IEnumerable<AutoCompleteResult> GetPartListByCustomerId(short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterPart_GetPartListByCustomerId", (object)dynamicParameters, "Part Master - GetPartListByCustomerId");
        }

        public IEnumerable<AutoCompleteResult> GetPackingTypeListByPartId(short partId, short consignorId, short consigneeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PartId", (object)partId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterPart_GetPackingTypeListByPartId", (object)dynamicParameters, "Part Master - GetPackingTypeListByPartId");
        }

        public MasterPartDetail GetPartDetailByPartIdAndPackingTypeId(long partId, short packingTypeId, short consignorId, short consigneeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PartId", (object)partId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PackingTypeId", (object)packingTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterPartDetail>("Usp_MasterPart_GetPartDetailByPartIdAndPackingTypeId", (object)dynamicParameters, "Part Master - GetPartDetailByPartIdAndPackingTypeId").FirstOrDefault();
        }




        public IEnumerable<MasterPart> GetPartByPagination(int pageNo, int pageSize, string sorting, string search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterPart>("Usp_PartMaster_GetPartsByPagination", (object)dynamicParameters, "Part Master - GetPartByPagination");

        }


    }
}