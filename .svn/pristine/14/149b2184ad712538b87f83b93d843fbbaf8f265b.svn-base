//  
// Type: ManifestCancellation
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ManifestCancellation
{
  [Display(Name = "Manifest No")]
  public string ManifestNo { get; set; }

  [Display(Name = "Manual Manifest No")]
  public string ManualManifestNo { get; set; }

  public short? CancelBy { get; set; }

  public short LocationId { get; set; }

  public string LocationCode { get; set; }

  public List<ManifestCancellationDetails> Details { get; set; }
}
