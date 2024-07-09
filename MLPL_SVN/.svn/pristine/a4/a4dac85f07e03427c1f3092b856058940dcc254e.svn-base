//  
// Type: CodeLock.Areas.Master.Repository.IJobOrderWorkGroupRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IJobOrderWorkGroupRepository : IDisposable
  {
    IEnumerable<MasterJobOrderWorkGroup> GetAll();

    MasterJobOrderWorkGroup GetDetailById(byte id);

    Response Insert(MasterJobOrderWorkGroup objWorkGroup);

    Response Update(MasterJobOrderWorkGroup objWorkGroup);

    bool IsWorkGroupAvailable(string workGroup, byte workGroupId);

    IEnumerable<AutoCompleteResult> GetWorkGroupList();
  }
}
