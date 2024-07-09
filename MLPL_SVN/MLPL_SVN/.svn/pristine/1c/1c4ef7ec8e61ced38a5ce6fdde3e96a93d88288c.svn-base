using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DocketOtherCharges
    {
        public DocketOtherCharges()
        {
            this.DocketNo = "";
            this.Details = new List<DocketOtherCharges>();
        }

        [Display(Name = "DocketId")]
        public int DocketId { get; set; }

        [Display(Name = "Docket No")]
        public string DocketNo { get; set; }

        [Display(Name = "From Location")]
        public string FromLocation { get; set; }

        [Display(Name = "To Location")]
        public string ToLocation { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Display(Name = "Paybas")]
        public string Paybas { get; set; }

        [Display(Name = "TransportMode")]
        public string TransportMode { get; set; }

        [Display(Name = "Docket Date")]
        public DateTime DocketDate { get; set; }

        [Display(Name = "Charge Type")]
        public string ChargeType { get; set; }

        [Display(Name = "Charge Code")]
        public int ChargeCode { get; set; }

        [Display(Name = "Re-Attempt Count")]
        public int ChargesCount { get; set; }

        [Display(Name = "Charge Amount")]
        public decimal ChargesAmount { get; set; }

        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }

        [Display(Name = "Sgst")]
        public decimal Sgst { get; set; }

        [Display(Name = "Cgst")]
        public decimal Cgst { get; set; }

        [Display(Name = "Igst")]
        public decimal Igst { get; set; }

        [Display(Name = "TaxTotal")]
        public decimal TaxTotal { get; set; }

        [Display(Name = "GrandTotal")]
        public decimal GrandTotal { get; set; }

        [Display(Name = "GstRate")]
        public decimal GstRate { get; set; }

        public List<DocketOtherCharges> Details { get; set; }


    }
}