//  
// Type: CodeLock.Areas.Master.Repository.IVehicleCapacityRateRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IVehicleCapacityRateRepository : IDisposable
  {
    MasterVehicleCapacityRate GetById(short id);

    IEnumerable<MasterVehicleCapacityRate> GetAll();

    void InsertUpdate(
      MasterVehicleCapacityRate objMasterVehicleCapacityRate);

    bool IsVendorAvailable(string vendorCode, short vendorId);
  }
}
