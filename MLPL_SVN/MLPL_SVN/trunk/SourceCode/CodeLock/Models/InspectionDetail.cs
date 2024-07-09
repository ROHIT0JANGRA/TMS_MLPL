//  
// Type: CodeLock.Models.InspectionDetail
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class InspectionDetail
  {
    public bool IsChecked { get; set; }

    public long GrnId { get; set; }

    public DateTime GrnDate { get; set; }

    public string GrnNo { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public Decimal GrnQuantity { get; set; }

    public Decimal InspectionQuantity { get; set; }

    public Decimal ApproveQuantity { get; set; }

    public Decimal RepackingQuantity { get; set; }

    public Decimal RejectQuantity { get; set; }

    public byte? RejectReason { get; set; }

    public string Remarks { get; set; }
  }
}
