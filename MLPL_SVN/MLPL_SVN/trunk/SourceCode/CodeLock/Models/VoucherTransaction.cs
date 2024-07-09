//  
// Type: CodeLock.Models.VoucherTransaction
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class VoucherTransaction
  {
    public long VoucherId { get; set; }

    public string VoucherNo { get; set; }

    public string TransactionType { get; set; }

    public short FromAccountId { get; set; }

    public short ToAccountId { get; set; }

    public long ChequeId { get; set; }

    public Decimal? Debit { get; set; }

    public Decimal? Credit { get; set; }

    public string DocumentNo { get; set; }

    public bool? IsCancel { get; set; }

    public Decimal? NetAmount { get; set; }

    public Decimal? CashAmount { get; set; }

    public Decimal? ChequeAmount { get; set; }

    public short EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public byte CompanyId { get; set; }
  }
}
