using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class BaBillEntry : BaseModel
  {
    public BaBillEntry()
    {
      this.ChargeList = new List<VendorBillCharge>();
      this.TaxList = new List<MasterTax>();
    }

    public short VendorId { get; set; }

    [Required(ErrorMessage = "Please enter Vendor")]
    [Display(Name = "Vendor")]
    public string VendorCode { get; set; }

    [Display(Name = "From Date")]
    public DateTime FromDate { get; set; }

    [Display(Name = "To Date")]
    public DateTime ToDate { get; set; }

    [Display(Name = "System Document No")]
    public string DocumentNo { get; set; }

    [Required(ErrorMessage = "Please select Vendor Service")]
    [Display(Name = "Vendor Service")]
    public byte VendorServiceId { get; set; }

    public bool IsBooking { get; set; }

    [Display(Name = "Document Type")]
    public MasterGeneral[] DocumentType { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
    [Required(ErrorMessage = "Please select Bill Date and Time")]
    [DataType(DataType.DateTime)]
    [Display(Name = "Bill Date")]
    public DateTime BillDateTime { get; set; }

    [Display(Name = "Bill Due Date")]
    public DateTime? BillDueDate { get; set; }

    [Display(Name = "Manual Bill No")]
    public string ManualBillNo { get; set; }

    [Display(Name = "Bill Amount")]
    public Decimal BillAmount { get; set; }

    [Display(Name = "Remarks")]
    public string Remarks { get; set; }

    [Display(Name = "Other Deduction")]
    public Decimal OtherDeduction { get; set; }

    [Display(Name = "Discount Received")]
    public Decimal DiscountReceived { get; set; }

    [Display(Name = "Net Payable Amount")]
    public Decimal NetPayableAmount { get; set; }

    [Display(Name = "Document Type")]
    public string SelectedDocumentType { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public string VendorChargeList { get; set; }

    public byte BillType { get; set; }

    public bool IsFinalize { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal TaxTotal { get; set; }

    public byte TdsGroupId { get; set; }

    public short TdsAccountId { get; set; }

    public Decimal TdsRate { get; set; }

    public Decimal TdsAmount { get; set; }

    [PanNoAnnotation]
    public string PanNo { get; set; }

    public string ServiceTaxNo { get; set; }

    public Decimal GrandTotal { get; set; }

    public List<VendorBillCharge> ChargeList { get; set; }

    public List<MasterTax> TaxList { get; set; }

    public List<BaBillDetail> Details { get; set; }
  }
}
