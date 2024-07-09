//  
// Type: CodeLock.Models.MasterAirport
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterAirport : BaseModel
  {
    public byte AirportId { get; set; }

    [Required(ErrorMessage = "Please enter Airport No")]
    [StringLength(25, ErrorMessage = "Airport No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Remote("IsAirportNoAvailable", "Airport", AdditionalFields = "CompanyId,AirportId,_AirportIdToken", ErrorMessage = "Airport No already exists.", HttpMethod = "POST")]
    [Display(Name = "Airport No")]
    public string AirportNo { get; set; }

    [Remote("IsAirportNameAvailable", "Airport", AdditionalFields = "CompanyId,AirportId,_AirportIdToken", ErrorMessage = "Airport Name already exists.", HttpMethod = "POST")]
    [Display(Name = "Airport Name")]
    [Required(ErrorMessage = "Please enter Airport Name")]
    [StringLength(25, ErrorMessage = "Airport Name must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    public string AirportName { get; set; }

    [Required(ErrorMessage = "Please select Country")]
    [Display(Name = "Country Name")]
    public byte CountryId { get; set; }

    public string CountryName { get; set; }

    [Required(ErrorMessage = "Please select State")]
    [Display(Name = "State Name")]
    public short StateId { get; set; }

    public string StateName { get; set; }

    [Required(ErrorMessage = "Please select City")]
    [Display(Name = "City")]
    public int CityId { get; set; }

    public string CityName { get; set; }

    [Required(ErrorMessage = "Please select Alternate City")]
    [Display(Name = "Alternate City")]
    public int AlternateCityId { get; set; }

    public string AlternateCityName { get; set; }
  }
}
