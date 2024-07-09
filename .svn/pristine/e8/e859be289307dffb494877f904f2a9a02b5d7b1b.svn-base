//  
// Type: CodeLock.Areas.Master.Repository.DocumentControlRepository
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
  public class DocumentControlRepository : BaseRepository, IDocumentControlRepository, IDisposable
  {
    public IEnumerable<MasterDocumentControl> GetDcrDocumentList(
      byte CompanyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterDocumentControl>("Usp_MasterDocument_GetDcrDocumentList", (object) dynamicParameters, "DocumentControl Master - GetDcrDocumentList");
    }
  }
}
