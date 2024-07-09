//  
// Type: CodeLock.Areas.Finance.Controllers.VendorPaymentController
//  
//  
//  

using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web;

namespace CodeLock.Areas.Finance.Controllers
{
  public class VendorPaymentController : Controller
  {
    private readonly IVendorPaymentRepository vendorPaymentRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly IAccountRepository accountRepository;
    private readonly ICompanyRepository companyRepository;
    private readonly ILocationRepository locationRepository;
    private readonly IGstRepository gstRepository;
    private readonly IVendorRepository vendorRepository;

        public VendorPaymentController(
      IVendorPaymentRepository _vendorPaymentRepository,
      IGeneralRepository _generalRepository,
      IAccountRepository _accountRepository,
      ICompanyRepository _companyRepository,
      ILocationRepository _locationRepository,
      IGstRepository _gstRepository,
      IVendorRepository _vendorRepository)
    {
      this.vendorPaymentRepository = _vendorPaymentRepository;
      this.generalRepository = _generalRepository;
      this.accountRepository = _accountRepository;
      this.companyRepository = _companyRepository;
      this.locationRepository = _locationRepository;
      this.gstRepository = _gstRepository;
      this.vendorRepository = _vendorRepository;
    }
        public ActionResult VendorBillCancellation()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationListByLocationId(SessionUtility.LoginLocationId, SessionUtility.LoginUserLocationId);
            return base.View();
        }

        [HttpPost]
        public ActionResult VendorBillCancellation(VendorBillCancellation objBillBillCancellation)
        {
            ActionResult action;
            objBillBillCancellation.LocationId = SessionUtility.LoginLocationId;
            objBillBillCancellation.LocationCode = SessionUtility.LoginLocationCode;
            objBillBillCancellation.EntryBy = SessionUtility.LoginUserId;
            objBillBillCancellation.CompanyId = SessionUtility.CompanyId;
            objBillBillCancellation.FinYear = SessionUtility.FinYear;
            objBillBillCancellation.BillDetail = (
                from m in objBillBillCancellation.BillDetail
                where m.IsChecked
                select m).ToList<VendorBillCancelDetail>();
            if (!this.vendorPaymentRepository.VendorBillCancellation(objBillBillCancellation).IsSuccessfull)
            {
                action = base.View(objBillBillCancellation);
            }
            else
            {
                action = base.RedirectToAction("VendorBillCancellationDone");
            }
            return action;
        }

