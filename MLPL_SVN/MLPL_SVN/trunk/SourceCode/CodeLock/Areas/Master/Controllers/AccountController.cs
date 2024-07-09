
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountCategoryRepository accountCategoryRepository;
        private readonly IAccountGroupRepository accountGroupRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ILocationRepository locationRepository;

        public AccountController()
        {
        }

        public AccountController(IAccountRepository _accountRepository, IAccountCategoryRepository _accountCategoryRepository, IAccountGroupRepository _accountGroupRepository, IGeneralRepository _generalRepository, ICompanyRepository _companyRepository, ILocationRepository _locationRepository)
        {
            this.accountRepository = _accountRepository;
            this.accountCategoryRepository = _accountCategoryRepository;
            this.accountGroupRepository = _accountGroupRepository;
            this.generalRepository = _generalRepository;
            this.companyRepository = _companyRepository;
            this.locationRepository = _locationRepository;
        }

        public ActionResult ChartOfAccount()
        {
            ((dynamic)base.ViewBag).TreeData = JsonConvert.SerializeObject(this.accountRepository.GetChartOfAccount());
            return base.View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.accountRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetAccountAutoCompleteList(string accountCode)
        {
            return base.Json(this.accountRepository.GetAccountAutoCompleteList(accountCode));
        }

        public JsonResult GetAccountCodeList(byte categoryId)
        {
            return base.Json(this.accountRepository.GetAccountListByAccountCategoryId(categoryId));
        }

        public IEnumerable<AutoCompleteResult> GetAccountCodeListByCategoryId(byte categoryId)
        {
            return this.accountRepository.GetAccountListByAccountCategoryId(categoryId);
        }

        public JsonResult GetAccountListByAccountCategoryId(byte categoryId)
        {
            return base.Json(this.accountRepository.GetAccountListByAccountCategoryId(categoryId));
        }

        public IEnumerable<AutoCompleteResult> GetAccountListForCardCategory()
        {
            return this.accountRepository.GetAccountListForCardCategory();
        }

        public IEnumerable<AutoCompleteResult> GetAllAccountCodeList()
        {
            return this.accountRepository.GetAllAccountCodeList();
        }

        public JsonResult GetListByCategory(byte categoryId)
        {
            return base.Json(this.accountRepository.GetAccountListByAccountCategoryId(categoryId));
        }

        public IEnumerable<AutoCompleteResult> GetSelectList(byte categoryId)
        {
            return this.accountRepository.GetAccountListByAccountCategoryId(categoryId);
        }

        [HttpPost]
        public JsonResult GetTaxDetails()
        {
            return base.Json(this.accountRepository.GetTaxDetails(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return base.View(this.accountRepository.GetAll());
        }

        public ActionResult Insert()
        {
            MasterAccount masterAccount = new MasterAccount();
            ((dynamic)base.ViewBag).CategoryList = this.accountCategoryRepository.GetMainAccountCategoryList();
            ((dynamic)base.ViewBag).GroupList = this.accountGroupRepository.GetListByCategoryId(masterAccount.AccountCategoryId);
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).PartyAccountList = this.generalRepository.GetByIdList(11);
            ((dynamic)base.ViewBag).AccountCodeList = this.accountGroupRepository.GetAccountGroupListByMainCategoryId(masterAccount.MainCategoryId);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(masterAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("AccountId")]
        public ActionResult Insert(MasterAccount objMasterAccount)
        {
            ActionResult action;
            base.ModelState["MappedAccountId"].Errors.Clear();
            base.ModelState["PartyId"].Errors.Clear();
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterAccount);
            }
            else
            {
                objMasterAccount.EntryBy = SessionUtility.LoginUserId;
                short num = this.accountRepository.Insert(objMasterAccount);
                if (num == 0)
                { action = base.RedirectToAction("Done", new { documentNo = "Account already opened ." }); }
                else if (num == -1)
                { action = base.RedirectToAction("Done", new { documentNo = "Account description is already used." }); }
                else
                { action = base.RedirectToAction("View", new { id = num }); }

            }
            return action;
        }


        public ActionResult Done()
        {
            return (ActionResult)this.View();
        }


        [HttpPost]
        [ValidateAntiModelInjection("AccountId")]
        public JsonResult IsAccountCodeAvailable(MasterAccount objMasterAccount)
        {
            JsonResult jsonResult = base.Json(this.accountRepository.IsAccountCodeAvailable(objMasterAccount.AccountCode, objMasterAccount.AccountId));
            return jsonResult;
        }

        public JsonResult IsAccountCodeExist(string accountCode)
        {
            return base.Json(this.accountRepository.IsAccountCodeExist(accountCode));
        }

        public JsonResult IsChequeExist(string chequeNo, DateTime chequeDate, byte partyTypeId, short partyId)
        {
            JsonResult jsonResult = base.Json(this.accountRepository.IsChequeExist(chequeNo, chequeDate, partyTypeId,partyId));
            return jsonResult;
        }

        public JsonResult IsChequeExistForCollection(string chequeNo, DateTime chequeDate, byte partyTypeId, short partyId)
        {
            JsonResult jsonResult = base.Json(this.accountRepository.IsChequeExistForCollection(chequeNo, chequeDate,  partyTypeId,  partyId));
            return jsonResult;
        }

        public ActionResult Update(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            MasterAccount masterAccount = new MasterAccount();
            masterAccount = this.accountRepository.GetById(id.Value);
            ((dynamic)base.ViewBag).CategoryList = this.accountCategoryRepository.GetMainAccountCategoryList();


            ((dynamic)base.ViewBag).GroupList = this.accountGroupRepository.GetListByCategoryId(masterAccount.AccountCategoryId);
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            IEnumerable<AutoCompleteResult> byIdList = this.generalRepository.GetByIdList(11);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            List<AutoCompleteResult> autoCompleteResults = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteResults.Add(autoCompleteResult);
            autoCompleteResults.AddRange(byIdList);
            ((dynamic)base.ViewBag).PartyAccountList = autoCompleteResults;
            ((dynamic)base.ViewBag).AccountCodeList = this.accountGroupRepository.GetAccountGroupListByCategoryId(masterAccount.MainCategoryId);
            ((dynamic)base.ViewBag).MappedAccountList = this.accountRepository.GetAccountListByAccountCategoryId(masterAccount.AccountCategoryId);
            short? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                httpStatusCodeResult = base.View(masterAccount);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("AccountId")]
        public ActionResult Update(MasterAccount objMasterAccount)
        {
            ActionResult action;
            base.ModelState["MappedAccountId"].Errors.Clear();
            base.ModelState["PartyId"].Errors.Clear();
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterAccount);
            }
            else
            {
                objMasterAccount.UpdateBy = new short?(SessionUtility.LoginUserId);
                short num = this.accountRepository.Update(objMasterAccount);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }
        public ActionResult View(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            short? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                httpStatusCodeResult = base.View(this.accountRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        public JsonResult GetAutoCompleteVendorAccountList(string vendorCode, byte vendorTypeId)
        {
            vendorTypeId = 4;
            byte LocationId = Convert.ToByte(SessionUtility.LoginLocationId);
            JsonResult jsonResult = base.Json(this.accountRepository.GetAutoCompleteVendorAccountList(vendorCode, vendorTypeId, LocationId));

            return jsonResult;
        }



    }
}
