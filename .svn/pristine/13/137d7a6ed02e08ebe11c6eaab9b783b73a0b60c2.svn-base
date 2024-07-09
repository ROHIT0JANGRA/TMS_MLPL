//  
// Type: CodeLock.Models.PurchaseOrderApprove
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PurchaseOrderApprove
  {
    [Display(Name = "PO No")]
    public string PoNo { get; set; }

    [Display(Name = "Approval Date")]
    [Required(ErrorMessage = "Please enter Approval Date")]
    public DateTime ApproveDate { get; set; }

    [Display(Name = "Vendor")]
    public short VendorId { get; set; }

    public string VendorCode { get; set; }

    [Display(Name = "Vendor Name")]
    public string VendorName { get; set; }

    [Display(Name = "Manual PO No")]
    public string ManualPoNo { get; set; }

    public List<PurchaseOrderApproveDetail> Details { get; set; }
  }
}
