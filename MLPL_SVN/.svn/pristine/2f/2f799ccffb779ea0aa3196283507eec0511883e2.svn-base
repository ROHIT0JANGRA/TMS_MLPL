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
  public class LocationController : Controller
  {
    private readonly ILocationRepository locationRepository;
    private readonly ILocationHierarchyRepository locationHierarchyRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly ICountryRepository countryrepository;
    private readonly IStateRepository stateRepository;
    private readonly ICityRepository cityRepository;

        public LocationController()
        {

        }
        public LocationController(ILocationRepository _locationRepository, ILocationHierarchyRepository _locationHierarchyRepository, GeneralRepository _generalRepository, ICountryRepository _countryRepository, IStateRepository _stateRepository, ICityRepository _cityRepository)
        {
            this.locationRepository = _locationRepository;
            this.locationHierarchyRepository = _locationHierarchyRepository;
            this.generalRepository = _generalRepository;
            this.countryrepository = _countryRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
        }

        public JsonResult CheckValidLoginLocation(short locationId)
        {
            return base.Json(locationId == SessionUtility.LoginLocationId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.locationRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetAutoCompleteLocationList(string locationCode)
        {
            return base.Json(this.locationRepository.GetAutoCompleteLocationList(locationCode));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteLocationListDocketENtry(string locationCode)
        {
            return base.Json(this.locationRepository.GetAutoCompleteLocationListDocketENtry(locationCode));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteLocationListDocketEntryByDeliveryLocation(string locationCode,short customerId)
        {
            return base.Json(this.locationRepository.GetAutoCompleteLocationListDocketEntryByDeliveryLocation(locationCode, customerId));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteLocationAllList(string locationCode)
        {
            return base.Json(this.locationRepository.GetAutoCompleteLocationList(locationCode,"ALL"));
        }

        [HttpPost]
        public JsonResult GetByLocationHierarchy(byte locationHierarchy)
        {
            return base.Json(this.locationRepository.GetByLocationHierarchy(locationHierarchy));
        }

        [HttpPost]
        public JsonResult GetLocationByHierarchyId(bool isRegion)
        {
            return base.Json(this.locationRepository.GetLocationByHierarchyId(isRegion));
        }

        [HttpPost]
        public JsonResult GetLocationListByLocationId(short locationId)
        {
            JsonResult jsonResult = base.Json(this.locationRepository.GetLocationListByLocationId(locationId, SessionUtility.LoginUserLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLocationListByStateId(short stateId)
        {
            return base.Json(this.locationRepository.GetLocationListByStateId(stateId));
        }

        public JsonResult GetLocationListByZoneId(short zoneId)
        {
            return base.Json(this.locationRepository.GetLocationListByZoneId(zoneId));
        }

        public ActionResult Index()
        {
            return base.View(this.locationRepository.GetAll());
        }

        private void Init(bool isCreateGet, byte locationHierarchyId, byte countryId, short stateId, int cityId)
        {
            if (!isCreateGet)
            {
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(countryId);
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(stateId);
                ((dynamic)base.ViewBag).LocationList = new SelectList(this.locationRepository.GetByLocationHierarchy(locationHierarchyId), "Value", "Name");
            }
            else
            {
                ((dynamic)base.ViewBag).StateList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).CityList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).PincodeList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            ((dynamic)base.ViewBag).CountryList = this.countryrepository.GetCountryList();
            ((dynamic)base.ViewBag).LocationHierarchyList = this.generalRepository.GetByIdList(3);
            ((dynamic)base.ViewBag).ReportLocationHierarchyList = this.generalRepository.GetByIdList(4);
            ((dynamic)base.ViewBag).OwnershipTypeList = this.generalRepository.GetByIdList(5);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).LocationTypeList = this.generalRepository.GetByIdList(87);
            ((dynamic)base.ViewBag).OwnershipLocationList = this.locationRepository.GetLocationList("1");
        }

        public ActionResult Insert()
        {
            MasterLocation masterLocation = new MasterLocation();
            ((dynamic)base.ViewBag).LocationHierarchyList = this.generalRepository.GetByIdList(4);
            ((dynamic)base.ViewBag).LocationTypeList = this.generalRepository.GetByIdList(87);
            ((dynamic)base.ViewBag).CountryList = this.countryrepository.GetCountryList();
            ((dynamic)base.ViewBag).ReportLocationHierarchyList = this.generalRepository.GetByIdList(4);
            ((dynamic)base.ViewBag).OwnershipTypeList = this.generalRepository.GetByIdList(5);
            ((dynamic)base.ViewBag).StateList = new SelectList(Enumerable.Empty<SelectListItem>());
            ((dynamic)base.ViewBag).CityList = new SelectList(Enumerable.Empty<SelectListItem>());
            ((dynamic)base.ViewBag).ReportLocationHierarchyList = new SelectList(Enumerable.Empty<SelectListItem>());

            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).OwnershipLocationList = this.locationRepository.GetLocationList("1");

            masterLocation.IsActive = true;
            return base.View(masterLocation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("LocationId")]
        public ActionResult Insert(MasterLocation objMasterLocation)
        {
            ActionResult action;
            //if (!base.ModelState.IsValid)
            //{
            //    ((dynamic)base.ViewBag).LocationHierarchyList = this.locationHierarchyRepository.GetLocationHierarchyList();
            //    ((dynamic)base.ViewBag).LocationTypeList = this.generalRepository.GetByIdList(87);
            //    action = base.View(objMasterLocation);
            //}
            //else
            //{
            //    objMasterLocation.EntryBy = SessionUtility.LoginUserId;
            //    objMasterLocation.WarehouseId = SessionUtility.WarehouseId;
            //    byte num = this.locationRepository.Insert(objMasterLocation);
            //    action = base.RedirectToAction("View", new { id = num });
            //}

            objMasterLocation.EntryBy = SessionUtility.LoginUserId;
            objMasterLocation.WarehouseId = SessionUtility.WarehouseId;
            short num = this.locationRepository.Insert(objMasterLocation);
            action = base.RedirectToAction("View", new { id = num });

            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("LocationId")]
        public JsonResult IsLocationCodeAvailable(MasterLocation objMasterLocation)
        {
            JsonResult jsonResult = base.Json(this.locationRepository.IsLocationCodeAvailable(objMasterLocation.LocationCode, objMasterLocation.LocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsLocationCodeExist(string locationCode)
        {
            return base.Json(this.locationRepository.IsLocationCodeExist(locationCode));
        }

        [HttpPost]
        public JsonResult IsLocationCodeExistOwnership(string locationCode)
        {
            return base.Json(this.locationRepository.IsLocationCodeExistOwnership(locationCode));
        }

        public ActionResult Update(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            short? nullable2 = id;
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
                MasterLocation byId = this.locationRepository.GetById((short)id.Value);
                if (byId != null)
                {

                    byId.StateNameId = byId.StateId;
                    byId.CountryNameId = byId.CountryId;
                    byId.DataEntryLocation = byId.SavedDataEntryLocation;
                    byId.LocationHierarchyReportingToId = Convert.ToByte(byId.ReportLocationHierarchy);

                    ((dynamic)base.ViewBag).LocationHierarchyList = this.locationHierarchyRepository.GetLocationHierarchyList();
                    ((dynamic)base.ViewBag).LocationTypeList = this.generalRepository.GetByIdList(87);
                    ((dynamic)base.ViewBag).CountryList = this.countryrepository.GetCountryList();
                    ((dynamic)base.ViewBag).LocationHierarchyList = this.generalRepository.GetByIdList(3);
                    ((dynamic)base.ViewBag).ReportLocationHierarchyList = this.locationRepository.GetByLocationHierarchy(byId.LocationHierarchyReportingToId); //this.generalRepository.GetByIdList(4);
                    ((dynamic)base.ViewBag).OwnershipTypeList = this.generalRepository.GetByIdList(5);
                    ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
                    ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(Convert.ToByte(byId.CountryId));
                    ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(Convert.ToByte(byId.StateId));
                    ((dynamic)base.ViewBag).OwnershipLocationList = this.locationRepository.GetLocationList("1");

                    httpStatusCodeResult = base.View(byId);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("LocationId")]
        public ActionResult Update(MasterLocation objMasterLocation)
        {
            ActionResult action;
            //if (!base.ModelState.IsValid)
            //{
            //    ((dynamic)base.ViewBag).LocationHierarchyList = this.locationHierarchyRepository.GetLocationHierarchyList();
            //    ((dynamic)base.ViewBag).LocationTypeList = this.generalRepository.GetByIdList(87);
            //    action = base.View(objMasterLocation);
            //}
            //else
            //{
            //    objMasterLocation.UpdateBy = new short?(SessionUtility.LoginUserId);
            //    objMasterLocation.WarehouseId = SessionUtility.WarehouseId;
            //    byte num = this.locationRepository.Update(objMasterLocation);
            //    action = base.RedirectToAction("View", new { id = num });
            //}

            objMasterLocation.UpdateBy = new short?(SessionUtility.LoginUserId);
            objMasterLocation.WarehouseId = SessionUtility.WarehouseId;
            short num = this.locationRepository.Update(objMasterLocation);
            action = base.RedirectToAction("View", new { id = num });

            return action;
        }

        public ActionResult View(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            short? nullable2 = id;
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
                httpStatusCodeResult = base.View(this.locationRepository.GetById((short)id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }
        [HttpPost]
        public JsonResult CheckDeliveryLocationByBillingParty(short locationId, short customerId)
        {
            JsonResult jsonResult = base.Json(this.locationRepository.CheckDeliveryLocationByBillingParty(locationId, customerId));
            return jsonResult;
        }
    }
}
