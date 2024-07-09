//  
// Type: CodeLock.Models.Grn
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Grn : BaseModel
  {
    public Grn()
    {
      this.GrnNo = "";
      this.Details = new List<GrnDetail>();
    }

    public long GrnId { get; set; }

    [Display(Name = "GRN No")]
    public string GrnNo { get; set; }

    public DateTime GrnDate { get; set; }

    public TimeSpan GrnTime { get; set; }

    [Display(Name = "GRN Date Time")]
    public DateTime? GrnDateTime { get; set; }

    public long? AsnId { get; set; }

    [Display(Name = "ASN No")]
    public string AsnNo { get; set; }

    [Display(Name = "Supplier")]
    [Required(ErrorMessage = "Please select Supplier")]
    public string SupplierCode { get; set; }

    public short SupplierId { get; set; }

    public string SupplierName { get; set; }

    public byte SupplierType { get; set; }

    [Required(ErrorMessage = "Please enter PO No")]
    [Display(Name = "PO No")]
    public string PoNo { get; set; }

    [Display(Name = "PO Date")]
    [Required(ErrorMessage = "Please select PO Date")]
    public DateTime PoDate { get; set; }

    [Required(ErrorMessage = "Please select Invoice No")]
    [Display(Name = "Invoice No")]
    public string InvoiceNo { get; set; }

    [Display(Name = "Invoice Date")]
    [Required(ErrorMessage = "Please select Invoice Date")]
    public DateTime? InvoiceDate { get; set; }

    [Display(Name = "Gate Pass In Number")]
    [Required(ErrorMessage = "Please select Gate Pass In Number")]
    public long GatepassInId { get; set; }

    [Required(ErrorMessage = "Please select Grn Type")]
    [Display(Name = "Grn Type")]
    public short GrnTypeId { get; set; }

    [Display(Name = "Dock Number")]
    public string DockNumber { get; set; }

    [Display(Name = "Load No")]
    public string LoadNo { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public Decimal? TotalQuantity { get; set; }

    public Decimal? HoldQuantity { get; set; }

    public bool IsChecked { get; set; }

    [Required(ErrorMessage = "Please select atleast one record")]
    public List<GrnDetail> Details { get; set; }
  }
}
