using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VoucherCancellation
    {
        public long VoucherId { get; set; }

        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }

        public DateTime VoucherDate { get; set; }

        public List<VoucherCancellationDetail> Details { get; set; }
    }
}