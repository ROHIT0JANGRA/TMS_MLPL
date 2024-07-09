using CodeLock.Areas.Master.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeLock.Models;

namespace CodeLock.Areas.Master.Controllers
{
    public class FSCRateController : Controller
    {
        private readonly IFSCRateRepository fscRateRepository;
        private readonly ILaneRepository laneRepository;

        public FSCRateController()
        {
        }

        public FSCRateController(ILaneRepository _laneRepository, IFSCRateRepository _fscRateRepository)
        {
            this.laneRepository = _laneRepository;
            this.fscRateRepository = _fscRateRepository;
        }
        // GET: Master/FSCRate
        public ActionResult Index(short? CustomerId = 0)
        {
            var oData = new FSCRate();
            try
            {
                if (TempData["MessageType"] != null)
                {
                    ViewBag.MessageType = Convert.ToString(TempData["MessageType"]);
                    ViewBag.MessageText = Convert.ToString(TempData["MessageText"]);
                    TempData.Clear();
                }
                InItViewBag(CustomerId);
                var oDetail = fscRateRepository.GetFSCRateList(SessionUtility.CompanyId, CustomerId);
                oData.Details = oDetail.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.MessageType = "Error";
                ViewBag.MessageText = ex.Message;
            }
            return View(oData);
        }
        public void InItViewBag(short? CustomerId = 0)
        {
            ((dynamic)base.ViewBag).CustomerList = laneRepository.GetLaneCustomer(SessionUtility.CompanyId);
            var oLaneList = this.fscRateRepository.GetLaneList((short)SessionUtility.CompanyId, CustomerId, 0);
            ((dynamic)base.ViewBag).LaneList = oLaneList.Select(row => new AutoCompleteResult() { Name = row.LaneId, Value = row.ID.ToString() }).ToList();
        }

        [HttpGet]
        public ActionResult GetFSCRateDetails()
        {
            return this.RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult GetFSCRateDetails(short customerId)
        {
            InItViewBag(customerId);
            var oData = new FSCRate();
            oData.CompanyId = SessionUtility.CompanyId;
            oData.CustomerId = customerId;
            oData.EntryBy = SessionUtility.LoginUserId;
            oData.Details = fscRateRepository.GetFSCRateList(SessionUtility.CompanyId, customerId).ToList();
            if (oData.Details.Count == 0)
                oData.Details = new List<FSCRateDetail> { new FSCRateDetail() { LaneId = "", ID = 0 } };

            return View("Create", oData);
        }

        [HttpPost]
        public ActionResult GetLaneDetails(short companyId, short customerId, short? LaneId)
        {
            JsonResult jsonResult = base.Json(this.fscRateRepository.GetLaneList(companyId, customerId, LaneId));
            return jsonResult;
        }
        public ActionResult Create()
        {
            InItViewBag();
            var oData = new FSCRate();
            return View(oData);
        }

        [HttpPost]
        public ActionResult Create(FSCRate oData)
        {
            try
            {
                oData.Details.RemoveAll(r => r.LaneId == "0" || r.LaneId == null);
                if (!this.ModelState.IsValid)
                {
                    InItViewBag();
                    var errors = this.ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                    return View("Create");
                }
                oData.EntryBy = SessionUtility.LoginUserId;
                oData.CompanyId = SessionUtility.CompanyId;
                this.fscRateRepository.Insert(oData);

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