using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;

namespace CodeLock.Areas.Master.Controllers
{
    public class TyreModelController : Controller
    {
        private readonly ITyreModelRepository tyreModelRepository;
        private readonly IGeneralRepository generalRepository;

        public TyreModelController(ITyreModelRepository _tyreModelRepository, IGeneralRepository _generalRepository)
        {
            this.tyreModelRepository = _tyreModelRepository;
            this.generalRepository = _generalRepository;
        }
        public ActionResult Index()
        {
            List<MasterTyreModel> objMasterTyreModel = new List<MasterTyreModel>();
            objMasterTyreModel = (List<MasterTyreModel>)tyreModelRepository.GetAll();
            return View(objMasterTyreModel);

        }
        public ActionResult Insert()
        {
            MasterTyreModel objMasterTyreModel = new MasterTyreModel();
            ((dynamic)base.ViewBag).ManufacturerTypeList = this.generalRepository.GetByIdList(101);
            ((dynamic)base.ViewBag).TyreSizeTypeList = this.generalRepository.GetByIdList(102);
            ((dynamic)base.ViewBag).TyrePatternTypeList = this.generalRepository.GetByIdList(103);
            return View(objMasterTyreModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("TyreModelId")]
        public ActionResult Insert(MasterTyreModel objMasterTyreModel)
        {
            if (ModelState.IsValid)
            {
                objMasterTyreModel.EntryBy = SessionUtility.LoginUserId;
                short TyreModelId = tyreModelRepository.Insert(objMasterTyreModel);
                return RedirectToAction("View", new { id = TyreModelId });
            }
            return View(objMasterTyreModel);
        }
        public ActionResult Update(short? id)
        {
            short? nullable = id;
            ((dynamic)base.ViewBag).ManufacturerTypeList = this.generalRepository.GetByIdList(101);
            ((dynamic)base.ViewBag).TyreSizeTypeList = this.generalRepository.GetByIdList(102);
            ((dynamic)base.ViewBag).TyrePatternTypeList = this.generalRepository.GetByIdList(103);
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyreModelRepository.GetById(id.Value));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiModelInjection("TyreModelId")]
        public ActionResult Update(MasterTyreModel objMasterTyreModel)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyreModel);
            objMasterTyreModel.UpdateBy = new short?(SessionUtility.LoginUserId);
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyreModelRepository.Update(objMasterTyreModel)
            });
        }
        public ActionResult View(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
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
                httpStatusCodeResult = base.View(this.tyreModelRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }
    }

}