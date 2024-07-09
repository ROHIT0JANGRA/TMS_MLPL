//  
// Type: CodeLock.Models.DocketTaxDetail
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class DocketTaxDetail
  {
    public long DocketId { get; set; }

    public byte TaxCode { get; set; }

    public Decimal TaxAmount { get; set; }
  }
}
