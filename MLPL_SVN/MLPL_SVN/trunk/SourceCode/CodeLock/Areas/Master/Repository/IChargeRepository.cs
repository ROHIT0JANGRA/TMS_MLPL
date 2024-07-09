//  
// Type: CodeLock.Areas.Master.Repository.IChargeRepository
//  
//  
//  

using CodeLock.Models;
using System;

namespace CodeLock.Areas.Master.Repository
{
  public interface IChargeRepository : IDisposable
  {
    MasterCharge GetChargeByTypeId(byte chargeType, byte chargeCode);
  }
}
