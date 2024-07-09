//  
// Type: CodeLock.Models.PurchaseOrder
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PurchaseOrder : BaseModel
  {
    public long PoId { get; set; }

    public string PoNo { get; set; }

    public short LocationId { get; set; }

    [Required(ErrorMessage = "Please select Material Category")]
    [Display(Name = "Material Category")]
    public byte MaterialCategoryId { get; set; }

    public string MaterialCategory { get; set; }

    [Required(ErrorMessage = "Please enter PO Date")]
    [Display(Name = "PO Date")]
    public DateTime PoDate { get; set; }

    public short VendorId { get; set; }

    [Display(Name = "Vendor")]
    [Required(ErrorMessage = "Please enter Vendor")]
    public string VendorCode { get; set; }

    public string VendorName { get; set; }

    [StringLength(30, ErrorMessage = "Manual PO No must be minimum 2 and maximum 30 character long", MinimumLength = 2)]
    [Display(Name = "Manual PO No")]
    [Required(ErrorMessage = "Please enter Manual PO No")]
    public string ManualPoNo { get; set; }

    [Required(ErrorMessage = "Please enter Remarks")]
    [StringLength(200, ErrorMessage = "Remarks must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Remarks")]
    public string Remarks { get; set; }

    public Decimal Amount { get; set; }

    [Display(Name = "Advance Amount")]
    public Decimal AdvanceAmount { get; set; }

    [Display(Name = "Balance Amount")]
    public Decimal BalanceAmount { get; set; }

    public Decimal? TotalQuantity { get; set; }

    public List<PurchaseOrderDetail> Details { get; set; }
  }
}
