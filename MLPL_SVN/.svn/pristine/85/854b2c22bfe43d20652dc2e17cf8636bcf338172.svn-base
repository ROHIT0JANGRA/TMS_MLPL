using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class AccountOpeningPartyController : Controller
    {
        private IAccountOpeningPartyRepository accountOpeningPartyRepository;
        private IGeneralRepository generalRepository;
        private ILocationRepository locationRepository;
        private IAccountRepository accountRepository;

        public AccountOpeningPartyController()
        {
            this.accountOpeningPartyRepository = (IAccountOpeningPartyRepository)new AccountOpeningPartyRepository();
            this.accountRepository = (IAccountRepository)new AccountRepository();
            this.generalRepository = (IGeneralRepository)new GeneralRepository();
            this.locationRepository = (ILocationRepository)new LocationRepository();
        }

        public ActionResult AccountOpeningParty()
        {
            this.Init();
            IEnumerable<AutoCompleteResult> accountList =  this.accountRepository.GetAllAccountCodeList();
            foreach (var item in accountList)
            {
                item.Name = item.Name + " : " + item.Description; 
            }
            ((dynamic)base.ViewBag).AccountList = accountList;
            return (ActionResult)this.View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AccountOpeningParty(
          MasterAccountOpeningParty objAccountOpeningParty)
        {
            if (objAccountOpeningParty.PartyType != (byte)2)
                this.ModelState.Remove("VendorTypeId");
            if (this.ModelState.IsValid)
            {
                objAccountOpeningParty.FinYear = SessionUtility.FinYear;
                objAccountOpeningParty.CompanyId = SessionUtility.CompanyId;
                if (this.accountOpeningPartyRepository.InsetUpdate(objAccountOpeningParty).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("Done");
            }
            this.Init();
            return (ActionResult)this.View((object)objAccountOpeningParty);
        }

        public ActionResult Done()
        {
            return (ActionResult)this.View();
        }

        private void Init()
        {
            string[] strArrays = new string[] { "1" };
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            IEnumerable<AutoCompleteResult> customerAccountList = this.accountOpeningPartyRepository.GetCustomerAccountList();
            ((dynamic)base.ViewBag).CustomerAccountList = JsonConvert.SerializeObject(customerAccountList);
            IEnumerable<AutoCompleteResult> vendorAccountList = this.accountOpeningPartyRepository.GetVendorAccountList();
            ((dynamic)base.ViewBag).VendorAccountList = JsonConvert.SerializeObject(vendorAccountList);
        }

        public JsonResult GetCreditDebit(
         short partyType,
         int partyId,
         byte locationId,
         short accountId)
        {
            return this.Json((object)this.accountOpeningPartyRepository.GetCreditDebit(partyType, partyId, locationId, accountId,SessionUtility.FinYear), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.accountOpeningPartyRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
