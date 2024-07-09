using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class ConsignorConsigneeController : Controller
  {
    private readonly IConsignorConsigneeRepository consignorConsigneeRepository;

    public ConsignorConsigneeController(
      IConsignorConsigneeRepository _consignorConsigneeRepository)
    {
      this.consignorConsigneeRepository = _consignorConsigneeRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.consignorConsigneeRepository.GetAll());
    }

    public ActionResult Mapping(short? id)
    {
      MasterConsignorConsigneeMapping consigneeMapping = new MasterConsignorConsigneeMapping();
      short? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        consigneeMapping = this.consignorConsigneeRepository.GetById(id.Value);
      return (ActionResult) this.View((object) consigneeMapping);
    }

    [HttpPost]
    [ValidateAntiModelInjection("MappingId")]
    public ActionResult Mapping(
      MasterConsignorConsigneeMapping objMasterConsignorConsigneeMapping)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterConsignorConsigneeMapping);
      short num;
      if (objMasterConsignorConsigneeMapping.MappingId > (short) 0)
      {
        objMasterConsignorConsigneeMapping.UpdateBy = new short?(SessionUtility.LoginUserId);
        objMasterConsignorConsigneeMapping.UpdateDate = new DateTime?(DateTime.Now);
        num = this.consignorConsigneeRepository.Update(objMasterConsignorConsigneeMapping);
      }
      else
      {
        objMasterConsignorConsigneeMapping.EntryBy = SessionUtility.LoginUserId;
        objMasterConsignorConsigneeMapping.EntryDate = DateTime.Now;
        num = this.consignorConsigneeRepository.Insert(objMasterConsignorConsigneeMapping);
      }
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = num
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.consignorConsigneeRepository.GetById(id.Value));
    }

    [HttpPost]
    public JsonResult IsMappingAvailable(
      short mappingId,
      short consignorId,
      short consigneeId,
      short billingPartyId)
    {
      return this.Json((object) this.consignorConsigneeRepository.IsMappingAvailable(mappingId, consignorId, consigneeId, billingPartyId));
    }

    protected override void Dispose(bool disposing)
    {
      this.consignorConsigneeRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
