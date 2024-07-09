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
    public class TyrePositionRepository : BaseRepository, ITyrePositionRepository, IDisposable
    {
        public IEnumerable<MasterTyrePosition> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterTyrePosition>("Usp_MasterTyrePosition_GetAll", (object)null, "TyrePosition Master - GetAll");
        }
        public MasterTyrePosition GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TyrePositionid", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterTyrePosition>("Usp_MasterTyrePosition_GetById", (object)dynamicParameters, "TyrePosition Master - GetById").FirstOrDefault<MasterTyrePosition>();
        }
        public short Insert(MasterTyrePosition objMasterTyrePosition)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyrePosition", (object)XmlUtility.XmlSerializeToString((object)objMasterTyrePosition), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyrePositionid", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyrePosition_Insert", (object)dynamicParameters, "TyrePosition Master - Insert");
            return dynamicParameters.Get<short>("@TyrePositionid");
        }
        public short Update(MasterTyrePosition objMasterTyrePosition)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyrePosition", (object)XmlUtility.XmlSerializeToString((object)objMasterTyrePosition), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyrePositionid", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyrePosition_Update", (object)dynamicParameters, "TyrePosition Master - Update");
            return dynamicParameters.Get<short>("@TyrePositionid");
        }
    }
}
