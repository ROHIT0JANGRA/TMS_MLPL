//  
// Type: CodeLock.Models.Thc
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class Thc : BaseModel
    {
        public Thc()
        {
            this.IsEmptyVehicle = false;
            this.IsAdhoc = false;
            this.AdvBalPmtDtl = new List<ThcAdvBalPaymnt_Details>();
            this.InvoiceList = new List<DocketInvoice>();
            this.LRList = new List<DocketInvoice>();

        }
        public List<DocketInvoice> LRList { get; set; }
        [Display(Name = "Transport Mode")]
        [Required(ErrorMessage = "Please select Transport Mode")]
        public byte TransportModeId { get; set; }

        [Display(Name = "Route")]
        [Required(ErrorMessage = "Please select Transport Route")]
        public short RouteId { get; set; }

        public long ThcId { get; set; }

        [Display(Name = "THC No")]
        public string ThcNo { get; set; }

        [Required(ErrorMessage = "Please select THC Date and Time")]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [Display(Name = "THC Date")]
        [DataType(DataType.DateTime)]
        public DateTime ThcDateTime { get; set; }

        [Display(Name = "Pan No")]
        [PanNoAnnotation]
        public string PanNo { get; set; }

        public DateTime ThcDate { get; set; }

        [StringLength(50, ErrorMessage = "Manual THC No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "THC Manual/Vendor Docket No")]
        public string ManualThcNo { get; set; }

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public string RouteName { get; set; }

        public DateTime? ExpectedDepartureDate { get; set; }

        public DateTime? ActualDepartureDate { get; set; }

        public DateTime? ExpectedArrivalDate { get; set; }

        public DateTime? ActualArrivalDate { get; set; }

        public short FromLocationId { get; set; }

        public string FromLocationCode { get; set; }

        [Display(Name = "Location")]
        public string ToLocationCode { get; set; }

        public short ToLocationId { get; set; }

        public byte TransitTimeHour { get; set; }

        public int? FromCityId { get; set; }

       
        [RequiredIf("IsSelectCity == true", ErrorMessage = "Please enter City Name")]
        [Display(Name = "From City")]
        public string FromCityName { get; set; }

        public int? ToCityId { get; set; }

       
        [RequiredIf("IsSelectCity == true", ErrorMessage = "Please enter City Name")]
        [Display(Name = "To City")]
        public string ToCityName { get; set; }

        [Display(Name = "Is Empty Vehicle")]
        public bool IsEmptyVehicle { get; set; }

        [Display(Name = "Is Adhoc")]
        public bool IsAdhoc { get; set; }

        [Display(Name = "Vendor Type")]
        [Required(ErrorMessage = "Please select Vendor Type")]
        public short VendorTypeId { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "Please select Vendor")]
        public short VendorId { get; set; }

        [Display(Name = "Is Market Vehicle")]
        public bool IsMarketVehicle { get; set; }

        [Display(Name = "Select City")]
        public bool IsSelectCity { get; set; }

        [Display(Name = "Vehicle")]
        [RequiredIf("TransportModeId == 2", ErrorMessage = "Please select Vehicle")]
        public short? VehicleId { get; set; }

        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Vendor Name")]
        [NameAnnotation]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [NameAnnotation]
        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Supplier Name")]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [MobileAnnotation]
        [RequiredIf("VendorId == 1", ErrorMessage = "Please enter Supplier Mobile No")]
        [Display(Name = "Supplier Mobile No")]
        public string SupplierMobileNo { get; set; }

        [Display(Name = "Vehicle No")]
        [RequiredIf("VehicleId == 1", ErrorMessage = "Please enter Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "Tripsheet No")]
        public long TripsheetId { get; set; }

        [RequiredIf("TransportModeId == 2", ErrorMessage = "Please select Vehicle Type")]
        [Display(Name = "Vehicle Type")]
        public short? VehicleTypeId { get; set; }

        [Display(Name = "FTL Type")]
        [RequiredIf("TransportModeId == 2", ErrorMessage = "Please select FTL Type")]
        public short? FtlTypeId { get; set; }

        [Display(Name = "Vehicle Registration No")]
        public string VehicleRegistrationNo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Vehicle Registration Date")]
        [Required(ErrorMessage = "Please select Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [RequiredIf("TransportModeId == 2", ErrorMessage = "Please enter Engine No")]
        [Display(Name = "Engine No")]
        public string EngineNo { get; set; }

        [RequiredIf("TransportModeId == 2", ErrorMessage = "Please enter Chasis No")]
        [Display(Name = "Chasis No")]
        public string ChassisNo { get; set; }

        [RequiredIf("TransportModeId == 2", ErrorMessage = "Please enter RC Book No")]
        [Display(Name = "RC Book No")]
        public string RcBookNo { get; set; }

        [Required(ErrorMessage = "Please select Insurance Validity Date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Insurance Validity Date")]
        public DateTime InsuranceValidityDate { get; set; }

        [Required(ErrorMessage = "Please select Fitness Validity Date")]
        [Display(Name = "Fitness Validity Date")]
        [DataType(DataType.DateTime)]
        public DateTime FitnessValidityDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Vehicle Permit Validity Date")]
        [Required(ErrorMessage = "Please select Vehicle Permit Validity Date")]
        public DateTime PermitValidityDate { get; set; }

        public string EwayBillNo { get; set; }

        public DateTime? EwayBillIssueDate { get; set; }

        public DateTime? EwayBillExpiryDate { get; set; }

        [StringLength(50, ErrorMessage = "Driver Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "First Driver Name")]
        [NameAnnotation]
        [Required(ErrorMessage = "Please enter Driver Name")]
        public string FirstDriverName { get; set; }

        [Required(ErrorMessage = "Please enter Mobile No")]
        [MobileAnnotation]
        [Display(Name = "Mobile No")]
        public string FirstDriverMobileNo { get; set; }

        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        [Display(Name = "License No")]
        [Required(ErrorMessage = "Please enter License No")]
        public string FirstDriverLicenseNo { get; set; }

        [StringLength(50, ErrorMessage = "RTO Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter RTO Name")]
        [NameAnnotation]
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

        [MobileAnnotation]
        [Display(Name = "Mobile No")]
        public string SecondDriverMobileNo { get; set; }

        [Display(Name = "License No")]
        [StringLength(25, ErrorMessage = "License No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
        public string SecondDriverLicenseNo { get; set; }

        [StringLength(50, ErrorMessage = "RTO Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "Issue By RTO")]
        [NameAnnotation]
        public string SecondDriverLicenseIssueBy { get; set; }

        [Display(Name = "License Validity Date")]
        [DataType(DataType.DateTime)]
        public DateTime? SecondDriverLicenseValidityDate { get; set; }

        [RequiredIf("TransportModeId == 1", ErrorMessage = "Please Select AirPort")]
        [Display(Name = "Airport")]
        public byte? AirportId { get; set; }

        [Display(Name = "Airline")]
        [RequiredIf("TransportModeId == 1", ErrorMessage = "Please Select Airline")]
        public byte? AirlineId { get; set; }

        [Display(Name = "Flight")]
        [RequiredIf("TransportModeId == 1", ErrorMessage = "Please Select Flight")]
        public byte? FlightId { get; set; }

        [Display(Name = "AWB No")]
        [RequiredIf("TransportModeId == 1", ErrorMessage = "Please Select AWB no")]
        public string AwbNo { get; set; }

        [Display(Name = "Schedule Departure Time")]
        public TimeSpan ScheduleDepartureTime { get; set; }

        [Display(Name = "Train Name")]
        [NameAnnotation]
        [RequiredIf("TransportModeId == 3", ErrorMessage = "Please enter Train Name")]
        public string TrainName { get; set; }

        [Display(Name = "Train No")]
        [RequiredIf("TransportModeId == 3", ErrorMessage = "Please Select Train no")]
        public string TrainNo { get; set; }

        [Required(ErrorMessage = "Please enter Contract Amount")]
        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Contract Amount must be greater then 0")]
        [Display(Name = "Contract Amount")]
        public Decimal ContractAmount { get; set; }

        [Display(Name = "Balance Paid At")]
        public short BalanceLocationId { get; set; }

        [Display(Name = "Advance Amount")]
        [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Advance Amount between 0 to 9999999999")]
        [AssertThat("ContractAmount >= AdvanceAmount", ErrorMessage = "Advance Amount is must be less than or equal to Contract Amount")]
        public Decimal AdvanceAmount { get; set; }


        [Display(Name = "Advance Paid At")]
        [RequiredIf("AdvanceAmount > 0 && IsMultiAdvApply == false", ErrorMessage = "Please enter Advance Paid Location")]
        public short? AdvanceLocationId { get; set; }

        public string FinacialStatus { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime? CancelledDate { get; set; }

        public string CancelledReason { get; set; }

        public bool IsThcUpdated { get; set; }

        [Display(Name = "Arrival Date")]
        public string ArrivalDate { get; set; }

        [Display(Name = "Arrival Location")]
        public string ArrivalLocationCode { get; set; }

        [Display(Name = "Vehicle Capacity")]
        [Range(1.0, 999999999999.0, ErrorMessage = "Please enter Valid Vehicle Capacity")]
        public Decimal VehicleCapacity { get; set; }

        [Required(ErrorMessage = "Please enter Balance Paid Location")]
        public string BalanceLocationCode { get; set; }

        [RequiredIf("AdvanceAmount > 0 && IsMultiAdvApply == false", ErrorMessage = "Please enter Advance Paid Location")]
        public string AdvanceLocationCode { get; set; }

        [Display(Name = "Telephone Charge")]
        public Decimal TelephoneCharge { get; set; }

        [Display(Name = "Humali Charge")]
        public Decimal HumaliCharge { get; set; }

        [Display(Name = "Mamul Charge")]
        public Decimal MamulCharge { get; set; }

        [AssertThat("ManifestCount > 0", ErrorMessage = "Please select any one Manifest")]
        public short ManifestCount { get; set; }

        [Display(Name = "Total Manifest")]
        [AssertThat("TotalManifest > 0", ErrorMessage = "Manifest Not Available")]
        public short TotalManifest { get; set; }

        public short TotalDocket { get; set; }

        public Decimal OtherAmount { get; set; }

        public int StartKm { get; set; }

        [Required(ErrorMessage = "Please enter Outgoing Seal No. 1")]
        [Display(Name = "Outgoing Seal No. 1")]
        public string OutgoingSealNo { get; set; }


        public string OutgoingRemark { get; set; }

        public bool IsOverLoaded { get; set; }

        public byte? OverLoadedReasonId { get; set; }

        public ThcSummary ThcSummary { get; set; }

        public List<ThcManifestDetail> ThcManifestDetailList { get; set; }

        public List<MasterCharge> ChargeList { get; set; }

        public List<ThcAdvBalPaymnt_Details> AdvBalPmtDtl { get; set; }

        [Display(Name = "Document Type")]
        public byte DocumentTypeId { get; set; }
        [Display(Name = "Actual Weight")]
        public decimal TotalActualWeight { get; set; }
        [Display(Name = "Kanta Weight")]
        public decimal KantaWeight { get; set; }
        [Display(Name = "Slip No.")]
        public string SlipNo { get; set; }
        [Display(Name = "Reason For Weight Loss")]
        public string ReasonForWeightLoss { get; set; }
        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Manual Document No")]
        public string ManualDocumentNo { get; set; }
        [Display(Name = "Is Multiadvance Apply")]
        public bool IsMultiAdvApply { get; set; }
        [Display(Name = "RR No.")]
        public string RRNo { get; set; }
        public string FinYear { get; set; }


        public int Tosave { get; set; }
        public int ServiceTypeId { get; set; }

        //

        public List<DocketInvoice> InvoiceList { get; set; }
        public int Packages { get; set; }
        public decimal ChargedWeight { get; set; }
        public bool IsBill { get; set; }
        [Display(Name = "Is Fuel Apply")]
        public bool IsFuelApply { get; set; }

        [Display(Name = "Fuel Vendor ")]
        
        public short FuelVendorId { get; set; }

        //[Display(Name = "Fuel Amount")]
        //public decimal FuelAmount { get; set; }
        [Display(Name = "Fuel Slip No.")]
        public string FuelSlipNo { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [Display(Name = "Slip Date")]
        [DataType(DataType.DateTime)]
        public DateTime FuelSlipDate { get; set; }
        //public DateTime SlipDate { get; set; }

        [Display(Name = "Fuel Rate")]
        public decimal Rate { get; set; }

        [Display(Name = "Quantity.")]
        public decimal Quantity { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Fuel Type ")]
        public short FuelTypeId { get; set; }

        [Display(Name = "TDS Rule")]
        [Required(ErrorMessage = "Please select TDS Rule")]
        public short TDSRuleId { get; set; }
        [Display(Name = "TDS Amount")]
        public decimal TDSAmount { get; set; }

    }

    public class ManifestReport
    {
        public int SRNo { get; set; }
        public string ManifestNo { get; set; }
        public string ManifestDate { get; set; }
        public string ManifestTime { get; set; }
        public string DocketNo { get; set; }
        public string ManualManifestNo { get; set; }
        public string Location { get; set; }
        public string NextLocation { get; set; }
        public int TotalDocket { get; set; }
        public int TotalPackages { get; set; }
        public decimal TotalActualWeight { get; set; }
        public string IsCancel { get; set; }
        public string CancelDate { get; set; }
        public string CancelReason { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string Company { get; set; }
        public string IsThc { get; set; }
        public string CancelBy { get; set; }
        public string LoadingSheetNo { get; set; }
        public string IsLabourDC { get; set; }
        public string IsLabourBilling { get; set; }
        public decimal TotalLabourAmount { get; set; }
        public string Vendor { get; set; }
        public decimal TotalDeliveryKartAmount { get; set; }
        public decimal TotalDeliveryLabourAmount { get; set; }
        public string IsUseInBilling { get; set; }
        public string Remarks { get; set; }
    }
    public class THCReport
    {
        public int SRNo { get; set; }
        public string ThcNo { get; set; }
        public string THCDate { get; set; }
        public string THCTime { get; set; }
        public string ManifestNo { get; set; }
        public string ManualThcNo { get; set; }
        public string TransportMode { get; set; }
        public string Route { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string CurrentLocation { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string IsEmptyVehicle { get; set; }
        public string IsAdhoc { get; set; }
        public string VendorName { get; set; }
        public string SupplierName { get; set; }
        public string SupplierMobileNo { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleTypeName { get; set; }
        public string RegistrationDate { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string RcBookNo { get; set; }
        public string InsuranceValidityDate { get; set; }
        public string FitnessValidityDate { get; set; }
        public string PermitValidityDate { get; set; }
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
        public int AirportId { get; set; }
        public int AirlineId { get; set; }
        public int FlightId { get; set; }
        public string AwbNo { get; set; }
        public string TrainName { get; set; }
        public string TrainNo { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public int BalanceLocationId { get; set; }
        public string AdvancedLocation { get; set; }
        public string FinacialStatus { get; set; }
        public string IsCancel { get; set; }
        public string CancelDate { get; set; }
        public string CancelReason { get; set; }
        public string Company { get; set; }
        public decimal OtherAmount { get; set; }
        public string CancelBy { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string LocationUpdatedBy { get; set; }
        public DateTime LocationUpdatedDate { get; set; }
        public string IsOutCapacity { get; set; }
        public string IsLabourBilling { get; set; }
        public string IsMultiAdvApply { get; set; }
        public string PanNo { get; set; }
        public decimal TotalActualWeight { get; set; }
        public decimal KantaWeight { get; set; }
        public string SlipNo { get; set; }
        public string ReasonForWeightLoss { get; set; }
        public string IsAdvancePaymentDone { get; set; }
        public int TDSRuleId { get; set; }
        public decimal TDSAmount { get; set; }
        public decimal TdsAmountOnAdvance { get; set; }
        public string IsFuelApply { get; set; }
        public string FuelVendor { get; set; }
        public string FuelSlipDate { get; set; }
        public decimal FuelSlipQuantity { get; set; }
        public decimal FuelSlipAmount { get; set; }
        public string FuelSlipNo { get; set; }
        public decimal BalanceAmount { get; set; }
    }
    public class ArrivalReport
    {
        public int SRNo { get; set; }
        public string ThcNo { get; set; }
        public string THCDate { get; set; }
        public string THCTime { get; set; }
        public string ManifestNo { get; set; }
        public string ManualThcNo { get; set; }
        public string TransportMode { get; set; }
        public string Route { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string CurrentLocation { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string IsEmptyVehicle { get; set; }
        public string IsAdhoc { get; set; }
        public string VendorName { get; set; }
        public string SupplierName { get; set; }
        public string SupplierMobileNo { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleTypeName { get; set; }
        public string RegistrationDate { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string RcBookNo { get; set; }
        public string InsuranceValidityDate { get; set; }
        public string FitnessValidityDate { get; set; }
        public string PermitValidityDate { get; set; }
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
        public string AirportId { get; set; }
        public string AirlineId { get; set; }
        public string FlightId { get; set; }
        public string AwbNo { get; set; }
        public string TrainName { get; set; }
        public string TrainNo { get; set; }
        public string ContractAmount { get; set; }
        public string AdvanceAmount { get; set; }
        public string AdvancedLocation { get; set; }
        public string FinacialStatus { get; set; }
        public string IsCancel { get; set; }
        public string CancelDate { get; set; }
        public string CancelReason { get; set; }
        public string Company { get; set; }
        public string OtherAmount { get; set; }
        public string CancelBy { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string LocationUpdatedBy { get; set; }
        public string LocationUpdatedDate { get; set; }
        public string IsOutCapacity { get; set; }
        public string IsLabourBilling { get; set; }
        public string IsMultiAdvApply { get; set; }
        public string PanNo { get; set; }
        public decimal TotalActualWeight { get; set; }
        public decimal KantaWeight { get; set; }
        public string SlipNo { get; set; }
        public string ReasonForWeightLoss { get; set; }
        public string IsAdvancePaymentDone { get; set; }
        public int TDSRuleId { get; set; }
        public decimal TDSAmount { get; set; }
        public decimal TdsAmountOnAdvance { get; set; }
        public string IsFuelApply { get; set; }
        public string FuelVendor { get; set; }
        public string FuelSlipDate { get; set; }
        public decimal FuelSlipQuantity { get; set; }
        public decimal FuelSlipAmount { get; set; }
        public string FuelSlipNo { get; set; }
        public decimal BalanceAmount { get; set; }
    }

    public class PODPendingReport
    {
        public int SRNo { get; set; }
        public string ThcNo { get; set; }
        public string THCDate { get; set; }
        public string THCTime { get; set; }
        public string ManifestNo { get; set; }
        public string ManualThcNo { get; set; }
        public string TransportMode { get; set; }
        public string Route { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string CurrentLocation { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string IsEmptyVehicle { get; set; }
        public string IsAdhoc { get; set; }
        public string VendorName { get; set; }
        public string SupplierName { get; set; }
        public string SupplierMobileNo { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleTypeName { get; set; }
        public string RegistrationDate { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string RcBookNo { get; set; }
        public string InsuranceValidityDate { get; set; }
        public string FitnessValidityDate { get; set; }
        public string PermitValidityDate { get; set; }
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
        public string AwbNo { get; set; }
        public string TrainName { get; set; }
        public string TrainNo { get; set; }
        public string ContractAmount { get; set; }
        public string AdvanceAmount { get; set; }
        public string AdvancedLocation { get; set; }
        public string BalanceLocation { get; set; }
        public string FinacialStatus { get; set; }
        public string IsCancel { get; set; }
        public string CancelDate { get; set; }
        public string CancelReason { get; set; }
        public string Company { get; set; }
        public string OtherAmount { get; set; }
        public string CancelBy { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string LocationUpdatedBy { get; set; }
        public string LocationUpdatedDate { get; set; }
        public string IsOutCapacity { get; set; }
        public string IsLabourBilling { get; set; }
        public string IsMultiAdvApply { get; set; }
        public string PanNo { get; set; }
        public decimal TotalActualWeight { get; set; }
        public decimal KantaWeight { get; set; }
        public string SlipNo { get; set; }
        public string ReasonForWeightLoss { get; set; }
        public string IsAdvancePaymentDone { get; set; }
        public decimal TDSAmount { get; set; }
        public decimal TdsAmountOnAdvance { get; set; }
        public string IsFuelApply { get; set; }
        public string FuelVendor { get; set; }
        public string FuelSlipDate { get; set; }
        public decimal FuelSlipQuantity { get; set; }
        public decimal FuelSlipAmount { get; set; }
        public string FuelSlipNo { get; set; }
        public decimal BalanceAmount { get; set; }
    }



}
