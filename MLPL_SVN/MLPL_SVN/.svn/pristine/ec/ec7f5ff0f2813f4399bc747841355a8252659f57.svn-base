using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class BarcodePrint
    {
        public byte IsDetectFailure { get; set; }

        [Display(Name = "Enter GRN No")]
        public string GRNNo { get; set; }

        [Display(Name = "Select Installed Printer")]
        [Required(ErrorMessage = "Please select Installed Printer")]
        public string InstalledPrinter { get; set; }

        [Display(Name = "Select Printer DPI Type")]
        public string PrinterDPIType { get; set; }
    }

    public class LocationCodePrint
    {

        public string DocketNo { get; set; }
        public string FromLocation { get; set; }
        public string EntryDate { get; set; }
        public string PRICE { get; set; }
        public string LOCATIONCODE { get; set; }
        public string PRINTTYPE { get; set; }
        public string USNNOLineBraek { get; set; }
        public string USNCOUNT { get; set; }
    }
    public class DocketBarcodePrint
    {
        public long DocketId { get; set; }
        public string DocketNo { get; set; }
    }
}