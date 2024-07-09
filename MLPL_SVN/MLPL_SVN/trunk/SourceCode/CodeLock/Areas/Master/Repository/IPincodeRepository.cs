//  
// Type: CodeLock.Areas.Master.Repository.IPincodeRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IPincodeRepository : IDisposable
  {
     MasterPincode IsPincodeExist(string Pincode);
    IEnumerable<AutoCompleteResult> GetAutoCompletePincodeList(string Pincode);
    IEnumerable<MasterPincode> GetAll();

    MasterPincode GetById(byte id);

    byte Insert(MasterPincode objMasterPincode);

    byte Update(MasterPincode objMasterPincode);

    bool IsPincodeAvailable(string pincode, int pincodeId);
  }
}
