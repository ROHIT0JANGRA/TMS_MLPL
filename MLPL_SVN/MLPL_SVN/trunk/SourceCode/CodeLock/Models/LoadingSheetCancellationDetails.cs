//  
// Type: CodeLock.Models.LoadingSheetCancellationDetails
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class LoadingSheetCancellationDetails
  {
    public long LoadingSheetId { get; set; }

    public bool IsChecked { get; set; }

    public string CancelReason { get; set; }

    public DateTime CancelDate { get; set; }
  }
}
