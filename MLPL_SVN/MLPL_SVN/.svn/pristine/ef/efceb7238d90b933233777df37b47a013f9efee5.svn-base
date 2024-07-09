//  
// Type: CodeLock.Areas.Master.Repository.HsnRepository
//  
//  
//  

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
  public class HsnRepository : BaseRepository, IHsnRepository, IDisposable
  {
    public IEnumerable<MasterHsn> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterHsn>("Usp_HSN_GetAll", (object) null, "HSN Master - GetAll");
    }

    public MasterHsn GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HsnId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterHsn>("Usp_HSN_GetDetailById", (object) dynamicParameters, "HSN Master - GetDetailById").FirstOrDefault<MasterHsn>();
    }

    public Response Insert(MasterHsn objHsn)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterHsn", (object) XmlUtility.XmlSerializeToString((object) objHsn), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_HSN_Insert", (object) dynamicParameters, "HSN Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterHsn objHsn)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterHsn", (object) XmlUtility.XmlSerializeToString((object) objHsn), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_HSN_Update", (object) dynamicParameters, "HSN Master - Update").FirstOrDefault<Response>();
    }

    public bool IsHsnNameAvailable(string HsnName, byte HsnId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HsnName", (object) HsnName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@HsnId", (object) HsnId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_HSN_IsHsnNameAvailable", (object) dynamicParameters, "HSN Master - IsHsnNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsHsnCodeAvailable(string HsnCode, byte HsnId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HsnCode", (object) HsnCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@HsnId", (object) HsnId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_HSN_IsHsnCodeAvailable", (object) dynamicParameters, "HSN Master - IsHsnCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetHsnList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_HSN_GetList", (object) null, "HSN Master - GetHsnList");
    }
  }
}
