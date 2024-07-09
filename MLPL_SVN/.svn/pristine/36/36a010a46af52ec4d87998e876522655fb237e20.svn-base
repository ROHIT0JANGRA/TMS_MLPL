using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractRateMatrixSlabRange
  {
    public CustomerContractRateMatrixSlabRange()
    {
      this.ContractId = (short) 0;
      this.SlabId = (byte) 0;
      this.From = new Decimal(0);
      this.To = new Decimal(0);
      this.RateType = (byte) 0;
    }

    public short ContractId { get; set; }

    public byte SlabId { get; set; }

    public byte ChargeCode { get; set; }

    [Display(Name = "From")]
    [Range(0, 999999999, ErrorMessage = "Please enter From greater than zero")]
    [Required(ErrorMessage = "Please enter From")]
    public Decimal From { get; set; }

    [Display(Name = "To")]
    [Required(ErrorMessage = "Please enter To")]
    [Range(0, 999999999, ErrorMessage = "Please enter To greater than zero")]
    public Decimal To { get; set; }

    [Display(Name = "Rate Type")]
    public byte RateType { get; set; }
  }
}
