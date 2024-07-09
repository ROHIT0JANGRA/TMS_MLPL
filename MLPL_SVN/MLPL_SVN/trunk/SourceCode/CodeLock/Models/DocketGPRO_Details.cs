using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DocketGPRO_Details
    {
        [Display(Name = "Sr No.")]
        public int SNo { get; set; }

        [Display(Name = "GP Date")]
        public DateTime GPDate { get; set; }

        [Display(Name = "RO Date")]
        public DateTime RODate { get; set; }

        [Display(Name = "GP No")]
        public string GPNo { get; set; }

        [Display(Name = "RO No")]
        public string RONo { get; set; }

    }
}