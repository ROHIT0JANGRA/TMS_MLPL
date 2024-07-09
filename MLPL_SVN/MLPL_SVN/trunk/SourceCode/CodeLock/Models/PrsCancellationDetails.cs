//  
// Type: CodeLock.Models.PrsCancellationDetails
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PrsCancellationDetails
  {
    public long PrsId { get; set; }

    public bool IsChecked { get; set; }

    public string CancelReason { get; set; }

    [Display(Name = "Cancel Date")]
    public DateTime CancelDate { get; set; }
  }
}
