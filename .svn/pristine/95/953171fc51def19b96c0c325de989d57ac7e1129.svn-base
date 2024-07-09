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
  public class CityController : Controller
  {
    private readonly ICityRepository cityRepository;
    private readonly ICountryRepository countryRepository;
    private readonly IStateRepository stateRepository;
    private readonly IZoneRepository zoneRepository;

    public CityController()
    {
    }

    public CityController(
      ICityRepository _cityRepository,
      ICountryRepository _countryRepository,
      IStateRepository _stateRepository,
      IZoneRepository _zoneRepository)
    {
      this.cityRepository = _cityRepository;
      this.countryRepository = _countryRepository;
      this.stateRepository = _stateRepository;
      this.zoneRepository = _zoneRepository;
    }

    public ActionResult Index()
    {
        ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
        return (ActionResult) this.View((object) this.cityRepository.GetAll("","","N"));
    }

    [HttpPost]
    public ActionResult Index(string StateId, string CityName)
    {
        ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
        return (ActionResult)this.View((object)this.cityRepository.GetAll(StateId, CityName, "Y"));
    }


        public ActionResult Insert()
        {
            MasterCity masterCity = new MasterCity();
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).ZoneList = this.zoneRepository.GetZoneList();
            return base.View(masterCity);
        }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("CityId")]
    public ActionResult Insert(MasterCity objMasterCity)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCity);
      objMasterCity.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.cityRepository.Insert(objMasterCity)
      });
    }


        public ActionResult Update(long? id)
        {
            ActionResult httpStatusCodeResult;
            long? nullable;
            long? nullable1;
            long? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new long?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
                ((dynamic)base.ViewBag).ZoneList = this.zoneRepository.GetZoneList();
                httpStatusCodeResult = base.View(this.cityRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


        [ValidateAntiModelInjection("CityId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterCity objMasterCity)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCity);
      objMasterCity.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.cityRepository.Update(objMasterCity)
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.cityRepository.GetById(id.Value));
    }

    [ValidateAntiModelInjection("CityId")]
    [HttpPost]
    public JsonResult IsCityNameAvailable(MasterCity objMasterCity)
    {
      return this.Json((object) this.cityRepository.IsCityNameAvailable(objMasterCity.CityName, objMasterCity.CityId));
    }

    [HttpPost]
    public JsonResult GetAutoCompleteCityList(string cityName)
    {
      return this.Json((object) this.cityRepository.GetAutoCompleteCityList(cityName));
    }

    [HttpPost]
    public JsonResult IsCityNameExist(string cityName)
    {
      return this.Json((object) this.cityRepository.IsCityNameExist(cityName));
    }

    [HttpPost]
    public JsonResult GetCityListByStateId(short stateId)
    {
      return this.Json((object) this.cityRepository.GetCityListByStateId(stateId));
    }

    [HttpPost]
    public JsonResult GetCityListByLocationId(short locationId)
    {
      return this.Json((object) this.cityRepository.GetCityListByLocationId(locationId));
    }

    [HttpPost]
    public JsonResult GetAutoCompleteCityNameListByStateId(short stateId, string cityName)
    {
      return this.Json((object) this.cityRepository.GetAutoCompleteCityNameListByStateId(stateId, cityName));
    }

    [HttpPost]
    public JsonResult GetCityByLocationId(short locationId)
    {
      return this.Json((object) this.cityRepository.GetCityByLocationId(locationId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.cityRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
