using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractChargeMatrixLTL
  {
    [Required(ErrorMessage = "Please select From")]
    [Display(Name = "From")]
    public short FromLocation { get; set; }

    [Required(ErrorMessage = "Please select To")]
    [Display(Name = "To")]
    public short ToLocation { get; set; }

    public Decimal Rate { get; set; }

    [Required(ErrorMessage = "Please select Rate Type")]
    [Display(Name = "Rate Type")]
    public byte RateType { get; set; }

    public byte TransitDays { get; set; }

    public short? BillLocationId { get; set; }
  }
}
