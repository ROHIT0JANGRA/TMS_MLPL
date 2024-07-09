//  
// Type: CodeLock.Areas.Master.Repository.AccountRepository
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
    public class AccountRepository : BaseRepository, IAccountRepository, IDisposable
    {
        public IEnumerable<MasterAccount> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterAccount>("Usp_MasterAccount_GetAll", (object)null, "Account Master - GetAll");
        }

        public MasterAccount GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AccountId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterAccount>("Usp_MasterAccount_GetById", (object)dynamicParameters, "Account Master - GetById").FirstOrDefault<MasterAccount>();
        }

        public short Insert(MasterAccount objMasterAccount)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlAccount", (object)XmlUtility.XmlSerializeToString((object)objMasterAccount), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AccountId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterAccount_Insert", (object)dynamicParameters, "Account Master - Insert");
            return dynamicParameters.Get<short>("@AccountId");
        }

        public short Update(MasterAccount objMasterAccount)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlAccount", (object)XmlUtility.XmlSerializeToString((object)objMasterAccount), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AccountId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterAccount_Update", (object)dynamicParameters, "Account Master - Update");
            return dynamicParameters.Get<short>("@AccountId");
        }

        public bool IsAccountCodeAvailable(string accountCode, short accountId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AccountId", (object)accountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AccountCode", (object)accountCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterAccount_IsCodeAvailable", (object)dynamicParameters, "Account Master - IsAccountCodeAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<ChartOfAccount> GetChartOfAccount()
        {
            return DataBaseFactory.QuerySP<ChartOfAccount>("Usp_MasterAccount_GetChartOfAccount", (object)null, "Account Master - GetChartOfAccount");
        }

        public IEnumerable<AutoCompleteResult> GetAllAccountCodeList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccount_GetAllAccountCodeList", (object)null, "Account Master - GetAllAccountCodeList");
        }

        public IEnumerable<MasterTax> GetTaxDetails()
        {
            return DataBaseFactory.QuerySP<MasterTax>("Usp_MasterAccount_GetTaxDetails", (object)null, "Account Master - GetTaxDetails");
        }

        public AutoCompleteResult IsAccountCodeExist(string accountCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AccountCode", (object)accountCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccount_IsAccountCodeExist", (object)dynamicParameters, "Account Master - IsAccountCodeExist").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetAccountAutoCompleteList(
          string accountCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AccountCode", (object)accountCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)SessionUtility.LoginLocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccount_GetAccountAutoCompleteList", (object)dynamicParameters, "Account Master - GetAccountAutoCompleteList");
        }

        public IEnumerable<AutoCompleteResult> GetAccountListForCardCategory()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccount_GetAccountListForCardCategory", (object)null, "Account Master - GetAccountListForCardCategory");
        }

        public IEnumerable<AutoCompleteResult> GetAccountListByAccountCategoryId(
          byte categoryId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CategoryId", (object)categoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccount_GetAccountListByAccountCategoryId", (object)dynamicParameters, "Account Master - GetAccountListByAccountCategoryId");
        }

        public Cheque IsChequeExistForCollection(string chequeNo, DateTime chequeDate, byte partyTypeId, short partyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ChequeNo", (object)chequeNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChequeDate", (object)chequeDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartyTypeId", (object)partyTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartyId", (object)partyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Cheque>("Usp_MasterAccount_IsChequeExistForCollection", (object)dynamicParameters, "Account Master - IsChequeExistForCollection").FirstOrDefault<Cheque>();
        }

        public bool IsChequeExist(string chequeNo, DateTime chequeDate, byte partyTypeId, short partyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ChequeNo", (object)chequeNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChequeDate", (object)chequeDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartyTypeId", (object)partyTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartyId", (object)partyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsChequeExist", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP<Cheque>("Usp_MasterAccount_IsChequeExist", (object)dynamicParameters, "Account Master - IsChequeExist").FirstOrDefault<Cheque>();
            return dynamicParameters.Get<bool>("@IsChequeExist");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompleteVendorAccountList(string vendorCode, byte vendorTypeId, byte LocationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorCode", (object)vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorTypeId", (object)vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetAutoCompleteVendorAccountList", (object)dynamicParameters, "Vendor Master - GetAutoCompleteVendorAccountList");
        }
    }
}
