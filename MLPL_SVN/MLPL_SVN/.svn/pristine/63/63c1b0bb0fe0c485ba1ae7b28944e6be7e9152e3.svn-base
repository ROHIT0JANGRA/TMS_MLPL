//  
// Type: CodeLock.Areas.Operation.Repository.IDrsRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
    public interface IDrsRepository : IDisposable
    {
        IEnumerable<AutoCompleteResult> GetBookedByList();

        DrsCharges GetChargeList(long drsId);

        Drs GetDocketList(
          DateTime fromDate,
          DateTime toDate,
          byte paybasId,
          byte transportModeId,
          byte businessTypeId,
          bool isOda,
          string docketNos,
          short vendorId,
          short locationId,
          byte companyId,
          bool isDeliveryThroughSameVehicle);

        IEnumerable<DrsDocket> GetDocketListForUpdateDrs(
          long drsId,
          DateTime fromDate,
          DateTime toDate,
          byte paybasId,
          byte transportModeId,
          byte businessTypeId,
          bool isOda,
          string docketNos,
          short vendorId,
          short locationId,
          byte companyId,
          bool isDeliveryThroughSameVehicle);

        Response Insert(Drs objDrs);

        Response Update(Drs objDrs);

        AutoCompleteResult CheckValidDrsNo(string drsNo);

        Drs GetStep2DetailById(long drsId);

        Drs GetStep3DetailById(long drsId);

        Drs GetStep4DetailById(long drsId);

        Drs GetStep5DetailById(long drsId);

        Drs GetStep6DetailById(long drsId);

        IEnumerable<Drs> GetDrsListForDrsUpdate(
          string drsNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId,
          byte companyId);

        Drs GetDrsDocketListById(long drsId, short locationId, byte companyId);

        Response Close(DrsClose objDrs);

        IEnumerable<Drs> GetDrsListForCancellation(
          string drsNos,
          string manualDrsNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId);

        Response Cancellation(DrsCancellation objDrsCancellation);
        IEnumerable<Docket> GetOrderDeliveryDocketList(
          string docketNo,
          DateTime fromDate,
          DateTime toDate);
        IEnumerable<DeliverOrderInvoiceDetail> GetOrderDeliveryPartListForDocket(long docketId);
        DeliverOrder GetOrderDeliveryDocketPartDetail(long docketId);
        Response OrderDeliveryInsert(DeliverOrder deliverOrder);

        IEnumerable<Drs> GetDrsListForDrsCloseCancellation(
         string drsNos,
         DateTime fromDate,
         DateTime toDate,
         short locationId);

        Response DrsCloseCancellation(
            long drsId,
            string cancelReason,
            DateTime cancelDate,
            short cancelBy,
            short locationId);
    }
}
