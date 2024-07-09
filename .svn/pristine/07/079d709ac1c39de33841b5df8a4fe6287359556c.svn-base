using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CityPincodeMapping : Base
  {
    [Display(Name = "Country Name")]
    [Required(ErrorMessage = "Please select Country Name")]
    public byte CountryId { get; set; }

    [Display(Name = "State Name")]
    [Required(ErrorMessage = "Please select State Name")]
    public short StateId { get; set; }

    [Display(Name = "City Name")]
    [Required(ErrorMessage = "Please select City Name")]
    public long CityId { get; set; }

    [Required(ErrorMessage = "Please select Pincode Details")]
    public MasterPincode Pincode { get; set; }
  }
}
