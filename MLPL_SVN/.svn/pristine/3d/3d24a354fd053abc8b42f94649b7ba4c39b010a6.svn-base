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
  public class ReceiverController : Controller
  {
    private readonly IReceiverRepository receiverRepository;
    private readonly ILocationRepository locationRepository;

    public ReceiverController()
    {
    }

    public ReceiverController(
      IReceiverRepository _receiverRepository,
      ILocationRepository _locationRepository)
    {
      this.receiverRepository = _receiverRepository;
      this.locationRepository = _locationRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.receiverRepository.GetAll());
    }

        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(new MasterReceiver());
        }

        [ValidateAntiModelInjection("ReceiverId")]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Insert(MasterReceiver objMasterReceiver)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterReceiver);
      objMasterReceiver.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.receiverRepository.Insert(objMasterReceiver)
      });
    }

        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
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
                httpStatusCodeResult = base.View(this.receiverRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("ReceiverId")]
    [HttpPost]
    public ActionResult Update(MasterReceiver objMasterReceiver)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterReceiver);
      objMasterReceiver.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.receiverRepository.Update(objMasterReceiver)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.receiverRepository.GetById(id.Value));
    }

    public JsonResult GetAutoCompleteReceiverListByLocation(
      string receiverCode,
      short locationId)
    {
      return this.Json((object) this.receiverRepository.GetAutoCompleteReceiverListByLocation(receiverCode, locationId, SessionUtility.CompanyId));
    }

    public JsonResult IsReceiverCodeExistByLocation(string receiverCode, short locationId)
    {
      return this.Json((object) this.receiverRepository.IsReceiverCodeExistByLocation(receiverCode, locationId, SessionUtility.CompanyId));
    }

    [HttpPost]
    [ValidateAntiModelInjection("ReceiverId")]
    public JsonResult IsReceiverNameAvailable(MasterReceiver objMasterReceiver)
    {
      return this.Json((object) this.receiverRepository.IsReceiverNameAvailable(objMasterReceiver.ReceiverName, objMasterReceiver.ReceiverId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.receiverRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
