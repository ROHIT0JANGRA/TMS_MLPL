//  
// Type: CodeLock.Areas.Master.Repository.IRoleRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IRoleRepository : IDisposable
  {
    IEnumerable<MasterRole> GetAll();

    MasterRole GetById(byte id);

    byte Insert(MasterRole objMasterRole);

    byte Update(MasterRole objMasterRole);

    IEnumerable<AutoCompleteResult> GetRoleList();

    bool IsRoleNameAvailable(string roleName, short roleId);
  }
}
