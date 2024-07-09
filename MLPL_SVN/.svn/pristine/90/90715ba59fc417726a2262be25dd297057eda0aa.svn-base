using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class JobOrderTaskController : Controller
  {
    private readonly IJobOrderTaskRepository jobOrderTaskRepository;
    private readonly IJobOrderWorkGroupRepository jobOrderWorkGroupRepository;
    private readonly IJobOrderTaskTypeRepository jobOrderTaskTypeRepository;

    public JobOrderTaskController()
    {
    }

    public JobOrderTaskController(
      IJobOrderTaskRepository _jobOrderTaskRepository,
      IJobOrderWorkGroupRepository _jobOrderWorkGroupRepository,
      IJobOrderTaskTypeRepository _jobOrderTaskTypeRepository)
    {
      this.jobOrderTaskRepository = _jobOrderTaskRepository;
      this.jobOrderWorkGroupRepository = _jobOrderWorkGroupRepository;
      this.jobOrderTaskTypeRepository = _jobOrderTaskTypeRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.jobOrderTaskRepository.GetAll());
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterJobOrderTask detailById = this.jobOrderTaskRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }


        public ActionResult Insert(byte? id)
        {
            int? nullable;
            int? nullable1;
            MasterJobOrderTask masterJobOrderTask = new MasterJobOrderTask();
            byte? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?((int)nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                masterJobOrderTask = this.jobOrderTaskRepository.GetDetailById(id.Value);
            }
            ((dynamic)base.ViewBag).WorkGroupList = this.jobOrderWorkGroupRepository.GetWorkGroupList();
            ((dynamic)base.ViewBag).TaskTypeList = this.jobOrderTaskTypeRepository.GetTaskTypeList();
            return base.View(masterJobOrderTask);
        }

        [HttpPost]
        [ValidateAntiModelInjection("TaskId")]
        public ActionResult Insert(MasterJobOrderTask objTask)
        {
            Response response;
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objTask.EntryBy = SessionUtility.LoginUserId;
                objTask.UpdateBy = new short?(SessionUtility.LoginUserId);
                response = (objTask.TaskId <= 0 ? this.jobOrderTaskRepository.Insert(objTask) : this.jobOrderTaskRepository.Update(objTask));
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
                base.TempData["result"] = response;
            }
             ((dynamic)base.ViewBag).WorkGroupList = this.jobOrderWorkGroupRepository.GetWorkGroupList();
            ((dynamic)base.ViewBag).TaskTypeList = this.jobOrderTaskTypeRepository.GetTaskTypeList();
            action = base.View(objTask);
            return action;
        }

        public JsonResult IsTaskAvailable(
      byte workGroupId,
      byte taskTypeId,
      string task,
      short taskId)
    {
      return this.Json((object) this.jobOrderTaskRepository.IsTaskAvailable(workGroupId, taskTypeId, task, taskId));
    }

    public JsonResult GetTaskDescriptionListByWorkGroupIdAndTaskTypeId(
      byte workGroupId,
      byte taskTypeId)
    {
      return this.Json((object) this.jobOrderTaskRepository.GetTaskDescriptionListByWorkGroupIdAndTaskTypeId(workGroupId, taskTypeId));
    }

    public JsonResult GetEstimatedLabourHoursByTaskId(short taskId)
    {
      return this.Json((object) this.jobOrderTaskRepository.GetEstimatedLabourHoursByTaskId(taskId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.jobOrderTaskRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
