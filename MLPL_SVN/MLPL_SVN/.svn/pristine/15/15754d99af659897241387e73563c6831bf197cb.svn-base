//  
// Type: CodeLock.Models.MasterVehicleColdChainRate
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterVehicleColdChainRate : BaseModel
  {
    public short VehicleId { get; set; }

    [Display(Name = "Vehicle No")]
    [Required(ErrorMessage = "Please enter Vehicle No")]
    public string VehicleNo { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Dry KMPL")]
    public Decimal OutsideCityDryKmpl { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Dry KMPL")]
    public Decimal WithinCityDryKmpl { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Reefer KMPL")]
    public Decimal OutsideCityReeferKmpl { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Reefer KMPL")]
    public Decimal WithinCityReeferKmpl { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Empty KMPL")]
    public Decimal OutsideCityEmptyKmpl { get; set; }

    [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Empty KMPL")]
    public Decimal WithinCityEmptyKmpl { get; set; }
  }
}
