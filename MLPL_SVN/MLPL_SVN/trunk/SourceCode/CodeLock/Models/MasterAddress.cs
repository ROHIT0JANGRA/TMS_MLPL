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
        //[Remote("IsAddressCodeAvailable", "Address", AdditionalFields = "AddressId,_AddressIdToken", ErrorMessage = "Address Code already exists.", HttpMethod = "POST")]
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
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please select State Name")]
        public short StateId { get; set; }

        public short CustomerId { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }   
        [Display(Name = "Provisional Id/No")]
        public string ProvisionalId { get; set; }

        [GstInNoAnnotation]
        [Required(ErrorMessage = "Please enter GSTIN No")]
        [Display(Name = "GSTIN No")]
        [StringLength(15, ErrorMessage = "GSTIN No must be 15 character long", MinimumLength = 15)]
        public string GstTinNo { get; set; }

        public string GstType { get; set; }

        [Display(Name = "Pin Code")]
        [Required(ErrorMessage = "Please Enter Pincode")]
        [StringLength(10, ErrorMessage = "Pincode must be minimum 4 and maximum 10 character long", MinimumLength = 4)]
        public string Pincode { get; set; }

        [Display(Name = "Registration Type")]
        [Required(ErrorMessage = "Please select registration type")]
        public string RegistrationType { get; set; }
        [Display(Name = "Registration Type")]
        public string RegistrationTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
