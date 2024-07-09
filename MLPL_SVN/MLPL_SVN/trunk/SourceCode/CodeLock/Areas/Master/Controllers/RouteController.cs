using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeLock.Areas.Master.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteRepository routeRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IRulesRepository rulesRepository;

        public RouteController()
        {
        }

        public RouteController(
          IRouteRepository _routeRepository,
          IGeneralRepository _generalRepository,
          IRulesRepository _rulesRepository)
        {
            this.routeRepository = _routeRepository;
            this.generalRepository = _generalRepository;
            this.rulesRepository = _rulesRepository;
        }

        public JsonResult ValidateRoute(int TransportModeId, int RouteCategoryIsLongHaul, string locationId,short routeId)
        {
            return base.Json(this.routeRepository.ValidateRoute(TransportModeId, RouteCategoryIsLongHaul, locationId, routeId));
        }

        public ActionResult Index()
        {
            return (ActionResult)this.View((object)this.routeRepository.GetAll());
        }

        public ActionResult Insert(short? id)
        {
            MasterRoute masterRoute = new MasterRoute();
            short? nullable = id;
            if ((nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                masterRoute = this.routeRepository.GetById(id.Value);
            if (masterRoute.RouteDetailList.Count == 0)
            {
                masterRoute.RouteDetailList.Add(new MasterRouteDetail());
                masterRoute.RouteDetailList.Add(new MasterRouteDetail());
            }
            this.Init();
            return (ActionResult)this.View((object)masterRoute);
        }

        private void Init()
        {
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RouteCategoryList = this.generalRepository.GetByIdList(50);
            ((dynamic)base.ViewBag).IsUseRouteContractAmount = this.rulesRepository.GetModuleRuleByIdAndRuleId(5, 1);
        }

        [ValidateAntiModelInjection("RouteId")]
        [HttpPost]
        public ActionResult Insert(MasterRoute objMasterRoute)
        {
            if (objMasterRoute.RouteDetailList.Count < 2)
                this.ModelState.AddModelError("NumberOfRows", "Please select minimum two locations");
            if (!objMasterRoute.IsUseRouteContractAmount)
            {
                this.ModelState["FromAmount"].Errors.Clear();
                this.ModelState["ToAmount"].Errors.Clear();
            }
            if (this.ModelState.IsValid)
            {
                byte num = 0;
                foreach (MasterRouteDetail routeDetail in objMasterRoute.RouteDetailList)
                    routeDetail.RouteIndex = num++;
                if (objMasterRoute.RouteId == (short)0)
                {
                    objMasterRoute.EntryBy = SessionUtility.LoginUserId;
                    Response response = this.routeRepository.Insert(objMasterRoute);
                    if (response.IsSuccessfull)
                        return (ActionResult)this.RedirectToAction("View", (object)new
                        {
                            id = response.DocumentId
                        });
                }
                else
                {
                    objMasterRoute.UpdateBy = new short?(SessionUtility.LoginUserId);
                    Response response = this.routeRepository.Update(objMasterRoute);
                    if (response.IsSuccessfull)
                        return (ActionResult)this.RedirectToAction("View", (object)new
                        {
                            id = response.DocumentId
                        });
                }
            }
            this.Init();
            return (ActionResult)this.View((object)objMasterRoute);
        }

        public ActionResult View(short? id)
        {
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //return (ActionResult) this.View((object) this.routeRepository.GetById((short) (byte) id.Value));
            return (ActionResult)this.View((object)this.routeRepository.GetById((short)id.Value));
        }

        [HttpPost]
        public JsonResult GetRouteListByTransportModeId(byte transportModeId,short locationId)
        {
            return this.Json((object)this.routeRepository.GetRouteListByTransportModeId(transportModeId, locationId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckValidContractAmount(byte routeId, Decimal contractAmount)
        {
            return this.Json((object)this.routeRepository.CheckValidContractAmount(routeId, contractAmount), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsRouteNameAvailable(short routesId, string routeName)
        {
            return Json(routeRepository.IsRouteNameAvailable(routesId, routeName));
            //return this.Json((object)this.routeRepository.IsRouteNameAvailable(routesId, routeName), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.routeRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
