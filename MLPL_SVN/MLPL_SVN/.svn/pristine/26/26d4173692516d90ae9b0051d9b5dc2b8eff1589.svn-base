using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class MasterAccountOpeningBalance : BaseModel
    {
        public string FinYear { get; set; }

        [Display(Name = "Ledger Balance Transfer Type")]
        [Required(ErrorMessage = "Please select Ledger Balance Transfer Type")]
        public short  LedgerBalanceTransferTypeId { get; set; }

        [Display(Name = "Ledger Type")]
        [Required(ErrorMessage = "Please select Ledger Type")]
        public short LedgerTypeId { get; set; }

        [Display(Name = "Sub Ledger Type")]
        [Required(ErrorMessage = "Please select Sub Ledger Type")]
        public short SubLedgerTypeId { get; set; }

        [Display(Name = "Profit/Loss Ledger Type")]
        [Required(ErrorMessage = "Please select Profit/Loss Ledger Type")]
        public short ProfitLossLedgerTypeId { get; set; }
    }
}