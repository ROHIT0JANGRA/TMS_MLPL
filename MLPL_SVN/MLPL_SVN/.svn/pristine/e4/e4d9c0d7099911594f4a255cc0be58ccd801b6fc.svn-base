//  
// Type: CodeLock.Areas.Master.Repository.CustomerAddressRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
    public class CustomerAddressRepository : BaseRepository, ICustomerAddressRepository, IDisposable
    {
        public IEnumerable<MasterCustomerAddressMapping> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterCustomerAddressMapping>("Usp_MasterCustomerAddressMapping_GetAll", (object)null, "CustomerAddressMapping Master - GetAll");
        }

        public MasterCustomerAddressMapping GetById(
          byte customerId,
          int cityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CityId", (object)cityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomerAddressMapping>("Usp_MasterCustomerAddressMapping_GetById", (object)dynamicParameters, "CustomerAddressMapping Master - GetById").FirstOrDefault<MasterCustomerAddressMapping>();
        }

        public Response AddressMapping(
          MasterCustomerAddressMapping objMasterCustomerAddressMapping)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerAddressMapping", (object)XmlUtility.XmlSerializeToString((object)objMasterCustomerAddressMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomerAddressMapping", (object)dynamicParameters, "CustomerAddressMapping Master - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteListByCustomerId(
          short customerId,
          string addressCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AddressCode", (object)addressCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerAddressMapping_GetAutoCompleteListByCustomerId", (object)dynamicParameters, "CustomerAddressMapping Master - GetAutoCompleteListByCustomerId");
        }

        public OrderBillDetail CheckValidAddressCodeByCustomerId(
          short customerId,
          string addressCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AddressCode", (object)addressCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            OrderBillDetail orderBillDetail = new OrderBillDetail();
            return DataBaseFactory.QuerySP<OrderBillDetail>("Usp_MasterCustomerAddressMapping_CheckValidAddressCodeByCustomerId", (object)dynamicParameters, "CustomerAddressMapping Master - CheckValidAddressCodeByCustomerId").FirstOrDefault<OrderBillDetail>() ?? new OrderBillDetail();
        }

        public IEnumerable<MasterCustomerAddressMapping> GetMappingByCustomerIdCityId(
          short customerId,
          int cityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CityId", (object)cityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomerAddressMapping>("Usp_MasterCustomerAddressMapping_GetMappingByCustomerIdCityId", (object)dynamicParameters, "CustomerAddressMapping Master - GetMappingByCustomerIdCityId");
        }

        public IEnumerable<AutoCompleteResult> GetCustomerAddressList(short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerAddress_GetCustomerAddressList", (object)dynamicParameters, "Customer Address Master - GetCustomerAddressList");
        }

        public MasterAddress GetCustomerAddressById(short addressId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AddressId", (object)addressId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterAddress>("Usp_MasterCustomerAddress_GetCustomerAddressById", (object)dynamicParameters, "Customer Address Master - GetCustomerAddressById").FirstOrDefault<MasterAddress>() ?? new MasterAddress(); ;
        }
    }
}
