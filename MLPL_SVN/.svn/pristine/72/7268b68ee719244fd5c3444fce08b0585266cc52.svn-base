using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class BudgetController : Controller
  {
    private IBudgetRepository budgetRepository;
    private ILocationRepository locationRepository;
    private IAccountCategoryRepository accountCategoryRepository;
    private IAccountRepository accountRepository;
    private IZoneRepository zoneRepository;

        public BudgetController(IBudgetRepository _budgetRepository, ILocationRepository _locationRepository, IAccountCategoryRepository _accountCategoryRepository, IAccountRepository _accountRepository, IZoneRepository _zoneRepository)
        {
            this.budgetRepository = _budgetRepository;
            this.locationRepository = _locationRepository;
            this.accountCategoryRepository = _accountCategoryRepository;
            this.accountRepository = _accountRepository;
            this.zoneRepository = _zoneRepository;
        }

        public BudgetController()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.budgetRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Index()
        {
            MasterBudgetCriteria masterBudgetCriterium = new MasterBudgetCriteria();
            this.Init(masterBudgetCriterium.LocationWiseAccountId, masterBudgetCriterium.LocationWiseBranchId);
            return base.View(masterBudgetCriterium);
        }

        [HttpPost]
        public ActionResult Index(MasterBudgetCriteria objBudget)
        {
            return base.View(objBudget);
        }

        private void Init(byte accountId, short locationId)
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).CategoryList = this.accountCategoryRepository.GetMainAccountCategoryList();
            ((dynamic)base.ViewBag).AccountCodeList = this.accountRepository.GetAccountListByAccountCategoryId(accountId);
            ((dynamic)base.ViewBag).BudgetYearList = this.budgetRepository.GetBudgetFinancialYearList();
            ((dynamic)base.ViewBag).RegionList = this.zoneRepository.GetZoneList();
            ((dynamic)base.ViewBag).AllBranchList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).AllAccountList = this.accountRepository.GetAllAccountCodeList();
        }


    }
}
