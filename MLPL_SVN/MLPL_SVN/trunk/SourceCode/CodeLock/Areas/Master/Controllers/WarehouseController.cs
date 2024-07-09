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
  public class WarehouseController : Controller
  {
    private readonly IWarehouseRepository warehouseRepository;

        public WarehouseController()
        {
        }

        public WarehouseController(IWarehouseRepository _warehouseRepository)
        {
            this.warehouseRepository = _warehouseRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.warehouseRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetAutoCompleteList(string warehouseName)
        {
            return base.Json(this.warehouseRepository.GetAutoCompleteList(warehouseName));
        }

        public ActionResult Index()
        {
            return base.View(this.warehouseRepository.GetAll());
        }

        public ActionResult Insert()
        {
            ILocationRepository locationRepository = new LocationRepository();
            ((dynamic)base.ViewBag).LocationList = locationRepository.GetLocationList();
            return base.View(new MasterWarehouse());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("WarehouseId")]
        public ActionResult Insert(MasterWarehouse objMasterWarehouse)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).LocationList = (new LocationRepository()).GetLocationList();
                action = base.View(objMasterWarehouse);
            }
            else
            {
                objMasterWarehouse.EntryBy = SessionUtility.LoginUserId;
                byte num = this.warehouseRepository.Insert(objMasterWarehouse);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        public JsonResult IsWarehouseNameExist(string warehouseName)
        {
            return base.Json(this.warehouseRepository.IsWarehouseNameExist(warehouseName));
        }

        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            ILocationRepository locationRepository = new LocationRepository();
            ((dynamic)base.ViewBag).LocationList = locationRepository.GetLocationList();
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
                httpStatusCodeResult = base.View(this.warehouseRepository.GetById((short)id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("WarehouseId")]
        public ActionResult Update(MasterWarehouse objMasterWarehouse)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).LocationList = (new LocationRepository()).GetLocationList();
                action = base.View(objMasterWarehouse);
            }
            else
            {
                objMasterWarehouse.UpdateBy = new short?(SessionUtility.LoginUserId);
                byte num = this.warehouseRepository.Update(objMasterWarehouse);
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
                httpStatusCodeResult = base.View(this.warehouseRepository.GetById((short)id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}
