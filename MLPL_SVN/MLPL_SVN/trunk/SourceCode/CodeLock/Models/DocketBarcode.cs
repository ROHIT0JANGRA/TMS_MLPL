using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class DocketBarcode
    {
        public DocketBarcode()
        {
            this.BarCodeList = new List<DocketBarcode>();
        }

        [Display(Name = "Docket No")]
        public long DocketId { get; set; }

        [Display(Name = "Docket No")]
        public string DocketNo { get; set; }

        [Display(Name = "BarCode")]
        public string BarCode { get; set; }

        [Display(Name = "barcodeTrnId")]
        public long barcodeTrnId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Origin")]
        public string Origin { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Display(Name = "Total Pkt")]
        public long TotalPkt { get; set; }

        [Display(Name = "To be scan")]
        public long TobeScan { get; set; }

        [Required(ErrorMessage = "Please enter Length")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Length")]
        [Display(Name = "Length")]
        public Decimal Length { get; set; }

        [Required(ErrorMessage = "Please enter Breadth")]
        [Display(Name = "Breadth")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Breadth")]
        public Decimal Breadth { get; set; }

        [Display(Name = "Height")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Height")]
        [Required(ErrorMessage = "Please enter Height")]
        public Decimal Height { get; set; }

        [Display(Name = "Actual Weight")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Actual Weight")]
        [Required(ErrorMessage = "Please enter Actual Weight")]
        public Decimal ActualWeight { get; set; }

        public List<DocketBarcode> BarCodeList { get; set; }

        [Display(Name = "From Bar Code")]
        [Required(ErrorMessage = "Please Enter From Bar Code")]
        public long FromBarCode { get; set; }

        [Display(Name = "To Bar Code")]
        [Required(ErrorMessage = "Please Enter To Bar Code")]
        public long ToBarCode { get; set; }

    }
}