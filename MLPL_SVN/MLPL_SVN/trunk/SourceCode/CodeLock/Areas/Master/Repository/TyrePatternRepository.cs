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
    public class TyrePatternRepository : BaseRepository, ITyrePatternRepository, IDisposable
    {
        public IEnumerable<MasterTyrePattern> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterTyrePattern>("Usp_MasterTyrePattern_GetAll", (object)null, "Master TyrePattern - GetAll");
        }
        public MasterTyrePattern GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TyrePatternId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterTyrePattern>("Usp_MasterTyrePattern_GetById", (object)dynamicParameters, "Master TyrePattern - GetById").FirstOrDefault<MasterTyrePattern>();
           
        }
        public short Insert(MasterTyrePattern objMasterTyrePattern)
        {
            var pram = new DynamicParameters();
            pram.Add("@XmlTyrePattern", XmlUtility.XmlSerializeToString(objMasterTyrePattern), DbType.Xml);
            pram.Add("@TyrePatternId", null, DbType.Int16, direction: ParameterDirection.Output);

            DataBaseFactory.QuerySP("Usp_MasterTyrePattern_Insert", pram, module: "Master TyrePattern - Insert");
            return pram.Get<short>("@TyrePatternId");
        }
        public short Update(MasterTyrePattern objMasterTyrePattern)
        {
            var pram = new DynamicParameters();
            pram.Add("@XmlTyrePattern", XmlUtility.XmlSerializeToString(objMasterTyrePattern), DbType.Xml);
            pram.Add("@TyrePatternId", null, DbType.Int16, direction: ParameterDirection.Output);

            DataBaseFactory.QuerySP("Usp_MasterTyrePattern_Update", pram, module: "Master TyrePattern - Update");
            return pram.Get<short>("@TyrePatternId");
        }

        public bool IsTyrePatternAvailable(string TyrePatternCode, byte TyrePatternId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TyrePatternId", (object)TyrePatternId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TyrePatternCode", (object)TyrePatternCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyrePattern_IsNameAvailable", (object)dynamicParameters, "Master TyrePattern - IsTyrePatternAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }
    }
}
