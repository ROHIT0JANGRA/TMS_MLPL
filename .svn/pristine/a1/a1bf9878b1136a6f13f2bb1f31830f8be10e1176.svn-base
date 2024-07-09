//  
// Type: CodeLock.Models.LoadingSheetCancellation
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class LoadingSheetCancellation
  {
    [Display(Name = "Loading Sheet No")]
    public string LoadingSheetNo { get; set; }

    [Display(Name = "Manual Loading Sheet No")]
    public string ManualLoadingSheetNo { get; set; }

    public short? CancelBy { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public List<LoadingSheetCancellationDetails> Details { get; set; }
  }
}
