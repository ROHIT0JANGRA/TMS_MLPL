//  
// Type: CodeLock.Areas.Master.Repository.IVendorRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IVendorRepository : IDisposable
  {
        IEnumerable<AutoCompleteResult> GetCustomerList();
        MasterVendor GetById(short id);

    IEnumerable<AutoCompleteResult> GetVendorNameList();

    IEnumerable<MasterVendorDetails> GetAll();

    short Insert(MasterVendor objMasterVendor);

   short Update(MasterVendor objMasterVendor);

        IEnumerable<AutoCompleteResult> GetVendorListByVendorTypeId(
      byte vendorTypeId);

    IEnumerable<AutoCompleteResult> GetVendorNameByVendorTypeId(
      short vendorTypeId);

    IEnumerable<AutoCompleteResult> GetVendorServiceByVendorId(
      short vendorId);

    bool IsVendorNameAvailable(string vendorCode, short vendorId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteVendorList(
      string vendorCode,
      byte vendorType);

    AutoCompleteResult IsVendorCodeExist(string vendorCode, byte vendorTypeId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteVendorListByLocation(
      string vendorCode,
      byte vendorType,
      short locationId);

    AutoCompleteResult IsVendorCodeExistByLocation(
      string vendorCode,
      byte vendorType,
      short locationId);

    IEnumerable<AutoCompleteResult> GetVenderTypeByVehicleId(
      short vehicleId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteListForFuelPumpVendor(
      string vendorCode);

    IEnumerable<AutoCompleteResult> GetLocationListByVendorId(
      short vendorId);
        
     bool CheckDate(short contractId, short customerId, byte paybasId, bool isCustomerContract, DateTime startDate, DateTime endDate);
        bool CheckDateIsValid(short contractId, short customerId, byte paybasId, bool isCustomerContract, DateTime contractDate);
        IEnumerable<VendorExcelData> GetVendorExcelData();
        IEnumerable<AutoCompleteResult> GetWarehouseListByVendorId(
      short VendorId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteVendorListByLocationforFuel(short locationId);
        IEnumerable<MasterVendorDetails> GetVendorsByPagination(int pageNo, int pageSize, string sorting, string search);


    }
}
