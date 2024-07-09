//  
// Type: CodeLock.Areas.Finance.Controllers.PurchaseOrderController
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
  public class PurchaseOrderController : Controller
  {
    private readonly IPurchaseOrderRepository purchaseOrderRepository;
    private readonly IGeneralRepository generalRepository;

        public PurchaseOrderController(IPurchaseOrderRepository _purchaseOrderRepository, IGeneralRepository _generalRepository)
        {
            this.purchaseOrderRepository = _purchaseOrderRepository;
            this.generalRepository = _generalRepository;
        }

        public ActionResult AdvancePayment()
        {
            return base.View(new PurchaseOrderAdvancePayment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdvancePayment(PurchaseOrderAdvancePayment objAdvancePayment)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objAdvancePayment);
            }
            else
            {
                objAdvancePayment.EntryBy = SessionUtility.LoginUserId;
                objAdvancePayment.FinYear = SessionUtility.FinYear;
                objAdvancePayment.CompanyId = SessionUtility.CompanyId;
                objAdvancePayment.LocationId = SessionUtility.LoginLocationId;
                Response response = this.purchaseOrderRepository.AdvancePayment(objAdvancePayment);
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, voucherId = response.DocumentId2, voucherNo = response.DocumentNo2, status = "AdvancePaymentDone" });
            }
            return action;
        }

        public ActionResult Approve()
        {
            return base.View(new PurchaseOrderApprove());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(PurchaseOrderApprove objPurchaseOrderApprove)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objPurchaseOrderApprove.Details.RemoveAll((PurchaseOrderApproveDetail m) => !m.IsChecked);
                objPurchaseOrderApprove.Details.ForEach((PurchaseOrderApproveDetail m) => m.ApproveDate = objPurchaseOrderApprove.ApproveDate);
                objPurchaseOrderApprove.Details.ForEach((PurchaseOrderApproveDetail m) => m.ApproveBy = SessionUtility.LoginUserId);
                if (this.purchaseOrderRepository.Approve(objPurchaseOrderApprove).IsSuccessfull)
                {
                    action = base.RedirectToAction("Done", new { status = "Approval" });
                    return action;
                }
            }
            action = base.View(objPurchaseOrderApprove);
            return action;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.purchaseOrderRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Done()
        {
            return base.View();
        }

        public JsonResult GetDetailById(long poId)
        {
            return base.Json(this.purchaseOrderRepository.GetDetailById(poId));
        }

        public JsonResult GetPurchaseOrderListForAdvancePayment(DateTime fromDate, DateTime toDate, short vendorId, string poNo, string manualPoNo)
        {
            JsonResult jsonResult = base.Json(this.purchaseOrderRepository.GetPurchaseOrderListForAdvancePayment(fromDate, toDate, vendorId, SessionUtility.FinStartDate, SessionUtility.FinEndDate, poNo, manualPoNo, SessionUtility.LoginLocationId));
            return jsonResult;
        }
        public JsonResult GetPurchaseOrderListForApproval(DateTime fromDate, DateTime toDate, short vendorId, string poNo, string manualPoNo)
        {
            JsonResult jsonResult = base.Json(this.purchaseOrderRepository.GetPurchaseOrderListForApproval(fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, vendorId, poNo, manualPoNo, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        public JsonResult GetPurchaseOrderListForGrnInsert(DateTime fromDate, DateTime toDate, byte materialCategoryId, short vendorId, string poNo, string manualPoNo)
        {
            JsonResult jsonResult = base.Json(this.purchaseOrderRepository.GetPurchaseOrderListForGrnInsert(fromDate, toDate, materialCategoryId, vendorId, poNo, manualPoNo));
            return jsonResult;
        }

        public ActionResult Grn()
        {
            PoGrn poGrn = new PoGrn();
            ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            return base.View(poGrn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grn(PoGrn objPoGrn)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                if (base.ModelState.IsValid)
                {
                    objPoGrn.ReceivedBy = SessionUtility.LoginUserId;
                    Response response = this.purchaseOrderRepository.GrnInsert(objPoGrn);
                    if (response.IsSuccessfull)
                    {
                        action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "GrnDone" });
                        return action;
                    }
                }
            }
            ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            action = base.View(objPoGrn);
            return action;
        }

        public ActionResult Insert()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                Details = new List<PurchaseOrderDetail>()
            };
            List<PurchaseOrderDetail> details = purchaseOrder.Details;
            PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail()
            {
                SkuId = 0,
                SkuName = "",
                Description = "",
                Quantity = 0,
                Rate = new decimal(0),
                DiscountPercentage = new decimal(0),
                TaxPercentage = new decimal(0),
                TotalAmount = new decimal(0)
            };
            details.Add(purchaseOrderDetail);
            ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            return base.View(purchaseOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(PurchaseOrder objPurchaseOrder)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objPurchaseOrder.EntryBy = SessionUtility.LoginUserId;
                Response response = this.purchaseOrderRepository.Insert(objPurchaseOrder);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "PoGenerateDone" });
                    return action;
                }
            }
            ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            action = base.View(objPurchaseOrder);
            return action;
        }

        public ActionResult IssueSlip()
        {
            IssueSlip issueSlip = new IssueSlip()
            {
                Details = new List<IssueSlipDetail>()
            };
            List<IssueSlipDetail> details = issueSlip.Details;
            IssueSlipDetail issueSlipDetail = new IssueSlipDetail()
            {
                SkuId = 0,
                SkuName = "",
                Description = "",
                StockQuantity = 0,
                RequiredQuantity = 0,
                IssuedQuantity = 0,
                UnitPrice = new decimal(0),
                TotalAmount = new decimal(0)
            };
            details.Add(issueSlipDetail);
            ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            return base.View(issueSlip);
        }



    }
}
