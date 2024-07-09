using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class BarCodeModel
    {
        public BarCodeModel()
        {
            this.BarCode = "";
            this.Details = new List<BarCodeModel>();
        }
        public List<BarCodeModel> Details { get; set; }

        [Display(Name = "Barcode Id")]
        public string barcodeId { get; set; }

        [Required(ErrorMessage = "Please enter Bar Code")]
        [Display(Name = "BarCode")]
        public string BarCode { get; set; }

        [Display(Name = "BarCodeFile")]
        public string BarCodeFile { get; set; }
    }
}