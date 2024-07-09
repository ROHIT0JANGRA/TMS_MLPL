//  
// Type: Manifest
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Manifest : BaseModel
{
  public long ManifestId { get; set; }

  public string ManifestNo { get; set; }

  [Required(ErrorMessage = "Please select Manifest Date and Time")]
  [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
  [Display(Name = "Manifest Date")]
  [DataType(DataType.DateTime)]
  public DateTime ManifestDateTime { get; set; }

  public DateTime ManifestDate { get; set; }

  public TimeSpan ManifestTime { get; set; }

  [StringLength(50, ErrorMessage = "Manual Manifest No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
  [Display(Name = "Manual Manifest No")]
  public string ManualManifestNo { get; set; }

  public short LocationId { get; set; }

  public string LocationCode { get; set; }

  public short NextLocationId { get; set; }

  [Required(ErrorMessage = "Please enter Next Stop")]
  [Display(Name = "Next Stop")]
  public string NextLocationCode { get; set; }

  [Display(Name = "Transport Mode")]
  public byte TransportModeId { get; set; }

  [Display(Name = "Destination")]
  public string DestinationLocation { get; set; }

  [Display(Name = "Region")]
  public string Region { get; set; }

  [Display(Name = "From City")]
  public int FromCityId { get; set; }

  public string FromCityName { get; set; }

  [Display(Name = "To City")]
  public int ToCityId { get; set; }

  public string ToCityName { get; set; }

  public string DocketNo { get; set; }

  public long LoadingSheetId { get; set; }

  [Display(Name = "Loading Sheet No.")]
  public string LoadingSheetNo { get; set; }

  [DataType(DataType.DateTime)]
  [Display(Name = "Loading Sheet Date and Time")]
  public DateTime LoadingSheetDateTime { get; set; }

  public short TotalDocket { get; set; }

  [Display(Name = "Total Packages")]
  public int TotalPackages { get; set; }

  [Display(Name = "Balance Packages")]
  public int BalancePackages { get; set; }

  [Display(Name = "Total Actual Weight")]
  public Decimal TotalActualWeight { get; set; }

  public short TotalLoadDocket { get; set; }

  public int TotalLoadPackages { get; set; }

  public Decimal TotalLoadActualWeight { get; set; }

  public Decimal TotalKartAmount { get; set; }

  [Display(Name = "Vendor Code")]
  public short VendorId { get; set; }

  public string VendorCode { get; set; }

  public string VendorName { get; set; }

  public string ManifestStatus { get; set; }

  public List<ManifestDocket> ManifestDocketList { get; set; }

  public List<ManifestDocket> NonManifestDocketList { get; set; }

   public Decimal TotalLabourAmount { get; set; }

    public Decimal TotalDeliveryKartAmount { get; set; }
    public Decimal TotalDeliveryLabourAmount { get; set; }
    public Decimal TotalDoorDeliveryBaAmount { get; set; }

    public short NextLocationSearchId { get; set; }

    [Display(Name = "Vendor Code")]
    //[RequiredIf("NextLocationSearchId != 0", ErrorMessage = "Please select vendor name")]
    public string VendorDumtcoId { get; set; }

    public string Remarks { get; set; }

}
