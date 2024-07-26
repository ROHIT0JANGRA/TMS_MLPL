//  
// Type: CodeLock.Areas.Master.Repository.UserWarehouseRepository
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
  public class UserWarehouseRepository : BaseRepository, IUserWarehouseRepository, IDisposable
  {
    public IEnumerable<MasterUserWarehouseMapping> GetMapping()
    {
      return DataBaseFactory.QuerySP<MasterUserWarehouseMapping>("Usp_MasterUserWarehouseMapping", (object) null, "MasterUserWarehouseMapping");
    }

    public IEnumerable<MasterUserWarehouseMapping> GetMappingByUserId(
      short userId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@UserId", (object) userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
    return DataBaseFactory.QuerySP<MasterUserWarehouseMapping>("Usp_MasterUserWarehouseMapping_GetById", (object) dynamicParameters, "MasterUserWarehouseMapping - GetById");
    
    }

    public Response Mapping(
      MasterUserWarehouseMapping objMasterUserWarehouseMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlUserWarehouseMapping", (object) XmlUtility.XmlSerializeToString((object) objMasterUserWarehouseMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterUserWarehouseMapping_Update", (object) dynamicParameters, "UserWarehouseMapping").FirstOrDefault<Response>();
    }
  }
}
