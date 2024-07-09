//  
// Type: CodeLock.Areas.FMS.Repository.ITrackingRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.FMS.Repository
{
  public interface ITrackingRepository : IDisposable
  {
    IEnumerable<FleetDocumentTracking> GetTripsheetList(
      short locationId,
      DateTime fromDate,
      DateTime toDate,
      string tripsheetNos,
      string manualTripsheetNos,
      string vehicalNos);
  }
}
