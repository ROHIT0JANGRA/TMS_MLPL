//  
// Type: CodeLock.Areas.Master.Repository.ILocationRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ILocationRepository : IDisposable
    {
        IEnumerable<AutoCompleteResult> GetLocationListOnlyBranch();
        AutoCompleteResult IsLocationCodeExistOwnership(string locationCode);
        IEnumerable<AutoCompleteResult> GetAutoCompleteLocationList(
      string locationCode, string OwnershipType);
        IEnumerable<AutoCompleteResult> GetLocationAllList(string OwnershipType);
        IEnumerable<AutoCompleteResult> GetLocationList(string OwnershipType);
        MasterLocation GetById(short id);

        IEnumerable<MasterLocation> GetAll();

        short Insert(MasterLocation objMasterLocation);

        short Update(MasterLocation objMasterLocation);

        IEnumerable<AutoCompleteResult> GetLocationListByLocationId(
          short loginLocationId,
          short loginUserLocationId);

        IEnumerable<AutoCompleteResult> GetLocationListByStateId(
          short stateId);

        bool IsLocationNameAvailable(string locationName, short locationId);

        IEnumerable<AutoCompleteResult> GetLocationList();

        IEnumerable<AutoCompleteResult> GetAutoCompleteLocationList(
          string locationCode);

        IEnumerable<AutoCompleteResult> GetAutoCompleteLocationListDocketENtry(
     string locationCode);

        IEnumerable<AutoCompleteResult> GetAutoCompleteLocationListDocketEntryByDeliveryLocation(
       string locationCode, short customerId);

        bool IsLocationCodeAvailable(string locationCode, short locationId);

        AutoCompleteResult IsLocationCodeExist(string locationCode);

        IEnumerable<AutoCompleteResult> GetByLocationHierarchy(
          byte locationHierarchy);

        IEnumerable<AutoCompleteResult> GetLocationHierarchyByLocationId(
          short locationId,
          short virtualLocationId);

        IEnumerable<AutoCompleteResult> GetLocationListByZoneId(
          short zoneId);

        IEnumerable<AutoCompleteResult> GetLocationByHierarchyId(
          bool isRegion);
        LocationNameById GetLocationNameById(string locationName);
        bool CheckDeliveryLocationByBillingParty(short locationId, short customerId);
    }
}
