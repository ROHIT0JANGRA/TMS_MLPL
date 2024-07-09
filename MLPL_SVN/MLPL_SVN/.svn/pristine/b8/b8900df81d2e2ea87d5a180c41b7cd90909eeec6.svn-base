//  
// Type: CodeLock.Models.MasterCity
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterCity : BaseModel
  {
    [Display(Name = "Country Name")]
    [Required(ErrorMessage = "Please select Country Name")]
    public byte CountryId { get; set; }

    [Display(Name = "State Name")]
    [Required(ErrorMessage = "Please select State Name")]
    public short StateId { get; set; }

    [Required(ErrorMessage = "Please select Zone Name")]
    [Display(Name = "Zone Name")]
    public byte ZoneId { get; set; }

    public long CityId { get; set; }

    [Required(ErrorMessage = "Please enter City Name")]
    [Remote("IsCityNameAvailable", "City", AdditionalFields = "CityId,_CityIdToken", ErrorMessage = "City Name already exists.", HttpMethod = "POST")]
    [Display(Name = "City Name")]
    [StringLength(50, ErrorMessage = "City Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string CityName { get; set; }

    [Display(Name = "Is Permit Required")]
    public bool IsPermitRequired { get; set; }

    [Display(Name = "Is ODA Applicable")]
    public bool IsOdaApplicable { get; set; }

    [Display(Name = "ODA KM")]
    [Range(0, 2147483647, ErrorMessage = "ODA KM must be a greater than or equal to zero")]
    public Decimal OdaKm { get; set; }

    [Display(Name = "State Name")]
    public string StateName { get; set; }

    [Display(Name = "Zone Name")]
    public string ZoneName { get; set; }

    [Display(Name = "Country Name")]
    public string CountryName { get; set; }
        [Display(Name = "B2C Zone")]
    public string B2CZoneId { get; set; }

   [Display(Name = "B2C Zone Name")]
   public string B2CZoneName { get; set; }

   [Display(Name = "Is Metro")]
   public bool isMetro { get; set; }
    }
}
