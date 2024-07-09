//  
// Type: CodeLock.Models.TplBillEntry
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class TplBillEntry : BaseModel
    {
        public long BillId { get; set; }

        [Display(Name = "Transaction Category")]
        [Required(ErrorMessage = "Please select Transaction Category")]
        public string GstSac { get; set; }

        public byte GstSacId { get; set; }

        public long VendorGstId { get; set; }

        public long CompanyGstId { get; set; }

        [Display(Name = "Vendor GST State")]
        public short VendorGstStateId { get; set; }

        [Required(ErrorMessage = "Please select Transporter GST State")]
        [Display(Name = "Transporter GST State")]
        public short CompanyGstStateId { get; set; }

        public byte PrimaryBillingTypeId { get; set; }

        [Display(Name = "Transporter GSTIN No")]
        public string CompanyGstStateGstTinNo { get; set; }

        [Display(Name = "Vendor GSTIN No")]
        public string VendorGstStateGstTinNo { get; set; }

        [PanNoAnnotation]
        [Display(Name = "Vendor PAN No")]
        public string VendorPanNo { get; set; }

        [Display(Name = "SAC Category")]
        public string SacName { get; set; }

        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

        public byte GstServiceTypeId { get; set; }

        [Display(Name = "GST Rate")]
        public Decimal GstRate { get; set; }

        [Display(Name = "Inter State")]
        public string InterState { get; set; }

        [Display(Name = "SGST")]
        public Decimal Sgst { get; set; }

        public Decimal SgstPercentage { get; set; }

        [Display(Name = "UGST")]
        public Decimal Ugst { get; set; }

        public Decimal UgstPercentage { get; set; }

        [Display(Name = "CGST")]
        public Decimal Cgst { get; set; }

        public Decimal CgstPercentage { get; set; }

        [Display(Name = "IGST")]
        public Decimal Igst { get; set; }

        public Decimal IgstPercentage { get; set; }

        [Display(Name = "GST Total")]
        public Decimal GstTotal { get; set; }

        [Display(Name = "Total")]
        public Decimal Total { get; set; }

        public short VendorId { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "Please enter Vendor")]
        public string VendorCode { get; set; }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Bill Date Time")]
        public DateTime BillDateTime { get; set; }

        [Display(Name = "Vendor Bill No")]
        [Required(ErrorMessage = "Please enter Vendor Bill No")]
        public string VendorBillNo { get; set; }

        [Display(Name = "Vendor Bill Date")]
        public DateTime VendorBillDate { get; set; }

        [Display(Name = "Due Days")]
        public int DueDays { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please enter Remarks")]
        [Display(Name = "Remarks")]
        [StringLength(250, ErrorMessage = "Remarks must be minimum 2 and maximum 250 character long", MinimumLength = 2)]
        public string Remarks { get; set; }

        [Display(Name = "Sub Total")]
        public Decimal SubTotal { get; set; }

        [Display(Name = "Grand Total")]
        public Decimal GrandTotal { get; set; }

        public byte TdsGroupId { get; set; }

        [Display(Name = "TDS Applicable")]
        public bool EnableTds { get; set; }

        [RequiredIf("EnableTds==true", ErrorMessage = "Please select TDS Section")]
        [Display(Name = "TDS Section")]
        public string TdsAccountId { get; set; }

        [Display(Name = "TDS Rate(%)")]
        [Range(0.0, 99.99, ErrorMessage = "Please enter TDS Rate between 0 to 99.99")]
        public Decimal TdsRate { get; set; }

        [Display(Name = "TDS Amount")]
        public Decimal TdsAmount { get; set; }

        public string BillType { get; set; }

        [Display(Name = "Discount")]
        public Decimal DiscountReceived { get; set; }

        [Display(Name = "Other Deduction")]
        public Decimal OtherDeduction { get; set; }

        public string LocationCode { get; set; }

        public Decimal PaidAmount { get; set; }

        public Decimal PendingAmount { get; set; }

        public List<TplBillEntryDetail> Details { get; set; }
        public byte DocumentTypeId { get; set; }
    }
}
