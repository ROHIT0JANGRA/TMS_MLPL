//  
// Type: CodeLock.Areas.Finance.Repository.ITripsheetBillRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Finance.Repository
{
  public interface ITripsheetBillRepository : IDisposable
  {
    IEnumerable<TripsheetBillDetail> GetTripsheettListForBillGeneration(
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      byte ftlTypeId,
      short vehicleId,
      short locationId,
      byte companyId,
      short generationLocationId);

    Response Generate(TripsheetBill objTripsheetBill);
  }
}
