
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerBillUnSubmission
  {
    public CustomerBillUnSubmission()
    {
      this.BillNo = "";
    }

    [Display(Name = "Bill No")]
    public string BillNo { get; set; }

    [Display(Name = "Manual Bill No")]
    public string ManualBillNo { get; set; }

    [Required(ErrorMessage = "Please select Bill Type")]
    [Display(Name = "Bill Type")]
    public byte PaybasId { get; set; }

    [Display(Name = "Billing Party")]
    public short CustomerId { get; set; }

    [Display(Name = "Billing Party")]
    public string CustomerCode { get; set; }
    public short EntryBy { get; set; }
    public List<BillSubmissionDetail> Details { get; set; }
  }
}
