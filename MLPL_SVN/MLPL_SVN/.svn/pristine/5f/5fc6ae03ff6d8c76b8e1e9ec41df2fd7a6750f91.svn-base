using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerVendorAdjustment : BaseModel
    {
        public short LocationId { get; set; }
        public short CustomerId { get; set; }
        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Please enter Customer")]
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public short VendorId { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "Please enter Vendor")]
        public string VendorCode { get; set; }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }
        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }
        public decimal TotalCustomerAdjustmentAmount { get; set; }
        public decimal TotalVendorAdjustmentAmount { get; set; }

        [Required(ErrorMessage = "Please select Adjustment Date and Time")]
        [Display(Name = "Adjustment Date")]
        [DataType(DataType.DateTime)]
        public DateTime AdjustmentDateTime { get; set; }
        public List<CustomerAdjustmentDetail> CustomerAdjustmentDetails { get; set; }
        public List<VendorAdjustmentDetail> VendorAdjustmentDetails { get; set; }

        public string FinYear { get; set; }

    }

    public class CustomerAdjustmentDetail
    {
        public long CustomerBillId { get; set; }
        public bool IsChecked { get; set; }
        public short CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerBillNo { get; set; }
        public decimal CustomerBillAmount { get; set; }
        public decimal CustomerPendingAmount { get; set; }
        public decimal CustomerAdjustmentAmount { get; set; }
    }

    public class VendorAdjustmentDetail
    {
        public long VendorBillId { get; set; }
        public bool IsChecked { get; set; }
        public short VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorBillNo { get; set; }
        public decimal VendorBillAmount { get; set; }
        public decimal VendorPendingAmount { get; set; }
        public decimal VendorAdjustmentAmount { get; set; }
    }
}