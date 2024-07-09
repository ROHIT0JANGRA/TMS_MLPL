//  
// Type: CodeLock.Models.IssueSlip
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class IssueSlip
  {
    public long IssueSlipId { get; set; }

    [Display(Name = "Issue Slip No")]
    public string IssueSlipNo { get; set; }

    [Display(Name = "Material Category")]
    [Required(ErrorMessage = "Please select Material Category")]
    public byte MaterialCategoryId { get; set; }

    [Display(Name = "Vehicle No")]
    public short VehicleId { get; set; }

    public string VehicleNo { get; set; }

    [Display(Name = "Job Sheet No")]
    public long JobOrderId { get; set; }

    public string JobOrderNo { get; set; }

    [Display(Name = "Issue Date")]
    public DateTime IssueDate { get; set; }

    [Display(Name = "Issue Location")]
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    [Display(Name = "Requisition No")]
    public long SpareRequestId { get; set; }

    public string SpareRequestNo { get; set; }

    [Display(Name = "Requisition Date")]
    public DateTime SpareRequestDate { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "CFR MR No")]
    public string CfrMrNo { get; set; }

    [Display(Name = "Remarks")]
    [Required(ErrorMessage = "Please enter Remarks")]
    [StringLength(200, ErrorMessage = "Remarks must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    public string Remarks { get; set; }

    public List<IssueSlipDetail> Details { get; set; }
  }
}
