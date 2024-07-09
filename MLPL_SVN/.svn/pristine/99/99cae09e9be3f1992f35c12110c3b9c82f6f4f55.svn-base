//  
// Type: CodeLock.Areas.Master.Repository.FieldsUtility
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace CodeLock.Areas.Master.Repository
{
  public static class FieldsUtility
  {
    public static IEnumerable<MasterFields> GetAll(
      byte? moduleId,
      string fieldName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ModuleId", (object) moduleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FieldName", (object) fieldName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterFields>("Usp_MasterFields_GetAll", (object) dynamicParameters, "Fields Master - Get All");
    }
  }
}
