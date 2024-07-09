using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.Master.Repository;
using Secure_Coding.MvcSecurityExtensions;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsRepository accountsRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IGstRepository gstRepository;
        public AccountsController()
        {
        }
        public AccountsController(IAccountsRepository _accountsRepository, IAccountRepository _accountRepository, IGeneralRepository _generalRepository, IGstRepository _gstRepository)
        {
            this.accountsRepository = _accountsRepository;
            this.accountRepository = _accountRepository;
            this.generalRepository = _generalRepository;
            this.gstRepository = _gstRepository;

        }

        public ActionResult VoucherCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VoucherCancellation(VoucherCancellation objVoucherCancellation)
        {
            ActionResult action;
            Response response = new Response();
            objVoucherCancellation.Details.RemoveAll((VoucherCancellationDetail m) => !m.IsChecked);
            objVoucherCancellation.Details.ForEach((VoucherCancellationDetail m) => m.CancelBy = new short?(SessionUtility.LoginUserId));
            if (!this.accountsRepository.VoucherCancellation(objVoucherCancellation).IsSuccessfull)
            {
                action = base.View(objVoucherCancellation);
            }
            else
            {
                action = base.RedirectToAction("VoucherCancellationDone");
            }
            return action;
        }
        public ActionResult VoucherCancellationDone()
        {
            return base.View();
        }


        public ActionResult AdviceCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdviceCancellation(AdviceCancellation objAdviceCancellation)
        {
            ActionResult action;
            Response response = new Response();
            objAdviceCancellation.Details.RemoveAll((AdviceCancellationDetail m) => !m.IsChecked);
            objAdviceCancellation.Details.ForEach((AdviceCancellationDetail m) => m.CancelBy = new short?(SessionUtility.LoginUserId));
            if (!this.accountsRepository.AdviceCancellation(objAdviceCancellation).IsSuccessfull)
            {
                action = base.View(objAdviceCancellation);
            }
            else
            {
                action = base.RedirectToAction("AdviceCancellationDone");
            }
            return action;
        }
        public ActionResult AdviceCancellationDone()
        {
            return base.View();
        }

        public JsonResult GetAdvicerForCancellation(string AdviceNos, DateTime fromDate, DateTime toDate)
        {

            JsonResult jsonResult = base.Json(this.accountsRepository.GetAdviceCancellation(AdviceNos, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetVoucherForCancellation(string VoucherNos, DateTime fromDate, DateTime toDate)
        {

            JsonResult jsonResult = base.Json(this.accountsRepository.GetVoucherCancellation(VoucherNos, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.CompanyId));
            return jsonResult;
        }

        public ActionResult Advice()
        {
            return base.View(new Advice());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Advice(Advice objAdvice)
        {
            ActionResult action;
            this.ModelState.Remove("PaymentDetails.TdsAccountId");
            if (base.ModelState.IsValid)
            {
                Response response = new Response();
                objAdvice.CompanyId = SessionUtility.CompanyId;
                objAdvice.EntryBy = SessionUtility.LoginUserId;
                objAdvice.LocationCode = SessionUtility.LoginLocationCode;
                objAdvice.FinYear = SessionUtility.FinYear;
                response = this.accountsRepository.Advice(objAdvice);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("AdviceDone", new { documentNo = response.DocumentNo, documentId = response.DocumentId, documentNo2 = response.DocumentNo2, documentId2 = response.DocumentId2, status = "AdviceGenerateDone" });
                    return action;
                }
                base.TempData["result"] = response;
            }
            action = base.View(objAdvice);
            return action;
        }

        public ActionResult AdviceAcknowledgement()
        {
            AdviceAcknowledgement adviceAcknowledgement = new AdviceAcknowledgement();
            SelectList selectList = new SelectList(this.accountRepository.GetAccountListByAccountCategoryId(5), "Value", "Description");
            SelectList selectList1 = new SelectList(this.accountRepository.GetAccountListByAccountCategoryId(6), "Value", "Description");
            ((dynamic)base.ViewBag).BankAccountList = JsonConvert.SerializeObject(selectList1);
            ((dynamic)base.ViewBag).CashAccountList = JsonConvert.SerializeObject(selectList);
            return base.View(adviceAcknowledgement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdviceAcknowledgement(AdviceAcknowledgement objAdviceAcknowledgement)
        {
            ActionResult action;
            objAdviceAcknowledgement.Details.RemoveAll((AdviceAcknowledgementDetail m) => !m.IsChecked);
            objAdviceAcknowledgement.Details.ForEach((AdviceAcknowledgementDetail m) => m.AcknowledgementBy = SessionUtility.LoginUserId);
            objAdviceAcknowledgement.Details.ForEach((AdviceAcknowledgementDetail m) => m.FinYear = SessionUtility.FinYear);
            Response response = this.accountsRepository.AdviceAcknowledgement(objAdviceAcknowledgement);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(68);
                action = base.View(objAdviceAcknowledgement);
            }
            else
            {
                action = base.RedirectToAction("AdviceAcknowledgementDone", new { documentId = response.DocumentId });
            }
            return action;
        }

        public ActionResult AdviceAcknowledgementDone(long documentId)
        {
            List<Advice> advices = new List<Advice>();
            advices.AddRange(this.accountsRepository.GetAdviceListByAcknowledgementId(documentId));
            return base.View(advices);
        }

        public ActionResult AdviceDone()
        {
            return base.View();
        }
        public ActionResult ContraVoucher()
        {
            ContraVoucher contraVoucher = new ContraVoucher();
            contraVoucher.Details.Add(new ContraVoucherDetail());
            contraVoucher.Details.Add(new ContraVoucherDetail());
            SelectList selectList = new SelectList(this.accountsRepository.GetAccountCodeListForPaymentModeBank(), "Value", "Text");
            ((dynamic)base.ViewBag).AccountCodeListForPaymentModeBank = JsonConvert.SerializeObject(selectList);
            this.Init();
            return base.View(contraVoucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContraVoucher(ContraVoucher objContraVoucher)
        {
            ActionResult action;
            objContraVoucher.LocationCode = SessionUtility.LoginLocationCode;
            objContraVoucher.EntryBy = SessionUtility.LoginUserId;
            objContraVoucher.PreparedById = SessionUtility.CompanyId;
            objContraVoucher.PreparedByCode = SessionUtility.CompanyCode;
            objContraVoucher.PreparedByName = SessionUtility.CompanyName;
            objContraVoucher.FinYear = SessionUtility.FinYear;
            objContraVoucher.UpdateBy = new short?(SessionUtility.LoginUserId);
            objContraVoucher.UpdateDate = new DateTime?(DateTime.Now);
            Response response = this.accountsRepository.ContraVoucher(objContraVoucher);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                SelectList selectList = new SelectList(this.accountsRepository.GetAccountCodeListForPaymentModeBank(), "Value", "Text");
                ((dynamic)base.ViewBag).AccountCodeListForPaymentModeBank = JsonConvert.SerializeObject(selectList);
                this.Init();
                action = base.View(objContraVoucher);
            }
            else
            {
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "ContraVoucher" });
            }
            return action;
        }

        public ActionResult CreditDebitVoucher()
        {
            CreditDebitVoucher creditDebitVoucher = new CreditDebitVoucher();
            creditDebitVoucher.Details.Add(new CreditDebitVoucherDetail());
            this.Init();
            return base.View(creditDebitVoucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreditDebitVoucher(CreditDebitVoucher objCreditDebitVoucher)
        {
            string str;
            ActionResult action;
            long documentId;
            long? partyGstId;
            HttpPostedFileBase attachment = objCreditDebitVoucher.Attachment;
            HttpPostedFileBase vendorInvoiceAttachment = objCreditDebitVoucher.VendorInvoiceAttachment;
            objCreditDebitVoucher.CompanyId = SessionUtility.CompanyId;
            objCreditDebitVoucher.FinYear = SessionUtility.FinYear;
            objCreditDebitVoucher.LocationId = SessionUtility.LoginLocationId;
            objCreditDebitVoucher.LocationCode = SessionUtility.LoginLocationCode;
            objCreditDebitVoucher.EntryBy = SessionUtility.LoginUserId;
            objCreditDebitVoucher.Attachment = null;
            objCreditDebitVoucher.VendorInvoiceAttachment = null;
            this.ModelState.Remove("PaymentDetails.TdsAccountId");
            /* if (objCreditDebitVoucher.PaymentDetails.PaymentMode == 8)
             {
                 objCreditDebitVoucher.PaymentDetails.CashAccountId = objCreditDebitVoucher.PaymentDetails.BaAccountID;

             }
             if (objCreditDebitVoucher.ReceiptDetails.ReceiptMode == 8)
             {
                 objCreditDebitVoucher.ReceiptDetails.CashAccountId = objCreditDebitVoucher.ReceiptDetails.BaAccountID;

             } */
            Response response = this.accountsRepository.CreditDebitVoucher(objCreditDebitVoucher);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.Init();
                action = base.View(objCreditDebitVoucher);
            }
            else
            {
                string fileName = "";
                if (attachment != null)
                {
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        documentId = response.DocumentId;
                        fileName = AzureStorageHelper.GetFileName("Voucher", "Voucher", documentId.ToString(), SessionUtility.LoginLocationCode, attachment.FileName);
                    }
                    else
                    {
                        documentId = response.DocumentId;
                        fileName = string.Concat(documentId.ToString(), "_", attachment.FileName);
                    }
                }
                if (fileName != "")
                {
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        AzureStorageHelper.UploadBlob("Voucher", attachment, fileName, fileName);
                    }
                    else
                    {
                        str = string.Concat(ConfigHelper.LocalStoragePath, "DECL/", fileName);
                        attachment.SaveAs(str);
                    }
                }
                string fileName1 = "";
                if (vendorInvoiceAttachment != null)
                {
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        documentId = response.DocumentId;
                        fileName1 = AzureStorageHelper.GetFileName("Voucher", "Voucher", documentId.ToString(), SessionUtility.LoginLocationCode, vendorInvoiceAttachment.FileName);
                    }
                    else
                    {
                        documentId = response.DocumentId;
                        fileName1 = string.Concat(documentId.ToString(), "_", vendorInvoiceAttachment.FileName);
                    }
                }
                if (fileName1 != "")
                {
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        AzureStorageHelper.UploadBlob("Voucher", vendorInvoiceAttachment, fileName1, fileName1);
                    }
                    else
                    {
                        str = string.Concat(ConfigHelper.LocalStoragePath, "Voucher/", fileName1);
                        vendorInvoiceAttachment.SaveAs(str);
                    }
                }
                VoucherSummary voucherSummary = new VoucherSummary()
                {
                    VoucherId = response.DocumentId,
                    BusinessTypeId = objCreditDebitVoucher.BusinessTypeId,
                    Remarks = objCreditDebitVoucher.Remarks,
                    ReferenceNo = objCreditDebitVoucher.ReferenceNo,
                    AccountingLocationId = objCreditDebitVoucher.AccountingLocationId,
                    CompanyGstId = new long?((long)objCreditDebitVoucher.CompanyGstId),
                    SubTotal = objCreditDebitVoucher.SubTotal,
                    Igst = objCreditDebitVoucher.Igst,
                    Cgst = objCreditDebitVoucher.Cgst,
                    Sgst = objCreditDebitVoucher.Sgst,
                    Ugst = objCreditDebitVoucher.Ugst,
                    TaxTotal = objCreditDebitVoucher.GstTotal,
                    TdsAccountId = objCreditDebitVoucher.TdsAccountId,
                    TdsRate = objCreditDebitVoucher.TdsRate,
                    TdsAmount = objCreditDebitVoucher.TdsAmount,
                    GrandTotal = objCreditDebitVoucher.Amount,
                    NetAmount = objCreditDebitVoucher.NetAmount,
                    GstExemptedCategory = objCreditDebitVoucher.GstExemptedCategory,
                    DocumentName = fileName,
                    VendorInvoiceDocumentName = fileName1
                };
                VoucherSummary voucherSummary1 = voucherSummary;
                if (objCreditDebitVoucher.IsPartyRegistered)
                {
                    partyGstId = objCreditDebitVoucher.PartyGstId;
                }
                else
                {
                    partyGstId = null;
                }
                voucherSummary1.PartyGstId = partyGstId;
                voucherSummary.PartyStateId = new short?(objCreditDebitVoucher.PartyGstStateId);
                List<VoucherAccountDetail> voucherAccountDetails = new List<VoucherAccountDetail>();
                foreach (CreditDebitVoucherDetail detail in objCreditDebitVoucher.Details)
                {
                    VoucherAccountDetail voucherAccountDetail = new VoucherAccountDetail()
                    {
                        VoucherId = response.DocumentId,
                        IsGstExempted = detail.GstExempted,
                        IsTdsExempted = detail.TdsExempted,
                        IsProduct = detail.IsProduct,
                        AccountId = detail.AccountId,
                        SacId = detail.SacId,
                        Units = detail.Units,
                        Narration = (string.IsNullOrEmpty(detail.Narration) ? string.Empty : detail.Narration),
                        Amount = detail.Amount,
                        GstAmount = detail.GstAmount,
                        GstCharged = detail.GstCharged,
                        TotalAmount = detail.TotalAmount,
                        CostCenterType = detail.CostCenterType,
                        CostCenterId = (long)detail.CostCenterId,
                        GstRate = detail.GstRate
                    };
                    voucherAccountDetails.Add(voucherAccountDetail);
                }
                voucherSummary.VoucherAccountDetailList = voucherAccountDetails;
                this.accountsRepository.VoucherSummary(voucherSummary);
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "CreditDebitVoucher" });
            }
            return action;
        }

        public ActionResult CrossLocationVoucher()
        {
            CrossLocationVoucher crossLocationVoucher = new CrossLocationVoucher();
            crossLocationVoucher.Details.Add(new CrossLocationVoucherDetail());
            this.Init();
            return base.View(crossLocationVoucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrossLocationVoucher(CrossLocationVoucher objCrossLocationVoucher)
        {
            ActionResult action;
            Response response = this.accountsRepository.CrossLocationVoucher(objCrossLocationVoucher);
            string transactionTypeByVoucherId = this.accountsRepository.GetTransactionTypeByVoucherId(response.DocumentId2);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.Init();
                action = base.View(objCrossLocationVoucher);
            }
            else
            {
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, documentNo2 = response.DocumentNo2, documentId2 = response.DocumentId2, transactionType = transactionTypeByVoucherId, status = "CrossLocationVoucher" });
            }
            return action;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.accountsRepository.Dispose();
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
        }

        public ActionResult Done()
        {
            return base.View();
        }

        public JsonResult GetAdviceListForAcknowledgement(string adviceNos, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.accountsRepository.GetAdviceListForAcknowledgement(adviceNos, fromDate, toDate, SessionUtility.LoginLocationId, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.CompanyId));
            return jsonResult;
        }

        public void Init()
        {
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).SacList = this.gstRepository.GetSacList();
            ((dynamic)base.ViewBag).TdsList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            ((dynamic)base.ViewBag).CostCenterList = this.generalRepository.GetByIdList(33);
        }

        public ActionResult JournalVoucher()
        {
            JournalVoucher journalVoucher = new JournalVoucher();
            journalVoucher.Details.Add(new JournalVoucherDetail());
            journalVoucher.Details.Add(new JournalVoucherDetail());
            this.Init();
            return base.View(journalVoucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JournalVoucher(JournalVoucher objJournalVoucher)
        {
            ActionResult action;
            objJournalVoucher.CompanyId = SessionUtility.CompanyId;
            objJournalVoucher.PreparedLocationId = SessionUtility.LoginLocationId;
            objJournalVoucher.PreparedLocationCode = SessionUtility.LoginLocationCode;
            objJournalVoucher.EntryBy = SessionUtility.LoginUserId;
            objJournalVoucher.FinYear = SessionUtility.FinYear;
            Response response = this.accountsRepository.JournalVoucher(objJournalVoucher);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.Init();
                action = base.View(objJournalVoucher);
            }
            else
            {
                VoucherSummary voucherSummary = new VoucherSummary()
                {
                    VoucherId = response.DocumentId,
                    BusinessTypeId = 0,
                    Remarks = "",
                    ReferenceNo = objJournalVoucher.ReferenceNo,
                    AccountingLocationId = SessionUtility.LoginLocationId,
                    SubTotal = (objJournalVoucher.CreditAmount > new decimal(0) ? objJournalVoucher.CreditAmount : objJournalVoucher.DebitAmount),
                    GrandTotal = (objJournalVoucher.CreditAmount > new decimal(0) ? objJournalVoucher.CreditAmount : objJournalVoucher.DebitAmount),
                    NetAmount = (objJournalVoucher.CreditAmount > new decimal(0) ? objJournalVoucher.CreditAmount : objJournalVoucher.DebitAmount),
                    GstExemptedCategory = 0,
                    DocumentName = "",
                    VendorInvoiceDocumentName = ""
                };
                List<VoucherAccountDetail> voucherAccountDetails = new List<VoucherAccountDetail>();
                foreach (JournalVoucherDetail detail in objJournalVoucher.Details)
                {
                    VoucherAccountDetail voucherAccountDetail = new VoucherAccountDetail()
                    {
                        VoucherId = response.DocumentId,
                        IsGstExempted = false,
                        IsTdsExempted = false,
                        IsProduct = false,
                        AccountId = detail.AccountId,
                        Narration = (string.IsNullOrEmpty(detail.Narration) ? string.Empty : detail.Narration),
                        Amount = (detail.Credit > new decimal(0) ? detail.Credit : detail.Debit),
                        CostCenterType = (objJournalVoucher.CostCenterSelection ? objJournalVoucher.CostCenterType : detail.CostCenterType),
                        CostCenterId = (long)((objJournalVoucher.CostCenterSelection ? objJournalVoucher.CostCenterId : detail.CostCenterId))
                    };
                    voucherAccountDetails.Add(voucherAccountDetail);
                }
                voucherSummary.VoucherAccountDetailList = voucherAccountDetails;
                this.accountsRepository.VoucherSummary(voucherSummary);
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "JournalVoucher" });
            }
            return action;
        }

        public ActionResult MultipleVoucher()
        {
            MultipleVoucher multipleVoucher = new MultipleVoucher();
            multipleVoucher.Details.Add(new MultipleVoucherDetail());
            multipleVoucher.Details.Add(new MultipleVoucherDetail());
            this.Init();
            return base.View(multipleVoucher);
        }

        public ActionResult SpecialCostVoucher()
        {
            SpecialCostVoucher specialCostVoucher = new SpecialCostVoucher();
            specialCostVoucher.Details.Add(new SpecialCostVoucherDetail());
            this.Init();
            return base.View(specialCostVoucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SpecialCostVoucher(SpecialCostVoucher objSpecialCostVoucher)
        {
            ActionResult action;
            long documentId;
            long? partyGstId;
            HttpPostedFileBase attachment = objSpecialCostVoucher.Attachment;

            objSpecialCostVoucher.CompanyId = SessionUtility.CompanyId;
            objSpecialCostVoucher.FinYear = SessionUtility.FinYear;
            objSpecialCostVoucher.LocationId = SessionUtility.LoginLocationId;
            objSpecialCostVoucher.LocationCode = SessionUtility.LoginLocationCode;
            objSpecialCostVoucher.EntryBy = SessionUtility.LoginUserId;
            objSpecialCostVoucher.Attachment = null;
            /* if (objSpecialCostVoucher.PaymentDetails.PaymentMode == 8)
             {
                 objSpecialCostVoucher.PaymentDetails.CashAccountId = objSpecialCostVoucher.PaymentDetails.BaAccountID;

             }*/
            Response response = this.accountsRepository.SpecialCostVoucher(objSpecialCostVoucher);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.Init();
                action = base.View(objSpecialCostVoucher);
            }
            else
            {
                string fileName = "";
                if (attachment != null)
                {
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        documentId = response.DocumentId;
                        fileName = AzureStorageHelper.GetFileName("Voucher", "Voucher", documentId.ToString(), SessionUtility.LoginLocationCode, attachment.FileName);
                    }
                    else
                    {
                        documentId = response.DocumentId;
                        fileName = string.Concat(documentId.ToString(), "_", attachment.FileName);
                    }
                }
                if (fileName != "")
                {
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        AzureStorageHelper.UploadBlob("Voucher", attachment, fileName, fileName);
                    }
                    else
                    {
                        string str = string.Concat(ConfigHelper.LocalStoragePath, "DECL/", fileName);
                        attachment.SaveAs(str);
                    }
                }
                VoucherSummary voucherSummary = new VoucherSummary()
                {
                    VoucherId = response.DocumentId,
                    BusinessTypeId = objSpecialCostVoucher.BusinessTypeId,
                    Remarks = "",
                    ReferenceNo = objSpecialCostVoucher.ReferenceNo,
                    AccountingLocationId = objSpecialCostVoucher.AccountingLocationId,
                    CompanyGstId = new long?((long)objSpecialCostVoucher.CompanyGstId),
                    SubTotal = objSpecialCostVoucher.SubTotal,
                    Igst = objSpecialCostVoucher.Igst,
                    Cgst = objSpecialCostVoucher.Cgst,
                    Sgst = objSpecialCostVoucher.Sgst,
                    Ugst = objSpecialCostVoucher.Ugst,
                    TaxTotal = objSpecialCostVoucher.GstTotal,
                    TdsAccountId = objSpecialCostVoucher.TdsAccountId,
                    TdsRate = objSpecialCostVoucher.TdsRate,
                    TdsAmount = objSpecialCostVoucher.TdsAmount,
                    GrandTotal = objSpecialCostVoucher.Amount,
                    NetAmount = objSpecialCostVoucher.NetAmount,
                    GstExemptedCategory = objSpecialCostVoucher.GstExemptedCategory,
                    DocumentName = fileName,
                    VendorInvoiceDocumentName = ""
                };
                VoucherSummary voucherSummary1 = voucherSummary;
                if (objSpecialCostVoucher.IsPartyRegistered)
                {
                    partyGstId = objSpecialCostVoucher.PartyGstId;
                }
                else
                {
                    partyGstId = null;
                }
                voucherSummary1.PartyGstId = partyGstId;
                voucherSummary.PartyStateId = new short?(objSpecialCostVoucher.PartyGstStateId);
                List<VoucherAccountDetail> voucherAccountDetails = new List<VoucherAccountDetail>();
                foreach (SpecialCostVoucherDetail detail in objSpecialCostVoucher.Details)
                {
                    VoucherAccountDetail voucherAccountDetail = new VoucherAccountDetail()
                    {
                        VoucherId = response.DocumentId,
                        IsGstExempted = detail.GstExempted,
                        IsTdsExempted = detail.TdsExempted,
                        IsProduct = detail.IsProduct,
                        AccountId = detail.AccountId,
                        SacId = detail.SacId,
                        Units = detail.Units,
                        Narration = (string.IsNullOrEmpty(detail.Narration) ? string.Empty : detail.Narration),
                        Amount = detail.Amount,
                        GstAmount = detail.GstAmount,
                        GstCharged = detail.GstCharged,
                        TotalAmount = detail.TotalAmount,
                        DocumentTypeId = objSpecialCostVoucher.DocumentTypeId,
                        DocumentId = detail.DocumentId,
                        CostCenterType = detail.CostCenterType,
                        CostCenterId = (long)detail.CostCenterId,
                        GstRate = detail.GstRate
                    };
                    voucherAccountDetails.Add(voucherAccountDetail);
                }
                voucherSummary.VoucherAccountDetailList = voucherAccountDetails;
                this.accountsRepository.VoucherSummary(voucherSummary);
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "SpecialCostVoucher" });
            }
            return action;
        }

        public ActionResult CustomerVendorAdjustment()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult CustomerVendorAdjustment(CustomerVendorAdjustment objCustomerVendorAdjustment)
        {
            objCustomerVendorAdjustment.CompanyId = SessionUtility.CompanyId;
            objCustomerVendorAdjustment.LocationId = SessionUtility.LoginLocationId;
            objCustomerVendorAdjustment.EntryBy = SessionUtility.LoginUserId;
            objCustomerVendorAdjustment.FinYear = SessionUtility.FinYear;
            Response response = this.accountsRepository.CustomerVendorAdjustment(objCustomerVendorAdjustment);
            if (response.IsSuccessfull)
            {
                return base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "CustomerVendorAdjustmentDone" });
            }
            return base.View(objCustomerVendorAdjustment);
        }

        public JsonResult GetCustomerBillListForAdjustment(
         short vendorId,
         short customerId,
         DateTime fromDate,
         DateTime toDate,
         string billNos,
         string manualbillNos)
        {
            return this.Json((object)this.accountsRepository.GetCustomerBillListForAdjustment(vendorId, customerId, fromDate, toDate, billNos, manualbillNos));
        }
        public JsonResult GetVendorBillListForAdjustment(
       short vendorId,
       short customerId,
       DateTime fromDate,
       DateTime toDate,
       string billNos,
       string manualbillNos)
        {
            return this.Json((object)this.accountsRepository.GetVendorBillListForAdjustment(vendorId, customerId, fromDate, toDate, billNos, manualbillNos));
        }

        public JsonResult GetAdjustmentList()
        {
            return this.Json((object)this.accountsRepository.GetAdjustmentList());
        }
    }
}
