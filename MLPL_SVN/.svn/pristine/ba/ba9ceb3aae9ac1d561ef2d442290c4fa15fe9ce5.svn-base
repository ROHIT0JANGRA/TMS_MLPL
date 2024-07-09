//  
// Type: CodeLock.Areas.Master.Repository.IAddressRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAddressRepository : IDisposable
  {
    IEnumerable<MasterAddress> GetAll();

    MasterAddress GetById(short id);

    short Insert(MasterAddress objMasterAddress);

    short Update(MasterAddress objMasterAddress);

    bool IsAddressCodeAvailable(string addressCode, short addressId);

    IEnumerable<MasterAddress> GetAddressByContractId(short contractId);
  }
}
