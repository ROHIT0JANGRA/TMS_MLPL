//  
// Type: CodeLock.Models.DriverAdvance
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DriverAdvance : BaseModel
    {
        public long TripsheetId { get; set; }

        public byte searchBy { get; set; }

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public string FinYear { get; set; }

        [Display(Name = "Tripsheet No")]
        public string TripsheetNo { get; set; }

        [Display(Name = "Tripsheet Date")]
        public DateTime TripsheetDate { get; set; }

        [Display(Name = "Starting Location")]
        public string StartLocationCode { get; set; }

        [Display(Name = "End Location")]
        public string EndLocationCode { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        public short VehicleId { get; set; }

        [Display(Name = "Driver")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Please select Driver")]
        public short DriverId { get; set; }

        [Display(Name = "Driver License No")]
        public string DriverLicenseNo { get; set; }

        [Display(Name = "License Valid upto")]
        public DateTime DriverLicenseValidityDate { get; set; }

        [Display(Name = "Driver Balance")]
        public Decimal DriverBalance { get; set; }

        public Decimal PaidAmount { get; set; }

        public Decimal ReceivedAmount { get; set; }

        public Decimal BalanceAmount { get; set; }

        [Required(ErrorMessage = "Please enter Advance Place")]
        [Display(Name = "Advance Place")]
        public string AdvancePlace { get; set; }

        [Display(Name = "Advance Date")]
        [Required(ErrorMessage = "Please select Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime AdvanceDate { get; set; }

        [Required(ErrorMessage = "Please enter Advance Amount")]
        [Display(Name = "Advance Amount")]
        public Decimal AdvanceAmount { get; set; }

        [Display(Name = "Advance Location")]
        public short AdvanceLocationId { get; set; }

        [Display(Name = "Advance Location")]
        public string AdvanceLocationCode { get; set; }

        [Display(Name = "Advance Paid By")]
        [Required(ErrorMessage = "Please enter Advance Paid By")]
        public string AdvancePaidBy { get; set; }

        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Please enter Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Pay Advance By Cash Card")]
        public bool IsAdvancePaidByCashCard { get; set; }

        [Display(Name = "Expected Expense")]
        public Decimal PendingAmount { get; set; }

        public Payment PaymentDetails { get; set; }
    }
}
