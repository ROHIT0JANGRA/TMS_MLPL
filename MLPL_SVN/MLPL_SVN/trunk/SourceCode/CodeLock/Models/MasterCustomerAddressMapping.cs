//  
// Type: CodeLock.Models.MasterCustomerAddressMapping
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterCustomerAddressMapping : Base
  {
    [Required(ErrorMessage = "Please select Customer")]
    [Display(Name = "Customer")]
    public short CustomerId { get; set; }

    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }

    public short AddressId { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }

    [Display(Name = "Address")]
    public List<MasterCustomerAddressMapping> AddressList { get; set; }

    public string Pincode { get; set; }

    [Display(Name = "Address Code")]
    public string AddressCode { get; set; }

    [Required(ErrorMessage = "Please select Country Name")]
    [Display(Name = "Country Name")]
    public byte CountryId { get; set; }

    [Display(Name = "State Name")]
    [Required(ErrorMessage = "Please select State Name")]
    public short StateId { get; set; }

    [Display(Name = "City Name")]
    [Required(ErrorMessage = "Please select City Name")]
    public int CityId { get; set; }

    public string CountryName { get; set; }

    public string StateName { get; set; }

    public string CityName { get; set; }
  }
}
