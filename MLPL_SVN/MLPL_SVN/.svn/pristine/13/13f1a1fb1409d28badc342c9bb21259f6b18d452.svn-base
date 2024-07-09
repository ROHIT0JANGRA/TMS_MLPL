using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ITrackingRepository = CodeLock.Areas.Operation.Repository.ITrackingRepository;

namespace CodeLock.Areas.Operation.Controllers
{
    public class ThcController : Controller
    {
        private readonly IThcRepository thcRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly IAirportRepository airportRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IRouteRepository routeRepository;
        private readonly IVendorRepository vendorRepository;
        private readonly IVendorPaymentRepository vendorPaymentRepository;
        private readonly IDocketRepository docketRepository;
        private readonly IManifestRepository manifestRepository;
        private readonly ITrackingRepository trackingRepository;
        private readonly IRulesRepository rulesRepository;

        public ThcController()
        {
        }

        public ThcController(IThcRepository _thcRepository, IGeneralRepository _generalRepository,
            IVehicleTypeRepository _vehicleTypeRepository,
            AirportRepository _airportRepository,
            ILocationRepository _locationRepository,
            IWarehouseRepository _warehouseRepository,
            IAccountRepository _accountRepository,
            IRouteRepository _routeRepository,
            IDocketRepository _docketRepository, IVendorRepository _vendorRepository,
            IVendorPaymentRepository _vendorPaymentRepository, IManifestRepository _manifestRepository,
            ITrackingRepository _trackingRepository, IRulesRepository _rulesRepository)
        {
            this.thcRepository = _thcRepository;
            this.generalRepository = _generalRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.airportRepository = _airportRepository;
            this.warehouseRepository = _warehouseRepository;
            this.locationRepository = _locationRepository;
            this.accountRepository = _accountRepository;
            this.routeRepository = _routeRepository;
            this.docketRepository = _docketRepository;
            this.vendorRepository = _vendorRepository;
            this.vendorPaymentRepository = _vendorPaymentRepository;
            this.manifestRepository = _manifestRepository;
            this.trackingRepository = _trackingRepository;
            this.rulesRepository = _rulesRepository;
        }


        [HttpPost]
        public ActionResult ChangeVehicleType(Docket obj)
        {
            ActionResult action;

            //
            if (obj.FtlTypeId == null)
            {
                obj.FtlTypeId = 0;
            }



            obj.Tosave = 4;
            obj.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.DocketUpdate(obj);
            action = base.RedirectToAction("UpdateDocketOption", "Thc");
            return action;
        }
        public ActionResult ChangeVehicleType(string DocketId)
        {
            Docket docket = this.docketRepository.DocketGetDetailById(DocketId);
            ((dynamic)base.ViewBag).ServiceTypeList = docket.ServiceTypeList;
            ((dynamic)base.ViewBag).FtlTypeList = docket.FtlTypeList;

            return base.View(docket);
        }


        [HttpPost]
        public ActionResult ChangeDocketAmount(Docket objThc)
        {
            ActionResult action;
            objThc.EntryBy = SessionUtility.LoginUserId;

            if (string.IsNullOrEmpty(objThc.AllowUpdate))
            {
                objThc.AllowUpdate = "";
            }

            if (objThc.AllowUpdate == "")
            {
                this.thcRepository.ChangeDocketAmount(objThc);
            }

            action = base.RedirectToAction("UpdateDocketOption", "Thc");
            return action;
        }
        public ActionResult ChangeDocketAmount(long DocketId)
        {
            Docket obj = new Docket();
            DocketStep6 docketStep6 = this.docketRepository.ChangeDocketList(DocketId.ToString());
            ((dynamic)base.ViewBag).RateTypeList = docketStep6.RateTypeList;

            ((dynamic)base.ViewBag).GstPayerList = docketStep6.ServiceTaxPayerList;
            ((dynamic)base.ViewBag).GstStateList = docketStep6.CustomerGSTList;
            ((dynamic)base.ViewBag).CompanyGstStateList = docketStep6.CompanyGSTList;

            obj = this.docketRepository.GetStep6DetailByIdByChangeAmount(DocketId);

            foreach (var docketStep in docketStep6.DocketEditList)
            {
                obj.CustomerName = docketStep.CustomerName;
                obj.CompanyName = docketStep.CompanyName;
            }

            foreach (var docketStep in docketStep6.ServiceMappingList)
            {
                obj.IsRcm = docketStep.IsRcm;
                obj.GstRate = docketStep.GstRate;
                obj.ServiceType = docketStep.ServiceType;
                obj.ServiceTypeId = docketStep.ServiceTypeId;
                obj.GstSacId = docketStep.SacId;
                obj.GstSacName = docketStep.SacName;
            }

            Docket obj1 = this.docketRepository.DocketGetDetailById(DocketId.ToString());
            obj.DocketNo = obj1.DocketNo;
            obj.DocketDate = obj1.DocketDate;
            obj.FromCity = obj1.FromCity;
            obj.ToCity = obj1.ToCity;
            obj.CustomerCode = obj1.CustomerCode;
            obj.CustomerName = obj1.CustomerName;
            obj.ConsignorCode = obj1.ConsignorCode;
            obj.ConsignorName = obj1.ConsignorName;
            obj.ConsignorAddress1 = obj1.ConsignorAddress1;
            obj.ConsignorCity = obj1.ConsignorCity;
            obj.ConsigneeCode = obj1.ConsigneeCode;
            obj.ConsigneeName = obj1.ConsigneeName;
            obj.ConsigneeAddress1 = obj1.ConsigneeAddress1;
            obj.ConsigneeCity = obj1.ConsigneeCity;
            obj.ChargedWeight = obj1.ChargedWeight;
            obj.Packages = obj1.Packages;
            obj.InvoiceList = obj1.InvoiceList;

            return base.View(obj);
        }


