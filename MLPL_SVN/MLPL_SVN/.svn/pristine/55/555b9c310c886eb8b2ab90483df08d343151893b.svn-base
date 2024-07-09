using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class HolidayDateWiseController : Controller
  {
    private readonly IHolidayDateWiseRepository holidayDateWiseRepository;

    public HolidayDateWiseController()
    {
    }

    public HolidayDateWiseController(
      IHolidayDateWiseRepository _holidayDateWiseRepository)
    {
      this.holidayDateWiseRepository = _holidayDateWiseRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.holidayDateWiseRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterHolidayDateWise());
    }

    [ValidateAntiModelInjection("HolidayId")]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Insert(MasterHolidayDateWise objMasterHolidayDateWise)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterHolidayDateWise);
      objMasterHolidayDateWise.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.holidayDateWiseRepository.Insert(objMasterHolidayDateWise)
      });
    }

    public ActionResult Update(byte? id)
    {
      MasterHolidayDateWise masterHolidayDateWise = new MasterHolidayDateWise();
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.holidayDateWiseRepository.GetById(id.Value));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("HolidayId")]
    public ActionResult Update(MasterHolidayDateWise objMasterHolidayDateWise)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterHolidayDateWise);
      objMasterHolidayDateWise.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.holidayDateWiseRepository.Update(objMasterHolidayDateWise)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.holidayDateWiseRepository.GetById(id.Value));
    }

    [ValidateAntiModelInjection("HolidayId")]
    [HttpPost]
    public JsonResult IsHolidayDateAvailable(
      MasterHolidayDateWise objMasterHolidayDateWise)
    {
      return this.Json((object) this.holidayDateWiseRepository.IsHolidayDateAvailable(objMasterHolidayDateWise.HolidayDate, objMasterHolidayDateWise.HolidayId));
    }

    public JsonResult IsDateHoliday(DateTime docketDate, short locationId)
    {
      return this.Json((object) this.holidayDateWiseRepository.IsDateHoliday(docketDate, locationId));
    }
  }
}
