using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class LabourDCModule : BaseModel
    {
        public LabourDCModule()
        {
            this.ManifestList = new List<LabourDCManifest>();
            this.Details = new List<LabourDCModule>();
        }
        
        public short CancelBy { get; set; }
        public bool IsLabourDCChecked { get; set; }
        public string ManifestsNo { get; set; }
        public long LabourDCId { get; set; }
        public string LabourDCNo { get; set; }

        [Required(ErrorMessage = "Please select Labour DC Date and Time")]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [Display(Name = "Labour DC Date")]
        [DataType(DataType.DateTime)]
        public DateTime LabourDCDateTime { get; set; }

        public DateTime LabourDCDate { get; set; }

        public TimeSpan LabourDCTime { get; set; }

        [StringLength(50, ErrorMessage = "Manual Manifest No must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "Manual Labour DC No")]
        public string ManualLabourDCNo { get; set; }

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

       public int TotalManifest { get; set; }

        [Display(Name = "Total Packages")]
        public int TotalPackages { get; set; }

        [Display(Name = "Balance Packages")]
        public int BalancePackages { get; set; }

        [Display(Name = "Total Actual Weight")]
        public Decimal TotalActualWeight { get; set; }

        public short TotalLoadDocket { get; set; }

        public int TotalLoadPackages { get; set; }

        public Decimal TotalLoadActualWeight { get; set; }

        public Decimal TotalAmount { get; set; }


        [Required(ErrorMessage = "Please select vendor code")]
        [Display(Name = "Vendor Code")]
        public short VendorId { get; set; }

        [Display(Name = "Vendor Code")]
        [Required(ErrorMessage = "Please select vendor code")]
        public string VendorCode { get; set; }

        [Display(Name = "Vendor Code")]
        public string VendorCodeTracking { get; set; }

        public string VendorName { get; set; }

        [Display(Name = "Document Type")]
        [Required(ErrorMessage = "Please select Document Type")]
        public string DocumentType { get; set; }

        [Display(Name = "THC Type")]
        public string THCType { get; set; }

        [Display(Name = "Billing Location")]
        [Required(ErrorMessage = "Please select billing location")]
        public short BillLocationId { get; set; }
        public List<LabourDCManifest> ManifestList { get; set; }
        public string Remarks { get; set; }
        public List<LabourDCModule> Details { get; set; }

        public string CancelReason { get; set; }
        public DateTime CancelDate { get; set; }
        //
    }
    public class LabourDCTracking
    {
        public long LabourDCId { get; set; }
        public string LabourDCNo { get; set; }
        public DateTime LabourDCDate { get; set; }
        public string LocationCode { get; set; }
        public string VendorCode { get; set; }
        public Decimal TotalManifest { get; set; }
        public Decimal TotalPackages { get; set; }
        public Decimal TotalActualWeight { get; set; }
        public Decimal TotalAmount { get; set; }
        public string DocumentType { get; set; }
        public string isBilled { get; set; }
        public string BILLNO { get; set; }
        public string LdcStatus { get; set; }
        public string DocumentDetail { get; set; }
        
                    public string FromLocation { get; set; }
        public string ToLocation { get; set; }


    }
    public class LabourDCManifest
    {
        public long ManifestId { get; set; }
        public long LoadunloadId { get; set; }

        [Display(Name = "Manifest No")]
        public string ManifestNo { get; set; }

        [Display(Name = "Manifest Date")]
        public DateTime ManifestDate { get; set; }

        [Display(Name = "No of Dockets")]
        public int NoofDocket { get; set; }

        [Display(Name = "Packages")]
        public int Packages { get; set; }

        public int LoadPackages { get; set; }

        [Display(Name = "Actual Weight")]
        public Decimal ActualWeight { get; set; }

        public Decimal LoadActualWeight { get; set; }

        [Display(Name = "Location")]
        public string LocationCode { get; set; }

        //RateType
        [Display(Name = "RateType")]
        public string RateType { get; set; }
        public string Vehicleno { get; set; }


        public Decimal Rate { get; set; }

        public Decimal ChargedWeight { get; set; }

        public Decimal Amount { get; set; }

        public bool IsChecked { get; set; }

        //ChargesType
        [Display(Name = "ChargesType")]
        public string ChargesType { get; set; }

        public string FromLocation { get; set; }
        public string ToLocation { get; set; }


    }


}