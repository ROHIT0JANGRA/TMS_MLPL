using System;
using System.ComponentModel.DataAnnotations;


namespace CodeLock.Models
{
    public class ExpenseRegister
    {
        [Display(Name = "Report Type")]
        public byte ReportType { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNos { get; set; }

        [Display(Name = "Manual Document No")]
        public string ManualDocumentNos { get; set; }

    }
    public class ExpenseRegisterExcelData
    {
        public string ThcNo { get; set; }
        public string ThcDate { get; set; }
        public string PickupID { get; set; }
        public string Origin { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string TransportMode { get; set; }
        public string BookingType { get; set; }
        public string BusinessType { get; set; }
        public string ConsignorName { get; set; }
        public string ConsigneeName { get; set; }
        public string ThcVendorName { get; set; }
        public string VendorLR { get; set; }
        public string FtlType { get; set; }
        public string TripsheetNo { get; set; }
        public string ThcVehicleNo { get; set; }
        public int Packages { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ChargedWeight { get; set; }
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
        public decimal ThcAmount { get; set; }
        public string VendorManualBillNo { get; set; }
        public string VendorBillNo { get; set; }
        public string VendorBillDate { get; set; }


    }

    public class ExpenseRegisterModel
    {

        public string VendorName { get; set; }
        public string PanNo { get; set; }
        public string DocumentNo { get; set; }
        public string ManualDocumentNo { get; set; }
        public string TripsheetNo { get; set; }
        public string LocationOfDocument { get; set; }
        public string RouteName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentDate { get; set; }
        public string VehicleNo { get; set; }
        public decimal ContractAmount { get; set; }
        public int NumberOfCnotesMovedTotalcountofLRS { get; set; }
        public decimal TotalActualWeight { get; set; }
        public decimal TotalChargedWeight { get; set; }
        public decimal Capacity { get; set; }
        public decimal BasicFreightLRS { get; set; }
        public decimal SubTotalofLRS { get; set; }
        public decimal GrandTotalLRS { get; set; }
        public string AdvanceLocation { get; set; }
        public decimal AdvanceAmount { get; set; }
        public string IsMultiAdvance { get; set; }
        public string AdvanceVoucherNo { get; set; }
        public string AdvanceVoucherDate { get; set; }
        public string AdvancePaymentMode { get; set; }
        public string AdvanceChequeNo { get; set; }
        public string AdvanceChequeDate { get; set; }
        public string AdvanceBankName { get; set; }
        public decimal AdvancePending { get; set; }
        public decimal BalanceAmount { get; set; }
        public string BalanceLocation { get; set; }
        public string BalanceBillNo { get; set; }
        public string BalanceBillDate { get; set; }
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