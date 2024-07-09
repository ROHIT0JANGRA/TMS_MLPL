using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ContraVoucherDetail
  {
    [Required(ErrorMessage = "Please select Payment Mode")]
    public byte PaymentMode { get; set; }

    [Required(ErrorMessage = "Please enter Account")]
    public short AccountId { get; set; }

    public Decimal Debit { get; set; }

    public Decimal Credit { get; set; }

    public string ChequeRefNo { get; set; }

    public DateTime ChequeRefDate { get; set; }
  }
}
