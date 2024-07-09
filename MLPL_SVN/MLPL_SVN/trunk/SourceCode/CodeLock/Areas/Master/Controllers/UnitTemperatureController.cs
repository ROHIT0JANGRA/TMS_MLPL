using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class UnitTemperatureController : Controller
  {
    private readonly IUnitTemperatureRepository unitTemperatureRepository;

    public UnitTemperatureController()
    {
    }

    public UnitTemperatureController(
      IUnitTemperatureRepository _unitTemperatureRepository)
    {
      this.unitTemperatureRepository = _unitTemperatureRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.unitTemperatureRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterUnitTemperature());
    }

    [ValidateAntiModelInjection("UnitId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterUnitTemperature objUnitTemperature)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objUnitTemperature);
      objUnitTemperature.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.unitTemperatureRepository.Insert(objUnitTemperature)
      });
    }

    public ActionResult Update(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.unitTemperatureRepository.GetById(id.Value));
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Update(MasterUnitTemperature objUnitTemperature)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objUnitTemperature);
      objUnitTemperature.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.unitTemperatureRepository.Update(objUnitTemperature)
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.unitTemperatureRepository.GetById(id.Value));
    }
  }
}
