//  
// Type: CodeLock.Models.GstRegistration
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class GstRegistration : BaseModel
    {
        public long GstId { get; set; }

        public byte OwnerType { get; set; }

        public long OwnerId { get; set; }

        public string OwnerCode { get; set; }

        public string OwnerName { get; set; }

        public short CustomerId { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Is GstRegistered")]
        public bool IsGstRegistered { get; set; }

        public HttpPostedFileBase GstDeclarationAttachment { get; set; }

        [Display(Name = "Upload Declaration Document")]
        public string DeclarationDocumentName { get; set; }
        [Required(ErrorMessage = "Please enter State")]
        public short StateId { get; set; }

        [Display(Name = "State")]

        public string StateName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        public int CityId { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter City")]
        public string CityName { get; set; }

        [StringLength(10, ErrorMessage = "Provisional ID/No must be 10 character long", MinimumLength = 10)]
        [Required(ErrorMessage = "Please enter Provisional ID/No")]
        [Display(Name = "Provisional Id/No")]
        public string ProvisionalId { get; set; }

        [GstInNoAnnotation]
        //[Required(ErrorMessage = "Please enter GSTIN No")]
       // [AssertThat("RegistrationType = 1", ErrorMessage = "Please enter GSTIN No")]
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

        [Display(Name = "Pan No")]
        public string PanNo { get; set; }



    }
}
