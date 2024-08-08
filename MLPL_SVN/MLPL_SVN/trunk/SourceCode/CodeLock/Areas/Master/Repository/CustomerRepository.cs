
using System.Threading.Tasks;
using CodeLock.Api_Services;
using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web.Mvc;
using static Dapper.SqlMapper;
using System.IO.Compression;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Owin.BuilderProperties;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CodeLock.Areas.Master.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository, IDisposable
    {
        public bool IsSendSuccessfully = false;
       
        public IEnumerable<MasterCustomer> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_MasterCustomer_GetAll", (object)null, "Customer Master - GetAll");
        }
        public MasterCustomer GetById(int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<MasterCustomer>, IEnumerable<MasterCustomerDetail>, IEnumerable<MasterCustomerAddressInfo>, IEnumerable<MasterAddress>> tuple = DataBaseFactory.QueryMultipleSP<MasterCustomer, MasterCustomerDetail, MasterCustomerAddressInfo, MasterAddress>("Usp_MasterCustomer_GetById", (object)dynamicParameters, "Customer Master - GetById");
            MasterCustomer masterCustomer = new MasterCustomer();
            if (tuple != null && tuple.Item1 != null)
            {
                masterCustomer = tuple.Item1.FirstOrDefault<MasterCustomer>();
                if (tuple.Item2 != null)
                    masterCustomer.MasterCustomerDetail = tuple.Item2.FirstOrDefault<MasterCustomerDetail>();

                if (tuple.Item3 != null)
                    masterCustomer.MasterCustomerAddressInfo = tuple.Item3.FirstOrDefault<MasterCustomerAddressInfo>();
                if (tuple.Item4 != null)
                    masterCustomer.MasterAddressList = tuple.Item4.ToList();
            }
            // return DataBaseFactory.QuerySP<MasterCustomer>("Usp_MasterCustomer_GetById", (object) dynamicParameters, "Customer Master - GetById").FirstOrDefault<MasterCustomer>();
            return masterCustomer;
        }

        //public int Insert(MasterCustomer objMasterCustomer)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();
        //    dynamicParameters.Add("@XmlCustomer", (object)XmlUtility.XmlSerializeToString((object)objMasterCustomer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
        //    DataBaseFactory.QuerySP("Usp_MasterCustomer_Insert", (object)dynamicParameters, "Customer Master - Insert");
        //    return dynamicParameters.Get<int>("@CustomerId");
        //    // return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomer_Insert", (object) dynamicParameters, "Customer Master - Insert").FirstOrDefault<Response>();
        //}
        public int Insert(MasterCustomer objMasterCustomer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomer", (object)XmlUtility.XmlSerializeToString((object)objMasterCustomer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterCustomer_Insert_Test", (object)dynamicParameters, "Customer Master - Insert");

            return dynamicParameters.Get<int>("@CustomerId");
            // return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomer_Insert", (object) dynamicParameters, "Customer Master - Insert").FirstOrDefault<Response>();
        }
        public int Update(MasterCustomer objMasterCustomer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomer", (object)XmlUtility.XmlSerializeToString((object)objMasterCustomer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterCustomer_Update_Test", (object)dynamicParameters, "Customer Master - Update");
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

        public string GetCustomerAddressCode(int AddressId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AddressId", (object)AddressId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerAddressCode", "", new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            var res = DataBaseFactory.QuerySP("Usp_GetCustomerAddressCode", (object)dynamicParameters, "Customer Master - GetCustomerAddressCode");
            return dynamicParameters.Get<string>("@CustomerAddressCode");
        }
        // ***************************   Sap Bp Master Insert **************** *******8
        //public async Task<BPMasterModel> MapMasterCustomerToBPMaster(MasterCustomer masterCustomer)
        //{
        //    if (masterCustomer == null)
        //    {
        //        throw new ArgumentNullException(nameof(masterCustomer));
        //    }

        //    List<ContactEmployee> BPContactEmployee = new List<ContactEmployee>();
        //    if (masterCustomer.MasterCustomerDetail != null)
        //    {
        //        ContactEmployee bpContactEmpObj = new ContactEmployee
        //        {
        //            CardCode = masterCustomer.CustomerCode,
        //            Name = bpContactEmpObj.,
        //            MobilePhone = masterCustomerDetail.MobileNo ?? string.Empty,
        //            E_Mail = masterCustomerDetail.EmailId ?? string.Empty,
        //            Position = masterCustomerDetail.DecisionMakerDesignation ?? string.Empty,
        //            Title = "Mr", // Assuming title as "Mr" as hardcoded
        //            Active = "tYES", // Assuming "tYES" is a standard value used
        //            FirstName = decisionMakerName,
        //            LastName = decisionMakerName,

        //        };
        //        BPContactEmployee.Add(bpContactEmpObj);
        //    }

        //    List<BPBankAccount> BPBankAccounts = new List<BPBankAccount>();
        //    BPBankAccount objBPBank = new BPBankAccount
        //    {
        //        BPCode = masterCustomer.BPCode ?? string.Empty,
        //        Branch = masterCustomer.Branch ?? string.Empty,
        //        Country = "IN", // Corrected the country code to match the JSON
        //        BankCode = masterCustomer.BankCode ?? string.Empty,
        //        AccountNo = masterCustomer.Account ?? string.Empty,
        //        AccountName = masterCustomer.BankAccountName ?? string.Empty,
        //        BICSwiftCode = masterCustomer.BICSWIFTCode ?? string.Empty
        //    };
        //    BPBankAccounts.Add(objBPBank);

        //    var addressList = masterCustomer.MasterAddressList ?? new List<MasterAddress>();
        //    BPMasterModel bpmMasterModel = new BPMasterModel
        //    {
        //        CardCode = masterCustomer.CustomerCode ?? string.Empty,
        //        CardName = masterCustomer.CustomerName ?? string.Empty,
        //        GroupCode = 105, // Assuming a default group code
        //        CardType = masterCustomer.GroupName ?? string.Empty,
        //        DefaultBranch = masterCustomer.Branch ?? string.Empty,
        //        CompanyPrivate = "cPrivate", // Hardcoded as per JSON example
        //        DefaultAccount = masterCustomer.Account ?? string.Empty,
        //        DefaultBankCode = masterCustomer.BankCode ?? string.Empty,
        //        Industry = 2, // Hardcoded as per JSON example
        //        ContactEmployees = BPContactEmployee.ToList(),
        //        BPBankAccounts = BPBankAccounts.ToList(),
        //        BPAddresses = addressList.Select(address => new BPAddress
        //        {
        //            AddressName = address.AddressCode ?? string.Empty,
        //            ZipCode = address.Pincode ?? string.Empty,
        //            City = address.CityName ?? string.Empty,
        //            Country = "IN", // Corrected the country code to match the JSON
        //            State = address.StateName ?? string.Empty,
        //            AddressType = address.AddressType ?? string.Empty,
        //            AddressName2 = address.Address1 ?? string.Empty,
        //            AddressName3 = address.Address2 ?? string.Empty,
        //            BPCode = address.AddressCode ?? string.Empty,
        //            RowNum = address.RowNum,
        //            GSTIN = address.GstTinNo ?? string.Empty,
        //            GstType = address.GstType ?? string.Empty,
        //            U_PANNo = address.ProvisionalId ?? string.Empty,
        //            CreateDate = address.CreateDate,
        //            CreateTime = address.CreateTime
        //        }).ToList()
        //    };

        //    await SaveTheCustomerMasterDataInSap(bpmMasterModel);

        //    return bpmMasterModel;
        //}
        public string GetTheSateCodeBySateId()
        {
            MasterCustomerAddressInfo masterCustomerAddressInfo = new MasterCustomerAddressInfo();
            short stId = masterCustomerAddressInfo.StateId;
           string getTheSateCode = GetSateCodeBySateId(stId);
            return getTheSateCode;
        }
        public async Task<BPMasterModel> MapMasterCustomerToBPMaster(MasterCustomer masterCustomer)
        {
            //string getTheSateCode = GetSateCodeBySateId(stId);
            MasterCustomerAddressInfo masterCustomerAddressInfo = new MasterCustomerAddressInfo();
            short AddresInfostId = masterCustomerAddressInfo.StateId;
            string getAddInfoTheSateCode = GetSateCodeBySateId(AddresInfostId);
            if (masterCustomer == null)
            {
                throw new ArgumentNullException(nameof(masterCustomer));
            }

            // Check for null or empty details
            if (masterCustomer.MasterCustomerDetail == null)
            {
                throw new ArgumentNullException(nameof(masterCustomer.MasterCustomerDetail));
            }

            // Prepare ContactEmployee list
            List<ContactEmployee> BPContactEmployee = new List<ContactEmployee>();
            var masterCustomerDetail = masterCustomer.MasterCustomerDetail;
            var decisionMakerName = masterCustomerDetail.DecisionMakerName ?? string.Empty;

            ContactEmployee bpContactEmpObj = new ContactEmployee
            {
                Name = decisionMakerName,
                MobilePhone = masterCustomerDetail.MobileNo ?? string.Empty,
                E_Mail = masterCustomerDetail.EmailId ?? string.Empty,
                Position = masterCustomerDetail.DecisionMakerDesignation ?? string.Empty,
                Address = "53/10 New industrial area Faridabad",
                Title = "Mr", // Assuming title as "Mr" as hardcoded
                Active = "tYES", // Assuming "tYES" is a standard value used
                FirstName = decisionMakerName,
                LastName = decisionMakerName,
            };
            BPContactEmployee.Add(bpContactEmpObj);

            // Prepare BPBankAccounts list
            List<BPBankAccount> BPBankAccounts = new List<BPBankAccount>();
            BPBankAccount objBPBank = new BPBankAccount
            {
              
                Branch = "FARIDABAD" ?? string.Empty,
                Country = "IN", // Corrected the country code to match the JSON
                BankCode = "HDFC" ?? string.Empty,
                AccountNo = "20091867546" ?? string.Empty,
                AccountName = "HDFC BANK" ?? string.Empty,
                BICSwiftCode = "HDFC0000093" ?? string.Empty
            };
            BPBankAccounts.Add(objBPBank);

            // Prepare BPAddresses list
            //    var addressList = masterCustomer.MasterAddressList ?? new List<MasterAddress>();
            List<BPAddress> bpAddresses = new List<BPAddress>();

            if (masterCustomer.MasterAddressList != null)
            {

                for (int i = 0; i < masterCustomer.MasterAddressList.Count; i++)
                {
                    var address = masterCustomer.MasterAddressList[i];

                    BPAddress bpAddress = new BPAddress
                    {
                        AddressName = GetCityNameByCityId(address.CityId) ?? string.Empty,
                        ZipCode = address.Pincode ?? string.Empty,
                        City = GetCityNameByCityId(address.CityId) ?? string.Empty,
                        Country = "IN", // Assuming all addresses are in India
                        State = GetSateCodeBySateId(address.StateId) ?? string.Empty, // You may need to replace this with actual state code logic
                        AddressType = "bo_BillTo",
                        AddressName2 = address.Address1 ?? string.Empty,
                        AddressName3 = address.Address2 ?? string.Empty,
                        RowNum = i.ConvertToInt(),
                        GSTIN = address.GstTinNo ?? string.Empty,
                        GstType = "gstRegularTDSISD" ?? string.Empty,
                        U_PANNo = masterCustomer.MasterCustomerDetail.PanNo ?? string.Empty,

                    };

                    bpAddresses.Add(bpAddress);
                };
            }
         
            BPMasterModel bpmMasterModel = new BPMasterModel
            {
                Series = 720,
                CardName = masterCustomer.CustomerName ?? string.Empty,
                GroupCode = masterCustomer.groupCodeSelectedId, // Assuming a default group code
                CardType = "cCustomer",
                DefaultBranch = "FARIDABAD" ?? string.Empty,
                CompanyPrivate = "cPrivate", // Hardcoded as per JSON example
                DefaultAccount = "20091867546" ?? string.Empty,
                DefaultBankCode = "HDFC" ?? string.Empty,
                Industry = 2, // Hardcoded as per JSON example
                PayTermsGrpCode = 1,
                SalesPersonCode = -1,
                //       U_Controling_Branch = masterCustomer.Branch ?? string.Empty,
                ContactEmployees = BPContactEmployee.ToList(),
                BPBankAccounts = BPBankAccounts.ToList(),
                BPAddresses = bpAddresses.ToList()

            };
       
   
            // Call the SAP method and handle exceptions if needed
            await SaveTheCustomerMasterDataInSap(bpmMasterModel);

            return bpmMasterModel;
        }



        public async Task<Dictionary<string, object>> SaveTheCustomerMasterDataInSap(BPMasterModel masterCustomer)
        {
            try
            {
                string sessionId = SapSessionManagerController.GetSessionId();

                if (string.IsNullOrEmpty(sessionId))
                {
                    sessionId = await SapSessionManagerController.GenerateToken();
                }

                HttpClientHandler handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                };

                using (HttpClient client = new HttpClient(handler))
                {
                    
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                    client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
                    client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                    client.DefaultRequestHeaders.ExpectContinue = false;

                    // decompression
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("deflate"));
                    client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("br"));
                    CookieContainer cookies = new CookieContainer();
                    cookies.Add(new Cookie("B1SESSION", sessionId) { Domain = "103.194.8.71" });
                    cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "103.194.8.71" });
                    handler.CookieContainer = cookies;


                    // Append query string to URL

                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(masterCustomer);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://103.194.8.71:50000/b1s/v1/BusinessPartners", content);
                    var statusCode = response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                        {
                            using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                            using (var streamReader = new StreamReader(gzipStream))
                            {
                                string responseBodys = await streamReader.ReadToEndAsync();
                                IsSendSuccessfully = true;
                                //   ViewBag.responseData = responseBodys;
                                return new Dictionary<string, object> { { "responseData", responseBodys } };
                            }
                        }
                        return new Dictionary<string, object> { { "responseBody", responseBody } };
                    }
                    else
                    {
                        string errorMessage = $"Failed to Post BPMaster Data. Status code: {response.StatusCode}";
                        throw new HttpRequestException(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in SaveTheCustomerMasterDataInSap: {ex.Message}", ex);
            }
        }
        public string GetSateCodeBySateId(short sateId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StateId", sateId, DbType.Int16);

            // Execute the stored procedure and retrieve the state code
            string stateCode = DataBaseFactory.QuerySP<string>(
                "USP_GetStateCodeByStateId",
                dynamicParameters,
                "State Master - USP_GetStateCodeByStateId"
            ).FirstOrDefault();

            return stateCode;
        }
        
        public string GetCityNameByCityId(int CityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CityId", CityId, DbType.Int16);

            // Execute the stored procedure and retrieve the state code
            string stateCode = DataBaseFactory.QuerySP<string>(
                "USP_GetCityNameByCityId",
                dynamicParameters,
                "City Master - USP_GetCityNameByCityId"
            ).FirstOrDefault();

            return stateCode;
        }
    }
}