        [HttpPost]
        public ActionResult ChangeTHCAmount(ChangeAdvanceBalanceLocation objThc)
        {
            ActionResult action;
            objThc.EntryBy = SessionUtility.LoginUserId;

            Response response = new Response();
            response = this.vendorPaymentRepository.ChangeAdvanceBalanceLocation(objThc);

            action = base.RedirectToAction("UpdateDocketDumptco", "Thc");
            return action;
        }
        public ActionResult ChangeTHCAmount(string DocumentNo)
        {
            ((dynamic)base.ViewBag).VendorList = this.vendorRepository.GetVendorNameList();
            ChangeAdvanceBalanceLocation changeAdvanceBalanceLocation = new ChangeAdvanceBalanceLocation()
            {
                DocumentNo = DocumentNo.ConvertToString()
            };

            List<ThcAdvBalPaymnt_Details> MultiAdvDtl = new List<ThcAdvBalPaymnt_Details>();
            changeAdvanceBalanceLocation.AdvBalPmtDtl.Add(new ThcAdvBalPaymnt_Details());

            return base.View(changeAdvanceBalanceLocation);
        }


        [HttpPost]
        public ActionResult ChangeWeight(Docket objThc)
        {
            ActionResult action;
            objThc.Tosave = 3;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.DocketUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketOption", "Thc");
            return action;
        }
        public ActionResult ChangeWeight(string DocketId)
        {

            return base.View(this.docketRepository.DocketGetDetailById(DocketId));
        }
        [HttpPost]
        public ActionResult ChangeDimension(Docket objThc)
        {
            ActionResult action;
            objThc.Tosave = 2;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.DocketUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketOption", "Thc");
            return action;
        }
        public ActionResult ChangeDimension(string DocketId)
        {
            //
            ActionResult action;
            if (this.docketRepository.CheckDocketDimension(DocketId) == 0)
            {
                action = base.RedirectToAction("ChangeWeight", "Thc", new { DocketId = DocketId });

                return action;

            }
            else
            {
                return base.View(this.docketRepository.DocketGetDetailById(DocketId));
            }
        }


        [HttpPost]
        public ActionResult ChangeDocketCustomer(Docket objThc)
        {
            ActionResult action;

            if (objThc.CustomerId == 0)
            {
                this.ModelState.AddModelError("CustomerCode", "Customer Code is not valid");
                return View(objThc);
            }
            if (objThc.ConsignorId == 0)
            {
                this.ModelState.AddModelError("CustomerCode", "Consignor Code is not valid");
                return View(objThc);
            }
            if (objThc.ConsigneeId == 0)
            {
                this.ModelState.AddModelError("CustomerCode", "Consignee Code is not valid");
                return View(objThc);
            }


            objThc.Tosave = 1;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.DocketUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketOption", "Thc");
            return action;
        }
        public ActionResult ChangeDocketCustomer(string DocketId)
        {
            //
            return base.View(this.docketRepository.DocketGetDetailById(DocketId));
        }
        public ActionResult UpdateDocketOption()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult ChangeVendorLRNo(Thc objThc)
        {
            ActionResult action;
            objThc.Tosave = 8;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.ThcUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketDumptco", "Thc");
            return action;
        }
        public ActionResult ChangeVendorLRNo(string ThcId)
        {
            //
            return base.View(this.docketRepository.ThcGetDetailById(ThcId));
        }


        [HttpPost]
        public ActionResult ChangeFromCityToCity(Thc objThc)
        {
            ActionResult action;
            objThc.Tosave = 3;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.ThcUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketDumptco", "Thc");
            return action;
        }
        public ActionResult ChangeFromCityToCity(string ThcId)
        {
            return base.View(this.docketRepository.ThcGetDetailById(ThcId));
        }





        [HttpPost]
        public ActionResult ChangeVehicleNo(Thc objThc)
        {
            ActionResult action;
            objThc.Tosave = 7;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.ThcUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketDumptco", "Thc");
            return action;
        }
        public ActionResult ChangeVehicleNo(string ThcId)
        {
            return base.View(this.docketRepository.ThcGetDetailById(ThcId));
        }


