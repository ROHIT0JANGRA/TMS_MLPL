using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class AccountOpeningController : Controller
  {
    private readonly IAccountOpeningRepository accountOpeningRepository;
    private readonly IAccountCategoryRepository accountCategoryRepository;
    private readonly ILocationRepository locationRepository;

        public AccountOpeningController()
        {
            this.accountOpeningRepository = new AccountOpeningRepository();
            this.accountCategoryRepository = new AccountCategoryRepository();
            this.locationRepository = new LocationRepository();
        }

        public ActionResult AccountOpening()
        {
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountOpening(MasterAccountOpening objAccountOpening)
        {
            ActionResult action;
            objAccountOpening.Details.RemoveAll((AccountOpeningDetail m) => !m.IsChecked);
            objAccountOpening.Details.ForEach((AccountOpeningDetail m) => m.FinYear = SessionUtility.FinYear);
            objAccountOpening.Details.ForEach((AccountOpeningDetail m) => m.EntryBy = SessionUtility.LoginUserId);
            objAccountOpening.Details.ForEach((AccountOpeningDetail m) => m.CompanyId = SessionUtility.CompanyId);
            if (this.accountOpeningRepository.InsetUpdate(objAccountOpening).IsSuccessfull)
            {
                action = base.RedirectToAction("Done");
                return action;
            }
            ((dynamic)base.ViewBag).AccountCategoryList = this.accountCategoryRepository.GetAccountCategoryList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            action = base.View(objAccountOpening);
            return action;
        }

        public ActionResult Done()
        {
            return base.View();
        }


        public JsonResult GetAll(bool isLocationWise, short id, byte accountCategoryId, short accountId, short locationId)
        {
            JsonResult jsonResult = base.Json(this.accountOpeningRepository.GetAll(isLocationWise, id, accountCategoryId, accountId, locationId));
            return jsonResult;
        }

    }
}
