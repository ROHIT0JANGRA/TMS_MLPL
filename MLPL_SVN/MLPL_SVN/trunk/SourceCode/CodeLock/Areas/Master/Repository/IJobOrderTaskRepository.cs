//  
// Type: CodeLock.Areas.Master.Repository.IJobOrderTaskRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IJobOrderTaskRepository : IDisposable
  {
    IEnumerable<MasterJobOrderTask> GetAll();

    MasterJobOrderTask GetDetailById(byte id);

    Response Insert(MasterJobOrderTask objTask);

    Response Update(MasterJobOrderTask objTask);

    bool IsTaskAvailable(byte workGroupId, byte taskTypeId, string task, short taskId);

    IEnumerable<AutoCompleteResult> GetTaskList();

    IEnumerable<AutoCompleteResult> GetTaskDescriptionListByWorkGroupIdAndTaskTypeId(
      byte workGroupId,
      byte taskTypeId);

    byte GetEstimatedLabourHoursByTaskId(short taskId);
  }
}
