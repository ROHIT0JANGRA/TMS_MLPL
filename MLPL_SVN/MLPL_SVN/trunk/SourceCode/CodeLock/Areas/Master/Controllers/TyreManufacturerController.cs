using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class TyreManufacturerController : Controller
    {
        private readonly ITyreManufacturerRepository tyreManufacturerRepository;

        public TyreManufacturerController()
        {
        }

        public TyreManufacturerController(ITyreManufacturerRepository _tyreManufacturerRepository)
        {
            this.tyreManufacturerRepository = _tyreManufacturerRepository;
        }
        public ActionResult Index()
        {
            return (ActionResult)this.View((object)this.tyreManufacturerRepository.GetAll());
        }
        public ActionResult Insert()
        {
            return (ActionResult)this.View((object)new MasterTyreManufacturer());
        }

        [ValidateAntiModelInjection("ManufacturerId")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MasterTyreManufacturer objMasterTyreManufacturer)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyreManufacturer);
            objMasterTyreManufacturer.EntryBy = SessionUtility.LoginUserId;
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyreManufacturerRepository.Insert(objMasterTyreManufacturer)
            });
        }

        //[ValidateAntiModelInjection("ManufacturerId")]
        //[HttpPost]
        //public JsonResult IsCompanyNameAvailable(MasterCompany objMasterCompany)
        //{
        //    return this.Json((object)this.companyRepository.IsCompanyNameAvailable(objMasterCompany.CompanyName, (short)objMasterCompany.CompanyId));
        //}

        public ActionResult Update(byte? id)
        {
            byte? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyreManufacturerRepository.GetById(id.Value));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiModelInjection("ManufacturerId")]
        public ActionResult Update(MasterTyreManufacturer objMasterTyreManufacturer)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyreManufacturer);
            objMasterTyreManufacturer.UpdateBy = new short?(SessionUtility.LoginUserId);
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyreManufacturerRepository.Update(objMasterTyreManufacturer)
            });
        }

        public ActionResult View(byte? id)
        {
            byte? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyreManufacturerRepository.GetById(id.Value));
        }

    }
}