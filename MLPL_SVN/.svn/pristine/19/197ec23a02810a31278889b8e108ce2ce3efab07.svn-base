//  
// Type: CodeLock.Areas.Master.Repository.ISupervisorRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ISupervisorRepository : IDisposable
  {
    IEnumerable<MasterSupervisor> GetAll();

    MasterSupervisor GetById(byte id);

    byte Insert(MasterSupervisor objMasterSupervisor);

    byte Update(MasterSupervisor objMasterSupervisor);

    bool IsSupervisorNameAvailable(string SupervisorName, short SupervisorId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string supervisorName,
      short warehouseId);

    AutoCompleteResult IsSupervisorNameExist(
      string supervisorName,
      short warehouseId);
  }
}
