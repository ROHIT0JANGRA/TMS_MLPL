//  
// Type: CodeLock.Areas.Master.Repository.IFuelBrandRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IFuelBrandRepository : IDisposable
  {
    IEnumerable<MasterFuelBrand> GetAll();

    MasterFuelBrand GetDetailById(byte id);

    byte Insert(MasterFuelBrand objMasterFuelBrand);

    byte Update(MasterFuelBrand objMasterFuelBrand);

    IEnumerable<AutoCompleteResult> GetListByFuelTypeId(byte fuelTypeId);

    bool IsFuelBrandNameAvailable(string fuelBrandName, byte fuelBrandId);

    AutoCompleteResult CheckValidFuelBrandName(string fuelBrandName);

    IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string fuelBrandName);
  }
}
