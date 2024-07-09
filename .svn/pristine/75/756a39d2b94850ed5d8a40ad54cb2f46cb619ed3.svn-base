//  
// Type: CodeLock.Models.MasterVehicle
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterVehicle : BaseModel
  {
    public string FtlTypeName { get; set; }

    [Display(Name = " Vehicle")]
    public short VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Vehicle No")]
    [StringLength(50, ErrorMessage = "Vehicle No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsVehicleNoAvailable", "Vehicle", AdditionalFields = "VehicleId,_VehicleIdToken", ErrorMessage = "Vehicle No already exists", HttpMethod = "POST")]
    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    [Required(ErrorMessage = "Please select Vehicle Type")]
    [Display(Name = "Vehicle Type")]
    public short VehicleTypeId { get; set; }

    [Required(ErrorMessage = "Please select Vendor")]
    [Display(Name = "Vendor")]
    public short VendorId { get; set; }

    [Required(ErrorMessage = "Please select Ftl Type")]
    [Display(Name = "Ftl Type")]
    public byte FtlTypeId { get; set; }

    [Display(Name = "Location")]
    [Required(ErrorMessage = "Please select Location ")]
    public short LocationId { get; set; }

    [Display(Name = "Vendor Type")]
    public byte VendorTypeId { get; set; }

    [Display(Name = "Start Km")]
    public int? StartKm { get; set; }

    public string VehicleTypeName { get; set; }

    public string VendorTypeName { get; set; }

    public Decimal? Capacity { get; set; }

    public string VendorName { get; set; }

    public string LocationName { get; set; }

    public virtual MasterVehicleDetail MasterVehicleDetail { get; set; }
  }
}
