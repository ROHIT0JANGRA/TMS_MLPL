//  
// Type: CodeLock.Models.MasterZone
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterZone : BaseModel
  {
    [Display(Name = "Country Name")]
    [Required(ErrorMessage = "Please select Country Name")]
    public byte CountryId { get; set; }

    public byte ZoneId { get; set; }

    [Remote("IsZoneNameAvailable", "Zone", AdditionalFields = "ZoneId,_ZoneIdToken", ErrorMessage = "Zone Name already exists", HttpMethod = "POST")]
    [StringLength(50, ErrorMessage = "Zone Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Zone Name")]
    [Display(Name = "Zone Name")]
    public string ZoneName { get; set; }

    [Display(Name = "Country Name")]
    public string CountryName { get; set; }
  }
}
