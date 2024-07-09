//  
// Type: CodeLock.Models.ThcCancellation
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ThcCancellation
  {
    [Display(Name = "Thc No")]
    public string ThcNo { get; set; }

    [Display(Name = "Manual Thc No")]
    public string ManualThcNo { get; set; }

    public short? CancelBy { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public List<ThcCancellationDetails> Details { get; set; }
  }
}
