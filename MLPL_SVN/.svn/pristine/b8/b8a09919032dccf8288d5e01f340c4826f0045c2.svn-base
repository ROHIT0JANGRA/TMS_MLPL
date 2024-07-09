//  
// Type: CodeLock.Areas.Master.Repository.IPackagingMeasurementRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IPackagingMeasurementRepository : IDisposable
  {
    IEnumerable<MasterPackagingMeasurement> GetAll();

    MasterPackagingMeasurement GetById(short id);

    Response Insert(
      MasterPackagingMeasurement objMasterPackagingMeasurement);

    Response Update(
      MasterPackagingMeasurement objMasterPackagingMeasurement);

    bool IsPackagingTypeAvailable(string packagingType, short packagingTypeId);
  }
}
