
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class BillAccountDetail
  {
    public BillAccountDetail()
    {
      this.GstExempted = false;
      this.TdsExempted = false;
      this.AccountId = (short) 0;
      this.AccountCode = string.Empty;
      this.AccountDescription = string.Empty;
      this.CostCenterTypeId = (byte) 0;
      this.CostCenterId = 0L;
      this.CostCenterCode = string.Empty;
      this.Amount = new Decimal(0);
      this.Narration = string.Empty;
      this.SacId = (byte) 0;
    }

    [Display(Name = "Service Tax Exempted")]
    public bool GstExempted { get; set; }

    [Display(Name = "Tds Exempted")]
    public bool TdsExempted { get; set; }

    [Display(Name = "Goods/Product")]
    public bool IsGoodsProduct { get; set; }

    [Display(Name = "Account Id")]
    public short AccountId { get; set; }

    [Display(Name = "Account Code")]
    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }

    [Display(Name = "Account Description")]
    public string AccountDescription { get; set; }

    [Display(Name = "Cost Center Type")]
    [Required(ErrorMessage = "Please Select Cost Center Type")]
    public byte CostCenterTypeId { get; set; }

    [Display(Name = "Cost Center Code")]
    public long CostCenterId { get; set; }

    [Display(Name = "Cost Center Name")]
    public long CostCenterName { get; set; }

    [Display(Name = "SAC/HSN")]
    [Required(ErrorMessage = "Please select SAC")]
    public byte SacId { get; set; }

    [Display(Name = "Units")]
    public int Units { get; set; }

    [Required(ErrorMessage = "Please enter Cost Center")]
    [Display(Name = "Cost Center")]
    public string CostCenterCode { get; set; }

    [Required(ErrorMessage = "Please enter Amount")]
    [Display(Name = "Amount")]
    public Decimal Amount { get; set; }

    [Display(Name = "Narration")]
    public string Narration { get; set; }

    [Display(Name = "RCM")]
    public string Rcm { get; set; }

    public bool IsRcm { get; set; }

    [Display(Name = "GST Rate")]
    public Decimal GstRate { get; set; }

    [Display(Name = "GST Amount")]
    public Decimal GstAmount { get; set; }

    [Display(Name = "Total Amount")]
    public Decimal TotalAmount { get; set; }
  }
}
