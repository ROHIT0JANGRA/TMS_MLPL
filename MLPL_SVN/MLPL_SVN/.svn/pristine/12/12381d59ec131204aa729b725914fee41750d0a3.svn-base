//  
// Type: CodeLock.Areas.Master.Repository.ISkuRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ISkuRepository : IDisposable
  {
        IEnumerable<Stock> InventoryAll();

        IEnumerable<MasterSku> GetAll();

    MasterSku GetDetailById(int id);

    Response Insert(MasterSku objSku);

    Response Update(MasterSku objSku);

    IEnumerable<AutoCompleteResult> GetAutoCompleteSkuList(
      byte companyId,
      string skuCode);

    MasterSku IsSkuCodeExist(byte companyId, string skuCode);

    bool IsSkuNameAvailable(string SkuName, int SkuId);

    bool IsSkuCodeAvailable(string SkuCode, int SkuId);

    IEnumerable<AutoCompleteResult> GetSkuList();

    IEnumerable<AutoCompleteResult> GetAutoCompleteListByMaterialCategoryId(
      string skuName,
      byte materialCategoryId);

    AutoCompleteResult IsSkuNameExistForPurchaseOrder(
      string skuName,
      byte materialCategoryId);
  }
}
