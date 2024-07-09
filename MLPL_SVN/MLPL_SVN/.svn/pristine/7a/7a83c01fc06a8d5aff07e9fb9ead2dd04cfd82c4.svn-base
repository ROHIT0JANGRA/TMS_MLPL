
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
    public class BillSubmissionDetail
    {
        public long BillId { get; set; }

        public bool IsChecked { get; set; }

        [Display(Name = "Bill Amount")]
        public Decimal BillAmount { get; set; }

        public Decimal Tds { get; set; }

        public DateTime? SubmissionDateTime { get; set; }

        public string SubmittedTo { get; set; }

        public string SubmittedContactNo { get; set; }

        public short SubmittedLocationId { get; set; }

        public short SubmittedUserId { get; set; }

        public short CollectionUserId { get; set; }

        public short CollectionLocationId { get; set; }

        [Required(ErrorMessage = "Please Select Submitted By User")]
        public short SubmittedByUserId { get; set; }

        [Required(ErrorMessage = "Please Upload Document")]
        public string SubmittedDocumentName { get; set; }

        public HttpPostedFileBase SubmittedDocumentAttachment { get; set; }
        public string BillSubmissionRemarks { get; set; }
        public string BillNo { get; set; }
    }
}
