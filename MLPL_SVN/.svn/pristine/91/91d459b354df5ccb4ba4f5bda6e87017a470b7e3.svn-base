using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CodeLock.Models
{
    public class Lane : BaseModel
    {
        [Display(Name = "Customer")]
        [Required]
        public long CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public List<LaneDetail> LaneDetails { get; set; }
    }
    public class LaneDetail : BaseModel
    {
        [Display(Name = "Customer Name")]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long ID { get; set; }

        [Display(Name = "Lane Id")]
        public string LaneId { get; set; }

        [Display(Name = "Mother Lane Id")]
        public string MasterLaneId { get; set; }

        [Display(Name = "Route")]
        public string RouteId { get; set; }
        public string RouteName { get; set; }

        [Display(Name = "Vehicle Size")]
        public string FTLTypeId { get; set; }
        public string FTLTypeDesc { get; set; }

        [Display(Name = "Fuel Type")]
        public string FuelTypeId { get; set; }
        public string FuelTypeDesc { get; set; }

        [Display(Name = "Contracted KM")]
        public long ContractedKM { get; set; }
        
        [Display(Name = "Asset Count")]
        public long AssetCount { get; set; }
        
        [Display(Name = "Driver Count")]
        public long DriverCount { get; set; }
    }
}