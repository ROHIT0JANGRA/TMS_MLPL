//  
// Type: CodeLock.Areas.Master.Repository.JobOrderTaskRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
  public class JobOrderTaskRepository : BaseRepository, IJobOrderTaskRepository, IDisposable
  {
    public IEnumerable<MasterJobOrderTask> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterJobOrderTask>("Usp_MasterJobOrderTask_GetAll", (object) null, "Job Order Task  Master- GetAll");
    }

    public MasterJobOrderTask GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@TaskId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterJobOrderTask>("Usp_MasterJobOrderTask_GetDetailById", (object) dynamicParameters, "Job Order Task  Master - GetDetailById").FirstOrDefault<MasterJobOrderTask>();
    }

    public Response Insert(MasterJobOrderTask objTask)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTask", (object) XmlUtility.XmlSerializeToString((object) objTask), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterJobOrderTask_Insert", (object) dynamicParameters, "Job Order Task  Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterJobOrderTask objWorkGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTask", (object) XmlUtility.XmlSerializeToString((object) objWorkGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterJobOrderTask_Update", (object) dynamicParameters, "Job Order Task  Master - Update").FirstOrDefault<Response>();
    }

    public bool IsTaskAvailable(byte workGroupId, byte taskTypeId, string task, short taskId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@WorkGroupId", (object) workGroupId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TaskTypeId", (object) taskTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TaskId", (object) taskId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Task", (object) task, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterJobOrderTask_IsTaskAvailable", (object) dynamicParameters, "Job Order Task  Master - IsTaskAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetTaskList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterJobOrderTask_GetTaskList", (object) null, "Job Order Task  Master - GetTaskList");
    }

    public IEnumerable<AutoCompleteResult> GetTaskDescriptionListByWorkGroupIdAndTaskTypeId(
      byte workGroupId,
      byte taskTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@WorkGroupId", (object) workGroupId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TaskTypeId", (object) taskTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterJobOrderTask_GetTaskDescriptionListByWorkGroupIdAndTaskTypeId", (object) dynamicParameters, "Job Order Task  Master - GetTaskDescriptionListByWorkGroupIdAndTaskTypeId");
    }

    public byte GetEstimatedLabourHoursByTaskId(short taskId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@TaskId", (object) taskId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@EstimatedLabourHours", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterJobOrderTask_GetEstimatedLabourHoursByTaskId", (object) dynamicParameters, "Job Order Task  Master - GetEstimatedLabourHoursByTaskId");
      return dynamicParameters.Get<byte>("@EstimatedLabourHours");
    }
  }
}
