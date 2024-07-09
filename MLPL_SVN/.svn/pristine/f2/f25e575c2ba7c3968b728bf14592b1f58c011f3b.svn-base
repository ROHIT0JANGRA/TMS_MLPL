//  
// Type: CodeLock.Models.MasterCompany
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterCompany : BaseModel
  {
    public new byte CompanyId { get; set; }

    [Display(Name = "Company Code")]
    public string CompanyCode { get; set; }

    [Remote("IsCompanyNameAvailable", "Company", AdditionalFields = "CompanyId,_CompanyIdToken", ErrorMessage = "Company Name already exists.", HttpMethod = "POST")]
    [StringLength(50, ErrorMessage = "Company Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Company Name")]
    [Display(Name = "Company Name")]
    public string CompanyName { get; set; }

    [Display(Name = "Company Address")]
    [Required(ErrorMessage = "Please enter Company Address")]
    [StringLength(300, ErrorMessage = "Company Address must be minimum 2 and maximum 300 character long", MinimumLength = 2)]
    public string CompanyAddress { get; set; }

    [Required(ErrorMessage = "Please select Start Date")]
    [DataType(DataType.DateTime)]
    [Display(Name = "Company Start Date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Please enter Contact Person")]
    [Display(Name = "Contact Person")]
    [StringLength(100, ErrorMessage = "Contact Person must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    public string ContactPerson { get; set; }

    [Required(ErrorMessage = "Please enter Mobile No")]
    [Display(Name = "Mobile No")]
    [MobileAnnotation]
    public string MobileNo { get; set; }

    [GstInNoAnnotation]
    [Display(Name = "GST TIN No")]
    public string GstTinNo { get; set; }

    [Display(Name = "PAN No")]
    [PanNoAnnotation]
    public string PANNo { get; set; }

    [StringLength(15, ErrorMessage = "TAN No. must be minimum 2 and maximum 15 character long", MinimumLength = 2)]
    [Display(Name = "TAN No")]
    public string TANNo { get; set; }

    [StringLength(25, ErrorMessage = "Registration No. must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "Registration No")]
    public string RegistrationNo { get; set; }

    [Display(Name = "Punch Line")]
    [StringLength(100, ErrorMessage = "Punch Line must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    public string PunchLine { get; set; }
  }
}
