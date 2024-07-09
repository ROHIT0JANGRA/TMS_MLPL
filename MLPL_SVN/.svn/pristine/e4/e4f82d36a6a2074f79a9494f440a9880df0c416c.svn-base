//  
// Type: CodeLock.Areas.Finance.Repository.IPurchaseOrderRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Finance.Repository
{
  public interface IPurchaseOrderRepository : IDisposable
  {
    Response Insert(PurchaseOrder objPurchaseOrder);

    IEnumerable<PurchaseOrder> GetPurchaseOrderListForApproval(
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      short vendorId,
      string poNo,
      string manualPoNo,
      short locationId);

    Response Approve(PurchaseOrderApprove objPurchaseOrderApprove);

    Response GrnInsert(PoGrn objPoGrn);

    PurchaseOrder GetDetailById(long poId);

    IEnumerable<PurchaseOrder> GetPurchaseOrderListForGrnInsert(
      DateTime fromDate,
      DateTime toDate,
      byte materialCategoryId,
      short vendorId,
      string poNo,
      string manualPoNo);

    Response AdvancePayment(PurchaseOrderAdvancePayment objAdvancePayment);

    IEnumerable<PurchaseOrder> GetPurchaseOrderListForAdvancePayment(
      DateTime fromDate,
      DateTime toDate,
      short vendorId,
      DateTime finStartDate,
      DateTime finEndDate,
      string poNo,
      string manualPoNo,
      short locationId);

    Response IssueSlip(IssueSlip objIssueSlip);
  }
}
