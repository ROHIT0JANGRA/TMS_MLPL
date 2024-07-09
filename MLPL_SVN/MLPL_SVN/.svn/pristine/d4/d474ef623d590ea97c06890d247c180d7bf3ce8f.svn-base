using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class CustomerBillFormatController : Controller
  {
    private readonly ICustomerBillFormatRepository customerBillFormatRepository;
    private readonly ICustomerGroupRepository customerGroupRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly ICustomerRepository customerRepository;

        public CustomerBillFormatController()
        {
        }

        public CustomerBillFormatController(ICustomerBillFormatRepository _customerBillFormatRepository, ICustomerGroupRepository _customerGroupRepository, IGeneralRepository _generalRepository, ICustomerRepository _customerRepository)
        {
            this.customerBillFormatRepository = _customerBillFormatRepository;
            this.customerGroupRepository = _customerGroupRepository;
            this.generalRepository = _generalRepository;
            this.customerRepository = _customerRepository;
        }

        protected override void Dispose(bool disposing)
        {
            this.customerBillFormatRepository.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult GetAll(string groupCode)
        {
            IEnumerable<MasterCustomerBillFormat> all = this.customerBillFormatRepository.GetAll(groupCode);
            return base.Json(all, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBillFormat(string paybasId, string transportModeId, string serviceTypeId, byte formatId)
        {
            JsonResult jsonResult = base.Json(this.customerBillFormatRepository.GetBillFormat(paybasId, transportModeId, serviceTypeId, formatId));
            return jsonResult;
        }

        public JsonResult GetBillFormatByCustomerId(short customerId, byte paybasId, byte transportModeId, byte serviceTypeId)
        {
            JsonResult jsonResult = base.Json(this.customerBillFormatRepository.GetBillFormatByCustomerId(customerId, paybasId, transportModeId, serviceTypeId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsBillFormatMapped(short customerId)
        {
            JsonResult jsonResult = base.Json(this.customerBillFormatRepository.IsBillFormatMapped(customerId));
            return jsonResult;
        }

        public ActionResult Mapping()
        {
            MasterCustomerBillFormat masterCustomerBillFormat = new MasterCustomerBillFormat();
            ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerList();
            ((dynamic)base.ViewBag).GroupCodeList = this.customerGroupRepository.GetCustomerGroupList();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).BillFormatList = this.customerBillFormatRepository.GetBillFormatList();
            return base.View(masterCustomerBillFormat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mapping(MasterCustomerBillFormat objMasterCustomerBillFormatMapping)
        {
            objMasterCustomerBillFormatMapping.EntryBy = SessionUtility.LoginUserId;
            this.customerBillFormatRepository.BillFormatMapping(objMasterCustomerBillFormatMapping);
            return base.RedirectToAction("MappingDone");
        }

        public ActionResult MappingDone()
        {
            return base.View();
        }
        public ActionResult MappingV1()
        {
            MasterCustomerBillFormat masterCustomerBillFormat = new MasterCustomerBillFormat();
            IEnumerable<AutoCompleteResult> billFormatList = this.customerBillFormatRepository.GetBillFormatList();
            ((dynamic)base.ViewBag).List = JsonConvert.SerializeObject(billFormatList);
            ((dynamic)base.ViewBag).GroupCodeList = this.customerGroupRepository.GetCustomerGroupList();
            IEnumerable<AutoCompleteResult> byIdList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).PaybasList = JsonConvert.SerializeObject(byIdList);
            IEnumerable<AutoCompleteResult> autoCompleteResults = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).TransportModeList = JsonConvert.SerializeObject(autoCompleteResults);
            IEnumerable<AutoCompleteResult> byIdList1 = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).ServiceTypeList = JsonConvert.SerializeObject(byIdList1);
            return base.View(masterCustomerBillFormat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MappingV1(MasterCustomerBillFormat objMasterCustomerBillFormat)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                IEnumerable<AutoCompleteResult> billFormatList = this.customerBillFormatRepository.GetBillFormatList();
                ((dynamic)base.ViewBag).List = JsonConvert.SerializeObject(billFormatList);
                ((dynamic)base.ViewBag).GroupCodeList = this.customerGroupRepository.GetCustomerGroupList();
                IEnumerable<AutoCompleteResult> byIdList = this.generalRepository.GetByIdList(14);
                ((dynamic)base.ViewBag).PaybasList = JsonConvert.SerializeObject(byIdList);
                IEnumerable<AutoCompleteResult> autoCompleteResults = this.generalRepository.GetByIdList(15);
                ((dynamic)base.ViewBag).TransportModeList = JsonConvert.SerializeObject(autoCompleteResults);
                IEnumerable<AutoCompleteResult> byIdList1 = this.generalRepository.GetByIdList(16);
                ((dynamic)base.ViewBag).ServiceTypeList = JsonConvert.SerializeObject(byIdList1);
                action = base.View();
            }
            else
            {
                objMasterCustomerBillFormat.CustomerBillFormatList.ForEach((MasterCustomerBillFormat m) => m.EntryBy = SessionUtility.LoginUserId);
                objMasterCustomerBillFormat.CustomerBillFormatList.ForEach((MasterCustomerBillFormat m) => m.GroupCode = objMasterCustomerBillFormat.GroupCode);
                this.customerBillFormatRepository.Mapping(objMasterCustomerBillFormat);
                action = base.RedirectToAction("Mapping");
            }
            return action;
        }



    }
}
