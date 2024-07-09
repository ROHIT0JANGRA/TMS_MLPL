//  
// Type: CodeLock.Models.Departure
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Departure
  {
    public Departure()
    {
      this.TotalManifest = (short) 0;
      this.TotalDocket = (short) 0;
      this.TotalPackages = 0;
      this.TotalActualWeight = new Decimal(0);
    }

    public long ThcId { get; set; }

    [Display(Name = "THC No")]
    public string ThcNo { get; set; }

    [Display(Name = "THC Date")]
    public DateTime ThcDate { get; set; }

    public short FromLocationId { get; set; }

    public short ToLocationId { get; set; }

    public short RouteId { get; set; }

    [Display(Name = "Route")]
    public string RouteName { get; set; }

    [Display(Name = "Vehicle")]
    public string VehicleNo { get; set; }

    [Display(Name = "Actual Departure Date")]
    public DateTime ActualDepartureDate { get; set; }

    [Display(Name = "Start Kilometer")]
    public int StartKm { get; set; }

    [Display(Name = "Capacity Utilization(%)")]
    public Decimal CapacityUtilization { get; set; }

    [Required(ErrorMessage = "Please enter Out Seal No")]
    [Display(Name = "Out Seal No")]
    public string OutgoingSealNo { get; set; }

    [Required(ErrorMessage = "Please enter Outgoing Remark")]
    [Display(Name = "Outgoing Remarks")]
    public string OutgoingRemark { get; set; }

    [Display(Name = "Is Overload")]
    public bool IsOverLoaded { get; set; }

    [Display(Name = "Overload Reason")]
    [RequiredIf("IsOverLoaded == true", ErrorMessage = "Please select Overload Reason")]
    public byte? OverLoadedReasonId { get; set; }

    [Display(Name = "Total Weight Loaded")]
    public Decimal TotalWeightLoaded { get; set; }

    [Display(Name = "Vehicle Capacity")]
    public Decimal? VehicleCapacity { get; set; }

    public DateTime? ExpectedDepartureDate { get; set; }

    public List<ThcManifestDetail> ThcDepartureManifestList { get; set; }

    public short TotalManifest { get; set; }

    public short TotalDocket { get; set; }

    public int TotalPackages { get; set; }

    public Decimal TotalActualWeight { get; set; }

    public short LoadBy { get; set; }

    [Display(Name = "EWAY Bill No")]
    [Required(ErrorMessage = "Please enter EWAY Bill No")]
    [Range(1.0, 999999999999.0, ErrorMessage = "Please enter EWAY Bill No")]
    public string EwayBillNo { get; set; }

    [Display(Name = "EWAY Bill Issue Date")]
    public DateTime? EwayBillIssueDate { get; set; }

    [Display(Name = "EWAY Bill Expiry Date")]
    public DateTime? EwayBillExpiryDate { get; set; }
  }
}
