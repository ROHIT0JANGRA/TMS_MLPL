using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class MasterStandardRouteCharge : BaseModel
    {
        public MasterStandardRouteCharge()
        {
            this.ChargeList = new List<MasterStandardRouteChargeExpense>();
        }

        [Required(ErrorMessage = "Route Name cannot be blank")]
        [Display(Name = "Route Name")]
        public short RouteId { get; set; }
        public string RouteName { get; set; }

        [Display(Name = "Standard Fuel [In Liters]")]
        public decimal StandardFuelInLiters { get; set; }

        [Display(Name = "Standard Fuel Rate [In Rs]")]
        public decimal StandardFuelRateInRs { get; set; }

        [Display(Name = "Standard Driver AdvanceAmount")]
        public decimal StandardAdvanceAmount { get; set; }

        [Required(ErrorMessage = "Vehicle Type cannot be blank")]
        [Display(Name = "Vehicle Type")]
        public short VehicleTypeId { get; set; }

        [Display(Name = "Standard Charge Date")]
        public DateTime StandardChargeDate { get; set; }
        public List<MasterStandardRouteChargeExpense> ChargeList { get; set; }
    }

    public class MasterStandardRouteChargeExpense
    {
        public int ChargeCode { get; set; }
        public string ChargeName { get; set; }
        public decimal ChargeRate { get; set; }
    }
}