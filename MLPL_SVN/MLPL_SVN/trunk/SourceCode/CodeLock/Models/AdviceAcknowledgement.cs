//  
// Type: CodeLock.Models.AdviceAcknowledgement
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class AdviceAcknowledgement
  {
    public long AdviceId { get; set; }

    [Display(Name = "Advice No")]
    public string AdviceNo { get; set; }

    public string AdviceType { get; set; }

    public DateTime AdviceDate { get; set; }

    public string TransactionType { get; set; }

    public string TransactionDescription { get; set; }

    public string RaisedLocation { get; set; }

    public string Location { get; set; }

    public string AdviceStatus { get; set; }

    public Decimal Amount { get; set; }

    public string ChequeNo { get; set; }

    public DateTime ChequeDate { get; set; }

    public byte PaymentModeId { get; set; }

    public List<AdviceAcknowledgementDetail> Details { get; set; }
  }
}
