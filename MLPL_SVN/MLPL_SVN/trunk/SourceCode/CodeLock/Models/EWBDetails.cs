using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CodeLock.Models
{
    public class EWBDetails
    {
        public double cessNonAdvolValue { get; set; }
        public double otherValue { get; set; }
        public double transactionType { get; set; }
        public double actToStateCode { get; set; }
        public double actFromStateCode { get; set; }
        public string vehicleType { get; set; }
        public string rejectStatus { get; set; }
        public double extendedTimes { get; set; }
        public double totInvValue { get; set; }
        public string validUpto { get; set; }
        public string resstatus { get; set; }
        public string errorCodes { get; set; }
        public string errorDesc { get; set; }
        public double actualDist { get; set; }
        public double cessValue { get; set; }
        public double cgstValue { get; set; }
        public string docDate { get; set; }
        public string docNo { get; set; }
        public string docType { get; set; }
        public string fromAddr1 { get; set; }
        public string fromAddr2 { get; set; }
        public string fromGstin { get; set; }
        public double fromPincode { get; set; }
        public string fromPlace { get; set; }
        public double fromStateCode { get; set; }
        public string fromTrdName { get; set; }
        public string genMode { get; set; }
        public double igstValue { get; set; }
        public double noValidDays { get; set; }
        public double sgstValue { get; set; }
        public string status { get; set; }
        public string subSupplyType { get; set; }
        public string supplyType { get; set; }
        public string toAddr1 { get; set; }
        public string toAddr2 { get; set; }
        public string toGstin { get; set; }
        public double toPincode { get; set; }
        public string toPlace { get; set; }
        public double toStateCode { get; set; }
        public string toTrdName { get; set; }
        public double totalValue { get; set; }
        public string transDocDate { get; set; }
        public string transDocNo { get; set; }
        public string transMode { get; set; }
        public string transporterId { get; set; }
        public string transporterName { get; set; }
        public string userGstin { get; set; }
        public long ewbNo { get; set; }
        public string ewayBillDate { get; set; }
        public List<ItemList> itemList { get; set; }
        public List<VehiclListDetail> VehiclListDetails { get; set; }
    }
    public class ItemList
    {
        public double cessNonAdvol { get; set; }
        public string productDesc { get; set; }
        public double cessRate { get; set; }
        public double cgstRate { get; set; }
        public double hsnCode { get; set; }
        public double igstRate { get; set; }
        public double productId { get; set; }
        public string productName { get; set; }
        public string qtyUnit { get; set; }
        public double quantity { get; set; }
        public double sgstRate { get; set; }
        public double taxableAmount { get; set; }
        public double itemNo { get; set; }
        public double cessAdvol { get; set; }
    }
    public class VehiclListDetail
    {
        public string groupNo { get; set; }
        public string enteredDate { get; set; }
        public int ewbNo { get; set; }
        public string updMode { get; set; }
        public string vehicleNo { get; set; }
        public string fromPlace { get; set; }
        public double fromState { get; set; }
        public double tripshtNo { get; set; }
        public string userGSTINTransin { get; set; }
        public string transMode { get; set; }
        public string transDocNo { get; set; }
        public string transDocDate { get; set; }
    }
}