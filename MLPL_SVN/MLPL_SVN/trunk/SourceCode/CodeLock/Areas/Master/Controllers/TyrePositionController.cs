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
    public class TyrePositionController : Controller
    {
        private readonly ITyrePositionRepository tyrePositionRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly IGeneralRepository generalRepository;

        public TyrePositionController(ITyrePositionRepository _tyrePositionRepository, IVehicleTypeRepository _vehicleTypeRepository, IGeneralRepository _generalRepository)
        {
            this.tyrePositionRepository = _tyrePositionRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.generalRepository = _generalRepository;
        }
        public ActionResult Index()
        {
            List<MasterTyrePosition> objMasterTyrePosition = new List<MasterTyrePosition>();
            objMasterTyrePosition = (List<MasterTyrePosition>)tyrePositionRepository.GetAll();
            return View(objMasterTyrePosition);

        }
        public ActionResult Insert()
        {
            MasterTyrePosition objMasterTyrePosition = new MasterTyrePosition();
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).PositionCategoryTypeList = this.generalRepository.GetByIdList(101);
            return View(objMasterTyrePosition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("TyrePositionid")]
        public ActionResult Insert(MasterTyrePosition objMasterTyrePosition)
        {
            if (ModelState.IsValid)
            {
                objMasterTyrePosition.EntryBy = SessionUtility.LoginUserId;
                short TyrePositionid = tyrePositionRepository.Insert(objMasterTyrePosition);
                return RedirectToAction("View", new { id = TyrePositionid });
            }
            return View(objMasterTyrePosition);
        }
        public ActionResult Update(short? id)
        {
            short? nullable = id;
            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).PositionCategoryTypeList = this.generalRepository.GetByIdList(101);
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.tyrePositionRepository.GetById(id.Value));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiModelInjection("TyrePositionid")]
        public ActionResult Update(MasterTyrePosition objMasterTyrePosition)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterTyrePosition);
            objMasterTyrePosition.UpdateBy = new short?(SessionUtility.LoginUserId);
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.tyrePositionRepository.Update(objMasterTyrePosition)
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
                httpStatusCodeResult = base.View(this.tyrePositionRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }
    }

}