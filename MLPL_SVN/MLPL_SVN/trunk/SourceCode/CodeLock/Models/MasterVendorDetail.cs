//  
// Type: CodeLock.Models.MasterVendorDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class MasterVendorDetail : BaseModel
    {
        public MasterVendorDetail()
        {
            this.VendorId = (short)0;
        }

        public short VendorId { get; set; }

        [StringLength(25, ErrorMessage = "Password must be minimum 6 and maximum 25 character long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter PAN No")]
        [PanNoAnnotation]
        [Display(Name = "PAN No")]
        public string PanNo { get; set; }

        [Display(Name = "GST TIN No")]
        [GstInNoAnnotation]
        public string GstTinNo { get; set; }

        [Required(ErrorMessage = "Please enter Mobile No")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please enter Email Id")]
        [EmailAnnotation]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please select Country Name")]
        public byte CountryId { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please select State Name")]
        public short StateId { get; set; }
        public string StateName { get; set; }

        public short CityId { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(250, ErrorMessage = "Remarks must be minimum 2 and maximum 250 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Is Black Listed")]
        public bool IsBlackListed { get; set; }

        [Display(Name = "TDS Certificate")]
        public string TdsCertificate { get; set; }

        [Display(Name = "TDS Certificate")]
        public HttpPostedFileBase TdsCertificateDocumentAttachment { get; set; }

        [Display(Name = "Is TDS Applicable")]
        public bool IsTDSApplicable { get; set; }

        [Display(Name = "TDS Rate")]
        [Range(0, 999, ErrorMessage = "Please enter TDS Rate between 0 to 999")]
        public Decimal TDSRate { get; set; }

        [Display(Name = "TDS Account")]
        [Required(ErrorMessage = "Please select TDS Account")]
        public short TdsAccountId { get; set; }
        public string TdsAccount { get; set; }

        [Display(Name = "Is GST Applicable")]
        public bool IsGstApplicable { get; set; }

        [Display(Name = "Vendor GST State Name")]
        public short? VendorGstStateId { get; set; }
        public string VendorGstStateName { get; set; }

        [Display(Name = "Vendor GstTinNo")]
        public string VendorGstTinNo { get; set; }
        public long? VendorGstId { get; set; }

        [Display(Name = "Company GST State")]
        public short? CompanyGstStateId { get; set; }

        [Display(Name = "Company GSTState Name")]
        public string CompanyGstStateName { get; set; }

        [Display(Name = "Company GstTinNo")]
        public string CompanyGstTinNo { get; set; }
        public long? CompanyGstId { get; set; }

    }
}
