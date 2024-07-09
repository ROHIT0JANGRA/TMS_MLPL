//  
// Type: CodeLock.Models.MasterFuelBrand
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterFuelBrand : BaseModel
  {
    public byte FuelBrandId { get; set; }

    [Display(Name = "Fuel Brand Name")]
    [Required(ErrorMessage = "Please enter Fuel Brand Name")]
    [StringLength(25, ErrorMessage = "Fuel Brand Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Remote("IsFuelBrandNameAvailable", "FuelBrand", AdditionalFields = "FuelBrandId,_FuelBrandIdToken", ErrorMessage = "Fuel Brand Name already exists.", HttpMethod = "POST")]
    public string FuelBrandName { get; set; }

    [Display(Name = "Vendor Code")]
    public short VendorId { get; set; }

    [Required(ErrorMessage = "Please enter Vendor Code")]
    public string VendorCode { get; set; }

    public string VendorName { get; set; }

    [Display(Name = "Fuel Type")]
    public MultiCheckBox[] FuelType { get; set; }

    public string FuelTypes { get; set; }

    public bool IsDiesel { get; set; }

    public bool IsPetrol { get; set; }

    public bool IsCng { get; set; }
  }
}
