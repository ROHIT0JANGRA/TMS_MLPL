//  
// Type: CodeLock.Models.MasterVehicleDocumentType
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class MasterVehicleDocumentType : BaseModel
  {
    public short VehicleDocumentId { get; set; }

    [Display(Name = "Document")]
    [Required(ErrorMessage = "Please select Document")]
    public byte DocumentId { get; set; }

    public string Document { get; set; }

    [StringLength(50, ErrorMessage = "Document Description must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = " Document Description")]
    public string DocumentDescription { get; set; }

    [Display(Name = "Is State Wise Applicable")]
    public bool IsStateWiseApplicable { get; set; }

    [Required(ErrorMessage = "Please select Renewal Authority")]
    [Display(Name = "Renewal Authority")]
    public byte RenewalAuthorityId { get; set; }

    public string RenewalAuthorityName { get; set; }

    public short VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Vehicle No")]
    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    [Display(Name = "Document No")]
    [Required(ErrorMessage = "Please enter Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "Notes")]
    [Required(ErrorMessage = "Please enter Notes")]
    public string Notes { get; set; }

    [Display(Name = "Auto Mail Required")]
    public bool IsAutoMailRequired { get; set; }

    [Display(Name = "Cost")]
    [Required(ErrorMessage = "Please enter Cost")]
    public Decimal Cost { get; set; }

    [Required(ErrorMessage = "Please enter Auto Mail (To ID)")]
    [Display(Name = "Auto Mail (To ID)")]
    public string AutoMailToID { get; set; }

    [Display(Name = "Auto Mail (CC ID)")]
    public string AutoMailCcID { get; set; }

    [Display(Name = "Auto Mail (BCC ID)")]
    public string AutoMailBccID { get; set; }

    [Display(Name = "Document Issue Date")]
    public DateTime DocumentIssueDate { get; set; }

    [Display(Name = "Document Expiry Date")]
    public DateTime DocumentExpiryDate { get; set; }

    [Display(Name = "Upload Scanned Document")]
    public HttpPostedFileBase DocumentAttachment { get; set; }

    [Display(Name = "Upload Scanned Document")]
    public string UploadedDocumentName { get; set; }

    [Display(Name = "Reminder (in days)")]
    public short ReminderDays { get; set; }

    public short StateId { get; set; }

    [Display(Name = "State")]
    [Required(ErrorMessage = "Please enter State")]
    public string StateName { get; set; }

    [Display(Name = "Contents")]
    public string Contents { get; set; }
  }
}
