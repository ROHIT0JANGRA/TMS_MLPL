//  
// Type: CodeLock.Models.SalesRegister
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class SalesRegister
    {
        [Display(Name = "Company")]
        public string CompanyId { get; set; }

        public byte BaseOn { get; set; }

        [Display(Name = "Report Type")]
        public short ReportTypeId { get; set; }

        [Display(Name = "From Location")]
        public short FromLocationId { get; set; }

        [Display(Name = "Destination Location")]
        public short ToLocationId { get; set; }

        [Display(Name = "Payment Basis")]
        public string PaybasId { get; set; }

        [Display(Name = "Transit Mode")]
        public string TransportModeId { get; set; }

        [Display(Name = "Service Type")]
        [Required(ErrorMessage = "Please select Service Type")]
        public byte ServiceTypeId { get; set; }

        [Display(Name = "Business Type")]
        [Required(ErrorMessage = "Please select Business Type")]
        public byte BusinessTypeId { get; set; }

        [Display(Name = "Booked By")]
        public string IsBookedByBa { get; set; }

        [Display(Name = "Booked By Code")]
        public string BookedByCode { get; set; }

        public short BookedById { get; set; }

        [Display(Name = "Load Type")]
        public string LoadTypeId { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Pickup Delivery")]
        public string PickupDeliveryTypeId { get; set; }

        public short CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string DocketNo { get; set; }

        public string CustomerDocketNo { get; set; }

        [Display(Name = "Sort Order By")]
        public bool SortByDocketNo { get; set; }

        public bool AllDocketField { get; set; }

        public bool AllDocketCharges { get; set; }

        public bool AllReportField { get; set; }

        public bool AllDeliveryMrCharge { get; set; }

        public string BillNo { get; set; }

        public string DeliveryMRNO { get; set; }

        public string ThcNo { get; set; }
        public string ManifestNo { get; set; }

        [Display(Name = "Vendor")]
        public short VendorId { get; set; }

        public string VendorCode { get; set; }

        public string VendorName { get; set; }

        public short ConsignorId { get; set; }
        public short ConsigneeId { get; set; }
        public CodeLock.Models.DocketCharge[] DocketCharge { get; set; }

    }

    public class SalesRegisterExcelData
    {
        public string LRNo { get; set; }
        public string PickupID { get; set; }
        public string VendorLR { get; set; }

        public string DocketDate { get; set; }
        public string Origin { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string TransportMode { get; set; }
        public string BookingType { get; set; }
        public string BusinessType { get; set; }
        public string ConsignorName { get; set; }
        public string ConsigneeName { get; set; }
        public string BillingPartyName { get; set; }
        public string FtlType { get; set; }
        public string TripsheetNo { get; set; }
        public int Packages { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ChargedWeight { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal GRCharges { get; set; }
        public decimal FuelSurchargeCharges { get; set; }
        public decimal FOVCharges { get; set; }
        public decimal UnloadingCharges { get; set; }
        public decimal PickupCharges { get; set; }
        public decimal DocketCharges { get; set; }
        public decimal DoorDeliveryCharges { get; set; }
        public decimal LoadingCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal HandlingCharges { get; set; }
        public decimal ParkingCharges { get; set; }
        public decimal TollCharges { get; set; }
        public decimal HaltingCharges { get; set; }
        public decimal GreenTaxCharges { get; set; }
        public decimal HamaliCharges { get; set; }
        public decimal ODACharges { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string VehicleNo { get; set; }

        public string VendorName { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceAmount { get; set; }
        public decimal CftRatio { get; set; }
        public decimal FreightRate { get; set; }
        public string RateType { get; set; }
        public decimal DetentionCharges { get; set; }
        public string ManualLRNo { get; set; }
        public string EntryDate { get; set; }
        public string DeliveryDate { get; set; }
        public string Edd { get; set; }
        public string ArriveDate { get; set; }
        public string Destination { get; set; }
        public string CurrentLocation { get; set; }
        public string NextLocation { get; set; }
        public string Paybas { get; set; }
        public string LoadType { get; set; }
        public string ProductType { get; set; }
        public string RiskType { get; set; }
        public string StockType { get; set; }
        public string DeliveryType { get; set; }
        public string FlowType { get; set; }
        public string PrivateMark { get; set; }
        public string DACC { get; set; }
        public string COD { get; set; }
        public string ConsignorCode { get; set; }
        public string ConsignorGstinNo { get; set; }
        public string ConsigneeCode { get; set; }
        public string ConsigneeGstinNo { get; set; }
        public string ConnectivityDate { get; set; }
        public string BillLocation { get; set; }
        public string InvoiceDate { get; set; }
        public string PartNo { get; set; }
        public string PartName { get; set; }
        public int PartQuantity { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string CustomerLrNo { get; set; }
        public string BookedBy { get; set; }
        public string BookedByName { get; set; }
        public decimal VehicleCapacity { get; set; }
    }

    public class SalesInvoiceRegisterExcelData
    {
        public string LRNo { get; set; }
        public string PickupID { get; set; }
        public string VendorLR { get; set; }

        public string DocketDate { get; set; }
        public string Origin { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string TransportMode { get; set; }
        public string BookingType { get; set; }
        public string BusinessType { get; set; }
        public string ConsignorName { get; set; }
        public string ConsigneeName { get; set; }
        public string BillingPartyName { get; set; }
        public string FtlType { get; set; }
        public string TripsheetNo { get; set; }
        public int Packages { get; set; }
        public decimal VolumetricWeight { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ChargedWeight { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal GRCharges { get; set; }
        public decimal FuelSurchargeCharges { get; set; }
        public decimal FOVCharges { get; set; }
        public decimal UnloadingCharges { get; set; }
        public decimal PickupCharges { get; set; }
        public decimal DocketCharges { get; set; }
        public decimal DoorDeliveryCharges { get; set; }
        public decimal LoadingCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal HandlingCharges { get; set; }
        public decimal ParkingCharges { get; set; }
        public decimal TollCharges { get; set; }
        public decimal HaltingCharges { get; set; }
        public decimal GreenTaxCharges { get; set; }
        public decimal HamaliCharges { get; set; }
        public decimal ODACharges { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string VehicleNo { get; set; }

        public string VendorName { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceAmount { get; set; }
        public decimal CftRatio { get; set; }
        public decimal FreightRate { get; set; }
        public string RateType { get; set; }
        public decimal DetentionCharges { get; set; }
        public string InvoiceDate { get; set; }
        public string EwayBillNo { get; set; }
        public string EwayBillIssueDate { get; set; }
        public string EwayBillExpiryDate { get; set; }

        public string ReferanceNo { get; set; }

        public string PartNo { get; set; }
        public string PartName { get; set; }
        public int PartQuantity { get; set; }
        public string PartPackingType { get; set; }
        public double Lenght { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }

        public string EwayBillExpDate { get; set; }
        public string DocketNo { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public string PickUpBranch { get; set; }
        public string GateWayBranch { get; set; }
        public string CurrentLocation { get; set; }
        public string CurrentStatus { get; set; }

        public string EwayBillErrorMessage { get; set; }
        public string ErrorDate { get; set; }



    }
}
