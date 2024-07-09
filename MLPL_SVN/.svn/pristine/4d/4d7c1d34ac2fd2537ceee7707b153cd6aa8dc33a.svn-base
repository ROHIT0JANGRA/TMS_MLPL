//  
// Type: CodeLock.Areas.Master.Repository.IIssueRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IIssueRepository : IDisposable
  {
    IEnumerable<MasterIssue> GetAll();

    IEnumerable<MasterIssue> GetHistoryById(long id);

    Response Insert(MasterIssue objIssue);

    MasterIssue GetDetailById(long id);

    Response Update(MasterIssue objIssue);

    Response Close(MasterIssueClose objMasterIssueClose);

    Response Approval(MasterIssueApproval objMasterIssueApproval);

    MasterIssue GetHistoryDetailById(long historyId);
  }
}
