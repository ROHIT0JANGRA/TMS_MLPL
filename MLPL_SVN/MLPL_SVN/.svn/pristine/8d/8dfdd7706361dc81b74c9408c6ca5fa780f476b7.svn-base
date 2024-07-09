using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class DocketStatus : BaseModel
    {
        public DocketStatus()
        {
            this.StatusDetail = new List<DocketStatusDetail>();
        }
        public List<DocketStatusDetail> StatusDetail { get; set; }
        public long DocketId { get; set; }

        [Display(Name = "Docket No")]
        public string DocketNo { get; set; }

        [Display(Name = "Docket Date")]
        public string DocketDate { get; set; }

        [Display(Name = "Origin")]
        public string Origin { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        //
        [Display(Name = "Consignor Name")]
        public string ConsignorName { get; set; }

        //Pay Basis
        [Display(Name = "Pay Basis")]
        public string PayBasis { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        //Current Location
        [Display(Name = "Current Location")]
        public string CurrentLocation { get; set; }

        [Display(Name = "Consignee Name")]
        public string ConsigneeName { get; set; }

        [Display(Name = "Mode of Transport")]
        public string ModeOfTransport { get; set; }

        //Charge Weight
        [Display(Name = "Charge Weight")]
        public string ChargeWeight { get; set; }

        //A.D.D
        [Display(Name = "A.D.D")]
        public string ADDDate { get; set; }

        //Billing Party Name
        [Display(Name = "Billing Party Name")]
        public string BillingPartyName { get; set; }

        //Icon Name
        [Display(Name = "Icon Name")]
        public string IconName { get; set; }


        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        [Display(Name = "EDD")]
        public string EDD { get; set; }


        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please Select Status")]
        public string Status { get; set; }

        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Please enter remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Status Date")]
        [Required(ErrorMessage = "Please enter status date")]
        public DateTime StatusDate { get; set; }

        [Display(Name = "POD File")]
        public string PODFile { get; set; }

        [Display(Name = "Extension")]
        public string Extension { get; set; }

        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }

        [Display(Name = "Docket Status")]
        public string Docket_Status { get; set; }

        [Display(Name = "Packets")]
        public string Packets { get; set; }
        public string StatusDataList { get; set; }
        public bool ShowPaybas { get; set; }
        //
    }

    public class DocketStatusDetail
    {
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Status Date")]
        public string StatusDate { get; set; }

        [Display(Name = "POD File")]
        public string PODFile { get; set; }

    }

}