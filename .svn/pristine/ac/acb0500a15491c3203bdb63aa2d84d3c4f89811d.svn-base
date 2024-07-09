//  
// Type: CodeLock.Areas.Master.Repository.IAccountOpeningPartyRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAccountOpeningPartyRepository : IDisposable
  {
    IEnumerable<AutoCompleteResult> GetCustomerAccountList();

    IEnumerable<AutoCompleteResult> GetVendorAccountList();

    Response InsetUpdate(MasterAccountOpeningParty objAccountOpeningParty);

    MasterAccountOpeningParty GetCreditDebit(
      short partyType,
      int partyId,
      byte locationId,
      short accountId,
      string finYear);
  }
}
