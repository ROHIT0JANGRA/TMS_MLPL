using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class FuelSurchargeRevisionController : Controller
  {
    private readonly IFuelSurchargeRevisioinRepository fuelSurchargeRevisioinRepository;
    private readonly IGeneralRepository generalRepository;

    public FuelSurchargeRevisionController()
    {
    }

    public FuelSurchargeRevisionController(
      IFuelSurchargeRevisioinRepository _fuelSurchargeRevisioinRepository,
      IGeneralRepository _generalRepository)
    {
      this.fuelSurchargeRevisioinRepository = _fuelSurchargeRevisioinRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.fuelSurchargeRevisioinRepository.GetAll());
    }

    public ActionResult Insert()
    {
      FuelSurchargeRevision surchargeRevision = new FuelSurchargeRevision();
      foreach (MasterGeneral masterGeneral in this.generalRepository.GetByGeneralList((short) 15).ToList<MasterGeneral>())
        surchargeRevision.MasterFuelSurchargeRevisionRate.Add(new MasterFuelSurchargeRevisionRate()
        {
          TransportMode = masterGeneral.CodeDescription,
          TransportModeId = masterGeneral.CodeId,
          IsActive = false
        });
      return (ActionResult) this.View((object) surchargeRevision);
    }

    [HttpPost]
    [ValidateAntiModelInjection("RevisionId")]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(FuelSurchargeRevision objFuelSurchargeRevision)
    {
      if (this.ModelState.IsValid)
      {
        objFuelSurchargeRevision.EntryBy = SessionUtility.LoginUserId;
        if (this.fuelSurchargeRevisioinRepository.Insert(objFuelSurchargeRevision).IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Index");
      }
      return (ActionResult) this.View((object) objFuelSurchargeRevision);
    }

    public ActionResult Update(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.fuelSurchargeRevisioinRepository.GetById(id.Value));
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("RevisionId")]
    public ActionResult Update(FuelSurchargeRevision objFuelSurchargeRevision)
    {
      if (this.ModelState.IsValid)
      {
        objFuelSurchargeRevision.UpdateBy = new short?(SessionUtility.LoginUserId);
        if (this.fuelSurchargeRevisioinRepository.Update(objFuelSurchargeRevision).IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Index");
      }
      return (ActionResult) this.View((object) objFuelSurchargeRevision);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.fuelSurchargeRevisioinRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
