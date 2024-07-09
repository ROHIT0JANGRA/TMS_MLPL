//  
// Type: CodeLock.Models.DrsCancellation
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DrsCloseCancellation
    {
        [Display(Name = "Drs No")]
        public string DrsNo { get; set; }
        public long DrsId{ get; set; }


        [Display(Name = "Manual Drs No")]
        public string ManualDrsNo { get; set; }

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
