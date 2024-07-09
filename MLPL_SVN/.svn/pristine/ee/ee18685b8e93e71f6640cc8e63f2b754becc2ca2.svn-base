using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class TripCheckListController : Controller
  {
    private readonly ITripCheckListRepository tripCheckListRepository;
    private readonly IGeneralRepository generalRepository;

        public TripCheckListController()
        {
        }

        public TripCheckListController(ITripCheckListRepository _tripCheckListRepository, IGeneralRepository _generalRepository)
        {
            this.tripCheckListRepository = _tripCheckListRepository;
            this.generalRepository = _generalRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.tripCheckListRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return base.View(this.tripCheckListRepository.GetAll());
        }

        public ActionResult Insert(short? id)
        {
            int? nullable;
            int? nullable1;
            MasterTripCheckList masterTripCheckList = new MasterTripCheckList();
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
                masterTripCheckList = this.tripCheckListRepository.GetDetailById((byte)id.Value);
                masterTripCheckList.SavedDocuments = string.Join<byte>(",",
                    from m in this.tripCheckListRepository.GetCashTripCheckListDetail((byte)id.Value)
                    select m.DocumentId);
            }
            ((dynamic)base.ViewBag).CategoryList = this.generalRepository.GetByIdList(38);
            ((dynamic)base.ViewBag).DocumentsList = this.generalRepository.GetByIdList(39);
            return base.View(masterTripCheckList);
        }

        [HttpPost]
        [ValidateAntiModelInjection("CheckListId")]
        public ActionResult Insert(MasterTripCheckList ObjTripCheckList)
        {
            Response response;
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                ObjTripCheckList.EntryBy = SessionUtility.LoginUserId;
                ObjTripCheckList.UpdateBy = new short?(SessionUtility.LoginUserId);
                response = (ObjTripCheckList.CheckListId <= 0 ? this.tripCheckListRepository.Insert(ObjTripCheckList) : this.tripCheckListRepository.Update(ObjTripCheckList));
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
                base.TempData["result"] = response;
            }
            ((dynamic)base.ViewBag).CategoryList = this.generalRepository.GetByIdList(38);
            ((dynamic)base.ViewBag).DocumentsList = this.generalRepository.GetByIdList(39);
            action = base.View(ObjTripCheckList);
            return action;
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
                MasterTripCheckList detailById = this.tripCheckListRepository.GetDetailById((byte)id.Value);
                if (detailById != null)
                {
                    detailById.Documents = string.Join(", ",
                        from m in this.tripCheckListRepository.GetCashTripCheckListDetail((byte)id.Value)
                        select m.DocumentName);
                    httpStatusCodeResult = base.View(detailById);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

    }
}
