//  
// Type: CodeLock.ModuleHelper
//  
//  
//  

namespace CodeLock
{
    public static class ModuleHelper
    {
        public static readonly byte Docket = 1;
        public static readonly byte Prs = 2;
        public static readonly byte LoadingSheet = 3;
        public static readonly byte Manifest = 4;
        public static readonly byte Thc = 5;
        public static readonly byte Drs = 6;
        public static readonly byte Pod = 7;
        public static readonly byte Pfm = 8;
        public static readonly byte Vr = 9;
        public static readonly byte Deps = 10;
        public static readonly byte Unloading = 13;
        public static readonly short DocketTalk = 257;
        public static readonly byte ASN = 51;
        public static readonly byte GRN = 52;
        public static readonly byte Inspection = 53;
        public static readonly byte PutAway = 54;
        public static readonly byte Order = 55;
        public static readonly byte Pick = 56;
        public static readonly byte Dispatch = 57;
        public static readonly byte Repacking = 58;
        public static readonly byte GatePass = 162;
        public static readonly byte Tripsheet = 101;
        public static readonly byte DriverSettlement = 102;
        public static readonly byte CustomerBill = 151;
        public static readonly byte VendorBill = 152;
        public static readonly byte Voucher = 153;
        public static readonly byte Mr = 154;
        public static readonly byte AdvancePayment = 155;
        public static readonly byte BalancePayment = 156;
        public static readonly byte PurchaseOrder = 157;
        public static readonly byte DeliveryMr = 158;
        public static readonly byte Advice = 159;
        public static readonly byte CreditNote = 161;
        public static readonly byte DebitNote = 164;
        public static readonly byte CustomerVendorAdjustment = 166;
        public static readonly byte PasswordPolicy = 226;
        public static readonly byte CustomerContract = 227;
        public static readonly byte DeliveryMrDocket = 228;
        public static readonly short VendorContract = 229;
        public static readonly short Vendor = 230;

        public static object TripsheetCancellation { get; set; }
    }
}
