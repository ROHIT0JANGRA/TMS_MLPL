//  
// Type: CodeLock.Areas.Master.Repository.IReceiverRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IReceiverRepository : IDisposable
  {
    MasterReceiver GetById(byte id);

    IEnumerable<MasterReceiver> GetAll();

    byte Insert(MasterReceiver objMasterReceiver);

    byte Update(MasterReceiver objMasterReceiver);

    IEnumerable<AutoCompleteResult> GetAutoCompleteReceiverListByLocation(
      string receiverCode,
      short locationId,
      byte companyId);

    AutoCompleteResult IsReceiverCodeExistByLocation(
      string receiverCode,
      short locationId,
      byte companyId);

    bool IsReceiverNameAvailable(string receiverName, short receiverId);
  }
}
