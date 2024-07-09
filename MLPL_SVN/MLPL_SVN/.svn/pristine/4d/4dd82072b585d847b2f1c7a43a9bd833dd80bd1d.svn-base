using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class BillReAssign : Base
    {
        [Required(ErrorMessage = "Please enter Bill No")]
        public long BillId { get; set; }

        [Display(Name = "Bill No")]
        [Required(ErrorMessage = "Please enter Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Bill Date")]
        public DateTime BillDate { get; set; }

        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "Collection Location")]
        public string CollectionLocation { get; set; }

        [Display(Name = "New Location")]
        [Required(ErrorMessage = "Please select new location")]
        public long LocationId { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

    }
    public class VendorBillReAssign : Base
    {
        [Required(ErrorMessage = "Please enter Bill No")]
        public long BillId { get; set; }

        [Display(Name = "Bill No")]
        [Required(ErrorMessage = "Please enter Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Bill Date")]
        public DateTime BillDate { get; set; }

        [Display(Name = "Vendor")]
        public string Vendor { get; set; }

        [Display(Name = "Current Bill Location")]
        public string Location { get; set; }

        [Display(Name = "New Bill Location")]
        [Required(ErrorMessage = "Please select new bill location")]
        public long LocationId { get; set; }

        [Display(Name = "New Payment Location")]
        [Required(ErrorMessage = "Please select new location")]
        public long PaymentLocationId { get; set; }

        [Display(Name = "Current Payment Location")]
        public string PaymentLocation { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

    }
}