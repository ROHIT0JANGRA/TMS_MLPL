//  
// Type: CodeLock.Areas.Finance.Controllers.TrackingController
//  
//  
//  

using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Controllers
{
  public class TrackingController : Controller
  {
    private readonly ITrackingRepository trackingRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly IRulesRepository rulesRepository;


        public TrackingController(ITrackingRepository _trackingRepository, IGeneralRepository _generalRepository, IRulesRepository _rulesRepository)
        {
            this.trackingRepository = _trackingRepository;
            this.generalRepository = _generalRepository;
            this.rulesRepository = _rulesRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.trackingRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult IndexAllTime()
        {
            FinanceDocumentTracking financeDocumentTracking = new FinanceDocumentTracking();
            ((dynamic)base.ViewBag).BillTypeList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).PartyTypeList = this.generalRepository.GetByIdList(11);
            ((dynamic)base.ViewBag).UseTransportModeFTL = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3);
            return base.View(financeDocumentTracking);
        }

        public JsonResult GetCustomerBillList(short locationId, short customerId, byte billTypeId, DateTime fromDate, DateTime toDate, string documentNos, string manualDocumentNos)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetCustomerBillList(locationId, customerId, billTypeId, fromDate, toDate, documentNos, manualDocumentNos));
            return jsonResult;
        }
        public JsonResult GetDeliveryMrCustomerBillList(short locationId, short customerId, byte billTypeId, DateTime fromDate, DateTime toDate, string documentNos, string manualDocumentNos)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetDeliveryMrCustomerBillList(locationId, customerId, billTypeId, fromDate, toDate, documentNos, manualDocumentNos));
            return jsonResult;
        }
        

        public JsonResult GetDeliveryMrList(short locationId, short customerId, DateTime fromDate, DateTime toDate, string documentNos, string manualDocumentNos)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetDeliveryMrList(locationId, customerId, fromDate, toDate, documentNos, manualDocumentNos));
            return jsonResult;
        }

        public JsonResult GetMrList(short locationId, short customerId, DateTime fromDate, DateTime toDate, string documentNos, string manualDocumentNos)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetMrList(locationId, customerId, fromDate, toDate, documentNos, manualDocumentNos));
            return jsonResult;
        }

        public JsonResult GetVendorBillList(short locationId, short customerId, byte billTypeId, DateTime fromDate, DateTime toDate, string documentNos, string manualDocumentNos)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetVendorBillList(locationId, customerId, billTypeId, fromDate, toDate, documentNos, manualDocumentNos));
            return jsonResult;
        }

        public JsonResult GetVendorBillPaymentList(short locationId, byte billTypeId, DateTime fromDate, DateTime toDate, string documentNos)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetVendorBillPaymentList(locationId, billTypeId, fromDate, toDate, documentNos));
            return jsonResult;
        }

        public JsonResult GetVoucherList(short locationId, DateTime fromDate, DateTime toDate, string documentNo, string manualDocumentNo, byte partyType, string partyName)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetVoucherList(locationId, fromDate, toDate, documentNo, manualDocumentNo, partyType, (partyName == null ? "" : partyName)));
            return jsonResult;
        }

        public JsonResult GetCreditDebitNoteList(short locationId, DateTime fromDate, DateTime toDate, string documentNo, string manualDocumentNo, short partyId, byte noteTypeId)
        {
            JsonResult jsonResult = base.Json(this.trackingRepository.GetCreditDebitNoteList(locationId, fromDate, toDate, documentNo, manualDocumentNo, partyId, noteTypeId));
            return jsonResult;
        }

        public ActionResult Index()
        {
            FinanceDocumentTracking financeDocumentTracking = new FinanceDocumentTracking();
            ((dynamic)base.ViewBag).BillTypeList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).PartyTypeList = this.generalRepository.GetByIdList(11);
            ((dynamic)base.ViewBag).UseTransportModeFTL = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3);
            return base.View(financeDocumentTracking);
        }

        public ActionResult IndexSlpl()
        {
            FinanceDocumentTracking financeDocumentTracking = new FinanceDocumentTracking();
            ((dynamic)base.ViewBag).BillTypeList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).PartyTypeList = this.generalRepository.GetByIdList(11);
            ((dynamic)base.ViewBag).UseTransportModeFTL = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3);
            return base.View(financeDocumentTracking);
        }


    }
}
