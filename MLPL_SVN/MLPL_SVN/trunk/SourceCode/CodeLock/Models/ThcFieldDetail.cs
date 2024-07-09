//  
// Type: CodeLock.Models.ThcFieldDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ThcFieldDetail
  {
    [Display(Name = "THC No")]
    public string ThcNo { get; set; }

    [Display(Name = "THC Date")]
    public DateTime ThcDate { get; set; }

    [Display(Name = "From Location")]
    public short FromLocationId { get; set; }

    [Display(Name = "To Location")]
    public short ToLocationId { get; set; }

    [Display(Name = "From Location")]
    public string FromLocation { get; set; }

    [Display(Name = "To Location")]
    public string ToLocation { get; set; }

    [Display(Name = "Starting Km")]
    public int? StartKm { get; set; }

    [Display(Name = "Closing Km")]
    public int? EndKm { get; set; }

    [Display(Name = "Total Rum Km")]
    public int? TotalRumKm { get; set; }

    [Display(Name = "Load Type")]
    public string LoadType { get; set; }
  }
}
