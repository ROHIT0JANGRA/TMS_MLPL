
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CreditDebitVoucherDetail
  {
    public CreditDebitVoucherDetail()
    {
      this.GstExempted = false;
      this.TdsExempted = false;
      this.IsProduct = false;
      this.AccountId = (short) 0;
      this.AccountCode = string.Empty;
      this.AccountDescription = string.Empty;
      this.SacId = (byte) 0;
      this.Units = 0;
      this.Narration = string.Empty;
      this.Amount = new Decimal(0);
      this.Rcm = string.Empty;
      this.IsRcm = false;
      this.GstRate = new Decimal(0);
      this.GstAmount = new Decimal(0);
      this.GstCharged = new Decimal(0);
      this.TotalAmount = new Decimal(0);
    }

    [Display(Name = "GST Exempted")]
    public bool GstExempted { get; set; }

    [Display(Name = "TDS Exempted")]
    public bool TdsExempted { get; set; }

    [Display(Name = "Goods/Product\t")]
    public bool IsProduct { get; set; }

    public short AccountId { get; set; }

    [Required(ErrorMessage = "Please enter Account Code")]
    [Display(Name = "Account Code")]
    public string AccountCode { get; set; }

    [Display(Name = "Account Description")]
    public string AccountDescription { get; set; }

    [Display(Name = "Cost Center Type")]
    [Required(ErrorMessage = "Please select Cost Center Type")]
    public byte CostCenterType { get; set; }

    [Display(Name = "Cost Center")]
    public short CostCenterId { get; set; }

    [Required(ErrorMessage = "Please enter Cost Center")]
    public string CostCenter { get; set; }

    [Display(Name = "SAC/HSN")]
    [Required(ErrorMessage = "Please select SAC")]
    public byte SacId { get; set; }

    [Display(Name = "Units")]
    public int Units { get; set; }

    [Display(Name = "Narration")]
    [Required(ErrorMessage = "Please enter Narration")]
    [StringLength(200, ErrorMessage = "Narration must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    public string Narration { get; set; }

    [Range(0.001, 10000000000.00, ErrorMessage = "Please enter Amount")]
    [Display(Name = "Amount")]
    [Required(ErrorMessage = "Please enter Amount")]
    public Decimal Amount { get; set; }

    [Display(Name = "RCM")]
    public string Rcm { get; set; }

    public bool IsRcm { get; set; }

    [Display(Name = "GST Rate")]
    public Decimal GstRate { get; set; }

    [Display(Name = "GST Amount")]
    public Decimal GstAmount { get; set; }

    [Display(Name = "GST Charged")]
    public Decimal GstCharged { get; set; }

    [Display(Name = "Total Amount")]
    public Decimal TotalAmount { get; set; }
  }
}
