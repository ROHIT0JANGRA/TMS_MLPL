using CodeLock.Api_Services;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class VehicleController : Controller
  {
    private readonly IVehicleRepository vehicleRepository;
    private readonly IVehicleTypeRepository vehicleTypeRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly ILocationRepository locationRepository;
    private readonly IVendorRepository vendorRepository;

        public VehicleController()
        {
        }

        public VehicleController(IVehicleRepository _vehicleRepository, IVehicleTypeRepository _vehicleTypeRepository, IGeneralRepository _generalRepository, ILocationRepository _locationRepository, IVendorRepository _vendorRepository)
        {
            this.vehicleRepository = _vehicleRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.vendorRepository = _vendorRepository;
        }

        [HttpPost]
        public JsonResult GetAutoCompleteVehicleForMaintanance(string vehicleNo)
        {
            return base.Json(this.vehicleRepository.GetAutoCompleteVehicleForMaintanance(vehicleNo));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteVehicleListForStatus(string vehicleNo)
        {
            return base.Json(this.vehicleRepository.GetAutoCompleteVehicleListForStatus(vehicleNo, SessionUtility.LoginUserId));
        }




        [HttpPost]
        public JsonResult CheckValidVehicleNoForJobOrder(string vehicleNo, short locationId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.CheckValidVehicleNoForJobOrder(vehicleNo, locationId));
            return jsonResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.vehicleRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetAutoCompleteListForJobOrder(string vehicleNo, string locationId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetAutoCompleteListForJobOrder(vehicleNo, locationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAutoCompleteVehicleList(string vehicleNo)
        {
            return base.Json(this.vehicleRepository.GetAutoCompleteVehicleList(vehicleNo));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteVehicleListByLocation(string vehicleNo, string locationId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetAutoCompleteVehicleListByLocation(vehicleNo, locationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAutoCompleteVehicleListByLocationForTripsheet(string vehicleNo, string locationId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetAutoCompleteVehicleListByLocationForTripsheet(vehicleNo, locationId));
            return jsonResult;
        }

        [HttpPost]
        
        public JsonResult GetAutoCompleteVehicleListByForTripsheetCloser(string TripsheetNo, string TripsheetAction, string searchBy,string locationId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetAutoCompleteVehicleListByForTripsheetCloser(TripsheetNo, TripsheetAction, searchBy, locationId));
            return jsonResult;
        }
        public JsonResult GetById(short id)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetById(id), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetStartKm(short vehicleId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetStartKm(vehicleId));
            return jsonResult;
        }

        public JsonResult GetStartKmByVehicleId(short vehicleId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetStartKmByVehicleId(vehicleId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetTripsheetByVehicleId(short vehicleId,DateTime documentDateTime)
        {
            return base.Json(this.vehicleRepository.GetTripsheetByVehicleId(vehicleId, documentDateTime));
        }

        public JsonResult GetVehicleByFtlTypeId(byte ftlTypeId)
        {
            return base.Json(this.vehicleRepository.GetVehicleByFtlTypeId(ftlTypeId));
        }

        public JsonResult GetVehicleByVendorIdFtlTypeId(byte ftlTypeId, short vendorId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetVehicleByVendorIdFtlTypeId(ftlTypeId, vendorId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVehicleListByCardType(bool isFuelCard)
        {
            return base.Json(this.vehicleRepository.GetVehicleListByCardType(isFuelCard));
        }

        [HttpPost]
        public JsonResult GetVehicleListByVendorId(short vendorId)
        {
            return base.Json(this.vehicleRepository.GetVehicleListByVendorId(vendorId));
        }

        [HttpPost]
        public JsonResult GetVehicleListByVendorTypeByLocation(string vehicleNo, byte vendorTypeId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.GetVehicleListByVendorTypeByLocation(vehicleNo, vendorTypeId, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        //public ActionResult Index()
        //{
        //    return base.View(this.vehicleRepository.GetAll());
        //}

        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(new MasterVehicle());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("VehicleId")]
        public ActionResult Insert(MasterVehicle objMasterVehicle)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterVehicle);
            }
            else
            {
                objMasterVehicle.MasterVehicleDetail.EntryBy = SessionUtility.LoginUserId;
                short num = this.vehicleRepository.Insert(objMasterVehicle);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        public async Task<dynamic> FetchVehicleDetailsFromApi(string vehicleno)
        {
            string token = UlipTokenManagerController.GetTokenId();
            if (string.IsNullOrEmpty(token))
            {
                token = await UlipTokenManagerController.GenerateToken();
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var requestBody = new { vehiclenumber = vehicleno };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://www.ulip.dpiit.gov.in/ulip/v1.0.0/v1.0.0/VAHAN/01", content);
                var statusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return Json(responseData);
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    token = await UlipTokenManagerController.GenerateToken();
                    var responseData = new
                    {
                        code = statusCode,
                        error = false,
                        message = "Status Code 403 : Forbidden error (Please try again later)."
                    };
                    var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(responseData);
                    return jsonResponse;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var responseData = new
                    {
                        code = statusCode,
                        error = false,
                        Message = "Status Code 401 : Unauthorized login (Please check your credentials).",
                    };
                    var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(responseData);
                    return jsonResponse;
                }
            }

            return null;
        }

        [HttpPost]
        [ValidateAntiModelInjection("VehicleId")]
        public JsonResult IsVehicleNoAvailable(MasterVehicle objMasterVehicle)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.IsVehicleNoAvailable(objMasterVehicle.VehicleNo, objMasterVehicle.VehicleId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsVehicleNoExist(string vehicleNo)
        {
            return base.Json(this.vehicleRepository.IsVehicleNoExist(vehicleNo));
        }

        [HttpPost]
        public JsonResult IsVehicleNoExistByLocation(string vehicleNo, short locationId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.IsVehicleNoExistByLocation(vehicleNo, locationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsVehicleNoExistByVendorTypeByLocation(string vehicleNo, byte vendorTypeId)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.IsVehicleNoExistByVendorTypeByLocation(vehicleNo, vendorTypeId, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsVehicleNoExistForTripsheet(string vehicleNo)
        {
            JsonResult jsonResult = base.Json(this.vehicleRepository.IsVehicleNoExistForTripsheet(vehicleNo, SessionUtility.LoginLocationId));
            return jsonResult;
        }
        public ActionResult Update(short? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehicle = this.vehicleRepository.GetById(id.Value);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).VendorNameList = this.vendorRepository.GetVendorNameList();
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
                httpStatusCodeResult = base.View(this.vehicleRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("VehicleId")]
        public ActionResult Update(MasterVehicle objMasterVehicle)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterVehicle);
            }
            else
            {
                objMasterVehicle.MasterVehicleDetail.UpdateBy = new short?(SessionUtility.LoginUserId);
                short num = this.vehicleRepository.Update(objMasterVehicle);
                action = base.RedirectToAction("View", new { id = num });
            }
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).VendorNameList = this.vendorRepository.GetVendorNameList();
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
                httpStatusCodeResult = base.View(this.vehicleRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        public ActionResult Index()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult GetVehiclesByPaginations(Pagination pagination)
      {
            DTResponse DTResponse = new DTResponse();
            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ? "VM.VehicleId ASC" : pagination.data.columns[pagination.data.order[0].column].name + " " +pagination.data.order[0].dir;
            var Vehicles = this.vehicleRepository.GetVehiclesByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value);
            DTResponse.recordsTotal = Vehicles.FirstOrDefault() == null ? 0 : Vehicles.FirstOrDefault().TotalVehicle;
            DTResponse.recordsFiltered = Vehicles.FirstOrDefault() == null ? 0 : Vehicles.FirstOrDefault().FilterVehcile; //pagination.data.search.value == null? customers.FirstOrDefault().TotalCustomers : customers.Count();
            DTResponse.data = JsonConvert.SerializeObject(Vehicles);
            return Json(DTResponse, JsonRequestBehavior.AllowGet); 
        }

    }
}
