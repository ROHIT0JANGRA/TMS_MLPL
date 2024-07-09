using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class LocationHierarchyController : Controller
  {
    private readonly ILocationHierarchyRepository locationHierarchyRepository;

    public LocationHierarchyController()
    {
    }

    public LocationHierarchyController(
      ILocationHierarchyRepository _locationHierarchyRepository)
    {
      this.locationHierarchyRepository = _locationHierarchyRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.locationHierarchyRepository.GetAll());
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterLocationHierarchy detailById = this.locationHierarchyRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

    public ActionResult Insert(byte? id)
    {
      MasterLocationHierarchy locationHierarchy = new MasterLocationHierarchy();
      byte? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        locationHierarchy = this.locationHierarchyRepository.GetDetailById(id.Value);
      return (ActionResult) this.View((object) locationHierarchy);
    }

    [ValidateAntiModelInjection("LocationHierarchyId")]
    [HttpPost]
    public ActionResult Insert(MasterLocationHierarchy objLocationHierarchy)
    {
      if (this.ModelState.IsValid)
      {
        objLocationHierarchy.EntryBy = SessionUtility.LoginUserId;
        objLocationHierarchy.UpdateBy = new short?(SessionUtility.LoginUserId);
        objLocationHierarchy.WarehouseId = SessionUtility.WarehouseId;
        Response response = objLocationHierarchy.LocationHierarchyId <= (byte) 0 ? this.locationHierarchyRepository.Insert(objLocationHierarchy) : this.locationHierarchyRepository.Update(objLocationHierarchy);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
        this.TempData["result"] = (object) response;
      }
      return (ActionResult) this.View((object) objLocationHierarchy);
    }

    [ValidateAntiModelInjection("LocationHierarchyId")]
    [HttpPost]
    public JsonResult IsLocationHierarchyNameAvailable(
      MasterLocationHierarchy objMasterLocationHierarchy)
    {
      return this.Json((object) this.locationHierarchyRepository.IsLocationHierarchyNameAvailable(objMasterLocationHierarchy.LocationHierarchyName, objMasterLocationHierarchy.LocationHierarchyId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.locationHierarchyRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
