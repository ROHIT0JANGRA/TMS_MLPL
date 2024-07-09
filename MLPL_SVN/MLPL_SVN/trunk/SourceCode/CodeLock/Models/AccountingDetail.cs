//  
// Type: CodeLock.Models.AccountingDetail
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class AccountingDetail
  {
    public short AccountId { get; set; }

    public short OppositeAccountId { get; set; }

    public Decimal DebitAmount { get; set; }

    public Decimal CreditAmount { get; set; }

    public string Narration { get; set; }
  }
}
