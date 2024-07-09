using System;
using ExpressiveAnnotations.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VendorBillCancellation
    {
        [Display(Name = "Location")]
        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public short VendorId { get; set; }

        [RequiredIf("BillNo == null", ErrorMessage = "Please enter Vendor")]
        [Display(Name = "Vendor")]
        public string VendorCode { get; set; }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        public short EntryBy { get; set; }

        public byte CompanyId { get; set; }

        public string FinYear { get; set; }

        [Display(Name = "Cancel Date")]
        public DateTime CancelledDate { get; set; }

        [Required(ErrorMessage = "Please enter Cancel Reason")]
        [Display(Name = "Cancel Reason")]
        [StringLength(200, ErrorMessage = "Cancel Reason must be minimum 2 and maximum 200 character long", MinimumLength = 2)]
        public string CancelledReason { get; set; }

        public List<VendorBillCancelDetail> BillDetail { get; set; }
    }
}