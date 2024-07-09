//  
// Type: CodeLock.Areas.Master.Repository.JobOrderTaskTypeRepository
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
  public class JobOrderTaskTypeRepository : BaseRepository, IJobOrderTaskTypeRepository, IDisposable
  {
    public IEnumerable<MasterJobOrderTaskType> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterJobOrderTaskType>("Usp_MasterJobOrderTaskType_GetAll", (object) null, "Job Order Task Type Master- GetAll");
    }

    public MasterJobOrderTaskType GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@TaskTypeId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterJobOrderTaskType>("Usp_MasterJobOrderTaskType_GetDetailById", (object) dynamicParameters, "Job Order Task Type Master - GetDetailById").FirstOrDefault<MasterJobOrderTaskType>();
    }

    public Response Insert(MasterJobOrderTaskType objTaskType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTaskType", (object) XmlUtility.XmlSerializeToString((object) objTaskType), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterJobOrderTaskType_Insert", (object) dynamicParameters, "Job Order Task Type Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterJobOrderTaskType objWorkGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTaskType", (object) XmlUtility.XmlSerializeToString((object) objWorkGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterJobOrderTaskType_Update", (object) dynamicParameters, "Job Order Task Type Master - Update").FirstOrDefault<Response>();
    }

    public bool IsTaskTypeAvailable(string taskType, byte taskTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@TaskTypeId", (object) taskTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TaskType", (object) taskType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterJobOrderTaskType_IsTaskTypeAvailable", (object) dynamicParameters, "Job Order Task Type Master - IsTaskTypeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetTaskTypeList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterJobOrderTaskType_GetTaskTypeList", (object) null, "Job Order Task Type Master - GetTaskTypeList");
    }
  }
}
