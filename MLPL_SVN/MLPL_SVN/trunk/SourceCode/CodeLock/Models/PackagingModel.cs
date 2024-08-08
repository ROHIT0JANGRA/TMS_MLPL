using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class PackagingModel
    {
        public PackagingModel()
        {
            StockTransferLines = new List<StockTransferLine>();
        }

        public int DocEntry { get; set; }
        public int Series { get; set; }
        public string Printed { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Comments { get; set; }
        public string JournalMemo { get; set; }
        public int PriceList { get; set; }
        public int SalesPersonCode { get; set; }
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int FinancialPeriod { get; set; }
        public int TransNum { get; set; }
        public int DocNum { get; set; }
        public DateTime TaxDate { get; set; }
        public int ContactPerson { get; set; }
        public string FolioPrefixString { get; set; }
        public int? FolioNumber { get; set; }
        public string DocObjectCode { get; set; }
        public string AuthorizationStatus { get; set; }
        public int BPLID { get; set; }
        public string BPLName { get; set; }
        public string VATRegNum { get; set; }
        public string AuthorizationCode { get; set; }
        public DateTime? StartDeliveryDate { get; set; }
        public TimeSpan? StartDeliveryTime { get; set; }
        public DateTime? EndDeliveryDate { get; set; }
        public TimeSpan? EndDeliveryTime { get; set; }
        public string VehiclePlate { get; set; }
        public string ATDocumentType { get; set; }
        public string EDocExportFormat { get; set; }
        public string ElecCommStatus { get; set; }
        public string ElecCommMessage { get; set; }
        public string PointOfIssueCode { get; set; }
        public string Letter { get; set; }
        public int? FolioNumberFrom { get; set; }
        public int? FolioNumberTo { get; set; }
        public int? AttachmentEntry { get; set; }
        public string DocumentStatus { get; set; }
        public string ShipToCode { get; set; }
        public string SAPPassport { get; set; }
        public int? LastPageFolioNumber { get; set; }
        public string U_EInvReqS { get; set; }
        public string U_ErrCode { get; set; }
        public string U_EStatus { get; set; }
        public string U_EGSTIN { get; set; }
        public string U_EDocNum { get; set; }
        public DateTime? U_EDocDate { get; set; }
        public string U_Irn { get; set; }
        public DateTime? U_AckDate { get; set; }
        public string U_AckNo { get; set; }
        public string U_IrnStat { get; set; }
        public string U_InfoDtls { get; set; }
        public string U_SignQRCod { get; set; }
        public string U_SignInv { get; set; }
        public string U_EBILLNO { get; set; }
        public DateTime? U_EBILLDATE { get; set; }
        public string U_EEwbVT { get; set; }
        public string U_ErrMsg { get; set; }
        public string U_ARENTRY { get; set; }
        public string U_REF { get; set; }
        public string U_ORDRREF { get; set; }
        public string U_ORDRUSER { get; set; }
        public string U_VehicleNum { get; set; }
        public string U_DeliveryTerm { get; set; }
        public double U_Grosswt { get; set; }
        public string U_FreeText { get; set; }
        public double U_NetWt { get; set; }
        public string U_EWAYBILLS { get; set; }
        public string U_EwayBill { get; set; }
        public string U_SupplyType { get; set; }
        public string U_VehicleNo { get; set; }
        public string U_TrnspID { get; set; }
        public string U_TrnspName { get; set; }
        public string U_GRNo { get; set; }
        public DateTime? U_GRDate { get; set; }
        public string U_DrMobile { get; set; }
        public string U_InvType { get; set; }
        public string U_TransID { get; set; }
        public double U_Distance { get; set; }
        public string U_Transdocno { get; set; }
        public string U_Vehcile { get; set; }
        public string U_VehType { get; set; }
        public string U_Terms { get; set; }
        public string U_BillToAddress { get; set; }
        public string U_TransporterName { get; set; }
        public string U_Inward { get; set; }
        public string U_OutWard { get; set; }
        public string U_RGPNO { get; set; }
        public string U_InvoiceNo { get; set; }
        public DateTime? U_InvDate { get; set; }
        public string U_PartNo { get; set; }
        public double U_PartQty { get; set; }
        public List<StockTransferLine> StockTransferLines { get; set; }
        public StockTransferTaxExtension StockTransferTaxExtension { get; set; }
        public List<object> DocumentReferences { get; set; }

        // Additional fields for view model usage
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string SeriesName { get; set; }
        public int Skip { get; set; }
        public int Count { get; set; }
        [Display(Name = "Bill Address")]
        public short? CustomerAddressId { get; set; }
        public int CustomerId { get; set; }
        public string VehicalNo { get; set; }
    }

    public class StockTransferLine
    {
        public int LineNum { get; set; }
        public int DocEntry { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public double DiscountPercent { get; set; }
        public string VendorNum { get; set; }
        public string SerialNumber { get; set; }
        public string WarehouseCode { get; set; }
        public string FromWarehouseCode { get; set; }
        public string ProjectCode { get; set; }
        public double Factor { get; set; }
        public double Factor2 { get; set; }
        public double Factor3 { get; set; }
        public double Factor4 { get; set; }
        public string DistributionRule { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public string UseBaseUnits { get; set; }
        public string MeasureUnit { get; set; }
        public double UnitsOfMeasurement { get; set; }
        public string BaseType { get; set; }
        public int? BaseLine { get; set; }
        public int? BaseEntry { get; set; }
        public double UnitPrice { get; set; }
        public int UoMEntry { get; set; }
        public string UoMCode { get; set; }
        public double InventoryQuantity { get; set; }
        public double RemainingOpenQuantity { get; set; }
        public double RemainingOpenInventoryQuantity { get; set; }
        public string LineStatus { get; set; }
        public string U_COMPOSITION { get; set; }
        public double U_Quantity { get; set; }
        public List<object> SerialNumbers { get; set; }
        public List<object> BatchNumbers { get; set; }
        public List<object> CCDNumbers { get; set; }
        public List<object> StockTransferLinesBinAllocations { get; set; }
    }

    public class StockTransferTaxExtension
    {
        public string SupportVAT { get; set; }
        public string FormNumber { get; set; }
        public string TransactionCategory { get; set; }
        public string U_PANNoS { get; set; }
        public string U_PANNoB { get; set; }
    }

    //public class RgpChallanModal
    //{
    //    public int Series { get; set; }
    //    public string  CustomerCode { get; set; }
    //    public int CustomerId { get; set; }
    //    public DateTime DocDate { get; set; }
    //    public DateTime DueDate { get; set; }
    //    public string CardCode { get; set; }
    //    public string CardName { get; set; }

    //    public string Comments { get; set; }
    //    public int PriceList { get; set; }
    //    public int SalesPersonCode { get; set; }
    //    public string FromWarehouse { get; set; }
    //    public int FromBranch { get; set; }

    //    public string ToWarehouse { get; set; }
    //    public int BPLID { get; set; }
    //    public string BPLName { get; set; }
    //    public string U_EInvReqS { get; set; }
    //    public string U_EBILLNO { get; set; }
    //    public DateTime? U_EBILLDATE { get; set; }
    //    public string U_EEwbVT { get; set; }
    //    public string U_VehicleNum { get; set; }
    //    public string U_EWAYBILLS { get; set; }
    //    public string U_EwayBill { get; set; }
    //    public string U_SupplyType { get; set; }
    //    public string U_VehicleNo { get; set; }
    //    public string U_TrnspID { get; set; }
    //    public string U_TrnspName { get; set; }
    //    public string U_GRNo { get; set; }
    //    public DateTime? U_GRDate { get; set; }
    //    public string U_DrMobile { get; set; }
    //    public string U_InvType { get; set; }
    //    public string U_TransID { get; set; }
    //    public double U_Distance { get; set; }
    //    public string U_Transdocno { get; set; }
    //    public string U_Vehcile { get; set; }
    //    public string U_VehType { get; set; }
    //    public string U_TransporterName { get; set; }
    //    public string U_Inward { get; set; }
    //    public string U_OutWard { get; set; }
    //    public string U_RGPNO { get; set; }
    //    public string U_InvoiceNo { get; set; }
    //    public DateTime? U_InvDate { get; set; }
    //    public string U_PartNo { get; set; }
    //    public double U_PartQty { get; set; }
    //    public List<Item> Item { get; set; }
    //    public int WarehouseId { get; set; }
    //    public int Skip {  get; set; }
    //    public int Count { get; set; }

    //}
}