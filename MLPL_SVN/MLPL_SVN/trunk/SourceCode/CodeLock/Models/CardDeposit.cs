

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CardDeposit : BaseModel
  {

        [Display(Name = "Card Type")]
        public string CardTypeId { get; set; }

        [Required(ErrorMessage = "Please select FO Ledger")]
        [Display(Name = "FO Ledger")]
        public short AccountId { get; set; }


        [Display(Name = "Card Type")]
    public bool IsFuelCard { get; set; }

    [Required(ErrorMessage = "Please select Bank")]
    [Display(Name = "Bank")]
    public short BankAccountId { get; set; }

    public string BankAccountCode { get; set; }

    public List<MasterCard> CardDetailList { get; set; }
  }
}