        [HttpPost]
        public ActionResult ChangeVendorName(Thc objThc)
        {
            ActionResult action;
            objThc.Tosave = 1;
            objThc.EntryBy = SessionUtility.LoginUserId;

            this.thcRepository.ThcUpdate(objThc);
            action = base.RedirectToAction("UpdateDocketDumptco", "Thc");
            return action;
        }
        public ActionResult ChangeVendorName(string ThcId)
        {
            ((dynamic)base.ViewBag).VendorList = this.vendorRepository.GetAutoCompleteVendorList("", 0);
            return base.View(this.docketRepository.ThcGetDetailById(ThcId));
        }

        [HttpPost]
        public JsonResult CheckValidThcForUpdate(string ThcId, string VendorId, string updateFor, string LRNo)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidThcForUpdate(ThcId, VendorId, updateFor, LRNo));
            return jsonResult;
        }
        [HttpPost]
        public JsonResult CheckValidDocketNoForUpdate(string docketNo, int selectedStep)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidTHCNoForUpdate(docketNo, selectedStep));
            return jsonResult;
        }
        public ActionResult UpdateDocketDumptco()
        {
            return base.View();
        }


        public ActionResult Cancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation(ThcCancellation objThcCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objThcCancellation);
            }
            else
            {
                objThcCancellation.LocationId = SessionUtility.LoginLocationId;
                objThcCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objThcCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objThcCancellation.Details.RemoveAll((ThcCancellationDetails m) => !m.IsChecked);
                this.thcRepository.Cancellation(objThcCancellation);
                action = base.RedirectToAction("CancellationDone", "Docket", new { status = "ThcCancel" });
            }
            return action;
        }

        [HttpPost]
        public JsonResult CheckValidThcCode(string thcNo)
        {
            return base.Json(this.thcRepository.CheckValidThcCode(thcNo));
        }

        public ActionResult Deps()
        {
            this.DepsInit();
            return base.View();
        }

        [HttpPost]
        public ActionResult Deps(Deps objDeps)
        {
            ActionResult action;
            Response response = this.thcRepository.DepsEntry(objDeps);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.DepsInit();
                action = base.View(objDeps);
            }
            else
            {
                action = base.RedirectToAction("DepsDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult DepsDone()
        {
            return base.View();
        }

        private void DepsInit()
        {


            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).ArrivalConditions = this.generalRepository.GetByIdList(75);
            dynamic viewBag = base.ViewBag;
            Type type = typeof(JsonConvert);
            viewBag.ArrivalConditionList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).ArrivalConditions);
            ((dynamic)base.ViewBag).Warehouses = this.warehouseRepository.GetMappedWarehouseListByLocation(SessionUtility.LoginLocationId);
            dynamic obj = base.ViewBag;

            obj.WarehouseList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).Warehouses);
            ((dynamic)base.ViewBag).DeliveryProcess = this.generalRepository.GetByIdList(76);
            dynamic viewBag1 = base.ViewBag;

            viewBag1.DeliveryProcessList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).DeliveryProcess);
            ((dynamic)base.ViewBag).LateDeliveryReasons = this.generalRepository.GetByIdList(40);
            dynamic obj1 = base.ViewBag;

            obj1.LateDeliveryReasonList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).LateDeliveryReasons);
            ((dynamic)base.ViewBag).ShortReasons = this.generalRepository.GetByIdList(69);
            dynamic viewBag2 = base.ViewBag;

            viewBag2.ShortReasonList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).ShortReasons);
            ((dynamic)base.ViewBag).ExtraReasons = this.generalRepository.GetByIdList(70);
            dynamic obj2 = base.ViewBag;


            obj2.ExtraReasonList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).ExtraReasons);
            ((dynamic)base.ViewBag).PilferReasons = this.generalRepository.GetByIdList(71);
            dynamic viewBag3 = base.ViewBag;

            viewBag3.PilferReasonList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).PilferReasons);
            ((dynamic)base.ViewBag).DamageReasons = this.generalRepository.GetByIdList(72);
            dynamic obj3 = base.ViewBag;

            obj3.DamageReasonList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).DamageReasons);
            ((dynamic)base.ViewBag).RejectReasons = this.generalRepository.GetByIdList(80);
            ((dynamic)base.ViewBag).LabourVendorList = this.vendorRepository.GetVendorNameByVendorTypeId(9);
            dynamic objLabourVendorList = base.ViewBag;

            objLabourVendorList.LabourVendorLists = JsonConvert.SerializeObject(((dynamic)base.ViewBag).LabourVendorList);
        }

        public ActionResult DepsUpdate()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult DepsUpdate(ThcSummary objThcSummary)
        {
            ActionResult action;
            objThcSummary.IsUpdate = objThcSummary.IsUpdate;
            objThcSummary.LocationId = SessionUtility.LoginLocationId;
            objThcSummary.EntryBy = SessionUtility.LoginUserId;
            objThcSummary.ManifestList.RemoveAll((StockUpdateDocket m) => !m.IsChecked);
            foreach (StockUpdateDocket manifestList in objThcSummary.ManifestList)
            {
                DepsDocket depsDocket = new DepsDocket()
                {
                    DepsDocketId = manifestList.DepsDetails.DepsDocketId,
                    Packages = manifestList.DepsDetails.Packages,
                    FoundPackages = manifestList.DepsDetails.FoundPackages,
                    DocketId = manifestList.DepsDetails.DocketId,
                    DocketSuffix = manifestList.DepsDetails.DocketSuffix,
                    Remark = manifestList.DepsDetails.Remark
                };
                objThcSummary.DepsDetails.Add(depsDocket);
            }
            Response response = this.thcRepository.DepsUpdate(objThcSummary);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                action = base.View(objThcSummary);
            }
            else
            {
                action = base.RedirectToAction("StockUpdateDone");
            }
            return action;
        }

        public ActionResult Dispatch()
        {
            DocketDispatch docketDispatch = new DocketDispatch();
            ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetRouteNameList();
            ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAllAccountCodeList();
            return base.View(docketDispatch);
        }

        [HttpPost]
        public ActionResult Dispatch(DocketDispatch objDocketDispatch)
        {
            ActionResult action;
            objDocketDispatch.EntryBy = SessionUtility.LoginUserId;
            objDocketDispatch.CompanyId = SessionUtility.CompanyId;
            objDocketDispatch.Details.RemoveAll((DispatchDocketDetail m) => !m.IsChecked);
            Response response = this.thcRepository.DispatchInsert(objDocketDispatch);
            if (!response.IsSuccessfull)
            {
                action = base.View(objDocketDispatch);
            }
            else
            {
                action = base.RedirectToAction("DispatchDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult DispatchDone()
        {
            return base.View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.thcRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.vehicleTypeRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.airportRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.warehouseRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.locationRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FinanceUpdate()
        {
            FinanceUpdate financeUpdate = new FinanceUpdate();
            string[] strArrays = new string[] { "PRS", "DRS", "THC" };
            ((dynamic)base.ViewBag).DocumentTypeList = (
                from m in this.generalRepository.GetByIdList(32)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            return base.View(financeUpdate);
        }

        [HttpPost]
        public JsonResult GetChargeList(long thcId)
        {
            return base.Json(this.thcRepository.GetChargeList(thcId));
        }

        [HttpPost]
        public ActionResult GetDepsHistory(long depsDocketId)
        {
            ActionResult actionResult = this.PartialView("DepsHistory", this.thcRepository.GetDepsHistory(depsDocketId));
            return actionResult;
        }

        public JsonResult GetDepsListForStockUpdate(DateTime fromDate, DateTime toDate, string docketNo, string depsNo, short dateType, bool isUpdate)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetDepsListForStockUpdate(fromDate, toDate, docketNo, depsNo, dateType, isUpdate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDispatchDocketList()
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetDispatchDocketList(SessionUtility.LoginLocationId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetDocketDetailsForDeps(string docketNo)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetDocketDetailsForDeps(docketNo, (long)SessionUtility.LoginLocationId));
            return jsonResult;
        }

        public JsonResult GetDocumentListForUpdate(DateTime fromDate, DateTime toDate, string documentNo, string manualDocumentNo, byte documentTypeId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetDocumentListForUpdate(SessionUtility.LoginLocationId, fromDate, toDate, documentNo, manualDocumentNo, documentTypeId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetManifestList(DateTime fromDate, DateTime toDate, byte transportModeId, short routeId, short fromLocationId, short toLocationId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetManifestList(fromDate, toDate, transportModeId, routeId, fromLocationId, toLocationId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetManifestListForUpdateThc(long thcId, DateTime fromDate, DateTime toDate, byte transportModeId, short routeId, short fromLocationId, short toLocationId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetManifestListForUpdateThc(thcId, fromDate, toDate, transportModeId, routeId, fromLocationId, toLocationId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetStep1DetailById(long thcId)
        {
            return base.Json(this.thcRepository.GetStep1DetailById(thcId));
        }

        public JsonResult GetStep2DetailById(long thcId)
        {
            return base.Json(this.thcRepository.GetStep2DetailById(thcId));
        }

        public JsonResult GetStep3DetailById(long thcId)
        {
            return base.Json(this.thcRepository.GetStep3DetailById(thcId));
        }


        public JsonResult GetStep4DetailById(long thcId)
        {
            return base.Json(this.thcRepository.GetStep4DetailById(thcId));
        }

        public JsonResult GetStep5DetailById(long thcId)
        {
            return base.Json(this.thcRepository.GetStep5DetailById(thcId));
        }

        public JsonResult GetStep6DetailById(long thcId)
        {
            return base.Json(this.thcRepository.GetStep6DetailById(thcId));
        }

        [HttpPost]
        public JsonResult GetThcDetailForThcDeparture(long thcId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcDetailForThcDeparture(thcId, SessionUtility.LoginLocationId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetThcDetailsForStockUpdate(long thcId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcDetailsForStockUpdate(thcId, SessionUtility.LoginLocationId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetThcDocketListForStockUpdate(long thcId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcDocketListForStockUpdate(thcId, SessionUtility.LoginLocationId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetThcListForCancellation(string thcNo, string manualThcNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcListForCancellation(thcNo, manualThcNo, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetThcListForStockUpdate(string thcNos, DateTime fromDate, DateTime toDate, string vehicleNos, string docketNos, string arrivalLocations)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcListForStockUpdate(thcNos, fromDate, toDate, vehicleNos, docketNos, arrivalLocations, SessionUtility.LoginLocationId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetThcListForThcDeparture(string thcNos, DateTime fromDate, DateTime toDate, string manifestNos, string vehicleNos, string docketNos, short locationId, byte companyId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcListForThcDeparture(thcNos, fromDate, toDate, manifestNos, vehicleNos, docketNos, locationId, companyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetThcListForVehicleArrival(string thcNos, DateTime fromDate, DateTime toDate, string vehicleNos, string docketNos, string arrivalLocations)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcListForVehicleArrival(thcNos, fromDate, toDate, vehicleNos, docketNos, arrivalLocations, SessionUtility.LoginLocationId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetUnloadingDocketList(string thcNos)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetUnloadingDocketList(thcNos, SessionUtility.LoginLocationId));
            return jsonResult;
        }
        public ActionResult InsertTriSpeed(long? id)
        {
            ThcTrispeed thc = new ThcTrispeed();

            ((dynamic)base.ViewBag).ThcId = id;
            ((dynamic)base.ViewBag).RouteList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).VendorList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).VehicleList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).AirlineList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).FlightList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).AirPortList = this.airportRepository.GetAirPortList();
            ((dynamic)base.ViewBag).FTLTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            return base.View(thc);
        }

        [HttpPost]
        public ActionResult InsertTriSpeed(ThcTrispeed objThc)
        {
            Response response;
            ActionResult action;
            objThc.CompanyId = SessionUtility.CompanyId;
            objThc.LocationId = SessionUtility.LoginLocationId;
            objThc.LocationCode = SessionUtility.LoginLocationCode;
            objThc.EntryBy = SessionUtility.LoginUserId;
            if (objThc.BalanceLocationId == 0)
            {
                objThc.BalanceLocationId = SessionUtility.LoginLocationId;
            }
            objThc.ThcSummary.LoadBy = SessionUtility.LoginUserId;
            objThc.ThcSummary.FromLocationId = SessionUtility.LoginLocationId;
            objThc.ThcSummary.ToLocationId = new short?(objThc.ToLocationId);
            objThc.ThcSummary.ThcDate = objThc.ThcDateTime;
            objThc.ThcSummary.RouteId = objThc.RouteId;
            objThc.ThcSummary.ActualDepartureDate = new DateTime?(objThc.ThcDateTime);
            if (objThc.AdvanceLocationCode == null)
            {
                objThc.AdvanceLocationId = null;
            }
            response = (objThc.ThcId <= (long)0 ? this.thcRepository.InsertTrispeed(objThc) : this.thcRepository.UpdateTrispeed(objThc));
            if (!response.IsSuccessfull)
            {
                action = base.View(objThc);
            }
            else
            {
                action = base.RedirectToAction("ThcDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }
        private void Init(long? id)
        {


            ((dynamic)base.ViewBag).RouteList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).VendorList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).VehicleList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).AirlineList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).FlightList = Enumerable.Empty<SelectListItem>();
            ((dynamic)base.ViewBag).VendorFuelList = this.vendorRepository.GetAutoCompleteVendorListByLocationforFuel(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).AirPortList = this.airportRepository.GetAirPortList();
            ((dynamic)base.ViewBag).FTLTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            ((dynamic)base.ViewBag).FuelTypeList = this.generalRepository.GetByIdList(7);

            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).TDSRuleList = this.generalRepository.GetByIdList(304);

        }
        public ActionResult Insert(long? id)
        {
            Thc thc = new Thc();

            ((dynamic)base.ViewBag).ThcId = id;
            this.Init(null);

            if (id != null)
            {
                bool isBilled = false;
                thc.IsBill = thcRepository.CheckBillIsMade((long)id);

            }

            thc.AdvBalPmtDtl.Add(new ThcAdvBalPaymnt_Details());
            return base.View(thc);
        }

        [HttpPost]
        public ActionResult Insert(Thc objThc)
        {
            Response response;
            ActionResult action;
            objThc.CompanyId = SessionUtility.CompanyId;
            objThc.LocationId = SessionUtility.LoginLocationId;
            objThc.LocationCode = SessionUtility.LoginLocationCode;
            objThc.EntryBy = SessionUtility.LoginUserId;
            if (objThc.BalanceLocationId == 0)
            {
                objThc.BalanceLocationId = SessionUtility.LoginLocationId;
            }
            objThc.ThcSummary.LoadBy = SessionUtility.LoginUserId;
            objThc.ThcSummary.FromLocationId = SessionUtility.LoginLocationId;
            objThc.ThcSummary.ToLocationId = new short?(objThc.ToLocationId);
            objThc.ThcSummary.ThcDate = objThc.ThcDateTime;
            objThc.ThcSummary.RouteId = objThc.RouteId;
            objThc.FinYear = SessionUtility.FinYear;
            objThc.ThcSummary.ActualDepartureDate = new DateTime?(objThc.ThcDateTime);
            if (objThc.AdvanceLocationCode == null)
            {
                objThc.AdvanceLocationId = null;
            }

            response = (objThc.ThcId <= (long)0 ? this.thcRepository.Insert(objThc) : this.thcRepository.Update(objThc));
            if (!response.IsSuccessfull)
            {
                action = base.View(objThc);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 201) == "Y")
                {
                    string EntryBy = SessionUtility.LoginUserId.ToString();

                    Task<TaxProEwayConsolidateApiResponse> taskEx = Task.Run<TaxProEwayConsolidateApiResponse>(async () => await this.docketRepository.TaxProEwayConsolidated(response.DocumentId.ToString(), "THC", EntryBy));
                    TaxProEwayConsolidateApiResponse objTaskEx = taskEx.Result;

                    if(objTaskEx != null)
                    {
                        if(objTaskEx.IsSuccess==true)
                        {
                            response.DocumentId3 = Convert.ToInt64(objTaskEx.cEwbNo);
                            response.DocumentNo3= objTaskEx.cEwbNo.ToString();
                        }
                        else
                        {
                            response.DocumentNo3 = "0";
                            response.DocumentId3 = 0;
                        }
                    }
                    else
                    {
                        response.DocumentNo3 = "0";
                        response.DocumentId3 = 0;
                    }
                }

                if (objThc.ThcId <= (long)0 && this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 81) == "Y")
                {
                    foreach (var manifest in objThc.ThcManifestDetailList)
                    {
                        var manifestDocketList = this.manifestRepository.GetDocketListByManifestId(manifest.ManifestId);
                        foreach (var docket in manifestDocketList)
                        {
                            try
                            {
                                DocketTrackingResponseForFarEyeSuccess doketTrackingApiResponse = new DocketTrackingResponseForFarEyeSuccess();
                                DocketTrackingResponseForFarEyeFailure docketTrackingResponseForFarEye = new DocketTrackingResponseForFarEyeFailure();
                                string json = string.Empty;
                                doketTrackingApiResponse = trackingRepository.OrderTrackingForFarEye(docket.DocketNo);
                                if (doketTrackingApiResponse.order_no == null)
                                {
                                    docketTrackingResponseForFarEye.order_no = response.DocumentNo;
                                    docketTrackingResponseForFarEye.Status = "Not Found";
                                    json = JsonConvert.SerializeObject(docketTrackingResponseForFarEye);
                                }
                                else
                                    json = JsonConvert.SerializeObject(doketTrackingApiResponse);
                                CallFareyeWebhook(response.DocumentId, json);
                            }
                            catch (Exception ex)
                            {
                                ExceptionUtility.LogException(ex, "Call Fareye Webhook", SessionUtility.LoginUserId, nameof(Insert));
                            }
                            finally
                            {
                                action = base.RedirectToAction("ThcDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
                            }
                        }
                    }
                }

               action = base.RedirectToAction("ThcDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
            }
            return action;
        }

        public ActionResult StockUpdate()
        {
            ThcSummary thcSummary = new ThcSummary();
            this.DepsInit();
            return base.View(thcSummary);
        }
        public ActionResult StockUpdateScanning()
        {
            ThcSummary thcSummary = new ThcSummary();
            this.DepsInit();
            return base.View(thcSummary);
        }


        [HttpPost]
        public ActionResult StockUpdate(ThcSummary objThcSummary)
        {
            ActionResult action;
            objThcSummary.ToLocationId = new short?(SessionUtility.LoginLocationId);
            objThcSummary.ToLocationCode = SessionUtility.LoginLocationCode;
            objThcSummary.EntryBy = SessionUtility.LoginUserId;
            objThcSummary.CompanyId = SessionUtility.CompanyId;
            Response response = this.thcRepository.StockUpdate(objThcSummary);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.DepsInit();
                action = base.View(objThcSummary);
            }
            else
            {
                action = base.RedirectToAction("StockUpdateDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }


        public ActionResult StockUpdateDone(long documentId)
        {
            List<ThcManifestDetail> thcManifestDetails = new List<ThcManifestDetail>();
            thcManifestDetails.AddRange(this.thcRepository.GetManifestListByThcId(documentId));
            return base.View(thcManifestDetails);
        }

        public ActionResult ThcDeparture()
        {
            Departure departure = new Departure();
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            return base.View(departure);
        }

        [HttpPost]
        public ActionResult ThcDeparture(Departure objThcDeparture)
        {
            ActionResult action;
            objThcDeparture.FromLocationId = SessionUtility.LoginLocationId;
            objThcDeparture.LoadBy = SessionUtility.LoginUserId;
            if (objThcDeparture.ThcDepartureManifestList != null)
            {
                objThcDeparture.ThcDepartureManifestList.RemoveAll((ThcManifestDetail m) => !m.IsChecked);
            }
            Response response = this.thcRepository.ThcDeparture(objThcDeparture);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
                action = base.View(objThcDeparture);
            }
            else
            {
                action = base.RedirectToAction("ThcDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, type = "D" });
            }
            return action;
        }

        public ActionResult ThcDone(long documentId)
        {
            List<ThcManifestDetail> thcManifestDetails = new List<ThcManifestDetail>();
            thcManifestDetails.AddRange(this.thcRepository.GetManifestListByThcId(documentId));
            return base.View(thcManifestDetails);
        }

        public ActionResult Unloading()
        {
            Unloading unloading = new Unloading();
            ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetMappedWarehouseListByLocation(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAllAccountCodeList();
            return base.View(unloading);
        }

        [HttpPost]
        public ActionResult Unloading(Unloading objUnloading)
        {
            ActionResult action;
            objUnloading.CompanyId = SessionUtility.CompanyId;
            objUnloading.LocationId = SessionUtility.LoginLocationId;
            objUnloading.LocationCode = SessionUtility.LoginLocationCode;
            objUnloading.EntryBy = SessionUtility.LoginUserId;
            DynamicParameters dynamicParameter = new DynamicParameters();
            ParameterDirection? nullable = null;
            int? nullable1 = null;
            byte? nullable2 = null;
            byte? nullable3 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@LocationId", SessionUtility.LoginLocationId, new DbType?(DbType.Int16), nullable, nullable1, nullable3, nullable2);
            DateTime unloadingDateTime = objUnloading.UnloadingDateTime;
            nullable = null;
            nullable1 = null;
            nullable2 = null;
            byte? nullable4 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@UnloadingDate", unloadingDateTime.Date, new DbType?(DbType.Date), nullable, nullable1, nullable4, nullable2);
            nullable1 = null;
            nullable2 = null;
            byte? nullable5 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@UnloadingNo", null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), nullable1, nullable5, nullable2);
            DataBaseFactory.QuerySP("Usp_Unloading_GetNextUnloadingNo", dynamicParameter, "Unloading - GetNextUnloadingNo");
            objUnloading.UnloadingNo = dynamicParameter.Get<string>("@UnloadingNo");
            if (objUnloading.UnloadingAttachment != null)
            {
                DynamicParameters dynamicParameter1 = new DynamicParameters();
                nullable1 = null;
                nullable2 = null;
                byte? nullable6 = nullable2;
                nullable2 = null;
                dynamicParameter1.Add("@UnloadingId", null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), nullable1, nullable6, nullable2);
                DataBaseFactory.QuerySP("Usp_Unloading_GetMaxUnloadingId", dynamicParameter1, "Unloading - GetMaxUnloadingId");
                long num = dynamicParameter1.Get<long>("@UnloadingId");
                string fileName = "";
                if (!ConfigHelper.IsLocalStorage)
                {
                    fileName = AzureStorageHelper.GetFileName("Unloading", "DOC_TYPE", objUnloading.UnloadingNo.ToString(), num.ToString(), objUnloading.UnloadingAttachment.FileName);
                    AzureStorageHelper.UploadBlob("Employee", objUnloading.UnloadingAttachment, fileName, fileName);
                }
                else
                {
                    fileName = string.Concat(num.ToString(), "_", objUnloading.UnloadingAttachment.FileName);
                    string str = string.Concat(ConfigHelper.LocalStoragePath, "Employee/", fileName);
                    objUnloading.UnloadingAttachment.SaveAs(str);
                }
                objUnloading.UnloadingDocumentName = fileName;
                objUnloading.UnloadingAttachment = null;
            }
            Response response = this.thcRepository.Unloading(objUnloading);
            if (!response.IsSuccessfull)
            {
                action = base.View(objUnloading);
            }
            else
            {
                action = base.RedirectToAction("UnloadingDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult UnloadingDone()
        {
            return base.View();
        }

        public ActionResult VehicleArrival()
        {
            ThcSummary thcSummary = new ThcSummary();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).LateArrivalReasonList = this.generalRepository.GetByIdList(81);
            return base.View(thcSummary);
        }

        [HttpPost]
        public ActionResult VehicleArrival(ThcSummary objThcSummary)
        {
            ActionResult action;
            objThcSummary.ToLocationCode = SessionUtility.LoginLocationCode;
            objThcSummary.ToLocationId = new short?(SessionUtility.LoginLocationId);
            objThcSummary.UnloadBy = new short?(SessionUtility.LoginUserId);
            Response response = this.thcRepository.VehicleArrival(objThcSummary);
            if (!response.IsSuccessfull)
            {
                action = base.View(objThcSummary);
            }
            else
            {
                action = base.RedirectToAction("VehicleArrivalDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult VehicleArrivalDone()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult ThcDone(string hdnDocumentId, string hdnDocumentType, HttpPostedFileBase fuFileName)
        {
            string FileLoc = Server.MapPath("~/Storage/DocumentPrint/");
            string FileName = "";

            if (System.IO.Directory.Exists(FileLoc)) { }
            else
            {
                System.IO.Directory.CreateDirectory(FileLoc);
            }
            FileName = hdnDocumentType + "_" + hdnDocumentId + Path.GetExtension(fuFileName.FileName);

            FileLoc = FileLoc + FileName;

            fuFileName.SaveAs(FileLoc);
            Response response = this.generalRepository.InsertFormDocumentImage(hdnDocumentId, hdnDocumentType, FileName);
            ActionResult action = base.RedirectToAction("InsertDoneImage", new { documentId = response.DocumentId, documentNo = response.DocumentNo, DocumentFile = FileName });

            return action;
        }
        public ActionResult InsertDoneImage()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult GetDepsDocketHistory(long depsDocketId)
        {
            ActionResult actionResult = this.PartialView("DepsHistory", this.thcRepository.GetDepsDocketHistory(depsDocketId));
            return actionResult;
        }

        public async Task CallFareyeWebhook(long docketId, string payloadData)
        {
            // Replace 'webhookUrl' with your actual webhook endpoint URL
            string webhookUrl = "https://api.fareyeconnect.com/carrier/v1/essential/webhook";
            string bearerToken = "33b2b59b-0201-4814-96c8-484e55be46b5";

            using (var httpClient = new HttpClient())
            {
                // Set the Bearer Token in the request's authorization header
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

                // Set the content type to application/json if your webhook expects JSON data
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Create a StringContent with your payload data and the desired encoding (UTF8 in this case)
                var content = new StringContent(payloadData, Encoding.UTF8, "application/json");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                // Make the HTTP POST request to the webhook
                var response = httpClient.PostAsync(webhookUrl, content);
                response.Wait();
                var webhookResult = response.Result;
                docketRepository.InsertFareyeWebhookResult(docketId, Convert.ToString(webhookResult));
            }
        }
        [HttpPost]
        public JsonResult GetThcDocketListForStockUpdateByManifest(long thcId, string manifestId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcDocketListForStockUpdateByManifest(thcId, SessionUtility.LoginLocationId, manifestId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }


        [HttpPost]
        public JsonResult GetManifestListByThcIdForStockUpdate(long thcId)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetManifestListByThcIdForStockUpdate(thcId));
            return jsonResult;
        }

        public ActionResult StockUpdateMLPL()
        {
            ThcSummary thcSummary = new ThcSummary();
            this.DepsInit();
            return base.View(thcSummary);
        }

        [HttpPost]
        public ActionResult StockUpdateMLPL(ThcSummary objThcSummary)
        {
            ActionResult action;
            objThcSummary.ToLocationId = new short?(SessionUtility.LoginLocationId);
            objThcSummary.ToLocationCode = SessionUtility.LoginLocationCode;
            objThcSummary.EntryBy = SessionUtility.LoginUserId;
            objThcSummary.CompanyId = SessionUtility.CompanyId;
            Response response = this.thcRepository.StockUpdate(objThcSummary);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.DepsInit();
                action = base.View(objThcSummary);
            }
            else
            {
                action = base.RedirectToAction("StockUpdateMLPLDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }
        public ActionResult StockUpdateMLPLDone(long documentId)
        {
            List<ThcManifestDetail> thcManifestDetails = new List<ThcManifestDetail>();
            thcManifestDetails.AddRange(this.thcRepository.GetManifestListByThcId(documentId));
            return base.View(thcManifestDetails);
        }

        public JsonResult GetThcListForStockUpdateCancellation(string thcNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcListForStockUpdateCancellation(thcNo, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }
        public ActionResult ThcStockUpdateCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThcStockUpdateCancellation(ThcStockUpdateCancellation objThcStockUpdateCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objThcStockUpdateCancellation);
            }
            var response = this.thcRepository.ThcStockUpdateCancellation(objThcStockUpdateCancellation.ThcId, objThcStockUpdateCancellation.CancelReason, objThcStockUpdateCancellation.CancelDate, SessionUtility.LoginUserId, SessionUtility.LoginLocationId);
            if (!response.IsSuccessfull)
            {
                action = base.View(objThcStockUpdateCancellation);
            }
            return RedirectToAction("CancellationDone", "Docket", new { DocumentId = objThcStockUpdateCancellation.ThcId, status = "THCStockUpdateCancellationDone" });

        }
        public JsonResult GetMultiAdvanceDetail(long thcId)
        {
            JsonResult jsonResult= base.Json(this.thcRepository.GetMultiAdvanceDetail(thcId));
            return jsonResult;
        }

        public ActionResult VehicleArrivalCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VehicleArrivalCancellation(ThcCancellation objThcCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objThcCancellation);
            }
            else
            {
                objThcCancellation.LocationId = SessionUtility.LoginLocationId;
                objThcCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objThcCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objThcCancellation.Details.RemoveAll((ThcCancellationDetails m) => !m.IsChecked);
                this.thcRepository.VehicleArrivalCancellation(objThcCancellation);
                action = base.RedirectToAction("CancellationDone", "Docket", new { status = "VehicleArrivalCancellation" });
            }
            return action;
        }

        public JsonResult GetThcListForVehicleArrivalCancellation(string thcNo, string manualThcNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.thcRepository.GetThcListForVehicleArrivalCancellation(thcNo, manualThcNo, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }
    }


}
