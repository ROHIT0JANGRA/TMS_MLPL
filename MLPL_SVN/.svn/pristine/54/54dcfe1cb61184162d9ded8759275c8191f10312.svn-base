//  
// Type: CodeLock.Areas.Master.Repository.ICountryRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ICountryRepository : IDisposable
  {
    MasterCountry GetById(byte id);

    IEnumerable<MasterCountry> GetAll();

    byte Insert(MasterCountry objMasterCountry);

    byte Update(MasterCountry objMasterCountry);

    bool IsCountryNameAvailable(string countryName, byte countryId);

    IEnumerable<AutoCompleteResult> GetCountryList();
  }
}
