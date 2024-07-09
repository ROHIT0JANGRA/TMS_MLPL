//  
// Type: CodeLock.Areas.Master.Repository.IMenuRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IMenuRepository : IDisposable
  {
    IEnumerable<MasterMenu> GetMenuListByUserId(
      short loginUserId,
      byte companyId);

    Response Update(MasterMenuAccess objMasterMenuAccess);

    IEnumerable<MasterMenu> GetMenuAccessListByRoleId(
      byte roleId,
      byte companyId);

    IEnumerable<AutoCompleteResult> GetMainMenuList();

    IEnumerable<AutoCompleteResult> GetMenuListByParentMenuId(
      short parentMenuId);
  }
}
