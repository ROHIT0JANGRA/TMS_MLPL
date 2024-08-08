//  
// Type: CodeLock.Models.Prs
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class Prs
    {
        public Prs()
        {
            this.FinacialStatus = (byte)0;
            this.AdvBalPmtDtl = new List<PrsAdvBalPaymnt_Details>();
            this.DocketList = new List<PrsDocket>();
            this.ErrorList = new List<PrsDocket>();
        }

        public string DocketNo { get; set; }

        [Display(Name = "Paybas")]
        public byte? PaybasId { get; set; }

        [Display(Name = "Transport Mode")]
        //[Required(ErrorMessage = "Please enter Transport Mode")]
        public byte? TransportModeId { get; set; }

        [Display(Name = "Business Type")]
        public byte? BusinessTypeId { get; set; }

        [Display(Name = "Booked By")]
        public string IsBookedByBa { get; set; }

        [RequiredIf("DocketNo == null", ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        public string BookedByCode { get; set; }

        public short BookedById { get; set; }

        public long PrsId { get; set; }

        public string PrsNo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "PRS Date")]
        [Required(ErrorMessage = "Please select PRS Date")]
        public DateTime PrsDate { get; set; }

        [StringLength(50, ErrorMessage = "Manual PRS No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "Manual PRS")]
        public string ManualPrsNo { get; set; }

        [Display(Name = "Location")]
        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        [Display(Name = "Booked By")]
        public short BookedBy { get; set; }

        [Display(Name = "Use Ad-hoc Amount")]
        public bool IsAdhoc { get; set; }

        public short? ContractId { get; set; }

        [Required(ErrorMessage = "Please select Vendor")]
        [Display(Name = "Vendor")]
        public short VendorId { get; set; }

        [Display(Name = "Vendor Name")]
        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Vendor Name")]
        public string VendorName { get; set; }

        [Display(Name = "Supplier Name")]
        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Supplier Name")]
        public string SupplierName { get; set; }

        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Supplier Mobile No")]
        [MobileAnnotation]
        [Display(Name = "Supplier Mobile No")]
        public string SupplierMobileNo { get; set; }

        //[RequiredIf("VendorTypeId == 3", ErrorMessage = "Please select Tripsheet")]
        [Display(Name = "Trip Sheet")]
        public int? TripsheetId { get; set; }

        [Required(ErrorMessage = "Please select Vehicle")]
        [Display(Name = "Vehicle")]
        public short? VehicleId { get; set; }

        [RequiredIf("VehicleId == 1", ErrorMessage = "Please enter Vehicle No")]
        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        [Required(ErrorMessage = "Please select Vehicle Type")]
        [Display(Name = "Vehicle Type")]
        public short VehicleTypeId { get; set; }

        [Required(ErrorMessage = "Please select FTL Type")]
        [Display(Name = "FTL Type")]
        public short FtlTypeId { get; set; }

        [Required(ErrorMessage = "Please select Registration Date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Vehicle Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Engine No")]
        [Required(ErrorMessage = "Please enter Engine No")]
        public string EngineNo { get; set; }

        [Display(Name = "Chasis No")]
        [Required(ErrorMessage = "Please enter Chasis No")]
        public string ChassisNo { get; set; }

        [Display(Name = "RC Book No")]
        [Required(ErrorMessage = "Please enter RC Book No")]
        public string RcBookNo { get; set; }

        [Required(ErrorMessage = "Please select Insurance Validity Date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Insurance Validity Date")]
        public DateTime InsuranceValidityDate { get; set; }

        [Display(Name = "Fitness Validity Date")]
        [Required(ErrorMessage = "Please select Fitness Validity Date")]
        [DataType(DataType.DateTime)]
        public DateTime FitnessValidityDate { get; set; }

        [Display(Name = "Vehicle Permit Validity Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select Vehicle Permit Validity Date")]
        public DateTime PermitValidityDate { get; set; }

        [NameAnnotation]
        [Required(ErrorMessage = "Please enter Driver Name")]
        [Display(Name = "First Driver Name")]
        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        public string FirstDriverName { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Please enter Mobile No")]
        [MobileAnnotation]
        public string FirstDriverMobileNo { get; set; }

        [Display(Name = "License No")]
        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter License No")]
        public string FirstDriverLicenseNo { get; set; }

        [Required(ErrorMessage = "Please enter RTO Name")]
        [StringLength(50, ErrorMessage = "RTO Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "Issue By RTO")]
        public string FirstDriverLicenseIssueBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "License Validity Date")]
        [Required(ErrorMessage = "Please select License Validity Date")]
        public DateTime FirstDriverLicenseValidityDate { get; set; }

        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [NameAnnotation]
        [Display(Name = "Second Driver Name")]
        public string SecondDriverName { get; set; }

        [MobileAnnotation]
        [Display(Name = "Mobile No")]
        public string SecondDriverMobileNo { get; set; }

        [Display(Name = "License No")]
        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        public string SecondDriverLicenseNo { get; set; }

        [Display(Name = "Issue By RTO")]
        [StringLength(50, ErrorMessage = "RTO Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        public string SecondDriverLicenseIssueBy { get; set; }

        [Display(Name = "License Validity Date")]
        [DataType(DataType.DateTime)]
        public DateTime? SecondDriverLicenseValidityDate { get; set; }

        [Display(Name = "Starting Kilometer")]
        [Range(0.001, 10000000.0, ErrorMessage = "Please enter a value greater than zero")]
        [Required(ErrorMessage = "Please enter Starting Kilometer")]
        public int StartKm { get; set; }

        [Display(Name = "End Kilometer")]
        [AssertThat("StartKm < EndKm", ErrorMessage = "End Kilometer is greater than Starting Kilometer")]
        [Range(0.001, 10000000.0, ErrorMessage = "Please enter a value greater than zero")]
        [Required(ErrorMessage = "Please enter End Kilometer")]
        public int EndKm { get; set; }

        [Required(ErrorMessage = "Please enter Outgoing Remark")]
        [Display(Name = "Outgoing Remark")]
        public string OutgoingRemark { get; set; }

        [Display(Name = "Overload")]
        public bool IsOverLoaded { get; set; }


        [RequiredIf("IsOverLoaded == true", ErrorMessage = "Please select Overloaded Reason")]
        [Display(Name = "Overload Reason")]
        public byte? OverLoadedReasonId { get; set; }

        [Display(Name = "Weight Loaded")]
        public Decimal WeightLoaded { get; set; }

        [Display(Name = "Capacity Utilization")]
        public Decimal CapacityUtilization { get; set; }

        [AssertThat("TotalDocket > 0", ErrorMessage = "Docket Not Available")]
        public short TotalDocket { get; set; }

        [Display(Name = "Total Packages")]
        public int TotalPackages { get; set; }

        [Display(Name = "Total Actual Weight")]
        public Decimal TotalActualWeight { get; set; }

        [Display(Name = "Kanta Weight")]
        public decimal KantaWeight { get; set; }

        [Display(Name = "Slip No.")]
        public string SlipNo { get; set; }

        [Display(Name = "Reason For Weight Loss")]
        public string ReasonForWeightLoss { get; set; }

        [Display(Name = "Contract Amount")]
        [Required(ErrorMessage = "Please enter Contract Amount")]
        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter a value between 1 to 9999999999")]
        public Decimal ContractAmount { get; set; }

        [Display(Name = "Balance Paid At")]
        public short BalanceLocationId { get; set; }

        [Display(Name = "Advance Amount")]
        [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Advance Amount between 0 to 9999999999")]
        [AssertThat("ContractAmount >= AdvanceAmount", ErrorMessage = "Advance Amount is must be less than or equal to Contract Amount")]
        public Decimal AdvanceAmount { get; set; }

        [Display(Name = "Advance Paid At")]
        [RequiredIf("AdvanceAmount > 0 && IsMultiAdvApply == false", ErrorMessage = "Please enter Advance Paid Location")]
        // [RequiredIf("AdvanceAmount > 0", ErrorMessage = "Please enter Advance Paid Location")]
        public short? AdvanceLocationId { get; set; }

        public byte FinacialStatus { get; set; }

        [Display(Name = "Is Cancelled")]
        public bool IsCancelled { get; set; }

        public DateTime? CancelledDate { get; set; }

        public string CancelledReason { get; set; }

        public short EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public byte CompanyId { get; set; }

        [Display(Name = "Vendor Type")]
        [Required(ErrorMessage = "Please select Vendor Type")]
        public byte VendorTypeId { get; set; }

        [Display(Name = "PRS Date")]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please select PRS Date and Time")]
        public DateTime PrsDateTime { get; set; }

        [Display(Name = "Vehicle Capacity")]
        [Range(1.0, 999999999999.0, ErrorMessage = "Please enter Valid Vehicle Capacity")]
        public Decimal VehicleCapacity { get; set; }

        [Required(ErrorMessage = "Please enter Balance Paid Location")]
        public string BalanceLocationCode { get; set; }

        [RequiredIf("AdvanceAmount > 0 && IsMultiAdvApply == false", ErrorMessage = "Please enter Advance Paid Location")]

        // [RequiredIf("AdvanceAmount > 0", ErrorMessage = "Please enter Advance Paid Location")]
        public string AdvanceLocationCode { get; set; }

        [Display(Name = "Telephone Charge")]
        public Decimal TelephoneCharge { get; set; }

        [Display(Name = "Humali Charge")]
        public Decimal HumaliCharge { get; set; }

        [Display(Name = "Mamul Charge")]
        public Decimal MamulCharge { get; set; }

        [Display(Name = "Employee")]
        public short EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        [AssertThat("DocketCount > 0", ErrorMessage = "Please select any one Docket")]
        public int DocketCount { get; set; }

        public Decimal OtherAmount { get; set; }

        public List<PrsDocket> DocketList { get; set; }
        public List<PrsDocket> ErrorList { get; set; }

        public List<MasterCharge> ChargeList { get; set; }

        [Range(1.0, 999999999999.0, ErrorMessage = "Please enter EWAY Bill No")]
        [Display(Name = "EWAY Bill No")]
        [Required(ErrorMessage = "Please enter EWAY Bill No")]
        public string EwayBillNo { get; set; }

        [Display(Name = "EWAY Bill Issue Date")]
        public DateTime? EwayBillIssueDate { get; set; }

        [Display(Name = "EWAY Bill Expiry Date")]
        public DateTime? EwayBillExpiryDate { get; set; }

        [Display(Name = "Pickup By Same Vehicle")]
        public bool IsPickupThroughSameVehicle { get; set; }

        public string PrsStatus { get; set; }

        [Display(Name = "Select City")]
        public bool IsSelectCity { get; set; }

        public int? FromCityId { get; set; }

        public List<PrsAdvBalPaymnt_Details> AdvBalPmtDtl { get; set; }

        [NameAnnotation]
        [Display(Name = "From City")]
        [RequiredIf("IsSelectCity == true", ErrorMessage = "Please enter City Name")]
        public string FromCityName { get; set; }

        public int? ToCityId { get; set; }

        [RequiredIf("IsSelectCity == true", ErrorMessage = "Please enter City Name")]
        [NameAnnotation]
        [Display(Name = "To City")]
        public string ToCityName { get; set; }
        [Display(Name = "Is Multiadvance Apply")]
        public bool IsMultiAdvApply { get; set; }
        public string FinYear { get; set; }

        public bool ReportType { get; set; }
        public bool FormatType { get; set; }

        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string data { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public short level { get; set; }
        public short levelType { get; set; }
        public int length { get; set; }
        public int total { get; set; }
        public int start { get; set; }
    }

    public class PRSReport
    {
        public  List<AdvanceFilterColumns> AdvanceFilterColumnList { get; set; }      
       
    }

}
