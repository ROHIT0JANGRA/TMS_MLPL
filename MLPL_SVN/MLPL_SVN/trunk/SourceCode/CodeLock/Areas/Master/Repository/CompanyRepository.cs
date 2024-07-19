//  
// Type: CodeLock.Areas.Master.Repository.CompanyRepository
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
  public class CompanyRepository : BaseRepository, ICompanyRepository, IDisposable
  {
    public MasterCompany GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCompany>("Usp_MasterCompany_GetById", (object) dynamicParameters, "Company Master - GetById").FirstOrDefault<MasterCompany>();
    }

    public IEnumerable<MasterCompany> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterCompany>("Usp_MasterCompany_GetAll", (object) null, "Company Master - GetAll");
    }

    public byte Insert(MasterCompany objMasterCompany)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@XmlCompany", (object) XmlUtility.XmlSerializeToString((object) objMasterCompany), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        dynamicParameters.Add("@CompanyId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
        DataBaseFactory.QuerySP("Usp_MasterCompany_Insert", (object) dynamicParameters, "Company Master - Insert");
        return dynamicParameters.Get<byte>("@CompanyId");
    }

    public byte Update(MasterCompany objMasterCompany)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCompany", (object) XmlUtility.XmlSerializeToString((object) objMasterCompany), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCompany_Update", (object) dynamicParameters, "Company Master - Update");
      return dynamicParameters.Get<byte>("@CompanyId");
    }

    public IEnumerable<AutoCompleteResult> GetVirtualLoginCompanyList(
      short loginUserId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@UserId", (object) loginUserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VirtualLogin_GetCompany", (object) dynamicParameters, "Company Master - GetVirtualLoginCompanyList");
    }

    public IEnumerable<AutoCompleteResult> GetVirtualLoginFinanceYearList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VirtualLogin_GetFinacialYear", (object) null, "Company Master - GetVirtualLoginFinanceYearList");
    }

    public IEnumerable<AutoCompleteResult> GetVirtualLoginFinanceYearListByUserId(
      short loginUserId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@UserId", (object) loginUserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VirtualLogin_GetFinacialYearByUserId", (object) dynamicParameters, "Company Master - GetVirtualLoginFinanceYearList");
    }

    public string GetVirtualLoginFinanceYearById(string finYearId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FinYearId", (object) finYearId, new DbType?(DbType.String), new ParameterDirection?(), new int?(4));
      dynamicParameters.Add("@FinYearName", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(10));
      DataBaseFactory.QuerySP("Usp_VirtualLogin_GetFinacialYearById", (object) dynamicParameters, "Company Master - GetVirtualLoginFinanceYearById");
      return dynamicParameters.Get<string>("@FinYearName");
    }

    public bool IsCompanyNameAvailable(string companyName, short companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyName", (object) companyName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCompany_IsNameAvailable", (object) dynamicParameters, "Company Master - IsCompanyNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetCompanyList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCompany_GetCompanyList", (object) null, "Company Master - GetCompanyList");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteCompanyList(
      string companyCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyCode", (object) companyCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCompany_GetAutoCompleteCompanyList", (object) dynamicParameters, "Company Master - GetAutoCompleteCompanyList");
    }

    public AutoCompleteResult IsCompanyCodeExist(string companyCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyCode", (object) companyCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCompany_IsCompanyCodeExist", (object) dynamicParameters, "Company Master - CheckValidCompanyCode").FirstOrDefault<AutoCompleteResult>();
    }
  }
}
