﻿//  
// Type: CodeLock.Areas.Master.Repository.CustomerRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Dapper.SqlMapper;

namespace CodeLock.Areas.Master.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository, IDisposable
    {
        public IEnumerable<MasterCustomer> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_MasterCustomer_GetAll", (object)null, "Customer Master - GetAll");
        }

        public MasterCustomer GetById(int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<MasterCustomer>, IEnumerable<MasterCustomerDetail>, IEnumerable<MasterCustomerAddressInfo>> tuple = DataBaseFactory.QueryMultipleSP<MasterCustomer, MasterCustomerDetail, MasterCustomerAddressInfo>("Usp_MasterCustomer_GetById", (object)dynamicParameters, "Customer Master - GetById");
            MasterCustomer masterCustomer = new MasterCustomer();
            if (tuple != null && tuple.Item1 != null)
            {
                masterCustomer = tuple.Item1.FirstOrDefault<MasterCustomer>();
                if (tuple.Item2 != null)
                    masterCustomer.MasterCustomerDetail = tuple.Item2.FirstOrDefault<MasterCustomerDetail>();

                if (tuple.Item3 != null)
                    masterCustomer.MasterCustomerAddressInfo = tuple.Item3.FirstOrDefault<MasterCustomerAddressInfo>();
            }
            // return DataBaseFactory.QuerySP<MasterCustomer>("Usp_MasterCustomer_GetById", (object) dynamicParameters, "Customer Master - GetById").FirstOrDefault<MasterCustomer>();
            return masterCustomer;
        }

        public int Insert(MasterCustomer objMasterCustomer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomer", (object)XmlUtility.XmlSerializeToString((object)objMasterCustomer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterCustomer_Insert", (object)dynamicParameters, "Customer Master - Insert");
            return dynamicParameters.Get<int>("@CustomerId");
            // return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomer_Insert", (object) dynamicParameters, "Customer Master - Insert").FirstOrDefault<Response>();
        }

        public int Update(MasterCustomer objMasterCustomer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomer", (object)XmlUtility.XmlSerializeToString((object)objMasterCustomer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterCustomer_Update", (object)dynamicParameters, "Customer Master - Update");
            return dynamicParameters.Get<int>("@CustomerId");
        }

        public bool IsCustomerNameAvailable(string CustomerName, short CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerName", (object)CustomerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterCustomer_IsCustomerNameAvailable", (object)dynamicParameters, "Customer Master - IsCustomerNameAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public bool IsCustomerNameExistWithGstNo(string CustomerName, string gstNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@GstNo", (object)gstNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerName", (object)CustomerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterCustomer_IsCustomerNameExistWithGstNo", (object)dynamicParameters, "Customer Master - IsCustomerNameAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerListByLocationPaybas(
      short locationId,
      byte paybasId,
      string customerName,
      bool allowWalkIn,
      bool isGstTypeCustomer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerName", (object)customerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AllowWalkIn", (object)allowWalkIn, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsGstTypeCustomer", (object)isGstTypeCustomer, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_GetCustomerListByLocationPaybas", (object)dynamicParameters, "Docket - GetCustomerListByLocationPaybas");
        }



        public IEnumerable<AutoCompleteResult> GetCustomerList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetCustomerList", (object)null, "Customer Master - GetAutoCompleteCustomerList");
        }
        public IEnumerable<AutoCompleteResult> GetCustomerListUserwise(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetCustomerList", (object)dynamicParameters, "Customer Master - GetAutoCompleteCustomerList");
        }
        public IEnumerable<AutoCompleteResult> GetCustomerListAssignUserwise(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerAssigned_GetCustomerList", (object)dynamicParameters, "Customer Master - GetAutoCompleteCustomerList");
        }
        public MasterCustomer IsCustomerExistByLocationPaybas(
      short locationId,
      byte paybasId,
      string customerCode,
      bool allowWalkIn)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AllowWalkIn", (object)allowWalkIn, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_Docket_IsCustomerExistByLocationPaybas", (object)dynamicParameters, "Docket - IsCustomerExistByLocationPaybas").FirstOrDefault<MasterCustomer>();
        }




        public IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerList(
      string customerCode,
      byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompleteCustomerList", (object)dynamicParameters, "Customer Master - GetAutoCompleteCustomerList");
        }

        public IEnumerable<AutoCompleteResult> GetAutocompleteConsigneeList(
          string consigneeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ConsigneeName", (object)consigneeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Consignee_GetAutocompleteList", (object)dynamicParameters, "Customer Master - GetAutocompleteList");
        }

        public Docket GetConsigneeDetailByName(string consigneeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ConsigneeName", (object)consigneeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Consignee_GetDetailByName", (object)dynamicParameters, "Customer Master - GetConsigneeDetailByName").FirstOrDefault<Docket>();
        }

        public AutoCompleteResult IsCustomerCodeExist(
          string customerCode,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_IsCustomerCodeExist", (object)dynamicParameters, "Customer Master - CheckValidCustomerCode").FirstOrDefault<AutoCompleteResult>();
        }

        public MasterCustomer IsCustomerCodeExistForOrder(
        string customerCode,
        byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_MasterCustomer_IsCustomerCodeExistForOrder", (object)dynamicParameters, "Customer Master - CheckValidCustomerCode").FirstOrDefault<MasterCustomer>();
        }


        public IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerListByLocation(
         string customerCode,
         short locationId,
         byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompleteListByLocation", (object)dynamicParameters, "Customer Master - GetAutoCompleteCustomerListByLocation");
        }

        public AutoCompleteResult IsCustomerCodeExistByLocation(
          string customerCode,
          short locationId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_IsCustomerCodeExistByLocation", (object)dynamicParameters, "Customer Master - IsCustomerCodeExistByLocation").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteListByPaybasId(
          string customerCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompleteListByPaybasId", (object)dynamicParameters, "Customer Master - GetAutoCompleteListByPaybasId");
        }

        public IEnumerable<AutoCompleteResult> GetLocationListByCustomerId(
          short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetLocationListByCustomerId", (object)dynamicParameters, "Customer Master - GetLocationListByCustomerId");
        }

        public IEnumerable<AutoCompleteResult> GetCustomerListByGroupCode(
          string groupCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@GroupCode", (object)groupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetCustomerListByGroupCode", (object)dynamicParameters, "Customer Master - GetCustomerListByGroupCode");
        }

        public IEnumerable<AutoCompleteResult> GetCustomerListByPaybasId(
          byte payBasId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PayBasId", (object)payBasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetCustomerListByPaybasId", (object)dynamicParameters, "Customer Master - GetCustomerListByPaybasId");
        }



        public IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerListByLocationPaybasWithGST(
         short locationId,
         byte paybasId,
         string customerName,
         bool allowWalkIn)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerName", (object)customerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AllowWalkIn", (object)allowWalkIn, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_GetCustomerListByLocationPaybasWithGST", (object)dynamicParameters, "Docket - GetCustomerListByLocationPaybas");
        }

        public MasterCustomer IsCustomerExistByLocationPaybasWithGST(
      short locationId,
      byte paybasId,
      string customerCode,
      bool allowWalkIn)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AllowWalkIn", (object)allowWalkIn, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_Docket_IsCustomerExistByLocationPaybasWithGST", (object)dynamicParameters, "Docket - IsCustomerExistByLocationPaybas").FirstOrDefault<MasterCustomer>();
        }
        public GetBycustomerName GetDetailByName(string customerName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerName", (object)customerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<GetBycustomerName>("Usp_Customer_GetDetailByName", (object)dynamicParameters, "Customer Master - GetDetailByName").FirstOrDefault<GetBycustomerName>();
        }

        public IEnumerable<MasterCustomer> GetCustomersByPagination(int pageNo, int pageSize, string sorting, string search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_MasterCustomer_GetCustomersByPagination", (object)dynamicParameters, "Customer Master - GetCustomersByPagination");
        }

        public IEnumerable<AutoCompleteResult> GetDropDownCustomerList(byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetDropDownCustomerList", (object)dynamicParameters, "Customer Master - GetDropDownCustomerList");
        }
        public IEnumerable<AutoCompleteResult> GetMappingByCustomerId(
      short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //dynamicParameters.Add("@CityId", (object)cityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerAddressMapping_GetMappingByCustomerId", (object)dynamicParameters, "CustomerAddressMapping Master - GetMappingByCustomerId");
        }

        public IEnumerable<CustomerExcelData> GetCustomerExcelData()
        {
            return DataBaseFactory.QuerySP<CustomerExcelData>("Usp_MasterCustomer_GetAll", (object)null, "Customer Master - GetCustomerExcelData");
        }
        public IEnumerable<AutoCompleteResult> GetCustomerListByLocation(
      short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_GetCustomerListByLocation", (object)dynamicParameters, "Customer Master - GetCustomerListByLocation");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteGstCustomerList(
      string customerCode,
      byte customerTypeId,
      byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerTypeId", (object)customerTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompleteGstCustomerList", (object)dynamicParameters, "Customer Master - GetAutoCompleteCustomerList");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompleteGstTinNo(
     string gstTinNo,
     byte paybasId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@GstTinNo", (object)gstTinNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompleteGstTinNo", (object)dynamicParameters, "Customer Master - GetAutoCompleteCustomerList");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompletePanNoAndMobileNo(
    string panNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@panNo", (object)panNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompletePanNoAndMobileNo", (object)dynamicParameters, "Customer Master - GetAutoCompletePanNoAndMobileNo");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompleteMobileNo(
    string mobileNo,
    byte paybasId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MobileNo", (object)mobileNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompleteMobileNo", (object)dynamicParameters, "Customer Master - GetAutoCompleteMobileNo");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompletePanNo(
    string panNo,
    byte paybasId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PanNo", (object)panNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetAutoCompletePanNo", (object)dynamicParameters, "Customer Master - GetAutoCompletePanNo");
        }



    }
}
