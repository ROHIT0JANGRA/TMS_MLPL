using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class Packaging
    {
        RgpChallanModal RgpChallanModal { get; set; }
    }
     public class Item
    {
        public string ItemNo { get; set; }
        public string ItemDescription { get; set; }
        public string FromWH { get; set; }
        public string ToWH { get; set; }
        public string Location { get; set; }
        public int Qty { get; set; }
        public decimal InfoPrice { get; set; }
        public string TaxCat { get; set; }
        public bool Taxable { get; set; }
        public decimal GstAmt { get; set; }
        public decimal Total { get; set; }
    }

    public class RgpChallanModal
    {
        public int Series { get; set; }
        public string  CustomerCode { get; set; }
        public int CustomerId { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CardCode { get; set; }
        public string Comments { get; set; }
        public int PriceList { get; set; }
        public int SalesPersonCode { get; set; }
        public string FromWarehouse { get; set; }
        public int FromBranch { get; set; }

        public string ToWarehouse { get; set; }
        public int BPLID { get; set; }
        public string BPLName { get; set; }
        public string U_EInvReqS { get; set; }
        public string U_EBILLNO { get; set; }
        public DateTime? U_EBILLDATE { get; set; }
        public string U_EEwbVT { get; set; }
        public string U_VehicleNum { get; set; }
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
        public string U_TransporterName { get; set; }
        public string U_Inward { get; set; }
        public string U_OutWard { get; set; }
        public string U_RGPNO { get; set; }
        public string U_InvoiceNo { get; set; }
        public DateTime? U_InvDate { get; set; }
        public string U_PartNo { get; set; }
        public double U_PartQty { get; set; }
        public List<Item> Item { get; set; }
        public int WarehouseId { get; set; }
    }
}