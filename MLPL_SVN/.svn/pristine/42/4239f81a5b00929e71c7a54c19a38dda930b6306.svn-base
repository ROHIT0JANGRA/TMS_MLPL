using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CreditNoteDetails
  {
    public long BillId { get; set; }

    [Display(Name = "Bill No")]
    public string BillNo { get; set; }

    public Decimal BillAmount { get; set; }

    [Display(Name = "Credit Note Purpose")]
    [Required(ErrorMessage = "Please select CreditNote purpose")]
    public byte CreditNotePurposeId { get; set; }

    public string CreditNotePurpose { get; set; }

    [Display(Name = "Credit Note Amount")]
    [Required(ErrorMessage = "Please enter CreditNote Amount")]
    public Decimal CreditNoteAmount { get; set; }

    [Display(Name = "Remarks")]
    public string Remarks { get; set; }
  }
}
