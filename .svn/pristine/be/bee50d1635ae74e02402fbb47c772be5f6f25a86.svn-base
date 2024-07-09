//  
// Type: CodeLock.Models.TripsheetCancellation
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class TripsheetCancellation
  {
    [Display(Name = "Tripsheet No")]
    public string TripsheetNo { get; set; }

    [Display(Name = "Manual Tripsheet No")]
    public string ManualTripsheetNo { get; set; }

    [Display(Name = "Tripsheet Cancellation Date")]
    public DateTime CancelDate { get; set; }

    [StringLength(200, ErrorMessage = "Cancel Reason must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
    [Required(ErrorMessage = "Please enter Cancel Reason")]
    [Display(Name = "Tripsheet Cancellation Reason")]
    public string CancelReason { get; set; }

    public List<Tripsheet> Details { get; set; }
  }

    public class TripsheetAdvanceCancellation
    {
        public long TripsheetId { get; set; }

        [Display(Name = "Tripsheet No")]
        public string TripsheetNo { get; set; }

        [Display(Name = "Manual Tripsheet No")]
        public string ManualTripsheetNo { get; set; }

        public long VoucherId { get; set; }

        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }

        [Display(Name = "Tripsheet Advance Cancellation Date")]
        public DateTime CancelDate { get; set; }

        [StringLength(200, ErrorMessage = "Cancel Reason must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter Cancel Reason")]
        [Display(Name = "Tripsheet Advance Cancellation Reason")]
        public string CancelReason { get; set; }

		public short CancelBy { get; set; }

		public List<Tripsheet> TripSheetList { get; set; }

        public List<DriverAdvance> DriverAdvanceList { get; set; }
    }
}
