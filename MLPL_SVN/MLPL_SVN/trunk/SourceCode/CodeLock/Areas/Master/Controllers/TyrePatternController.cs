using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{

    public class TyrePatternController : Controller
    {
        private readonly ITyrePatternRepository tyrePatternRepository;
        private readonly IGeneralRepository generalRepository;

        public TyrePatternController()
        {

        }

        public TyrePatternController(ITyrePatternRepository _tyrePatternRepository, IGeneralRepository generalRepository)
        {
            this.tyrePatternRepository = _tyrePatternRepository;
            this.generalRepository = generalRepository;
        }
        public ActionResult Index()
        {
            return (ActionResult)this.View((object)this.tyrePatternRepository.GetAll());
        }

        public ActionResult Insert()
        {
            MasterTyrePattern objMasterTyrePattern = new MasterTyrePattern();
            ((dynamic)base.ViewBag).PositionAllowedDescription = this.generalRepository.GetByIdList(102);
            return View(objMasterTyrePattern);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("TyrePatternId")]
        public ActionResult Insert(MasterTyrePattern objMasterTyrePattern)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyrePattern);
            objMasterTyrePattern.EntryBy = SessionUtility.LoginUserId;
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyrePatternRepository.Insert(objMasterTyrePattern)
            });
          
        }

        public ActionResult Update(short ? id)
        {

           
            short? nullable = id;
            ((dynamic)base.ViewBag).PositionAllowedDescription = this.generalRepository.GetByIdList(102);
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyrePatternRepository.GetById(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("TyrePatternId")]
        public ActionResult Update(MasterTyrePattern objMasterTyrePattern)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyrePattern);
            objMasterTyrePattern.UpdateBy = SessionUtility.LoginUserId;
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyrePatternRepository.Update(objMasterTyrePattern)
            });

            
        }
        public ActionResult View(short ? id)
        {
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyrePatternRepository.GetById(id.Value));
            
        }

      
        [HttpPost]
        [ValidateAntiModelInjection("tyrepatternid")]
        public JsonResult IsTyrePatternAvailable(MasterTyrePattern objMasterTyrePattern)
        {
            return this.Json((object)this.tyrePatternRepository.IsTyrePatternAvailable(objMasterTyrePattern.TyrePatternCode, objMasterTyrePattern.TyrePatternId));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.tyrePatternRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
