//  
// Type: CodeLock.Areas.FMS.Controllers.JobOrderController
//  
//  
//  

using CodeLock.Areas.FMS.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.FMS.Controllers
{
  public class JobOrderController : Controller
  {
    private readonly IJobOrderRepository jobOrderRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly IJobOrderWorkGroupRepository jobOrderWorkGroupRepository;
    private readonly IJobOrderTaskTypeRepository jobOrderTaskTypeRepository;
    private readonly ILocationRepository locationRepository;
    private readonly IVendorRepository vendorRepository;
    private readonly ISkuRepository skuRepository;

        public JobOrderController()
        {
        }

        public JobOrderController(IJobOrderRepository _jobOrderRepository, IGeneralRepository _generalRepository, IJobOrderWorkGroupRepository _jobOrderWorkGroupRepository, IJobOrderTaskTypeRepository _jobOrderTaskTypeRepository, ILocationRepository _locationRepository, IVendorRepository _vendorRepository, ISkuRepository _skuRepository)
        {
            this.jobOrderRepository = _jobOrderRepository;
            this.generalRepository = _generalRepository;
            this.jobOrderWorkGroupRepository = _jobOrderWorkGroupRepository;
            this.jobOrderTaskTypeRepository = _jobOrderTaskTypeRepository;
            this.locationRepository = _locationRepository;
            this.vendorRepository = _vendorRepository;
            this.skuRepository = _skuRepository;
        }

        public ActionResult Approve()
        {
            this.Init();
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(JobOrderApprove objJobOrderApprove)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                Response response = this.jobOrderRepository.Approve(objJobOrderApprove);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("Done", new { status = "ApprovalDone" });
                    return action;
                }
                base.TempData["result"] = response;
            }
            this.Init();
            action = base.View(objJobOrderApprove);
            return action;
        }

        [HttpPost]
        public JsonResult CheckValidVehicleNoForJobOrder(string vehicleNo)
        {
            return base.Json(this.jobOrderRepository.CheckValidVehicleNoForJobOrder(vehicleNo));
        }

        public ActionResult Close(long? id)
        {
            JobOrder jobOrder = new JobOrder()
            {
                TaskDetails = new List<TaskDetail>(),
                SparePartDetails = new List<SparePartDetail>()
            };
            JobOrder byId = jobOrder;
            if (id.HasValue)
            {
                byId = this.jobOrderRepository.GetById(id.Value);
                byId.TaskDetails = this.jobOrderRepository.GetTaskDetailById(id.Value).ToList<TaskDetail>();
                byId.SparePartDetails = this.jobOrderRepository.GetSparePartDetailById(id.Value).ToList<SparePartDetail>();
            }
            return base.View(byId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Close(JobOrder objJobOrder)
        {
            ActionResult action;
            objJobOrder.CloseBy = SessionUtility.LoginUserId;
            Response response = this.jobOrderRepository.Close(objJobOrder);
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.Init();
                action = base.View(objJobOrder);
            }
            else
            {
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, status = "CloseDone" });
            }
            return action;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.jobOrderRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Done()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult GetJobOrderListForApprove(DateTime fromDate, DateTime toDate, string jobOrderNo, byte jobCardType)
        {
            JsonResult jsonResult = base.Json(this.jobOrderRepository.GetJobOrderListForApprove(fromDate, toDate, jobOrderNo, jobCardType, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }


        [HttpPost]
        public JsonResult GetJobOrderListForUpdate(DateTime fromDate, DateTime toDate, string jobOrderNo, byte jobCardType)
        {
            JsonResult jsonResult = base.Json(this.jobOrderRepository.GetJobOrderListForUpdate(fromDate, toDate, jobOrderNo, jobCardType, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        private void Init()
        {
            ((dynamic)base.ViewBag).JobCardTypeList = this.generalRepository.GetByIdList(73);
            ((dynamic)base.ViewBag).WorkGroupList = this.jobOrderWorkGroupRepository.GetWorkGroupList();
            ((dynamic)base.ViewBag).TaskTypeList = this.jobOrderTaskTypeRepository.GetTaskTypeList();
            IEnumerable<AutoCompleteResult> locationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).LocationList = JsonConvert.SerializeObject(locationList);
            IEnumerable<AutoCompleteResult> vendorListByVendorTypeId = this.vendorRepository.GetVendorListByVendorTypeId(7);
            ((dynamic)base.ViewBag).VendorList = JsonConvert.SerializeObject(vendorListByVendorTypeId);
            ((dynamic)base.ViewBag).SkuList = this.skuRepository.GetSkuList();
        }

        public ActionResult Insert(long? id)
        {
            JobOrder jobOrder = new JobOrder()
            {
                TaskDetails = new List<TaskDetail>(),
                SparePartDetails = new List<SparePartDetail>()
            };
            JobOrder byId = jobOrder;
            if (!id.HasValue)
            {
                List<TaskDetail> taskDetails = byId.TaskDetails;
                TaskDetail taskDetail = new TaskDetail()
                {
                    WorkGroupId = 0,
                    TaskId = 0,
                    TaskTypeId = 0,
                    EstimatedLabourHours = 0,
                    EstimatedLabourCost = new decimal(0),
                    Remarks = ""
                };
                taskDetails.Add(taskDetail);
                List<SparePartDetail> sparePartDetails = byId.SparePartDetails;
                SparePartDetail sparePartDetail = new SparePartDetail()
                {
                    SkuId = 0,
                    TaskTypeId = 0,
                    RequestedQuantity = 0,
                    CostPerUnit = new decimal(0),
                    Cost = new decimal(0),
                    Remarks = ""
                };
                sparePartDetails.Add(sparePartDetail);
            }
            else
            {
                byId = this.jobOrderRepository.GetById(id.Value);
                byId.TaskDetails = this.jobOrderRepository.GetTaskDetailById(id.Value).ToList<TaskDetail>();
                byId.SparePartDetails = this.jobOrderRepository.GetSparePartDetailById(id.Value).ToList<SparePartDetail>();
            }
            this.Init();
            return base.View(byId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(JobOrder objJobOrder)
        {
            Response response;
            ActionResult action;
            string str = (objJobOrder.JobOrderId > (long)0 ? "UpdateDone" : "GenerateDone");
            objJobOrder.EntryBy = SessionUtility.LoginUserId;
            objJobOrder.UpdateBy = new short?(SessionUtility.LoginUserId);
            response = (objJobOrder.JobOrderId <= (long)0 ? this.jobOrderRepository.Insert(objJobOrder) : this.jobOrderRepository.Update(objJobOrder));
            if (!response.IsSuccessfull)
            {
                base.TempData["result"] = response;
                this.Init();
                action = base.View(objJobOrder);
            }
            else
            {
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId, spareRequestNo = response.DocumentNo2, spareRequestId = response.DocumentId2, status = str });
            }
            return action;
        }

        public ActionResult Update()
        {
            this.Init();
            return base.View();
        }


    }
}
