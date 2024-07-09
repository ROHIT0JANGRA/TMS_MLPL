using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class AdviceAcknowledgementDetail
  {
    public bool IsChecked { get; set; }

    public long AdviceId { get; set; }

    [Required(ErrorMessage = "Please select Account")]
    public short ToAccountId { get; set; }

    [Required(ErrorMessage = "Please select Deposite Date")]
    public DateTime AcknowledgementDate { get; set; }

    public short AcknowledgementBy { get; set; }

    public string FinYear { get; set; }
  }
}
