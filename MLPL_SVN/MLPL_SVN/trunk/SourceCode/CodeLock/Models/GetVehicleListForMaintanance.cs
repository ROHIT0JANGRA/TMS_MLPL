using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class GetVehicleListForMaintanance
    {
        public bool IsChecked { get; set; }
        public short id { get; set; }
        [Required(ErrorMessage = "Please select vehicle number")]
        [Display(Name = "Vehicle id")]
        public short VehicleId { get; set; }
        [Required(ErrorMessage = "Please select vehicle number")]

        [Display(Name = "Vehicle Number")]
        public String VehicleNo { get; set; }

        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }
        
        [Display(Name = "Supervisor Mobile No")]
        [MobileAnnotation]
        public string SupervisorMobNo { get; set; }
        
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "StatusRemarks")]
        public string StatusRemarks { get; set; }

        [Display(Name = "StatusDate")]
        public string VehStatusDate { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        
        [Display(Name = "Driver Mobile No")]
        public string DriverMobNo { get; set; }

        //[Required(ErrorMessage = "Please select vehicle Status")]
        [Display(Name = "Vehicle Status")]
        public string VehicleStatus { get; set; }

        [Display(Name = "CurrDate")]
        public DateTime CurrDate { get; set; }

        [Display(Name = "Maintanance Remarks")]
        public string VehMaintananceRemarks { get; set; }

        [Display(Name = "Spare Parts")]
        public string SpareParts { get; set; }

        [Display(Name = "Expected Date")]
        public DateTime? ExpectdDate { get; set; }

        [Display(Name = "Upload Support Document")]
        public string DocumentName { get; set; }

        [Display(Name = "Attach bills")]
        public HttpPostedFileBase BillDocument { get; set; }

        [Range(0, 999999999999.0, ErrorMessage = "Please enter expense amount")]
        [Display(Name = "Expense Amount ")]
        public Decimal ExpenseAmount { get; set; }
        public short EntryBy { get; set; }
    }
}