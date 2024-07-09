
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Cheque : BaseModel
  {
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public string FinYear { get; set; }

    public byte ChequeStatus { get; set; }

    public bool ChequeType { get; set; }

    public long ChequeId { get; set; }

    [Display(Name = "Cheque No")]
    [Required(ErrorMessage = "Please enter Cheque No")]
    public string ChequeNo { get; set; }

    [Display(Name = "Cheque Date")]
    public DateTime ChequeDate { get; set; }

    [Display(Name = "Cheque Amount")]
    public Decimal ChequeAmount { get; set; }

    [Display(Name = "Collection Amount")]
    public Decimal CollectionAmount { get; set; }

    [Display(Name = "Balance Amount")]
    public Decimal? BalanceAmount { get; set; }

    [Required(ErrorMessage = "Please select Bank")]
    [Display(Name = "Bank")]
    public short BankAccountId { get; set; }

    [Display(Name = "On Account")]
    public bool IsOnAccount { get; set; }

    [Display(Name = "Bank Name")]
    public string BankName { get; set; }

    [Display(Name = "Branch Name")]
    public string BranchName { get; set; }

    [Display(Name = "Party Code")]
    public string PartyCode { get; set; }

    [Display(Name = "Party Name")]
    public string PartyName { get; set; }

    public string Narration { get; set; }

    public bool IsDeposited { get; set; }

    public short? DepositBy { get; set; }

    public DateTime? DepositDate { get; set; }

    public long? DepositVoucherId { get; set; }

    public string DepositVoucherNo { get; set; }
  }
}
