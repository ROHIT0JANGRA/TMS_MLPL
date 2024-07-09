
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class AirportController : Controller
  {
    private readonly IAirportRepository airportRepository;
    private readonly ICountryRepository countryRepository;
    private readonly IStateRepository stateRepository;
    private readonly ICityRepository cityRepository;

        public AirportController()
        {
        }

        public AirportController(IAirportRepository _airportRepository, ICountryRepository _countryRepository, IStateRepository _stateRepository, ICityRepository _cityRepository)
        {
            this.airportRepository = _airportRepository;
            this.countryRepository = _countryRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
        }

        public JsonResult CheckValidAirportNo(string airportNo)
        {
            return base.Json(this.airportRepository.CheckValidAirportNo(airportNo));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.airportRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetAirlineList(byte airportId)
        {
            return base.Json(this.airportRepository.GetAirLineList(airportId));
        }

        public SelectList GetAirPortList()
        {
            return new SelectList(this.airportRepository.GetAirPortList(), "Value", "Name");
        }

        public JsonResult GetAutoCompleteList(string airportNo)
        {
            return base.Json(this.airportRepository.GetAutoCompleteList(airportNo));
        }

        public JsonResult GetFlightList(byte airlineId, DateTime dateTime)
        {
            JsonResult jsonResult = base.Json(this.airportRepository.GetFlightList(airlineId, dateTime));
            return jsonResult;
        }

        public ActionResult Index()
        {
            return base.View(this.airportRepository.GetAll());
        }

        private void Init(byte countryId, short stateId)
        {
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            if ((countryId != 0 ? true : stateId != 0))
            {
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(countryId);
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(stateId);
                ((dynamic)base.ViewBag).AlternateCityList = this.cityRepository.GetCityListByStateId(stateId);
            }
            else
            {
                ((dynamic)base.ViewBag).StateList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).CityList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).AlternateCityList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        public ActionResult Insert(byte? airportId, byte? companyId)
        {
            int? nullable;
            int? nullable1;
            MasterAirport masterAirport = new MasterAirport();
            byte? nullable2 = airportId;
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
                masterAirport = this.airportRepository.GetDetailById(airportId.Value, companyId.Value);
            }
            masterAirport.CompanyId = SessionUtility.CompanyId;
            this.Init(masterAirport.CountryId, masterAirport.StateId);
            return base.View(masterAirport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("AirportId")]
        public ActionResult Insert(MasterAirport objMasterAirport)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterAirport);
            }
            else
            {
                byte num = 0;
                if (objMasterAirport.AirportId <= 0)
                {
                    objMasterAirport.EntryBy = SessionUtility.LoginUserId;
                    num = this.airportRepository.Insert(objMasterAirport);
                }
                else
                {
                    objMasterAirport.UpdateBy = new short?(SessionUtility.LoginUserId);
                    num = this.airportRepository.Update(objMasterAirport);
                }
                action = base.RedirectToAction("View", new { airportId = num, companyId = objMasterAirport.CompanyId });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("AirportId")]
        public JsonResult IsAirportNameAvailable(MasterAirport objMasterAirport)
        {
            JsonResult jsonResult = base.Json(this.airportRepository.IsAirportNameAvailable(objMasterAirport.AirportName, objMasterAirport.AirportId));
            return jsonResult;
        }

        [HttpPost]
        [ValidateAntiModelInjection("AirportId")]
        public JsonResult IsAirportNoAvailable(MasterAirport objMasterAirport)
        {
            JsonResult jsonResult = base.Json(this.airportRepository.IsAirportNoAvailable(objMasterAirport.AirportNo, objMasterAirport.AirportId));
            return jsonResult;
        }

        public ActionResult View(byte airportId, byte companyId)
        {
            ActionResult actionResult = base.View(this.airportRepository.GetDetailById(airportId, companyId));
            return actionResult;
        }


    }
}
