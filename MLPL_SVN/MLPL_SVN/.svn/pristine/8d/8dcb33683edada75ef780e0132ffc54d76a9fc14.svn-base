//  
// Type: CodeLock.Models.PaymentDetail
//  
//  
//  

using System;
using System.Collections.Generic;

namespace CodeLock.Models
{
  public class PaymentDetail : BaseModel
  {
    public PaymentDetail()
    {
      this.IsPayment = true;
      this.ChequeDetail = new Cheque();
      this.Details = new List<AccountingDetail>();
    }

    public bool IsPayment { get; set; }

    public short LocationId { get; set; }

    public int FinYear { get; set; }

    public string LocationCode { get; set; }

    public string DocumentNo { get; set; }

    public string VoucherNo { get; set; }

    public long VoucherId { get; set; }

    public string Narration { get; set; }

    public Decimal NetAmount { get; set; }

    public DateTime TransactionDate { get; set; }

    public byte PaymentMode { get; set; }

    public string PartyCode { get; set; }

    public string PartyName { get; set; }

    public byte PartyType { get; set; }

    public Decimal CashAmount { get; set; }

    public short CashAccountId { get; set; }

    public Cheque ChequeDetail { get; set; }

    public byte TransactionType { get; set; }

    public byte EntryModuleId { get; set; }

    public bool UseVoucherNoAsDocumentNo { get; set; }

    public List<AccountingDetail> Details { get; set; }
  }
}
