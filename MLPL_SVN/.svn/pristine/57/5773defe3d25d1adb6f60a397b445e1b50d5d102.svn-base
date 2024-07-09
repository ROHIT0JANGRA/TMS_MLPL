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
  public class AssetController : Controller
  {
    private readonly IAssetRepository assetRepository;
    private readonly IAccountGroupRepository accountGroupRepository;
    private readonly IGeneralRepository generalRepository;

    public AssetController()
    {
    }

    public AssetController(
      IAssetRepository _assetRepository,
      IAccountGroupRepository _accountGroupRepository,
      IGeneralRepository _generalRepository)
    {
      this.assetRepository = _assetRepository;
      this.accountGroupRepository = _accountGroupRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.assetRepository.GetAll());
    }

    public ActionResult Insert()
    {
      this.Init();
      return (ActionResult) this.View((object) new MasterAsset());
    }

    [ValidateAntiModelInjection("AssetId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterAsset objMasterAsset)
    {
      if (this.ModelState.IsValid)
      {
        objMasterAsset.EntryBy = SessionUtility.LoginUserId;
        return (ActionResult) this.RedirectToAction("View", (object) new
        {
          id = this.assetRepository.Insert(objMasterAsset)
        });
      }
      this.Init();
      return (ActionResult) this.View((object) objMasterAsset);
    }

    public ActionResult Update(byte? id)
    {
      this.Init();
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.assetRepository.GetById(id.Value));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("AssetId")]
    public ActionResult Update(MasterAsset objMasterAsset)
    {
      if (this.ModelState.IsValid)
      {
        objMasterAsset.UpdateBy = new short?(SessionUtility.LoginUserId);
        return (ActionResult) this.RedirectToAction("View", (object) new
        {
          id = this.assetRepository.Update(objMasterAsset)
        });
      }
      this.Init();
      return (ActionResult) this.View((object) objMasterAsset);
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.assetRepository.GetById(id.Value));
    }

    private void Init()
    {
        ((dynamic)base.ViewBag).AssetGroupList = this.accountGroupRepository.GetAccountGroupList();
        ((dynamic)base.ViewBag).UnitsOfMeasurementList = this.generalRepository.GetByIdList(10);
        ((dynamic)base.ViewBag).AssetCategoryList = this.generalRepository.GetByIdList(48);
        ((dynamic)base.ViewBag).DepreciationMethodList = this.generalRepository.GetByIdList(49);
    }

    [ValidateAntiModelInjection("AssetId")]
    [HttpPost]
    public JsonResult IsAssetNameAvailable(MasterAsset objMasterAsset)
    {
      return this.Json((object) this.assetRepository.IsAssetNameAvailable(objMasterAsset.AssetName, objMasterAsset.AssetId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.assetRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
