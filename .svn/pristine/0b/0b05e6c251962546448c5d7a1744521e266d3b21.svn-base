//  
// Type: CodeLock.Areas.WMS.Repository.IGatePassRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.WMS.Repository
{
  public interface IGatePassRepository : IDisposable
  {
    IEnumerable<GatePass> GetGatePassInList(
      byte SupplierType,
      long SupplierId,
      string PurchseOrderNo,
      string InvoiceNo,
      string AsnNo,
      DateTime FromDate,
      DateTime ToDate);

    IEnumerable<AutoCompleteResult> GetGatePassNoList();

    IEnumerable<GatePass> GetSkuDetails(long AsnId);

    Response GatePassIn(GatePass objGatePass);
  }
}
