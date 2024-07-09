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
  public class SupervisorController : Controller
  {
    private readonly ISupervisorRepository supervisorRepository;
    private readonly IWarehouseRepository warehouseRepository;
    private readonly IGeneralRepository generalRepository;

        public SupervisorController()
        {
        }

        public SupervisorController(ISupervisorRepository _supervisorRepository, IWarehouseRepository _warehouseRepository, IGeneralRepository _generalRepository)
        {
            this.supervisorRepository = _supervisorRepository;
            this.warehouseRepository = _warehouseRepository;
            this.generalRepository = _generalRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.supervisorRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetAutoCompleteList(string supervisorName)
        {
            JsonResult jsonResult = base.Json(this.supervisorRepository.GetAutoCompleteList(supervisorName, SessionUtility.WarehouseId));
            return jsonResult;
        }

        public ActionResult Index()
        {
            return base.View(this.supervisorRepository.GetAll());
        }

        public ActionResult Insert()
        {
            MasterSupervisor masterSupervisor = new MasterSupervisor();
            ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetVirtualLoginWarehouseList(SessionUtility.LoginUserId);
            ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(88);
            return base.View(masterSupervisor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("SupervisorId")]
        public ActionResult Insert(MasterSupervisor objMasterSupervisor)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetVirtualLoginWarehouseList(SessionUtility.LoginUserId);
                ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(88);
                action = base.View(objMasterSupervisor);
            }
            else
            {
                objMasterSupervisor.EntryBy = SessionUtility.LoginUserId;
                byte num = this.supervisorRepository.Insert(objMasterSupervisor);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("SupervisorId")]
        public JsonResult IsSupervisorNameAvailable(MasterSupervisor objMasterSupervisor)
        {
            JsonResult jsonResult = base.Json(this.supervisorRepository.IsSupervisorNameAvailable(objMasterSupervisor.SupervisorName, objMasterSupervisor.SupervisorId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsSupervisorNameExist(string supervisorName)
        {
            JsonResult jsonResult = base.Json(this.supervisorRepository.IsSupervisorNameExist(supervisorName, SessionUtility.WarehouseId));
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
                ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(88);
                httpStatusCodeResult = base.View(this.supervisorRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("SupervisorId")]
        public ActionResult Update(MasterSupervisor objMasterSupervisor)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetVirtualLoginWarehouseList(SessionUtility.LoginUserId);
                ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(88);
                action = base.View(objMasterSupervisor);
            }
            else
            {
                objMasterSupervisor.UpdateBy = new short?(SessionUtility.LoginUserId);
                byte num = this.supervisorRepository.Update(objMasterSupervisor);
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
                httpStatusCodeResult = base.View(this.supervisorRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}
