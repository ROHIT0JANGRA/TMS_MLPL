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
  public class ZoneController : Controller
  {
    private readonly IZoneRepository zoneRepository;
    private readonly ICountryRepository countryRepository;

    public ZoneController()
    {
    }

    public ZoneController(IZoneRepository _zoneRepository, ICountryRepository _countryRepository)
    {
      this.zoneRepository = _zoneRepository;
      this.countryRepository = _countryRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.zoneRepository.GetAll());
    }

        public ActionResult Insert()
        {
            MasterZone masterZone = new MasterZone();
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            return base.View(masterZone);
        }

        [ValidateAntiModelInjection("ZoneId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterZone objMasterZone)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterZone);
      objMasterZone.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.zoneRepository.Insert(objMasterZone)
      });
    }

        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
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
                ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
                httpStatusCodeResult = base.View(this.zoneRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [ValidateAntiModelInjection("ZoneId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterZone objMasterZone)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterZone);
      objMasterZone.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.zoneRepository.Update(objMasterZone)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.zoneRepository.GetById(id.Value));
    }

    [ValidateAntiModelInjection("ZoneId")]
    [HttpPost]
    public JsonResult IsZoneNameAvailable(MasterZone objMasterZone)
    {
      return this.Json((object) this.zoneRepository.IsZoneNameAvailable(objMasterZone.ZoneName, objMasterZone.ZoneId));
    }

    public JsonResult GetAutoCompleteZone(string zoneName)
    {
      return this.Json((object) this.zoneRepository.GetAutoCompleteZoneList(zoneName));
    }

    [HttpPost]
    public JsonResult IsZoneNameExist(string zoneName)
    {
      return this.Json((object) this.zoneRepository.IsZoneNameExist(zoneName));
    }
  }
}
