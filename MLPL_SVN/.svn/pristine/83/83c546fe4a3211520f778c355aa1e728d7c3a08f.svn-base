//  
// Type: CodeLock.Models.PoGrn
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PoGrn
  {
    public long GrnId { get; set; }

    [Display(Name = "Material Category")]
    public byte MaterialCategoryId { get; set; }

    public string MaterialCategory { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "Vendor")]
    public short VendorId { get; set; }

    public string VendorCode { get; set; }

    public long PoId { get; set; }

    [Display(Name = "PO No")]
    public string PoNo { get; set; }

    [Display(Name = "Manual PO No")]
    public string ManualPoNo { get; set; }

    [Display(Name = "GRN No")]
    public string GrnNo { get; set; }

    [Required(ErrorMessage = "Please enter GRN Date")]
    [Display(Name = "GRN Date")]
    public DateTime GrnDate { get; set; }

    [Display(Name = "PO Date")]
    public string PoDate { get; set; }

    [Display(Name = "Manual GRN No")]
    [Required(ErrorMessage = "Please enter Manual GRN No")]
    [StringLength(30, ErrorMessage = "Manual GRN No must be minimum 2 and maximum 30 character long", MinimumLength = 2)]
    public string ManualGrnNo { get; set; }

    [Required(ErrorMessage = "Please enter Remarks")]
    [StringLength(200, ErrorMessage = "Remarks must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Display(Name = "Remarks")]
    public string Remarks { get; set; }

    public Decimal Amount { get; set; }

    public short ReceivedBy { get; set; }

    public List<GrnGenerateDetail> Details { get; set; }
  }
}
