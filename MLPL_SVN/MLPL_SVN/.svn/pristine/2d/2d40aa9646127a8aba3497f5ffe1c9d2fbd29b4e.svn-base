//  
// Type: CodeLock.Areas.Master.Repository.IHsnRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IHsnRepository : IDisposable
  {
    IEnumerable<MasterHsn> GetAll();

    Response Insert(MasterHsn objSac);

    MasterHsn GetDetailById(byte id);

    Response Update(MasterHsn objSac);

    bool IsHsnCodeAvailable(string hsnCode, byte hsnId);

    bool IsHsnNameAvailable(string hsnName, byte hsnId);

    IEnumerable<AutoCompleteResult> GetHsnList();
  }
}
