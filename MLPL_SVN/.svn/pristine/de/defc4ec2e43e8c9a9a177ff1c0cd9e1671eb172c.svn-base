//  
// Type: CodeLock.Areas.Operation.Repository.IManifestRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
    public interface IManifestRepository : IDisposable
    {
        IEnumerable<LabourDCTracking> GetManifestListForLabourDCForTracking(
          string locationId,
          string docketList,
          DateTime fromDate,
          DateTime toDate,
          string DocumentType,
          string THCType,
          string VendorId,
          string companyId
          );

        Response InsertLabourDC(LabourDCModule objManifest);
        IEnumerable<LabourDCManifest> GetManifestListForLabourDC(
              byte companyId,
              string locationId,
              DateTime fromDate,
              DateTime toDate,
              string docketList,
              string DocumentType,
              string THCType
              );
        IEnumerable<ManifestDocket> GetDocketListForManifest(
      byte companyId,
      short locationId,
      string docketList,
      DateTime fromDate,
      DateTime toDate,
      byte transportModeId,
      int fromCityId,
      int toCityId,
      string toLocationList,
      string zoneList,
      short vendorId);

        Response Insert(Manifest objManifest);

        IEnumerable<Manifest> GetManifestListForCancellation(
          string manifestNos,
          string manualManifestNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId);

        Response Cancellation(ManifestCancellation objManifestCancellation);

        Response CancellationLabourDC(LabourDCModule objLabourDCCancellation);
        IEnumerable<LabourDCModule> GetLabourDCListForCancellation(
             string LabourDCNos,
             DateTime fromDate,
             DateTime toDate,
             short locationId);
        IEnumerable<ManifestDocket> GetDocketListByManifestId(
     long manifestId);
    }
}
