//  
// Type: CodeLock.Areas.WMS.Repository.IDispatchRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.WMS.Repository
{
  public interface IDispatchRepository : IDisposable
  {
    Response Insert(Dispatch objDispatch);

    IEnumerable<Order> GetOrderListForDispatch(
      byte companyId,
      short warehouseId,
      string orderNo,
      string invoiceNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate);

    IEnumerable<DispatchDetail> GetOrderDetails(
      byte companyId,
      short warehouseId,
      long id);

    IEnumerable<DispatchRegister> GetRegisterDispatchDetail(
      string dispatchNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate);
  }
}
