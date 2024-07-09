
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class CreditDebitVoucher
  {
    public CreditDebitVoucher()
    {
      this.ManualNo = "NA";
      this.Details = new List<CreditDebitVoucherDetail>();
    }

    public byte CompanyId { get; set; }

    [Display(Name = "Voucher Type")]
    public byte VoucherType { get; set; }

    [Display(Name = "Voucher No")]
    public string VoucherNo { get; set; }

    [Display(Name = "Voucher Date")]
    public DateTime VoucherDate { get; set; }

    [Display(Name = "Manual No")]
    [StringLength(25, ErrorMessage = "Manual No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    public string ManualNo { get; set; }

    [Required(ErrorMessage = "Please select Business Devision")]
    [Display(Name = "Business Devision")]
    public byte BusinessTypeId { get; set; }

    [Display(Name = "Remarks")]
    [Required(ErrorMessage = "Please enter Remarks")]
    [StringLength(200, ErrorMessage = "Remarks must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    public string Remarks { get; set; }

    [Required(ErrorMessage = "Please enter Reference No")]
    [StringLength(50, ErrorMessage = "Reference No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Display(Name = "Reference No")]
    public string ReferenceNo { get; set; }

    [Display(Name = "Prepared at Location")]
    public short PreparedLocationId { get; set; }

    public string PreparedLocationCode { get; set; }

    [Display(Name = "Accounting Location")]
    public short AccountingLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Accounting Location")]
    public string AccountingLocationCode { get; set; }

    [Display(Name = "GSTIN No")]
    public string GstTinNo { get; set; }

    public short CompanyGstStateId { get; set; }

    public short CompanyGstId { get; set; }

    public byte CodeType { get; set; }

    [Display(Name = "Paid To/Received From")]
    public short CodeId { get; set; }

    [Required(ErrorMessage = "Please enter Paid To/Received From")]
    public string Code { get; set; }

    public string PartyName { get; set; }

    [Display(Name = "Paid To/Received State")]
    [Required(ErrorMessage = "Please select State")]
    public long? PartyGstId { get; set; }

    public short PartyGstStateId { get; set; }

    [Display(Name = "Narration")]
    [Required(ErrorMessage = "Please enter Narration")]
    [StringLength(200, ErrorMessage = "Narration must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    public string Narration { get; set; }

    public bool IsPartyRegistered { get; set; }

    [Display(Name = "GST Exempted Category")]
    public byte GstExemptedCategory { get; set; }

    [Display(Name = "Upload Declaration Document")]
    public string DocumentName { get; set; }

    public HttpPostedFileBase Attachment { get; set; }

    [Display(Name = "Sub Total")]
    public Decimal SubTotal { get; set; }

    [Display(Name = "IGST")]
    public Decimal Igst { get; set; }

    public Decimal IgstPercentage { get; set; }

    [Display(Name = "CGST")]
    public Decimal Cgst { get; set; }

    public Decimal CgstPercentage { get; set; }

    [Display(Name = "SGST")]
    public Decimal Sgst { get; set; }

    public Decimal SgstPercentage { get; set; }

    [Display(Name = "UGST")]
    public Decimal Ugst { get; set; }

    public Decimal UgstPercentage { get; set; }

    [Display(Name = "GST Total")]
    public Decimal GstTotal { get; set; }

    [Display(Name = "Amount")]
    public Decimal Amount { get; set; }

    [Display(Name = "Net Amount")]
    [AssertThat("0 < NetAmount", ErrorMessage = "Net Amount must be greater than 0")]
    public Decimal NetAmount { get; set; }

    [Range(0.001, 99.99, ErrorMessage = "Please enter TDS Rate between 0 to 99.99")]
    [Display(Name = "TDS Rate(%)")]
    public Decimal TdsRate { get; set; }

    [Display(Name = "TDS Section")]
    [Required(ErrorMessage = "Please select TDS Section")]
    public short TdsAccountId { get; set; }

    [Display(Name = "TDS Amount")]
    public Decimal TdsAmount { get; set; }

    [Display(Name = "Upload Vendor Invoice")]
    public string VendorInvoiceDocumentName { get; set; }

    public HttpPostedFileBase VendorInvoiceAttachment { get; set; }

    public List<CreditDebitVoucherDetail> Details { get; set; }

    public Payment PaymentDetails { get; set; }

    public Receipt ReceiptDetails { get; set; }

    public string FinYear { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public short EntryBy { get; set; }

    [Display(Name = "Cost Center Applicable")]
    public bool IsCostCenterApplicable { get; set; }
  }
}
