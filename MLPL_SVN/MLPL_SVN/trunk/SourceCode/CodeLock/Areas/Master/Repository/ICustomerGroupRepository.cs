//  
// Type: CodeLock.Areas.Master.Repository.ICustomerGroupRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ICustomerGroupRepository : IDisposable
  {
    IEnumerable<MasterCustomerGroup> GetAll();

    MasterCustomerGroup GetById(string id);

    string Insert(MasterCustomerGroup objMasterCustomerGroup);

    string Update(MasterCustomerGroup objMasterCustomerGroup);

    bool IsGroupNameAvailable(string groupName, string groupCode);

    IEnumerable<AutoCompleteResult> GetCustomerGroupList();
  }
}
