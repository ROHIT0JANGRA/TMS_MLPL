//  
// Type: CodeLock.Models.VendorBillGeneration
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
	public class VendorBillGeneration : BaseModel
	{
		public VendorBillGeneration()
		{
			this.ChargeList = new List<VendorBillCharge>();
			this.TaxList = new List<MasterTax>();
		}

		public short VendorId { get; set; }

		[Required(ErrorMessage = "Please enter Vendor")]
		[Display(Name = "Vendor")]
		public string VendorCode { get; set; }

		[Display(Name = "Vendor Name")]
		[Required(ErrorMessage = "Please enter Vendor Name")]
		public string VendorName { get; set; }

		[Display(Name = "From Date")]
		public DateTime FromDate { get; set; }

		[Display(Name = "To Date")]
		public DateTime ToDate { get; set; }

		[Display(Name = "System Document No")]
		public string DocumentNo { get; set; }

		[Display(Name = "Manual Document No")]
		public string ManualDocumentNo { get; set; }

		[Display(Name = "Vendor Service")]
		[Required(ErrorMessage = "Please select Vendor Service")]
		public byte VendorServiceId { get; set; }

		public bool IsBooking { get; set; }

		[Display(Name = "Document Type")]
		public MasterGeneral[] DocumentType { get; set; }

		[Required(ErrorMessage = "Please select Bill Date and Time")]
		[Display(Name = "Bill Date")]
		[DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
		[DataType(DataType.DateTime)]
		public DateTime BillDateTime { get; set; }

		[Required(ErrorMessage = "Please select vendor Bill Date")]
		[Display(Name = "Vendor Bill Date")]
		[DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
		[DataType(DataType.DateTime)]
		public DateTime VendorBillDateTime { get; set; }

		[Display(Name = "Manual Bill No")]
		[Required(ErrorMessage = "Please enter manual bill no")]
		public string ManualBillNo { get; set; }

        [Display(Name = "Bill Payment Location ")]
        public short PaymentLocationId { get; set; }
        [Required(ErrorMessage = "Please enter bill payment location")]
        public string PaymentLocation { get; set; }
        public string PaymentLocationCode { get; set; }
        [Display(Name = "Bill Amount")]
		public Decimal BillAmount { get; set; }

		[Display(Name = "Contract Amount")]
		public Decimal ContractAmount { get; set; }

		[Display(Name = "Remarks")]
		public string Remarks { get; set; }

		[Display(Name = "Document Type")]
		public string SelectedDocumentType { get; set; }

		public short LocationId { get; set; }

		public string LocationCode { get; set; }

		public string VendorChargeList { get; set; }

		[Display(Name = "Vendor State")]
		[Required(ErrorMessage = "Please select Vendor GST State")]
		public short VendorGstStateId { get; set; }

		[Display(Name = "Company State")]
		[Required(ErrorMessage = "Please select Company GST State")]
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
		public short GstVendorLocationId { get; set; }

		[Required(ErrorMessage = "Please select Location")]
		public short GstCompanyLocationId { get; set; }

		[Required(ErrorMessage = "Please select City")]
		public int GstVendorCityId { get; set; }

		[Required(ErrorMessage = "Please select City")]
		public int GstCompanyCityId { get; set; }

		[Required(ErrorMessage = "Please enter Address")]
		public string GstVendorAddress { get; set; }


		public long VendorGstId { get; set; }

		[GstInNoAnnotation]
		[Required(ErrorMessage = "Please enter GSTIN No")]
		public string VendorGstinNo { get; set; }

		public long CompanyGstId { get; set; }

		public string CompanyGstinNo { get; set; }

		[Display(Name = "Bill Due Date")]
		public DateTime? BillDueDate { get; set; }

		public byte BillType { get; set; }

		public bool IsFinalize { get; set; }

		public Decimal SubTotal { get; set; }

		public Decimal TaxTotal { get; set; }

		public bool EnableGst { get; set; }

		public Decimal GstRate { get; set; }

		public bool EnableTds { get; set; }

		public byte GstExemptedCategoryId { get; set; }

		public byte TdsGroupId { get; set; }

		public short TdsAccountId { get; set; }

		public Decimal TdsRate { get; set; }

		public Decimal TdsAmount { get; set; }

		[PanNoAnnotation]
		public string PanNo { get; set; }

		public Decimal GrandTotal { get; set; }

		[Display(Name = "Location")]
		public string BAMappedLocationid { get; set; }


		[Required(ErrorMessage = "Please Enter Location")]
		public string BAMappedLocation { get; set; }
        [Display(Name = "Transport Mode")]
        //[Required(ErrorMessage = "Please enter Transport Mode")]
        public byte TransportModeId { get; set; }

        public List<VendorBillCharge> ChargeList { get; set; }

		public List<MasterTax> TaxList { get; set; }

		public List<VendorDocument> Details { get; set; }

		public List<VendorDocument> DocumentList { get; set; }

        [Display(Name = "IS TDS Applicable")]
        public bool IsTDSApplicable { get; set; }

        [Display(Name = "TDS Amount On Advance")]
        public decimal TdsAmountOnAdvance { get; set; }

        [Display(Name = "TDS Amount On Balance")]
        public decimal TdsAmountOnBalance { get; set; }

    }
}