        [HttpPost]
        public JsonResult GetBillListForBillCancellation(short vendorId, DateTime fromDate, DateTime toDate, string billNo)
        {
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.GetBillListForBillCancellation(vendorId, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, billNo));
            return jsonResult;
        }

        public ActionResult VendorBillCancellationDone()
        {
            return base.View();
        }
        public ActionResult AdvancePayment()
        {
            this.Init();
            VendorAdvancePayment vendorAdvancePayment = new VendorAdvancePayment()
            {
                DocumentTypes = this.generalRepository.GetByGeneralList(32).ToArray<MasterGeneral>()
            };
            return base.View(vendorAdvancePayment);
        }

        [HttpPost]
        public ActionResult AdvancePayment(VendorAdvancePayment objVendorAdvancePayment)
        {
            objVendorAdvancePayment.CompanyId = SessionUtility.CompanyId;
            objVendorAdvancePayment.EntryBy = SessionUtility.LoginUserId;
            objVendorAdvancePayment.EntryDate = DateTime.Now;
            objVendorAdvancePayment.FinYear = SessionUtility.FinYear;
            objVendorAdvancePayment.LocationId = SessionUtility.LoginLocationId;
            objVendorAdvancePayment.LocationCode = SessionUtility.LoginLocationCode;
            if (objVendorAdvancePayment.PaymentDetails.PaymentMode == 8)
            {
                objVendorAdvancePayment.PaymentDetails.CashAccountId = objVendorAdvancePayment.PaymentDetails.BaAccountID;
            }
            Response response = this.vendorPaymentRepository.AdvancePaymentInsert(objVendorAdvancePayment);
            ActionResult action = base.RedirectToAction("AdvancePaymentDone", new { PaymentId = response.DocumentId, PaymentNo = response.DocumentNo, voucherId = response.DocumentId2, voucherNo = response.DocumentNo2 });
            return action;
        }

        public ActionResult AdvancePaymentDone()
        {
            return base.View();
        }

        public ActionResult BaBillEntry()
        {
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            return base.View();
        }

        public ActionResult BillEntryDone()
        {
            return base.View();
        }


        


        public ActionResult VendorBillFinalization()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationListByLocationId(SessionUtility.LoginLocationId, SessionUtility.LoginUserLocationId);
            return base.View();
        }


        [HttpPost]
        public ActionResult VendorBillFinalization(VendorBillFinalizationProcess objBillFinalization)
        {
            ActionResult action;
            objBillFinalization.LocationId = SessionUtility.LoginLocationId;
            objBillFinalization.LocationCode = SessionUtility.LoginLocationCode;
            objBillFinalization.EntryBy = SessionUtility.LoginUserId;
            objBillFinalization.CompanyId = SessionUtility.CompanyId;
            objBillFinalization.FinYear = SessionUtility.FinYear;
            objBillFinalization.BillDetail = (
                from m in objBillFinalization.BillDetail
                where m.IsChecked
                select m).ToList<FinalizationBillDetail>();
            if (!this.vendorPaymentRepository.VendorBillFinalization(objBillFinalization).IsSuccessfull)
            {
                action = base.View(objBillFinalization);
            }
            else
            {
                action = base.RedirectToAction("VendorBillFinalizationDone");
            }
            return action;
        }

        public ActionResult VendorBillFinalizationV1()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationListByLocationId(SessionUtility.LoginLocationId, SessionUtility.LoginUserLocationId);
            return base.View();
        }


        [HttpPost]
        public ActionResult VendorBillFinalizationV1(VendorBillFinalizationProcess objBillFinalization)
        {
            ActionResult action;
            objBillFinalization.LocationId = SessionUtility.LoginLocationId;
            objBillFinalization.LocationCode = SessionUtility.LoginLocationCode;
            objBillFinalization.EntryBy = SessionUtility.LoginUserId;
            objBillFinalization.CompanyId = SessionUtility.CompanyId;
            objBillFinalization.FinYear = SessionUtility.FinYear;
            objBillFinalization.BillDetail = (
                from m in objBillFinalization.BillDetail
                where m.IsChecked
                select m).ToList<FinalizationBillDetail>();
            if (!this.vendorPaymentRepository.VendorBillFinalizationV1(objBillFinalization).IsSuccessfull)
            {
                action = base.View(objBillFinalization);
            }
            else
            {
                action = base.RedirectToAction("VendorBillFinalizationDone");
            }
            return action;
        }


        public ActionResult VendorBillFinalizationDone()
        {
            return base.View();
        }


        public ActionResult BillPayment()
        {
            this.Init();
            return base.View();
        }

        [HttpPost]
        public ActionResult BillPayment(VendorBillPayment objVendorBillPayment)
        {
            Response response = new Response();
            objVendorBillPayment.EntryBy = SessionUtility.LoginUserId;
            objVendorBillPayment.EntryDate = DateTime.Now;
            objVendorBillPayment.LocationId = SessionUtility.LoginLocationId;
            objVendorBillPayment.CompanyId = SessionUtility.CompanyId;
            objVendorBillPayment.FinYear = SessionUtility.FinYear;
            if (objVendorBillPayment.PaymentDetails.PaymentMode == 8)
            {
                objVendorBillPayment.PaymentDetails.CashAccountId = objVendorBillPayment.PaymentDetails.BaAccountID;

            }
            response = this.vendorPaymentRepository.BillPayment(objVendorBillPayment);
            ActionResult action = base.RedirectToAction("BillPaymentDone", new { PaymentId = response.DocumentId, PaymentNo = response.DocumentNo, voucherId = response.DocumentId2, voucherNo = response.DocumentNo2, billType = objVendorBillPayment.VendorServiceId });
            return action;
        }

        public ActionResult BillPaymentDone()
        {
            return base.View();
        }

        public ActionResult GetValidChangeAdvanceBalanceLocation()
        {
            return base.View();
        }

        

        public ActionResult ChangeAdvanceBalanceLocation(string DocumentNo)
        {
            ((dynamic)base.ViewBag).VendorList = this.vendorRepository.GetVendorNameList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ChangeAdvanceBalanceLocation changeAdvanceBalanceLocation = new ChangeAdvanceBalanceLocation()
            {
                DocumentNo = DocumentNo.ConvertToString()
                

            };
            
            List<ThcAdvBalPaymnt_Details> MultiAdvDtl = new List<ThcAdvBalPaymnt_Details>();
            MultiAdvDtl = this.vendorPaymentRepository.GetMultiAdvanceBalanceData(DocumentNo).ToList<ThcAdvBalPaymnt_Details>();
            if(MultiAdvDtl.Count==0)
            {
                changeAdvanceBalanceLocation.AdvBalPmtDtl.Add(new ThcAdvBalPaymnt_Details());
            }
            else
            {
                changeAdvanceBalanceLocation.AdvBalPmtDtl = MultiAdvDtl;
            }
            
            //changeAdvanceBalanceLocation.AdvBalPmtDtl.Add(new ThcAdvBalPaymnt_Details());
            return base.View(changeAdvanceBalanceLocation);
        }

        [HttpPost]
        public ActionResult ChangeAdvanceBalanceLocation(ChangeAdvanceBalanceLocation objChangeAdvanceBalanceLocation)
        {
            objChangeAdvanceBalanceLocation.UpdateBy = new short?(SessionUtility.LoginUserId);
            Response response = new Response();
            response = this.vendorPaymentRepository.ChangeAdvanceBalanceLocation(objChangeAdvanceBalanceLocation);
            return base.RedirectToAction("ChangeAdvanceBalanceLocationDone");
        }

        public ActionResult ChangeAdvanceBalanceLocationDone()
        {
            return base.View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.vendorPaymentRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.accountRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.companyRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.locationRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.gstRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetBillCharges()
        {
            return base.Json(this.vendorPaymentRepository.GetBillCharges());
        }


        [HttpPost]
        public JsonResult GetBillDetailForBillPayment(string billId)
        {
            return base.Json(this.vendorPaymentRepository.GetBillDetailForBillPayment(billId));
        }

        [HttpPost]
        public JsonResult GetBillListForBillFinalization(short locationId, short vendorId, DateTime fromDate, DateTime toDate, string billNo)
        {
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.GetBillListForBillFinalization(locationId, vendorId, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, billNo));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetBillListForPayment(VendorBillPayment objVendorBillPayment)
        {
            return base.Json(this.vendorPaymentRepository.GetBillListForBillPayment(objVendorBillPayment));
        }

        [HttpPost]
        public JsonResult GetDocumentDetailForAdvancePayment(List<VendorDocument> objVendorDocument)
        {
            
            return base.Json(this.vendorPaymentRepository.GetDocumentDetailForAdvancePayment(objVendorDocument, SessionUtility.LoginLocationId));
        }

        [HttpPost]
        public JsonResult GetDocumentDetailForBaBillGeneration(List<long> DocketId)
        {
            return base.Json(this.vendorPaymentRepository.GetDocumentDetailForBaBillGeneration(DocketId));
        }

        [HttpPost]
        public JsonResult GetDocumentDetailForVehicleHireBillGeneration(List<VendorDocument> objVendorDocument)
        {
            return base.Json(this.vendorPaymentRepository.GetDocumentDetailForVehicleHireBillGeneration(objVendorDocument));
        }

        [HttpPost]
        public JsonResult GetDocumentListForAdvancePayment(VendorAdvancePayment objVendorAdvancePayment)
        {
            return base.Json(this.vendorPaymentRepository.GetDocumentListForAdvancePayment(objVendorAdvancePayment));
        }

        [HttpPost]
        public JsonResult GetDocumentListForBaBillGeneration(short VendorId, DateTime FromDate, DateTime ToDate, string DocumentNo)
        {
            return base.Json(this.vendorPaymentRepository.GetDocumentListForBaBillGeneration(VendorId, FromDate, ToDate, DocumentNo, SessionUtility.LoginLocationId));
        }

        [HttpPost]
        public JsonResult GetDocumentListForVehicleHireBillGeneration(VendorBillGeneration objVendorBillGeneration)
        {
            objVendorBillGeneration.LocationId = SessionUtility.LoginLocationId;
            return base.Json(this.vendorPaymentRepository.GetDocumentListForVehicleHireBillGeneration(objVendorBillGeneration));
        }

        private void Init()
        {
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).BankAccountList = this.accountRepository.GetAccountListByAccountCategoryId(6);
            ((dynamic)base.ViewBag).CashAccountList = this.accountRepository.GetAccountListByAccountCategoryId(5);
        }

        public ActionResult OtherBillEntry()
        {
            OtherBillEntry otherBillEntry = new OtherBillEntry();
            otherBillEntry.BillAccountDetails.Add(new BillAccountDetail());
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetVirtualLoginCompanyList(SessionUtility.LoginUserId);
            ((dynamic)base.ViewBag).CostCenterTypeId = this.generalRepository.GetByIdList(33);
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            ((dynamic)base.ViewBag).GstTypeList = this.generalRepository.GetByIdList(61);
            ((dynamic)base.ViewBag).GstServiceTypeList = this.gstRepository.GetSacList();
            ((dynamic)base.ViewBag).GstExemptedCategoryList = this.generalRepository.GetByIdList(62);
            ((dynamic)base.ViewBag).SacList = this.gstRepository.GetSacList();
            return base.View(otherBillEntry);
        }

        [HttpPost]
        public ActionResult OtherBillEntry(OtherBillEntry objOtherBillEntry)
        {
            ActionResult action;
            objOtherBillEntry.LocationId = SessionUtility.LoginLocationId;
            objOtherBillEntry.LocationCode = SessionUtility.LoginLocationCode;
            objOtherBillEntry.EntryBy = SessionUtility.LoginUserId;
            objOtherBillEntry.EntryDate = DateTime.Now;
            objOtherBillEntry.CompanyId = SessionUtility.CompanyId;
            VendorPaymentDone vendorPaymentDone = new VendorPaymentDone();
            Response response = this.vendorPaymentRepository.OtherBillInsert(objOtherBillEntry);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetVirtualLoginCompanyList(SessionUtility.LoginUserId);
                ((dynamic)base.ViewBag).CostCenterTypeId = this.generalRepository.GetByIdList(33);
                ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
                ((dynamic)base.ViewBag).GstTypeList = this.generalRepository.GetByIdList(61);
                ((dynamic)base.ViewBag).GstServiceTypeList = this.gstRepository.GetSacList();
                ((dynamic)base.ViewBag).GstExemptedCategoryList = this.generalRepository.GetByIdList(62);
                ((dynamic)base.ViewBag).SacList = this.gstRepository.GetSacList();
                action = base.View(objOtherBillEntry);
            }
            else
            {
                action = base.RedirectToAction("BillEntryDone", new { billId = response.DocumentId, billNo = response.DocumentNo, status = "OtherBillEntry" });
            }
            return action;
        }

        public ActionResult Upload()
        {
            return base.View(new VendorBillUpload());
        }


        [HttpPost]
        public ActionResult Upload(VendorBillUpload objVendorBillUpload)
        {
            VendorBillUpload vendorBillUpload = new VendorBillUpload()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            VendorBillUpload vendorBillUpload1 = vendorBillUpload;
            if (objVendorBillUpload.File != null)
            {
                vendorBillUpload1 = this.vendorPaymentRepository.InsertVendorBill(objVendorBillUpload);
            }
            return base.View(vendorBillUpload1);
        }

        [HttpPost]
        public JsonResult ValidateDocumentIdForAdvanceBalanceLocation(string DocumentNo)
        {
            return base.Json(this.vendorPaymentRepository.ValidateDocumentIdForAdvanceBalanceLocation(DocumentNo));
        }

        public ActionResult VehicleHireBillEntry()
        {
            VendorBillGeneration vendorBillGeneration = new VendorBillGeneration()
            {
                DocumentType = this.generalRepository.GetByGeneralList(32).ToArray<MasterGeneral>()
            };
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            ((dynamic)base.ViewBag).GstTypeList = this.generalRepository.GetByIdList(61);
            ((dynamic)base.ViewBag).GstServiceTypeList = this.gstRepository.GetSacList();
            ((dynamic)base.ViewBag).GstExemptedCategoryList = this.generalRepository.GetByIdList(62);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).TDSRuleList = this.generalRepository.GetByIdList(304);
            return base.View(vendorBillGeneration);
        }

        [HttpPost]
        public ActionResult VehicleHireBillEntry(VendorBillGeneration objVendorBillGeneration)
        {
            ActionResult action;
            int DocumentTypeId;
            objVendorBillGeneration.LocationId = SessionUtility.LoginLocationId;
            objVendorBillGeneration.LocationCode = SessionUtility.LoginLocationCode;
            objVendorBillGeneration.EntryBy = SessionUtility.LoginUserId;
            objVendorBillGeneration.EntryDate = DateTime.Now;
            objVendorBillGeneration.CompanyId = SessionUtility.CompanyId;
            objVendorBillGeneration.ChargeList = JsonConvert.DeserializeObject<List<VendorBillCharge>>(objVendorBillGeneration.VendorChargeList);
            VendorPaymentDone vendorPaymentDone = new VendorPaymentDone();

            DocumentTypeId = 0;
            foreach (var item in objVendorBillGeneration.Details)
            {
                DocumentTypeId = Convert.ToInt32(item.DocumentTypeId);
            }

            if (DocumentTypeId == 13)
            {
                objVendorBillGeneration.Details.RemoveAll((VendorDocument m) => !m.IsChecked);
            }

            Response response = this.vendorPaymentRepository.VehicleHireBillInsert(objVendorBillGeneration);
            if (!response.IsSuccessfull)
            {
                action = base.View(objVendorBillGeneration);
            }
            else
            {
                action = base.RedirectToAction("BillEntryDone", new { billId = response.DocumentId, billNo = response.DocumentNo, status = "VehicleHireBillEntry" , documentTypeId = DocumentTypeId });
            }
            return action;
        }
        public ActionResult BillGeneration()
        {
            VendorBillGeneration vendorBillGeneration = new VendorBillGeneration()
            {
                DocumentType = this.generalRepository.GetByGeneralList(32).ToArray<MasterGeneral>()
            };
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            ((dynamic)base.ViewBag).GstTypeList = this.generalRepository.GetByIdList(61);
            ((dynamic)base.ViewBag).GstServiceTypeList = this.gstRepository.GetSacList();
            ((dynamic)base.ViewBag).GstExemptedCategoryList = this.generalRepository.GetByIdList(62);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            return base.View(vendorBillGeneration);
        }

        [HttpPost]
        public ActionResult BillGeneration(VendorBillGeneration objVendorBillGeneration)
        {
            ActionResult action;
            int DocumentTypeId;
            objVendorBillGeneration.LocationId = SessionUtility.LoginLocationId;
            objVendorBillGeneration.LocationCode = SessionUtility.LoginLocationCode;
            objVendorBillGeneration.EntryBy = SessionUtility.LoginUserId;
            objVendorBillGeneration.EntryDate = DateTime.Now;
            objVendorBillGeneration.CompanyId = SessionUtility.CompanyId;
            objVendorBillGeneration.ChargeList = JsonConvert.DeserializeObject<List<VendorBillCharge>>(objVendorBillGeneration.VendorChargeList);
            VendorPaymentDone vendorPaymentDone = new VendorPaymentDone();

            DocumentTypeId = 0;
            foreach (var item in objVendorBillGeneration.Details)
            {
                DocumentTypeId = Convert.ToInt32(item.DocumentTypeId);
            }

            if (DocumentTypeId == 13)
            {
                objVendorBillGeneration.Details.RemoveAll((VendorDocument m) => !m.IsChecked);
            }

            Response response = this.vendorPaymentRepository.VehicleHireBillInsert(objVendorBillGeneration);
            if (!response.IsSuccessfull)
            {
                action = base.View(objVendorBillGeneration);
            }
            else
            {
                action = base.RedirectToAction("BillEntryDone", new { billId = response.DocumentId, billNo = response.DocumentNo, status = "VehicleHireBillEntry", documentTypeId = DocumentTypeId });
            }
            return action;
        }
        public ActionResult VendorBillPaymentCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendorBillPaymentCancellation(VendorBillPaymentCancellation objVendorBillPaymentCancellation)
        {
            ActionResult action;
            Response response = new Response();
            objVendorBillPaymentCancellation.Details.RemoveAll((PaymentCancellationDetail m) => !m.IsChecked);
            objVendorBillPaymentCancellation.Details.ForEach((PaymentCancellationDetail m) => m.CancelBy = new short?(SessionUtility.LoginUserId));
            if (!this.vendorPaymentRepository.VendorBillPaymentCancellation(objVendorBillPaymentCancellation).IsSuccessfull)
            {
                action = base.View(objVendorBillPaymentCancellation);
            }
            else
            {
                action = base.RedirectToAction("VendorBillPaymentCancellationDone");
            }
            return action;
        }
        public ActionResult VendorBillPaymentCancellationDone()
        {
            return base.View();
        }

        public JsonResult GetBillPaymentForCancellation(string PaymentNos, DateTime fromDate, DateTime toDate)
        {
            short loginLocationId;
            if ((new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y")
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            short num = loginLocationId;
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.GetVendorBillPaymentCancellation(PaymentNos, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }




        public ActionResult VendorAdvancePaymentCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendorAdvancePaymentCancellation(VendorAdvancePaymentCancellation objVendorAdvancePaymentCancellation)
        {
            ActionResult action;
            Response response = new Response();
            objVendorAdvancePaymentCancellation.Details.RemoveAll((PaymentCancellationDetail m) => !m.IsChecked);
            objVendorAdvancePaymentCancellation.Details.ForEach((PaymentCancellationDetail m) => m.CancelBy = new short?(SessionUtility.LoginUserId));
            if (!this.vendorPaymentRepository.VendorAdvancePaymentCancellation(objVendorAdvancePaymentCancellation).IsSuccessfull)
            {
                action = base.View(objVendorAdvancePaymentCancellation);
            }
            else
            {
                action = base.RedirectToAction("VendorAdvancePaymentCancellationDone");
            }
            return action;
        }
        public ActionResult VendorAdvancePaymentCancellationDone()
        {
            return base.View();
        }

        public JsonResult GetAdvancePaymentForCancellation(string PaymentNos, DateTime fromDate, DateTime toDate)
        {
            short loginLocationId;
            if ((new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y")
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            short num = loginLocationId;
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.GetVendorAdvancePaymentCancellation(PaymentNos, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        public ActionResult UploadInSystem()
        {
            return base.View(new VendorBillUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystem(VendorBillUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            VendorBillUploadInSystem docketUploadInSystem = new VendorBillUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            VendorBillUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.vendorPaymentRepository.UploadInSystem(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        public ActionResult LabourDCBillReAssignDone()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult CheckValidBillNoForReAssign(string LabourDCNo)
        {
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.CheckValidBillNoForReAssign(LabourDCNo));
            return jsonResult;
        }

        public ActionResult LabourDCBillReAssign()
        {
            LabourDCModule docketDacc = new LabourDCModule();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();

            return base.View(docketDacc);
        }

        [HttpPost]
        public ActionResult LabourDCBillReAssign(LabourDCModule objDocketDacc)
        {
            objDocketDacc.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            response = this.vendorPaymentRepository.InsertBillReAssign(objDocketDacc);

            if (response.IsSuccessfull)
            {
                return base.RedirectToAction("LabourDCBillReAssignDone");
            }

            return base.View();
        }
        [HttpPost]
        public JsonResult CheckValidVendorBillNoForReAssign(string BillNo)
        {
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.CheckValidVendorBillNoForReAssign(BillNo));
            return jsonResult;
        }
        public ActionResult VendorBillReAssignDone()
        {
            return base.View();
        }

        public ActionResult VendorBillReAssign()
        {
            VendorBillReAssign docketDacc = new VendorBillReAssign();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();

            return base.View(docketDacc);
        }

        [HttpPost]
        public ActionResult VendorBillReAssign(VendorBillReAssign objVendorBillReAssign)
        {
            objVendorBillReAssign.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            response = this.vendorPaymentRepository.InsertVendorBillReAssign(objVendorBillReAssign);

            if (response.IsSuccessfull)
            {
                return base.RedirectToAction("VendorBillReAssignDone");
            }

            return base.View();
        }

        [HttpPost]
        public JsonResult IsOtherManualBillNoExist(short vendorId, string manualBillNo)
        {
            JsonResult jsonResult = base.Json(this.vendorPaymentRepository.IsOtherManualBillNoExist(vendorId,manualBillNo,SessionUtility.FinYear, SessionUtility.LoginLocationId, SessionUtility.CompanyId));
            return jsonResult;
        }
    }
}
