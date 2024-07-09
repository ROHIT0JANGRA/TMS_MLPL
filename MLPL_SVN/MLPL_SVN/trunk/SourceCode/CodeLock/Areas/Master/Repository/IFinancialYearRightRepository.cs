//  
// Type: CodeLock.Areas.Master.Repository.IFinancialYearRightRepository
//  
//  
//  

using CodeLock.Models;
using System;

namespace CodeLock.Areas.Master.Repository
{
  public interface IFinancialYearRightRepository : IDisposable
  {
    Response Insert(
      MasterFinancialYearRight objMasterFinancialYearRight);
  }
}
