using CodeLock.Areas.Ewaybill.Repository;
using CodeLock.Models;
using CodeLock.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Ewaybill.Controllers
{
    public class EwaybillMasterController : Controller
    {
        private readonly IEwaybillRepository ewaybillRepository;

        public EwaybillMasterController() { }
        public EwaybillMasterController(IEwaybillRepository _ewaybillRepository)
        {
            this.ewaybillRepository = _ewaybillRepository;
        }

        // GET: Ewaybill/FetchByTransporter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EwaybillTaskScheduler()
        {
            try
            {
                if (!ewaybillRepository.IsRunning())
                {
                    ewaybillRepository.Start();
                    ewaybillRepository.GetUpdateIsSchedulerActiveOrUpdate("DailyEwaybillTaskScheduler", "UpdateIsActive", true);
                    return Json(new { isRunning = true, message = "Task Scheduler is now running." });
                }
                else
                {
                    ewaybillRepository.Stop();
                    ewaybillRepository.GetUpdateIsSchedulerActiveOrUpdate("DailyEwaybillTaskScheduler", "UpdateIsActive", false);
                    return Json(new { isRunning = false, message = "Task Scheduler is now stopped." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = $"Error: {ex.Message}" });
            }
        }
        [HttpGet]
        public JsonResult GetSchedulerStatus()
        {
            try
            {
                bool isRunning = ewaybillRepository.IsRunning();
                var status = new
                {
                    message = isRunning ? "Scheduler is running." : "Scheduler is not running."
                };
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { isRunning = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}