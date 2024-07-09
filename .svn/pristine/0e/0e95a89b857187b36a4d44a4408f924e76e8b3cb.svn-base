using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class JobOrderTaskTypeController : Controller
  {
    private readonly IJobOrderTaskTypeRepository jobOrderTaskTypeRepository;

    public JobOrderTaskTypeController()
    {
    }

    public JobOrderTaskTypeController(
      IJobOrderTaskTypeRepository _jobOrderTaskTypeRepository)
    {
      this.jobOrderTaskTypeRepository = _jobOrderTaskTypeRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.jobOrderTaskTypeRepository.GetAll());
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterJobOrderTaskType detailById = this.jobOrderTaskTypeRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

    public ActionResult Insert(byte? id)
    {
      MasterJobOrderTaskType jobOrderTaskType = new MasterJobOrderTaskType();
      byte? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        jobOrderTaskType = this.jobOrderTaskTypeRepository.GetDetailById(id.Value);
      return (ActionResult) this.View((object) jobOrderTaskType);
    }

    [HttpPost]
    [ValidateAntiModelInjection("TaskTypeId")]
    public ActionResult Insert(MasterJobOrderTaskType objTaskType)
    {
      if (this.ModelState.IsValid)
      {
        objTaskType.EntryBy = SessionUtility.LoginUserId;
        objTaskType.UpdateBy = new short?(SessionUtility.LoginUserId);
        Response response = objTaskType.TaskTypeId <= (byte) 0 ? this.jobOrderTaskTypeRepository.Insert(objTaskType) : this.jobOrderTaskTypeRepository.Update(objTaskType);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
        this.TempData["result"] = (object) response;
      }
      return (ActionResult) this.View((object) objTaskType);
    }

    [HttpPost]
    [ValidateAntiModelInjection("TaskTypeId")]
    public JsonResult IsTaskTypeAvailable(MasterJobOrderTaskType objTaskType)
    {
      return this.Json((object) this.jobOrderTaskTypeRepository.IsTaskTypeAvailable(objTaskType.TaskType, objTaskType.TaskTypeId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.jobOrderTaskTypeRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
