
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class AddressController : Controller
  {
    private readonly IAddressRepository addressRepository;

    public AddressController()
    {
    }

    public AddressController(IAddressRepository _addressRepository)
    {
      this.addressRepository = _addressRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.addressRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterAddress());
    }

    [ValidateAntiModelInjection("AddressId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterAddress objMasterAddress)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterAddress);
      objMasterAddress.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.addressRepository.Insert(objMasterAddress)
      });
    }

    public ActionResult Update(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.addressRepository.GetById(id.Value));
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("AddressId")]
    public ActionResult Update(MasterAddress objMasterAddress)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterAddress);
      objMasterAddress.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.addressRepository.Update(objMasterAddress)
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.addressRepository.GetById(id.Value));
    }

    public JsonResult GetAddressByContractId(short contractId)
    {
      return this.Json((object) this.addressRepository.GetAddressByContractId(contractId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    [ValidateAntiModelInjection("AddressId")]
    public JsonResult IsAddressCodeAvailable(MasterAddress objMasterAddress)
    {
      return this.Json((object) this.addressRepository.IsAddressCodeAvailable(objMasterAddress.AddressCode, objMasterAddress.AddressId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.addressRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
