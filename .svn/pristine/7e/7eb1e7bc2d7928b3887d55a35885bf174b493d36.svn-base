//  
// Type: CodeLock.Models.ThcDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ThcDetail
  {
    public long TripsheetId { get; set; }

    [Display(Name = "From City")]
    public int FromCityId { get; set; }

    [Display(Name = "To City")]
    public int ToCityId { get; set; }

    [Required(ErrorMessage = "Please enter Thc No")]
    [Display(Name = "THC No")]
    public string ThcNo { get; set; }

    [Display(Name = "THC Date")]
    [Required(ErrorMessage = "Please enter Thc Date")]
    public DateTime ThcDate { get; set; }

    [Required(ErrorMessage = "Please enter Freight Amount")]
    [Display(Name = "Freight Amount")]
    public Decimal FreightAmount { get; set; }

    [Display(Name = "Labour Charge")]
    public Decimal LabourCharge { get; set; }

    [Display(Name = "Other Charge")]
    public Decimal OtherCharge { get; set; }

    [Display(Name = "Total")]
    public Decimal TotalAmount { get; set; }

    [Required(ErrorMessage = "Please enter From City")]
    public string FromCity { get; set; }

    [Required(ErrorMessage = "Please enter To City")]
    public string ToCity { get; set; }

    [Display(Name = "From Location")]
    public short FromLocationId { get; set; }

    [Display(Name = "To Location")]
    public short ToLocationId { get; set; }

    [Required(ErrorMessage = "Please enter From Location")]
    public string FromLocation { get; set; }

    [Required(ErrorMessage = "Please enter To Location")]
    public string ToLocation { get; set; }

    [Display(Name = "Starting Km")]
    public int? StartKm { get; set; }

    [Display(Name = "Closing Km")]
    public int? EndKm { get; set; }

    [Display(Name = "Total Rum Km")]
    public int? TotalRumKm { get; set; }

    public string LoadType { get; set; }
  }
}
