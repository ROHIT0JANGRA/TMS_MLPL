using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeLock.Areas.Operation.Controllers
{
    public class ManifestController : Controller
    {
        private readonly IManifestRepository manifestRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IZoneRepository zoneRepository;
        private readonly ITrackingRepository trackingRepository;
        private readonly IDocketRepository docketRepository;
        private readonly IRulesRepository rulesRepository;

        public ManifestController(
          IManifestRepository _manifestRepository,
          IGeneralRepository _generalRepository,
          ILocationRepository _locationRepository,
          IZoneRepository _zoneRepository,
          ITrackingRepository _trackingRepository,
          IDocketRepository _docketRepository,
          IRulesRepository _rulesRepository)
        {
            this.manifestRepository = _manifestRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.zoneRepository = _zoneRepository;
            this.trackingRepository = _trackingRepository;
            this.docketRepository = _docketRepository;
            this.rulesRepository = _rulesRepository;
        }

        [HttpPost]
        public JsonResult GetManifestListForLabourDCForTracking(
          string locationId,
          string docketList,
          DateTime fromDate,
          DateTime toDate,
          string DocumentType,
          string THCType,
          string VendorId
          )
        {
            return this.Json((object)this.manifestRepository.GetManifestListForLabourDCForTracking(locationId, docketList, fromDate, toDate, DocumentType, THCType, VendorId, SessionUtility.CompanyId.ToString()), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetManifestListForLabourDC(
          string locationId,
          string docketList,
          DateTime fromDate,
          DateTime toDate,
          string DocumentType,
          string THCType
          )
        {
            return this.Json((object)this.manifestRepository.GetManifestListForLabourDC(SessionUtility.CompanyId, locationId, fromDate, toDate, docketList, DocumentType, THCType), JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertLabourDCDone()
        {
            return (ActionResult)this.View();
        }
        public ActionResult LabourDC()
        {
            LabourDCModule labourDC = new LabourDCModule();
            labourDC.LocationId = SessionUtility.LoginLocationId;
            labourDC.BillLocationId = SessionUtility.LoginLocationId;
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(labourDC);
        }
        [HttpPost]
        public ActionResult LabourDC(LabourDCModule objManifest)
        {
            if (this.ModelState.IsValid)
            {
                objManifest.LocationId = SessionUtility.LoginLocationId;
                objManifest.LocationCode = SessionUtility.LoginLocationCode;
                objManifest.EntryBy = SessionUtility.LoginUserId;
                objManifest.EntryDate = DateTime.Now;
                objManifest.CompanyId = SessionUtility.CompanyId;
                objManifest.ManifestList = objManifest.ManifestList.Where<LabourDCManifest>((Func<LabourDCManifest, bool>)(m => m.IsChecked)).ToList<LabourDCManifest>();
                Response response = this.manifestRepository.InsertLabourDC(objManifest);
                if (response.IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("InsertLabourDCDone", (object)new
                    {
                        documentId = response.DocumentId,
                        documentNo = response.DocumentNo
                    });
            }
            return (ActionResult)this.View((object)objManifest);
        }
        public ActionResult Insert()
        {
            Manifest manifest = new Manifest();
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).ZoneList = this.zoneRepository.GetZoneList();
            return base.View(manifest);
        }

        [HttpPost]
        public ActionResult Insert(Manifest objManifest)
        {
            ActionResult action;
            if (this.ModelState.IsValid)
            {
                objManifest.LocationId = SessionUtility.LoginLocationId;
                objManifest.LocationCode = SessionUtility.LoginLocationCode;
                objManifest.EntryBy = SessionUtility.LoginUserId;
                objManifest.EntryDate = DateTime.Now;
                objManifest.CompanyId = SessionUtility.CompanyId;
                objManifest.ManifestDocketList = objManifest.ManifestDocketList.Where<ManifestDocket>((Func<ManifestDocket, bool>)(m => m.IsChecked)).ToList<ManifestDocket>();
                List<ManifestDocket> list = objManifest.ManifestDocketList.Where<ManifestDocket>((Func<ManifestDocket, bool>)(m => m.LoadPackages < m.Packages || m.LoadActualWeight < m.ActualWeight)).Select<ManifestDocket, ManifestDocket>((Func<ManifestDocket, ManifestDocket>)(docket => new ManifestDocket()
                {
                    DocketId = docket.DocketId,
                    DocketSuffix = docket.DocketSuffix == "." ? "A" : StringFunctions.NextKeyCode(docket.DocketSuffix),
                    Packages = (int)(short)(docket.Packages - docket.LoadPackages),
                    ActualWeight = docket.ActualWeight - docket.LoadActualWeight,
                    LoadPackages = docket.LoadPackages,
                    LoadActualWeight = docket.LoadActualWeight,
                    IsSuffixDocket = true
                })).ToList<ManifestDocket>();
                objManifest.ManifestDocketList.ForEach((Action<ManifestDocket>)(m =>
                {
                    m.Packages = m.LoadPackages;
                    m.ActualWeight = m.LoadActualWeight;
                }));
                objManifest.ManifestDocketList.AddRange((IEnumerable<ManifestDocket>)list);
                Response response = this.manifestRepository.Insert(objManifest);
                if (response.IsSuccessfull)
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
                                ExceptionUtility.LogException(ex, "Call Fareye Webhook", SessionUtility.LoginUserId, nameof(Insert));
                            }
                            finally
                            {
                                action = base.RedirectToAction("InsertDone", (object)new
                                {
                                    documentId = response.DocumentId,
                                    documentNo = response.DocumentNo
                                });
                            }
                        }
                        return (ActionResult)this.RedirectToAction("InsertDone", (object)new
                        {
                            documentId = response.DocumentId,
                            documentNo = response.DocumentNo
                        });
                    }
                    return (ActionResult)this.RedirectToAction("InsertDone", (object)new
                    {
                        documentId = response.DocumentId,
                        documentNo = response.DocumentNo
                    });
                }
                return (ActionResult)this.View((object)objManifest);
            }
            else
                return (ActionResult)this.View((object)objManifest);
            

        }

        public ActionResult InsertDone()
        {
            return (ActionResult)this.View();
        }

        [HttpPost]
        public JsonResult GetDocketListForManifest(
          byte companyId,
          short locationId,
          string docketList,
          DateTime fromDate,
          DateTime toDate,
          byte transportModeId,
          int fromCityId,
          int toCityId,
          string toLocationList,
          string zoneList,
          short vendorId)
        {
            return this.Json((object)this.manifestRepository.GetDocketListForManifest(companyId, locationId, docketList, fromDate, toDate, transportModeId, fromCityId, toCityId, toLocationList, zoneList, vendorId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cancellation()
        {
            return (ActionResult)this.View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Cancellation(ManifestCancellation objManifestCancellation)
        {
            if (this.ModelState.IsValid)
            {
                objManifestCancellation.LocationId = SessionUtility.LoginLocationId;
                objManifestCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objManifestCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objManifestCancellation.Details.RemoveAll((Predicate<ManifestCancellationDetails>)(m => !m.IsChecked));
                if (this.manifestRepository.Cancellation(objManifestCancellation).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("CancellationDone", "Docket", (object)new
                    {
                        status = "ManifestCancel"
                    });
            }
            return (ActionResult)this.View((object)objManifestCancellation);
        }

        [HttpPost]
        public JsonResult GetManifestListForCancellation(
          string manifestNos,
          string manualManifestNos,
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.manifestRepository.GetManifestListForCancellation(manifestNos, manualManifestNos, fromDate, toDate, SessionUtility.LoginLocationId));
        }

        [HttpPost]
        public JsonResult GetLabourDCListForCancellation(
             string LabourDCNo,
             DateTime fromDate,
             DateTime toDate)
        {
            return this.Json((object)this.manifestRepository.GetLabourDCListForCancellation(LabourDCNo, fromDate, toDate, SessionUtility.LoginLocationId));
        }
        public ActionResult CancellationLabourDC()
        {
            return (ActionResult)this.View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CancellationLabourDC(LabourDCModule objLabourDCCancellation)
        {
            objLabourDCCancellation.LocationId = SessionUtility.LoginLocationId;
            objLabourDCCancellation.LocationCode = SessionUtility.LoginLocationCode;
            objLabourDCCancellation.CancelBy = SessionUtility.LoginUserId;
            objLabourDCCancellation.Details.RemoveAll((Predicate<LabourDCModule>)(m => !m.IsLabourDCChecked));
            if (this.manifestRepository.CancellationLabourDC(objLabourDCCancellation).IsSuccessfull)
                return (ActionResult)this.RedirectToAction("CancellationDone", "Docket", (object)new
                {
                    status = "LabourDCCancel"
                });

            return (ActionResult)this.View((object)objLabourDCCancellation);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.manifestRepository.Dispose();
            base.Dispose(disposing);
            if (disposing)
                this.generalRepository.Dispose();
            base.Dispose(disposing);
            if (disposing)
                this.locationRepository.Dispose();
            base.Dispose(disposing);
            if (disposing)
                this.zoneRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
