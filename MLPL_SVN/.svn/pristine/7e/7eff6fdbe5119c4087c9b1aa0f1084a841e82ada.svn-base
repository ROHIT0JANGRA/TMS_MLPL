//  
// Type: CodeLock.Areas.Master.Repository.ICompanyRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ICompanyRepository : IDisposable
  {
    MasterCompany GetById(byte id);

    IEnumerable<MasterCompany> GetAll();

    byte Insert(MasterCompany objMasterCompany);

    byte Update(MasterCompany objMasterCompany);

    IEnumerable<AutoCompleteResult> GetVirtualLoginCompanyList(
      short loginUserId);

    IEnumerable<AutoCompleteResult> GetVirtualLoginFinanceYearList();

    IEnumerable<AutoCompleteResult> GetVirtualLoginFinanceYearListByUserId(
      short loginUserId);

    string GetVirtualLoginFinanceYearById(string finYearId);

    bool IsCompanyNameAvailable(string companyName, short companyId);

    IEnumerable<AutoCompleteResult> GetCompanyList();

    IEnumerable<AutoCompleteResult> GetAutoCompleteCompanyList(
      string companyCode);

    AutoCompleteResult IsCompanyCodeExist(string companyCode);
  }
}
