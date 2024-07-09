//  
// Type: CodeLock.Areas.Operation.Repository.IPrsRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
  public interface IPrsRepository : IDisposable
  {
    IEnumerable<AutoCompleteResult> GetBookedByList();

    Prs GetDocketList(
      string docketNos,
      DateTime fromDate,
      DateTime toDate,
      byte paybasId,
      byte transportModeId,
      byte businessTypeId,
      string isBookedByBa,
      short bookedById,
      short locationId,
      byte companyId,
      bool isPickupThroughSameVehicle);

    IEnumerable<PrsDocket> GetDocketListForUpdatePrs(
      long prsId,
      string docketNos,
      DateTime fromDate,
      DateTime toDate,
      byte paybasId,
      byte transportModeId,
      byte businessTypeId,
      string isBookedByBa,
      short bookedById,
      short locationId,
      byte companyId,
      bool isPickupThroughSameVehicle);

    PrsCharges GetChargeList(long prsId);

    Response Insert(Prs objPRS);

    Response Update(Prs objPRS);

    AutoCompleteResult CheckValidPrsNo(string prsNo);

    Prs GetStep2DetailById(long prsId);

    Prs GetStep3DetailById(long prsId);

    Prs GetStep4DetailById(long prsId);

    Prs GetStep5DetailById(long prsId);

    Prs GetStep6DetailById(long prsId);

    IEnumerable<Prs> GetPrsListForCancellation(
      string prsNos,
      string manualPrsNos,
      DateTime fromDate,
      DateTime toDate,
      short locationId);

    void Cancellation(PrsCancellation objPrsCancellation);
  }
}
