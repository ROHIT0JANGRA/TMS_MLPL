using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VehicleProfitability
    {
        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "Route")]
        public byte RouteId { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        public byte LocationId { get; set; }

        [Display(Name = "Tripsheet No/Manual Tripsheet No")]
        public string TripsheetNo { get; set; }
    }
}
