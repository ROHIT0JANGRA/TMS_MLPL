//  
// Type: CodeLock.Models.DocketCancellationDetails
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocketCancellationDetails
  {
    public long DocketId { get; set; }

    public bool IsChecked { get; set; }

    public string CancelReason { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
    [Display(Name = "Cancel Date")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Please select Cancel Date and Time")]
    public DateTime CancelDate { get; set; }
  }
}
