//  
// Type: CodeLock.Models.VendorBillDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorBillDetail
  {
    public long BillId { get; set; }

    public string BillNo { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
    [DataType(DataType.DateTime)]
    public DateTime BillDate { get; set; }

    public string ManualBillNo { get; set; }

    public string VendorName { get; set; }

    public Decimal PaidAmount { get; set; }

    public Decimal PendAmount { get; set; }

    public Decimal NetAmount { get; set; }

    public string BranchCode { get; set; }

    public string BillType { get; set; }

    public Decimal GrandTotal { get; set; }

    public short EntryBy { get; set; }

    public DateTime EntryDate { get; set; }
  }
}
