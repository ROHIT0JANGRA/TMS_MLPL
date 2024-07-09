using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeLock.Areas.Operation.Controllers
{
    public class LoadingSheetController : Controller
    {
        private readonly ILoadingSheetRepository loadingSheetRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IZoneRepository zoneRepository;
        private readonly ITrackingRepository trackingRepository;
        private readonly IDocketRepository docketRepository;
        private readonly IRulesRepository rulesRepository;

        public LoadingSheetController(ILoadingSheetRepository _loadingSheetRepository, IGeneralRepository _generalRepository, ILocationRepository _locationRepository, IZoneRepository _zoneRepository, IDocketRepository _docketRepository, ITrackingRepository trackingRepository, IRulesRepository _rulesRepository)
        {
            this.loadingSheetRepository = _loadingSheetRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.zoneRepository = _zoneRepository;
            this.trackingRepository = trackingRepository;
            this.docketRepository = _docketRepository;
            this.rulesRepository = _rulesRepository;
        }

        public ActionResult Cancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation(LoadingSheetCancellation objLoadingSheetCancellation)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objLoadingSheetCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objLoadingSheetCancellation.LocationId = SessionUtility.LoginLocationId;
                objLoadingSheetCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objLoadingSheetCancellation.Details.RemoveAll((LoadingSheetCancellationDetails m) => !m.IsChecked);
                if (this.loadingSheetRepository.Cancellation(objLoadingSheetCancellation).IsSuccessfull)
                {
                    action = base.RedirectToAction("CancellationDone", "Docket", new { status = "LoadingSheetCancel" });
                    return action;
                }
            }
            action = base.View(objLoadingSheetCancellation);
            return action;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.loadingSheetRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.locationRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.zoneRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetDocketListForLoadingSheet(byte companyId, short locationId, string docketList, DateTime fromDate, DateTime toDate, byte transportModeId, int fromCityId, int toCityId, string toLocationList, string zoneList)
        {
            JsonResult jsonResult = base.Json(this.loadingSheetRepository.GetDocketListForLoadingSheet(companyId, locationId, docketList, fromDate, toDate, transportModeId, fromCityId, toCityId, toLocationList, zoneList), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLoadingSheetDetails(long loadingsheetId, short vendorId)
        {
            LoadingSheet loadingSheetById = this.loadingSheetRepository.GetLoadingSheetById(loadingsheetId);
            Manifest manifest = new Manifest()
            {
                LoadingSheetId = loadingsheetId,
                LoadingSheetNo = loadingSheetById.LoadingSheetNo,
                LoadingSheetDateTime = loadingSheetById.LoadingSheetDateTime,
                NextLocationId = loadingSheetById.NextLocationId,
                ManifestDocketList = this.loadingSheetRepository.GetDocketListByLoadingSheetId(loadingsheetId, vendorId, SessionUtility.LoginLocationId).ToList<ManifestDocket>()
            };
            return base.Json(manifest, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLoadingSheetListForCancellation(string loadingSheetNo, string manualLoadingSheetNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.loadingSheetRepository.GetLoadingSheetListForCancellation(loadingSheetNo, manualLoadingSheetNo, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLoadingSheetListForUpdate(short locationId, DateTime fromDate, DateTime toDate, short nextLocationId, string loadingSheetNo)
        {
            JsonResult jsonResult = base.Json(this.loadingSheetRepository.GetLoadingSheetListForUpdate(locationId, fromDate, toDate, nextLocationId, loadingSheetNo), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
        public ActionResult InsertDumtco()
        {
            LoadingSheet loadingSheet = new LoadingSheet();
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).ZoneList = this.zoneRepository.GetZoneList();
            loadingSheet.TransportModeId = 2;
            return base.View(loadingSheet);
        }
        public ActionResult Insert()
        {
            LoadingSheet loadingSheet = new LoadingSheet();
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).ZoneList = this.zoneRepository.GetZoneList();
            return base.View(loadingSheet);
        }

        [HttpPost]
        public ActionResult Insert(LoadingSheet objLoadingSheet)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objLoadingSheet.LocationId = SessionUtility.LoginLocationId;
                objLoadingSheet.EntryBy = SessionUtility.LoginUserId;
                objLoadingSheet.CompanyId = SessionUtility.CompanyId;
                objLoadingSheet.LoadingSheetDocketList.RemoveAll((LoadingSheetDocket x) => !x.IsChecked);
                Response response = this.loadingSheetRepository.Insert(objLoadingSheet);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
                    return action;
                }
            }
            action = base.View(objLoadingSheet);
            return action;
        }

        public ActionResult InsertDone()
        {
            return base.View();
        }

        public ActionResult Update()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult Update(Manifest objManifest)
        {
            ActionResult action;
            objManifest.LocationId = SessionUtility.LoginLocationId;
            objManifest.LocationCode = SessionUtility.LoginLocationCode;
            objManifest.EntryBy = SessionUtility.LoginUserId;
            objManifest.EntryDate = DateTime.Now;
            objManifest.CompanyId = SessionUtility.CompanyId;
            objManifest.ManualManifestNo = "NA";
            objManifest.ManifestDate = objManifest.ManifestDateTime.Date;
            objManifest.ManifestTime = objManifest.ManifestDateTime.TimeOfDay;
            objManifest.NonManifestDocketList = (
                from m in objManifest.ManifestDocketList
                where !m.IsChecked
                select m).ToList<ManifestDocket>();
            objManifest.ManifestDocketList = (
                from m in objManifest.ManifestDocketList
                where m.IsChecked
                select m).ToList<ManifestDocket>();
            List<ManifestDocket> list = (
                from m in objManifest.ManifestDocketList
                where (m.LoadPackages < m.Packages ? true : m.LoadActualWeight < m.ActualWeight)
                select m into docket
                select new ManifestDocket()
                {
                    DocketId = docket.DocketId,
                    DocketSuffix = (docket.DocketSuffix == "." ? "A" : StringFunctions.NextKeyCode(docket.DocketSuffix)),
                    Packages = (short)(docket.Packages - docket.LoadPackages),
                    ActualWeight = docket.ActualWeight - docket.LoadActualWeight,
                    LoadPackages = docket.LoadPackages,
                    LoadActualWeight = docket.LoadActualWeight,
                    IsSuffixDocket = true
                }).ToList<ManifestDocket>();
            objManifest.ManifestDocketList.ForEach((ManifestDocket m) =>
            {
                m.Packages = m.LoadPackages;
                m.ActualWeight = m.LoadActualWeight;
            });
            objManifest.ManifestDocketList.AddRange(list);
            Response response = this.loadingSheetRepository.Update(objManifest);
            if (!response.IsSuccessfull)
            {
                action = base.View(objManifest);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 81) == "Y")
                {
                    foreach (var docket in objManifest.ManifestDocketList)
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

                            ExceptionUtility.LogException(ex, "Call Fareye Webhook", SessionUtility.LoginUserId, nameof(Update));
                        }
                        finally
                        {
                            action = base.RedirectToAction("UpdateDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
                        }
                    }
                }
                action = base.RedirectToAction("UpdateDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult UpdateParcel()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult UpdateParcel(Manifest objManifest)
        {
            ActionResult action;
            objManifest.LocationId = SessionUtility.LoginLocationId;
            objManifest.LocationCode = SessionUtility.LoginLocationCode;
            objManifest.EntryBy = SessionUtility.LoginUserId;
            objManifest.EntryDate = DateTime.Now;
            objManifest.CompanyId = SessionUtility.CompanyId;
            objManifest.ManualManifestNo = "NA";
            objManifest.ManifestDate = objManifest.ManifestDateTime.Date;
            objManifest.ManifestTime = objManifest.ManifestDateTime.TimeOfDay;
            objManifest.NonManifestDocketList = (
                from m in objManifest.ManifestDocketList
                where !m.IsChecked
                select m).ToList<ManifestDocket>();
            objManifest.ManifestDocketList = (
                from m in objManifest.ManifestDocketList
                where m.IsChecked
                select m).ToList<ManifestDocket>();
            List<ManifestDocket> list = (
                from m in objManifest.ManifestDocketList
                where (m.LoadPackages < m.Packages ? true : m.LoadActualWeight < m.ActualWeight)
                select m into docket
                select new ManifestDocket()
                {
                    DocketId = docket.DocketId,
                    DocketSuffix = (docket.LastDocketSuffix == "." ? "A" : StringFunctions.NextKeyCode(docket.LastDocketSuffix)),
                    Packages = (short)(docket.Packages - docket.LoadPackages),
                    ActualWeight = docket.ActualWeight - docket.LoadActualWeight,
                    LoadPackages = docket.LoadPackages,
                    LoadActualWeight = docket.LoadActualWeight,
                    IsSuffixDocket = true
                }).ToList<ManifestDocket>();
            objManifest.ManifestDocketList.ForEach((ManifestDocket m) =>
            {
                m.Packages = m.LoadPackages;
                m.ActualWeight = m.LoadActualWeight;
            });
            objManifest.ManifestDocketList.AddRange(list);
            Response response = this.loadingSheetRepository.Update(objManifest);
            if (!response.IsSuccessfull)
            {
                action = base.View(objManifest);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 81) == "Y")
                {
                    foreach (var docket in objManifest.ManifestDocketList)
                    {
                        try
                        {
                            DocketTrackingResponseForFarEyeSuccess doketTrackingApiResponse = new DocketTrackingResponseForFarEyeSuccess();
                            DocketTrackingResponseForFarEyeFailure docketTrackingResponseForFarEye = new DocketTrackingResponseForFarEyeFailure();
                            string json = string.Empty;
                            var docketDetails = docketRepository.DocketGetDetailById(Convert.ToString(docket.DocketId));
                            doketTrackingApiResponse = trackingRepository.OrderTrackingForFarEye(docketDetails.DocketNo);
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

                            ExceptionUtility.LogException(ex, "Call Fareye Webhook", SessionUtility.LoginUserId, nameof(Update));
                        }
                        finally
                        {
                            action = base.RedirectToAction("UpdateParcelDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
                        }
                    }
                }
                action = base.RedirectToAction("UpdateParcelDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult UpdateParcelScanning()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult UpdateParcelScanning(Manifest objManifest)
        {
            ActionResult action;
            objManifest.LocationId = SessionUtility.LoginLocationId;
            objManifest.LocationCode = SessionUtility.LoginLocationCode;
            objManifest.EntryBy = SessionUtility.LoginUserId;
            objManifest.EntryDate = DateTime.Now;
            objManifest.CompanyId = SessionUtility.CompanyId;
            objManifest.ManualManifestNo = "NA";
            objManifest.ManifestDate = objManifest.ManifestDateTime.Date;
            objManifest.ManifestTime = objManifest.ManifestDateTime.TimeOfDay;
            objManifest.NonManifestDocketList = (
                from m in objManifest.ManifestDocketList
                where !m.IsChecked
                select m).ToList<ManifestDocket>();
            objManifest.ManifestDocketList = (
                from m in objManifest.ManifestDocketList
                where m.IsChecked
                select m).ToList<ManifestDocket>();
            List<ManifestDocket> list = (
                from m in objManifest.ManifestDocketList
                where (m.LoadPackages < m.Packages ? true : m.LoadActualWeight < m.ActualWeight)
                select m into docket
                select new ManifestDocket()
                {
                    DocketId = docket.DocketId,
                    DocketSuffix = (docket.LastDocketSuffix == "." ? "A" : StringFunctions.NextKeyCode(docket.LastDocketSuffix)),
                    Packages = (short)(docket.Packages - docket.LoadPackages),
                    ActualWeight = docket.ActualWeight - docket.LoadActualWeight,
                    LoadPackages = docket.LoadPackages,
                    LoadActualWeight = docket.LoadActualWeight,
                    IsSuffixDocket = true
                }).ToList<ManifestDocket>();
            objManifest.ManifestDocketList.ForEach((ManifestDocket m) =>
            {
                m.Packages = m.LoadPackages;
                m.ActualWeight = m.LoadActualWeight;
            });
            objManifest.ManifestDocketList.AddRange(list);
            Response response = this.loadingSheetRepository.Update(objManifest);
            if (!response.IsSuccessfull)
            {
                action = base.View(objManifest);
            }
            else
            {
                action = base.RedirectToAction("UpdateParcelDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult UpdateCriteria()
        {
            return base.View();
        }

        public ActionResult UpdateDone()
        {
            return base.View();
        }

        public ActionResult UpdateParcelDone()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult GetVendorList(short locationId)
        {
            return this.Json((object)this.loadingSheetRepository.GetVendorList(locationId), JsonRequestBehavior.AllowGet);
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

    }
}
