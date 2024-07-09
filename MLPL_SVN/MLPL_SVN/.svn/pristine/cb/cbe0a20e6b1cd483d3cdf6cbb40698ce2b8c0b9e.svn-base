//  
// Type: CodeLock.Areas.FMS.Repository.ITripsheetRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.FMS.Repository
{
    public interface ITripsheetRepository : IDisposable
    {

        Response InsertMilkRunTripsheet(MilkRunLogDetail objTripsheetClosure);
        MilkRunLogDetail GetMilkRunTripsheetDetails(string TripsheetNo);

        IEnumerable<Tracking_Details> GetVehicleTrackingId(
        string TripsheetId);
        Response VehicleTrackingInsert(VehicleTracking obj);
        IEnumerable<AutoCompleteResult> GetTrispeedListByVehicleNo(
            string vehicleId);
        IEnumerable<AutoCompleteResult> GetStatusReason(
        byte VehicleStatus);
        IEnumerable<GetVehicleStatusList> GetVehicleStatusDtl(long userId);
        IEnumerable<GetVehicleStatusList> GetVehicleStatusListDtl(long userId);
        MaintananceList GetMetnatancList(string VehicleNo);
        Response VehicleMaintenanceInsert(VehicleMaintenanceStatus objVehicleMaintenanceStatus);
        string GetNextFileName();
        Response VehicleStatusInsert(VehicleStatusDetail objVehicleStatusDetail, short LoginUserId);
        VehicleStatusDetail GetVehicleStatus(string VehicleNo);
        AutoCompleteResult IsChargeNameExistTripSheet(string chargeName, string TripsheetId);
        Response Insert(Tripsheet objTripsheet);

        Response Close(TripsheetClosure objTripsheetClosure);

        Response DriverSettlement(DriverSettlement objDriverSettlement);

        IEnumerable<DocketDetail> GetDocketListByVehicleNo(string vehicleNo);

        IEnumerable<ChecklistDetail> GetCheckList();

        bool IsFuelSlipNoAvailable(string fuelSlipNo, long tripsheetId);

        IEnumerable<Tripsheet> GetTripsheetListForClose(
          byte tripsheetAction,
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId);

        TripsheetClosure GetById(long id);

        IEnumerable<AutoCompleteResult> GetAutoCompleteChargeList(
          string chargeName);

        AutoCompleteResult IsChargeNameExist(string chargeName);

        IEnumerable<TripsheetAdvance> GetAdvanceDetail(long tripsheetId);

        IEnumerable<Tripsheet> GetTripsheetListForDriverSettlement(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId);

        IEnumerable<OilExpenses> GetTripsheetOilExpenseList(long tripsheetId);

        IEnumerable<EnRouteExpenses> GetTripsheetEnrouteExpenseList(
          long tripsheetId);

        IEnumerable<VehicleLogDetail> GetTripsheetVehicleLogList(
          long tripsheetId);

        IEnumerable<OilExpenses> GetOilExpenseDetailAgaintsCash(long tripsheetId);

        IEnumerable<EnRouteExpenses> GetEnRouteExpenseDetail(long tripsheetId);

        IEnumerable<Tripsheet> GetTripsheetListForDriverAdvance(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId);

        Response DriverAdvanceInsert(DriverAdvance objDriverAdvance);

        AutoCompleteResult IsTripsheetNoExist(string tripsheetNo);

        List<TripsheetLaneDetail> GetLaneList(short companyId, short customerId, long? laneId);
        List<TripsheetLaneDetail> GetLaneDetail(short companyId, short customerId, long laneId, DateTime? TrisheeetDate);
        List<TripsheetLaneDetail> GetFSCRateContractDetail(short companyId, short customerId, long? laneId, long VehicleId, DateTime? StartDate, short? ContractID);
        IEnumerable<AutoCompleteResult> GetCardListByTripsheetId(
          long tripsheetId,
          bool isFuelCard);

        IEnumerable<Tripsheet> GetTripsheetListForFuelSlip(
          string manualTripsheetNo,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          string vehicleNo);

        IEnumerable<FuelSlipDetail> GetFuelSlipDetailByTripsheetId(
          long tripsheetId);

        Response FuelSlipInsert(FuelSlip objFuelSlip);

        IEnumerable<Tripsheet> GetCancelledTripsheetList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string tripsheetNos,
          string manualTripsheetNos);

        Response Cancellation(TripsheetCancellation objTripsheetCancellation);

        IEnumerable<TripsheetExpectedExpense> GetTripsheetListForExpectedExpense(
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate);

        Response ExpectedExpense(
          TripsheetExpectedExpense objTripsheetExpectedExpense);

        IEnumerable<Tripsheet> GetTripsheetListForExpectedDriverAdvance(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate);

        IEnumerable<ExpectedDriverAdvanceDetails> GetExpectedDriverAdvanceDetailById(
          long id);

        Response ExpectedDriverAdvanceInsert(ExpectedDriverAdvance objExpectedDriverAdvance);

        IEnumerable<ThcDetail> GetTripsheetThcDetailList(long TripsheetId);

        IEnumerable<ThcFieldDetail> GetTripsheetThcFieldDetailList(
          long TripsheetId);
        IEnumerable<TripsheetLaneDetail> GetTripsheetLaneFieldDetailList(
          long tripsheetId);
        IEnumerable<GetVehicleStatusList> GetVehicleStatusListDtl();

        IEnumerable<GetVehicleListForMaintanance> VehicleMaintananceUpdateDataList(long id);

        Response VehicleStatusListUpdateInsert(VehicleMaintananceUpdateData objVehicleMaintananceUpdateData);
        IEnumerable<FuelSlipDetail> GetFuelSlipDetail(long tripsheetId);

        IEnumerable<Tripsheet> GetAdvanceCancelTripsheetList(
         short locationId,
         DateTime fromDate,
         DateTime toDate,
         string tripsheetNos,
         string manualTripsheetNos, string voucherNo);

        IEnumerable<TripsheetAdvance> GetAdvanceCancelDriverAdvanceList(long tripsheetId);

        Response AdvanceCancellation(TripsheetAdvanceCancellation tripsheetAdvanceCancellation);
        DocketListByTripsheetApi GetDocketListByTripsheet(string tripsheetNo);
        DocketCartonListByTripsheetResponse GetDocketCartonListByTripsheet(string tripsheetNo);
        ApiSubmitScanResponse SubmitScanDocket(ApiSubmitScanRequest apiSubmitScanRequest);

        ApiSubmitScanResponse SubmitScanDocketCarton(ApiSubmitScanRequest apiSubmitScanRequest);
        IEnumerable<TripsheetSettlementCancellation> GetTripsheetListForTripsheetSettlementCancellation(
  byte searchBy,
  string tripsheetNo,
  DateTime fromDate,
  DateTime toDate,
   byte tripsheetAction,
  DateTime finStartDate,
  DateTime finEndDate,
  short locationId);
        Response TripsheetSettlementCancellation(TripsheetSettlementCancellation objTripsheetSettlementCancellation);
        IEnumerable<TripsheetSettlementCancellation> GetTripsheetListForTripsheetFuelSlipCancellation(
            byte searchBy,
  string tripsheetNo,
  DateTime fromDate,
  DateTime toDate,
  DateTime finStartDate,
  DateTime finEndDate,
  short locationId);

        IEnumerable<FuelSlipDetail> GetFuelSlipListForTripsheetFuelSlipCancellation(long tripsheetId);
        Response TripsheetFuelSlipCancellation(FuelSlip objFuelSlip);
    }
}
