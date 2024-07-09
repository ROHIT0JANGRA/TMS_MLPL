//  
// Type: CodeLock.Models.MasterAccountOpeningParty
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterAccountOpeningParty : BaseModel
  {
    public string FinYear { get; set; }

    [Required(ErrorMessage = "Please select Party Type")]
    [Display(Name = "Party Type")]
    public byte PartyType { get; set; }

    [Display(Name = "Vendor Type")]
    [Required(ErrorMessage = "Please select Vendor Type")]
    public byte VendorTypeId { get; set; }

    [Display(Name = "Customer")]
    public short PartyId { get; set; }

    [Required(ErrorMessage = "Please enter Customer")]
    public string PartyCode { get; set; }

    [Required(ErrorMessage = "Please select Location")]
    [Display(Name = "Location")]
    public short LocationId { get; set; }

    [Required(ErrorMessage = "Please select Account")]
    [Display(Name = "Account")]
    public short AccountId { get; set; }

    [Required(ErrorMessage = "Please enter Debit Amount")]
    [Display(Name = "Debit Amount")]
    public Decimal DebitAmount { get; set; }

    [Display(Name = "Credit Amount")]
    [Required(ErrorMessage = "Please enter Credit Amount")]
    public Decimal CreditAmount { get; set; }
  }
}
