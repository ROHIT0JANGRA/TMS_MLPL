//  
// Type: CodeLock.Areas.Master.Repository.IAccountRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAccountRepository : IDisposable
  {
    IEnumerable<MasterAccount> GetAll();

    MasterAccount GetById(short id);

    short Insert(MasterAccount objMasterAccount);

    short Update(MasterAccount objMasterAccount);

    bool IsAccountCodeAvailable(string accountCode, short accountId);

    IEnumerable<ChartOfAccount> GetChartOfAccount();

    IEnumerable<AutoCompleteResult> GetAllAccountCodeList();

    IEnumerable<MasterTax> GetTaxDetails();

    AutoCompleteResult IsAccountCodeExist(string accountCode);

    IEnumerable<AutoCompleteResult> GetAccountAutoCompleteList(
      string accountCode);

    IEnumerable<AutoCompleteResult> GetAccountListForCardCategory();

    IEnumerable<AutoCompleteResult> GetAccountListByAccountCategoryId(
      byte categoryId);

    Cheque IsChequeExistForCollection(string chequeNo, DateTime chequeDate, byte partyTypeId, short partyId);

    bool IsChequeExist(string chequeNo, DateTime chequeDate, byte partyTypeId, short partyId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteVendorAccountList(string vendorCode, byte vendorType, byte LocationId);
    }
}
