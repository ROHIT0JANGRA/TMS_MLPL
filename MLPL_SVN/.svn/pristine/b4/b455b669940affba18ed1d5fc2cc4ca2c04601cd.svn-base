//  
// Type: CodeLock.Models.MrCancellationDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MrCancellationDetail
  {
    public long MrId { get; set; }

    public bool IsChecked { get; set; }

    [Required(ErrorMessage = "Please enter Cancel Reason")]
    [StringLength(200, ErrorMessage = "Cancel Reason must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Cancel Reason")]
    public string CancelReason { get; set; }

    [Display(Name = "Cancel Date")]
    public DateTime CancelDate { get; set; }

    public short? CancelBy { get; set; }
  }
}
