//  
// Type: CodeLock.Models.MasterCountry
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterCountry : BaseModel
  {
    [Display(Name = "Country Id")]
    public byte CountryId { get; set; }

    [Remote("IsCountryNameAvailable", "Country", AdditionalFields = "CountryId,_CountryIdToken", ErrorMessage = "Country Name already exists.", HttpMethod = "POST")]
    [StringLength(50, ErrorMessage = "Country Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Country Name")]
    [Required(ErrorMessage = "Please enter Country Name")]
    public string CountryName { get; set; }
  }
}
