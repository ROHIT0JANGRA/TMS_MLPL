
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class ThcStockUpdateCancellation
    {
        [Display(Name = "Thc No")]
        public string ThcNo { get; set; }

        public long ThcId { get; set; }

        [Display(Name = "Manual Thc No")]
        public string ManualThcNo { get; set; }

        public short? CancelBy { get; set; }

        public short LocationId { get; set; }

        [Required(ErrorMessage = "Please Enter Cancel Reason")]
        [Display(Name = "Cancel Reason")]
        public string CancelReason { get; set; }

        [Required(ErrorMessage = "Please Enter Cancel Date")]
        [Display(Name = "Cancel Date")]

        public DateTime CancelDate { get; set; }

    }
}