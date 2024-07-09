using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class VehicleColdChainRateController : Controller
  {
    private readonly IVehicleColdChainRateRepository vehicleColdChainRateRepository;

    public VehicleColdChainRateController()
    {
    }

    public VehicleColdChainRateController(
      IVehicleColdChainRateRepository _vehicleColdChainRateRepository)
    {
      this.vehicleColdChainRateRepository = _vehicleColdChainRateRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.vehicleColdChainRateRepository.GetAll());
    }

    public ActionResult Insert(short? id)
    {
      MasterVehicleColdChainRate vehicleColdChainRate = new MasterVehicleColdChainRate();
      short? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) this.View((object) this.vehicleColdChainRateRepository.GetById(id.Value));
      return (ActionResult) this.View((object) vehicleColdChainRate);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(
      MasterVehicleColdChainRate objMasterVehicleColdChainRate)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterVehicleColdChainRate);
      objMasterVehicleColdChainRate.EntryBy = SessionUtility.LoginUserId;
      objMasterVehicleColdChainRate.UpdateBy = new short?(SessionUtility.LoginUserId);
      this.vehicleColdChainRateRepository.InsertUpdate(objMasterVehicleColdChainRate);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = objMasterVehicleColdChainRate.VehicleId
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.vehicleColdChainRateRepository.GetById(id.Value));
    }

    public JsonResult GetById(short id)
    {
      return this.Json((object) this.vehicleColdChainRateRepository.GetById(id), JsonRequestBehavior.AllowGet);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.vehicleColdChainRateRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
