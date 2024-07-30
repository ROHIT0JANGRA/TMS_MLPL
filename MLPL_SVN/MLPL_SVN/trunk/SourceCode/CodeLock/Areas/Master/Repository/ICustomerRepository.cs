//  
// Type: CodeLock.Areas.Master.Repository.ICustomerRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<AutoCompleteResult> GetCustomerListAssignUserwise(int UserId);
        IEnumerable<AutoCompleteResult> GetCustomerListUserwise(int UserId);
        IEnumerable<MasterCustomer> GetAll();

        MasterCustomer GetById(int id);

        int Insert(MasterCustomer objMasterCustomer);
        string GetCustomerAddressCode(int AddressId);

        int Update(MasterCustomer objMasterCustomer);

        bool IsCustomerNameAvailable(string CustomerName, short CustomerId);

        bool IsCustomerNameExistWithGstNo(string CustomerName, string gstNo);

        IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerListByLocationPaybas(
          short locationId,
          byte paybasId,
          string customerName,
          bool allowWalkIn, bool isGstTypeCustomer);



        IEnumerable<AutoCompleteResult> GetCustomerList();

        MasterCustomer IsCustomerExistByLocationPaybas(
          short locationId,
          byte paybasId,
          string customerCode,
          bool allowWalkIn);




        IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerList(
          string customerCode,
          byte companyId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerListByLocation(
          string customerCode,
          short locationId,
          byte companyId);

        AutoCompleteResult IsCustomerCodeExist(string customerCode, byte companyId);

        AutoCompleteResult IsCustomerCodeExistByLocation(
          string customerCode,
          short locationId,
          byte companyId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteListByPaybasId(
          string customerCode);

        IEnumerable<AutoCompleteResult> GetLocationListByCustomerId(
          short customerId);

        IEnumerable<AutoCompleteResult> GetCustomerListByGroupCode(
          string groupCode);

        IEnumerable<AutoCompleteResult> GetAutocompleteConsigneeList(
          string consigneeName);

        Docket GetConsigneeDetailByName(string consigneeName);

        IEnumerable<AutoCompleteResult> GetCustomerListByPaybasId(
          byte payBasId);

        MasterCustomer IsCustomerCodeExistForOrder(
            string customerCode,
            byte companyId);



        MasterCustomer IsCustomerExistByLocationPaybasWithGST(
             short locationId,
             byte paybasId,
             string customerCode,
             bool allowWalkIn);
        IEnumerable<AutoCompleteResult> GetAutoCompleteCustomerListByLocationPaybasWithGST(
          short locationId,
          byte paybasId,
          string customerName,
          bool allowWalkIn);
        GetBycustomerName GetDetailByName(string customerName);

        IEnumerable<MasterCustomer> GetCustomersByPagination(int pageNo, int pageSize, string sorting, string search);

        IEnumerable<AutoCompleteResult> GetDropDownCustomerList(byte companyId);
        IEnumerable<CustomerExcelData> GetCustomerExcelData();

        IEnumerable<AutoCompleteResult> GetCustomerListByLocation(
        short locationId);
       IEnumerable<AutoCompleteResult> GetAutoCompleteGstCustomerList(
     string customerCode,
     byte customerTypeId,
     byte companyId);
        IEnumerable<AutoCompleteResult> GetAutoCompleteGstTinNo(
     string gstTinNo,
     byte paybasId);
        IEnumerable<AutoCompleteResult> GetAutoCompletePanNoAndMobileNo(
    string panNo);
        IEnumerable<AutoCompleteResult> GetAutoCompleteMobileNo(
    string mobileNo,
    byte paybasId);
        IEnumerable<AutoCompleteResult> GetAutoCompletePanNo(
    string panNo, 
    byte paybasId);
    }
}
