using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System.Web;
using System.Runtime.CompilerServices;
using System.Net;
using System.Web.Mvc;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using CodeLock.Areas.Master.Repository;
using Newtonsoft.Json;

namespace CodeLock.Areas.Operation.Controllers
{
    public class CustomerPanelController : Controller
    {
        private readonly ICustomerPanelRepository customerPanelRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly ICityRepository cityRepository;
        private readonly IGeneralRepository generalRepository;

        public CustomerPanelController()
        {

        }

        public CustomerPanelController(ICustomerPanelRepository _customerPanelRepository, IWarehouseRepository _warehouseRepository, ICityRepository _cityRepository,IGeneralRepository _generalRepository)
        {
            this.customerPanelRepository = _customerPanelRepository;
            this.warehouseRepository = _warehouseRepository;
            this.cityRepository = _cityRepository;
            this.generalRepository = _generalRepository;
        }

        // GET: Operation/CustomerPanel
        public ActionResult Index()
        {
            
             return View();
        }

        public ActionResult CustomerPickup()
        {
            CustomerPickup objCustomerPickup = new CustomerPickup();
            objCustomerPickup.CustomerPickupDetails.Add(new CustomerPickupDetail());
            objCustomerPickup.InvoiceDetails.Add(new CustomerPickupInvoiceDetail());
            ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetMappedWarehouseListByLocation(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();
            ((dynamic)base.ViewBag).ModeTypeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BrandList = this.generalRepository.GetByIdList(100);
            ((dynamic)base.ViewBag).GenderList = this.generalRepository.GetByIdList(101);
            ((dynamic)base.ViewBag).ArticalList = this.generalRepository.GetByIdList(102);

            ((dynamic)base.ViewBag).Brands = this.generalRepository.GetByIdList(100);
            dynamic viewBag = base.ViewBag;
            viewBag.BrandLists = JsonConvert.SerializeObject(((dynamic)base.ViewBag).Brands);

            ((dynamic)base.ViewBag).Gender = this.generalRepository.GetByIdList(101);
            dynamic viewBag1 = base.ViewBag;
            viewBag1.GenderLists = JsonConvert.SerializeObject(((dynamic)base.ViewBag).Gender);

            ((dynamic)base.ViewBag).Articals = this.generalRepository.GetByIdList(102);
            dynamic viewBag2 = base.ViewBag;
            viewBag2.ArticalLists = JsonConvert.SerializeObject(((dynamic)base.ViewBag).Articals);

            return base.View(objCustomerPickup);
        }
        
    }
}