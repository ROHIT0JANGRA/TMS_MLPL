//  
// Type: CodeLock.Models.VendorContractDistanceBased
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VendorContractDistanceBased : BaseModel
  {
    public short ContractId { get; set; }

    public byte VendorTypeId { get; set; }

    [Display(Name = "Transport Mode")]
    [Required(ErrorMessage = "Please select Transport Mode")]
    public byte TransportModeId { get; set; }

    [Required(ErrorMessage = "Please select FTL Type")]
    [Display(Name = "FTL Type")]
    public byte FtlTypeId { get; set; }

    [Required(ErrorMessage = "Please select Vehicle Type")]
    [Display(Name = "Vehicle Type")]
    public short VehicleTypeId { get; set; }

    [Required(ErrorMessage = "Please select Vehicle")]
    [Display(Name = "Vehicle No.")]
    public short VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Minimum Charge")]
    [AssertThat("MaximumCharge > MinimumCharge", ErrorMessage = "Maxmimum Charge is must be greater than to Minimum Charge")]
    [Range(0.0, 9999999999.0, ErrorMessage = "Please enter valid Minimum Charge")]
    [Display(Name = "Minimum Amount")]
    public Decimal MinimumCharge { get; set; }

    [Required(ErrorMessage = "Please enter Maxmimum Charge")]
    [Range(0.01, 9999999999.0, ErrorMessage = "Please enter Maxmimum Charge greater than zero")]
    [Display(Name = "Maxmimum Charge")]
    public Decimal MaximumCharge { get; set; }

    [Display(Name = "Commited KM.")]
    [Range(0.01, 99999.0, ErrorMessage = "Please enter Commited KM. greater than zero")]
    [Required(ErrorMessage = "Please enter Commited KM.")]
    public Decimal MinimumKM { get; set; }

    [Range(0.01, 9999.0, ErrorMessage = "Please enter Rate greater than zero")]
    [Display(Name = "Rate Per Additional KM.")]
    [Required(ErrorMessage = "Please enter Rate Per Additional KM.")]
    public Decimal RatePerAdditionalKM { get; set; }

    [Required(ErrorMessage = "Please enter Trip Per Month")]
    [Range(0.01, 999.0, ErrorMessage = "Please enter Trip greater than zero")]
    [Display(Name = "Trip Per Month")]
    public byte TripPerMonth { get; set; }
  }
}
