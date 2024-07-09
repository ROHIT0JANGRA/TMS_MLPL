//  
// Type: CodeLock.Areas.Operation.Repository.ILoadingSheetRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
  public interface ILoadingSheetRepository : IDisposable
  {
    IEnumerable<LoadingSheetDocket> GetDocketListForLoadingSheet(
      byte companyId,
      short locationId,
      string docketList,
      DateTime fromDate,
      DateTime toDate,
      byte transportModeId,
      int fromCityId,
      int toCityId,
      string toLocationList,
      string zoneList);

    Response Insert(LoadingSheet objLoadingSheet);

    Response Update(Manifest objLoadingSheet);

    IEnumerable<LoadingSheet> GetLoadingSheetListForUpdate(
      short locationId,
      DateTime fromDate,
      DateTime toDate,
      short nextLocationId,
      string loadingSheetNo);

    LoadingSheet GetLoadingSheetById(long loadingsheetId);

    IEnumerable<ManifestDocket> GetDocketListByLoadingSheetId(
      long loadingSheetId,
      short vendorId,
      short locationId);

    IEnumerable<LoadingSheet> GetLoadingSheetListForCancellation(
      string loadingSheetNo,
      string manualLoadingSheetNo,
      DateTime fromDate,
      DateTime toDate,
      short locationId);

    Response Cancellation(
      LoadingSheetCancellation objLoadingSheetCancellation);

        IEnumerable<AutoCompleteResult> GetVendorList(short locationId);
    }
}
