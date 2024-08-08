//  
// Type: CodeLock.Models.Drs
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class Drs : BaseModel
    {
        public Drs()
        {
            this.IsOda = false;
            this.FinacialStatus = (byte)0;
            this.DrsDocketList = new List<DrsDocket>();
            this.ErrorList = new List<DrsDocket>();
            this.ChargeList = new List<MasterCharge>();
            this.AdvBalPmtDtl = new List<DrsAdvBalPaymnt_Details>();
        }

        public string DocketNo { get; set; }

        [Display(Name = "Paybas")]
        [RequiredIf("DocketNo == ''", ErrorMessage = "Please select Paybas")]
        public byte? PaybasId { get; set; }

        [Display(Name = "Transport Mode")]
        //[Required(ErrorMessage = "Please enter Transport Mode")]
        public byte? TransportModeId { get; set; }

        [Display(Name = "Business Type")]
        public byte? BusinessTypeId { get; set; }

        [Display(Name = "Booked By")]
        public bool IsBookedByBa { get; set; }

        [Display(Name = "Is ODA")]
        public bool IsOda { get; set; }

        public long DrsId { get; set; }

        public string DrsNo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DRS Date")]
        [Required(ErrorMessage = "Please select DRS Date")]
        public DateTime DrsDate { get; set; }

        [StringLength(50, ErrorMessage = "Manual DRS No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "Manual DRS")]
        public string ManualDrsNo { get; set; }

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

        [Display(Name = "BA Vendor Code")]
        public short BaVendorId { get; set; }

        public string BaVendorCode { get; set; }

        [Display(Name = "BA Vendor Name")]
        public string BaVendorName { get; set; }

        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Supplier Name")]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Pan No")]
        [Required(ErrorMessage = "Please enter Pan No")]
        [PanNoAnnotation]
        public string PanNo { get; set; }

        [Display(Name = "Supplier Mobile No")]
        [MobileAnnotation]
        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Supplier Mobile No")]
        public string SupplierMobileNo { get; set; }

        //[RequiredIf("VendorTypeId == 3", ErrorMessage = "Please select Tripsheet")]
        [Display(Name = "Trip Sheet")]
        public int? TripsheetId { get; set; }

        [Display(Name = "Vehicle")]
        [Required(ErrorMessage = "Please select Vehicle")]
        public short? VehicleId { get; set; }

        [Display(Name = "Vehicle No")]
        [RequiredIf("VehicleId == 1", ErrorMessage = "Please enter Vehicle No")]
        public string VehicleNo { get; set; }

        //[Display(Name = "Tripsheet No")]
        //public long TripsheetId { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Please select Vehicle Type")]
        public short VehicleTypeId { get; set; }

        [Required(ErrorMessage = "Please select FTL Type")]
        [Display(Name = "FTL Type")]
        public short FtlTypeId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Vehicle Registration Date")]
        [Required(ErrorMessage = "Please select Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please enter Engine No")]
        [Display(Name = "Engine No")]
        public string EngineNo { get; set; }

        [Required(ErrorMessage = "Please enter Chasis No")]
        [Display(Name = "Chasis No")]
        public string ChassisNo { get; set; }

        [Required(ErrorMessage = "Please enter RC Book No")]
        [Display(Name = "RC Book No")]
        public string RcBookNo { get; set; }

        [Required(ErrorMessage = "Please select Insurance Validity Date")]
        [Display(Name = "Insurance Validity Date")]
        [DataType(DataType.DateTime)]
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
        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter Driver Name")]
        [Display(Name = "First Driver Name")]
        public string FirstDriverName { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Please enter Mobile No")]
        [MobileAnnotation]
        public string FirstDriverMobileNo { get; set; }

        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        [Display(Name = "License No")]
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

        [Display(Name = "Second Driver Name")]
        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [NameAnnotation]
        public string SecondDriverName { get; set; }

        [Display(Name = "Mobile No")]
        [MobileAnnotation]
        public string SecondDriverMobileNo { get; set; }

        [Display(Name = "License No")]
        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        public string SecondDriverLicenseNo { get; set; }

        [Display(Name = "Issue By RTO")]
        [StringLength(50, ErrorMessage = "RTO Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        public string SecondDriverLicenseIssueBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "License Validity Date")]
        public DateTime? SecondDriverLicenseValidityDate { get; set; }

        [Range(0.001, 10000000.0, ErrorMessage = "Please enter a value between 0 to 10000000")]
        [Required(ErrorMessage = "Please enter Starting KMs")]
        [Display(Name = "Starting KMs")]
        public int StartKm { get; set; }

        [Required(ErrorMessage = "Please enter End KMs")]
        [Display(Name = "End KMs")]
        [Range(0.001, 10000000.0, ErrorMessage = "Please enter a value between 0 to 10000000")]
        [AssertThat("StartKm < EndKm", ErrorMessage = "End Km is greater than Starting Km")]
        public int EndKm { get; set; }

        [Display(Name = "Outgoing Remark")]
        [Required(ErrorMessage = "Please enter Outgoing Remark")]
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

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter a value between 1 to 9999999999")]
        [Required(ErrorMessage = "Please enter Contract Amount")]
        [Display(Name = "Contract Amount")]
        public Decimal ContractAmount { get; set; }

        [Display(Name = "Balance Paid At")]
        public short BalanceLocationId { get; set; }

        [AssertThat("ContractAmount >= AdvanceAmount", ErrorMessage = "Advance Amount is must be less than or equal to Contract Amount")]
        [Display(Name = "Advance Amount")]
        [Range(0.0, 9999999999.0, ErrorMessage = "Please enter a value between 0 to 9999999999")]
        public Decimal AdvanceAmount { get; set; }

        [Display(Name = "Advance Paid At")]
        [RequiredIf("AdvanceAmount > 0 && IsMultiAdvApply == false", ErrorMessage = "Please enter Advance Paid Location")]
        //[RequiredIf("AdvanceAmount > 0", ErrorMessage = "Please enter Advance Paid Location")]
        public short? AdvanceLocationId { get; set; }

        public byte FinacialStatus { get; set; }

        [Display(Name = "Is Cancelled")]
        public bool IsCancelled { get; set; }

        public DateTime? CancelledDate { get; set; }

        public string CancelledReason { get; set; }

        [Required(ErrorMessage = "Please select Vendor Type")]
        [Display(Name = "Vendor Type")]
        public byte VendorTypeId { get; set; }

        [Display(Name = "DRS Entry Time")]
        public TimeSpan DRSEntryTime { get; set; }

        [Range(1.0, 999999999999.0, ErrorMessage = "Please enter Valid Vehicle Capacity")]
        [Display(Name = "Vehicle Capacity")]
        public Decimal VehicleCapacity { get; set; }

        [Required(ErrorMessage = "Please enter Balance Paid Location")]
        public string BalanceLocationCode { get; set; }

          [RequiredIf("AdvanceAmount > 0 && IsMultiAdvApply == false", ErrorMessage = "Please enter Advance Paid Location")]
        //[RequiredIf("AdvanceAmount > 0", ErrorMessage = "Please enter Advance Paid Location")]
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

        public List<DrsDocket> DrsDocketList { get; set; }
        public List<DrsDocket> dtDocketDetailsList { get; set; }    
        public List<DrsDocket> ErrorList { get; set; }
        public List<MasterCharge> ChargeList { get; set; }

        [Display(Name = "EWAY Bill No")]
        [Required(ErrorMessage = "Please enter EWAY Bill No")]
        [Range(1.0, 999999999999.0, ErrorMessage = "Please enter EWAY Bill No")]
        public string EwayBillNo { get; set; }

        [Display(Name = "EWAY Bill Issue Date")]
        public DateTime? EwayBillIssueDate { get; set; }

        [Display(Name = "EWAY Bill Expiry Date")]
        public DateTime? EwayBillExpiryDate { get; set; }

        [Display(Name = "Delivery By Same Vehicle")]
        public bool IsDeliveryThroughSameVehicle { get; set; }

        public string DrsStatus { get; set; }

        public bool IsDrsClose { get; set; }

        [Display(Name = "Select City")]
        public bool IsSelectCity { get; set; }

        public int? FromCityId { get; set; }
        public List<DrsAdvBalPaymnt_Details> AdvBalPmtDtl { get; set; }

       
        [RequiredIf("IsSelectCity == true", ErrorMessage = "Please enter City Name")]
        [Display(Name = "From City")]
        public string FromCityName { get; set; }

        public int? ToCityId { get; set; }

     
        [Display(Name = "To City")]
        [RequiredIf("IsSelectCity == true", ErrorMessage = "Please enter City Name")]
        public string ToCityName { get; set; }
        [Display(Name = "Is Multiadvance Apply")]
        public bool IsMultiAdvApply { get; set; }


        [Display(Name = "Total Labour Amount")]
        public Decimal TotalLabourAmount { get; set; }

        public string FinYear { get; set; }
        public string DeliveryPersonName { get; set; }
    }

 
public class DRSReportModel
    {
        public List<AdvanceFilterColumns> AdvanceFilterColumnList { get; set; }

    }



}
