//  
// Type: CodeLock.Areas.Master.Repository.IFuelSurchargeRevisioinRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IFuelSurchargeRevisioinRepository : IDisposable
  {
    IEnumerable<FuelSurchargeRevision> GetAll();

    FuelSurchargeRevision GetById(short id);

    string GetManualContractId(short contractId);

    Response Insert(FuelSurchargeRevision objFuelSurchargeRevision);

    Response Update(FuelSurchargeRevision objFuelSurchargeRevision);
  }
}
