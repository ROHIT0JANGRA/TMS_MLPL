//  
// Type: CodeLock.Models.ThcDepartureManifest
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ThcDepartureManifest
  {
    public long ManifestId { get; set; }

    [Display(Name = "Sys. MF No")]
    public string ManifestNo { get; set; }

    [Display(Name = "Manual MF")]
    public string ManualManifestNo { get; set; }

    [Display(Name = "MF Branch")]
    public short LocationId { get; set; }

    [Display(Name = "Next Stop")]
    public short NextLocationId { get; set; }

    [Display(Name = "MF Date")]
    public DateTime ManifestDate { get; set; }

    public short TotalDocket { get; set; }

    public string LocationCode { get; set; }

    public string NextLocationCode { get; set; }

    public bool IsChecked { get; set; }
  }
}
