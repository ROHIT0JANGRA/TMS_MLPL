//  
// Type: CodeLock.Models.MasterPincode
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterPincode : BaseModel
  {
    [Display(Name = "Location Code")]
    public string LocationCode { get; set; }

    public int PincodeId { get; set; }

    [Required(ErrorMessage = "Please select Country Name")]
    [Display(Name = "Country Name")]
    public byte CountryId { get; set; }

    [Display(Name = "State Name")]
    [Required(ErrorMessage = "Please select State Name")]
    public short StateId { get; set; }

    [Display(Name = "City Name")]
    [Required(ErrorMessage = "Please select City Name")]
    public int CityId { get; set; }

    [Display(Name = "Country Name")]
    public string CountryName { get; set; }

    [Display(Name = "State Name")]
    public string StateName { get; set; }

    [Display(Name = "City Name")]
    public string CityName { get; set; }

    [Display(Name = "Pincode")]
    [Required(ErrorMessage = "Please Enter Pincode")]
    [StringLength(10, ErrorMessage = "Pincode must be minimum 4 and maximum 10 character long", MinimumLength = 4)]
    [Remote("IsPincodeAvailable", "Pincode", AdditionalFields = "PincodeId,_PincodeIdToken", ErrorMessage = "Pincode already exists.", HttpMethod = "POST")]
    public string Pincode { get; set; }

    [Required(ErrorMessage = "Please select Area")]
    public string Area { get; set; }

    public short? LocationId { get; set; }
     public string LocationName { get; set; }

    }
}
