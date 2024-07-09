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
  public class BinsController : Controller
  {
    private readonly IBinsRepository binsRepository;
    private readonly IBinHierarchyRepository binHierarchyRepository;

        public BinsController()
        {
        }

        public BinsController(IBinsRepository _binsRepository, IBinHierarchyRepository _binHierarchyRepository)
        {
            this.binsRepository = _binsRepository;
            this.binHierarchyRepository = _binHierarchyRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.binsRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetAutoCompleteList(string binCode)
        {
            JsonResult jsonResult = base.Json(this.binsRepository.GetAutoCompleteList(binCode, SessionUtility.WarehouseId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetParentBinList(byte binHierarchyId)
        {
            return base.Json(this.binsRepository.GetParentBinList(binHierarchyId));
        }

        public JsonResult GetParentHierarchy(byte binHierarchyId)
        {
            return base.Json(this.binsRepository.GetParentHierarchy(binHierarchyId));
        }

        public ActionResult Index()
        {
            return base.View(this.binsRepository.GetAll());
        }

        public ActionResult Insert()
        {
            MasterBins masterBin = new MasterBins();
            ((dynamic)base.ViewBag).BinHierarchyList = this.binHierarchyRepository.GetBinHierarchyList();
            return base.View(masterBin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("BindId")]
        public ActionResult Insert(MasterBins objMasterBins)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterBins);
            }
            else
            {
                objMasterBins.EntryBy = SessionUtility.LoginUserId;
                objMasterBins.WarehouseId = SessionUtility.WarehouseId;
                int num = this.binsRepository.Insert(objMasterBins);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("BindId")]
        public JsonResult IsBinCodeAvailable(MasterBins objMasterBins)
        {
            JsonResult jsonResult = base.Json(this.binsRepository.IsBinCodeAvailable(objMasterBins.BinCode, objMasterBins.BindId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsBinCodeExist(string binCode)
        {
            JsonResult jsonResult = base.Json(this.binsRepository.IsBinCodeExist(binCode, SessionUtility.WarehouseId));
            return jsonResult;
        }
        public JsonResult IsBinNameAvailableBySku(string skuId, string binId)
        {
            JsonResult jsonResult = base.Json(this.binsRepository.IsBinNameAvailableBySku(skuId, binId));
            return jsonResult;
        }


        [HttpPost]
        [ValidateAntiModelInjection("BindId")]
        public JsonResult IsBinNameAvailable(MasterBins objMasterBins)
        {
            JsonResult jsonResult = base.Json(this.binsRepository.IsBinNameAvailable(objMasterBins.BinName, objMasterBins.BindId));
            return jsonResult;
        }

        public ActionResult Update(int? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            int? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?((int)nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                ((dynamic)base.ViewBag).BinHierarchyList = this.binHierarchyRepository.GetBinHierarchyList();
                httpStatusCodeResult = base.View(this.binsRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("BindId")]
        public ActionResult Update(MasterBins objMasterBins)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterBins);
            }
            else
            {
                objMasterBins.UpdateBy = new short?(SessionUtility.LoginUserId);
                objMasterBins.WarehouseId = SessionUtility.WarehouseId;
                int num = this.binsRepository.Update(objMasterBins);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        public ActionResult View(int? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            int? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?((int)nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                httpStatusCodeResult = base.View(this.binsRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}
