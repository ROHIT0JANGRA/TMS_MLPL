using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class PartController : Controller
    {
        private readonly IPartRepository partRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ICustomerRepository customerRepository;
        public PartController()
        {

        }

        public PartController(IGeneralRepository _generalRepository, IPartRepository _partRepository, ICustomerRepository _customerRepository)
        {
            this.generalRepository = _generalRepository;
            this.partRepository = _partRepository;
            this.customerRepository = _customerRepository;
        }


        // GET: Master/Part
        //public ActionResult Index()
        //{
        //    return (ActionResult)this.View((object)this.partRepository.GetAll());
        //}

        public ActionResult Insert()
        {
            MasterPart masterPart = new MasterPart();
            MasterPartDetail masterPartDetail = new MasterPartDetail();
            masterPart.PartDetails.Add(masterPartDetail);
            ((dynamic)base.ViewBag).PackingType = this.generalRepository.GetByIdList(102);
            ((dynamic)base.ViewBag).PackageDimensions = this.generalRepository.GetByIdList(103);
            ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetDropDownCustomerList(SessionUtility.CompanyId);

            return View(masterPart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("PartId")]
        public ActionResult Insert(MasterPart objMasterPart)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterPart);
            objMasterPart.EntryBy = SessionUtility.LoginUserId;
            objMasterPart.EntryDate = DateTime.Now;
            objMasterPart.UpdateDate = null;
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.partRepository.Insert(objMasterPart)
            });

        }
        //[ValidateAntiModelInjection("PartId")]
        
        //[HttpPost]
        public JsonResult IsPartNameAvailable(MasterPart objMasterPart)
        {
            return this.Json((object)this.partRepository.IsPartNameAvailable(objMasterPart.PartName, objMasterPart.PartId));
        }
        public JsonResult IsPartNoAvailable(MasterPart objMasterPart)
        {
            return this.Json((object)this.partRepository.IsPartNoAvailable(objMasterPart.PartNo, objMasterPart.PartId));
        }

        public ActionResult Update(long? id)
        {
            ActionResult httpStatusCodeResult;

            if (id.HasValue)
            {
                ((dynamic)base.ViewBag).PackingType = this.generalRepository.GetByIdList(102);
                ((dynamic)base.ViewBag).PackageDimensions = this.generalRepository.GetByIdList(103);
                ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetDropDownCustomerList(SessionUtility.CompanyId);
                httpStatusCodeResult = base.View(this.partRepository.GetById(id.ConvertToLong()));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("PartId")]
        public ActionResult Update(MasterPart objMasterPart)
        {
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterPart);
            objMasterPart.UpdateBy = new short?(SessionUtility.LoginUserId);
            objMasterPart.EntryDate = DateTime.Now;
            objMasterPart.UpdateDate = DateTime.Now;
            objMasterPart.UpdateDate = DateTime.Now;
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.partRepository.Update(objMasterPart)
            });
        }
        public ActionResult View(long? id)
        {
            long? nullable = id;
            if (!(nullable.HasValue ? new long?((long)nullable.GetValueOrDefault()) : new long?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.partRepository.GetById(id.Value));
        }

        [HttpPost]
        public JsonResult GetPackingTypeListByPartId(short partId, short consignorId, short consigneeId)
        {
            return this.Json((object)this.partRepository.GetPackingTypeListByPartId(partId, consignorId, consigneeId));
        }

        [HttpPost]
        public JsonResult GetPartListByConsignorIdAndConsigneeId(short consignorId, short consigneeId)
        {
            return this.Json((object)this.partRepository.GetPartListByConsignorIdAndConsigneeId(consignorId, consigneeId));
        }

        [HttpPost]
        public JsonResult GetPartDetailByPartIdAndPackingTypeId(long partId, short packingTypeId, short consignorId, short consigneeId)
        {
            return this.Json((object)this.partRepository.GetPartDetailByPartIdAndPackingTypeId(partId, packingTypeId, consignorId, consigneeId));
        }




        public JsonResult GetPartByPagination(Pagination pagination)
        {
            DTResponse DTResponse = new DTResponse();
            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ?
                "PartId asc" : pagination.data.columns[pagination.data.order[0].column].name + " " +
                    pagination.data.order[0].dir;
            var parts = this.partRepository.GetPartByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value);
            DTResponse.recordsTotal = parts.FirstOrDefault() == null ? 0 : parts.FirstOrDefault().TotalParts;
            DTResponse.recordsFiltered = parts.FirstOrDefault() == null ? 0 : parts.FirstOrDefault().FilterParts;
            DTResponse.data = JsonConvert.SerializeObject(parts);
            return Json(DTResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return base.View();
        }



    }
}