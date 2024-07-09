//  
// Type: CodeLock.Models.MasterAddress
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterAddress : BaseModel
  {
    [Display(Name = "City Name")]
    [Required(ErrorMessage = "Please select City Name")]
    public int CityId { get; set; }

    [Required(ErrorMessage = "Please select City Name")]
    public string CityName { get; set; }

    public short AddressId { get; set; }

    [Display(Name = "Address Code")]
    [Remote("IsAddressCodeAvailable", "Address", AdditionalFields = "AddressId,_AddressIdToken", ErrorMessage = "Address Code already exists.", HttpMethod = "POST")]
    [Required(ErrorMessage = "Please enter Address Code")]
    [StringLength(20, ErrorMessage = "Address must be minimum 2 and maximum 20 character long", MinimumLength = 2)]
    public string AddressCode { get; set; }

    [Required(ErrorMessage = "Please enter Address 1")]
    [StringLength(300, ErrorMessage = "Address 1 must be minimum 2 and maximum 300 character long", MinimumLength = 2)]
    [Display(Name = "Address 1")]
    public string Address1 { get; set; }

    [StringLength(300, ErrorMessage = "Address 2 must be minimum 2 and maximum 300 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Address 2")]
    [Display(Name = "Address 2")]
    public string Address2 { get; set; }

    [Display(Name = "Pincode")]
    [Required(ErrorMessage = "Please enter Pincode")]
    public string Pincode { get; set; }

    [Required(ErrorMessage = "Please enter Mobile No.")]
    [Display(Name = "Mobile No")]
    [MobileAnnotation]
    public string MobileNo { get; set; }

   [Display(Name = "Statistical Charges Code")]
    public string StatisticalChargesCode { get; set; }

        [Display(Name = "Is MRE No Applicable")]
        public bool IsMreNoApplicable { get; set; }

        [EmailAnnotation]
    [Display(Name = "Email Id")]
    [Required(ErrorMessage = "Please enter Email Address")]
    public string EmailId { get; set; }

    public byte CountryId { get; set; }

    public short StateId { get; set; }

    public short CustomerId { get; set; }
  }
}
