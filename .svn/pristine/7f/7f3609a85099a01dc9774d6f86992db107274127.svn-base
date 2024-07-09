//  
// Type: CodeLock.Areas.WMS.Repository.IInspectionRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.WMS.Repository
{
  public interface IInspectionRepository : IDisposable
  {
    Response Insert(Inspection objInspection);

    IEnumerable<InspectionDetail> GetInspectionList(
      byte warehouseId,
      byte companyId,
      DateTime fromDate,
      DateTime toDate,
      string invoiceNos,
      string grnNos);
  }
}
