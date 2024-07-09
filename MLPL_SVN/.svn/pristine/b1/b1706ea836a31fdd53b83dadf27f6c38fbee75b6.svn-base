//  
// Type: CodeLock.Areas.Operation.Repository.IVendorDocumentApprovalRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
  public interface IVendorDocumentApprovalRepository : IDisposable
  {
    IEnumerable<VendorDocumentDetail> GetDocumentListForApproval(
      short locationId,
      string SelectedDocumentType);

    Response Insert(VendorDocumentApproval objVendorDocumentApproval);

    IEnumerable<VendorDocumentDetail> GetVendorDocumentDetailListByDocumentId(
      long historyId);
  }
}
