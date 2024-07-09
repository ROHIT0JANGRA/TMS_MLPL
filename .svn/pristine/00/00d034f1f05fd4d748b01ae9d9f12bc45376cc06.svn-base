using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class VehicleCapacityRateController : Controller
  {
    private readonly IVehicleCapacityRateRepository vehicleCapacityRateRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly IVehicleTypeRepository vehicleTypeRepository;

    public VehicleCapacityRateController()
    {
    }

    public VehicleCapacityRateController(
      IVehicleCapacityRateRepository _vehicleCapacityRateRepository,
      IGeneralRepository _generalRepository,
      IVehicleTypeRepository _vehicleTypeRepository)
    {
      this.vehicleCapacityRateRepository = _vehicleCapacityRateRepository;
      this.generalRepository = _generalRepository;
      this.vehicleTypeRepository = _vehicleTypeRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.vehicleCapacityRateRepository.GetAll());
    }

        public ActionResult Insert(short? id)
        {
            ActionResult actionResult;
            int? nullable;
            int? nullable1;
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            MasterVehicleCapacityRate masterVehicleCapacityRate = new MasterVehicleCapacityRate();
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
            if (!nullable.HasValue)
            {
                masterVehicleCapacityRate.Details.Add(new VehicleCapacityRateDetail());
                actionResult = base.View(masterVehicleCapacityRate);
            }
            else
            {
                actionResult = base.View(this.vehicleCapacityRateRepository.GetById(id.Value));
            }
            return actionResult;
        }

        [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(
      MasterVehicleCapacityRate objMasterVehicleCapacityRate)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterVehicleCapacityRate);
      objMasterVehicleCapacityRate.EntryBy = SessionUtility.LoginUserId;
      objMasterVehicleCapacityRate.UpdateBy = new short?(SessionUtility.LoginUserId);
      this.vehicleCapacityRateRepository.InsertUpdate(objMasterVehicleCapacityRate);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = objMasterVehicleCapacityRate.VendorId
      });
    }

    [HttpPost]
    public JsonResult IsVendorAvailable(string vendorCode, short vendorId)
    {
      return this.Json((object) this.vehicleCapacityRateRepository.IsVendorAvailable(vendorCode, vendorId));
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.vehicleCapacityRateRepository.GetById(id.Value));
    }

    public JsonResult GetById(short id)
    {
      return this.Json((object) this.vehicleCapacityRateRepository.GetById(id), JsonRequestBehavior.AllowGet);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.vehicleCapacityRateRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
