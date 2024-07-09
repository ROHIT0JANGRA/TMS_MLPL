//  
// Type: CodeLock.Areas.Master.Repository.IBinHierarchyRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IBinHierarchyRepository : IDisposable
  {
    IEnumerable<MasterBinHierarchy> GetAll();

    byte Insert(MasterBinHierarchy objMasterBinHierarchy);

    byte Update(MasterBinHierarchy objMasterBinHierarchy);

    MasterBinHierarchy GetDetailById(byte id);

    bool IsBinHierarchyNameAvailable(string binHierarchyName, short binHierarchyId);

    IEnumerable<AutoCompleteResult> GetBinHierarchyList();
  }
}
