using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class PackagingMeasurementController : Controller
  {
    private readonly IPackagingMeasurementRepository packagingMeasurementRepository;

    public PackagingMeasurementController()
    {
    }

    public PackagingMeasurementController(
      IPackagingMeasurementRepository _packagingMeasurementRepository)
    {
      this.packagingMeasurementRepository = _packagingMeasurementRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.packagingMeasurementRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterPackagingMeasurement());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("PackagingTypeId")]
    public ActionResult Insert(
      MasterPackagingMeasurement objMasterPackagingMeasurement)
    {
      if (this.ModelState.IsValid && objMasterPackagingMeasurement.MeasurementType.Length > 0)
      {
        objMasterPackagingMeasurement.EntryBy = SessionUtility.LoginUserId;
        Response response = this.packagingMeasurementRepository.Insert(objMasterPackagingMeasurement);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
      }
      return (ActionResult) this.View((object) objMasterPackagingMeasurement);
    }

    public ActionResult Update(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.packagingMeasurementRepository.GetById(id.Value));
    }

    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("PackagingTypeId")]
    [HttpPost]
    public ActionResult Update(
      MasterPackagingMeasurement objMasterPackagingMeasurement)
    {
      if (this.ModelState.IsValid)
      {
        objMasterPackagingMeasurement.UpdateBy = new short?(SessionUtility.LoginUserId);
        Response response = this.packagingMeasurementRepository.Update(objMasterPackagingMeasurement);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
      }
      return (ActionResult) this.View((object) objMasterPackagingMeasurement);
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.packagingMeasurementRepository.GetById(id.Value));
    }

    [ValidateAntiModelInjection("PackagingTypeId")]
    [HttpPost]
    public JsonResult IsPackagingTypeAvailable(
      MasterPackagingMeasurement objMasterPackagingMeasurement)
    {
      return this.Json((object) this.packagingMeasurementRepository.IsPackagingTypeAvailable(objMasterPackagingMeasurement.PackagingType, objMasterPackagingMeasurement.PackagingTypeId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.packagingMeasurementRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
