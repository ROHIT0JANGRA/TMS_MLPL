//  
// Type: CodeLock.Models.DriverSettlement
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DriverSettlement : Base
    {
        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public long TripsheetId { get; set; }

        public byte searchBy { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Tripsheet No")]
        public string TripsheetNo { get; set; }

        [Display(Name = "Manual Tripsheet No")]
        public string ManualTripsheetNo { get; set; }

        [Display(Name = "Tripsheet Date")]
        public DateTime TripsheetDate { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

        [Display(Name = "Starting Location")]
        public string StartLocationCode { get; set; }

        [Display(Name = "End Location")]
        public string EndLocationCode { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Market/Qwn")]
        public string SubCategory { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "External Usage Category")]
        public string ExternalUsageCategory { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Display(Name = "Route")]
        public string Route { get; set; }

        [Display(Name = "Vehicle Mode")]
        public string VehicleMode { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        public short VehicleId { get; set; }

        [Display(Name = "Tripsheet Operational Close Date")]
        public DateTime? OpCloseDateTime { get; set; }

        [Display(Name = "Tripsheet Financial Close Date")]
        public DateTime? FinCloseDateTime { get; set; }

        [Display(Name = "Driver")]
        public string DriverName { get; set; }

        public short? DriverId { get; set; }

        [Display(Name = "Driver License No")]
        public string DriverLicenseNo { get; set; }

        [Display(Name = "License Valid upto")]
        public DateTime DriverLicenseValidityDate { get; set; }

        [Display(Name = "Starting Km Reading")]
        public int? StartKm { get; set; }

        [Display(Name = "Closing Km Reading")]
        public int? EndKm { get; set; }

        [Display(Name = "Total Km")]
        public int TotalKm { get; set; }

        [Display(Name = "Actual KMPL")]
        public int ActualKMPL { get; set; }

        [Required(ErrorMessage = "Please enter Prepared By")]
        [Display(Name = "Prepared By")]
        public string PreparedBy { get; set; }

        [Required(ErrorMessage = "Please enter Checked By")]
        [Display(Name = "Checked By")]
        public string CheckedBy { get; set; }

        [Required(ErrorMessage = "Please enter Approved By")]
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }

        [Required(ErrorMessage = "Please enter Audited By")]
        [Display(Name = "Audited By")]
        public string AuditedBy { get; set; }

        public DateTime SettlementDate { get; set; }

        [Display(Name = "Total Advance")]
        public Decimal TotalAdvance { get; set; }

        [Display(Name = "Total Expense")]
        public Decimal TotalExpense { get; set; }

        [Display(Name = "Total Enroute Expense")]
        public Decimal TotalEnrouteExpense { get; set; }

        [Display(Name = "Total Oil Expense Cash")]
        public Decimal TotalOilExpenseCash { get; set; }

        [Display(Name = "Total Oil Expense Card")]
        public Decimal TotalOilExpenseCard { get; set; }

        [Display(Name = "Net Amount")]
        public Decimal NetAmount { get; set; }

        public Decimal PaidAmount { get; set; }

        public Decimal ReceivedAmount { get; set; }

        public Decimal DriverBalanceAmount { get; set; }

        public string DriverBalanceDrCr { get; set; }

        public Payment PaymentDetails { get; set; }

        public Receipt ReceiptDetails { get; set; }

        public string FinYear { get; set; }
        [Display(Name = "Settlement Remarks")]
        [Required(ErrorMessage = "Please Enter Remarks")]
        public string SettlementRemarks { get; set; }
    }
}
