//  
// Type: CodeLock.Models.ThcManifestDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ThcManifestDetail
  {
    public bool IsThc { get; set; }

    public long ThcId { get; set; }

    public long ManifestId { get; set; }

    [Display(Name = "Manifest No")]
    public string ManifestNo { get; set; }

    [Display(Name = "Manual Manifest No")]
    public string ManualManifestNo { get; set; }

    [Display(Name = "Next Stop")]
    public string DestinationCode { get; set; }

    [Display(Name = "Location Code")]
    public string OriginCode { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Manifest Date")]
    public DateTime? ManifestDate { get; set; }

    public int Docket { get; set; }

    [Display(Name = "Packages")]
    public int Packages { get; set; }

    [Display(Name = "Actual Weight")]
    public Decimal ActualWeight { get; set; }

    [Display(Name = "Vendor Weight")]
    public Decimal VendorWeight { get; set; }
    public bool IsChecked { get; set; }

    public short DestinationId { get; set; }

    public long DocketId { get; set; }

    public short ToLocationId { get; set; }

    public bool IsArrived { get; set; }

    public bool IsHold { get; set; }
    public bool IsThcStockUpdateDone { get; set; }
  }
}
