//  
// Type: CodeLock.Areas.Master.Repository.FieldsRepository
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

namespace CodeLock.Areas.Master.Repository
{
  public class FieldsRepository : BaseRepository, IFieldsRepository, IDisposable
  {
    public IEnumerable<MasterFields> GetAll(byte? moduleId, string fieldName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ModuleId", (object) moduleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FieldName", (object) fieldName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterFields>("Usp_MasterFields_GetAll", (object) dynamicParameters, "Fields Master - Get All");
    }
  }
}
