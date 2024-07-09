using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CreditDebitNote : Base
    {
        public CreditDebitNote()
        {
            this.Details = new List<CreditDebitNoteDetail>();
        }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Manual Bill No")]
        public string ManualBillNo { get; set; }

        [Display(Name = "Bill Type")]
        [Required(ErrorMessage = "Please select Bill Type")]
        public byte BillTypeId { get; set; }

        [Display(Name = "Bill Type")]
        public string BillType { get; set; }

        [Display(Name = "Transport Mode")]
        [Required(ErrorMessage = "Please select Transport Mode")]
        public byte TransportModeId { get; set; }

        [Display(Name = "Billing Party")]
        public short PartyId { get; set; }

        [Required(ErrorMessage = "Please enter Billing Party")]
        [Display(Name = "Billing Party")]
        public string PartyCode { get; set; }

        [Display(Name = "Billing Party Name")]
        public string PartyName { get; set; }

        public long NoteId { get; set; }

        [Display(Name = "Note No")]
        public string NoteNo { get; set; }

        [Required(ErrorMessage = "Please select Note Type")]
        [Display(Name = "Note Type")]
        public int NoteType { get; set; }

        public string NoteTypeDes { get; set; }

        [Display(Name = "Is GST")]
        public bool IsGst { get; set; }

        [Required(ErrorMessage = "Please select Note Date")]
        [Display(Name = "Note Date")]
        public DateTime NoteDate { get; set; }

        [Display(Name = "Note Branch")]
        public string NoteBranchName { get; set; }
        public short NoteBranchId { get; set; }

        [Display(Name = "Party Name")]
        public string  PartyCodeName { get; set; }
        
        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }
       
        [Display(Name = "Total Note Amount")]
        public decimal TotalNoteAmount { get; set; }

        public decimal SubTotalNoteAmount { get; set; }

        public decimal GstNoteAmount { get; set; }
        public int AccountId { get; set; }

        [Display(Name = "Income Ledger")]
        [Required(ErrorMessage = "Please select Income Ledger")]
        public string AccountCode { get; set; }

        [Display(Name = "Ledger Description")]
        public string AccountDescription { get; set; }

        public string GstType { get; set; }
        public short LocationId { get; set; }
		public string LocationCode { get; set; }
		public string FinYear { get; set; }
        public bool IsChecked { get; set; }
        public short CancelBy { get; set; }
        public string CancelReason { get; set; }
        public DateTime CancelDate { get; set; }
        public bool IsGstReverse { get; set; }

        public List<CreditDebitNoteDetail> Details { get; set; }
    }

    public class CreditDebitNoteDetail
    {
        public bool IsChecked { get; set; }
        public long BillId { get; set; }
        
        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Bill Date")]
        public string BillDate { get; set; }

        [Display(Name = "Bill Amount")]
        public decimal BillAmount { get; set; }

        [Display(Name = "Balance Amount")]
        public decimal BalanceAmount { get; set; }

        [Display(Name = "Note Amount")]
        [Range(0.001, 10000000.0, ErrorMessage = "Please enter Note Amount")]
        [Required(ErrorMessage = "Please enter Note Amount")]
        public decimal NoteAmount { get; set; }

        [Display(Name = "Note Purpose")]
        [Required(ErrorMessage = "Please select Note Purpose")]
        public short NotePurposeId { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        public DateTime CancelDate { get; set; }
        public string CancelReason { get; set; }
        public short CancelBy { get; set; }
        public long NoteId { get; set; }
    }
}