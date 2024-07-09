//  
// Type: CodeLock.Areas.Master.Repository.IBinsRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IBinsRepository : IDisposable
  {
    IEnumerable<MasterBins> GetAll();

    MasterBins GetById(int id);

        int Insert(MasterBins objMasterBins);

        int Update(MasterBins objMasterBins);

    bool IsBinCodeAvailable(string binCode, int bindId);

    bool IsBinNameAvailable(string binName, int bindId);

    AutoCompleteResult GetParentHierarchy(byte binHierarchyId);

    IEnumerable<AutoCompleteResult> GetParentBinList(
      byte binHierarchyId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string binCode,
      short warehouseId);

    AutoCompleteResult IsBinCodeExist(string binCode, short warehouseId);
    IEnumerable<MasterBins> IsBinNameAvailableBySku(string SkuId, string BindId);
  }
}
