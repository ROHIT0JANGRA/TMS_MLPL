using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
    public class TyreSizeRepository : BaseRepository,ITyreSizeRepository
    {
        public IEnumerable<MasterTyreSize> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterTyreSize>("Usp_MasterTyreSize_GetAll", module: "TyreSize Master - GetAll");
        }

        public short Insert(MasterTyreSize objMasterTyreSize)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyreSize", (object)XmlUtility.XmlSerializeToString((object)objMasterTyreSize), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyreSizeId", null, DbType.Int16, ParameterDirection.Output, null, null, null);

            DataBaseFactory.QuerySP("Usp_MasterTyreSize_Insert", dynamicParameters, "TyreSize Master - Insert");

            return dynamicParameters.Get<short>("@TyreSizeId");
        }
        public short Update(MasterTyreSize objMasterTyreSize)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyreSize", (object)XmlUtility.XmlSerializeToString((object)objMasterTyreSize), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyreSizeId", null, DbType.Int16, ParameterDirection.Output, null, null, null);

            DataBaseFactory.QuerySP("Usp_MasterTyreSize_Update", dynamicParameters, "TyreSize Master - Update");

            return dynamicParameters.Get<short>("@TyreSizeId");
        }


        public MasterTyreSize GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TyreSizeId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterTyreSize>("Usp_MasterTyreSize_GetById", (object)dynamicParameters, "TyreSize Master - GetById").FirstOrDefault<MasterTyreSize>();
        }
        public bool IsTyreSizeNameAvailable(string tyreSizeName,short tyreSizeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TyreSizeId", (object)tyreSizeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyreSizeName", (object)tyreSizeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyreSize_IsTyreSizeNameAvailable", (object)dynamicParameters, "TyreSize Master - IsTyreSizeNameAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        

        /* public short Update(MasterTyreSize objMasterTyreSize)
         {
             DynamicParameters dynamicParameters = new DynamicParameters();
             dynamicParameters.Add("@XmlTyreSize", objMasterTyreSize == null ? null : XmlUtility.XmlSerializeToString(objMasterTyreSize), DbType.Xml);

             DataBaseFactory.QuerySP("Usp_MasterTyreSize_Update", dynamicParameters, "TyreSize Master - Update");

             return objMasterTyreSize.TyreSizeId;
         }*/


    }
}