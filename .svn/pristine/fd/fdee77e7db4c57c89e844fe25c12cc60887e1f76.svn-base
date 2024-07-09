//  
// Type: CodeLock.Areas.Master.Repository.IGstRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IGstRepository : IDisposable
  {
    Response ValidateGSTState(long GstId, long OwnerId, long StateId, byte OwnerType);
    IEnumerable<GstRegistration> GetListByOwnerType(byte ownerType);

    GstRegistration GetById(long id);

    Response Insert(GstRegistration objGstRegistration);

    Response Update(GstRegistration objGstRegistration);

    IEnumerable<AutoCompleteResult> GetStateListByOwnerTypeIdAndOwnerId(
      byte ownerType,
      long ownerId);

    bool IsStateNameAvailable(string stateName, byte ownerType, long ownerId, long gstId);

    IEnumerable<TransportModeToServiceMapping> GetGstServiceAndSacCategoryByTransportModeId(
      byte transportModeId);

    IEnumerable<AutoCompleteResult> GetGstServiceTypeIdBySacId(
      byte sacId);

    IEnumerable<GstRegistration> GetGstRegistrationByOwnerId(
      byte ownerType,
      int ownerId);

    IEnumerable<AutoCompleteResult> GetGstStateList(
      byte ownerType,
      long ownerId,
      short locationId);
       
    MasterSac GetGstDetailByGstServiceTypeId(byte gstServiceTypeId);

    IEnumerable<AutoCompleteResult> GetCategoryList();

    IEnumerable<AutoCompleteResult> GetGstServiceTypeList();

    IEnumerable<AutoCompleteResult> GetSacList();

    GstRegistration GetGstDetailByOwnerAndState(
      byte ownerType,
      long ownerId,
      short stateId);

    GstRegistration GetGstDetailByOwnerAndCity(
      byte ownerType,
      long ownerId,
      int cityId);

    GstRegistration GetCustomerGstDetailByCustomerIdAndCityId(
      short customerId,
      int cityId);

    GstRegistration GetGstDetailByLocationIdAndOwnerType(
      short locationId,
      byte ownerType);

    MasterSac GetDetailById(byte id);

    IEnumerable<AutoCompleteResult> GetCityListByOwnerAndState(
      byte ownerType,
      long ownerId,
      short stateId);

    GstRegistration GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity(
      byte ownerType,
      long ownerId,
      short stateId,
      int cityId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteSacList(
      string sacCode);

    AutoCompleteResult IsSacCodeExist(string sacCode);

    GstRegistration GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation(
      byte ownerType,
      long ownerId,
      short stateId,
      short locationId);
  }
}
