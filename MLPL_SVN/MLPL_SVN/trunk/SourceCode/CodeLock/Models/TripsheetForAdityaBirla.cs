using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{

    public class TripsheetForAdityaBirlaMain
    {
        public TripsheetForAdityaBirlaMain()
        {
            this.TripsheetList = new List<TripsheetForAdityaBirla>();
            this.SummaryList = new List<TripsheetForAdityaBirlaSummary>();
            this.EWBNList = new List<TripsheetForAdityaBirlaEWBN>();
        }

        public List<TripsheetForAdityaBirla> TripsheetList { get; set; }
        public List<TripsheetForAdityaBirlaSummary> SummaryList { get; set; }
        public List<TripsheetForAdityaBirlaEWBN> EWBNList { get; set; }


    }
    public class TripsheetForAdityaBirla
    {
        [Display(Name = "Tripsheet Date")]
        public string tripsheetdate { get; set; }

        [Display(Name = "WHSE")]
        public string whseid { get; set; }

        [Display(Name = "From City")]
        public string fromcity { get; set; }

        [Display(Name = "Tripsheet No.")]
        public string tripsheetno { get; set; }

        [Display(Name = "Doc No.")]
        public string dcno { get; set; }

        [Display(Name = "LR No.")]
        public string lrno { get; set; }

        [Display(Name = "Carton No")]
        public string cartonno { get; set; }

        [Display(Name = "No of Pieces")]
        public string noofpieces { get; set; }
        public string custtype { get; set; }

        [Display(Name = "Showroom No")]
        public string shroomno { get; set; }

        [Display(Name = "Showroom Name")]
        public string shroomname { get; set; }
        public string shroomaddress1 { get; set; }
        public string shroomaddress2 { get; set; }

        [Display(Name = "To City")]
        public string shroomcity { get; set; }

        [Display(Name = "To Pin No.")]
        public string shroompin { get; set; }
        public string shroomphone { get; set; }
        public string shroommail { get; set; }
        public string transportername { get; set; }
        public string transcode { get; set; }
    }
    public class TripsheetForAdityaBirlaSummary
    {
        public string tripsheetsumid { get; set; }

        [Display(Name = "Plant Code")]
        public string plantcode { get; set; }

        [Display(Name = "Tripsheet No")]
        public string tripsheetno { get; set; }

        [Display(Name = "Tripsheet Date")]
        public string tripsheetdate { get; set; }

        [Display(Name = "LR No.")]
        public string lrno { get; set; }

        [Display(Name = "Customer Code")]
        public string custcode { get; set; }

        [Display(Name = "Customer Name")]
        public string custname { get; set; }

        [Display(Name = "Invoice Qty")]
        public decimal invoiceqty { get; set; }

        [Display(Name = "No of Boxes")]
        public decimal noofboxes { get; set; }

        [Display(Name = "Weight")]
        public decimal weight { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal invoicevalue { get; set; }

        [Display(Name = "City Name")]
        public string cityname { get; set; }

        [Display(Name = "E-Waybill No")]
        public string ewaybillno { get; set; }

        [Display(Name = "Error Message")]
        public string ErrorMessage { get; set; }

        [Display(Name = "From City")]
        public string fromCity { get; set; }

        [Display(Name = "To City")]
        public string toCity { get; set; }

        [Display(Name = "To Pin Code")]
        public string toPinCode { get; set; }
     
        [Display(Name = "Total Count")]
        public string totalcount { get; set; }

        public string branch_code { get; set; }
    }
    public class TripsheetForAdityaBirlaEWBN
    {
        [Display(Name = "Doc No.")]
        public string docno { get; set; }
        
        [Display(Name = "Invoice No.")]
        public string invoiceno { get; set; }
        [Display(Name = "LR No.")]
        public string lrno { get; set; }
        [Display(Name = "Tripsheet No")]
        public string tripsheetno { get; set; }
        [Display(Name = "Tripsheet Date")]
        public string tripsheetdate { get; set; }
        [Display(Name = "Invoice Date")]
        public string invoicedate { get; set; }
        [Display(Name = "E-Waybill No.")]
        public string ewaybillno { get; set; }
        [Display(Name = "Invoice Value")]
        public decimal invoicevalue { get; set; }
        [Display(Name = "Plant Code")]
        public string plantcode { get; set; }

        [Display(Name = "Custumer Code")]
        public string custcode { get; set; }

    }


}