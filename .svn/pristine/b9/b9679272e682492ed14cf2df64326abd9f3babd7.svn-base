
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerBillCollection : BaseModel
    {
        public CustomerBillCollection()
        {
            this.BillNo = "";
        }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Bill Type")]
        [Required(ErrorMessage = "Please select Bill Type")]
        public byte PaybasId { get; set; }

        [Display(Name = "Billing Party")]

        public short CustomerId { get; set; }

        [Display(Name = "Billing Party")]
        public string CustomerCode { get; set; }

        //[Required(ErrorMessage = "Please enter Billing Party")]
        [Display(Name = "Billing Party")]
        public string CriteriaCustomerCode { get; set; }

        [Display(Name = "Bill Collection Date")]
        [Required(ErrorMessage = "Please enter Bill Collection Date")]
        public DateTime CollectionDateTime { get; set; }

        [Display(Name = "Bill Collection Remarks")]
        public string BillCollectionRemarks { get; set; }
        public string LocationCode { get; set; }

        public short LocationId { get; set; }

        public string FinYear { get; set; }

        [Display(Name = "Manual MR No")]
        [StringLength(100, ErrorMessage = "Manual MR No must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter Manual MR No")]
        public string ManualMrNo { get; set; }

        public List<BillCollectionDetail> Details { get; set; }

        public List<MrDetail> MrDetailList { get; set; }

        public List<VoucherTransaction> VoucherTransactionDetails { get; set; }

        public List<MrHeader> MrHeaderList { get; set; }

        public Receipt ReceiptDetails { get; set; }

        [Display(Name = "Collection Type ")]
        public short CollectionType { get; set; }


        [Display(Name = "Customer Group ")]
        [Required(ErrorMessage = "Please Select Customer Group")]
        public string CustomerGroup { get; set; }
        public string CustomerGroupName { get; set; }
        [Display(Name = "Customer Type")]
        [Required(ErrorMessage = "Please select Customer Type")]
        public Byte CustomerTypeId { get; set; }

        [Display(Name = "Adjustment No")]
        public long AdjustmentId  { get; set; }

    }
}
