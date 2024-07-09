using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CrossLocationVoucherDetail
  {
    public short AccountId { get; set; }

    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }

    [AssertThat("0 < Amount", ErrorMessage = "Amount is greater than zero")]
    public Decimal Amount { get; set; }

    public string Narration { get; set; }
  }
}
