//  
// Type: CodeLock.Models.JournalVoucherDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class JournalVoucherDetail
  {
    public short AccountId { get; set; }

    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }

    public string AccountDescription { get; set; }

    [Required(ErrorMessage = "Please select Cost Center Type")]
    public byte CostCenterType { get; set; }

    public short CostCenterId { get; set; }

    [Required(ErrorMessage = "Please enter Cost Center")]
    public string CostCenter { get; set; }

    public Decimal Debit { get; set; }

    public Decimal Credit { get; set; }

    public string Narration { get; set; }
  }
}
