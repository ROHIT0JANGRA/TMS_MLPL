using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.IO;
using Dapper;
using System.Xml.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.VariantTypes;
using System.Net;

namespace CodeLock.Areas.Operation.Controllers
{
    public class DrsController : Controller
    {
        private readonly IDrsRepository drsRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ITrackingRepository trackingRepository;
        private readonly IDocketRepository docketRepository;
        private readonly IRulesRepository rulesRepository;

        public DrsController()
        {
        }

        public DrsController(IDrsRepository _drsRepository, IGeneralRepository _generalRepository, IVehicleTypeRepository _vehicleTypeRepository, ILocationRepository _locationRepository, ITrackingRepository _trackingRepository, IDocketRepository _docketRepository, IRulesRepository _rulesRepository)
        {
            this.drsRepository = _drsRepository;
            this.generalRepository = _generalRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.locationRepository = _locationRepository;
            this.trackingRepository = _trackingRepository;
            this.docketRepository = _docketRepository;
            this.rulesRepository = _rulesRepository;
        }

        public ActionResult Cancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation(DrsCancellation objDrsCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objDrsCancellation);
            }
            else
            {
                objDrsCancellation.LocationId = SessionUtility.LoginLocationId;
                objDrsCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objDrsCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objDrsCancellation.Details.RemoveAll((DrsCancellationDetails m) => !m.IsChecked);
                this.drsRepository.Cancellation(objDrsCancellation);
                action = base.RedirectToAction("CancellationDone", "Docket", new { status = "DrsCancel" });
            }
            return action;
        }

        [HttpPost]
        public JsonResult CheckValidDrsNo(string drsNo)
        {
            return base.Json(this.drsRepository.CheckValidDrsNo(drsNo));
        }

        public ActionResult Close()
        {
            DrsClose drsClose = new DrsClose();
            ((dynamic)base.ViewBag).LateDeliveryReasonList = JsonConvert.SerializeObject((new GeneralRepository()).GetByIdList(40));
            ((dynamic)base.ViewBag).PartDeliveryReasonList = JsonConvert.SerializeObject((new GeneralRepository()).GetByIdList(41));
            ((dynamic)base.ViewBag).UnDeliveryReasonList = JsonConvert.SerializeObject((new GeneralRepository()).GetByIdList(42));
            return base.View(drsClose);
        }

        [HttpPost]
        public ActionResult Close(DrsClose objDrs)
        {
            ActionResult action;
            objDrs.UpdateBy = new short?(SessionUtility.LoginUserId);
            Response response = this.drsRepository.Close(objDrs);
            if (!response.IsSuccessfull)
            {
                action = base.View(objDrs);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 81) == "Y")
                {
                    foreach (var docket in objDrs.DocketDetails)
                    {
                        if (docket.DeliveredPackages == 0)
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
                                ExceptionUtility.LogException(ex, "Call Fareye Webhook", SessionUtility.LoginUserId, nameof(Close));
                            }
                            finally
                            {
                                action = base.RedirectToAction("CloseDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
                            }
                        }
                    }
                }
                action = base.RedirectToAction("CloseDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult CloseDone()
        {
            return base.View();
        }


        [HttpPost]
        public JsonResult GetChargeList(long drsId)
        {
            return base.Json(this.drsRepository.GetChargeList(drsId));
        }

        [HttpPost]
        public JsonResult GetDocketList(DateTime fromDate, DateTime toDate, byte paybasId, byte transportModeId, byte busnessTypeId, bool isOda, string docketNos, short vendorId, bool isDeliveryThroughSameVehicle)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetDocketList(fromDate, toDate, paybasId, transportModeId, busnessTypeId, isOda, docketNos, vendorId, SessionUtility.LoginLocationId, SessionUtility.CompanyId, isDeliveryThroughSameVehicle), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketListForUpdateDrs(long drsId, DateTime fromDate, DateTime toDate, byte paybasId, byte transportModeId, byte busnessTypeId, bool isOda, string docketNos, short vendorId, bool isDeliveryThroughSameVehicle)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetDocketListForUpdateDrs(drsId, fromDate, toDate, paybasId, transportModeId, busnessTypeId, isOda, docketNos, vendorId, SessionUtility.LoginLocationId, SessionUtility.CompanyId, isDeliveryThroughSameVehicle), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDrsDocketListById(long drsId)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetDrsDocketListById(drsId, SessionUtility.LoginLocationId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetDrsListForCancellation(string drsNo, string manualDrsNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetDrsListForCancellation(drsNo, manualDrsNo, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDrsListForDrsUpdate(string drsNos, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetDrsListForDrsUpdate(drsNos, fromDate, toDate, SessionUtility.LoginLocationId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetReasonList()
        {
            DrsDeliveryReasonList drsDeliveryReasonList = new DrsDeliveryReasonList()
            {
                Late = this.generalRepository.GetByIdList(40).ToList<AutoCompleteResult>(),
                Part = this.generalRepository.GetByIdList(41).ToList<AutoCompleteResult>(),
                Un = this.generalRepository.GetByIdList(42).ToList<AutoCompleteResult>()
            };
            return base.Json(drsDeliveryReasonList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStep2DetailById(long drsId)
        {
            return base.Json(this.drsRepository.GetStep2DetailById(drsId));
        }

        public JsonResult GetStep3DetailById(long drsId)
        {
            return base.Json(this.drsRepository.GetStep3DetailById(drsId));
        }

        public JsonResult GetStep4DetailById(long drsId)
        {
            return base.Json(this.drsRepository.GetStep4DetailById(drsId));
        }

        public JsonResult GetStep5DetailById(long drsId)
        {
            return base.Json(this.drsRepository.GetStep5DetailById(drsId));
        }

        public JsonResult GetStep6DetailById(long drsId)
        {
            return base.Json(this.drsRepository.GetStep6DetailById(drsId));
        }
        public ActionResult Insert(long? id)
        {
            Drs dr = new Drs();
            ((dynamic)base.ViewBag).DrsId = id;
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).BookedByList = this.drsRepository.GetBookedByList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).FTLTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            dr.AdvBalPmtDtl.Add(new DrsAdvBalPaymnt_Details());
            dr.DrsDocketList.Add(new DrsDocket());
            dr.ErrorList.Add(new DrsDocket());
            return base.View(dr);
        }

        [HttpPost]
        public ActionResult Insert(Drs objDrs)
        {
            Response response;
            ActionResult action;
            objDrs.EntryBy = SessionUtility.LoginUserId;
            objDrs.EntryDate = DateTime.Now;
            objDrs.LocationId = SessionUtility.LoginLocationId;
            objDrs.LocationCode = SessionUtility.LoginLocationCode;
            objDrs.CompanyId = SessionUtility.CompanyId;
            objDrs.FinYear = SessionUtility.FinYear;
            objDrs.DrsDocketList.RemoveAll((DrsDocket m) => !m.IsChecked);
            response = (objDrs.DrsId <= (long)0 ? this.drsRepository.Insert(objDrs) : this.drsRepository.Update(objDrs));
            if (!response.IsSuccessfull)
            {
                action = base.View(objDrs);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 201) == "Y")
                {
                    string EntryBy = SessionUtility.LoginUserId.ToString();

                    Task<TaxProEwayConsolidateApiResponse> taskEx = Task.Run<TaxProEwayConsolidateApiResponse>(async () => await this.docketRepository.TaxProEwayConsolidated(response.DocumentId.ToString(), "DRS", EntryBy));
                    TaxProEwayConsolidateApiResponse objTaskEx = taskEx.Result;

                    if(objTaskEx != null)
                    {
                        if(objTaskEx.IsSuccess == true)
                        {
                            response.DocumentNo3 = objTaskEx.cEwbNo.ToString();
                            response.DocumentId3 =Convert.ToInt64(objTaskEx.cEwbNo);
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

                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 81) == "Y")
                {
                    foreach (var docket in objDrs.DrsDocketList)
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
                            action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
                        }
                    }
                }


                action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
            }
            return action;
        }

        public ActionResult InsertKExpress(long? id)
        {
            Drs dr = new Drs();
            ((dynamic)base.ViewBag).DrsId = id;
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).BookedByList = this.drsRepository.GetBookedByList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).FTLTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            dr.AdvBalPmtDtl.Add(new DrsAdvBalPaymnt_Details());
            return base.View(dr);
        }

        [HttpPost]
        public ActionResult InsertKExpress(Drs objDrs)
        {
            Response response;
            ActionResult action;
            objDrs.EntryBy = SessionUtility.LoginUserId;
            objDrs.EntryDate = DateTime.Now;
            objDrs.LocationId = SessionUtility.LoginLocationId;
            objDrs.LocationCode = SessionUtility.LoginLocationCode;
            objDrs.CompanyId = SessionUtility.CompanyId;
            objDrs.DrsDocketList.RemoveAll((DrsDocket m) => !m.IsChecked);
            response = (objDrs.DrsId <= (long)0 ? this.drsRepository.Insert(objDrs) : this.drsRepository.Update(objDrs));
            if (!response.IsSuccessfull)
            {
                action = base.View(objDrs);
            }
            else
            {
                action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;
        }

        public ActionResult InsertDone()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult InsertDone(string hdnDocumentId, string hdnDocumentType, HttpPostedFileBase fuFileName)
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

        public ActionResult DeliverOrder()
        {
            DeliverOrder deliverOrder = new DeliverOrder();
            return base.View(deliverOrder);
        }

        [HttpPost]
        public ActionResult DeliverOrder(DeliverOrder deliverOrder)
        {
            ActionResult action;
            deliverOrder.EntryBy = SessionUtility.LoginUserId;
            deliverOrder.EntryDate = DateTime.Now;
            deliverOrder.LocationId = SessionUtility.LoginLocationId;
            deliverOrder.CompanyId = SessionUtility.CompanyId;
            //deliverOrder.Items.RemoveAll(m => m.IsChecked == false);
            if (deliverOrder.POD != null)
            {

                string str;
                if (ConfigHelper.IsLocalStorage)
                {
                    str = deliverOrder.DocketId.ToString() + "_" + deliverOrder.POD.FileName;
                    string filename = ConfigHelper.LocalStoragePath + "POD/" + str;
                    deliverOrder.POD.SaveAs(filename);
                }
                else
                {
                    str = AzureStorageHelper.GetFileName("POD", "DOC_TYPE", deliverOrder.DocketNo.ToString(), deliverOrder.DocketId.ToString(), deliverOrder.POD.FileName);
                    AzureStorageHelper.UploadBlob("POD", deliverOrder.POD, str, str);
                }
                deliverOrder.DocumentName = str;
                deliverOrder.POD = (HttpPostedFileBase)null;

            }

            Response response = this.drsRepository.OrderDeliveryInsert(deliverOrder);
            if (!response.IsSuccessfull)
            {
                action = base.View(deliverOrder);
            }
            else
            {
                action = base.RedirectToAction("DeliverOrderDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }
            return action;

        }

        public ActionResult DeliverOrderDone()
        {
            return base.View();
        }
        [HttpPost]
        public JsonResult GetOrderDeliveryDocketList(string docketNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetOrderDeliveryDocketList(docketNo, fromDate, toDate));
            return jsonResult;
        }
        public JsonResult GetOrderDeliveryPartListForDocket(long docketId)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetOrderDeliveryPartListForDocket(docketId));
            return jsonResult;
        }
        public JsonResult GetOrderDeliveryDocketPartDetail(long docketId)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetOrderDeliveryDocketPartDetail(docketId));
            return jsonResult;
        }

        public async Task CallFareyeWebhook(long docketId, string payloadData)
        {
            try
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
            catch (Exception ex)
            {

            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.drsRepository.Dispose();
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
        }
        public JsonResult GetDrsListForDrsCloseCancellation(string drsNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.drsRepository.GetDrsListForDrsCloseCancellation(drsNo,fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }
        public ActionResult DrsCloseCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DrsCloseCancellation(DrsCloseCancellation objDrsCloseCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objDrsCloseCancellation);
            }
               var response= this.drsRepository.DrsCloseCancellation(objDrsCloseCancellation.DrsId, objDrsCloseCancellation.CancelReason, objDrsCloseCancellation.CancelDate, SessionUtility.LoginUserId, SessionUtility.LoginLocationId);
            if (!response.IsSuccessfull)
            {
                action = base.View(objDrsCloseCancellation);
            }
            return RedirectToAction("CancellationDone", "Docket", new {DocumentId = objDrsCloseCancellation.DrsId,status="DRSCloseCancellationDone"});

        }
   


    }
}
