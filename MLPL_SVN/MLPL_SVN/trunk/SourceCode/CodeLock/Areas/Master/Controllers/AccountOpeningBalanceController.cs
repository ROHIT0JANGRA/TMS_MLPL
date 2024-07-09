using Antlr.Runtime.Misc;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class AccountOpeningBalanceController : Controller
    {
        private readonly IAccountOpeningBalanceRepository accountOpeningBalanceRepository;
        private readonly IAccountCategoryRepository accountCategoryRepository;

        public AccountOpeningBalanceController()
        {
            this.accountOpeningBalanceRepository = new AccountOpeningBalanceRepository();
            this.accountCategoryRepository = new AccountCategoryRepository();
        }

        public ActionResult AccountOpeningBalance()
        {
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountOpeningBalance(MasterAccountOpeningBalance objAccountOpeningBalance)
        {
            ActionResult action;
            if (this.accountOpeningBalanceRepository.InsetUpdate(objAccountOpeningBalance).IsSuccessfull)
            {
                action = base.RedirectToAction("Done");
                return action;
            }
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            return base.View();
        }

        public ActionResult Done()
        {
            return base.View();
        }
    }
}