//  
// Type: CodeLock.Models.MasterPackagingMeasurement
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterPackagingMeasurement : BaseModel
  {
    public short PackagingTypeId { get; set; }

    [StringLength(100, ErrorMessage = "Packaging Type must be minimum 1 and maximum 100 character long", MinimumLength = 1)]
    [Display(Name = "Packaging Type")]
    [Required(ErrorMessage = "Please enter Packaging Type")]
    [Remote("IsPackagingTypeAvailable", "PackagingMeasurement", AdditionalFields = "PackagingTypeId,_PackagingTypeIdToken", ErrorMessage = "Packaging Type already exists", HttpMethod = "POST")]
    public string PackagingType { get; set; }

    [Display(Name = "Length")]
    [Range(0.0, 999.99, ErrorMessage = "Please enter a value between 0 to 999")]
    [Required(ErrorMessage = "Please enter Length")]
    public Decimal Length { get; set; }

    [Range(0.0, 999.99, ErrorMessage = "Please enter a value between 0 to 999")]
    [Required(ErrorMessage = "Please enter Breadth")]
    [Display(Name = "Breadth")]
    public Decimal Breadth { get; set; }

    [Range(0.0, 999.99, ErrorMessage = "Please enter a value between 0 to 999")]
    [Required(ErrorMessage = "Please enter Height")]
    [Display(Name = "Height")]
    public Decimal Height { get; set; }

    [Display(Name = "Measurement Type")]
    [Required(ErrorMessage = "Please select Measurement Type")]
    public string MeasurementType { get; set; }

    public string MeasurementTypeName { get; set; }
  }
}
