using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class CustomerAddressController : Controller
  {
    private readonly ICustomerAddressRepository customerAddressRepository;
    private readonly ICountryRepository countryRepository;
    private readonly ICustomerRepository customerRepository;
    private readonly IStateRepository stateRepository;
    private readonly ICityRepository cityRepository;

        public CustomerAddressController()
        {
        }

        public CustomerAddressController(ICustomerAddressRepository _customerAddressRepository, ICountryRepository _countryRepository, ICustomerRepository _customerRepository, IStateRepository _stateRepository, ICityRepository _cityRepository)
        {
            this.customerAddressRepository = _customerAddressRepository;
            this.countryRepository = _countryRepository;
            this.customerRepository = _customerRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
        }

        //[HttpPost]
        public JsonResult CheckValidAddressCodeByCustomerId(short customerId, string addressCode)
        {
            JsonResult jsonResult = base.Json(this.customerAddressRepository.CheckValidAddressCodeByCustomerId(customerId, addressCode));
            return jsonResult;
        }

        public JsonResult GetAutoCompleteListByCustomerId(short customerId, string addressCode)
        {
            JsonResult jsonResult = base.Json(this.customerAddressRepository.GetAutoCompleteListByCustomerId(customerId, addressCode));
            return jsonResult;
        }

        public JsonResult GetMappingByCustomerIdCityId(short customerId, int cityId)
        {
            JsonResult jsonResult = base.Json(this.customerAddressRepository.GetMappingByCustomerIdCityId(customerId, cityId));
            return jsonResult;
        }

        public JsonResult GetCustomerAddressList(short customerId)
        {
            return this.Json((object)this.customerAddressRepository.GetCustomerAddressList(customerId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerAddressById(short addressId)
        {
            JsonResult jsonResult = base.Json(this.customerAddressRepository.GetCustomerAddressById(addressId));
            return jsonResult;
        }

        public ActionResult Index()
        {
            return base.View(this.customerAddressRepository.GetAll());
        }

        public ActionResult Mapping(short? id, int? cityId)
        {
            int? nullable;
            int? nullable1;
            int? nullable2;
            MasterCustomerAddressMapping masterCustomerAddressMapping = new MasterCustomerAddressMapping();
            int? nullable3 = id;
            if (nullable3.HasValue)
            {
                nullable1 = new int?(nullable3.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                masterCustomerAddressMapping.CustomerId = id.Value;
            }
            nullable3 = cityId;
            if (nullable3.HasValue)
            {
                nullable2 = new int?(nullable3.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable2 = nullable;
            }
            nullable = nullable2;
            if (nullable.HasValue)
            {
                masterCustomerAddressMapping.CityId = (int)cityId.Value;
            }
            if (masterCustomerAddressMapping.CityId <= 0)
            {
                ((dynamic)base.ViewBag).StateList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).CityList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            else
            {
                MasterCity byId = this.cityRepository.GetById(masterCustomerAddressMapping.CityId);
                masterCustomerAddressMapping.CountryId = byId.CountryId;
                masterCustomerAddressMapping.StateId = byId.StateId;
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(masterCustomerAddressMapping.CountryId);
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(masterCustomerAddressMapping.StateId);
            }
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerList();
            return base.View(masterCustomerAddressMapping);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mapping(MasterCustomerAddressMapping objMasterCustomerAddressMapping)
        {
            ActionResult action;
            if ((!base.ModelState.IsValid || objMasterCustomerAddressMapping.CountryId <= 0 || objMasterCustomerAddressMapping.StateId <= 0 || objMasterCustomerAddressMapping.CityId <= 0 ? false : objMasterCustomerAddressMapping.CustomerId > 0))
            {
                objMasterCustomerAddressMapping.AddressList.RemoveAll((MasterCustomerAddressMapping m) => !m.IsActive);
                objMasterCustomerAddressMapping.AddressList.ForEach((MasterCustomerAddressMapping m) => {
                    m.CustomerId = objMasterCustomerAddressMapping.CustomerId;
                    m.EntryBy = SessionUtility.LoginUserId;
                });
                if (this.customerAddressRepository.AddressMapping(objMasterCustomerAddressMapping).IsSuccessfull)
                {
                    action = base.RedirectToAction("Index");
                    return action;
                }
            }
            action = base.View(objMasterCustomerAddressMapping);
            return action;
        }



    }
}
