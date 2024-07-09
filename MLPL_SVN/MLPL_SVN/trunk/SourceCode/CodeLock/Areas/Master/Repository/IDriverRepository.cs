//  
// Type: CodeLock.Areas.Master.Repository.IDriverRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IDriverRepository : IDisposable
  {
        IEnumerable<AutoCompleteResult> GetDriverList();
        IEnumerable<AutoCompleteResult> GetAutoCompleteDriverList(
          string driverName);

        AutoCompleteResult IsDriverNameExist(
          string driverName);

    IEnumerable<MasterDriver> GetAll();

        MasterDriver GetById(int id);

        Response Insert(MasterDriver objMasterDriver);

    Response DocumentInsert(DriverDocument objDriverDocument);

    short DocumentUpdate(DriverDocument objDriverDocument);

    Response Update(MasterDriver objMasterDriver);

    IEnumerable<AutoCompleteResult> GetDriverListByLocation(
      short locationId);

    IEnumerable<AutoCompleteResult> GetDriverListByTripSheetRule(
      short locationId,
      short? vehicleId);

    MasterDriver GetDriverDetailByVehicleId(short locationId, short vehicleId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteDriverListByLocation(
      string driverName,
      short locationId);
    IEnumerable<AutoCompleteResult> GetAutoCompleteDriverCodeListByLocation(
          string driverName,
          short locationId);

          AutoCompleteResult IsDriverNameExistByLocation(
      string driverName,
      short locationId);

        AutoCompleteResult IsDriverCodeExistByLocation(
    string driverName,
    short locationId);

        IEnumerable<AutoCompleteResult> GetLocationListByDriverId(int driverId);
         IEnumerable<MasterDriver> GetDriversByPagination(int pageNo, int pageSize, string sorting, string search);


    }
}
