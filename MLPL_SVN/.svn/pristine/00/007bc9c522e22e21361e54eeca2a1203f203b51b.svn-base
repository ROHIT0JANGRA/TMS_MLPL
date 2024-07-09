//  
// Type: CodeLock.Areas.Master.Repository.ISupplierRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ISupplierRepository : IDisposable
  {
    IEnumerable<MasterSupplier> GetAll();

    MasterSupplier GetById(byte id);

    Response Insert(MasterSupplier objMasterSupplier);

    byte Update(MasterSupplier objMasterSupplier);

    bool IsSupplierNameAvailable(string supplierName, short supplierId);

    AutoCompleteResult IsSupplierCodeExist(byte companyId, string supplierCode);

    IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      byte companyId,
      string supplierCode);
  }
}
