//  
// Type: CodeLock.Models.VendorContractRouteBased
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorContractRouteBased : BaseModel
  {
    public short ContractId { get; set; }

    public byte VendorTypeId { get; set; }

    [Required(ErrorMessage = "Please select Transport Mode")]
    [Display(Name = "Transport Mode")]
    public byte TransportModeId { get; set; }

    [Display(Name = "FTL Type")]
    [Required(ErrorMessage = "Please select FTL Type")]
    public byte FtlTypeId { get; set; }

    [Required(ErrorMessage = "Please select Route")]
    [Display(Name = "Route")]
    public short RouteId { get; set; }

    [Display(Name = "FTL Type")]
    public byte FtlType { get; set; }

    [Display(Name = "Vehicle Number")]
    public short VehicleNo { get; set; }

    [Display(Name = "Vehicle Number")]
    [Required(ErrorMessage = "Please select Vehicle")]
    public short VehicleId { get; set; }

    [Range(0.0, 9999999999.0, ErrorMessage = "Please enter valid Minimum Charge")]
    [Display(Name = "Minimum Charge")]
    [AssertThat("MaximumCharge > MinimumCharge", ErrorMessage = "Minimum Charge is must be less than to Maxmimum Charge")]
    [Required(ErrorMessage = "Please enter Minimum Charge")]
    public Decimal MinimumCharge { get; set; }

    [AssertThat("MaximumCharge > MinimumCharge", ErrorMessage = "Maxmimum Charge is must be greater than to Minimum Charge")]
    [Range(0.01, 9999999999.0, ErrorMessage = "Please enter Maxmimum Charge greater than zero")]
    [Display(Name = "Maximum Charge")]
    [Required(ErrorMessage = "Please enter Maxmimum Charge")]
    public Decimal MaximumCharge { get; set; }

    [Display(Name = "Rate Type")]
    [Required(ErrorMessage = "Please select Rate Type")]
    public byte RateTypeId { get; set; }

    [Required(ErrorMessage = "Please enter Rate")]
    [Range(0.01, 9999999999.0, ErrorMessage = "Please enter Rate greater than zero")]
    [Display(Name = "Rate")]
    public Decimal Rate { get; set; }
  }
}
