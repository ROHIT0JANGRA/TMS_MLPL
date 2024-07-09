using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerBillCancellation
  {
    public CustomerBillCancellation()
    {
      this.BillNo = "";
    }

    [Display(Name = "Bill No")]
    public string BillNo { get; set; }

    [Display(Name = "Manual Bill No")]
    public string ManualBillNo { get; set; }

    [Display(Name = "Bill Type")]
    public byte PaybasId { get; set; }

    [Display(Name = "Billing Party")]
    public short CustomerId { get; set; }

    [Display(Name = "Billing Party")]
    public string CustomerCode { get; set; }

    [Display(Name = "Cancel Date")]
    public DateTime CancelledDate { get; set; }

    [Required(ErrorMessage = "Please enter Cancel Reason")]
    [Display(Name = "Cancel Reason")]
    [StringLength(200, ErrorMessage = "Cancel Reason must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    public string CancelledReason { get; set; }

    public List<BillCancellationDetail> Details { get; set; }
  }
}
