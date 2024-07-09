using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CodeLock.Models
{
    public class MasterTyrePattern
    {
        [Display(Name = "TyrePattern ID")]
        public byte TyrePatternId { get; set; }

        [Display(Name = "TyrePattern Code")]
        public string TyrePatternCode { get; set; }

        [Display(Name = "TyrePattern Description")]
        public string TyrePatternDescription { get; set; }

        [Display(Name = "Position Allowed ")]
        public byte PositionAllowed { get; set; }

        [Display(Name = "IsActive ")]
        public bool IsActive { get; set; }

        public short EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public short UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}