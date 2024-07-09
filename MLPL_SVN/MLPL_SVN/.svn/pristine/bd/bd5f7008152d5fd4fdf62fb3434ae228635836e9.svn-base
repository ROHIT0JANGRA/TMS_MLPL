//  
// Type: CodeLock.Models.SupplementryBill
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class SupplementryBill : BaseModel
  {
    public SupplementryBill()
    {
      this.BillAccountDetails = new List<CodeLock.Models.BillAccountDetails>();
    }

    public long BillId { get; set; }

    public string BillNo { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    [Required(ErrorMessage = "Please Select Paybas")]
    [Display(Name = "Paybas")]
    public byte PaybasId { get; set; }

    public string Paybas { get; set; }

    public short CustomerId { get; set; }

    [Display(Name = "Customer")]
    [Required(ErrorMessage = "Please enter Customer")]
    public string CustomerCode { get; set; }

    [Display(Name = "Manual Bill No")]
    public string ManualBillNo { get; set; }

    [Display(Name = "Bill Date")]
    public DateTime BillDate { get; set; }

    [Display(Name = "Due Date")]
    public DateTime DueDate { get; set; }

    [Display(Name = "Company List")]
    public new byte CompanyId { get; set; }

    [Display(Name = "Submission Location")]
    public short SubmissionLocationId { get; set; }

    public bool MultipleCNoteNo { get; set; }

    [Display(Name = "Collection Location")]
    public short CollectionLocationId { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "Document Type")]
    public byte DocumentTypeId { get; set; }

    public long DocumentId { get; set; }

    [Display(Name = "Document Type")]
    public string DocumentTypeCode { get; set; }

    public Decimal ServiceTaxApplicableAmount { get; set; }

    public bool EnableServiceTax { get; set; }

    public bool RoundOffServiceTax { get; set; }

    public Decimal TaxTotal { get; set; }

    public Decimal BillAmount { get; set; }

    public List<MasterTax> TaxList { get; set; }

    public List<CodeLock.Models.BillAccountDetails> BillAccountDetails { get; set; }
  }
}
