﻿//  
// Type: CodeLock.Areas.Master.Repository.IVehicleRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface IVehicleRepository : IDisposable
    {
        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListForStatus(
            string vehicleNo, long userId);
        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleForMaintanance(
        string vehicleNo);
        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListForStatus(
        string vehicleNo);
        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListByForTripsheetCloser(
          string TripsheetNo, string TripsheetAction, string searchBy, string locationId);
        MasterVehicle GetById(short id);

        IEnumerable<MasterVehicleDetails> GetAll();

        IEnumerable<AutoCompleteResult> GetVehicleList();

        short Insert(MasterVehicle objMasterVehicle);

        short Update(MasterVehicle objMasterVehicle);

        bool IsVehicleNoAvailable(string vehicleNo, short vehicleId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListByLocation(
          string vehicleNo,
          string locationId);

        IEnumerable<AutoCompleteResult> GetVehicleListByVendorTypeByLocation(
          string vehicleNo,
          byte vendorTypeId,
          short locationId);

        AutoCompleteResult IsVehicleNoExistByVendorTypeByLocation(
          string vehicleNo,
          byte vendorTypeId,
          short locationId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListByLocationForTripsheet(
          string vehicleNo,
          string locationId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleList(
          string vehicleNo);

        AutoCompleteResult IsVehicleNoExistByLocation(
          string vehicleNo,
          short locationId);

        AutoCompleteResult IsVehicleNoExistForTripsheet(
          string vehicleNo,
          short locationId);

        IEnumerable<AutoCompleteResult> GetVehicleListByVendorId(
          short vendorId);

        AutoCompleteResult IsVehicleNoExist(string vehicleNo);

        int GetStartKmByVehicleId(short vehicleId);

        IEnumerable<AutoCompleteResult> GetVehicleByFtlTypeId(
          byte ftlTypeId);

        IEnumerable<AutoCompleteResult> GetVehicleByVendorIdFtlTypeId(
          byte ftlTypeId,
          short vendorId);

        IEnumerable<AutoCompleteResult> GetTripsheetByVehicleId(
          short vehicleId, DateTime documentDateTime);

        IEnumerable<AutoCompleteResult> GetAutoCompleteListForJobOrder(
          string vehicleNo,
          string locationId);

        AutoCompleteResult CheckValidVehicleNoForJobOrder(
          string vehicleNo,
          short locationId);

        IEnumerable<AutoCompleteResult> GetVehicleListByCardType(
          bool isFuelCard);

        int GetStartKm(short vehicleId);

        IEnumerable<MasterServiceVehicle> GetAllData();

        IEnumerable<MasterServiceVehicle> GetAllDataVehicleServiceKM();

        short InsertKmMapping(MasterServiceVehicle objMasterVehicle);

        bool IsVehicleAvailable(short VehicleId);

        IEnumerable<AutoCompleteResult> GetCompanyVehicleList(short VehicleTypeId);

        MasterServiceVehicle GetKmMappingByMappingId(short id);

        short UpdateKmMapping(MasterServiceVehicle objMasterVehicle);
        IEnumerable<AutoCompleteResult> GetVehicleListByVendorTypeId(
      short vendorTypeId);


        IEnumerable<MasterVehicleDetails> GetVehiclesByPagination(int pageNo, int pageSize, string sorting, string search);



        }
}
