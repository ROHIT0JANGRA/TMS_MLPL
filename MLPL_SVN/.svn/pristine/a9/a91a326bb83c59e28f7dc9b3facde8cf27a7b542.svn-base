//  
// Type: CodeLock.Areas.Master.Repository.IAccountCategoryRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAccountCategoryRepository : IDisposable
  {
    IEnumerable<MasterAccountCategory> GetAll();

    MasterAccountCategory GetById(byte id);

    byte Insert(MasterAccountCategory objMasterAccountCategory);

    byte Update(MasterAccountCategory objMasterAccountCategory);

    bool IsAccountCategoryNameAvailable(string accountCategoryCode, short accountCategoryId);

    IEnumerable<AutoCompleteResult> GetMainAccountCategoryList();

    IEnumerable<AutoCompleteResult> GetAccountCategoryList();
  }
}
