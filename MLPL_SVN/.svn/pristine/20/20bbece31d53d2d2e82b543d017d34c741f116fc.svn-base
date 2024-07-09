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
  public class SacController : Controller
  {
    private readonly ISacRepository sacRepository;
    private readonly IGeneralRepository generalRepository;

    public SacController()
    {
    }

    public SacController(ISacRepository _sacRepository, IGeneralRepository _generalRepository)
    {
      this.sacRepository = _sacRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.sacRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterSac());
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("SacId")]
    public ActionResult Insert(MasterSac objMasterSac)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterSac);
      objMasterSac.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.sacRepository.Insert(objMasterSac)
      });
    }

    public ActionResult Update(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.sacRepository.GetById(id.Value));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("SacId")]
    public ActionResult Update(MasterSac objMasterSac)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterSac);
      objMasterSac.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.sacRepository.Update(objMasterSac)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.sacRepository.GetById(id.Value));
    }

        public ActionResult ServiceTypeToSac()
        {
            IEnumerable<ServiceTypeToSacMapping> serviceTypeToSacMapping = this.sacRepository.GetServiceTypeToSacMapping();
            ((dynamic)base.ViewBag).SacList = this.sacRepository.GetSacList();
            return base.View(serviceTypeToSacMapping);
        }

        [HttpPost]
    public ActionResult ServiceTypeToSac(
      IEnumerable<ServiceTypeToSacMapping> objServiceTypeToSacMapping)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objServiceTypeToSacMapping);
      foreach (Base @base in objServiceTypeToSacMapping)
        @base.UpdateBy = new short?(SessionUtility.LoginUserId);
      this.sacRepository.ServiceTypeToSacMapping(objServiceTypeToSacMapping);
      return (ActionResult) this.RedirectToAction("Done", (object) new
      {
        status = "ServiceTypeToSacMappingDone"
      });
    }

        public ActionResult TransportModeToService()
        {
            IEnumerable<TransportModeToServiceMapping> transportModeToServiceMapping = this.sacRepository.GetTransportModeToServiceMapping();
            ((dynamic)base.ViewBag).ServiceList = this.generalRepository.GetByIdList(56);
            return base.View(transportModeToServiceMapping);
        }

        [HttpPost]
    public ActionResult TransportModeToService(
      IEnumerable<TransportModeToServiceMapping> objTransportModeToServiceMapping)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objTransportModeToServiceMapping);
      foreach (Base @base in objTransportModeToServiceMapping)
        @base.UpdateBy = new short?(SessionUtility.LoginUserId);
      this.sacRepository.TransportModeToServiceMapping(objTransportModeToServiceMapping);
      return (ActionResult) this.RedirectToAction("Done", (object) new
      {
        status = "TransportModeToServiceMappingDone"
      });
    }

    [HttpPost]
    [ValidateAntiModelInjection("SacId")]
    public JsonResult IsSacNameAvailable(MasterSac objMasterSac)
    {
      return this.Json((object) this.sacRepository.IsSacNameAvailable(objMasterSac.SacName, objMasterSac.SacId));
    }

    [HttpPost]
    public JsonResult IsSacCodeAvailable(MasterSac objMasterSac)
    {
      return this.Json((object) this.sacRepository.IsSacCodeAvailable(objMasterSac.SacCode, objMasterSac.SacId));
    }

    [HttpPost]
    public JsonResult GetSacDetailById(byte sacId)
    {
      return this.Json((object) this.sacRepository.GetById(sacId));
    }

    [HttpPost]
    public JsonResult GetSacList()
    {
      return this.Json((object) this.sacRepository.GetSacList());
    }

    [HttpPost]
    public JsonResult GetServiceList()
    {
      return this.Json((object) this.sacRepository.GetServiceList());
    }

    [HttpPost]
    public JsonResult GetSacCategoryList()
    {
      return this.Json((object) this.sacRepository.GetSacCategoryList());
    }

    [HttpPost]
    public JsonResult GetGstRateList()
    {
      return this.Json((object) this.sacRepository.GetGstRateList());
    }

    public ActionResult Done()
    {
      return (ActionResult) this.View();
    }
  }
}
