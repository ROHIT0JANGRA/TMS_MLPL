//  
// Type: CodeLock.Models.MultipleVoucherDetail
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MultipleVoucherDetail
  {
    public bool Perticular { get; set; }

    public short AccountId { get; set; }

    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }

    [Required(ErrorMessage = "Please select Cost Center Type")]
    public byte CostCenterType { get; set; }

    public short CostCenterId { get; set; }

    [Required(ErrorMessage = "Please enter Cost Center")]
    public string CostCenter { get; set; }

    public short PartyCodeId { get; set; }

    [Required(ErrorMessage = "Please enter Party Code")]
    public string PartyCode { get; set; }

    public Decimal Debit { get; set; }

    public Decimal Credit { get; set; }

    public string Narration { get; set; }
  }
}
