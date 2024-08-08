//  
// Type: CodeLock.Models.MasterCustomerAddressInfo
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterCustomerAddressInfo
  {
   // public short CustomerId { get; set; }

   [Required(ErrorMessage = "Please select Communication Address 1")]
    [Display(Name = "Communication Address 1")]
    public string Address1 { get; set; }

    [Display(Name = "Communication Address 2")]
    [Required(ErrorMessage = "Please select Communication Address 2")]
    public string Address2 { get; set; }

    [Required(ErrorMessage = "Please select City")]
    [Display(Name = "City")]
    public int CityId { get; set; }

    [Required(ErrorMessage = "Please select Pincode")]
    [Display(Name = "Pincode")]
    public string Pincode { get; set; }

        [Required(ErrorMessage = "Please select Country")]
        [Display(Name = "Country")]
        public byte CountryId { get; set; } = 1;

    [Required(ErrorMessage = "Please select State")]
    [Display(Name = "State")]
    public short StateId { get; set; }

    public string CountryName { get; set; }

    public string StateName { get; set; }

    public string CityName { get; set; }
  }
}
