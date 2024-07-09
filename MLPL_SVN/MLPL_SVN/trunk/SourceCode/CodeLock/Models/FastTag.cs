using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class FastTag : BaseModel
    {
        [Display(Name = "Transaction Id")]
        public string TransactionId { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Transaction Time")]
        public DateTime TransactionTime { get; set; }

        [Display(Name = "Transaction Date Time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Transaction Date Time")]
        public DateTime TransactionDateTime { get; set; }

        [Display(Name = "Plaza")]
        public string Plaza { get; set; }

        [Display(Name = "Vehicle Class")]
        public string VehicleClass { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "Lane Direction")]
        public string LaneDirection { get; set; }

        [Display(Name = "Fare")]
        public Decimal Fare { get; set; }

        [Display(Name = "Tripsheet")]
        public string TripsheetId { get; set; }

        [Display(Name = "UploadStatus")]
        public string UploadStatus { get; set; }

    }
}