using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class TyreSizeController : Controller
    {
        private readonly ITyreSizeRepository tyreSizeRepository;
        private readonly IGeneralRepository generalRepository;
        public TyreSizeController()
        {
        }
        public TyreSizeController (ITyreSizeRepository _tyreSizeRepository, IGeneralRepository _generalRepository)
        {
            this.tyreSizeRepository = _tyreSizeRepository;
            this.generalRepository = _generalRepository;
        }
            public ActionResult Index()
                {
                return (ActionResult)this.View((object)this.tyreSizeRepository.GetAll());
            }
        public ActionResult Insert()
        {
           
            MasterTyreSize objMasterTyreSize = new MasterTyreSize();
            ViewBag.TyreTypeCategory = this.generalRepository.GetByIdList(103);
            return base.View(objMasterTyreSize);
           

        }

        [ValidateAntiModelInjection("TyreSizeId")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MasterTyreSize objMasterTyreSize)
        {
            if (ModelState.IsValid)
            {
                objMasterTyreSize.EntryBy = SessionUtility.LoginUserId;
                short TyreSizeId = tyreSizeRepository.Insert(objMasterTyreSize);
                return RedirectToAction("View", new { id = TyreSizeId });
            }
            return View(objMasterTyreSize);
        }
       
      
        public ActionResult Update(short? id)
        {
                short? nullable = id;
            ((dynamic)base.ViewBag).TyreTypeCategoryList = this.generalRepository.GetByIdList(103);
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return (ActionResult)this.View((object)this.tyreSizeRepository .GetById(id.Value));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiModelInjection("TyreSizeId")]
        public ActionResult Update(MasterTyreSize objMasterTyreSize)
        {
            if (!this.ModelState.IsValid)
             return (ActionResult)this.View((object)objMasterTyreSize);
            objMasterTyreSize.UpdateBy = (SessionUtility.LoginUserId);
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyreSizeRepository.Update(objMasterTyreSize)
            });
        }

        public ActionResult View(short? id)
        {
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyreSizeRepository.GetById(id.Value));
        }


        [HttpPost]
        [ValidateAntiModelInjection("TyreSizeId")]
        public JsonResult IsTyreSizeNameAvailable(MasterTyreSize objMasterTyreSize)
        {
            return this.Json((object)this.tyreSizeRepository.IsTyreSizeNameAvailable(objMasterTyreSize.TyreSizeName, objMasterTyreSize.TyreSizeId));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.tyreSizeRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
