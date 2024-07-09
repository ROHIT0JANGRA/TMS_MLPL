using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractRiskMatrix
  {
    public short ContractId { get; set; }

    [Display(Name = "From")]
    public Decimal FromFreight { get; set; }

    [Display(Name = "To")]
    [Range(0.0, 9999999999.99, ErrorMessage = "Please enter To")]
    public Decimal ToFreight { get; set; }

    [Display(Name = "Rate")]
    [Range(0.0, 9999999999.99, ErrorMessage = "Please enter Rate")]
    public Decimal Rate { get; set; }

    [Display(Name = "Rate Type")]
    public byte RateType { get; set; }

    public bool IsCarrierRisk { get; set; }

    [Display(Name = "Minimum Freight Amount")]
    public Decimal MinimumChargeAmount { get; set; }

    [Display(Name = "Maximum Freight Amount")]
    public Decimal MaximumChargeAmount { get; set; }
  }
}
