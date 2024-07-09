//  
// Type: CodeLock.Areas.Finance.Repository.IBankingRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Finance.Repository
{
  public interface IBankingRepository : IDisposable
  {
    Cheque GetChequeDetail(DateTime chequeDate, string chequeNo);

    Response ChequeDeposit(Cheque objCheque);

    IEnumerable<BankReconcilationChequeDetails> GetChequeDetailsForBankReconciliation(
      BankReconcilation objBankReconcilation);

    Response BankReconcilationUpdate(BankReconcilation objBankReconcilation);
    BankReccoOpng GetOpeningBalDtl(short LocationId, DateTime FromDate, DateTime ToDate, short BankAccountId);
    
    }
}
