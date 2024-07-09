using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class DocketInvoiceApi
    {
        public DocketInvoiceApi()
        {
            this.PartList = new List<DocketInvoicePartApi>();
        }
        public long InvoiceId { get; set; }
        public string InvoiceNo { get; set; }

        public string InvoiceDate { get; set; }

        public string TypeOfPackage { get; set; }

        public Decimal Length { get; set; }

        public Decimal Breadth { get; set; }

        public Decimal Height { get; set; }

        public Decimal InvoiceAmount { get; set; }

        public short Packages { get; set; }

        public Decimal VolumetricWeight { get; set; }

        public Decimal ActualWeight { get; set; }

        public Decimal ChargedWeight { get; set; }

        public string EwayBillNo { get; set; }

        public string EwayBillIssueDate { get; set; }

        public string EwayBillExpiryDate { get; set; }

        public List<DocketInvoicePartApi> PartList { get; set; }

    }

    public class DocketInvoicePartApi
    {
        public long InvoiceId { get; set; }

        public string PartName { get; set; }

        public Decimal PartQuantity { get; set; }

        public decimal PartAmount { get; set; }
        
        public bool IsCod { get; set; }

    }
}