//  
// Type: CodeLock.Areas.Operation.Repository.IThcRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
    public interface IThcRepository : IDisposable
    {

        void ChangeDocketAmount(Docket objThc);
        void DocketUpdate(Docket objThc);
        void ThcUpdate(Thc objThc);
        Response Insert(Thc objThc);
        Response Update(Thc objThc);

        Response InsertTrispeed(ThcTrispeed objThc);
        Response UpdateTrispeed(ThcTrispeed objThc);

        ThcCharges GetChargeList(long thcId);

        IEnumerable<ThcManifestDetail> GetManifestList(
          DateTime fromDate,
          DateTime toDate,
          byte transportModeId,
          short routeId,
          short fromLocationId,
          short toLocationId);

        IEnumerable<ThcManifestDetail> GetManifestListForUpdateThc(
          long thcId,
          DateTime fromDate,
          DateTime toDate,
          byte transportModeId,
          short routeId,
          short fromLocationId,
          short toLocationId);

        List<AutoCompleteResult> GetArrivalConditionList();

        List<AutoCompleteResult> GetDeliveryProcessList();

        List<AutoCompleteResult> GetLateDeliveryReasonList();

        IEnumerable<ThcManifestDetail> GetManifestListByThcId(long thcId);

        AutoCompleteResult CheckValidThcCode(string thcNo);

        IEnumerable<FinanceSummary> GetDocumentListForUpdate(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo,
          byte documentTypeId);

        Thc GetStep1DetailById(long thcId);

        Thc GetStep2DetailById(long thcId);

        Thc GetStep3DetailById(long thcId);

        Thc GetStep4DetailById(long thcId);

        Thc GetStep5DetailById(long thcId);

        Thc GetStep6DetailById(long thcId);

        IEnumerable<Thc> GetThcListForVehicleArrival(
          string thcNos,
          DateTime fromDate,
          DateTime toDate,
          string vehicleNos,
          string docketNos,
          string arrivalLocations,
          short locationId,
          byte companyId);

        Response VehicleArrival(ThcSummary objTHCSummary);

        IEnumerable<Thc> GetThcListForStockUpdate(
          string thcNos,
          DateTime fromDate,
          DateTime toDate,
          string vehicleNos,
          string docketNos,
          string arrivalLocations,
          short locationId,
          byte companyId);

        ThcSummary GetThcDetailsForStockUpdate(long thcId, short locationId);

        IEnumerable<StockUpdateDocket> GetThcDocketListForStockUpdate(
          long thcId,
          short locationId);

        Response StockUpdate(ThcSummary objThcSummary);

        Response ThcDeparture(Departure objThcDeparture);

        IEnumerable<Thc> GetThcListForThcDeparture(
          string thcNos,
          DateTime fromDate,
          DateTime toDate,
          string manifestNos,
          string vehicleNos,
          string docketNos,
          short locationId,
          byte companyId);

        Departure GetThcDetailForThcDeparture(long thcId, short locationId);

        Response Unloading(Unloading objUnloading);

        IEnumerable<UnloadingDocket> GetUnloadingDocketList(
          string thcNos,
          short locationId);

        IEnumerable<Thc> GetThcListForCancellation(
          string thcNos,
          string manualThcNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId);

        void Cancellation(ThcCancellation objThcCancellation);

        Response DepsUpdate(ThcSummary objThcSummary);

        IEnumerable<DepsDocket> GetDepsListForStockUpdate(
          DateTime fromDate,
          DateTime toDate,
          string docketNo,
          string depsNo,
          short dateType,
          bool isUpdate,
          short locationId);

        IEnumerable<DepsDocket> GetDepsHistory(long id);

        Response DepsEntry(Deps objDeps);

        Deps GetDocketDetailsForDeps(string docketNo, long locationId);

        IEnumerable<DispatchDocketDetail> GetDispatchDocketList(
          short locationId,
          byte companyId);

        Response DispatchInsert(DocketDispatch objDocketDispatch);

        IEnumerable<DepsDocket> GetDepsDocketHistory(long id);
        IEnumerable<StockUpdateDocket> GetThcDocketListForStockUpdateByManifest(
         long thcId,
         short locationId,
         string manifestId);
        IEnumerable<ThcManifestDetail> GetManifestListByThcIdForStockUpdate(
          long thcId);
        bool CheckBillIsMade(long thcId);
        IEnumerable<Thc> GetThcListForStockUpdateCancellation(
            string thcNos,
            DateTime fromDate,
            DateTime toDate,
            short locationId);
        Response ThcStockUpdateCancellation(
            long thcId,
            string cancelReason,
            DateTime cancelDate,
            short cancelBy,
            short locationId);
        IEnumerable<ThcAdvBalPaymnt_Details> GetMultiAdvanceDetail(
        long thcId);

        IEnumerable<Thc> GetThcListForVehicleArrivalCancellation(
          string thcNos,
          string manualThcNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId);

        void VehicleArrivalCancellation(ThcCancellation objThcCancellation);
    }
}
