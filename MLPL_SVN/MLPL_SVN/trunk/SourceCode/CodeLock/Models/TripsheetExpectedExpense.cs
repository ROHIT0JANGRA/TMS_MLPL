//  
// Type: CodeLock.Models.TripsheetExpectedExpense
//  
//  
//  

using System;
using System.Collections.Generic;

namespace CodeLock.Models
{
  public class TripsheetExpectedExpense
  {
    public long TripsheetId { get; set; }

    public string ManualTripsheetNo { get; set; }

    public string TripsheetNo { get; set; }

    public DateTime TripsheetDate { get; set; }

    public string FirstDriverName { get; set; }

    public string VehicleNo { get; set; }

    public Decimal ExpectedAmount { get; set; }

    public string FromLocaton { get; set; }

    public string ToLocaton { get; set; }

    public string FromCity { get; set; }

    public string ToCity { get; set; }

    public List<TripsheetExpectedExpenseDetail> Details { get; set; }
  }
}
