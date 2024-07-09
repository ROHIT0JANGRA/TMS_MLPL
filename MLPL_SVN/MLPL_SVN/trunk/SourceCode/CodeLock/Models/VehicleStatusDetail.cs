using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class VehicleStatusDetail
    {
        public VehicleStatusDetail()
        {
            this.VehicleStatusList = new List<GetVehicleStatusList>();
            this.VehicleDetailList = new List<GetVehicleStatusList>();
        }
        public List<GetVehicleStatusList> VehicleStatusList { get; set; }
        public List<GetVehicleStatusList> VehicleDetailList { get; set; }

        [Display(Name = "Vehicle id")]
        public short VehicleId { get; set; }
        [Required(ErrorMessage = "Please select vehicle number")]

        [Display(Name = "Vehicle Number")]
        public String VehicleNo { get; set; }

        [Required(ErrorMessage = "Please select vehicle Status")]
        [Display(Name = "Vehicle Status")]
        public string VehicleStatus { get; set; }
        [RequiredIf("VehicleStatus == '2'", ErrorMessage = "Please select reason for Off road.")]
        
        [Display(Name = "Reason")]
        public string StatusReason { get; set; }

        [Display(Name = "VehCurStatus")]
        public short VehCurStatus { get; set; }

        [Display(Name = "Location")]
        public string VehLocation { get; set; }

        [Display(Name = "Vehicle Status Date")]
        public DateTime? VehStatusDateTime { get; set; }

        [Display(Name = "Remarks")]
        public string VehRemarks { get; set; }

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


    }
}