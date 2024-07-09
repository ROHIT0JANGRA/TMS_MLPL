using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;

namespace CodeLock.Areas.Master.Controllers
{
    public class LaneController : Controller
    {
        private readonly ILaneRepository laneRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IRouteCityWiseRepository routeCityWiseRepository;

        public LaneController()
        {
        }

        public LaneController(ILaneRepository _laneRepository, IGeneralRepository _generalRepository, IRouteCityWiseRepository _routeCityWiseRepository)
        {
            this.laneRepository = _laneRepository;
            this.generalRepository = _generalRepository;
            this.routeCityWiseRepository = _routeCityWiseRepository;
        }

        // GET: Master/LaneMaster
        public ActionResult Index(long CustomerId = 0)
        {
            if (TempData["MessageType"] != null)
            {
                ViewBag.MessageType = Convert.ToString(TempData["MessageType"]);
                ViewBag.MessageText = Convert.ToString(TempData["MessageText"]);
                TempData.Clear();
            }
            var oLane = new Lane();
            var oLaneDetail = laneRepository.GetAll(SessionUtility.CompanyId, CustomerId);
            oLane.LaneDetails = oLaneDetail;
            return View(oLane);
        }

        public void InItViewBag()
        {
            ((dynamic)base.ViewBag).CustomerList = laneRepository.GetLaneCustomer(SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).RouteList = this.routeCityWiseRepository.GetAllList();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).FuelTypeList = this.generalRepository.GetByIdList(7);
        }

        public ActionResult GetLaneDetails(long CustomerId = 0)
        {
            InItViewBag();
            var oLane = new Lane();
            oLane.CustomerId = CustomerId;
            oLane.CompanyId = SessionUtility.CompanyId;
            var oLaneDetail = laneRepository.GetAll(SessionUtility.CompanyId, CustomerId);
            if (oLaneDetail.Count == 0)
                oLaneDetail = new List<LaneDetail>()
                {
                    new LaneDetail()
                    {
                        ID=0,
                        CustomerId=CustomerId,
                        LaneId=string.Empty,
                        MasterLaneId=string.Empty,
                        RouteId=string.Empty,
                        FTLTypeId=string.Empty,
                        FuelTypeId=string.Empty,
                        AssetCount=0,
                        DriverCount = 0,
                        ContractedKM=0,
                        IsActive=true
                    }
                };
            oLane.LaneDetails = oLaneDetail;
            return View("Create", oLane);
        }

        // GET: Master/LaneMaster/Create
        public ActionResult Create()
        {
            InItViewBag();
            var oLane = new Lane();
            return View(oLane);
        }

        // POST: Master/LaneMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lane oLane)
        {
            try
            {
                oLane.LaneDetails.RemoveAll(r => r.LaneId == "0" || r.LaneId == null);
                if (!this.ModelState.IsValid)
                {
                    InItViewBag();
                    var errors = this.ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                    return View("Create");
                }
                oLane.EntryBy = SessionUtility.LoginUserId;
                this.laneRepository.Insert(SessionUtility.CompanyId, oLane.CustomerId, oLane);

                TempData["MessageType"] = "Success";
                TempData["MessageText"] = "Record Added Successfully";
                TempData.Keep();
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = "Failed";
                TempData["MessageText"] = "Error:" + ex.Message.Replace(System.Environment.NewLine, "");
                TempData.Keep();
                return RedirectToAction("Index");
            }
        }

    }
}
