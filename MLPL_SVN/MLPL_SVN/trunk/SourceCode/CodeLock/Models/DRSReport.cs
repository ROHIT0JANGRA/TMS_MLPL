using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class DRSReport
    {
        [Required(ErrorMessage = "Please select Level")]
        [Display(Name = "Level")]
        public short Level { get; set; }

        [Required(ErrorMessage = "Please select Level Type")]
        [Display(Name = "Level Type")]
        public short LevelType { get; set; }
    }
}