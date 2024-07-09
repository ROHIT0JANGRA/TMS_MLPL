
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class AccountGroupController : Controller
  {
    private readonly IAccountGroupRepository accountGroupRepository;
    private readonly IAccountCategoryRepository accountCategoryRepository;

        public AccountGroupController()
        {
        }

        public AccountGroupController(IAccountGroupRepository _accountGroupRepository, IAccountCategoryRepository _accountCategoryRepository)
        {
            this.accountGroupRepository = _accountGroupRepository;
            this.accountCategoryRepository = _accountCategoryRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.accountGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetAccountGroupListByCategoryId(byte accountCategoryId)
        {
            return base.Json(this.accountGroupRepository.GetListByCategoryId(accountCategoryId));
        }

        public ActionResult Index()
        {
            return base.View(this.accountGroupRepository.GetAll());
        }

        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).CategoryList = this.accountCategoryRepository.GetMainAccountCategoryList();
            MasterAccountGroup masterAccountGroup = new MasterAccountGroup();
            ((dynamic)base.ViewBag).GroupCodeList = this.accountGroupRepository.GetListByCategoryId(masterAccountGroup.AccountCategoryId);
            return base.View(masterAccountGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("AccountGroupId")]
        public ActionResult Insert(MasterAccountGroup objMasterAccountGroup)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterAccountGroup);
            }
            else
            {
                objMasterAccountGroup.EntryBy = SessionUtility.LoginUserId;
                short num = this.accountGroupRepository.Insert(objMasterAccountGroup);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("AccountGroupId")]
        public JsonResult IsGroupCodeAvailable(MasterAccountGroup objMasterAccountGroup)
        {
            JsonResult jsonResult = base.Json(this.accountGroupRepository.IsGroupCodeAvailable(objMasterAccountGroup.GroupCode, objMasterAccountGroup.AccountGroupId));
            return jsonResult;
        }

        [HttpPost]
        [ValidateAntiModelInjection("AccountGroupId")]
        public JsonResult IsGroupNameAvailable(MasterAccountGroup objMasterAccountGroup)
        {
            JsonResult jsonResult = base.Json(this.accountGroupRepository.IsGroupNameAvailable(objMasterAccountGroup.GroupName, objMasterAccountGroup.AccountGroupId));
            return jsonResult;
        }

        public ActionResult Update(short? id)
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
                ((dynamic)base.ViewBag).CategoryList = this.accountCategoryRepository.GetMainAccountCategoryList();
                MasterAccountGroup masterAccountGroup = new MasterAccountGroup();
                ((dynamic)base.ViewBag).GroupCodeList = this.accountGroupRepository.GetListByCategoryId(masterAccountGroup.AccountCategoryId);
                httpStatusCodeResult = base.View(this.accountGroupRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("AccountGroupId")]
        public ActionResult Update(MasterAccountGroup objMasterAccountGroup)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterAccountGroup);
            }
            else
            {
                objMasterAccountGroup.UpdateBy = new short?(SessionUtility.LoginUserId);
                short num = this.accountGroupRepository.Update(objMasterAccountGroup);
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
                httpStatusCodeResult = base.View(this.accountGroupRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }



    }
}
