//  
// Type: CodeLock.Models.MasterCard
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class MasterCard : BaseModel
  {
    public MasterCard()
    {
      this.VendorId = new short?((short) 0);
    }

    [Display(Name = "Card Type")]
    public string CardType { get; set; }

    [Required(ErrorMessage = "Card Type can't be blank")]
    [Display(Name = "Card Type")]
    public string CardTypeId { get; set; }
    public short CardId { get; set; }

    //[Remote("IsCardNoAvailable", "Card", AdditionalFields = "CardId,_CardIdToken", ErrorMessage = "Card No already exists.", HttpMethod = "POST")]
    [Required(ErrorMessage = "Please enter Card No")]
    [Display(Name = "Card No")]
    [StringLength(25, ErrorMessage = "Card No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string CardNo { get; set; }

    [Display(Name = "Vendor Code")]
    public short? VendorId { get; set; }

    [RequiredIf("IsFuelCard == 2", ErrorMessage = "Please enter Vendor Code")]
    public string VendorCode { get; set; }

    public string VendorName { get; set; }

    [Display(Name = "Issue Date")]
    public DateTime? IssueDate { get; set; }

    [Display(Name = "Expiry Date")]
    public DateTime? ExpiryDate { get; set; }

    [Required(ErrorMessage = "Please select Vehicle")]
    [Display(Name = "Vehicle")]
    public string Vehicle { get; set; }

    [Display(Name = "Deposit Date")]
    public DateTime? DepositDate { get; set; }

    public string SavedVehicle { get; set; }

    [Required(ErrorMessage = "Please select FO Ledger")]
    [Display(Name = "FO Ledger")]
    public short AccountId { get; set; }

    public string AccountCode { get; set; }

    [Display(Name = "Card Type")]
    public int IsFuelCard { get; set; }

    public bool IsVehicle { get; set; }

    [Required(ErrorMessage = "Please enter Card Limit")]
    [Display(Name = "Card Limit")]
    [Range(0.001, 10000000.0, ErrorMessage = "Please enter Card Limit")]
    public Decimal CardLimit { get; set; }

    [Display(Name = "Balance Amount")]
    public Decimal BalanceAmount { get; set; }

    [Display(Name = "Deposit Amount")]
    [Required(ErrorMessage = "Please enter Deposit Amount")]
    [Range(0.001, 10000000.0, ErrorMessage = "Please enter Deposit Amount")]
    public Decimal DepositAmount { get; set; }

    [Display(Name = "Payment Mode")]
    [Required(ErrorMessage = "Please select Payment Mode")]
    public byte PaymentMode { get; set; }

    public string FinYear { get; set; }

    public short LocationId { get; set; }
  }
}
