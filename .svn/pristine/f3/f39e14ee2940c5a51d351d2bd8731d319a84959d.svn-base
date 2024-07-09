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
  public class VehicleTypeController : Controller
  {
    private readonly IVehicleTypeRepository vehicleTypeRepository;
    private readonly IGeneralRepository generalRepository;

    public VehicleTypeController()
    {
    }

    public VehicleTypeController(
      IVehicleTypeRepository _vehicleTypeRepository,
      IGeneralRepository _generalRepository)
    {
      this.vehicleTypeRepository = _vehicleTypeRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.vehicleTypeRepository.GetAll());
    }

        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).FuelTypeList = this.generalRepository.GetByIdList(7);
            return base.View(new MasterVehicleType());
        }

        [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("VehicleTypeId")]
    public ActionResult Insert(MasterVehicleType objMasterVehicleType)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterVehicleType);
      objMasterVehicleType.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.vehicleTypeRepository.Insert(objMasterVehicleType)
      });
    }

        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            ((dynamic)base.ViewBag).FuelTypeList = this.generalRepository.GetByIdList(7);
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
                httpStatusCodeResult = base.View(this.vehicleTypeRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


        [ValidateAntiModelInjection("VehicleTypeId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterVehicleType objMasterVehicleType)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterVehicleType);
      objMasterVehicleType.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.vehicleTypeRepository.Update(objMasterVehicleType)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.vehicleTypeRepository.GetById(id.Value));
    }

    public JsonResult GetById(byte id)
    {
      return this.Json((object) this.vehicleTypeRepository.GetById(id), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    [ValidateAntiModelInjection("VehicleTypeId")]
    public JsonResult IsVehicleTypeNameAvailable(MasterVehicleType objMasterVehicleType)
    {
      return this.Json((object) this.vehicleTypeRepository.IsVehicleTypeNameAvailable(objMasterVehicleType.VehicleTypeId, objMasterVehicleType.VehicleTypeName));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.vehicleTypeRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
