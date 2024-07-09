using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CodeLock.Areas.Operation.Controllers
{
  public class PrsController : Controller
  {
    private readonly IPrsRepository prsRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly IVehicleTypeRepository vehicleTypeRepository;
    private readonly ILocationRepository locationRepository;
    private readonly IDocketRepository docketRepository;
    private readonly IRulesRepository rulesRepository;
        public PrsController()
        {
        }

        public PrsController(IPrsRepository _prsRepository, IGeneralRepository _generalRepository, IVehicleTypeRepository _vehicleTypeRepository, ILocationRepository _locationRepository, IDocketRepository _docketRepository, IRulesRepository _rulesRepository)
        {
            this.prsRepository = _prsRepository;
            this.generalRepository = _generalRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.locationRepository = _locationRepository;
            this.docketRepository = _docketRepository;
            this.rulesRepository = _rulesRepository;
        }

        public ActionResult Cancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation(PrsCancellation objPrsCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objPrsCancellation);
            }
            else
            {
                objPrsCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objPrsCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objPrsCancellation.Details.RemoveAll((PrsCancellationDetails m) => !m.IsChecked);
                this.prsRepository.Cancellation(objPrsCancellation);
                action = base.RedirectToAction("CancellationDone", "Docket", new { status = "PrsCancel" });
            }
            return action;
        }

        [HttpPost]
        public JsonResult CheckValidPrsNo(string prsNo)
        {
            return base.Json(this.prsRepository.CheckValidPrsNo(prsNo));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.prsRepository.Dispose();
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

        public JsonResult GetChargeList(long prsId)
        {
            return base.Json(this.prsRepository.GetChargeList(prsId));
        }

        [HttpPost]
        public JsonResult GetDocketList(string docketNos, DateTime fromDate, DateTime toDate, byte paybasId, byte transportModeId, byte busnessTypeId, string isBookedByBa, short bookedById, bool isPickupThroughSameVehicle)
        {
            JsonResult jsonResult = base.Json(this.prsRepository.GetDocketList(docketNos, fromDate, toDate, paybasId, transportModeId, busnessTypeId, isBookedByBa, bookedById, SessionUtility.LoginLocationId, SessionUtility.CompanyId, isPickupThroughSameVehicle), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketListForUpdatePrs(long prsId, string docketNos, DateTime fromDate, DateTime toDate, byte paybasId, byte transportModeId, byte busnessTypeId, string isBookedByBa, short bookedById, bool isPickupThroughSameVehicle)
        {
            JsonResult jsonResult = base.Json(this.prsRepository.GetDocketListForUpdatePrs(prsId, docketNos, fromDate, toDate, paybasId, transportModeId, busnessTypeId, isBookedByBa, bookedById, SessionUtility.LoginLocationId, SessionUtility.CompanyId, isPickupThroughSameVehicle), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetPrsListForCancellation(string prsNo, string manualPrsNo, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.prsRepository.GetPrsListForCancellation(prsNo, manualPrsNo, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        public JsonResult GetStep2DetailById(long prsId)
        {
            return base.Json(this.prsRepository.GetStep2DetailById(prsId));
        }

        public JsonResult GetStep3DetailById(long prsId)
        {
            return base.Json(this.prsRepository.GetStep3DetailById(prsId));
        }

        public JsonResult GetStep4DetailById(long prsId)
        {
            return base.Json(this.prsRepository.GetStep4DetailById(prsId));
        }

        public JsonResult GetStep5DetailById(long prsId)
        {
            return base.Json(this.prsRepository.GetStep5DetailById(prsId));
        }

        public JsonResult GetStep6DetailById(long prsId)
        {
            return base.Json(this.prsRepository.GetStep6DetailById(prsId));
        }

        public ActionResult Insert(long? id)
        {
             Prs pr = new Prs();
            ((dynamic)base.ViewBag).PrsId = id;
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).BookedByList = this.prsRepository.GetBookedByList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).FTLTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            pr.AdvBalPmtDtl.Add(new PrsAdvBalPaymnt_Details());
            pr.DocketList.Add(new PrsDocket());
            pr.ErrorList.Add(new PrsDocket());
            return base.View(pr);
        }

        [HttpPost]
        public ActionResult Insert(Prs objPRS)
        {
            Response response;
            ActionResult action;
            objPRS.EntryBy = SessionUtility.LoginUserId;
            objPRS.EntryDate = DateTime.Now;
            objPRS.LocationId = SessionUtility.LoginLocationId;
            objPRS.LocationCode = SessionUtility.LoginLocationCode;
            objPRS.CompanyId = SessionUtility.CompanyId;
            objPRS.FinYear = SessionUtility.FinYear;
            objPRS.DocketList.RemoveAll((PrsDocket m) => !m.IsChecked);
            response = (objPRS.PrsId <= (long)0 ? this.prsRepository.Insert(objPRS) : this.prsRepository.Update(objPRS));
            if (!response.IsSuccessfull)
            {
                action = base.View(objPRS);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 201) == "Y")
                {
                    string EntryBy = SessionUtility.LoginUserId.ToString();

                    Task<TaxProEwayConsolidateApiResponse> taskEx = Task.Run<TaxProEwayConsolidateApiResponse>(async () => await this.docketRepository.TaxProEwayConsolidated(response.DocumentId.ToString(), "PRS", EntryBy));
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

                action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
            }
            return action;
        }

        public ActionResult InsertKExpress(long? id)
        {
            Prs pr = new Prs();
            ((dynamic)base.ViewBag).PrsId = id;
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).BookedByList = this.prsRepository.GetBookedByList();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).FTLTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).OverLoadedReasonList = this.generalRepository.GetByIdList(44);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            pr.AdvBalPmtDtl.Add(new PrsAdvBalPaymnt_Details());
            return base.View(pr);
        }

        [HttpPost]
        public ActionResult InsertKExpress(Prs objPRS)
        {
            Response response;
            ActionResult action;
            objPRS.EntryBy = SessionUtility.LoginUserId;
            objPRS.EntryDate = DateTime.Now;
            objPRS.LocationId = SessionUtility.LoginLocationId;
            objPRS.LocationCode = SessionUtility.LoginLocationCode;
            objPRS.CompanyId = SessionUtility.CompanyId;
            objPRS.DocketList.RemoveAll((PrsDocket m) => !m.IsChecked);
            response = (objPRS.PrsId <= (long)0 ? this.prsRepository.Insert(objPRS) : this.prsRepository.Update(objPRS));
            if (!response.IsSuccessfull)
            {
                action = base.View(objPRS);
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

    }
}
