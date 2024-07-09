using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class ProductTemperatureController : Controller
  {
    private readonly IProductTemperatureRepository productTemperatureRepository;
    private readonly IGeneralRepository generalRepository;

    public ProductTemperatureController()
    {
    }

    public ProductTemperatureController(
      IProductTemperatureRepository _productTemperatureRepository,
      IGeneralRepository _generalRepository)
    {
      this.productTemperatureRepository = _productTemperatureRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.productTemperatureRepository.GetAll());
    }

        public ActionResult Insert(short? id)
        {
            ActionResult actionResult;
            int? nullable;
            int? nullable1;
            MasterProductTemperature masterProductTemperature = new MasterProductTemperature();
            ((dynamic)base.ViewBag).ProductList = this.generalRepository.GetByIdList(24);
            short? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            actionResult = (!nullable.HasValue ? base.View(masterProductTemperature) : base.View(this.productTemperatureRepository.GetById(id.Value)));
            return actionResult;
        }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Insert(MasterProductTemperature objProductTemperature)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objProductTemperature);
      objProductTemperature.EntryBy = SessionUtility.LoginUserId;
      this.productTemperatureRepository.InsertUpdate(objProductTemperature);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = objProductTemperature.ProductId
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.productTemperatureRepository.GetById(id.Value));
    }

    public JsonResult GetById(short id)
    {
      return this.Json((object) this.productTemperatureRepository.GetById(id), JsonRequestBehavior.AllowGet);
    }
  }
}
