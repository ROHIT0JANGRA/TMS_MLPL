//  
// Type: CodeLock.Areas.Master.Repository.IZoneRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IZoneRepository : IDisposable
  {
    IEnumerable<MasterZone> GetAll();

    MasterZone GetById(byte id);

    bool IsZoneNameAvailable(string zoneName, byte zoneId);

    byte Insert(MasterZone objMasterZone);

    IEnumerable<AutoCompleteResult> GetZoneList();

    byte Update(MasterZone objMasterZone);

    AutoCompleteResult IsZoneNameExist(string zoneName);

    IEnumerable<AutoCompleteResult> GetAutoCompleteZoneList(
      string zoneName);
  }
}
