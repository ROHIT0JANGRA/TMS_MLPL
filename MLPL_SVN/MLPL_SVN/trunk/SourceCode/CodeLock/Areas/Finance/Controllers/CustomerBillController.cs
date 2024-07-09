﻿using CodeLock.Areas.Contract.Repository;
using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Controllers
{
    public class CustomerBillController : Controller
    {
        private readonly ICustomerBillRepository customerBillRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IGstRepository gstRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IDocketRepository docketRepository;
        private readonly ICustomerContractRepository customerContractRepository;
        private readonly IRulesRepository rulesRepository;
        private readonly IUserRepository userRepository;
        private readonly ISacRepository sacRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICustomerGroupRepository customerGroupRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly IHsnRepository hsnRepository;
        private readonly IVehicleRepository vehicleRepository;

        public CustomerBillController(ICustomerBillRepository _customerBillRepository, IGeneralRepository _generalRepository,
             IAccountRepository _accountRepository, IGstRepository _gstRepository,
             ICustomerRepository _customerRepository, IDocketRepository _docketRepository,
             ICustomerContractRepository _customerContractRepository,
             IRulesRepository _rulesRepository,
             IUserRepository _userRepository,
             ISacRepository _sacRepository,
             ILocationRepository _locationRepository, ICustomerGroupRepository _customerGroupRepository,
             IWarehouseRepository _warehouseRepository,
             IHsnRepository _hsnRepository,
             IVehicleRepository _vehicleRepository
             )
        {
            this.customerBillRepository = _customerBillRepository;
            this.generalRepository = _generalRepository;
            this.accountRepository = _accountRepository;
            this.gstRepository = _gstRepository;
            this.customerRepository = _customerRepository;
            this.docketRepository = _docketRepository;
            this.customerContractRepository = _customerContractRepository;
            this.rulesRepository = _rulesRepository;
            this.userRepository = _userRepository;
            this.sacRepository = _sacRepository;
            this.locationRepository = _locationRepository;
            this.customerGroupRepository = _customerGroupRepository;
            this.warehouseRepository = _warehouseRepository;
            this.hsnRepository = _hsnRepository;
            this.vehicleRepository = _vehicleRepository;
        }

        public JsonResult AddDocketList(string DocketNo, string CustomerId, byte TransactionTypeId)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.AddDocketList(DocketNo, CustomerId, TransactionTypeId));
            return jsonResult;
        }


        [HttpPost]
        public JsonResult GetCreditDebitNoteListForCancellation(
          string NoteNo,
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.customerBillRepository.GetCreditDebitNoteListForCancellation(NoteNo, fromDate, toDate, SessionUtility.LoginLocationId));
        }
        public ActionResult CancellationCreditDebitNote()
        {
            return (ActionResult)this.View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CancellationCreditDebitNote(CreditDebitNote objCancellation)
        {
            objCancellation.LocationId = SessionUtility.LoginLocationId;
            objCancellation.CancelBy = SessionUtility.LoginUserId;
            objCancellation.Details.RemoveAll((m => !m.IsChecked));
            if (this.customerBillRepository.CancellationCreditDebitNote(objCancellation).IsSuccessfull)
                return (ActionResult)base.RedirectToAction("SubmissionDone", new { status = "CancellationCreditDebitNote" });


            return (ActionResult)this.View((object)objCancellation);
        }

        public JsonResult CreditDebitNoteBillData(bool isCreditNote, bool isGst, byte billTypeId, string fromDate, string toDate, short partyId, string billNos, string manualBillNos, string transportModeId)
        {
            IEnumerable<CreditDebitNoteDetail> obj = this.customerBillRepository.CreditDebitNoteBillData(isCreditNote, isGst, billTypeId, fromDate, toDate, partyId, billNos, manualBillNos, transportModeId);

            return base.Json(obj);
        }
        public ActionResult CreditDebitNote()
        {
            Session["ClickResponse"] = null;
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);



            ((dynamic)base.ViewBag).NotePurpose = this.generalRepository.GetByIdList(100);
            dynamic obj = base.ViewBag;
            obj.NotePurposeList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).NotePurpose);

            CreditDebitNote creditDebitNote = new CreditDebitNote();
            creditDebitNote.Details.Add(new CreditDebitNoteDetail());
            return base.View(creditDebitNote);
        }

        [HttpPost]
        public ActionResult CreditDebitNote(CreditDebitNote objCreditDebitNote)
        {
            ActionResult action;
            Response response;
            objCreditDebitNote.LocationId = SessionUtility.LoginLocationId;
            objCreditDebitNote.CompanyId = SessionUtility.CompanyId;
            objCreditDebitNote.FinYear = SessionUtility.FinYear;
            objCreditDebitNote.Details = objCreditDebitNote.Details.Where<CreditDebitNoteDetail>((Func<CreditDebitNoteDetail, bool>)(m => m.IsChecked)).ToList<CreditDebitNoteDetail>();
            if (Session["ClickResponse"] == null)
            {
                response = this.customerBillRepository.InsertCreditDebitNote(objCreditDebitNote);
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objCreditDebitNote);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = 20 });
            }
            return action;
        }

        public JsonResult GetDocketListGstForCustomerBillGenerationDumtco(short customerId, DateTime fromDate, DateTime toDate, byte gstServiceTypeId, byte customerGstStateId, byte companyGstStateId, byte paybasId, byte serviceTypeId, byte ftlTypeId, string ManifestId, string VendorId, bool isRcm, string DocketNo)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListGstForCustomerBillGenerationDumtco(customerId, fromDate, toDate, gstServiceTypeId, customerGstStateId, companyGstStateId, paybasId, serviceTypeId, ftlTypeId, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId, ManifestId, VendorId, isRcm, DocketNo));
            return jsonResult;
        }
        public JsonResult GetDocketListGstForCustomerBillGenerationMLPL(short customerId, DateTime fromDate, DateTime toDate, byte gstServiceTypeId, byte customerGstStateId, byte companyGstStateId, byte paybasId, byte serviceTypeId, byte ftlTypeId, string ManifestId, string VendorId, string DocketNo, byte TransactionTypeId)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListGstForCustomerBillGenerationMLPL(customerId, fromDate, toDate, gstServiceTypeId, customerGstStateId, companyGstStateId, paybasId, serviceTypeId, ftlTypeId, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId, ManifestId, VendorId, DocketNo, TransactionTypeId));
            return jsonResult;
        }
