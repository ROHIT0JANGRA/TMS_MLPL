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
  public class SkuController : Controller
  {
    private readonly ISkuRepository skuRepository;
    private readonly IGeneralRepository generalRepository;

    public SkuController()
    {
    }

    public SkuController(ISkuRepository _skuRepository, IGeneralRepository _generalRepository)
    {
      this.skuRepository = _skuRepository;
      this.generalRepository = _generalRepository;
    }


    public ActionResult Inventory()
    {
        return (ActionResult)this.View((object)this.skuRepository.InventoryAll());
    }


        public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.skuRepository.GetAll());
    }


    public ActionResult View(int? id)
    {
      int? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterSku detailById = this.skuRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

        public ActionResult Insert(short? id)
        {
            int? nullable;
            int? nullable1;
            MasterSku masterSku = new MasterSku();
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
            if (nullable.HasValue)
            {
                masterSku = this.skuRepository.GetDetailById((int)id.Value);
            }
            ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            ((dynamic)base.ViewBag).UnitsOfMeasurementList = this.generalRepository.GetByIdList(10);
            ((dynamic)base.ViewBag).SkuSizeList = this.generalRepository.GetByIdList(90);
            ((dynamic)base.ViewBag).SkuTypeList = this.generalRepository.GetByIdList(89);


            return base.View(masterSku);
        }


        [HttpPost]
        [ValidateAntiModelInjection("SkuId")]
        public ActionResult Insert(MasterSku objSku)
        {
            Response response;
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objSku.EntryBy = SessionUtility.LoginUserId;
                objSku.UpdateBy = new short?(SessionUtility.LoginUserId);
                objSku.WarehouseId = SessionUtility.WarehouseId;
                response = (objSku.SkuId <= 0 ? this.skuRepository.Insert(objSku) : this.skuRepository.Update(objSku));
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
                base.TempData["result"] = response;
            }
             ((dynamic)base.ViewBag).MaterialCategoryList = this.generalRepository.GetByIdList(74);
            ((dynamic)base.ViewBag).UnitsOfMeasurementList = this.generalRepository.GetByIdList(10);
            ((dynamic)base.ViewBag).SkuSizeList = this.generalRepository.GetByIdList(90);
            ((dynamic)base.ViewBag).SkuTypeList = this.generalRepository.GetByIdList(89);

            action = base.View(objSku);
            return action;
        }

        [HttpPost]
    public JsonResult GetSkuList()
    {
      return this.Json((object) this.skuRepository.GetSkuList());
    }

    public JsonResult GetAutoCompleteSkuList(string skuCode)
    {
      return this.Json((object) this.skuRepository.GetAutoCompleteSkuList(SessionUtility.CompanyId, skuCode));
    }

    public JsonResult IsSkuCodeExist(string skuCode)
    {
      return this.Json((object) this.skuRepository.IsSkuCodeExist(SessionUtility.CompanyId, skuCode));
    }

    [HttpPost]
    [ValidateAntiModelInjection("SkuId")]
    public JsonResult IsSkuNameAvailable(string SkuName, int SkuId)
    {
      return this.Json((object) this.skuRepository.IsSkuNameAvailable(SkuName, SkuId));
    }

    [ValidateAntiModelInjection("SkuId")]
    [HttpPost]
    public JsonResult IsSkuCodeAvailable(string SkuCode, int SkuId)
    {
      return this.Json((object) this.skuRepository.IsSkuCodeAvailable(SkuCode, SkuId));
    }

    [HttpPost]
    public JsonResult GetAutoCompleteListByMaterialCategoryId(
      string skuName,
      byte materialCategoryId)
    {
      return this.Json((object) this.skuRepository.GetAutoCompleteListByMaterialCategoryId(skuName, materialCategoryId));
    }

    public JsonResult IsSkuNameExistForPurchaseOrder(
      string skuName,
      byte materialCategoryId)
    {
      return this.Json((object) this.skuRepository.IsSkuNameExistForPurchaseOrder(skuName, materialCategoryId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.skuRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
