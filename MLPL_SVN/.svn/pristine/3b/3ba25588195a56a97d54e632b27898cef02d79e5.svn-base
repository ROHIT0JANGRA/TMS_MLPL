//  
// Type: CodeLock.Models.ThcDocketDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ThcDocketDetail
  {
    public long ThcId { get; set; }

    public long? ManifestId { get; set; }

    public short? ManifestDestinationId { get; set; }

    public long DocketId { get; set; }

    public short DocketDestinationId { get; set; }

    public string DocketNo { get; set; }

    [Display(Name = "Suffix")]
    public string DocketSuffix { get; set; }

    [Display(Name = "Booking Date")]
    public DateTime DocketDate { get; set; }

    [Display(Name = "Committed Delay Date")]
    public DateTime? DeliveryDate { get; set; }

    [Display(Name = "Packages")]
    public short Packages { get; set; }

    [Display(Name = "Actual Weight")]
    public Decimal ActualWeight { get; set; }

    [Display(Name = "Charge Weight")]
    public Decimal ChargeWeight { get; set; }

    [Display(Name = "Origin")]
    public string FromLocationCode { get; set; }

    [Display(Name = "Destination")]
    public string ToLocationCode { get; set; }

    [Display(Name = "Pay Basis")]
    public string Paybas { get; set; }

    public bool IsChecked { get; set; }
  }
}
