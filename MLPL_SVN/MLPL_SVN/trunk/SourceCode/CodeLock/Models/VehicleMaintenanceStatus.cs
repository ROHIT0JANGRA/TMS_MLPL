using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class VehicleMaintenanceStatus
    {
        public bool IsChecked { get; set; }
        public short id { get; set; }
        [Required(ErrorMessage = "Please select vehicle number")]
        [Display(Name = "Vehicle id")]
        public short VehicleId { get; set; }
        [Required(ErrorMessage = "Please select vehicle number")]

        [Display(Name = "Vehicle Number")]
        public String VehicleNo { get; set; }

        [Required(ErrorMessage = "Please select vehicle Status")]
        [Display(Name = "Vehicle Status")]
        public string VehicleStatus { get; set; }
        public string StatusNm { get; set; }

        [Display(Name = "CurrDate")]
        public DateTime CurrDate { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Spare Parts")]
        public string SpareParts { get; set; }

        [Display(Name = "Expected Date")]
        public DateTime? ExpectdDate { get; set; }

        
        [Range(0, 999999999999.0, ErrorMessage = "Please enter expense amount")]
        [Display(Name = "Expense Amount ")]
        public Decimal ExpenseAmount { get; set; }

        [Display(Name = "Upload Support Document")]
        public string DocumentName { get; set; }

        [Display(Name = "Attach bills")]
        public HttpPostedFileBase BillDocument { get; set; }

        
        public short EntryBy { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Please enter Driver Mobile No")]
        [Display(Name = "Driver Mobile No")]
        [MobileAnnotation]
        public string DriverMobNo { get; set; }

        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }

        [Required(ErrorMessage = "Please enter Supervisor Mobile No")]
        [Display(Name = "Supervisor Mobile No")]
        [MobileAnnotation]
        public string SupervisorMobNo { get; set; }

        [Required(ErrorMessage = "Please enter Location")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Vehicle Status Date")]
        public DateTime VehStatusDate { get; set; }
    }

}