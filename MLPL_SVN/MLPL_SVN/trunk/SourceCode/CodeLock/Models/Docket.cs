using DocumentFormat.OpenXml.VariantTypes;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class DocketBarcodeDetail
    {
        public string DocketId { get; set; }
        public string DocketNo { get; set; }
        public string DocketDate { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string BarCode { get; set; }
        public string sno { get; set; }
        public string ConsignorName { get; set; }
        public string ConsigneeName { get; set; }
        public string Pkt { get; set; }

    }

    public class RecalculateDetail
    {
        public string DocketId { get; set; }
        public int Packages { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ChargeWeight { get; set; }
        public decimal FreightRate { get; set; }
        public decimal Freight { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }

    public class DocketEdit
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }


    }
    public class DocketSearch
    {
        public DocketSearch()
        {
            this.DocketList = new List<DocketSearchDetail>();
        }
        public List<DocketSearchDetail> DocketList { get; set; }
    }
    public class DocketSearchDetail
    {
        public string DocketId { get; set; }
        public short EntryBy { get; set; }
    }
    public class Docket : BaseModel
    {
        public Docket()
        {
            this.InvoiceList = new List<DocketInvoice>();
            this.InvoiceVolumetricList = new List<InvoiceVolumetric>();
            this.DocumentList = new List<DocketDocument>();
            this.ChargeList = new List<MasterCharge>();
            this.TaxList = new List<MasterTax>();
            this.GPROList = new List<DocketGPRO_Details>();
        }

        [Required(ErrorMessage = "Please enter pin code")]
        public string PinCode { get; set; }
        public string PincodeId { get; set; }

        public bool IsSuccessfull { get; set; }
        public string ErrorMessage { get; set; }
        public string StepSelection { get; set; }
       // public string AllowUpdate { get; set; }
        [Display(Name = "Fixed Cost")]
        public bool IsFixedValue { get; set; }
        public List<RecalculateDetail> RecalculateList { get; set; }
        public string DocketNoSearch { get; set; }
        public string CompanyName { get; set; }
        public long DocketId { get; set; }

        [Display(Name = "Trip")]
        public string TripRound { get; set; }

        [Display(Name = "Process Type")]
        public string FreightType { get; set; }
        public bool IsConsignorConsigneePartyMapping { get; set; }

        [Display(Name = "Is Old")]
        public bool IsOld { get; set; }

        public string CurrentLocationId { get; set; }
        public string DocumentName { get; set; }
        public string VehicleStatus { get; set; }

        public string DocketStatus { get; set; }

        public short ContractId { get; set; }

        public short FreightContractId { get; set; }

        [Display(Name = "Entry Type")]
        public string DocketType { get; set; }

        // [DisplayName("Docket", "DocketNo")]
        [Display(Name = "Docket No")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DocketNo { get; set; }

        [Display(Name = "Docket Suffix")]
        public string DocketSuffix { get; set; }

        [Display(Name = "Docket Date Time")]
        //[DisplayName("Docket", "DocketDateTime")]
        public DateTime DocketDateTime { get; set; }

        public DateTime DocketDate { get; set; }

        public TimeSpan DocketTime { get; set; }

        [Display(Name = "Paybas")]
        [Required(ErrorMessage = "Please select Paybas")]
        public byte PaybasId { get; set; }

        public string Paybas { get; set; }

        [Required(ErrorMessage = "Please select Contract Party")]
        [Display(Name = "Contract Party Code")]
        public string CustomerCode { get; set; }

        public short CustomerId { get; set; }

        public short PaymentCustomerId { get; set; }
        
        //[Required(ErrorMessage = "Please select Contract Party")]
        [Display(Name = "Contract Party Code")]
        public string PaymentCustomerCode { get; set; }


        [Display(Name = "Contract Party Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Contract Party Name")]
        public string PaymentCustomerName { get; set; }

        [Display(Name = "From Location")]
        //[DisplayName("Docket", "FromLocation")]
        public string FromLocation { get; set; }

        public short FromLocationId { get; set; }

        public string FromLocationCode { get; set; }

        [Display(Name = "To Location")]
        //[DisplayName("Docket", "ToLocation")]
        public string ToLocation { get; set; }

        public short ToLocationId { get; set; }

        [Display(Name = "Vehicle No")]
        public short? VehicleId { get; set; }

        [Display(Name = "Vendor Type")]
        public byte VendorTypeId { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "WMS Invoice No")]
        public string WmsInvoiceNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }

        public bool LoadingSheetStatus { get; set; }

        public bool ManifestStatus { get; set; }

        public bool PrsStatus { get; set; }

        public bool IsBilled { get; set; }

        public bool UsePreviousHistory { get; set; }

        public bool UseAddressCode { get; set; }

        public bool IsAdd { get; set; }

        public bool IsFinancialUpdate { get; set; }

        public bool IsWalkInConsignorSaveInSystem { get; set; }

        [Display(Name = "Consignor Details")]
        public bool IsConsignorFromMaster { get; set; }
        [Display(Name = "Consignor Details")]
        public bool IsConsignorGst { get; set; }
        public string ConsignorFrom { get; set; }

        [Display(Name = "Consignor GST IN No")]
        public long ConsignorGstId { get; set; }

        [Display(Name = "Consignor GST IN No")]
        [StringLength(15, ErrorMessage = "Gst No. must be 15 character long", MinimumLength = 15)]
        public string ConsignorGstTinNo { get; set; }

        [Display(Name = "Consignor Group Code")]
        [Required(ErrorMessage = "Please select Consignor Group Code")]
        public string ConsignorGroupCode { get; set; }

        [Display(Name = "Consignor")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please select Consignor")]
        public string ConsignorCode { get; set; }

        public short ConsignorId { get; set; }

        [Display(Name = "Consignor Name")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please enter Consignor Name")]
        public string ConsignorName { get; set; }

        [Display(Name = "Consignor Address Code")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsignorAddressCode { get; set; }

        public short ConsignorAddressId { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignor Address 1")]
        [Required(ErrorMessage = "Please enter Consignor Address 1")]
        public string ConsignorAddress1 { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignor Address 2")]
        //[Required(ErrorMessage = "Please enter Consignor Address 2")]
        public string ConsignorAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter Consignor City")]
        [Display(Name = "Consignor City")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsignorCity { get; set; }

        public int ConsignorCityId { get; set; }

        [Required(ErrorMessage = "Please enter Consignor Pincode")]
        [Display(Name = "Consignor Pincode")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(6, ErrorMessage = "Consignor Pincode  must be 6 character long", MinimumLength = 6)]
        public string ConsignorPincode { get; set; }

        [MobileAnnotation]
        [Display(Name = "Consignor Mobile No")]
        [Required(ErrorMessage = "Please enter Consignor Mobile No")]
        //[StringLength(10, ErrorMessage = "Consignor Mobile No  must be 10 character long", MinimumLength = 10)]
        //[DisplayName("Docket", "ConsignorMobileNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsignorMobileNo { get; set; }

        [MobileAnnotation]
        [Display(Name = "Consignor Mobile No")]
        [Required(ErrorMessage = "Please enter Consignor Mobile No")]
        [StringLength(10, ErrorMessage = "Consignor Mobile No  must be 10 character long", MinimumLength = 10)]
        //[DisplayName("Docket", "ConsignorMobileNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsignorSearchMobileNo { get; set; }

        [PanNoAnnotation]
        //[Required(ErrorMessage = "Please enter Consignor PanNo")]
        [Display(Name = "Consignor Pan No")]
        public string ConsignorSearchPanNo { get; set; }

        [PanNoAnnotation]
        [Display(Name = "Consignor Pan No")]
        [Required(ErrorMessage = "Please enter Consignor Pan No")]
        public string ConsignorPanNo { get; set; }


        [Display(Name = "Consignor Phone No")]
        [Required(ErrorMessage = "Please enter Consignor Phone No")]
        public string ConsignorPhoneNo { get; set; }
        [Display(Name = "Consignor Email Id")]
        // [DisplayName("Docket", "ConsignorEmailId")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsignorEmailId { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignor IN No")]
        //[DisplayName("Docket", "ConsignorTinNo")]
        public string ConsignorTinNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignor Cst No")]
        //        [DisplayName("Docket", "ConsignorCstNo")]
        public string ConsignorCstNo { get; set; }

        public bool IsWalkInConsigneeSaveInSystem { get; set; }

        [Display(Name = "Consignee Details")]
        public bool IsConsigneeFromMaster { get; set; }
        [Display(Name = "Consignee Details")]
        public bool IsConsigneeGst { get; set; }
        
        public string ConsigneeFrom { get; set; }

        [Display(Name = "Consignee GST IN No")]
        public long ConsigneeGstId { get; set; }

        [Display(Name = "Consignee GST IN No")]
        [StringLength(15, ErrorMessage = "Gst No. must be 15 character long", MinimumLength = 15)]
        public string ConsigneeGstTinNo { get; set; }

        [Display(Name = "Consignee Group Code")]
        [Required(ErrorMessage = "Please select Consignee Group Code")]
        public string ConsigneeGroupCode { get; set; }

        [Display(Name = "Consignee")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please select Consignee")]
        public string ConsigneeCode { get; set; }

        public short ConsigneeId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please enter Consignee Name")]
        [Display(Name = "Consignee Name")]
        public string ConsigneeName { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignee Address Code")]
        public string ConsigneeAddressCode { get; set; }

        public short ConsigneeAddressId { get; set; }

        [Required(ErrorMessage = "Please enter Consignee Address 1")]
        [Display(Name = "Consignee Address 1")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsigneeAddress1 { get; set; }

        //[Required(ErrorMessage = "Please enter Consignee Address 2")]
        [Display(Name = "Consignee Address 2")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsigneeAddress2 { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please enter Consignee City")]
        [Display(Name = "Consignee City")]
        public string ConsigneeCity { get; set; }

        public int ConsigneeCityId { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please enter Consignee Pincode")]
        [Display(Name = "Consignee Pincode")]
        [StringLength(6, ErrorMessage = "Consignor Pincode  must be 6 character long", MinimumLength = 6)]
        public string ConsigneePincode { get; set; }

        [MobileAnnotation]
        [Display(Name = "Consignee Mobile No")]
        [Required(ErrorMessage = "Please enter Consignee Mobile No")]
        public string ConsigneeSearchMobileNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignee Mobile No")]
        [Required(ErrorMessage = "Please enter Consignee Mobile No")]
        [StringLength(10, ErrorMessage = "Consignee Mobile No  must be 10 character long", MinimumLength = 10)]
        //       [DisplayName("Docket", "ConsigneeMobileNo")]
        public string ConsigneeMobileNo { get; set; }

        [PanNoAnnotation]
        //[Required(ErrorMessage = "Please enter Consignee PanNo")]
        [Display(Name = "Consignee PanNo")]
        public string ConsigneeSearchPanNo { get; set; }

        [PanNoAnnotation]
        [Required(ErrorMessage = "Please enter Consignee PanNo")]
        [Display(Name = "Consignee Pan No")]
        public string ConsigneePanNo { get; set; }

        [Display(Name = "Consignee Phone No")]
        [Required(ErrorMessage = "Please enter Consignee Phone No")]
        public string ConsigneePhoneNo { get; set; }
        [Display(Name = "Consignee Email Id")]

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        // [DisplayName("Docket", "ConsigneeEmailId")]
        public string ConsigneeEmailId { get; set; }

        [Display(Name = "Billing Party ")]

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        // [DisplayName("Docket", "ConsigneeEmailId")]
        public string BillingPartyId { get; set; }

        [Display(Name = "Mapped Billing Party ")]
        public short MappingBillingPartyId { get; set; }

        [Display(Name = "Consignee IN No")]
        //        [DisplayName("Docket", "ConsigneeTinNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ConsigneeTinNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Consignee Cst No")]
        //  [DisplayName("Docket", "ConsigneeCstNo")]
        public string ConsigneeCstNo { get; set; }

        [Required(ErrorMessage = "Please select Transport Mode")]
        [Display(Name = "Transport Mode")]
        public byte TransportModeId { get; set; }

        [Display(Name = "Transport Mode")]
        public string TransportMode { get; set; }

        [Display(Name = "Service Type")]
        [Required(ErrorMessage = "Please select Service Type")]
        public byte ServiceTypeId { get; set; }

        public string ServiceType { get; set; }

        [Required(ErrorMessage = "Please select FTL Type")]
        [Display(Name = "FTL Type")]
        public byte FtlTypeId { get; set; }

        public string FtlType { get; set; }

        [Required(ErrorMessage = "Please select Pickup Delivery")]
        [Display(Name = "Pickup Delivery")]
        public byte PickupDeliveryTypeId { get; set; }

        public string PickupDeliveryType { get; set; }

        [Display(Name = "From City")]

        // [DisplayName("Docket", "FromCity")]
        public string FromCity { get; set; }

        public int FromCityId { get; set; }

        [Display(Name = "To City")]
        //    [DisplayName("Docket", "ToCity")]
        public string ToCity { get; set; }

        public int ToCityId { get; set; }

        [Display(Name = "Product Type Id")]
        //[DisplayName("Docket", "ProductTypeId")]
        [Required(ErrorMessage = "Please select {0}")]
        public long ProductTypeId { get; set; }

        public string ProductType { get; set; }

        [Required(ErrorMessage = "Please select {0}")]
        [Display(Name = "Packaging Type Id")]
        //[DisplayName("Docket", "PackagingTypeId")]
        public byte PackagingTypeId { get; set; }

        public string PackagingType { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Remarks")]
        // [DisplayName("Docket", "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Volumetric")]
        public bool IsVolumetric { get; set; }

        [Display(Name = "Part Volumetric")]
        public bool IsPartVolumetric { get; set; }

        [Display(Name = "COD")]
        public bool IsCod { get; set; }

        [Display(Name = "ODA")]
        public bool IsOda { get; set; }

        [Display(Name = "Local")]
        public bool IsLocal { get; set; }

        [Display(Name = "Load Type")]
        //   [DisplayName("Docket", "LoadTypeId")]
        public byte LoadTypeId { get; set; }

        public string LoadType { get; set; }

        [Display(Name = "Division")]
        //  [DisplayName("Docket", "DivisionId")]
        public byte DivisionId { get; set; }

        public string Division { get; set; }

        [Display(Name = "Business Type")]
        //       [DisplayName("Docket", "BusinessTypeId")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public byte BusinessTypeId { get; set; }

        public string BusinessType { get; set; }

        [Display(Name = "DACC")]
        public bool IsDacc { get; set; }

        [Display(Name = "Permit")]
        public bool IsPermit { get; set; }

        [Display(Name = "Deferment")]
        public bool IsDeferment { get; set; }

        [Display(Name = "Industry")]
        //     [DisplayName("Docket", "IndustryId")]
        public byte IndustryId { get; set; }

        public string Industry { get; set; }

        [Display(Name = "Multi Pickup")]
        public bool IsMultiPickup { get; set; }

        [Display(Name = "Multi Delivery")]
        public bool IsMultiDelivery { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [RequiredIf("IsMultiPickup || IsMultiDelivery", ErrorMessage = "Please enter {0}")]
        [Display(Name = "Mother Docket No")]

        //     [DisplayName("Docket", "MotherDocketNo")]
        public string MotherDocketNo { get; set; }

        public long? MotherDocketId { get; set; }

        [Display(Name = "Pickup By Same Vehicle")]
        public bool IsPickupThroughSameVehicle { get; set; }
        [Display(Name = "Delivery By Same Vehicle")]
        public bool IsDeliveryThroughSameVehicle { get; set; }

        [Display(Name = "Risk Type")]
        public bool IsCarrierRisk { get; set; }

        public bool IsDoorDelivery { get; set; }

        [Display(Name = "Risk Type")]
        //  [DisplayName("Docket", "RiskType")]
        public string RiskType { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Policy No")]
        //[DisplayName("Docket", "PolicyNo")]
        public string PolicyNo { get; set; }

        [Display(Name = "Policy Date")]
        //    [DisplayName("Docket", "PolicyDate")]
        public DateTime? PolicyDate { get; set; }

        [Display(Name = "Mode at Covers")]
        //        [DisplayName("Docket", "ModvatCovers")]
        public Decimal ModvatCovers { get; set; }

        [Display(Name = "Internal Covers")]
        //[DisplayName("Docket", "InternalCovers")]
        public Decimal InternalCovers { get; set; }

        [Display(Name = "Customer Reference No")]
        //[DisplayName("Docket", "CustomerReferenceNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustomerReferenceNo { get; set; }

        [Display(Name = "Customer Reference Date")]
        //[DisplayName("Docket", "CustomerReferenceDate")]
        public DateTime? CustomerReferenceDate { get; set; }

        [Display(Name = "Customer Gatepass No")]
        //[DisplayName("Docket", "CustomerGatepassNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustomerGatepassNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Customer Delivery No")]
        //        [DisplayName("Docket", "CustomerDeliveryNo")]
        public string CustomerDeliveryNo { get; set; }

        [Display(Name = "Reference PO/Docket")]
        //[DisplayName("Docket", "PrivateMark")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PrivateMark { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "TP No")]
        //  [DisplayName("Docket", "TPNo")]
        public string TPNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Entry Sheet No")]
        //[DisplayName("Docket", "EntrysheetNo")]
        public string EntrysheetNo { get; set; }

        [Display(Name = "Obd No")]
        //     [DisplayName("Docket", "ObdNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ObdNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Engine No")]
        // [DisplayName("Docket", "EngineNo")]
        public string EngineNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Model No")]
        //       [DisplayName("Docket", "ModelNo")]
        public string ModelNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Gps No")]
        //[DisplayName("Docket", "GpsNo")]
        public string GpsNo { get; set; }

        [Display(Name = "Chassis No")]
        // [DisplayName("Docket", "ChassisNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ChassisNo { get; set; }

        //[Required(ErrorMessage = "Please select Permit Received At")]
        [Display(Name = "Permit Received At")]
        public string PermitReceivedAt { get; set; }

        [Display(Name = "Permit No")]
        //[Required(ErrorMessage = "Please enter No")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PermitNo { get; set; }

        //[Required(ErrorMessage = "Please select Permit Date")]
        [Display(Name = "Permit Date")]
        public DateTime PermitDate { get; set; }

        //[Required(ErrorMessage = "Please select Permit Validity Date")]
        [Display(Name = "Permit Validity Date")]
        public DateTime PermitValidityDate { get; set; }

        //[Required(ErrorMessage = "Please select Permit Received Date")]
        [Display(Name = "Permit Received Date")]
        public DateTime PermitReceivedDate { get; set; }

        public List<DocketDocument> DocumentList { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Part Quantity")]
        [Required(ErrorMessage = "Please enter Part Quantity")]
        public int PartQuantity { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Packages")]
        [Required(ErrorMessage = "Please enter Packages")]
        public int Packages { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Actual Weight")]
        [Required(ErrorMessage = "Please enter Actual Weight")]
        public Decimal ActualWeight { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Charged Weight")]
        [Required(ErrorMessage = "Please enter Charged Weight")]
        public Decimal ChargedWeight { get; set; }


        [Display(Name = "CFT Ratio")]
        public Decimal CftRatio { get; set; }

        public Decimal TotalCubic { get; set; }

        [Required(ErrorMessage = "Please select Docket Type")]
        [Display(Name = "Docket Type")]
        public string DocketFor { get; set; }

        [Display(Name = "BA Code")]
        public long VendorId { get; set; }

        [Display(Name = "BA Code")]
        [Required(ErrorMessage = "BA Code can't be blank")]
        public string VendorCode { get; set; }

        [Display(Name = "BA Name")]
        public string VendorName { get; set; }

        [Display(Name = "BA Billed")]
        public string BABilled { get; set; }

        public List<DocketInvoice> InvoiceList { get; set; }

        public List<InvoiceVolumetric> InvoiceVolumetricList { get; set; }

        public List<MasterCharge> ChargeList { get; set; }

        public List<MasterTax> TaxList { get; set; }

        public List<DocketGPRO_Details> GPROList { get; set; }

        //[Required(ErrorMessage = "Please enter Freight Amount")]
        [Display(Name = "Freight Amount")]
        public Decimal Freight { get; set; }

        [Display(Name = "Extra Freight")]
        public Decimal FreightExtra { get; set; }

        [Display(Name = "Freight Rate")]
        //[Required(ErrorMessage = "Please enter Freight Rate")]
        public Decimal FreightRate { get; set; }

        //[Required(ErrorMessage = "Please select Rate Type")]
        [Display(Name = "Rate Type")]
        public byte RateTypeId { get; set; }

        public string RateType { get; set; }

        public int Km { get; set; }

        [Display(Name = "KM")]
        public decimal FreightKM { get; set; }

        [Display(Name = "Extra KM")]
        public decimal FreightExtraKM { get; set; }

        [Display(Name = "Rate Per KM")]
        public Decimal FreightKMRate { get; set; }


        [Display(Name = "Rate Per Extra KM")]
        public Decimal FreightExtraRate { get; set; }

        [Display(Name = "Total")]
        public Decimal FreightKMTotal { get; set; }

        public byte TransitDays { get; set; }

        [Required(ErrorMessage = "Please select Bill Location")]
        [Display(Name = "Bill Location")]
        public string BillLocation { get; set; }

        public short BillLocationId { get; set; }

        public short BillLocationRule { get; set; }

        [Display(Name = "EDD")]
        public DateTime Edd { get; set; }

        [Display(Name = "Service Tax No")]
        // [DisplayName("Docket", "ServiceTaxRegisterNo")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ServiceTaxRegisterNo { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Local Service Tax No")]
        //     [DisplayName("Docket", "LocalServiceTaxRegisterNo")]
        public string LocalServiceTaxRegisterNo { get; set; }

        [Display(Name = "Service Tax Exempted")]
        public bool IsServiceTaxExempted { get; set; }

        [Display(Name = "Gst Payer")]
        //[Required(ErrorMessage = "Please select GST Payer")]
        public byte GstPayerId { get; set; }

        public string GstPayer { get; set; }

        public byte FovRateTypeId { get; set; }

        public Decimal Fov { get; set; }

        public Decimal FovRate { get; set; }

        public bool IsBooking { get; set; }

        [Display(Name = "GST Exemption")]
        public bool IsGst { get; set; }

        [Display(Name = "GST Billing Party")]
        public string GstBillingParty { get; set; }

        [Required(ErrorMessage = "Please select Party GST State")]
        [Display(Name = "Party GST State")]
        public string GstState { get; set; }

        public short GstStateId { get; set; }

        public long? PartyGstId { get; set; }

        [Display(Name = "Company GST State")]
        [Required(ErrorMessage = "Please select Company GST State")]
        public string CompanyGstState { get; set; }

        public short CompanyGstStateId { get; set; }

        public long? CompanyGstId { get; set; }

        [Display(Name = "Company GSTIN No")]
        public string CompanyGstTinNo { get; set; }

        [Display(Name = "SAC Category")]
        public string GstSacName { get; set; }

        public byte GstSacId { get; set; }

        [Display(Name = "Service Type")]
        public string GstServiceType { get; set; }

        public byte GstServiceTypeId { get; set; }

        [Display(Name = "GST Payer")]
        public bool IsBillingPartyGstPayer { get; set; }

        public string GstPayerName { get; set; }

        public byte GstPaidById { get; set; }

        [Required(ErrorMessage = "Please enter Party GSTIN No")]
        [Display(Name = "Party GSTIN No")]
        public string GstTinNo { get; set; }

        [Required(ErrorMessage = "Please enter Party PAN No")]
        [Display(Name = "Party PAN No")]
        public string PartyPanNo { get; set; }

        [Required(ErrorMessage = "Please select Declaration File")]
        [Display(Name = "GST Exemption Declaration File")]
        [RegularExpression("([a-zA-Z0-9\\s_\\\\.\\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase GstExemptionDeclarationFile { get; set; }

        [Display(Name = "GST Exemption Declaration File")]
        public string GstExemptionDeclarationFileName { get; set; }

        [Display(Name = "Inter/Intra State")]
        public bool IsInterState { get; set; }
        public bool IsAppointChargeApplicable { get; set; }


        public string InterState { get; set; }

        [Display(Name = "GST Rate")]
        public Decimal GstRate { get; set; }

        [Display(Name = "GST Amount")]
        public Decimal GstAmount { get; set; }

        [Display(Name = "RCM Applicable")]
        public bool IsRcm { get; set; }

        [Display(Name = "GST Charged")]
        public Decimal GstCharged { get; set; }

        [Display(Name = "Sub Total")]
        public Decimal SubTotal { get; set; }

        [Display(Name = "Tax Total")]
        public Decimal TaxTotal { get; set; }

        [Display(Name = "Grand Total")]
        public Decimal GrandTotal { get; set; }

        [Display(Name = "Total Part Quantity")]
        public Decimal TotalPartQuantity { get; set; }

        public bool IsPartyGstStateIsUnionTerritory { get; set; }

        public bool IsCompanyGstStateIsUnionTerritory { get; set; }

        [Display(Name = "Upload Status")]
        public string UploadStatus { get; set; }

        public string handlingChargedWeight { get; set; }

        [RequiredIf("ServiceTypeId == 3", ErrorMessage = "Please select Contract Slab")]
        [Display(Name = "Contract Slab")]
        public string ContractSlabId { get; set; }

        public Decimal CODCollectableAmount { get; set; }
        //


        [Required(ErrorMessage = "Please select Apply Rate Type")]
        [Display(Name = "Apply Rate Type")]
        public string ApplyRateType { get; set; }

        [Required(ErrorMessage = "Please select Booking Type")]
        [Display(Name = "Booking Type")]
        public string BookingTypeId { get; set; }

        [Display(Name = "Is DG Product")]
        public bool ISDGProduct { get; set; }


        [Display(Name = "FreightGM")]
        public Decimal FreightGM { get; set; }

        [Display(Name = "FreightKG")]
        public Decimal FreightKG { get; set; }

        [Display(Name = "Slab Type")]
        public string ContractSlabType { get; set; }

        [Display(Name = "HandOver Vendor")]
        public long HandOverVendorId { get; set; }

        [Display(Name = "Waybill No.")]
        public string WaybillNo { get; set; }
        public long PickupRequestId { get; set; }
        public long VendorContractId { get; set; }
        public decimal CftDivider { get; set; }
        public string DocketCopyFile { get; set; }

        [Display(Name = "Tripsheet No.")]
        public string TripsheetNo { get; set; }
        public DateTime TripsheetDate { get; set; }
        public string CustomerDocketNo { get; set; }
        public string PlantCode { get; set; }
        public string ContractParty { get; set; }
        public string ContractPartyName { get; set; }

        [Display(Name = "Carton No.")]
        public string CartonNo { get; set; }

        public string OrderNo { get; set; }
        public decimal PartAmount { get; set; }
        public int TotalDocket { get; set; }
        public int FilterDockets { get; set; }

        public string CustomerEmailId { get; set; }

        public int Tosave { get; set; }

        [Display(Name = "Cft Measurement Type")]
        [Required(ErrorMessage = "Please select Cft Measurement Type")]
        public string CftMeasurementType { get; set; }
        public string VolumetricWeightType { get; set; }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Bill No")]
        public DateTime BillDate { get; set; }

        public List<AutoCompleteResult> ServiceTypeList { get; set; }
        public List<AutoCompleteResult> FtlTypeList { get; set; }

        public string AllowUpdate { get; set; }

        public byte cnorCustomerTypeId { get; set; }
        public byte CneeCustomerTypeId { get; set; }

        [Display(Name = "Is Appointment Charge Applicable")]
        public bool IsAppointmentChargeIsApplicable { get; set; }
        public int Quantity { get; set; }

    }

    public class EwayBillDetails
    {
        public bool Success { get; set; }
        public string EwayBillDate { get; set; }
        public string EwayBillExpiryDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public bool IsUsed { get; set; }
        public string TotalInvoiceAmount { get; set; }
    }

    public class AuthorizationDetail
    {
        public string gspappid { get; set; }
        public string gspappsecret { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }

    }

    public class ResponseResult
    {
        public List<ApiDocketNewResponse> BookingDetail { get; set; }
    }
    public class ApiDocketNewResponse
    { 
        public string ReferenceNo { get; set; }
        public string DocketNo { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
    }

    public class DocketBarcodeInfo
    {
        public long DocketId { get; set; }
        public string DocketNo { get; set; }
        public string InvoiceNo { get; set; }
        public string PackageNo { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string ConsigneeName { get; set; }
        public string TotalBox { get; set; }
    }
        public class PickUpDetailRequest
    { 
        public string UserName { get; set; }
        public List<ApiPickUpDetail>PickUpDetails { get; set; }
    }
    public class ApiPickUpDetail
    {
        public string DocketNo { get; set; }
        public DateTime DocketDate { get; set; }
        public string RefNo { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
        public string ConsignorName { get; set; }
        public string ConsignorAddress { get; set; }
        public string ConsignorCity { get; set; }
        public string ConsignorPin { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string ConsigneeCity { get; set; }
        public string ConsigneePin { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string TransportMode { get; set; }
        public decimal ShipmentWeight { get; set; }
        public int NoOfCartons { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductValue { get; set; }
        public string RateType { get; set; }
        public short ConsignorId { get; set; }
        public short ConsigneeId { get; set; }
        public byte PaybasId { get; set; }
        public DateTime Edd { get; set; }
        public int ConsignorCityId { get; set; }
        public int ConsigneeCityId { get; set; }
        public byte TransportModeId { get; set; }
        public short ContractId { get; set; }
        public bool IsLocal { get; set; }
        public string DocketType { get; set; }
        public byte BusinessTypeId { get; set; }
        public byte ServiceTypeId { get; set; }
        public short CustomerId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
     
        public DateTime EntryDate { get; set; }
        public short EntryBy { get; set; }
        public byte CompanyId { get; set; }
        public string PrivateMark { get; set; }
        public string Remarks { get; set; }
        public string OperationType { get; set; }

        public short BillLocationId { get; set; }
        public byte RateTypeId { get; set; }
        public decimal Freight { get; set; }
        public decimal FreightRate { get; set; }
        public decimal IGST { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal UGST { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public short ContractCustomerId { get; set; }

        public string EwayBillNo { get; set; }
        public List<DocketInvoice> InvoiceDetails { get; set; }
        public List<BoxDetail> BoxDetails { get; set; }
        public List<DocketInvoiceCarton> DocketInvoiceCartons { get; set; }

    }

    public class BoxDetail
    {
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public short Pkgs { get; set; }


    }

    #region ApiOrderUpload

    public class ApiDocketRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OperationType { get; set; }
        public DocumentDetail DocumentList { get; set; }

    }

    public class DocumentDetail
    {
        public DocumentDetail()
        {
            BillDetail = new ApiBillDetail();
        }
        public string PincodeId { get; set; }
        public string DocketType { get; set; }
        public bool IsOld { get; set; }
        public string DocketNo { get; set; }
        public string OrderNo { get; set; }
        public string OrderDateTime { get; set; }
        public DateTime DocketDateTime { get; set; }
        public long DocketId { get; set; }
        public short ContractId { get; set; }
        public short FreightContractId { get; set; }
        public bool IsAdd { get; set; }
        public byte PaybasId { get; set; }
        public string Paybas { get; set; }
        public string CustomerCode { get; set; }
        public string FromLocation { get; set; }
        public short FromLocationId { get; set; }
        public string FromLocationCode { get; set; }
        public string ToLocation { get; set; }
        public short ToLocationId { get; set; }
        public string WmsInvoiceNo { get; set; }
        public byte VendorTypeId { get; set; }
        public short? VehicleId { get; set; }
        public string VehicleNo { get; set; }
        public bool IsConsignorFromMaster { get; set; }
        public short ConsignorId { get; set; }
        public string ConsignorName { get; set; }
        public string ConsignorGstTinNo { get; set; }
        public string ConsignorGroupCode { get; set; }
        public string ConsignorCode { get; set; }
        public short ConsignorAddressId { get; set; }
        public string ConsignorAddress { get; set; }
        public string ConsignorAddressCode { get; set; }
        public string ConsignorAddress1 { get; set; }
        public string ConsignorAddress2 { get; set; }
        public int ConsignorCityId { get; set; }
        public string ConsignorCity { get; set; }
        public string ConsignorPincode { get; set; }
        public string ConsignorMobileNo { get; set; }
        public string ConsignorEmailId { get; set; }
        public bool IsConsigneeFromMaster { get; set; }
        public short ConsigneeId { get; set; }
        public string ConsigneeGstTinNo { get; set; }
        public string ConsigneeGroupCode { get; set; }
        public string ConsigneeCode { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddressCode { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public int ConsigneeCityId { get; set; }
        public string ConsigneeCity { get; set; }
        public string ConsigneePincode { get; set; }
        public string ConsigneeMobileNo { get; set; }
        public string ConsigneeEmailId { get; set; }
        public string BillingParty { get; set; }
        public byte TransportModeId { get; set; }
        public byte ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public byte FtlTypeId { get; set; }
        public string FtlType { get; set; }
        public byte PickupDeliveryTypeId { get; set; }
        public string PickupDelivery { get; set; }
        public string FromCity { get; set; }
        public int FromCityId { get; set; }
        public string ToCity { get; set; }
        public int ToCityId { get; set; }
        public byte PackagingTypeId { get; set; }
        public string PackagingType { get; set; }
        public long ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public Decimal ProductValue { get; set; }

        public string Remarks { get; set; }
        public string PrivateMark { get; set; }
        public byte BusinessTypeId { get; set; }
        public string CustomerReferenceNo { get; set; }
        public bool IsOda { get; set; }
        public bool IsPermit { get; set; }
        public bool IsLocal { get; set; }
        public bool IsVolumetric { get; set; }
        public bool IsCod { get; set; }
        public bool IsDacc { get; set; }
        public bool IsDeferment { get; set; }
        public byte IndustryId { get; set; }
        public byte LoadTypeId { get; set; }
        public byte DivisionId { get; set; }
        public bool IsMultiPickup { get; set; }
        public bool IsPodUploaded { get; set; }
        public bool IsMultiDelivery { get; set; }
        public long? MotherDocketId { get; set; }
        public string MotherDocketNo { get; set; }
        public bool IsPickupThroughSameVehicle { get; set; }
        public bool IsDeliveryThroughSameVehicle { get; set; }
        public bool IsCarrierRisk { get; set; }
        public string PolicyNo { get; set; }
        public DateTime PolicyDate { get; set; }
        public decimal ModvatCovers { get; set; }
        public decimal InternalCovers { get; set; }
        public DateTime CustomerReferenceDate { get; set; }
        public string CustomerGatepassNo { get; set; }
        public string CustomerDeliveryNo { get; set; }
        public string TPNo { get; set; }
        public string EntrysheetNo { get; set; }
        public string ObdNo { get; set; }
        public string EngineNo { get; set; }
        public string ModelNo { get; set; }
        public string GpsNo { get; set; }
        public string ChassisNo { get; set; }
        public string PermitNo { get; set; }
        public DateTime PermitDate { get; set; }
        public string PermitValidityDate { get; set; }
        public string PermitReceivedAt { get; set; }
        public DateTime PermitReceivedDate { get; set; }
        public decimal CftRatio { get; set; }
        public decimal TotalCubic { get; set; }
        public short Packages { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ChargedWeight { get; set; }
        public int Km { get; set; }
        public DateTime Edd { get; set; }
        public byte GstPayerId { get; set; }
        public string GstBillingParty { get; set; }
        public bool IsGst { get; set; }
        public HttpPostedFileBase GstExemptionDeclarationFile { get; set; }
        public short GstStateId { get; set; }
        public string GstState { get; set; }
        public string GstTinNo { get; set; }
        public string CompanyGstState { get; set; }
        public string CompanyGstTinNo { get; set; }
        public string TransportMode { get; set; }
        public string GstServiceType { get; set; }
        public string ServiceTaxRegisterNo { get; set; }
        public byte GstSacId { get; set; }
        public string GstSacName { get; set; }
        public bool IsRcm { get; set; }
        public bool IsInterState { get; set; }
        public bool IsAppointChargeApplicable { get; set; }
        public decimal GstRate { get; set; }
        public decimal GstAmount { get; set; }
        public decimal GstCharged { get; set; }
        public byte FovRateTypeId { get; set; }
        public decimal FovRate { get; set; }
        public decimal Fov { get; set; }
        public bool IsServiceTaxExempted { get; set; }
        public bool IsBillingPartyGstPayer { get; set; }
        public long? PartyGstId { get; set; }
        public long? CompanyGstId { get; set; }
        public bool IsBilled { get; set; }
        public short EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public long VendorId { get; set; }
        public string GstExemptionDeclarationFileName { get; set; }
        public string CurrentLocationId { get; set; }
        public byte CompanyId { get; set; }
        public short WarehouseId { get; set; }
        public bool IsActive { get; set; }
        public short CustomerId { get; set; }
        public string DocketStatus { get; set; }
        public string UploadStatus { get; set; }
        public ApiBillDetail BillDetail { get; set; }
        public byte RateTypeId { get; set; }
        public short BillLocationId { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonMobileNo { get; set; }
        public string ContactPersonTelephoneNo { get; set; }
        public string RefNo { get; set; }
     
        public List<DocketInvoice> InvoiceList { get; set; }
        public List<DocketInvoiceCarton> InvoiceCartonList { get; set; }

    }
    public class ApiBillDetail
    {
        public decimal FreightRate { get; set; }
        public byte RateTypeId { get; set; }
        public string RateType { get; set; }
        public decimal Freight { get; set; }
        public short BillLocationId { get; set; }
        public string BillLocation { get; set; }
        public string TransportName { get; set; }
        public string TransportGstinNo { get; set; }
        public decimal IGST { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal UGST { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }

    public class ApiDocketResponse
    {
        public string UploadStatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ApiDocketDataResponse Documents { get; set; }
    }
    public class ApiDocketDataResponse
    {
        public bool IsSuccess { get; set; }
        public short ReasonCode { get; set; }
        public string Message { get; set; }
        public string DocketNo { get; set; }
        public string OrderNo { get; set; }

    }
    public class ApiDocketResult
    {
        public bool IsSuccessfull { get; set; }
        public string DocumentNo { get; set; }
        public long DocumentId { get; set; }
    }
    #endregion 

    public class LatLog
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class DocketPackages
    { 
        public long DocketId { get; set; }
        public string PackagesNo { get; set; }
    }

    public class BookingReport
    {
        public int SRNo { get; set; }
        public string DocketNo { get; set; }
        public string DocketDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string TransportMode { get; set; }
        public string EDD { get; set; }
        public int Packages { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ChargedWeight { get; set; }
        public string BusinessType { get; set; }
        public string ServiceType { get; set; }
        public string CustomerReferenceNo { get; set; }
        public string EntryBy { get; set; }
        public string EntryDate { get; set; }
        public string IsCancel { get; set; }
        public string Company { get; set; }
        public string CancelDate { get; set; }
        public string CancelReason { get; set; }
        public string CancelBy { get; set; }
        public string IsTPL { get; set; }
        public string CustomerDocketNo { get; set; }
        public string IsOld { get; set; }
        public string DocketType { get; set; }
        public string IsBABilled { get; set; }
        public string IsClosed { get; set; }
        public string IsBADeliveryBilled { get; set; }
        public string ConsignorName { get; set; }
        public string ConsigneeName { get; set; }
        public int CustomerId { get; set; }
    }

}