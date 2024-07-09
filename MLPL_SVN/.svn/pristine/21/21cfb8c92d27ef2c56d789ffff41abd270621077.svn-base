//  
// Type: CodeLock.Models.ExpenseContract
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ExpenseContract : BaseModel
  {
    public short ExpenseId { get; set; }

    [Required(ErrorMessage = "Please select Expense Name")]
    [Display(Name = "Expense Name")]
    public string ExpenseName { get; set; }

    [Required(ErrorMessage = "Please select PayBas Id")]
    [Display(Name = "PayBas")]
    public byte PayBasId { get; set; }

    public string PayBas { get; set; }

    [Display(Name = "Transport Mode")]
    [Required(ErrorMessage = "Please select Transport Mode")]
    public byte TransportModeId { get; set; }

    [Required(ErrorMessage = "Please select Matrix Type")]
    [Display(Name = "Matrix Type")]
    public byte MatrixType { get; set; }

    public short FromLocationId { get; set; }

    [Display(Name = "From ")]
    [Required(ErrorMessage = "Please select From Location")]
    public string FromLocation { get; set; }

    public short ToLocationId { get; set; }

    [Display(Name = "To ")]
    [Required(ErrorMessage = "Please select To Location")]
    public string ToLocation { get; set; }

    [Display(Name = "Rate Type ")]
    [Required(ErrorMessage = "Please Enter Rate Type")]
    public byte RateTypeId { get; set; }

    [Display(Name = "Rate ")]
    [Required(ErrorMessage = "Please Enter Rate")]
    public Decimal Rate { get; set; }

    public List<ExpenseContract> Details { get; set; }
  }
}
