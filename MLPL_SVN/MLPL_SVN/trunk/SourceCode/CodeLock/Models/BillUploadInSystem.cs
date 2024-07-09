//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class BillUploadInSystem : Response
    {
        public string FileName { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Bill Date")]
        public DateTime BillDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "Collection Branch")]
        public string CollectionBranch { get; set; }

        [Display(Name = "Billing Branch")]
        public string BillingBranch { get; set; }

        [Display(Name = "Narration")]
        public string Narration { get; set; }

        [Display(Name = "AccountCode")]
        public string AccountCode { get; set; }

        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }

        [Display(Name = "SGST")]
        public Decimal SGST { get; set; }

        [Display(Name = "CGST")]
        public Decimal CGST { get; set; }

        [Display(Name = "IGST")]
        public Decimal IGST { get; set; }

        [Display(Name = "Total")]
        public Decimal Total { get; set; }
        [Display(Name = "Upload Status")]
        public string UploadStatus { get; set; }
        public HttpPostedFileBase File { get; set; }

        public short EntryBy { get; set; }

        public BillUploadInSystem()
        {
            this.Details = new List<BillUploadInSystem>();
        }

        public List<BillUploadInSystem> Details { get; set; }

    }
}