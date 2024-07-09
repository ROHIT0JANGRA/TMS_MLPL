using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CodeLock.Models
{
    public class VendorAdvancePaymentCancellation
    {
        public long PaymentId { get; set; }

        [Display(Name = "Payment No")]
        public string PaymentNo { get; set; }

        public DateTime PaymentDate { get; set; }

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public List<PaymentCancellationDetail> Details { get; set; }
    }
}