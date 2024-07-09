//  
// Type: CodeLock.Areas.Master.Repository.JobOrderWorkGroupRepository
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
  public class JobOrderWorkGroupRepository : BaseRepository, IJobOrderWorkGroupRepository, IDisposable
  {
    public IEnumerable<MasterJobOrderWorkGroup> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterJobOrderWorkGroup>("Usp_MasterJobOrderWorkGroup_GetAll", (object) null, "Job Order Work Group Master- GetAll");
    }

    public MasterJobOrderWorkGroup GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@WorkGroupId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterJobOrderWorkGroup>("Usp_MasterJobOrderWorkGroup_GetDetailById", (object) dynamicParameters, "Job Order Work Group Master - GetDetailById").FirstOrDefault<MasterJobOrderWorkGroup>();
    }

    public Response Insert(MasterJobOrderWorkGroup objWorkGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlWorkGroup", (object) XmlUtility.XmlSerializeToString((object) objWorkGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterJobOrderWorkGroup_Insert", (object) dynamicParameters, "Job Order Work Group Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterJobOrderWorkGroup objWorkGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlWorkGroup", (object) XmlUtility.XmlSerializeToString((object) objWorkGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterJobOrderWorkGroup_Update", (object) dynamicParameters, "Job Order Work Group Master - Update").FirstOrDefault<Response>();
    }

    public bool IsWorkGroupAvailable(string workGroup, byte workGroupId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@WorkGroupId", (object) workGroupId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WorkGroup", (object) workGroup, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterJobOrderWorkGroup_IsWorkGroupAvailable", (object) dynamicParameters, "Job Order Work Group Master - IsWorkGroupAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetWorkGroupList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterJobOrderWorkGroup_GetWorkGroupList", (object) null, "Job Order Work Group Master - GetWorkGroupList");
    }
  }
}
