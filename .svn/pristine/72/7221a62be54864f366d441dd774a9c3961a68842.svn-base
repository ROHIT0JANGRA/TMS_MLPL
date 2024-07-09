//  
// Type: CodeLock.Areas.Master.Repository.IUserWarehouseRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IUserWarehouseRepository : IDisposable
  {
    IEnumerable<MasterUserWarehouseMapping> GetMapping();

    IEnumerable<MasterUserWarehouseMapping> GetMappingByUserId(
      short userId);

    Response Mapping(
      MasterUserWarehouseMapping objMasterUserWarehouseMapping);
  }
}
