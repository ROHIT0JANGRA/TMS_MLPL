using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class JobOrderWorkGroupController : Controller
  {
    private readonly IJobOrderWorkGroupRepository jobOrderWorkGroupRepository;

    public JobOrderWorkGroupController()
    {
    }

    public JobOrderWorkGroupController(
      IJobOrderWorkGroupRepository _jobOrderWorkGroupRepository)
    {
      this.jobOrderWorkGroupRepository = _jobOrderWorkGroupRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.jobOrderWorkGroupRepository.GetAll());
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterJobOrderWorkGroup detailById = this.jobOrderWorkGroupRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

    public ActionResult Insert(byte? id)
    {
      MasterJobOrderWorkGroup jobOrderWorkGroup = new MasterJobOrderWorkGroup();
      byte? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        jobOrderWorkGroup = this.jobOrderWorkGroupRepository.GetDetailById(id.Value);
      return (ActionResult) this.View((object) jobOrderWorkGroup);
    }

    [HttpPost]
    [ValidateAntiModelInjection("WorkGroupId")]
    public ActionResult Insert(MasterJobOrderWorkGroup ObjWorkGroup)
    {
      if (this.ModelState.IsValid)
      {
        ObjWorkGroup.EntryBy = SessionUtility.LoginUserId;
        ObjWorkGroup.UpdateBy = new short?(SessionUtility.LoginUserId);
        Response response = ObjWorkGroup.WorkGroupId <= (byte) 0 ? this.jobOrderWorkGroupRepository.Insert(ObjWorkGroup) : this.jobOrderWorkGroupRepository.Update(ObjWorkGroup);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
        this.TempData["result"] = (object) response;
      }
      return (ActionResult) this.View((object) ObjWorkGroup);
    }

    [HttpPost]
    [ValidateAntiModelInjection("WorkGroupId")]
    public JsonResult IsWorkGroupAvailable(MasterJobOrderWorkGroup ObjWorkGroup)
    {
      return this.Json((object) this.jobOrderWorkGroupRepository.IsWorkGroupAvailable(ObjWorkGroup.WorkGroup, ObjWorkGroup.WorkGroupId));
    }

    public JsonResult GetCardListByVehicleId()
    {
      return this.Json((object) this.jobOrderWorkGroupRepository.GetWorkGroupList());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.jobOrderWorkGroupRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
