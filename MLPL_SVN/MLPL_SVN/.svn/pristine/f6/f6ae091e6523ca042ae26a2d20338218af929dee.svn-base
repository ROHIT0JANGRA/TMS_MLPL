
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Asn : BaseModel
  {
    public Asn()
    {
      this.AsnNo = "";
      this.Details = new List<AsnDetail>();
    }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime FinStartDate { get; set; }

    public DateTime FinEndDate { get; set; }

    public long AsnId { get; set; }

    [Display(Name = "ASN No")]
    public string AsnNo { get; set; }

    public DateTime AsnDate { get; set; }

    public TimeSpan AsnTime { get; set; }

    [Display(Name = "ASN Date Time")]
    public DateTime? AsnDateTime { get; set; }

    [Display(Name = "Supplier")]
    public string SupplierCode { get; set; }

    public short SupplierId { get; set; }

    public string SupplierName { get; set; }

    [Display(Name = "Supplier Type")]
    public byte SupplierType { get; set; }

    public string SupplierTypeName { get; set; }

    [Display(Name = "PO No")]
    public string PoNo { get; set; }

    [Display(Name = "PO Date")]
    public DateTime? PoDate { get; set; }

    [Display(Name = "Invoice No")]
    [Required(ErrorMessage = "Please select Invoice No")]
    public string InvoiceNo { get; set; }

    [Required(ErrorMessage = "Please select Invoice Date")]
    [Display(Name = "Invoice Date")]
    public DateTime InvoiceDate { get; set; }

    [Required(ErrorMessage = "Please select atleast one record")]
    public List<AsnDetail> Details { get; set; }

    public List<CodeLock.Models.WarehouseStock> WarehouseStock { get; set; }
  }
}
