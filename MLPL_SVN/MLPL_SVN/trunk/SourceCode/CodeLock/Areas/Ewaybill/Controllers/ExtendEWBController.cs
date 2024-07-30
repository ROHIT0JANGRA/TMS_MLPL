using CodeLock.Areas.Ewaybill.Repository;
using CodeLock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Ewaybill.Controllers
{
    public class ExtendEWBController : Controller
    {
        private readonly IEwaybillRepository ewaybillRepository;

        public ExtendEWBController() { }
        public ExtendEWBController(IEwaybillRepository _ewaybillRepository)
        {
            this.ewaybillRepository = _ewaybillRepository;
        }

        public JsonResult GetAllEwaybillDetailByPagination(Pagination pagination)
        {
            DTResponse DTResponse = new DTResponse();
            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ?
                "EWB_Detai_Id asc" : pagination.data.columns[pagination.data.order[0].column].name + " " +
                    pagination.data.order[0].dir;
            var ewaybills = this.ewaybillRepository.GetAllEwaybillDetailByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value);
            DTResponse.recordsTotal = ewaybills.FirstOrDefault() == null ? 0 : ewaybills.FirstOrDefault().TotalEwaybill;
            DTResponse.recordsFiltered = ewaybills.FirstOrDefault() == null ? 0 : ewaybills.FirstOrDefault().FilterEwaybill;
            DTResponse.data = JsonConvert.SerializeObject(ewaybills);
            return Json(DTResponse, JsonRequestBehavior.AllowGet);
        }

        // GET: Ewaybill/ExtendEWB
        public ActionResult Index()
        {
            ViewBag.ewbSummary = ewaybillRepository.GetSummary();
            return View();
        }

        [HttpPost]
        public ActionResult Extend(string ewbNo)
        {
            return Json(new { success = true, ewbno = ewbNo });
        }
    }
}