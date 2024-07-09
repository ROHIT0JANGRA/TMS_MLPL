using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;
namespace CodeLock.Areas.Master.Controllers
{
    public class TyreController : Controller
    {
        private readonly ITyreRepository tyreRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly ITyreModelRepository tyreModelRepository;
        private readonly ITyreManufacturerRepository tyreManufacturerRepository;
        private readonly ITyreSizeRepository tyreSizeRepository;
        private readonly ITyrePatternRepository tyrePatternRepository;
        private readonly ITyrePositionRepository tyrePositionRepository;




        public TyreController()
        { 
        }
        public TyreController(ITyreRepository _tyreRepository, IGeneralRepository _generalRepository,IVehicleTypeRepository _vehicleTypeRepository, IVehicleRepository _vehicleRepository, ITyreModelRepository _tyreModelRepository, ITyreManufacturerRepository _tyreManufacturerRepository, ITyreSizeRepository _tyreSizeRepository,ITyrePatternRepository _tyrePatternRepository,ITyrePositionRepository _tyrePositionRepository)
        {
            this.tyreRepository = _tyreRepository;
            this.generalRepository = _generalRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.vehicleRepository = _vehicleRepository;
            this.tyreModelRepository = _tyreModelRepository;
            this.tyreManufacturerRepository = _tyreManufacturerRepository;
            this.tyreSizeRepository = _tyreSizeRepository;  
            this.tyrePatternRepository = _tyrePatternRepository;
            this.tyrePositionRepository = _tyrePositionRepository;

        }

        public ActionResult Index()
        {
            return (ActionResult)this.View((object)this.tyreRepository.GetAll());
        }
      
        public ActionResult Insert()
        {

            MasterTyre objMasterTyre = new MasterTyre();
            ((dynamic)base.ViewBag).TyreCategoryList = this.generalRepository.GetByIdList(303);
            ((dynamic)base.ViewBag).ManufacturerList = this.tyreManufacturerRepository.GetManufacturerList();
            ((dynamic)base.ViewBag).TyreModelList = this.tyreModelRepository.GetTyreModelList();
            ((dynamic)base.ViewBag).TyreSizeList = this.tyreSizeRepository.GetTyreSizeList();
            ((dynamic)base.ViewBag).VehicleNoList = this.vehicleRepository.GetVehicleList();
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).TyreTypeList = this.generalRepository.GetByIdList(103);
            ((dynamic)base.ViewBag).PositionCategoryList = this.generalRepository.GetByIdList(101);
            ((dynamic)base.ViewBag).PositionList = this.tyrePositionRepository.GetTyrePositionList();
            ((dynamic)base.ViewBag).TyrePatternList = this.tyrePatternRepository.GetTyrePatternList();
           // ((dynamic)base.ViewBag).TyreCategoryList = this.tyreRepository.GetTyreCategoryList();
            return base.View(objMasterTyre);


        }

        [ValidateAntiModelInjection("TyreId")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MasterTyre objMasterTyre)
        {
            if (ModelState.IsValid)
            {
                objMasterTyre.EntryBy = SessionUtility.LoginUserId;
                short TyreId = tyreRepository.Insert(objMasterTyre);
                return RedirectToAction("View", new { id = TyreId });
            }
            return View(objMasterTyre);
        }
        public ActionResult Update(short? id)
        {
            ((dynamic)base.ViewBag).TyreCategoryList = this.generalRepository.GetByIdList(303);
            ((dynamic)base.ViewBag).ManufacturerList = this.tyreManufacturerRepository.GetManufacturerList();
            ((dynamic)base.ViewBag).TyreModelList = this.tyreModelRepository.GetTyreModelList();
            ((dynamic)base.ViewBag).TyreSizeList = this.tyreSizeRepository.GetTyreSizeList();
            ((dynamic)base.ViewBag).VehicleNoList = this.vehicleRepository.GetVehicleList();
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).TyreTypeList = this.generalRepository.GetByIdList(103);
            ((dynamic)base.ViewBag).PositionCategoryList = this.generalRepository.GetByIdList(101);
            ((dynamic)base.ViewBag).PositionList = this.tyrePositionRepository.GetTyrePositionList();
            ((dynamic)base.ViewBag).TyrePatternList = this.tyrePatternRepository.GetTyrePatternList();
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyreRepository.GetById(id.Value));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiModelInjection("TyreId")]
        public ActionResult Update(MasterTyre objMasterTyre)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyre);
            objMasterTyre.UpdateBy = (SessionUtility.LoginUserId);
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyreRepository.Update(objMasterTyre)
            });
        }
        public ActionResult View(short? id)
        {
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyreRepository.GetById(id.Value));
        }

        [HttpPost]
    
        [ValidateAntiModelInjection("TyreId")]
        public JsonResult IsTyreNoAvailable(MasterTyre objMasterTyre)
        {
            return this.Json((object)this.tyreRepository.IsTyreNoAvailable(objMasterTyre.TyreId, objMasterTyre.TyreNo));
           
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.tyreRepository.Dispose();
            base.Dispose(disposing);
        }


    }
}