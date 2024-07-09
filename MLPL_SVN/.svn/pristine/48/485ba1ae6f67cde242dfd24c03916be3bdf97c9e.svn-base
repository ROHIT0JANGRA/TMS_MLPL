//  
// Type: CodeLock.Areas.Operation.Repository.IQuickDocketRepository
//  
//  
//  

using CodeLock.Models;
using System;

namespace CodeLock.Areas.Operation.Repository
{
  public interface IQuickDocketRepository : IDisposable
  {
    DocketStep1 GetStep1Detail(short locationId, byte companyId);

    Response Insert(Docket objDocket);

    Response Update(Docket objDocket);
  }
}
