//  
// Type: CodeLock.Areas.Master.Repository.IVehicleTypeRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IVehicleTypeRepository : IDisposable
  {
    IEnumerable<MasterVehicleType> GetAll();

    MasterVehicleType GetById(byte id);

    byte Insert(MasterVehicleType objMasterVehicleType);

    byte Update(MasterVehicleType objMasterVehicleType);

    bool IsVehicleTypeNameAvailable(short vehicleTypeId, string vehicleTypeName);

    IEnumerable<AutoCompleteResult> GetVehicleTypeList();
  }
}
