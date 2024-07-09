//  
// Type: CodeLock.Models.DrsClose
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DrsClose : Base
    {
        public long DrsId { get; set; }

        [Display(Name = "DRS Date")]
        public DateTime DrsDate { get; set; }

        [Display(Name = "DRS No")]
        public string DrsNo { get; set; }

        [Display(Name = "DRS No")]
        public string DrsNos { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Display(Name = "Start KM")]
        public int StartKm { get; set; }
        [Display(Name = "Vehicle No")]
        public string VehicleNo { get;set; }

        [Display(Name = "End KM")]
        [AssertThat("StartKm < EndKm", ErrorMessage = "Please enter End KM greater than Start KM")]
        public int EndKm { get; set; }

        public string DrsCloseRemarks { get; set; }
        public List<DrsDocket> DocketDetails { get; set; }
    }
}
