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
    public class TyreModelRepository : BaseRepository, ITyreModelRepository, IDisposable
    {
        public IEnumerable<MasterTyreModel> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterTyreModel>("Usp_MasterTyreModel_GetAll", (object)null, "TyreModel Master - GetAll");
        }
        public MasterTyreModel GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TyreModelId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterTyreModel>("Usp_MasterTyreModel_GetById", (object)dynamicParameters, "TyreModel Master - GetById").FirstOrDefault<MasterTyreModel>();
        }
        public short Insert(MasterTyreModel objMasterTyreModel)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyreModel", (object)XmlUtility.XmlSerializeToString((object)objMasterTyreModel), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyreModelId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyreModel_Insert", (object)dynamicParameters, "TyreModel Master - Insert");
            return dynamicParameters.Get<short>("@TyreModelId");
        }
        public short Update(MasterTyreModel objMasterTyreModel)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyreModel", (object)XmlUtility.XmlSerializeToString((object)objMasterTyreModel), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyreModelId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyreModel_Update", (object)dynamicParameters, "TyreModel Master - Update");
            return dynamicParameters.Get<short>("@TyreModelId");
        }
    }
}
