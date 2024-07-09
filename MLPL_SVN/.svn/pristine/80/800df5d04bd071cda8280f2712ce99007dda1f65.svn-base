//  
// Type: CodeLock.Models.TripsheetClosure
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class TripsheetClosure
    {
        public long VehicleTrackingId { get; set; }
        public byte CompanyId { get; set; }

        public long TripsheetId { get; set; }

        [Display(Name = "Tripsheet Action")]
        public byte TripsheetAction { get; set; }

        public byte searchBy { get; set; }

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

        public byte CategoryId { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        public byte? SubCategoryId { get; set; }

        [Display(Name = "Market/Own")]
        public string SubCategory { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }
        public short CustomerId { get; set; }

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
        [Required(ErrorMessage = "Please select Operational Close Date")]
        public DateTime? OpCloseDateTime { get; set; }

        public bool OpCloseStatus { get; set; }

        [Display(Name = "Tripsheet Financial Close Date")]
        public DateTime? FinCloseDateTime { get; set; }

        public bool FinCloseStatus { get; set; }

        [Display(Name = "Driver")]
        public string DriverName { get; set; }

        public short? DriverId { get; set; }

        [Display(Name = "Driver License No")]
        public string DriverLicenseNo { get; set; }

        [Display(Name = "License Valid upto")]
        public DateTime DriverLicenseValidityDate { get; set; }

        public Decimal DriverBalance { get; set; }

        [Display(Name = "Starting Km Reading")]
        public int? StartKm { get; set; }

        [Display(Name = "Closing Km Reading")]
        [Range(0.001, 10000000.0, ErrorMessage = "Please enter a value between 0 to 10000000")]
        [AssertThat("StartKm < EndKm", ErrorMessage = "Closing Km is greater than Starting Km")]
        [Required(ErrorMessage = "Please enter Closing Km")]
        public int EndKm { get; set; }

        [Display(Name = "Total Km")]
        public int TotalKm { get; set; }

        [Display(Name = "Actual KMPL")]
        public int ActualKMPL { get; set; }

        [Required(ErrorMessage = "Please enter Prepared By")]
        [Display(Name = "Prepared By")]
        public string PreparedBy { get; set; }

        [Display(Name = "Checked By")]
        [Required(ErrorMessage = "Please enter Checked By")]
        public string CheckedBy { get; set; }

        [Required(ErrorMessage = "Please enter Approved By")]
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }

        [Required(ErrorMessage = "Please enter Audited By")]
        [Display(Name = "Audited By")]
        public string AuditedBy { get; set; }

        public Decimal PendingAmount { get; set; }
        public string THCbillGenerated { get; set; }

        [Display(Name = "Entry By")]
        public string EntryBy { get; set; }
        public bool IsMilkrunHrsPerDayEnabled { get; set; }
        public bool IsLaneIdEnabled { get; set; }

        public List<CodeLock.Models.OilExpenses> OilExpenses { get; set; }

        public List<CodeLock.Models.EnRouteExpenses> EnRouteExpenses { get; set; }

        public List<TripsheetAdvance> TripsheetAdvanceDetail { get; set; }

        public List<CodeLock.Models.VehicleLogDetail> VehicleLogDetail { get; set; }

        public List<CodeLock.Models.ThcDetail> ThcDetail { get; set; }
        public List<CodeLock.Models.TripsheetLaneDetail> TripsheetLaneDetails { get; set; }

        public List<CodeLock.Models.ThcFieldDetail> ThcFieldDetail { get; set; }

        public List<CodeLock.Models.Tracking_Details> ThcTrackingDetail { get; set; }
    }
    public class TripsheetLaneDetail : FSCRateDetail
    {
        [Display(Name = "Tour Id")]
        public string TourId { get; set; }
        [Display(Name = "ER Id")]
        public string ErId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter Fixed Amount")]
        [Range(0.0, 9999999999.0, ErrorMessage = "Please enter valid Fixed Amount")]
        [Display(Name = "Fixed Amount")]
        public decimal FixedAmount { get; set; }

        [Range(0.0, 9999999999.0)]
        [Display(Name = "Toll Charges")]
        public decimal TollAmount { get; set; }
        [Display(Name = "Additional KM")]
        [Range(0.0, 9999999999.0)]
        public long AdditionalKM { get; set; }
        [Display(Name = "Additional Amount KM")]
        [Range(0.0, 9999999999.0)]
        public decimal AdditionalAmountKM { get; set; }
        [Display(Name = "Other Charge")]
        [Range(0.0, 9999999999.0)]
        public decimal OtherCharge { get; set; }

        [Display(Name = "Total Amount")]
        [Range(0.0, 9999999999.0)]
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }

    }
}
