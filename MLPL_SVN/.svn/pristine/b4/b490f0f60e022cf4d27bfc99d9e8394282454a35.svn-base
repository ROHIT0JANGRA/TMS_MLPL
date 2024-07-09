//  
// Type: CodeLock.Areas.Master.Repository.ILocationHierarchyRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ILocationHierarchyRepository : IDisposable
  {
    IEnumerable<MasterLocationHierarchy> GetAll();

    MasterLocationHierarchy GetDetailById(byte id);

    Response Insert(MasterLocationHierarchy objLocationHierarchy);

    Response Update(MasterLocationHierarchy objLocationHierarchy);

    bool IsLocationHierarchyNameAvailable(string LocationHierarchyName, byte LocationHierarchyId);

    IEnumerable<AutoCompleteResult> GetLocationHierarchyList();
  }
}
