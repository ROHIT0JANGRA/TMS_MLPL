//  
// Type: CodeLock.Areas.Master.Repository.IRoleBasedAccessRightRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IRoleBasedAccessRightRepository : IDisposable
  {
    Response Update(
      MasterRoleBasedAccessRight objMasterRoleBasedAccessRight);

    IEnumerable<MasterMenu> GetMenuAccessListByRoleIdAndUserId(
      byte roleId,
      short userId,
      byte companyId);
  }
}
