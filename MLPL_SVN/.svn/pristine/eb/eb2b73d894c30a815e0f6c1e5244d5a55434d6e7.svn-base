//  
// Type: CodeLock.Models.PrsCancellation
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PrsCancellation
  {
    [Display(Name = "PRS No")]
    public string PrsNo { get; set; }

    [Display(Name = "Manual PRS No")]
    public string ManualPrsNo { get; set; }

    public short? CancelBy { get; set; }

    public string LocationCode { get; set; }

    public List<PrsCancellationDetails> Details { get; set; }
  }
}
