
using System.Collections.Generic;

namespace CodeLock.Models
{
  public class ChartDetail : Base
  {
        public ChartDetail()
        {
            this.FleetTripTotalGeneratedTripsList = new List<FleetTrip>();
            this.FleetTripPendingforOperationClosureList = new List<FleetTrip>();
            this.FleetTripTripPendingForFinanceClosureList = new List<FleetTrip>();

            this.FinReceTripsBillList = new List<CustomerBill>();
            this.FinReceTBBList = new List<CustomerBill>();
            this.FinRecePaidList = new List<CustomerBill>();
            this.FinReceToPayList = new List<CustomerBill>();

            this.FinCollTripsBillList = new List<CustomerBill>();
            this.FinCollTBBList = new List<CustomerBill>();
            this.FinCollPaidList = new List<CustomerBill>();
            this.FinCollToPayList = new List<CustomerBill>();

            this.BookedShipmentList = new List<Docket>();
            this.LSPendingForMFList = new List<Docket>();
            this.MFPendingForTHCList = new List<Docket>();

            this.VehiclePendingforUnloadList = new List<Docket>();
            this.ShipmentPendingforDeliveryList = new List<Docket>();
            this.DRSPendingForClosureList = new List<Docket>();

            this.ShipmentDeliveredPartiallyFailList = new List<Docket>();
            this.DeliveredButPODnotScannedList = new List<Docket>();
            this.PODScannedbutNotForwardList = new List<Docket>();
        }

        public string BookedShipment { get; set; }
    public string LSPendingForMF { get; set; }
    public string MFPendingForTHC { get; set; }
    public List<Docket> BookedShipmentList { get; set; }
    public List<Docket> LSPendingForMFList { get; set; }
    public List<Docket> MFPendingForTHCList { get; set; }

    public string VehiclePendingforUnload { get; set; }
    public string ShipmentPendingforDelivery { get; set; }
    public string DRSPendingForClosure { get; set; }

    public List<Docket> VehiclePendingforUnloadList { get; set; }
    public List<Docket> ShipmentPendingforDeliveryList { get; set; }
    public List<Docket> DRSPendingForClosureList { get; set; }
        //
        public string ShipmentDeliveredPartiallyFail { get; set; }
        public string DeliveredButPODnotScanned { get; set; }
        public string PODScannedbutNotForward { get; set; }
        public List<Docket> ShipmentDeliveredPartiallyFailList { get; set; }
        public List<Docket> DeliveredButPODnotScannedList { get; set; }
        public List<Docket> PODScannedbutNotForwardList { get; set; }

        
        
        //
        public string VehicleArrivedButNotDepart { get; set; }
        public string TransshipmentStock { get; set; }
        public string Stock { get; set; }

        public string CODDODNotCollected { get; set; }
        public string CODDODNotForwarded { get; set; }
        public string CODDOD { get; set; }

        public string FinReceTripsBill { get; set; }
        public string FinReceTBB { get; set; }
        public string FinRecePaid { get; set; }
        public string FinReceToPay { get; set; }

        public string FinCollTripsBill { get; set; }
        public string FinCollTBB { get; set; }
        public string FinCollPaid { get; set; }
        public string FinCollToPay { get; set; }

        public string FinAsseCashInHand { get; set; }
        public string FinAsseBankBalance { get; set; }
        public string FinAsseBalance { get; set; }
        public string FinAsseTotalCash { get; set; }

        public string FinPayaAdvancePayablePendingExpensesBooking { get; set; }
        public string FinPayaPendingVendorPayableTDSPayable { get; set; }

        public string FinPaymAdvancePaymentVendorBillPaid { get; set; }
        public string FinPaymTDSPaid { get; set; }

        public string FinFloaAdvicenotAcknowledge { get; set; }
        public string FinFloaChequenotReconcile { get; set; }
        //
        public string OnRoadVehicle { get; set; }
        public string UnderMaintenance { get; set; }
        public string WithoutDriver { get; set; }

        public string TotalAdvancePaid { get; set; }
        public string BalancePendingonDriver { get; set; }
        public string TotalFuelBill { get; set; }
        public string PendingVendorPayableTDSPayable { get; set; }

        public string FleetTripTotalGeneratedTrips { get; set; }
        public string FleetTripPendingforOperationClosure { get; set; }
        public string FleetTripTripPendingForFinanceClosure { get; set; }
        public List<CustomerBill> FinReceTripsBillList { get; set; }
        public List<CustomerBill> FinReceTBBList { get; set; }
        public List<CustomerBill> FinRecePaidList { get; set; }
        public List<CustomerBill> FinReceToPayList { get; set; }
        public List<CustomerBill> FinCollTripsBillList { get; set; }
        public List<CustomerBill> FinCollTBBList { get; set; }
        public List<CustomerBill> FinCollPaidList { get; set; }
        public List<CustomerBill> FinCollToPayList { get; set; }
        public List<FleetTrip> FleetTripTotalGeneratedTripsList { get; set; }
        public List<FleetTrip> FleetTripPendingforOperationClosureList { get; set; }
        public List<FleetTrip> FleetTripTripPendingForFinanceClosureList { get; set; }

    }
    public class FleetTrip
    {
        public string TripSheetNo { get; set; }
        public string TripSheetDate { get; set; }
        public string CustomerName { get; set; }
        public string VehicleNo { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string TripSheetStatus { get; set; }

    }

    public class PaybaseWiseDocketCount
    {
        public string Paybas { get; set; }
        public int DocketCount { get; set; }
    }

    public class CustomerSales
    {
        public string CustomerName { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal TotalPendingAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal GrandTotal { get; set; }
    }

    public class VendorBillWiseAmount
    {
        public string VendorName { get; set; }
        public decimal TotalBillAmount { get; set; }
    }

    public class MonthWiseDocketCount
    {
        public string Month { get; set; }
        public int DocketCount { get; set; }
    }

    public class LocationSale
    {
        public string Location { get; set; }
        public decimal GrandTotal { get; set; }
    }

    public class DocketDeliveryDetails
    {
        public string LocationCode { get; set; }
        public int InTimeCount { get; set; }
        public int LateCount { get; set; }
    }

    public class DocketDashboardDetails
    {
        public int TotalTransaction { get; set; }
        public int TotalSale { get; set; }
        public int SalesPerDay { get; set; }
        public int BilledCount { get; set; }
        public int UnBilledCount { get; set; }
        public int TotalDeliveryCount { get; set; }
        public int InTimeDeliveryRatio { get; set; }
        public int InTimeBookingRatio { get; set; }
        public int LateDeliveryRatio { get; set; }
    }

    public class DocketBillUnBilledDetails
    {
        public int BilledCount { get; set; }
        public int UnBilledCount { get; set; }
    }
}
