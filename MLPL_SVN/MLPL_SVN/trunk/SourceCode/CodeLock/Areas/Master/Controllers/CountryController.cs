using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class CountryController : Controller
  {
    private readonly ICountryRepository countryRepository;

    public CountryController()
    {
    }

    public CountryController(ICountryRepository _countryRepository)
    {
      this.countryRepository = _countryRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.countryRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterCountry());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("CountryId")]
    public ActionResult Insert(MasterCountry objMasterCountry)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCountry);
      objMasterCountry.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.countryRepository.Insert(objMasterCountry)
      });
    }

    public ActionResult Update(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.countryRepository.GetById(id.Value));
    }

    [HttpPost]
    [ValidateAntiModelInjection("CountryId")]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterCountry objMasterCountry)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCountry);
      objMasterCountry.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.countryRepository.Update(objMasterCountry)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.countryRepository.GetById(id.Value));
    }

    [HttpPost]
    [ValidateAntiModelInjection("CountryId")]
    public JsonResult IsCountryNameAvailable(MasterCountry objMasterCountry)
    {
      return this.Json((object) this.countryRepository.IsCountryNameAvailable(objMasterCountry.CountryName, objMasterCountry.CountryId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.countryRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
