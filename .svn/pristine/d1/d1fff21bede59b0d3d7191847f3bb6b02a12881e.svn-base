//  
// Type: CodeLock.Areas.Master.Repository.IAccountOpeningRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  internal interface IAccountOpeningRepository : IDisposable
  {
    IEnumerable<AccountOpeningDetail> GetAll(
      bool isLocationWise,
      short id,
      byte accountCategoryId,
      short accountId,
      short locationId);

    Response InsetUpdate(MasterAccountOpening objAccountOpening);
  }
}
