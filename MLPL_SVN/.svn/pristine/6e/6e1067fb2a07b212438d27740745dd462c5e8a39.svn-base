using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class MasterServiceVehicle
    {[Key]
        [Display(Name = " Vehicle")]
        [Required(ErrorMessage = "Please select Vehicle")]
        public String VehicleId { get; set; }

        public int MappingId { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }
   //     [AssertThat("0 < PreviousServiceKM", ErrorMessage = "Previous Service KM must be greater than 0")]
        [Display(Name = "Previous Service KM")]
        public short PreviousServiceKM { get; set; }

        [Display(Name = "Previous Service Date")]
        public DateTime PreviousServiceDate { get; set; }

        [Display(Name = "Total Count Services ")]
        public int TotalCountServices { get; set; }
       
        [Display(Name = "Current Service KM")]
        [AssertThat("0 < CurrentServiceKM", ErrorMessage = "Current Service KM must be greater than 0")]
        [AssertThat("CurrentServiceKM < NextServiceKM", ErrorMessage = "Current Service KM must be less than Next Service KM")]
        public short CurrentServiceKM { get; set; }

        [Display(Name = "Current Service Date")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentServiceDate { get; set; }

        [Display(Name = "Next Service KM")]
        [AssertThat("0 < NextServiceKM", ErrorMessage = "Next Service KM must be greater than 0")]

        public short NextServiceKM { get; set; }

        [Display(Name = "Reminder (in KM)")]
        [AssertThat("Reminder < NextServiceKM", ErrorMessage = "Reminder Service KM must be less than Next Service KM")]
        [AssertThat("0 < Reminder", ErrorMessage = "Reminder must be greater than 0")]
        public long Reminder { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Service Type")]
        public long Servicetype { get; set; }

        [Display(Name = "Service Centre Type")]
        public long ServiceCentreType { get; set; }

        [Display(Name = "Workshop")]
        public long Workshop { get; set; }

        [Display(Name = "AMC/Non-AMC")]
        public long AMC { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Service Cost")]
        public long ServiceCost { get; set; }

        [Display(Name = "Upload Scanned Document")]
        public long UploadScannedDocument { get; set; }

        [EmailAnnotation]
        [Required(ErrorMessage = "Please enter To Email Id")]
        [Display(Name = "Automail (To ID)")]
        public string AutomailTo { get; set; }

        [EmailAnnotation]
        [Required(ErrorMessage = "Please enter CC Email Id")]
        [Display(Name = "Automail (To CCID)")]
        public string AutoMailCCId { get; set; }

        [EmailAnnotation]
        [Required(ErrorMessage = "Please enter BCC Email Id")]
        [Display(Name = "Automail (To BCCID)")]
        public string AutoMailBCCId { get; set; }

        [Display(Name = "Workshop")]
        //[Required(ErrorMessage = "Please select At-least one thing")]
        public string Location { get; set; }

        public string VendorCode { get; set; }

        [Display(Name = "Vendor")]
        public string Vendor { get; set; }


        public string TripsheetNo { get; set; }
        public string VehicleRoute { get; set; }
        public DateTime TSStartDate { get; set; }
        public DateTime TSEndDate { get; set; }
        public string DriverName { get; set; }
        public int StartKM { get; set; }
        public int ClosingKM { get; set; }
        public int TotalKMRunTS { get; set; }
        public int TotalKMRunGPS { get; set; }
        public int TotalKMRunManual { get; set; }
        public string TSStatus { get; set; }

    }
}