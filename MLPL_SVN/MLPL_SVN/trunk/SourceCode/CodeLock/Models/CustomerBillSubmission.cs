using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerBillSubmission
    {
        public CustomerBillSubmission()
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
        [Required(ErrorMessage = "Please enter Billing Party")]
        public string CustomerCode { get; set; }

        [Display(Name = "Bill Submission Date")]
        [Required(ErrorMessage = "Please enter Bill Submission Date")]
        public DateTime? SubmissionDateTime { get; set; }

        [Required(ErrorMessage = "Please enter Bill Submitted to")]
        [Display(Name = "Bill Submitted to")]
        public string SubmittedTo { get; set; }

        [Required(ErrorMessage = "Please enter Customer Billing Mobile No.")]
        [MobileAnnotation]
        [Display(Name = "Customer Billing Mobile No.")]
        public string SubmittedContactNo { get; set; }

        public short SubmittedLocationId { get; set; }
        public short SubmittedUserId { get; set; }
        [Display(Name = "Remarks")]
        public string BillSubmissionRemarks { get; set; }
        public List<BillSubmissionDetail> Details { get; set; }
        public byte CompanyId { get; set; }
        [Display(Name = "Customer Type")]
        [Required(ErrorMessage = "Please select Customer Type")]
        public Byte CustomerTypeId { get; set; }
    }
}
