//  
// Type: CodeLock.Areas.Master.Repository.IssueRepository
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
  public class IssueRepository : BaseRepository, IIssueRepository, IDisposable
  {
    public IEnumerable<MasterIssue> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterIssue>("Usp_Issue_GetAll", (object) null, "Issue Master - GetAll");
    }

    public IEnumerable<MasterIssue> GetHistoryById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@IssueId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterIssue>("Usp_Issue_GetHistoryById", (object) dynamicParameters, "Issue Master - GetHistoryById");
    }

    public MasterIssue GetDetailById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@IssueId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterIssue>("Usp_Issue_GetDetailById", (object) dynamicParameters, "Issue Master - GetDetailById").FirstOrDefault<MasterIssue>();
    }

    public Response Insert(MasterIssue objIssue)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterIssue", (object) XmlUtility.XmlSerializeToString((object) objIssue), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Issue_Insert", (object) dynamicParameters, "Issue Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterIssue objIssue)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterIssue", (object) XmlUtility.XmlSerializeToString((object) objIssue), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Issue_Update", (object) dynamicParameters, "Issue Master - Update").FirstOrDefault<Response>();
    }

    public Response Close(MasterIssueClose objMasterIssueClose)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterIssueClose", (object) XmlUtility.XmlSerializeToString((object) objMasterIssueClose), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Issue_Close", (object) dynamicParameters, "Issue Master - Close").FirstOrDefault<Response>();
    }

    public Response Approval(MasterIssueApproval objMasterIssueApproval)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterIssueApproval", (object) XmlUtility.XmlSerializeToString((object) objMasterIssueApproval), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Issue_Approval", (object) dynamicParameters, "Issue Master - Approval").FirstOrDefault<Response>();
    }

    public MasterIssue GetHistoryDetailById(long historyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HistoryId", (object) historyId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterIssue>("Usp_Issue_GetHistoryDetailById", (object) dynamicParameters, "Issue Master - GetHistoryDetailById").FirstOrDefault<MasterIssue>();
    }
  }
}
