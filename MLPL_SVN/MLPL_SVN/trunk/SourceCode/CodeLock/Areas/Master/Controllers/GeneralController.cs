using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class GeneralController : Controller
  {
    private readonly IGeneralRepository generalRepository;

    public GeneralController()
    {
    }

    public GeneralController(IGeneralRepository _generalRepository)
    {
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.generalRepository.GetCodeTypeList());
    }

    public ActionResult List(short id)
    {
        ((dynamic)base.ViewBag).CodeType = this.generalRepository.GetCodeTypeById(id);
        ((dynamic)base.ViewBag).CodeTypeId = id;
        return base.View(this.generalRepository.GetAll(id));
    }

    public ActionResult Insert(short id)
    {
      return (ActionResult) this.View((object) new MasterGeneral()
      {
        CodeId = (short) 0,
        CodeTypeId = id,
        CodeType = this.generalRepository.GetCodeTypeById(id)
      });
    }

    [HttpPost]
    [ValidateAntiModelInjection("CodeId")]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterGeneral objMasterGeneral)
    {
      if (this.ModelState.IsValid)
      {
        objMasterGeneral.EntryBy = SessionUtility.LoginUserId;
        if (this.generalRepository.Insert(objMasterGeneral))
          return (ActionResult) this.RedirectToAction("List", (object) new
          {
            id = objMasterGeneral.CodeTypeId
          });
      }
      return (ActionResult) this.View((object) objMasterGeneral);
    }

    public ActionResult Update(short id, short codeId)
    {
      MasterGeneral byId = this.generalRepository.GetById(id, codeId);
      if (byId == null)
        return (ActionResult) this.HttpNotFound();
      byId.CodeType = this.generalRepository.GetCodeTypeById(id);
      return (ActionResult) this.View((object) byId);
    }

    [ValidateAntiModelInjection("CodeId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterGeneral objMasterGeneral)
    {
      if (this.ModelState.IsValid)
      {
        objMasterGeneral.UpdateBy = new short?(SessionUtility.LoginUserId);
        if (this.generalRepository.Update(objMasterGeneral))
          return (ActionResult) this.RedirectToAction("List", (object) new
          {
            id = objMasterGeneral.CodeTypeId
          });
      }
      return (ActionResult) this.View((object) objMasterGeneral);
    }

    public ActionResult View(short id, short codeId)
    {
      return (ActionResult) this.View((object) this.generalRepository.GetById(id, codeId));
    }

    public JsonResult GetByIdList(short codeTypeId)
    {
      return this.Json((object) this.generalRepository.GetByIdList(codeTypeId));
    }

    [HttpPost]
    [ValidateAntiModelInjection("CodeId")]
    public JsonResult IsGeneralNameAvailable(MasterGeneral objMasterGeneral)
    {
      return this.Json((object) this.generalRepository.IsGeneralNameAvailable(objMasterGeneral.CodeDescription, objMasterGeneral.CodeTypeId, objMasterGeneral.CodeId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.generalRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
