using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class BillAccountDetails
  {
    public BillAccountDetails()
    {
      this.ServiceTaxApplicable = false;
      this.TdsApplicable = false;
      this.AccountId = (short) 0;
      this.AccountCode = string.Empty;
      this.AccountDescription = string.Empty;
      this.DocumentTypeId = (byte) 0;
      this.DocumentId = 0L;
      this.DocumentTypeCode = string.Empty;
      this.Amount = new Decimal(0);
      this.Narration = string.Empty;
    }

    [Display(Name = "Service Tax Applicable")]
    public bool ServiceTaxApplicable { get; set; }

    [Display(Name = "Tds Applicable")]
    public bool TdsApplicable { get; set; }

    [Display(Name = "Account Id")]
    public short AccountId { get; set; }

    [Required(ErrorMessage = "Please enter Account Code")]
    [Display(Name = "Account Code")]
    public string AccountCode { get; set; }

    [Display(Name = "Account Description")]
    public string AccountDescription { get; set; }

    [Display(Name = "Document Type")]
    public byte DocumentTypeId { get; set; }

    public long DocumentId { get; set; }

    [Display(Name = "Document Code")]
    public string DocumentCode { get; set; }

    [Display(Name = "Document Type")]
    public string DocumentTypeCode { get; set; }

    [Required(ErrorMessage = "Please enter Amount")]
    [Range(0.001, 10000000.0, ErrorMessage = "Please enter Amount greater than zero")]
    [Display(Name = "Amount")]
    public Decimal Amount { get; set; }

    [Required(ErrorMessage = "Please enter Narration")]
    [Display(Name = "Narration")]
    public string Narration { get; set; }
  }
}
