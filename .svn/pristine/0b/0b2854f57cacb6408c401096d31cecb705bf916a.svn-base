//  
// Type: CodeLock.Models.JournalVoucher
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class JournalVoucher
  {
    public JournalVoucher()
    {
      this.Details = new List<JournalVoucherDetail>();
    }

    public byte CompanyId { get; set; }

    [Display(Name = "Voucher No")]
    public string VoucherNo { get; set; }

    [Display(Name = "Voucher Date")]
    public DateTime VoucherDate { get; set; }

    [Required(ErrorMessage = "Please enter Manual No")]
    [StringLength(25, ErrorMessage = "Manual No must be minimum 2 and maximum 25 character long", MinimumLength = 2)]
    [Display(Name = "Manual No")]
    public string ManualNo { get; set; }

    [StringLength(50, ErrorMessage = "Reference No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Reference No")]
    [Display(Name = "Reference No")]
    public string ReferenceNo { get; set; }

    [Display(Name = "Prepared at Location")]
    public short PreparedLocationId { get; set; }

    public string PreparedLocationCode { get; set; }

    public byte CodeType { get; set; }

    [Display(Name = "Paid To/Received From")]
    public short CodeId { get; set; }

    [Required(ErrorMessage = "Please enter Paid To")]
    public string Code { get; set; }

    public string PartyName { get; set; }

    [StringLength(200, ErrorMessage = "Narration must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Narration")]
    [Display(Name = "Narration")]
    public string Narration { get; set; }

    [Display(Name = "Plz Check Here To Apply Common Cost Center")]
    public bool CostCenterSelection { get; set; }

    [Required(ErrorMessage = "Please select Cost Center Type")]
    [Display(Name = "Cost Center Type")]
    public byte CostCenterType { get; set; }

    [Display(Name = "Cost Center")]
    public short CostCenterId { get; set; }

    [Required(ErrorMessage = "Please enter Cost Center")]
    public string CostCenter { get; set; }

    public Decimal DebitAmount { get; set; }

    public Decimal CreditAmount { get; set; }

    public short Perticular { get; set; }

    public short EntryBy { get; set; }

    public string FinYear { get; set; }

    public List<JournalVoucherDetail> Details { get; set; }
  }
}
