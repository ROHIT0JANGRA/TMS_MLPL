//  
// Type: CodeLock.Areas.Master.Repository.ITripCheckListRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ITripCheckListRepository : IDisposable
  {
    IEnumerable<MasterTripCheckList> GetAll();

    MasterTripCheckList GetDetailById(byte id);

    Response Insert(MasterTripCheckList ObjTripCheckList);

    Response Update(MasterTripCheckList ObjTripCheckList);

    IEnumerable<MasterTripCheckListDocument> GetCashTripCheckListDetail(
      byte id);
  }
}
