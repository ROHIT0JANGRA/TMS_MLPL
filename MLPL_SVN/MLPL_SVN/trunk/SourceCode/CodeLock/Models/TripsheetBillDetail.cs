//  
// Type: CodeLock.Models.TripsheetBillDetail
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class TripsheetBillDetail
  {
    public long TripsheetId { get; set; }

    public string TripsheetNo { get; set; }

    public Decimal AcKm { get; set; }

    public Decimal NonAcKm { get; set; }

    public Decimal EmptyKm { get; set; }

    public Decimal FixedAcRate { get; set; }

    public Decimal FixedNonAcRate { get; set; }

    public Decimal FixedEmptyRate { get; set; }

    public Decimal VariableAcRate { get; set; }

    public Decimal VariableNonAcRate { get; set; }

    public Decimal VariableEmptyRate { get; set; }

    public Decimal GrossAmount { get; set; }

    public Decimal GstAmount { get; set; }

    public Decimal TotalAmount { get; set; }

    public bool IsChecked { get; set; }
  }
}
