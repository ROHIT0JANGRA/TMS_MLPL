//  
// Type: CodeLock.Models.Receipt
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Receipt
  {
    public Receipt()
    {
      this.ChequeType = true;
    }

    [Display(Name = "Receipt Mode")]
    [Required(ErrorMessage = "Please select Receipt Mode")]
    public byte ReceiptMode { get; set; }

    [Display(Name = "Amount Applicable")]
    [Range(1, 999999999, ErrorMessage = "Amount Applicable must be greater than zero")]
    public Decimal AmountApplicable { get; set; }

    [Display(Name = "Cash Amount")]
    public Decimal CashAmount { get; set; }

    [Display(Name = "Cash Account")]
    [Required(ErrorMessage = "Please select Cash Account")]
    public short CashAccountId { get; set; }

    [Display(Name = "Cheque/NEFT Amount")]
    public Decimal ChequeAmount { get; set; }

    [Display(Name = "Bank Account")]
    [Required(ErrorMessage = "Please select Bank Account")]
    public short BankAccountId { get; set; }

    [Display(Name = "Cheque/NEFT No")]
    [RequiredIf("ReceiptMode==2", ErrorMessage = "Please enter Cheque/NEFT No")]
    public string ChequeNo { get; set; }

    public long ChequeId { get; set; }

    [Required(ErrorMessage = "Please select Cheque/NEFT Date")]
    [Display(Name = "Cheque/NEFT Date")]
    public DateTime ChequeDate { get; set; }

    public bool ChequeType { get; set; }

    [Range(1, 999999999, ErrorMessage = "Net Payable Amount must be greater than zero")]
    [Display(Name = "Net Payable Amount")]
    public Decimal NetPayableAmount { get; set; }

    [Display(Name = "On Account Balance")]
    public Decimal OnAccountBalance { get; set; }

    [Display(Name = "Collection Amount From Cheque")]
    public Decimal CollectionAmountFromCheque { get; set; }

    [Display(Name = "TDS Account")]
    public short TdsAccountId { get; set; }

    public Decimal TdsAmount { get; set; }

    [Display(Name = "Direct Deposited In Bank")]
    public bool IsDirectDeposited { get; set; }

    [Display(Name = "Received From Bank Name")]
    [RequiredIf("ReceiptMode==2", ErrorMessage = "Please enter Received From Bank Name")]
    public string BankName { get; set; }

    [RequiredIf("ReceiptMode==2", ErrorMessage = "Received From Please enter Bank Branch Name")]
    [Display(Name = "Received From Bank Branch Name")]
    public string BankBranchName { get; set; }

    [Display(Name = "On Account")]
    public bool IsOnAccount { get; set; }

    [Display(Name = "Net Received Amount")]
    public Decimal NetReceived { get; set; }

    public bool EnableOnAccount { get; set; }

    public bool EnableBothReceipt { get; set; }

    [Required(ErrorMessage = "Please select BA Account")]
    [Display(Name = "BA Account")]
    public short BaAccountID { get; set; }

    [RequiredIf("ReceiptMode == 8", ErrorMessage = "Please enter BA Account Code.")]
    public string BaAccountCode { get; set; }

    [RequiredIf("ReceiptMode == 8", ErrorMessage = "Please enter  Remarks.")]
    [Display(Name = "Payment Remarks")]
    public string BaPaymentRemarks { get; set; }
    }
}
