using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class VendorBillUploadInSystem : Response
    {
        public string FileName { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Bill Date")]
        public DateTime BillDate { get; set; }

        [Display(Name = "Bill Type")]
        public string BillType { get; set; }

        [Display(Name = "Vendor Code")]
        public string VendorCode { get; set; }

        [Display(Name = "Vendor")]
        public string Vendor { get; set; }

        [Display(Name = "Billing Location")]
        public string BillingLocation { get; set; }

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

        public VendorBillUploadInSystem()
        {
            this.Details = new List<VendorBillUploadInSystem>();
        }

        public List<VendorBillUploadInSystem> Details { get; set; }

        [Display(Name = "Manual Remark")]
        public string ManualRemark { get; set; }
    }
}