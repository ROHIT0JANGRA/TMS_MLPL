//  
// Type: CodeLock.Models.MasterVehicleType
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterVehicleType : BaseModel
  {
    public string FuelTypeName { get; set; }

    public short VehicleTypeId { get; set; }

    [Display(Name = "Vehicle Manufacturer Name")]
    [StringLength(50, ErrorMessage = "Vehicle Manufacturer Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [NameAnnotation]
    [Required(ErrorMessage = "Please enter Vehicle Manufacturer Name")]
    public string Manufacturer { get; set; }

    [Display(Name = "Vehicle Type Name")]
    [StringLength(50, ErrorMessage = "Vehicle Type Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsVehicleTypeNameAvailable", "VehicleType", AdditionalFields = "VehicleTypeId,_VehicleTypeIdToken", ErrorMessage = "Vehicle Type Name already exists.", HttpMethod = "POST")]
    [Required(ErrorMessage = "Please enter Vehicle Type Name")]
    public string VehicleTypeName { get; set; }

    [StringLength(50, ErrorMessage = "Model No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Model No")]
    [Required(ErrorMessage = "Please enter Model No")]
    public string ModelNo { get; set; }

    [Required(ErrorMessage = "Please enter Vehicle Type Description")]
    [StringLength(50, ErrorMessage = "Vehicle Type Description must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Vehicle Type Description")]
    public string VehicleTypeDescription { get; set; }

    [Range(0, 2147483647, ErrorMessage = "Please enter a value between 0 to 999999999")]
    [Required(ErrorMessage = "Please enter Gross Vehicle Weight")]
    [Display(Name = "Gross Vehicle Weight")]
    public Decimal GrossVehicleWeight { get; set; }

    [Display(Name = "Unladen Weight")]
    [Required(ErrorMessage = "Please enter Unladen Weight")]
    [Range(0, 2147483647, ErrorMessage = "Please enter a value between 0 to 999999999")]
    public Decimal UnladenWeight { get; set; }

    [Display(Name = "Capacity")]
    public Decimal? Capacity { get; set; }

    [Required(ErrorMessage = "select fuel Type")]
    [Display(Name = "Fuel Type")]
    public byte FuelTypeId { get; set; }

    [Required(ErrorMessage = "Please enter Length")]
    [Display(Name = "Length")]
    [Range(1, 2147483647, ErrorMessage = "Please enter a value between 0 to 999999")]
    public Decimal Length { get; set; }

    [Range(1, 2147483647, ErrorMessage = "Please enter a value between 0 to 999999")]
    [Display(Name = "Width")]
    [Required(ErrorMessage = "Please enter Width")]
    public Decimal Width { get; set; }

    [Range(1, 2147483647, ErrorMessage = "Please enter a value between 0 to 999999")]
    [Required(ErrorMessage = "Please enter Height")]
    [Display(Name = "Height")]
    public Decimal Height { get; set; }
  }
}
