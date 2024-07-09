//  
// Type: CodeLock.Models.VehicleCapacityRateDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class VehicleCapacityRateDetail
  {
    public short LocationId { get; set; }

    [Required(ErrorMessage = "Please enter Location")]
    public string LocationCode { get; set; }

    [Required(ErrorMessage = "Please select Transport Mode")]
    public byte TransportModeId { get; set; }

    public string TransportMode { get; set; }

    [Required(ErrorMessage = "Please select Vehicle Type")]
    public short VehicleTypeId { get; set; }

    public string VehicleType { get; set; }

    public Decimal VehicleCapacity { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Allowed Weight")]
    [Required(ErrorMessage = "Please enter Allowed Weight")]
    public Decimal AllowedWeight { get; set; }

    [Required(ErrorMessage = "Please enter Allowed Mimumum Rate")]
    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Allowed Mimumum Rate")]
    public Decimal AllowedMimumumRate { get; set; }

    [Required(ErrorMessage = "Please enter Allowed Maximum Rate")]
    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Allowed Maximum Rate")]
    public Decimal AllowedMaximumRate { get; set; }

    [Required(ErrorMessage = "Please select Rate Type")]
    public byte RateTypeId { get; set; }

    public string RateType { get; set; }
  }
}
