using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class CustomerContractBasicInfo : BaseModel
  {
    public short ContractId { get; set; }

    public string LocationCode { get; set; }

    [Display(Name = "Contract Id")]
    public string ManualContractId { get; set; }

    [Display(Name = "Contract Date")]
    [Required(ErrorMessage = "Please select Contract Date")]
    [DataType(DataType.DateTime)]
    public DateTime ContractDate { get; set; }

    [Display(Name = "Location Code")]
    [Required(ErrorMessage = "Please select Location Code")]
    public short LocationId { get; set; }

    public HttpPostedFileBase Attachment { get; set; }

    [Display(Name = "Scan Copy")]
    public string DocumentName { get; set; }

    [Required(ErrorMessage = "Please select Party Category")]
    [Display(Name = "Party Category")]
    public byte PartyCategory { get; set; }

    [Display(Name = "Party Category")]
    public string Category { get; set; }

    [Display(Name = "Contract Category")]
    [Required(ErrorMessage = "Please select Contract Category")]
    public byte ContractCategory { get; set; }

    [Display(Name = "Contract Category")]
    public string CategoryForContract { get; set; }

    [StringLength(100, ErrorMessage = "Account Person Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Display(Name = "Account Person Name")]
    [Required(ErrorMessage = "Please enter Account Person Name")]
    public string AccountPersonName { get; set; }

    [Display(Name = "Account Person Mobile No")]
    [MobileAnnotation]
    [Required(ErrorMessage = "Please enter Account Person Mobile No")]
    public string AccountPersonMobileNo { get; set; }

    [Display(Name = "Account Person Email Id")]
    [EmailAnnotation]
    [Required(ErrorMessage = "Please enter Account Person Email Id")]
    public string AccountPersonEmailId { get; set; }

    [Display(Name = "CSE Name")]
    [Required(ErrorMessage = "Please enter CSE Name")]
    [StringLength(100, ErrorMessage = "CSE Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    public string CseName { get; set; }

    [Required(ErrorMessage = "Please enter CSE Mobile No")]
    [Display(Name = "CSE Mobile No")]
    [MobileAnnotation]
    public string CseMobileNo { get; set; }

    [EmailAnnotation]
    [Required(ErrorMessage = "Please enter CSE Email Id")]
    [Display(Name = "CSE Email Id")]
    public string CseEmailId { get; set; }

    [StringLength(100, ErrorMessage = "Account Representative Name must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
    [Display(Name = "Account Representative Name")]
    [Required(ErrorMessage = "Please enter Account Representative Name")]
    public string AccountRepresentativeName { get; set; }

    [Display(Name = "Remarks")]
    [StringLength(250, ErrorMessage = "Remarks must be maximum 250 character long")]
    public string Remarks { get; set; }
  }
}
