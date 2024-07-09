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
  public class RouteCityWiseController : Controller
  {
    private readonly IRouteCityWiseRepository routeRepository;
        private readonly IRouteRepository routeRepositoryMaster;
        private readonly IGeneralRepository generalRepository;
    private readonly IVehicleTypeRepository vehicleTypeRepository;

    public RouteCityWiseController()
    {
    }

    public RouteCityWiseController(
      IRouteCityWiseRepository _routeCityWiseRepository,
      IGeneralRepository _generalRepository,
      IVehicleTypeRepository _vehicleTypeRepository,
      IRouteRepository _routeRepositoryMaster)
    {
      this.routeRepository = _routeCityWiseRepository;
      this.generalRepository = _generalRepository;
      this.vehicleTypeRepository = _vehicleTypeRepository;
      this.routeRepositoryMaster = _routeRepositoryMaster;
    }
    public JsonResult ValidateRoute(int TransportModeId, int RouteCategoryIsLongHaul, string locationId)
    {
        return base.Json(this.routeRepository.ValidateRoute(TransportModeId, RouteCategoryIsLongHaul, locationId));
    }
    public ActionResult StandardRouteCharge()
    {
        ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
        ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetAllList();
        ((dynamic)base.ViewBag).Message = "";
        return (ActionResult)this.View();
   }

    [HttpPost]
    public ActionResult StandardRouteCharge(MasterStandardRouteCharge obj)
    {
        Response response;
        obj.EntryBy = SessionUtility.LoginUserId;
        obj.EntryDate = DateTime.Now;

        response = this.routeRepository.StandardRouteChargeUpdate(obj);

            if (response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
                ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetAllList();
                ((dynamic)base.ViewBag).Message = "Record submitted successfully";
                return (ActionResult)this.View(obj);
            }

        return (ActionResult)this.View(obj);
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.routeRepository.GetAll());
    }

    public ActionResult Insert(short? id)
    {
      MasterRouteCityWise masterRouteCityWise = new MasterRouteCityWise();
      short? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        masterRouteCityWise = this.routeRepository.GetDetailById(id.Value);
      if (masterRouteCityWise.RouteDetailList.Count == 0)
      {
        masterRouteCityWise.RouteDetailList.Add(new MasterRouteCityWiseDetail());
        masterRouteCityWise.RouteDetailList.Add(new MasterRouteCityWiseDetail());
      }
      this.Init();
      return (ActionResult) this.View((object) masterRouteCityWise);
    }

    [ValidateAntiModelInjection("RouteId")]
    [HttpPost]
    public ActionResult Insert(MasterRouteCityWise objMasterRouteCityWise)
    {
            objMasterRouteCityWise.DriverAdvanceAmount = 0;
            objMasterRouteCityWise.FuelQuantity = 0;


            if (objMasterRouteCityWise.RouteDetailList.Count < 2)
        this.ModelState.AddModelError("NumberOfRows", "Please select minimum two locations");
      if (this.ModelState.IsValid)
      {
        byte num = 0;
        foreach (MasterRouteCityWiseDetail routeDetail in objMasterRouteCityWise.RouteDetailList)
          routeDetail.RouteIndex = num++;
        Response response;
        if (objMasterRouteCityWise.RouteId == (short) 0)
        {
          objMasterRouteCityWise.EntryBy = SessionUtility.LoginUserId;
          objMasterRouteCityWise.EntryDate = DateTime.Now;
          response = this.routeRepository.Insert(objMasterRouteCityWise);
        }
        else
        {
          objMasterRouteCityWise.UpdateBy = new short?(SessionUtility.LoginUserId);
          objMasterRouteCityWise.UpdateDate = new DateTime?(DateTime.Now);
          response = this.routeRepository.Update(objMasterRouteCityWise);
        }
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
        this.TempData["result"] = (object) response;
      }
      this.Init();
      return (ActionResult) this.View((object) objMasterRouteCityWise);
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.routeRepository.GetDetailById((short) id.Value));
    }

        private void Init()
        {
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RouteCategoryList = this.generalRepository.GetByIdList(50);
        }

        public JsonResult IsRouteNameExist(string routeName)
    {
      return this.Json((object) this.routeRepository.IsRouteNameExist(routeName));
    }

    public JsonResult GetTransitTime(short routeId)
    {
      return this.Json((object) this.routeRepository.GetRouteTransitTime(routeId));
    }
    public JsonResult StandardRouteChargeView(string RouteId, string VehicleTypeId)
    {
        return this.Json((object)this.routeRepository.StandardRouteChargeView(RouteId, VehicleTypeId));
    }

   [HttpPost]
    public JsonResult GetAutoCompleteList(string routeName)
    {
      return this.Json((object) this.routeRepository.GetAutoCompleteList(routeName));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.routeRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
