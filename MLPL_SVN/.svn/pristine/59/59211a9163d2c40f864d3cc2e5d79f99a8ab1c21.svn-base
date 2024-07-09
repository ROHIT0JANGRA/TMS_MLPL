
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class BankReconcilation : BaseModel
  {
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public string FinYear { get; set; }

    [Required(ErrorMessage = "Please select Bank")]
    [Display(Name = "Bank")]
    public short BankAccountId { get; set; }

    [Display(Name = "Bank Name")]
    public string BankName { get; set; }

    [Display(Name = "From Date")]
    public DateTime FromDate { get; set; }

    [Display(Name = "To Date")]
    public DateTime ToDate { get; set; }

    public string ReconcileStatus { get; set; }

    public string AmountConsederation { get; set; }

    public List<BankReconcilationChequeDetails> ChequeDetails { get; set; }
  }
}
