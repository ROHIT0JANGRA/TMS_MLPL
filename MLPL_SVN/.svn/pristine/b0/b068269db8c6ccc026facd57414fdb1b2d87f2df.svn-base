//  
// Type: CodeLock.Areas.Master.Repository.ICustomerAddressRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ICustomerAddressRepository : IDisposable
    {
        IEnumerable<MasterCustomerAddressMapping> GetAll();

        MasterCustomerAddressMapping GetById(byte customerId, int cityId);

        Response AddressMapping(
          MasterCustomerAddressMapping objMasterCustomerAddressMapping);

        IEnumerable<AutoCompleteResult> GetAutoCompleteListByCustomerId(
          short customerId,
          string addressCode);

        OrderBillDetail CheckValidAddressCodeByCustomerId(
          short customerId,
          string addressCode);

        IEnumerable<MasterCustomerAddressMapping> GetMappingByCustomerIdCityId(
          short customerId,
          int cityId);

        IEnumerable<AutoCompleteResult> GetCustomerAddressList(short customerId);

        MasterAddress GetCustomerAddressById(short addressId);
    }
}
