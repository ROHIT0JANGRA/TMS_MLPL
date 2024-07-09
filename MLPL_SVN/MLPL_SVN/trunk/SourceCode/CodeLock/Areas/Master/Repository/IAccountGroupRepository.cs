//  
// Type: CodeLock.Areas.Master.Repository.IAccountGroupRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAccountGroupRepository : IDisposable
  {
    IEnumerable<MasterAccountGroup> GetAll();

    MasterAccountGroup GetById(short id);

    short Insert(MasterAccountGroup objMasterAccountGroup);

    short Update(MasterAccountGroup objMasterAccountGroup);

    bool IsGroupCodeAvailable(string groupCode, short accountGroupId);

    bool IsGroupNameAvailable(string groupName, short accountGroupId);

    IEnumerable<AutoCompleteResult> GetAccountGroupListByCategoryId(
      short accountCategoryId);

    IEnumerable<AutoCompleteResult> GetListByCategoryId(
      byte accountCategoryId);

    IEnumerable<AutoCompleteResult> GetAccountGroupList();

    IEnumerable<AutoCompleteResult> GetAccountGroupListByMainCategoryId(
      short maincategoryId);
  }
}
