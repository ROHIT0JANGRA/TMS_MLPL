
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class BillFinalization : Base
    {
        [Display(Name = "Finalization Date")]
        public DateTime FinalizationDate { get; set; }

        [Display(Name = "Billing Party")]
        [RequiredIf("BillNo == null", ErrorMessage = "Please enter Billing Party")]
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        [Display(Name = "Bill No(s)")]
        public string BillNo { get; set; }

        [Display(Name = "Manual Bill No(s)")]
        public string ManualBillNo { get; set; }

        public string FinYear { get; set; }

        public short LocationId { get; set; }

        [Display(Name = "Bill Type")]
        [Required(ErrorMessage = "Please select Bill Type")]
        public byte PaybasId { get; set; }
        [Display(Name = "Remarks")]
        public string BillFinalizationRemarks { get; set; }
        public List<BillFinalizationDetail> Details { get; set; }
        [Display(Name = "Customer Type")]
        [Required(ErrorMessage = "Please select Customer Type")]
        public Byte CustomerTypeId { get; set; }
    }
}
