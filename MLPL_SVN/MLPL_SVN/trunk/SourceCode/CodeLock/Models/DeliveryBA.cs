//  
// Type: CodeLock.Models.SalesProfitability
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DeliveryBA
    {
        public short VendorId { get; set; }
        [Display(Name = "Delivery BA Name")]
        public string VendorCode { get; set; }
        [Display(Name = "Vehicle No.")]
        public string VehicleNo { get; set; }
        [Display(Name = "Sys. Bill No.")]
        public string BillNo { get; set; }
        [Display(Name = "Docket No.")]
        public string DocketNo { get; set; }
        [Display(Name = "Location")]
        public short LocationId { get; set; }
        public bool IsCumulative { get; set; }
        [Display(Name = "Manual Bill No.")]
        public string ManualBillNo { get; set; }
    }

}
