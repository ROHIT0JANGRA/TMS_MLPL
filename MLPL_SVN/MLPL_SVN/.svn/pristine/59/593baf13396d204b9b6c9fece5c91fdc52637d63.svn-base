using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class VehicleTracking :Base
    { 
        public VehicleTracking()
        {
            this.TrackingList = new List<Tracking_Details>();
        }
        public List<Tracking_Details> TrackingList { get; set; }

        public long VehicleTrackingId { get; set; }

        [Required(ErrorMessage = "Please select vehicle no.")]
        [Display(Name = "Vehicle id")]
        public long VehicleId { get; set; }

        [Required(ErrorMessage = "Please select vehicle no.")]
        [Display(Name = "Vehicle Number")]
        public String VehicleNo { get; set; }

        [Required(ErrorMessage = "Please select tripsheet no.")]
        [Display(Name = "Tripsheet No")]
        public long TripsheetId { get; set; }

        [Display(Name = "Vehicle Number")]
        public String TripsheetVehicleNo { get; set; }

        [Display(Name = "Tripsheet No")]
        public String TripsheetNo { get; set; }

        [Display(Name = "Tripsheet Date")]
        public String TripsheetDate { get; set; }

        [Display(Name = "Route Name")]
        public String RouteName { get; set; }

        [Display(Name = "Driver Name")]
        public String DriverName { get; set; }

        [Display(Name = "Vehicle Mode")]
        public String VehicleMode { get; set; }

        [Display(Name = "Starting KM Reading")]
        public String StartingKMReading { get; set; }

        [Display(Name = "Category")]
        public String Category { get; set; }

        [Display(Name = "Total LR Attached")]
        public Int64 TotalLRAttached { get; set; }

        [Display(Name = "T.S Generated User name")]
        public String TSGeneratedUsername { get; set; }

        [Display(Name = "Sr No.")]
        public int SNo { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Display(Name = "Dated")]
        public DateTime Dated { get; set; }

        [Display(Name = "Time")]
        public DateTime DatedTime { get; set; }

        [Display(Name = "Start KM")]
        public int StartKM { get; set; }

        [Display(Name = "End KM")]
        public int EndKM { get; set; }

        [Display(Name = "Total Run KM")]
        public int TotalRunKM { get; set; }

        [Display(Name = "Load Type")]
        public string LoadType { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "LR Details")]
        public string LRDetails { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }

    }

    public class Tracking_Details
    {
        [Display(Name = "Sr No.")]
        public int SNo { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Display(Name = "Dated")]
        public DateTime Dated { get; set; }

        [Display(Name = "Dated")]
        public string DatedDes { get; set; }

        [Display(Name = "Start KM")]
        public int StartKM { get; set; }

        [Display(Name = "End KM")]
        public int EndKM { get; set; }

        [Display(Name = "Total Run KM")]
        public int TotalRunKM { get; set; }

        [Display(Name = "Load Type")]
        public string LoadType { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "LR Details")]
        public string LRDetails { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }

    }

}