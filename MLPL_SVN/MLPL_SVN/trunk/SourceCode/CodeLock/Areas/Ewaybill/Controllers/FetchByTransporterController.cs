using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeLock.Areas.Ewaybill.Repository;
using CodeLock.Models;
using CodeLock.Scheduler;
using Newtonsoft.Json;


namespace CodeLock.Areas.Ewaybill.Controllers
{
    public class FetchByTransporterController : Controller
    {
        private readonly IEwaybillRepository ewaybillRepository;

        public FetchByTransporterController() { }
        public FetchByTransporterController(IEwaybillRepository _ewaybillRepository)
        {
            this.ewaybillRepository = _ewaybillRepository;
        }

        public ActionResult Index()
        {
            IEnumerable<GetAllStateCredential> stateList = this.ewaybillRepository.GetAllState();
            ((dynamic)base.ViewBag).stateList = stateList;

            return View();
        }

        public async Task<ActionResult> SubmitDataInDb(EwaybillGetDetailFromWebNoAndDate model)
        {
            try
            {
                await this.ewaybillRepository.SubmitDataInDbAllStates(model);
            }
            catch (Exception ex)
            {
                View(ex.Message);
            }
            return View();
        }

    }
}