/* This controller method and repsository method is responsible for fetch bill data from datatabse  */
        public JsonResult GetDocketListGstForCustomerBillEdit(string BillNo, string DocketNo)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListGstForCustomerBillEdit(loginLocationId, BillNo, DocketNo));
            return jsonResult;
        }
        public ActionResult BillFinalization()
        {
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).CustomerTypeList = this.generalRepository.GetByIdList(303);
            return base.View();
        }

        [HttpPost]
        public ActionResult BillFinalization(BillFinalization objBillFinalization)
        {
            ActionResult action;
            short loginLocationId;
            if (base.ModelState.IsValid)
            {
                bool moduleRuleByIdAndRuleId = false;
                moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
                BillFinalization billFinalization = objBillFinalization;
                if (moduleRuleByIdAndRuleId)
                {
                    loginLocationId = 1;
                }
                else
                {
                    loginLocationId = SessionUtility.LoginLocationId;
                }
                billFinalization.LocationId = loginLocationId;
                objBillFinalization.EntryBy = SessionUtility.LoginUserId;
                objBillFinalization.CompanyId = SessionUtility.CompanyId;
                objBillFinalization.FinYear = SessionUtility.FinYear;
                billFinalization.BillFinalizationRemarks = billFinalization.BillFinalizationRemarks;
                objBillFinalization.Details.RemoveAll((BillFinalizationDetail m) => !m.IsChecked);

                if (this.customerBillRepository.BillFinalization(objBillFinalization).IsSuccessfull)
                {
                    action = base.RedirectToAction("SubmissionDone", new { status = "BillFinalization" });
                    return action;
                }
            }
            action = base.View(objBillFinalization);
            return action;
        }


        public ActionResult BillFinalizationMLPL()
        {
            Session["ClickResponse"] = null;
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            return base.View();
        }

        [HttpPost]
        public ActionResult BillFinalizationMLPL(BillFinalization objBillFinalization)
        {
            ActionResult action;
            Response response;
            short loginLocationId;
            if (base.ModelState.IsValid)
            {
                bool moduleRuleByIdAndRuleId = false;
                moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
                BillFinalization billFinalization = objBillFinalization;
                if (moduleRuleByIdAndRuleId)
                {
                    loginLocationId = 1;
                }
                else
                {
                    loginLocationId = SessionUtility.LoginLocationId;
                }
                billFinalization.LocationId = loginLocationId;
                objBillFinalization.EntryBy = SessionUtility.LoginUserId;
                objBillFinalization.CompanyId = SessionUtility.CompanyId;
                objBillFinalization.FinYear = SessionUtility.FinYear;
                billFinalization.BillFinalizationRemarks = billFinalization.BillFinalizationRemarks;
                objBillFinalization.Details.RemoveAll((BillFinalizationDetail m) => !m.IsChecked);
                if (Session["ClickResponse"] == null)
                {
                    foreach (var item in objBillFinalization.Details)
                    {
                        item.IsPosted = true;
                        //    DataSet ds = this.customerBillRepository.GenerateEInvoice(item.BillId);
                        //    if (ds.Tables[0].Rows.Count > 0)
                        //    {
                        //        item.ErrorMessage =ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        //        if (ds.Tables[0].Rows[0]["Status"].ToString()=="1")
                        //            item.IsPosted = true;
                        //        else
                        //            item.IsPosted = false;
                        //        item.Irn =ds.Tables[0].Rows[0]["Irn"].ToString();
                        //        item.SignedQRCode =ds.Tables[0].Rows[0]["SignedQRCode"].ToString();
                        //        item.SignedInvoice =ds.Tables[0].Rows[0]["SignedInvoice"].ToString();
                        //        item.IrnStatus =ds.Tables[0].Rows[0]["IrnStatus"].ToString();
                        //        item.AckNo =ds.Tables[0].Rows[0]["AckNo"].ToString();
                        //    }
                    }
                    response = this.customerBillRepository.BillFinalization(objBillFinalization);
                    Session["ClickResponse"] = response;
                }
                else
                {
                    response = (Response)Session["ClickResponse"];
                }
                if (response.IsSuccessfull)
                {
                    int index = 0;
                    foreach (var item in objBillFinalization.Details)
                    {
                        if (item.IsPosted == true)
                            item.ErrorMessage = "Bill finalize seccussfully";
                        if (item.IsPosted == false)
                        {
                            index = 1;
                        }
                    }
                    if (index == 1)
                    {
                        action = base.View("GenerationError", (IEnumerable<BillFinalizationDetail>)objBillFinalization.Details);
                    }
                    else
                    {
                        action = base.RedirectToAction("SubmissionDone", new { status = "BillFinalization" });
                    }


                    return action;
                }
            }
            action = base.View(objBillFinalization);
            return action;
        }
        public ActionResult GenerationError(IEnumerable<BillFinalizationDetail> obj)
        {
            return (ActionResult)this.View((object)obj);
        }
        public ActionResult GenerationErrorList()
        {
            return (ActionResult)this.View((object)this.customerBillRepository.GenerationErrorList(SessionUtility.LoginUserId));
        }
        public JsonResult GenerateEInvoice(long BillId)
        {
            BillFinalizationDetail billFinalizationDetail = new BillFinalizationDetail();

            DataSet ds = this.customerBillRepository.GenerateEInvoice(BillId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                {
                    billFinalizationDetail.IsPosted = true;
                    billFinalizationDetail.Irn = ds.Tables[0].Rows[0]["Irn"].ToString();
                    billFinalizationDetail.SignedQRCode = ds.Tables[0].Rows[0]["SignedQRCode"].ToString();
                    billFinalizationDetail.SignedInvoice = ds.Tables[0].Rows[0]["SignedInvoice"].ToString();
                    billFinalizationDetail.IrnStatus = ds.Tables[0].Rows[0]["IrnStatus"].ToString();
                    billFinalizationDetail.AckNo = ds.Tables[0].Rows[0]["AckNo"].ToString();
                    billFinalizationDetail.ErrorMessage = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    billFinalizationDetail.BillId = BillId;
                    billFinalizationDetail.BillNo = BillId.ToString();
                }
                else
                {
                    billFinalizationDetail.IsPosted = false;
                    billFinalizationDetail.ErrorMessage = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    billFinalizationDetail.BillId = BillId;
                    billFinalizationDetail.BillNo = BillId.ToString();
                    billFinalizationDetail.Irn = "";
                    billFinalizationDetail.SignedQRCode = "";
                    billFinalizationDetail.SignedInvoice = "";
                    billFinalizationDetail.AckNo = "";
                    billFinalizationDetail.IrnStatus = "";
                }
                this.customerBillRepository.BillEInvoice(billFinalizationDetail);
            }

            JsonResult jsonResult = base.Json(billFinalizationDetail);
            return jsonResult;
        }
        public ActionResult RegenerateEInvoice()
        {
            return (ActionResult)this.View((object)this.customerBillRepository.RegenerateEInvoice(SessionUtility.LoginUserId));
        }
        public ActionResult Cancellation()
        {
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation(CustomerBillCancellation objCustomerBillCancellation)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objCustomerBillCancellation.Details.RemoveAll((BillCancellationDetail m) => !m.IsChecked);
                objCustomerBillCancellation.Details.ForEach((BillCancellationDetail m) => m.CancelBy = SessionUtility.LoginUserId);
                objCustomerBillCancellation.Details.ForEach((BillCancellationDetail m) => m.CancelledDate = objCustomerBillCancellation.CancelledDate);
                objCustomerBillCancellation.Details.ForEach((BillCancellationDetail m) => m.CancelledReason = objCustomerBillCancellation.CancelledReason);
                if (this.customerBillRepository.Cancellation(objCustomerBillCancellation).IsSuccessfull)
                {
                    action = base.RedirectToAction("SubmissionDone", new { status = "Cancellation" });
                    return action;
                }
            }
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            action = base.View(objCustomerBillCancellation);
            return action;
        }

        public ActionResult Collection()
        {
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            ((dynamic)base.ViewBag).CustomerGroupList = this.customerGroupRepository.GetCustomerGroupList();
            ((dynamic)base.ViewBag).CustomerTypeList = this.generalRepository.GetByIdList(303);
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Collection(CustomerBillCollection objCollection)
        {
            ActionResult action;
            short loginLocationId;
            base.ModelState.Remove("ReceiptDetails.ChequeId");
            base.ModelState.Remove("ReceiptDetails.NetPayableAmount");
            base.ModelState.Remove("ReceiptDetails.AmountApplicable");
            base.ModelState.Remove("CustomerGroup");

            if (objCollection.ReceiptDetails.IsDirectDeposited)
            {
                base.ModelState.Remove("ReceiptDetails.BankName");
                base.ModelState.Remove("ReceiptDetails.BankBranchName");
            }
            if (objCollection.ReceiptDetails.ReceiptMode != 8)
            {
                base.ModelState.Remove("ReceiptDetails.BaAccountID");

            }
            if (base.ModelState.IsValid)
            {
                bool moduleRuleByIdAndRuleId = false;
                moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
                objCollection.LocationCode = (moduleRuleByIdAndRuleId ? "HQTR" : SessionUtility.LoginLocationCode);
                CustomerBillCollection customerBillCollection = objCollection;
                if (moduleRuleByIdAndRuleId)
                {
                    loginLocationId = 1;
                }
                else
                {
                    loginLocationId = SessionUtility.LoginLocationId;
                }
                customerBillCollection.LocationId = loginLocationId;
                objCollection.EntryBy = SessionUtility.LoginUserId;
                objCollection.EntryDate = DateTime.Now;
                objCollection.FinYear = SessionUtility.FinYear;
                objCollection.CompanyId = SessionUtility.CompanyId;
                objCollection.MrDetailList.RemoveAll((MrDetail m) => !m.IsChecked);
                objCollection.MrDetailList.ForEach((MrDetail x) => x.CollectionUserId = SessionUtility.LoginUserId);
                objCollection.MrDetailList.ForEach((MrDetail x) => x.CollectionLocationId = SessionUtility.LoginLocationId);

                if (objCollection.ReceiptDetails.ReceiptMode == 8)
                {
                    objCollection.ReceiptDetails.CashAccountId = objCollection.ReceiptDetails.BaAccountID;

                }

                Response response = this.customerBillRepository.Collection(objCollection);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("CollectionDone", new { DocumentId = response.DocumentId, DocumentNo = response.DocumentNo });
                    return action;
                }
            }
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            action = base.View(objCollection);
            return action;
        }

        public ActionResult CollectionDone()
        {
            return base.View();
        }


        public ActionResult DeliveryMr()
        {
            DeliveryMrHeader deliveryMrHeader = new DeliveryMrHeader();
            ((dynamic)base.ViewBag).DocketSuffixList = this.docketRepository.GetDocketSuffixList();
            return base.View(deliveryMrHeader);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeliveryMr(DeliveryMrHeader objDeliveryMrHeader)
        {
            ActionResult action;
            base.ModelState.Remove("ReceiptDetails.ChequeId");
            base.ModelState.Remove("ReceiptDetails.NetPayableAmount");
            if (objDeliveryMrHeader.ReceiptDetails.IsDirectDeposited)
            {
                base.ModelState.Remove("ReceiptDetails.BankName");
                base.ModelState.Remove("ReceiptDetails.BankBranchName");
            }

            if (objDeliveryMrHeader.ReceiptDetails.ReceiptMode != 8)
            {
                base.ModelState.Remove("ReceiptDetails.BaAccountID");

            }
            if (objDeliveryMrHeader.IsPartial == false)
            {

                base.ModelState.Remove("DeliverPartyId");
                base.ModelState.Remove("DeliverPartyCode");
                base.ModelState.Remove("DeliverPartyName");
                objDeliveryMrHeader.DeliverPartyId = objDeliveryMrHeader.PartyId;
                objDeliveryMrHeader.DeliverPartyCode = objDeliveryMrHeader.PartyCode;
                objDeliveryMrHeader.DeliverPartyName = objDeliveryMrHeader.PartyName;


            }

            if (objDeliveryMrHeader.IsPartial == true)
            {
                base.ModelState.Remove("ReceiptDetails.AmountApplicable");
                base.ModelState.Remove("ReceiptDetails.CollectionAmountFromCheque");
                base.ModelState.Remove("ReceiptDetails.TdsAccountId");
                base.ModelState.Remove("ReceiptDetails.TdsAmount");
            }

            if (base.ModelState.IsValid)
            {
                objDeliveryMrHeader.LocationCode = SessionUtility.LoginLocationCode;
                objDeliveryMrHeader.LocationId = SessionUtility.LoginLocationId;
                objDeliveryMrHeader.EntryBy = SessionUtility.LoginUserId;
                objDeliveryMrHeader.EntryDate = DateTime.Now;
                objDeliveryMrHeader.FinYear = SessionUtility.FinYear;
                objDeliveryMrHeader.CompanyId = SessionUtility.CompanyId;
                objDeliveryMrHeader.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
                objDeliveryMrHeader.Details.ForEach((CustomerBillDetail m) => m.CollectionUserId = SessionUtility.LoginUserId);
                objDeliveryMrHeader.Details.ForEach((CustomerBillDetail m) => m.CollectionLocationId = SessionUtility.LoginLocationId);
                objDeliveryMrHeader.ChargeList = JsonConvert.DeserializeObject<List<DeliveryMrCharge>>(objDeliveryMrHeader.DeliveryMrChargeList);
                List<DeliveryMrDone> list = this.customerBillRepository.DeliveryMr(objDeliveryMrHeader).ToList<DeliveryMrDone>();
                if (list[0].IsSuccessfull)
                {
                    base.TempData["MrDetails"] = list;
                    action = base.RedirectToAction("DeliveryMrDone");
                    return action;
                }
            }
                    ((dynamic)base.ViewBag).DocketSuffixList = this.docketRepository.GetDocketSuffixList();
            action = base.View(objDeliveryMrHeader);
            return action;
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeliveryMr(DeliveryMrHeader objDeliveryMrHeader)
        //{
        //    ActionResult action;
        //    base.ModelState.Remove("ReceiptDetails.ChequeId");
        //    base.ModelState.Remove("ReceiptDetails.NetPayableAmount");
        //    if (base.ModelState.IsValid)
        //    {
        //        objDeliveryMrHeader.LocationCode = SessionUtility.LoginLocationCode;
        //        objDeliveryMrHeader.LocationId = SessionUtility.LoginLocationId;
        //        objDeliveryMrHeader.EntryBy = SessionUtility.LoginUserId;
        //        objDeliveryMrHeader.EntryDate = DateTime.Now;
        //        objDeliveryMrHeader.FinYear = SessionUtility.FinYear;
        //        objDeliveryMrHeader.CompanyId = SessionUtility.CompanyId;
        //        objDeliveryMrHeader.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
        //        objDeliveryMrHeader.Details.ForEach((CustomerBillDetail m) => m.CollectionUserId = SessionUtility.LoginUserId);
        //        objDeliveryMrHeader.Details.ForEach((CustomerBillDetail m) => m.CollectionLocationId = SessionUtility.LoginLocationId);
        //        objDeliveryMrHeader.ChargeList = JsonConvert.DeserializeObject<List<DeliveryMrCharge>>(objDeliveryMrHeader.DeliveryMrChargeList);
        //        List<DeliveryMrDone> list = this.customerBillRepository.DeliveryMr(objDeliveryMrHeader).ToList<DeliveryMrDone>();
        //        if (list[0].IsSuccessfull)
        //        {
        //            base.TempData["MrDetails"] = list;
        //            action = base.RedirectToAction("DeliveryMrDone");
        //            return action;
        //        }
        //    }
        //    ((dynamic)base.ViewBag).DocketSuffixList = this.docketRepository.GetDocketSuffixList();
        //    action = base.View(objDeliveryMrHeader);
        //    return action;
        //}

        public ActionResult DeliveryMrDone()
        {
            ActionResult action;
            List<DeliveryMrDone> item = base.TempData["MrDetails"] as List<DeliveryMrDone>;
            if (item == null)
            {
                action = base.RedirectToAction("DeliveryMr");
            }
            else
            {
                action = base.View(item);
            }
            return action;
        }

        public ActionResult Detail(long id)
        {
            ActionResult actionResult;
            CustomerBill customerBillDetailById = this.customerBillRepository.GetCustomerBillDetailById(id);
            if (customerBillDetailById != null)
            {
                actionResult = base.View(customerBillDetailById);
            }
            else
            {
                actionResult = base.HttpNotFound();
            }
            return actionResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.customerBillRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.accountRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.gstRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.customerRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.docketRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.customerContractRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DocketFinalization()
        {
            return base.View();
        }

        public ActionResult Generation()
        {
            CustomerBill customerBill = new CustomerBill();
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(customerBill);
        }

        public ActionResult GenerationTriSpeed()
        {
            CustomerBill customerBill = new CustomerBill();
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(customerBill);
        }

        public ActionResult TripBill()
        {
            TripBilling ObjBill = new TripBilling();
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            return base.View(ObjBill);
        }

        public ActionResult TripBillMilkRun()
        {
            MilkRunBilling ObjBill = new MilkRunBilling();
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            return base.View(ObjBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TripBillMilkRun(MilkRunBilling ObjBill)
        {
            ActionResult action;
            ObjBill.CompanyId = SessionUtility.CompanyId;
            ObjBill.EntryBy = SessionUtility.LoginUserId;
            ObjBill.LocationId = SessionUtility.LoginLocationId;
            //ObjBill.Details.RemoveAll((MilkRunBillingDetail m) => !m.IsChecked);

            Response response = this.customerBillRepository.MilkRunSheetBill(ObjBill);

            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
                action = base.View(ObjBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = 0, CustomerId = ObjBill.CustomerId, TransportModeId = 0, ServiceTypeId = 0, FtlTypeId = 0, UseTransportModeServiceType = false });
            }

            return action;
        }



        public ActionResult TripBillNew()
        {
            TripBilling ObjBill = new TripBilling();
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            return base.View(ObjBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TripBillNew(TripBilling ObjBill)
        {
            ActionResult action;
            ObjBill.CompanyId = SessionUtility.CompanyId;
            ObjBill.EntryBy = SessionUtility.LoginUserId;
            ObjBill.LocationId = SessionUtility.LoginLocationId;
            ObjBill.Details.RemoveAll((TripBillDetail m) => !m.IsChecked);

            Response response = this.customerBillRepository.TripSheetBill(ObjBill);

            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
                action = base.View(ObjBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = 0, CustomerId = ObjBill.CustomerId, TransportModeId = 0, ServiceTypeId = 0, FtlTypeId = 0, UseTransportModeServiceType = false });
            }

            return action;
        }

        [HttpPost]
        public ActionResult TripBill(TripBilling ObjBill)
        {
            return base.View(ObjBill);
        }



        public JsonResult GetTripCustomerBillDetails(short customerId, DateTime fromDate, DateTime toDate, byte serviceTypeId, byte SacId, int fromcityid, int tocityid)
        {
            short loginLocationId;
            fromDate = DateTime.Now.AddYears(-3);
            toDate = DateTime.Now;
            if ((new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y")
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            short num = loginLocationId;
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetTripCustomerBillDetails(customerId, fromDate, toDate, serviceTypeId, SessionUtility.FinYear, num, SessionUtility.CompanyId, SacId, fromcityid, tocityid));
            return jsonResult;
        }
        public JsonResult GetTripCustomerBillDetailsNew(short customerId, DateTime fromDate, DateTime toDate, byte GstServiceTypeId)
        {
            short loginLocationId;
            loginLocationId = SessionUtility.LoginLocationId;
            short num = loginLocationId;
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetTripCustomerBillDetailsNew(customerId, fromDate, toDate, GstServiceTypeId));
            return jsonResult;
        }

        public JsonResult GetMilkRunCustomerBillDetails(short customerId, DateTime fromDate, DateTime toDate, byte GstServiceTypeId, string VehicleId, string TripsheetNo)
        {
            short loginLocationId;
            loginLocationId = SessionUtility.LoginLocationId;
            short num = loginLocationId;
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetMilkRunCustomerBillDetails(customerId, fromDate, toDate, GstServiceTypeId, VehicleId, TripsheetNo));
            return jsonResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generation(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;
            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response = this.customerBillRepository.Generate(objCustomerBill);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = objCustomerBill.PaybasId, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerationTriSpeed(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;
            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response = this.customerBillRepository.Generate(objCustomerBill);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = objCustomerBill.PaybasId, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }

        public ActionResult GenerationDone()
        {
            return base.View();
        }
        public ActionResult GenerationDumtcoDone()
        {
            return base.View();
        }

        public JsonResult GetBillListForBillFinalization(short locationId, short customerId, DateTime fromDate, DateTime toDate, string billNos, byte paybas, string manualBillNos)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetCustomerBillListForFinalization(billNos, fromDate, toDate, customerId, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, locationId, SessionUtility.CompanyId, paybas, manualBillNos));
            return jsonResult;
        }

        public JsonResult GetCustomerBillListForCancellation(string billNos, string manualBillNos, byte paybas, short customerId, DateTime fromDate, DateTime toDate)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetCustomerBillListForCancellation(billNos, manualBillNos, paybas, customerId, fromDate, toDate, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetCustomerBillListForCollection(string billNos, string manualBillNos, byte paybas, short customerId, DateTime fromDate, DateTime toDate, string customerGroup)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetCustomerBillListForCollection(billNos, manualBillNos, paybas, customerId, fromDate, toDate, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId, customerGroup));
            return jsonResult;
        }



        public JsonResult GetCustomerBillListForSubmission(string billNos, string manualBillNos, byte paybas, short customerId, DateTime fromDate, DateTime toDate)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetCustomerBillListForSubmission(billNos, manualBillNos, paybas, customerId, fromDate, toDate, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetCustomerBillListForUnSubmission(string billNos, string manualBillNos, byte paybas, short customerId, DateTime fromDate, DateTime toDate)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetCustomerBillListForUnSubmission(billNos, manualBillNos, paybas, customerId, fromDate, toDate, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetDeliveryCharges()
        {
            return base.Json(this.customerBillRepository.GetDeliveryCharges());
        }

        public JsonResult GetDocketListForCustomerBillGeneration(CustomerBill objCustomerBill)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListForCustomerBillGeneration(objCustomerBill.CustomerId, objCustomerBill.FromDate, objCustomerBill.ToDate, objCustomerBill.ServiceTax, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId, SessionUtility.CompanyId));
            return jsonResult;
        }
        public JsonResult GetDocketListGstForCustomerBillGeneration(short customerId, DateTime fromDate, DateTime toDate, byte gstServiceTypeId, byte customerGstStateId, byte companyGstStateId, byte paybasId, byte serviceTypeId, byte ftlTypeId, short billtypeInterIntra, short ownerType, short ownerId, bool rcmyn)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListGstForCustomerBillGeneration(customerId, fromDate, toDate, gstServiceTypeId, customerGstStateId, companyGstStateId, paybasId, serviceTypeId, ftlTypeId, billtypeInterIntra, ownerType, ownerId, rcmyn, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }
        public JsonResult GetDocketListGstForCustomerBillGenerationTriSpeed(short customerId, DateTime fromDate, DateTime toDate, byte gstServiceTypeId,
            byte customerGstStateId, byte companyGstStateId, byte paybasId,
            byte serviceTypeId, byte ftlTypeId, byte DocketStatusId, string PONo, short billtypeInterIntra, short ownerType, short ownerId)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListGstForCustomerBillGenerationTriSpeed(customerId, fromDate, toDate,
                gstServiceTypeId, customerGstStateId, companyGstStateId,
                paybasId, serviceTypeId, ftlTypeId, SessionUtility.FinYear,
                SessionUtility.FinStartDate, SessionUtility.FinEndDate, num,
                SessionUtility.CompanyId, DocketStatusId, PONo, billtypeInterIntra, ownerType, ownerId));
            return jsonResult;
        }

        public JsonResult GetGstDetails(byte sacId)
        {
            return base.Json(this.gstRepository.GetGstDetailByGstServiceTypeId(sacId));
        }

        public JsonResult GetGstRate(short gstServiceIdId)
        {
            return base.Json(this.customerBillRepository.GetGstRate(gstServiceIdId));
        }

        public JsonResult GetMrBillListForCancellation(string mrNos, DateTime fromDate, DateTime toDate)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetMrBillListForCancellation(mrNos, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetDeliveryMrBillListForCancellation(string mrNos, DateTime fromDate, DateTime toDate)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDeliveryMrBillListForCancellation(mrNos, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetMrDocketList(bool isDeliveredByConsignee, short customerId, string docketNos, string docketSuffix)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetMrDocketList(isDeliveredByConsignee, customerId, docketNos, docketSuffix, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId, SessionUtility.CompanyId));
            return jsonResult;
        }

        [HttpPost]
        [ValidateAntiModelInjection("BillId")]
        public JsonResult IsManualBillNoAvailable(CustomerBill objCustomerBill)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.IsManualBillNoAvailable(objCustomerBill.BillId, objCustomerBill.ManualBillNo));
            return jsonResult;
        }

        public ActionResult MiscellaneousBill(string customerId, string customerStateId,
            string companyStateId, string payBasId, string submissionId, string serviceTypeId)
        {
            GstGeneration Obj = new Models.GstGeneration();
            GstRegistration companyGst = gstRepository.GetGstDetailByOwnerAndState(1, SessionUtility.CompanyId, companyStateId.ConvertToShort());
            GstRegistration customerGst = gstRepository.GetGstDetailByOwnerAndState(3, customerId.ConvertToLong(), customerStateId.ConvertToShort());
            MasterCustomer objCustomer = this.customerRepository.GetById(customerId.ConvertToInt());

            Obj.BillId = 0;
            Obj.PaybasId = payBasId.ConvertToByte();
            Obj.CustomerId = objCustomer.CustomerId;
            Obj.CustomerCode = objCustomer.CustomerCode;
            Obj.CustomerName = objCustomer.CustomerName;
            Obj.SubmissionLocationCode = SessionUtility.LoginLocationCode;
            Obj.SubmissionLocationId = SessionUtility.LoginLocationId;
            Obj.CollectionLocationCode = SessionUtility.LoginLocationCode;
            Obj.CollectionLocationId = SessionUtility.LoginLocationId;

            Obj.GenerationState = companyGst.StateName;
            Obj.GenerationStateId = companyGst.StateId;
            Obj.CompanyGstId = companyGst.GstId;
            Obj.CompanyGstStateGstTinNo = companyGst.GstTinNo;
            Obj.GenerationCity = companyGst.CityName;
            Obj.GenerationCityId = companyGst.CityId;

            Obj.SubmissionState = customerGst.StateName;
            Obj.SubmissionStateId = customerGst.StateId;
            Obj.PartyGstId = customerGst.GstId;
            Obj.CustomerGstStateGstTinNo = customerGst.GstTinNo;
            Obj.SubmissionCity = customerGst.CityName;
            Obj.SubmissionCityId = customerGst.CityId;

            Obj.CustomerBillSupplementryDetail.Add(new CustomerBillSupplementryDetail());
            ((dynamic)base.ViewBag).SacList = this.sacRepository.GetSacList();
            ((dynamic)base.ViewBag).ServiceTypeId = serviceTypeId.ConvertToShort();
            ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetWarehouseList();
            ((dynamic)base.ViewBag).HsnList = this.hsnRepository.GetHsnList();
            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleListByVendorTypeId(3);

            return base.View(Obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("BillId")]
        public ActionResult MiscellaneousBill(GstGeneration objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
            GstGeneration gstGeneration = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            gstGeneration.GenerationLocationId = loginLocationId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            byte gstSacId = objCustomerBill.CustomerBillSupplementryDetail.FirstOrDefault<CustomerBillSupplementryDetail>().GstSacId;
            objCustomerBill.GstSac = gstSacId.ToString();
            objCustomerBill.GstSacId = objCustomerBill.CustomerBillSupplementryDetail.FirstOrDefault<CustomerBillSupplementryDetail>().GstSacId;
            objCustomerBill.ServiceTypeId = objCustomerBill.CustomerBillSupplementryDetail.FirstOrDefault<CustomerBillSupplementryDetail>().ServiceTypeId;
            base.ModelState.Remove("GstSac");
            base.ModelState.Remove("VehicleNo");
            if (base.ModelState.IsValid)
            {
                Response response = this.customerBillRepository.MiscellaneousBill(objCustomerBill);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = 4, CustomerId = objCustomerBill.CustomerId });
                    return action;
                }
                base.TempData["result"] = response;
            }
            ((dynamic)base.ViewBag).SACList = this.gstRepository.GetSacList();
            action = base.View(objCustomerBill);
            return action;
        }

        public ActionResult MrCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MrCancellation(MrCancellation objMrCancellation)
        {
            ActionResult action;
            Response response = new Response();
            objMrCancellation.Details.RemoveAll((MrCancellationDetail m) => !m.IsChecked);
            objMrCancellation.Details.ForEach((MrCancellationDetail m) => m.CancelBy = new short?(SessionUtility.LoginUserId));
            if (!this.customerBillRepository.MrCancellation(objMrCancellation).IsSuccessfull)
            {
                action = base.View(objMrCancellation);
            }
            else
            {
                action = base.RedirectToAction("SubmissionDone", new { status = "MrCancellationDone" });
            }
            return action;
        }

        public ActionResult DeliveryMrCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeliveryMrCancellation(MrCancellation objMrCancellation)
        {
            ActionResult action;
            Response response = new Response();
            objMrCancellation.Details.RemoveAll((MrCancellationDetail m) => !m.IsChecked);
            objMrCancellation.Details.ForEach((MrCancellationDetail m) => m.CancelBy = new short?(SessionUtility.LoginUserId));
            if (!this.customerBillRepository.DeliveryMrCancellation(objMrCancellation).IsSuccessfull)
            {
                action = base.View(objMrCancellation);
            }
            else
            {
                action = base.RedirectToAction("SubmissionDone", new { status = "DeliveryMrCancellationDone" });
            }
            return action;
        }


        public ActionResult Submission()
        {
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            IEnumerable<AutoCompleteResult> userNameListByLocationId = this.userRepository.GetUserNameListByLocationId(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).SubmittedByUserList = JsonConvert.SerializeObject(userNameListByLocationId);
            ((dynamic)base.ViewBag).CustomerTypeList = this.generalRepository.GetByIdList(303);

            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submission(CustomerBillSubmission objCustomerBillSubmission)
        {
            ActionResult action;
            long billId;
            short locIndex = 1;

            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(151, 1) == "Y";
            objCustomerBillSubmission.SubmittedUserId = SessionUtility.LoginUserId;
            objCustomerBillSubmission.CompanyId = SessionUtility.CompanyId;
            objCustomerBillSubmission.SubmittedLocationId = (moduleRuleByIdAndRuleId ? locIndex : SessionUtility.LoginLocationId);

            for (int i = 0; objCustomerBillSubmission.Details.Count > i; i++)
            {
                base.ModelState.Remove(string.Concat("Details[", i, "].SubmittedByUserId"));
                base.ModelState.Remove(string.Concat("Details[", i, "].SubmittedDocumentName"));
            }
            if (base.ModelState.IsValid)
            {
                objCustomerBillSubmission.Details.RemoveAll((BillSubmissionDetail m) => !m.IsChecked);
                objCustomerBillSubmission.Details.ForEach((BillSubmissionDetail m) => m.SubmittedUserId = SessionUtility.LoginUserId);
                objCustomerBillSubmission.Details.ForEach((BillSubmissionDetail m) => m.SubmittedLocationId = (moduleRuleByIdAndRuleId ? locIndex : SessionUtility.LoginLocationId));
                objCustomerBillSubmission.Details.ForEach((BillSubmissionDetail m) => m.SubmittedTo = objCustomerBillSubmission.SubmittedTo);
                objCustomerBillSubmission.Details.ForEach((BillSubmissionDetail m) => m.SubmittedContactNo = objCustomerBillSubmission.SubmittedContactNo);
                objCustomerBillSubmission.Details.ForEach((BillSubmissionDetail m) => m.BillSubmissionRemarks = objCustomerBillSubmission.BillSubmissionRemarks);
                objCustomerBillSubmission.Details.ForEach((BillSubmissionDetail m) => m.SubmissionDateTime = objCustomerBillSubmission.SubmissionDateTime);
                foreach (BillSubmissionDetail detail in objCustomerBillSubmission.Details)
                {
                    if (detail.SubmittedDocumentAttachment != null)
                    {
                        string fileName = "";
                        if (!ConfigHelper.IsLocalStorage)
                        {
                            billId = detail.BillId;
                            string str = string.Concat("DOC_TYPE", billId.ToString());
                            string str1 = detail.BillNo.ToString();
                            billId = detail.BillId;
                            fileName = AzureStorageHelper.GetFileName("CustomerBillSubmission", str, str1, billId.ToString(), detail.SubmittedDocumentAttachment.FileName);
                            AzureStorageHelper.UploadBlob("CustomerBillSubmission", detail.SubmittedDocumentAttachment, fileName, fileName);
                        }
                        else
                        {
                            billId = detail.BillId;
                            fileName = string.Concat(billId.ToString(), "_", detail.SubmittedDocumentAttachment.FileName);
                            string str2 = string.Concat(ConfigHelper.LocalStoragePath, "CustomerBillSubmission/", fileName);
                            detail.SubmittedDocumentAttachment.SaveAs(str2);
                        }
                        detail.SubmittedDocumentName = fileName;
                        detail.SubmittedDocumentAttachment = null;
                    }
                }
                Response response = this.customerBillRepository.Submission(objCustomerBillSubmission);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("SubmissionDone", new { DocumentId = response.DocumentId, DocumentNo = response.DocumentNo, status = "Submission" });
                    return action;
                }
            }
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            action = base.View(objCustomerBillSubmission);
            return action;
        }

        public ActionResult SubmissionDone()
        {
            return base.View();
        }

        public ActionResult SupplementryBill()
        {
            SupplementryBill supplementryBill = new SupplementryBill();
            supplementryBill.BillAccountDetails.Add(new BillAccountDetails());
            string[] strArrays = new string[] { "Docket", "THC" };
            string[] strArrays1 = strArrays;
            ((dynamic)base.ViewBag).DocumentTypeList = (
                from m in this.generalRepository.GetByIdList(23)
                where strArrays1.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            strArrays = new string[] { "2" };
            string[] strArrays2 = strArrays;
            ((dynamic)base.ViewBag).PaybasList = (
                from m in this.generalRepository.GetByIdList(68)
                where strArrays2.Contains<string>(m.Value)
                select m).ToList<AutoCompleteResult>();
            return base.View(supplementryBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupplementryBill(SupplementryBill objSupplementryBill)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objSupplementryBill.EntryBy = SessionUtility.LoginUserId;
                objSupplementryBill.CompanyId = SessionUtility.CompanyId;
                objSupplementryBill.LocationId = SessionUtility.LoginLocationId;
                objSupplementryBill.LocationCode = SessionUtility.LoginLocationCode;
                foreach (BillAccountDetails billAccountDetail in objSupplementryBill.BillAccountDetails)
                {
                    if (!objSupplementryBill.MultipleCNoteNo)
                    {
                        if (objSupplementryBill.DocumentNo != null)
                        {
                            billAccountDetail.DocumentTypeId = objSupplementryBill.DocumentTypeId;
                            billAccountDetail.DocumentId = objSupplementryBill.DocumentId;
                        }
                    }
                }
                Response response = this.customerBillRepository.SupplementaryBill(objSupplementryBill);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = 5, CustomerId = objSupplementryBill.CustomerId });
                    return action;
                }
            }
            string[] strArrays = new string[] { "Docket", "THC" };
            string[] strArrays1 = strArrays;
            ((dynamic)base.ViewBag).DocumentTypeList = (
                from m in this.generalRepository.GetByIdList(23)
                where strArrays1.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            strArrays = new string[] { "2" };
            string[] strArrays2 = strArrays;
            ((dynamic)base.ViewBag).PaybasList = (
                from m in this.generalRepository.GetByIdList(68)
                where strArrays2.Contains<string>(m.Value)
                select m).ToList<AutoCompleteResult>();
            action = base.View(objSupplementryBill);
            return action;
        }

        public ActionResult UnSubmission()
        {
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnSubmission(CustomerBillUnSubmission objCustomerBillUnSubmission)
        {
            ActionResult action;
            for (int i = 0; objCustomerBillUnSubmission.Details.Count > i; i++)
            {
                base.ModelState.Remove(string.Concat("Details[", i, "].SubmittedByUserId"));
                base.ModelState.Remove(string.Concat("Details[", i, "].SubmittedDocumentName"));
            }
            if (base.ModelState.IsValid)
            {
                objCustomerBillUnSubmission.Details.RemoveAll((BillSubmissionDetail m) => !m.IsChecked);
                objCustomerBillUnSubmission.EntryBy = SessionUtility.LoginUserId;

                if (this.customerBillRepository.UnSubmission(objCustomerBillUnSubmission).IsSuccessfull)
                {
                    action = base.RedirectToAction("SubmissionDone", new { status = "UnSubmission" });
                    return action;
                }
            }
             ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(68);

            action = base.View(objCustomerBillUnSubmission);
            return action;
        }

        [HttpPost]
        public JsonResult GetManifestList(string CustomerId, string VendorId, byte paybaseId)
        {
            return this.Json((object)this.customerBillRepository.GetManifestList(SessionUtility.LoginLocationId, CustomerId, VendorId, paybaseId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerationDumtco()
        {
            CustomerBill customerBill = new CustomerBill();

            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            //((dynamic)base.ViewBag).ManifestList = this.customerBillRepository.GetManifestList(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).CustomerTypeList = this.generalRepository.GetByIdList(303);
            return base.View(customerBill);
        }

        public ActionResult GenerationMLPL()
        {
            CustomerBill customerBill = new CustomerBill();
            Session["ClickResponse"] = null;
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            //((dynamic)base.ViewBag).ManifestList = this.customerBillRepository.GetManifestList(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            dynamic viewBag2 = base.ViewBag;
            viewBag2.ServiceTypes = JsonConvert.SerializeObject(((dynamic)base.ViewBag).ServiceTypeList);

            ((dynamic)base.ViewBag).MiscellaneousServiceTypes = this.generalRepository.GetByIdList(305);
            dynamic viewBag3 = base.ViewBag;
            viewBag3.MiscellaneousServiceServiceTypeList = JsonConvert.SerializeObject(((dynamic)base.ViewBag).MiscellaneousServiceTypes);

            return base.View(customerBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerationMLPL(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(15, 7) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;

            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;

            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);


            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response;


            if (Session["ClickResponse"] == null)
            {
                response = this.customerBillRepository.Generate(objCustomerBill);
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = objCustomerBill.PaybasId, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }

        public ActionResult GenerationMLPLEdit()
        {
            CustomerBill customerBill = new CustomerBill();
            Session["ClickResponse"] = null;
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(customerBill);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerationMLPLEdit(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(15, 7) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;

            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;

            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);

            //if (objCustomerBill.PaybasId != 3)
            //{
            //    objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
            //}

            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response;


            if (Session["ClickResponse"] == null)
            {
                response = this.customerBillRepository.ReGenerate(objCustomerBill);
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = 30, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerationDumtco(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(15, 7) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;

            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;

            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);

            //if (objCustomerBill.PaybasId != 3)
            //{
            //    objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
            //}

            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response = this.customerBillRepository.Generate(objCustomerBill);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDumtcoDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = objCustomerBill.PaybasId, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }


        public JsonResult GetTHCNoFromManifest(string ManifestId)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetTHCNoFromManifest(ManifestId));
            return jsonResult;
        }

        public ActionResult GenerateDeliveryBill()
        {
            DeliveryBill customerBill = new DeliveryBill();

            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(customerBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateDeliveryBill(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(15, 7) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;

            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;
            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);


            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response = this.customerBillRepository.GenerateDeliveryBill(objCustomerBill);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("DeliveryBilldone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = objCustomerBill.PaybasId, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }

        public ActionResult DeliveryBilldone()
        {
            return base.View();
        }


        public ActionResult UploadInSystem()
        {
            return base.View(new BillUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystem(BillUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            BillUploadInSystem docketUploadInSystem = new BillUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            BillUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.customerBillRepository.UploadInSystem(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }


        public JsonResult GetDocketListGstForCustomerGatePassBillGeneration(short customerId, DateTime fromDate, DateTime toDate, byte gstServiceTypeId, byte customerGstStateId, byte companyGstStateId, byte paybasId, byte serviceTypeId, byte ftlTypeId)
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
            JsonResult jsonResult = base.Json(this.customerBillRepository.GetDocketListGstForCustomerGatePassBillGeneration(customerId, fromDate, toDate, gstServiceTypeId, customerGstStateId, companyGstStateId, paybasId, serviceTypeId, ftlTypeId, SessionUtility.FinYear, SessionUtility.FinStartDate, SessionUtility.FinEndDate, num, SessionUtility.CompanyId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckValidBillNoForReAssign(string BillNo)
        {
            JsonResult jsonResult = base.Json(this.customerBillRepository.CheckValidBillNoForReAssign(BillNo));
            return jsonResult;
        }
        public ActionResult BillReAssignDone()
        {
            return base.View();
        }

        public ActionResult BillReAssign()
        {
            BillReAssign docketDacc = new BillReAssign();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();

            return base.View(docketDacc);
        }

        [HttpPost]
        public ActionResult BillReAssign(BillReAssign objDocketDacc)
        {
            objDocketDacc.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            response = this.customerBillRepository.InsertBillReAssign(objDocketDacc);

            if (response.IsSuccessfull)
            {
                return base.RedirectToAction("BillReAssignDone");
            }

            return base.View();
        }

        public ActionResult _DocketChargesList(long? docketId)
        {
            Docket docket = new Docket();
            if (!docketId.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;
            }
            else
            {
                docket.DocketId = docketId.Value;
            }
            docket = this.customerBillRepository.GetDocketChargeDetails(docket);
            return base.View(docket);
        }
        public ActionResult _TripsheetMilkRunLog(string TripsheetNo)
        {
            MilkRunLogDetail docket = new MilkRunLogDetail();
            docket.TripsheetNo = TripsheetNo;
            return base.View(docket);
        }

        public ActionResult GenerationMLPLV1()
        {
            CustomerBill customerBill = new CustomerBill();
            Session["ClickResponse"] = null;
            ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
            //((dynamic)base.ViewBag).ManifestList = this.customerBillRepository.GetManifestList(SessionUtility.LoginLocationId);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(customerBill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerationMLPLV1(CustomerBill objCustomerBill)
        {
            ActionResult action;
            short loginLocationId;
            short num;
            bool moduleRuleByIdAndRuleId = false;
            moduleRuleByIdAndRuleId = (new RulesRepository()).GetModuleRuleByIdAndRuleId(15, 7) == "Y";
            CustomerBill customerBill = objCustomerBill;
            if (moduleRuleByIdAndRuleId)
            {
                loginLocationId = 1;
            }
            else
            {
                loginLocationId = SessionUtility.LoginLocationId;
            }
            customerBill.GenerationLocationId = loginLocationId;
            objCustomerBill.GenerationUserId = SessionUtility.LoginUserId;
            objCustomerBill.GenerationUserName = SessionUtility.LoginUserName;
            CustomerBill customerBill1 = objCustomerBill;

            if (moduleRuleByIdAndRuleId)
            {
                num = 1;
            }
            else
            {
                num = SessionUtility.LoginLocationId;
            }
            customerBill1.LocationId = num;
            objCustomerBill.FinYear = SessionUtility.FinYear;
            objCustomerBill.CompanyId = SessionUtility.CompanyId;
            objCustomerBill.EntryBy = SessionUtility.LoginUserId;

            objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);

            //if (objCustomerBill.PaybasId != 3)
            //{
            //    objCustomerBill.Details.RemoveAll((CustomerBillDetail m) => !m.IsChecked);
            //}

            bool flag = this.rulesRepository.GetModuleRuleByIdAndRuleId(15, 3) == "Y";
            Response response;


            if (Session["ClickResponse"] == null)
            {
                response = this.customerBillRepository.Generate(objCustomerBill);
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).TransactionCategoryList = this.gstRepository.GetGstServiceTypeList();
                action = base.View(objCustomerBill);
            }
            else
            {
                action = base.RedirectToAction("GenerationDone", new { documentNo = response.DocumentNo, BillId = response.DocumentId, BillType = objCustomerBill.PaybasId, CustomerId = objCustomerBill.CustomerId, TransportModeId = objCustomerBill.TransportModeId, ServiceTypeId = objCustomerBill.ServiceTypeId, FtlTypeId = objCustomerBill.FtlTypeId, UseTransportModeServiceType = flag });
            }
            return action;
        }


    }
}