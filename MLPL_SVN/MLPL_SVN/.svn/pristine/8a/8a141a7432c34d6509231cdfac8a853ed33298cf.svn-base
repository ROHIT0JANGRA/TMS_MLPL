//  
// Type: CodeLock.Models.DrsCancellation
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DrsCancellation
  {
    [Display(Name = "Drs No")]
    public string DrsNo { get; set; }

    [Display(Name = "Manual Drs No")]
    public string ManualDrsNo { get; set; }

    public short? CancelBy { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public List<DrsCancellationDetails> Details { get; set; }
  }
}
