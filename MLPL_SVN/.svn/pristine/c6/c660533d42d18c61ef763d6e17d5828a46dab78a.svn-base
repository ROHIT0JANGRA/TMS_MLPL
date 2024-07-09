//  
// Type: CodeLock.Models.Payment
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class Payment
    {
        public Payment()
        {
            this.ChequeType = true;
        }

        public long VoucherId { get; set; }

        public string VoucherNo { get; set; }

        [Display(Name = "Payment Mode")]
        [Required(ErrorMessage = "Please select Payment Mode")]
        public byte PaymentMode { get; set; }

        [Display(Name = "Amount Applicable")]
        public Decimal AmountApplicable { get; set; }

        [Display(Name = "Cash Amount")]
        [AssertThat("(CashAmount + ChequeAmount) == AmountApplicable", ErrorMessage = "Sum of Cash Amount and Cheque Amount is equals to Applicable Amount")]
        public Decimal CashAmount { get; set; }

        [Display(Name = "Cash Account")]
        [Required(ErrorMessage = "Please select Cash Account")]
        public short CashAccountId { get; set; }

        [Required(ErrorMessage = "Please select Cash Card")]
        [Display(Name = "Cash Card")]
        public short CashCardId { get; set; }

        public bool AllowCashCard { get; set; }

        [AssertThat("(CashAmount + ChequeAmount) == AmountApplicable", ErrorMessage = "Sum of Cash Amount and Cheque/NEFT Amount is equals to Applicable Amount")]
        [Display(Name = "Cheque/NEFT Amount")]
        public Decimal ChequeAmount { get; set; }

        [Required(ErrorMessage = "Please select Bank Account")]
        [Display(Name = "Bank Account")]
        public short BankAccountId { get; set; }

        [RequiredIf("PaymentMode == 2", ErrorMessage = "Please enter Cheque/NEFT No.")]
        [Display(Name = "Cheque/NEFT No")]
        public string ChequeNo { get; set; }

        public bool ChequeType { get; set; }
        public long ChequeId { get; set; }

        [Display(Name = "Cheque/NEFT Date")]
        [Required(ErrorMessage = "Please select Cheque/NEFT Date")]
        public DateTime ChequeDate { get; set; }
        public DateTime CardTillDate { get; set; }
        public string CardVehicleId { get; set; }

        [Required(ErrorMessage = "Please select BA Account")]
        [Display(Name = "BA Account")]
        public short BaAccountID { get; set; }

        [RequiredIf("PaymentMode == 8", ErrorMessage = "Please enter BA Account Code.")]
        public string BaAccountCode { get; set; }

        [RequiredIf("PaymentMode == 8", ErrorMessage = "Please enter Payment Remarks.")]
        [Display(Name = "Payment Remarks")]
        public string BaPaymentRemarks { get; set; }

        [Display(Name = "On Account")]
        public bool IsOnAccount { get; set; }

        [Display(Name = "Net Payable Amount")]
        public Decimal NetPayable { get; set; }

        public bool EnableOnAccount { get; set; }

        [Display(Name = "On Account Balance")]
        public Decimal OnAccountBalance { get; set; }

        [Display(Name = "Payment Amount From Cheque")]
        public Decimal PaymentAmountFromCheque { get; set; }

        [Display(Name = "TDS Account")]
        public short TdsAccountId { get; set; }
        [Display(Name = "TDS Amount")]
        public Decimal TdsAmount { get; set; }
    }
}
