using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class PincodeController : Controller
  {
    private readonly IPincodeRepository pincodeRepository;
    private readonly ICountryRepository countryRepository;
    private readonly ILocationRepository locationRepository;
    private readonly IStateRepository stateRepository;
    private readonly ICityRepository cityRepository;

        public PincodeController()
        {
        }

        public PincodeController(IPincodeRepository _pincodeRepository, ICountryRepository _countryRepository, ILocationRepository _locationRepository, IStateRepository _stateRepository, ICityRepository _cityRepository)
        {
            this.pincodeRepository = _pincodeRepository;
            this.countryRepository = _countryRepository;
            this.locationRepository = _locationRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
        }

        public ActionResult Index()
        {
            return base.View(this.pincodeRepository.GetAll());
        }

        private void Init(byte countryId, short stateId)
        {
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(countryId);
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(stateId);
            if ((countryId != 0 ? true : stateId != 0))
            {
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(countryId);
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(stateId);
            }
            else
            {
                ((dynamic)base.ViewBag).StateList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).CityList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        public ActionResult Insert(byte? id)
        {
            int? nullable;
            int? nullable1;
            CityPincodeMapping cityPincodeMapping = new CityPincodeMapping();
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
                MasterCity byId = (new CityRepository()).GetById((short)id.Value);
                cityPincodeMapping.CityId = byId.CityId;
                cityPincodeMapping.StateId = byId.StateId;
                cityPincodeMapping.CountryId = byId.CountryId;
            }
            this.Init(cityPincodeMapping.CountryId, cityPincodeMapping.StateId);
            return base.View(new MasterPincode());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("PincodeId")]
        public ActionResult Insert(MasterPincode objMasterPincode)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                this.Init(objMasterPincode.CountryId, objMasterPincode.StateId);
                action = base.View(objMasterPincode);
            }
            else
            {
                objMasterPincode.EntryBy = SessionUtility.LoginUserId;
                byte num = this.pincodeRepository.Insert(objMasterPincode);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        [HttpPost]
        public JsonResult IsPincodeExist(string Pincode)
        {
            return base.Json(this.pincodeRepository.IsPincodeExist(Pincode));
        }

        [HttpPost]
        public JsonResult GetAutoCompletePincodeList(string Pincode)
        {
            return base.Json(this.pincodeRepository.GetAutoCompletePincodeList(Pincode));
        }


        [HttpPost]
        [ValidateAntiModelInjection("PincodeId")]
        public JsonResult IsPincodeAvailable(MasterPincode objMasterPincode)
        {
            JsonResult jsonResult = base.Json(this.pincodeRepository.IsPincodeAvailable(objMasterPincode.Pincode, objMasterPincode.PincodeId));
            return jsonResult;
        }

        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            MasterPincode masterPincode = new MasterPincode();
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
                masterPincode = this.pincodeRepository.GetById(id.Value);
                this.Init(masterPincode.CountryId, masterPincode.StateId);
                httpStatusCodeResult = base.View(masterPincode);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("PincodeId")]
        public ActionResult Update(MasterPincode objMasterPincode)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                this.Init(objMasterPincode.CountryId, objMasterPincode.StateId);
                action = base.View(objMasterPincode);
            }
            else
            {
                objMasterPincode.UpdateBy = new short?(SessionUtility.LoginUserId);
                byte num = this.pincodeRepository.Update(objMasterPincode);
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
                httpStatusCodeResult = base.View(this.pincodeRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}
