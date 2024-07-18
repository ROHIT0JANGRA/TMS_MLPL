//  
// Type: CodeLock.Models.Tripsheet
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class Tripsheet : BaseModel
    {
        public Tripsheet()
        {
            this.DocketDetails = new List<DocketDetail>();
            this.ChecklistDetails = new List<ChecklistDetail>();
            this.FuelSlipDetails = new List<FuelSlipDetail>();
        }

        public long TripsheetId { get; set; }

        [Display(Name = "Customer Name")]
        [RequiredIf("Category == 2", ErrorMessage = "Please enter Customer Name")]
        public string InternalCustomer { get; set; }
        public short InternalCustomerId { get; set; }
        public string FinYear { get; set; }

        public bool IsChecked { get; set; }

        [Display(Name = "Tripsheet No")]
        public string TripsheetNo { get; set; }

        [Display(Name = "Manual Tripsheet No")]
        [Required(ErrorMessage = "Please enter Manual Tripsheet No")]
        public string ManualTripsheetNo { get; set; }

        public DateTime TripsheetDate { get; set; }

        public TimeSpan TripsheetTime { get; set; }

        [Display(Name = "Tripsheet Date Time")]
        public DateTime? TripsheetDateTime { get; set; }

        [Display(Name = "Start Location")]
        public string StartLocation { get; set; }

        [Display(Name = "Start Location")]
        public short StartLocationId { get; set; }

        [Required(ErrorMessage = "Please enter End Location")]
        [Display(Name = "End Location")]
        public string EndLocation { get; set; }

        [Display(Name = "End Location")]
        public short EndLocationId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select Category")]
        public byte Category { get; set; }

        [Display(Name = "Sub Category")]
        [RequiredIf("Category != 2", ErrorMessage = "Please select Sub Category")]
        public byte? ExternalUsageSubCategory { get; set; }

        public byte? SubCategory { get; set; }

        [RequiredIf("Category == 2", ErrorMessage = "Please select Sub Category")]
        [Display(Name = "Sub Category")]
        public byte? InternalUsageSubCategory { get; set; }

        [RequiredIf("Category != 2", ErrorMessage = "Please enter Customer Code")]
        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Customer Code")]
        public short? CustomerId { get; set; }

        [Display(Name = "Vehicle No")]
        public short? VehicleId { get; set; }

        [Display(Name = "Vehicle No")]
        [Required(ErrorMessage = "Please enter Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "Vehicle Mode")]
        public string VehicleMode { get; set; }

        [RequiredIf("RouteId == 1", ErrorMessage = "Please enter From City")]
        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "From City")]
        public int FromCityId { get; set; }

        [Display(Name = "To City")]
        [RequiredIf("RouteId == 1", ErrorMessage = "Please enter To City")]
        public string ToCity { get; set; }

        [Display(Name = "To City")]
        public int ToCityId { get; set; }

        [Display(Name = "Starting Km. Reading")]
        [Required(ErrorMessage = "Please enter Start Km")]
        public int? StartKm { get; set; }

        [Display(Name = "First Driver")]
        public short? FirstDriverId { get; set; }

        [Display(Name = "Second Driver")]
        public short? SecondDriverId { get; set; }

        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter Driver Name")]
        [Display(Name = "First Driver Name")]
        //[NameAnnotation]
        public string FirstDriverName { get; set; }

        [Display(Name = "First Driver Mobile No")]
        [Required(ErrorMessage = "Please enter First Driver Mobile No")]
        [MobileAnnotation]
        public string FirstDriverMobileNo { get; set; }

        [Required(ErrorMessage = "Please enter License No")]
        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        [Display(Name = "License No")]
        public string FirstDriverLicenseNo { get; set; }

        [Display(Name = "First Driver License Issue By")]
        [Required(ErrorMessage = "Please enter First Driver License Issue By")]
        public string FirstDriverLicenseIssueBy { get; set; }

        [Display(Name = "License Validity Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select License Validity Date")]
        public DateTime FirstDriverLicenseValidityDate { get; set; }

        [Display(Name = "Second Driver Name")]
        //[NameAnnotation]
        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        public string SecondDriverName { get; set; }

        public DateTime CancelDate { get; set; }

        public string CancelReason { get; set; }

        [Display(Name = "Second Driver Mobile No")]
        [MobileAnnotation]
        public string SecondDriverMobileNo { get; set; }

        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        [Display(Name = "License No")]
        public string SecondDriverLicenseNo { get; set; }

        [Display(Name = "Second Driver License Issue By")]
        public string SecondDriverLicenseIssueBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "License Validity Date")]
        public DateTime? SecondDriverLicenseValidityDate { get; set; }

        public short TransitTimeHour { get; set; }

        public byte TransitTimeMinute { get; set; }

        [Display(Name = "Route")]
        public int? RouteId { get; set; }

        [Display(Name = "Pay Advance")]
        public bool IsAdvancePaid { get; set; }

        [Display(Name = "Pay Advance By Cash Card")]
        public bool IsAdvancePaidByCashCard { get; set; }

        [Display(Name = "Trip Route")]
        public short TripRouteId { get; set; }

        [RequiredIf("RouteId == 2", ErrorMessage = "Please enter Trip Route")]
        public string TripRouteName { get; set; }

        [Display(Name = "Transit Time")]
        public string TransitTime { get; set; }

        [Display(Name = "Driver Balance")]
        public Decimal DriverBalance { get; set; }

        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Please enter Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Is Fuel Slip Provided")]
        public bool IsFuelSlipProvided { get; set; }

        [RequiredIf("IsAdvancePaid == true", ErrorMessage = "Please select Advance Place")]
        [Display(Name = "Advance Place")]
        public string AdvancePlace { get; set; }

        [Display(Name = "Advance Date")]
        public DateTime AdvanceDate { get; set; }

        [Display(Name = "Advance Amount")]
        public Decimal AdvanceAmount { get; set; }

        [Display(Name = "Advance Location")]
        public short AdvanceLocationId { get; set; }

        [Display(Name = "Advance Location")]
        public string AdvanceLocationCode { get; set; }

        [RequiredIf("IsAdvancePaid == true", ErrorMessage = "Please select Advance Paid By")]
        [Display(Name = "Advance Paid By")]
        public string AdvancePaidBy { get; set; }

        [RequiredIf("IsAdvancePaidByCashCard == true", ErrorMessage = "Please select Advance Paid By Card")]
        [Display(Name = "Advance Paid By Card")]
        public byte? AdvanceCardId { get; set; }

        public List<DocketDetail> DocketDetails { get; set; }

        public List<FuelSlipDetail> FuelSlipDetails { get; set; }

        public List<ChecklistDetail> ChecklistDetails { get; set; }

        public Payment PaymentDetails { get; set; }

        [Display(Name = "Check List Checked By")]
        public string CheckListCheckedBy { get; set; }

        [Display(Name = "Check List Checked Date")]
        public DateTime? CheckListCheckedDate { get; set; }

        [Display(Name = "Check List Approved By")]
        public string CheckListApprovedBy { get; set; }

        [Display(Name = "Check List Approved Date")]
        public DateTime? CheckListApprovedDate { get; set; }

        [Display(Name = "Use Fuel Card")]
        public bool UseFuelCard { get; set; }

        [Display(Name = "Use Cash Card")]
        public bool UseCashCard { get; set; }

        [Display(Name = "Fuel Card")]
        public string FuelCard { get; set; }

        [Display(Name = "Cash Card")]
        public string CashCard { get; set; }

        [Display(Name = "Tripsheet Company")]
        [Required(ErrorMessage = "Please enter Tripsheet Company")]
        public byte TripsheetCompanyId { get; set; }
    }
    public class ReportTripStartModel
    {
        public int SRNo { get; set; }
        public string TripsheetNo { get; set; }
        public string TripsheetDate { get; set; }
        public string TripsheetTime { get; set; }
        public string ManualTripsheetNo { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string VehicleNo { get; set; }
        public int StartKm { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal DriverBalance { get; set; }
        public string IsThcAttached { get; set; }
        public string IsFuelSlipProvided { get; set; }
        public string IsCancel { get; set; }
        public string CancelDate { get; set; }
        public string CancelReason { get; set; }
        public string EntryBy { get; set; }
        public string EntryDate { get; set; }
        public string FirstDriverName { get; set; }
        public string FirstDriverMobileNo { get; set; }
        public string FirstDriverLicenseNo { get; set; }
        public string FirstDriverLicenseIssueBy { get; set; }
        public string FirstDriverLicenseValidityDate { get; set; }
        public string SecondDriverName { get; set; }
        public string SecondDriverMobileNo { get; set; }
        public string SecondDriverLicenseNo { get; set; }
        public string SecondDriverLicenseIssueBy { get; set; }
        public string SecondDriverLicenseValidityDate { get; set; }
        public int TransitTimeHour { get; set; }
        public int TransitTimeMinute { get; set; }
        public string CheckListCheckedBy { get; set; }
        public string CheckListCheckedDate { get; set; }
        public string CheckListApprovedBy { get; set; }
        public string CheckListApprovedDate { get; set; }
        public int EndKm { get; set; }
        public string OpCloseStatus { get; set; }
        public string Remarks { get; set; }
        public bool AllDocketField { get; set; }

        public bool AllDocketCharges { get; set; }

        public bool AllReportField { get; set; }
    }

}
