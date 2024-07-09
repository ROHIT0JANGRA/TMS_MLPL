using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class DeliverOrder 
    {
        
        [Display(Name = "Docket No")]
        public string DocketNo { get; set; }
        public long DocketId { get; set; }

        public int InvoiceId { get; set; }

        public int PartId { get; set; }

        [Display(Name = "Consignee Name")]
        public string ConsigneeName { get; set; }

        [Display(Name = "Consignee Address")]
        public string ConsigneeAddress1 { get; set; }

        [Display(Name = "Consignee Mobile No")]
        public string ConsigneeMobileNo { get; set; }

        [Display(Name = "Weight")]
        public decimal ActualWeight { get; set; }

        [Display(Name = "Total Part Amount")]
        public decimal TotalPartAmount { get; set; }

        [Display(Name = "Total Part Quantity")]
        public int TotalPartQuantity { get; set; }
        public string DocketSuffix { get; set; }
        public short EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public byte CompanyId { get; set; }
        public short LocationId { get; set; }
        public string DocumentName { get; set; }
        public HttpPostedFileBase POD { get; set; }
        [Display(Name = "Signature Document Name")]
        public string Signature { get; set; }
        [Display(Name = "Signature Image")]
        public HttpPostedFileBase SignatureImage { get; set; }
        [Display(Name = "Image Name")]
        public string Image { get; set; }

        [Display(Name = "Delivery Status")]
        public byte DeliveryStatusId { get; set; }

        [Display(Name = "Receiver Name")]
        public string ReceiverName { get; set; }

        [Display(Name = "Delivery Person Name")]
        public string DeliveryPersonName { get; set; }

        [Display(Name = "Receiver Type")]
        public byte ReceiverTypeId { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Deliver Packages")]
        public int DeliverPackages { get; set; }

        [Display(Name = "Delivery Date Time")]
        public DateTime DeliveryDateTime { get; set; }
        public decimal DeliverCodAmount { get; set; }
        public byte OrderDeliveryStatusId { get; set; }
        public List<DrsDocket> DocketDetails { get; set; }
        public List<DeliverOrderInvoiceDetail> Items { get; set; }

    }
    
    public class DeliverOrderInvoiceDetail
    {
        public string DocketNo { get; set; }
        public long DocketId { get; set; }
        public int InvoiceId { get; set; }
        public int PartId { get; set; }
        public string PartName { get; set; }
        public decimal PartQuantity { get; set; }
        public decimal PartAmount { get; set; }
        public bool IsCod { get; set; }
        public int SrNo { get; set; }
        public bool IsChecked { get; set; }

    }
}