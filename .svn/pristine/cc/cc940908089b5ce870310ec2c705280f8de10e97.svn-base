using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class ThcAdvBalPaymnt_Details
    {
        [Display(Name = "Advance Location")]
        [Required(ErrorMessage = "Please Select Advance Location")]
        public short AdvBalLoc { get; set; }
        

        [Required(ErrorMessage = "Please enter Advance Amount")]
        [Range(0.001, 999999999999.0, ErrorMessage = "Please enter Advance Amount")]
        [Display(Name = "Advance Amount")]
        public Decimal AdvBalAmount { get; set; }

        public bool IsAdvanceDone { get; set; }

        public string AdvanceDone { get; set; }
    }
}