using CodeLock.Areas.Finance.Repository;
using CodeLock.Models;
using System;
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Controllers
{
  public class BankingController : Controller
  {
    private readonly IBankingRepository bankingRepository;

    public BankingController(IBankingRepository _bankingRepository)
    {
      this.bankingRepository = _bankingRepository;
    }

    public ActionResult ChequeDeposit()
    {
      return (ActionResult) this.View((object) new Cheque());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ChequeDeposit(Cheque objCheque)
    {
      if (this.ModelState.IsValid)
      {
        //string[] strArray = objCheque.PartyCode.Split(':');
        //objCheque.PartyCode = strArray[0].Trim();
        //objCheque.PartyName = strArray[1].Trim();
        objCheque.EntryBy = SessionUtility.LoginLocationId;
        objCheque.LocationId = SessionUtility.LoginLocationId;
        objCheque.DepositBy = new short?(SessionUtility.LoginUserId);
        objCheque.CompanyId = SessionUtility.CompanyId;
        objCheque.LocationCode = SessionUtility.LoginLocationCode;
        objCheque.FinYear = SessionUtility.FinYear;
        Response response = this.bankingRepository.ChequeDeposit(objCheque);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Done", (object) new
          {
            voucherId = response.DocumentId,
            voucherNo = response.DocumentNo
          });
        this.TempData["result"] = (object) response;
      }
      return (ActionResult) this.View((object) objCheque);
    }

    public ActionResult Done()
    {
      return (ActionResult) this.View();
    }

    public JsonResult GetChequeDetail(DateTime chequeDate, string chequeNo)
    {
      return this.Json((object) this.bankingRepository.GetChequeDetail(chequeDate, chequeNo));
    }

    public ActionResult BankReconciliation()
    {
      return (ActionResult) this.View((object) new BankReconcilation());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult BankReconciliation(BankReconcilation objBankReconcilation)
    {
      if (this.ModelState.IsValid)
      {
                ActionResult action;
                //string[] strArray = objCheque.PartyCode.Split(':');
                //objCheque.PartyCode = strArray[0].Trim();
                //objCheque.PartyName = strArray[1].Trim();
                
                objBankReconcilation.UpdateBy = SessionUtility.LoginLocationId;
                objBankReconcilation.LocationId = SessionUtility.LoginLocationId;
                objBankReconcilation.CompanyId = SessionUtility.CompanyId;
                objBankReconcilation.LocationCode = SessionUtility.LoginLocationCode;
                objBankReconcilation.FinYear = SessionUtility.FinYear;
                objBankReconcilation.ChequeDetails.RemoveAll((BankReconcilationChequeDetails m) => !m.IsChecked);
                Response response = this.bankingRepository.BankReconcilationUpdate(objBankReconcilation);

                if (!this.bankingRepository.BankReconcilationUpdate(objBankReconcilation).IsSuccessfull)
                {
                    action = base.View(objBankReconcilation);
                }
                else
                {
                    action = base.RedirectToAction("ReconcilationDone");
                }
                return action;
      }
      return (ActionResult) this.View((object)objBankReconcilation);
    }

 public ActionResult ReconcilationDone()
   {
       return base.View();
   }

        
   public JsonResult GetOpeningBal(short LocationId, DateTime FromDate, DateTime ToDate, short BankAccountId)
        {
            return this.Json((object)this.bankingRepository.GetOpeningBalDtl(LocationId, FromDate, ToDate, BankAccountId));
            
        }

    public JsonResult GetChequeDetailsForBankReconciliation(
      BankReconcilation objBankReconcilation)
    {
      return this.Json((object) this.bankingRepository.GetChequeDetailsForBankReconciliation(objBankReconcilation));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.bankingRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
