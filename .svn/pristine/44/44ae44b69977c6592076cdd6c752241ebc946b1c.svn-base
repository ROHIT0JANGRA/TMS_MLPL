using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CodeLock.Models;

namespace CodeLock.Models
{
    public class FSCRate: BaseModel
    {
        [Display(Name = "Customer")]
        [Required]
        public short CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Start Date")]
        public string PeriodFrom { get; set; }
        [Display(Name = "End Date")]
        public string PeriodTo { get; set; }
        public List<FSCRateDetail> Details { get; set; }
    }
    public class FSCRateDetail : LaneDetail
    {
        public long FSCRateId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Period From")]
        [Required(ErrorMessage = "Period From is Required")]
        public DateTime PeriodFrom { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Period To")]
        [Required(ErrorMessage = "Period To is Required")]
        public DateTime PeriodTo { get; set; }
        public short ContractID { get; set; }

        [Range(0.0, 9999999999.0, ErrorMessage = "Please enter Variable Base Amt./Trip")]
        [Display(Name = "Variable Base Amt./Trip")]
        [Required(ErrorMessage = "Variable Base Amt is Required")]
        public decimal VariableBaseAmtPerTrip { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Fuel Price")]
        [Display(Name = "Fuel Base Price")]
        [Required(ErrorMessage = "Fuel Base Price is Required")]
        public decimal FuelBasePrice { get; set; }

        [Range(1.0, 9999999999.0, ErrorMessage = "Please enter Fuel Price")]
        [Display(Name = "New Fuel Price")]
        [Required(ErrorMessage = "New Fuel Price is Required")]
        public decimal NewFuelPrice { get; set; }

        [Display(Name = "Total Trip FSC Amount")]
        [Required(ErrorMessage = "Total Trip FSC Amount is Required")]
        public decimal TotalTripFSCAmount { get; set; }
    }
}