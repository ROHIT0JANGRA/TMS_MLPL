using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class FlightController : Controller
  {
    private readonly IFlightRepository flightRepository;
    private readonly IGeneralRepository generalRepository;

        public FlightController()
        {
        }

        public FlightController(IFlightRepository _flightRepository, IGeneralRepository _generalRepository)
        {
            this.flightRepository = _flightRepository;
            this.generalRepository = _generalRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.flightRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return base.View(this.flightRepository.GetAll());
        }

        public ActionResult Insert(short? id)
        {
            int? nullable;
            int? nullable1;
            MasterFlight masterFlight = new MasterFlight()
            {
                FlightId = 0,
                Details = new List<FlightDetail>()
            };
            MasterFlight detailById = masterFlight;
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
                List<FlightDetail> details = detailById.Details;
                FlightDetail flightDetail = new FlightDetail()
                {
                    FlightId = 0,
                    TransitId = 0,
                    DepartureTime = DateTime.Now,
                    ArrivalTime = DateTime.Now,
                    TransitDays = 0,
                    Days = ""
                };
                details.Add(flightDetail);
            }
            else
            {
                detailById = this.flightRepository.GetDetailById(id.Value);
                detailById.Details = this.flightRepository.GetFlightDetail(id.Value).ToList<FlightDetail>();
            }
            ((dynamic)base.ViewBag).AirlineList = this.generalRepository.GetByIdList(34);
            detailById.Day = (
                from m in this.generalRepository.GetAll(21)
                orderby m.CodeId
                select m).ToArray<MasterGeneral>();
            return base.View(detailById);
        }

        [HttpPost]
        [ValidateAntiModelInjection("FlightId")]
        public ActionResult Insert(MasterFlight objMasterFlight)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).AirlineList = this.generalRepository.GetByIdList(34);
                action = base.View(objMasterFlight);
            }
            else
            {
                short num = 0;
                for (short i = 0; i < objMasterFlight.Details.Count; i = (short)(i + 1))
                {
                    objMasterFlight.Details[i].TransitId = (i + 1).ConvertToShort();
                }
                if (objMasterFlight.FlightId <= 0)
                {
                    objMasterFlight.EntryBy = SessionUtility.LoginUserId;
                    num = this.flightRepository.Insert(objMasterFlight);
                }
                else
                {
                    objMasterFlight.UpdateBy = new short?(SessionUtility.LoginUserId);
                    num = this.flightRepository.Update(objMasterFlight);
                }
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("FlightId")]
        public JsonResult IsFlightNoAvailable(MasterFlight objMasterFlight)
        {
            JsonResult jsonResult = base.Json(this.flightRepository.IsFlightNoAvailable(objMasterFlight.FlightNo, objMasterFlight.FlightId));
            return jsonResult;
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
                httpStatusCodeResult = base.View(this.flightRepository.GetDetailById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}
