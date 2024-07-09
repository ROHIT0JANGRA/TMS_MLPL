//  
// Type: CodeLock.Models.OtherBillEntry
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
	public class OtherBillEntry : BaseModel
	{
		public OtherBillEntry()
		{
			this.BillAccountDetails = new List<BillAccountDetail>();
		}

		public short VendorId { get; set; }

		[Required(ErrorMessage = "Please enter Vendor")]
		[Display(Name = "Vendor")]
		public string VendorCode { get; set; }

		[Required(ErrorMessage = "Please enter Vendor Name")]
		[Display(Name = "Vendor Name")]
		public string VendorName { get; set; }

		[Display(Name = "Vendor State")]
		[Required(ErrorMessage = "Please select Vendor GST State")]
		public short VendorGstStateId { get; set; }

		[Required(ErrorMessage = "Please select Company GST State")]
		[Display(Name = "Company State")]
		public short CompanyGstStateId { get; set; }

		[Display(Name = "GST Type")]
		[Required(ErrorMessage = "Please select GST Type")]
		public byte GstTypeId { get; set; }

		[Required(ErrorMessage = "Please select GST Service Type")]
		[Display(Name = "GST Service Type")]
		public byte GstServiceTypeId { get; set; }

		[Display(Name = "Is Rcm Applicable")]
		public bool IsRcm { get; set; }

		[Display(Name = "Is Inter-State")]
		public bool IsInterState { get; set; }

		[Display(Name = "Is GST Registered")]
		public bool IsGstRegistered { get; set; }

		[Required(ErrorMessage = "Please select Location")]
		public short VendorLocationId { get; set; }

		[Required(ErrorMessage = "Please select Location")]
		public short CompanyLocationId { get; set; }

		[Required(ErrorMessage = "Please select City")]
		public int GstVendorCityId { get; set; }

		[Required(ErrorMessage = "Please select City")]
		public int GstCompanyCityId { get; set; }

		public long VendorGstId { get; set; }

		[GstInNoAnnotation]
		[Required(ErrorMessage = "Please enter GSTIN No")]
		public string VendorGstinNo { get; set; }

		public long CompanyGstId { get; set; }

		public string CompanyGstinNo { get; set; }

		[Required(ErrorMessage = "Please enter Address")]
		public string GstVendorAddress { get; set; }

		[Display(Name = "Manual Bill No")]
        [Required(ErrorMessage = "Please Manual Bill No.")]
        public string ManualBillNo { get; set; }

		[Display(Name = "Bill Date Time")]
		public DateTime BillDateTime { get; set; }

		[Display(Name = "Credit Account")]
		public string CreditAccount { get; set; }

		[Display(Name = "Due Date")]
		public DateTime BillDueDate { get; set; }

		[Display(Name = "Remarks")]
		public string Remarks { get; set; }

		[Display(Name = "Cost Center Applicable")]
		public bool IsCostCenterApplicable { get; set; }

		[Display(Name = "Other Deduction")]
		public Decimal OtherDeduction { get; set; }

		[Display(Name = "Discount Received")]
		public Decimal DiscountReceived { get; set; }

		[Display(Name = "Net Payable Amount")]
		public Decimal NetPayableAmount { get; set; }

		[Display(Name = "Company List")]
		public new byte CompanyId { get; set; }

		[Display(Name = "Total Account")]
		public Decimal TotalAccount { get; set; }

		[Display(Name = "Total Amount")]
		public Decimal TotalAmount { get; set; }

		public short LocationId { get; set; }

		public string LocationCode { get; set; }

		public byte BillType { get; set; }

		public bool IsFinalize { get; set; }

		public Decimal SubTotal { get; set; }

		public Decimal TaxTotal { get; set; }

		[Display(Name = "TDS Section")]
		[RequiredIf("TdsRate > 0", ErrorMessage = "Please select  TDS Section")]
		public short? TdsAccountId { get; set; }

		[Display(Name = "TDS Rate")]
		public Decimal TdsRate { get; set; }

		[Display(Name = "TDS Amount")]
		public Decimal TdsAmount { get; set; }

		[PanNoAnnotation]
		public string PanNo { get; set; }

		public string ServiceTaxNo { get; set; }

		public Decimal GrandTotal { get; set; }

		public Decimal GstRate { get; set; }

		public List<MasterTax> TaxList { get; set; }

		public List<BillAccountDetail> BillAccountDetails { get; set; }

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

		[Display(Name = "Bill Amount")]
		public Decimal BillAmount { get; set; }

        [Display(Name = "Bill Payment Location ")]
        public short PaymentLocationId { get; set; }
		public string PaymentLocation { get; set; }

    }
}
