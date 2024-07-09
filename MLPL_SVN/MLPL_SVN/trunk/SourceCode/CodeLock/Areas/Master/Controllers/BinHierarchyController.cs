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
  public class BinHierarchyController : Controller
  {
    private readonly IBinHierarchyRepository binHierarchyRepository;
    private readonly IWarehouseRepository warehouseRepository;

        public BinHierarchyController()
        {
        }

        public BinHierarchyController(IBinHierarchyRepository _binHierarchyRepository, IWarehouseRepository _warehouseRepository)
        {
            this.binHierarchyRepository = _binHierarchyRepository;
            this.warehouseRepository = _warehouseRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.binHierarchyRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return base.View(this.binHierarchyRepository.GetAll());
        }

        public ActionResult Insert()
        {
            MasterBinHierarchy masterBinHierarchy = new MasterBinHierarchy();
            ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetVirtualLoginWarehouseList(SessionUtility.LoginUserId);
            return base.View(masterBinHierarchy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("BinHierarchyId")]
        public ActionResult Insert(MasterBinHierarchy objMasterBinHierarchy)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterBinHierarchy);
            }
            else
            {
                objMasterBinHierarchy.EntryBy = SessionUtility.LoginUserId;
                byte num = this.binHierarchyRepository.Insert(objMasterBinHierarchy);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("BinHierarchyId")]
        public JsonResult IsBinHierarchyNameAvailable(MasterBinHierarchy objMasterBinHierarchy)
        {
            JsonResult jsonResult = base.Json(this.binHierarchyRepository.IsBinHierarchyNameAvailable(objMasterBinHierarchy.BinHierarchyName, (short)objMasterBinHierarchy.BinHierarchyId));
            return jsonResult;
        }

        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            byte? nullable2 = id;
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
                ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetVirtualLoginWarehouseList(SessionUtility.LoginUserId);
                httpStatusCodeResult = base.View(this.binHierarchyRepository.GetDetailById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("BinHierarchyId")]
        public ActionResult Update(MasterBinHierarchy objMasterBinHierarchy)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterBinHierarchy);
            }
            else
            {
                objMasterBinHierarchy.UpdateBy = new short?(SessionUtility.LoginUserId);
                byte num = this.binHierarchyRepository.Update(objMasterBinHierarchy);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        public ActionResult View(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            byte? nullable2 = id;
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
                httpStatusCodeResult = base.View(this.binHierarchyRepository.GetDetailById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }



    }
}
