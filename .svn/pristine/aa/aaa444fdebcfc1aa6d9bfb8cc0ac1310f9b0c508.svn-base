using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class veichleservicelistController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IVendorRepository vendorRepository;
    //private readonly IVeichleServicelistrepositorycs veichleServicelistrepositorycs;

        public veichleservicelistController()
        {
        }

        public veichleservicelistController(IVehicleRepository _vehicleRepository, IVehicleTypeRepository _vehicleTypeRepository, IGeneralRepository _generalRepository, ILocationRepository _locationRepository, IVendorRepository _vendorRepository/*, IVeichleServicelistrepositorycs _veichleServicelistrepositorycs*/)
        {
            this.vehicleRepository = _vehicleRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.vendorRepository = _vendorRepository;
        //this.veichleServicelistrepositorycs = _veichleServicelistrepositorycs;
        }

        // GET: Master/veichleservicelist
        public ActionResult Index()
        {
            return base.View(this.vehicleRepository.GetAllDataVehicleServiceKM());
        }
        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetCompanyVehicleList(2);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
         
            List<SelectListItem> ObjServiceTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Accident", Value = "1" },
                new SelectListItem { Text = "Break Down", Value = "2" },
                new SelectListItem { Text = "Fitness Certificate Renewal", Value = "3" },
                new SelectListItem { Text = "Preventive Maintenance", Value = "4" },
                new SelectListItem { Text = "Running Repair", Value = "5" },
                new SelectListItem { Text = "Schedule Maintenance", Value = "6" },
                new SelectListItem { Text = "Other", Value = "7" },

            };
                
            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).ServiceTypeList = ObjServiceTypeList;

            List<SelectListItem> ObjServiceCenterTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Workshop ", Value = "1" },
                new SelectListItem { Text = "Vendor ", Value = "2" },
            
            };

            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).ServiceCenterTypeList = ObjServiceCenterTypeList;


            List<SelectListItem> ObjAMCTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "AMC ", Value = "1" },
                new SelectListItem { Text = "Non AMC ", Value = "2" },

            };

            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).AMCTypeList = ObjAMCTypeList;


            //((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            return base.View(new MasterServiceVehicle());
        }

        public JsonResult IsVehicleAvailable(short VehicleId)
        {
            return this.Json((object)this.vehicleRepository.IsVehicleAvailable(VehicleId));
        }
        public ActionResult Update(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;

            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetCompanyVehicleList(2);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);

            List<SelectListItem> ObjServiceTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Accident", Value = "1" },
                new SelectListItem { Text = "Break Down", Value = "2" },
                new SelectListItem { Text = "Fitness Certificate Renewal", Value = "3" },
                new SelectListItem { Text = "Preventive Maintenance", Value = "4" },
                new SelectListItem { Text = "Running Repair", Value = "5" },
                new SelectListItem { Text = "Schedule Maintenance", Value = "6" },
                new SelectListItem { Text = "Other", Value = "7" },

            };
            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).ServiceTypeList = ObjServiceTypeList;

            List<SelectListItem> ObjServiceCenterTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Workshop ", Value = "1" },
                new SelectListItem { Text = "Vendor ", Value = "2" },

            };

            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).ServiceCenterTypeList = ObjServiceCenterTypeList;
            List<SelectListItem> ObjAMCTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "AMC ", Value = "1" },
                new SelectListItem { Text = "Non AMC ", Value = "2" },

            };

            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).AMCTypeList = ObjAMCTypeList;
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
                MasterServiceVehicle detailById = this.vehicleRepository.GetKmMappingByMappingId(id.Value);
                if (detailById != null)
                {
                    // this.Init();
                    httpStatusCodeResult = base.View(detailById);
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
        public ActionResult Update(MasterServiceVehicle objMasterVehicle)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterVehicle);
            }
            else
            {
                short num = 0;
                if (!base.ModelState.IsValid)
                {
                    action = base.View(objMasterVehicle);
                }
                else
                {
                    objMasterVehicle.TripsheetNo = "0";
                    objMasterVehicle.DriverName = "Aditya";
                    objMasterVehicle.VehicleRoute = "DEL";
                    objMasterVehicle.TSStatus = "Test";
                    objMasterVehicle.IsActive = true;


                    num = this.vehicleRepository.UpdateKmMapping(objMasterVehicle);

                }
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return base.RedirectToAction("Index", new { id = num });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Insert(MasterServiceVehicle objMasterVehicle)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {

                ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleList();
                ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
                ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
                ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
                ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            }
            List<SelectListItem> ObjServiceTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Accident", Value = "1" },
                new SelectListItem { Text = "Break Down", Value = "2" },
                new SelectListItem { Text = "Fitness Certificate Renewal", Value = "3" },
                new SelectListItem { Text = "Preventive Maintenance", Value = "4" },
                new SelectListItem { Text = "Running Repair", Value = "5" },
                new SelectListItem { Text = "Schedule Maintenance", Value = "6" },
                new SelectListItem { Text = "Other", Value = "7" },
            };
            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).ServiceTypeList = ObjServiceTypeList;
            List<SelectListItem> ObjServiceCenterTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Workshop ", Value = "1" },
                new SelectListItem { Text = "Vendor ", Value = "2" },

            };
            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).ServiceCenterTypeList = ObjServiceCenterTypeList;


            List<SelectListItem> ObjAMCTypeList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "AMC ", Value = "1" },
                new SelectListItem { Text = "Non AMC ", Value = "2" },

            };

            //Assigning generic list to ViewBag
            ((dynamic)base.ViewBag).AMCTypeList = ObjAMCTypeList;
            short num = 0;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterVehicle);
            }
            else
            {
                objMasterVehicle.TripsheetNo = "0";
                objMasterVehicle.DriverName = "Aditya";
                objMasterVehicle.VehicleRoute = "DEL";
                objMasterVehicle.TSStatus = "Test";
                objMasterVehicle.IsActive = true;

                num = this.vehicleRepository.InsertKmMapping(objMasterVehicle);

            }
            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return base.RedirectToAction("Index", new { id = num });

        }




        //public ActionResult demo()
        //{
        //    this.veichleServicelistrepositorycs.GetAll1();
        //    return base.View("demo");

        //}


    }
}