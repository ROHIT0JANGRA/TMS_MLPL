//  
// Type: CodeLock.Models.Unloading
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class Unloading : Base
  {
    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public long UnloadingId { get; set; }

    [Display(Name = "Unloading No")]
    public string UnloadingNo { get; set; }

    [Display(Name = "Unloading Date")]
    public DateTime UnloadingDateTime { get; set; }

    [Display(Name = "Is Market Vehicle")]
    public bool IsMarketVehicle { get; set; }

    [Display(Name = "THC No(s)")]
    public string ThcNos { get; set; }

    public int FromCityId { get; set; }

    [Required(ErrorMessage = "Please enter From City")]
    [Display(Name = "From City")]
    public string FromCityName { get; set; }

    public int ToCityId { get; set; }

    [Required(ErrorMessage = "Please enter To City")]
    [Display(Name = "City Name")]
    public string ToCityName { get; set; }

    [Required(ErrorMessage = "Please select Warehouse")]
    [Display(Name = "Warehouse")]
    public new short WarehouseId { get; set; }

    public short DriverId { get; set; }

    [Required(ErrorMessage = "Please enter Driver Name")]
    [Display(Name = "Driver Name")]
    public string DriverName { get; set; }

    public short VehicleId { get; set; }

    [Required(ErrorMessage = "Please enter Vehicle No")]
    [Display(Name = "Vehicle No")]
    public string VehicleNo { get; set; }

    [Display(Name = "Account Head")]
    [Required(ErrorMessage = "Please select Account Head")]
    public short AccountId { get; set; }

    public string Remark { get; set; }

    [Display(Name = "Unloading Attachment")]
    public HttpPostedFileBase UnloadingAttachment { get; set; }

    public string UnloadingDocumentName { get; set; }

    [Display(Name = "Total Packages")]
    public Decimal TotalPackages { get; set; }

    [Display(Name = "Total Freight")]
    public Decimal TotalFreight { get; set; }

    [Display(Name = "Advance Freight")]
    public Decimal AdvanceFreight { get; set; }

    [Display(Name = "Balance Freight")]
    public Decimal BalanceFreight { get; set; }

    [Display(Name = "Loading Charges")]
    public Decimal LoadingCharges { get; set; }

    [Display(Name = "UnLoading Charges")]
    public Decimal UnLoadingCharges { get; set; }

    [Display(Name = "Total ActualWeight")]
    public Decimal TotalActualWeight { get; set; }

    [Display(Name = "Total Charged Weight")]
    public Decimal TotalChargedWeight { get; set; }

    [Display(Name = "Total Paid Amount")]
    public Decimal TotalPaidAmount { get; set; }

    [Display(Name = "Total Topay Amount")]
    public Decimal TotalTopayAmount { get; set; }

    [Display(Name = "Contract Amount")]
    public Decimal ContractAmount { get; set; }

    [Required(ErrorMessage = "Please enter Advance Amount")]
    [Display(Name = "Advance Amount")]
    public Decimal AdvanceAmount { get; set; }

    [Display(Name = "Balance Amount")]
    public Decimal BalanceAmount { get; set; }

    public bool IsCancel { get; set; }

    [Display(Name = "Delivery Commission")]
    public Decimal DeliveryCommission { get; set; }

    [Display(Name = "Door Delivery")]
    public Decimal DoorDelivery { get; set; }

    [Display(Name = "KART Amount")]
    public Decimal KartAmount { get; set; }

    public List<UnloadingDocket> UnloadingDocketList { get; set; }
  }
    public class UnLoadingSheet 
    { 
        public long LoadunloadId { get; set; }
        public string LoadUnloadNo { get; set; }
        public DateTime UnloadDate { get; set; }
        public string LocationCode { get; set; }
        public string ManifestNo { get; set; }
        public long ManifestId { get; set; }

        public string VehicleNo { get; set; }
    }
    public class UnloadingReportModel
    {
        public int SRNo { get; set; }
        public string UnloadingNo { get; set; }
        public string UnloadingDate { get; set; }
        public string Location { get; set; }
        public string IsMarketVehicle { get; set; }
        public string VehicleNo { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public int DriverId { get; set; }
        public int WarehouseId { get; set; }
        public int AccountId { get; set; }
        public string Remark { get; set; }
        public string UnloadingDocumentName { get; set; }
        public string Company { get; set; }
        public int TotalPackages { get; set; }
        public decimal TotalFreight { get; set; }
        public decimal LoadingCharges { get; set; }
        public decimal UnLoadingCharges { get; set; }
        public decimal TotalActualWeight { get; set; }
        public decimal TotalChargedWeight { get; set; }
        public decimal AdvanceFreight { get; set; }
        public decimal BalanceFreight { get; set; }
        public decimal DeliveryCommission { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalTopayAmount { get; set; }
        public decimal DoorDelivery { get; set; }
        public decimal KartAmount { get; set; }
        public string EntryBy { get; set; }
        public string EntryDate { get; set; }
        // New fields
        public decimal ClaimCharges { get; set; }
        public decimal DetentionCharges { get; set; }
        public decimal IncentiveCharges { get; set; }
        public decimal HandlingCharges { get; set; }
        public decimal PenaltyCharges { get; set; }
        public decimal GSTRate { get; set; }
        public decimal TaxAmountTotal { get; set; }
        public string TDSSection { get; set; }
        public decimal TDSRate { get; set; }
        public decimal TDSAmt { get; set; }
        public decimal BalanceBillAmount { get; set; }
        public string BalanceVoucherNo { get; set; }
        public string BalanceVoucherDate { get; set; }
        public string BalancePaymentMode { get; set; }
        public string BalanceChequeNo { get; set; }
        public string BalanceChequeDate { get; set; }
        public string BalanceBankName { get; set; }
        public string BalanceBillPaymentNo { get; set; }
        public decimal BalanceBillPaymentAmount { get; set; }
        public decimal PendingBillPayableAmt { get; set; }
        public string DocumentStatus { get; set; }
        public string TripOperationalStatus { get; set; }
        public string TripFinancialStatus { get; set; }
    }

}
