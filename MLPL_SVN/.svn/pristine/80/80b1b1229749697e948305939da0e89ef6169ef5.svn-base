//  
// Type: CodeLock.Models.GstGeneration
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
    public class GstGeneration : BaseModel
    {

        public GstGeneration()
        {
            this.Details = new List<CustomerBillDetail>();
            this.CustomerBillSupplementryDetail = new List<CustomerBillSupplementryDetail>();
        }
        public long BillId { get; set; }

        public long PartyGstId { get; set; }

        [Display(Name = "Invoice No")]
        public string BillNo { get; set; }

        [Required(ErrorMessage = "Please select Transaction Type")]
        [Display(Name = "Transaction Type")]
        public byte TransactionTypeId { get; set; }

        [Required(ErrorMessage = "Please select Transaction Category")]
        [Display(Name = "Transaction Category")]
        public byte SacId { get; set; }

        public short CustomerId { get; set; }

        [Remote("IsManualBillNoAvailable", "CustomerBill", AdditionalFields = "BillId,_BillIdToken", ErrorMessage = "Manual Bill No already exists.", HttpMethod = "POST")]
        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Please enter Customer")]
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        [Display(Name = "Customer GST State")]
        [Required(ErrorMessage = "Please select Customer GST State")]
        public short CustomerGstStateId { get; set; }

        [Required(ErrorMessage = "Please select Transporter GST State")]
        [Display(Name = "Transporter GST State")]
        public short CompanyGstStateId { get; set; }

        public byte PrimaryBillingTypeId { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime BillDate { get; set; }

        [Display(Name = "Address")]
        public string BillingAddress { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        public short GenerationStateId { get; set; }

        [Display(Name = "Bill Generation State")]
        public string GenerationState { get; set; }

        public int GenerationCityId { get; set; }

        [Display(Name = "Bill Generation City")]
        public string GenerationCity { get; set; }

        [Display(Name = "GSTIN No")]
        public string CompanyGstStateGstTinNo { get; set; }

        public long CompanyGstId { get; set; }

        public short GenerationLocationId { get; set; }

        [Display(Name = "Generation Location")]
        public string GenerationLocationCode { get; set; }

        public short SubmissionStateId { get; set; }

        [Display(Name = "Bill Submission State")]
        public string SubmissionState { get; set; }

        public int SubmissionCityId { get; set; }

        [Display(Name = "Bill Submission City")]
        public string SubmissionCity { get; set; }

        [Display(Name = "GSTIN No")]
        public string CustomerGstStateGstTinNo { get; set; }

        public long CustomerGstId { get; set; }

        public short SubmissionLocationId { get; set; }

        [Display(Name = "Submission Location")]
        public string SubmissionLocationCode { get; set; }

        public short CollectionLocationId { get; set; }

        public string CollectionLocationCode { get; set; }

        public byte ServiceTypeId { get; set; }

        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

        [Display(Name = "Inter State")]
        public string InterState { get; set; }

        [Display(Name = "SAC Category")]
        public string SacName { get; set; }

        [Display(Name = "GST Rate")]
        public Decimal GstRate { get; set; }

        [Display(Name = "ITC")]
        public string Itc { get; set; }

        [Display(Name = "Customer GSTIN No")]
        public string CustomerGstInNo { get; set; }

        [Display(Name = "Transporter GSTIN No")]
        public string TransporterGstInNo { get; set; }

        [Display(Name = "Sub Total")]
        public Decimal SubTotal { get; set; }

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

        public string IsInterState { get; set; }

        [Display(Name = "GST Total")]
        public Decimal GstTotal { get; set; }

        [Display(Name = "Total Amount")]
        public Decimal TotalAmount { get; set; }

        public byte PaybasId { get; set; }

        public string Remarks { get; set; }

        public string GstSac { get; set; }

        public byte GstSacId { get; set; }

        public List<CustomerBillDetail> Details { get; set; }

        public List<CodeLock.Models.CustomerBillSupplementryDetail> CustomerBillSupplementryDetail { get; set; }

        [Display(Name = "Vehicle No")]
        public short? VehicleId { get; set; }

        [Display(Name = "Vehicle No")]
        [Required(ErrorMessage = "Please enter Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "Transporter Name")]
        public string VendorName { get; set; }
    }
}
