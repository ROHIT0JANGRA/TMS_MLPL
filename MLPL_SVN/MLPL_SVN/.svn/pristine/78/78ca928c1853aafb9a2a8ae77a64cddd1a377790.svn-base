//  
// Type: CodeLock.Areas.Master.Repository.IConsignorConsigneeRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IConsignorConsigneeRepository : IDisposable
  {
    MasterConsignorConsigneeMapping GetById(short mappingId);

    IEnumerable<MasterConsignorConsigneeMapping> GetAll();

    short Insert(
      MasterConsignorConsigneeMapping objMasterConsignorConsigneeMapping);

    short Update(
      MasterConsignorConsigneeMapping objMasterConsignorConsigneeMapping);

    bool IsMappingAvailable(
      short mappingId,
      short consignorId,
      short consigneeId,
      short billingPartyId);
  }
}
