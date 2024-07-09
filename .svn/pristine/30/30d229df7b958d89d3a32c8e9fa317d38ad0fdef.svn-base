//  
// Type: CodeLock.Areas.Master.Repository.IJobOrderTaskTypeRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IJobOrderTaskTypeRepository : IDisposable
  {
    IEnumerable<MasterJobOrderTaskType> GetAll();

    MasterJobOrderTaskType GetDetailById(byte id);

    Response Insert(MasterJobOrderTaskType objTaskType);

    Response Update(MasterJobOrderTaskType objTaskType);

    bool IsTaskTypeAvailable(string taskType, byte taskTypeId);

    IEnumerable<AutoCompleteResult> GetTaskTypeList();
  }
}
