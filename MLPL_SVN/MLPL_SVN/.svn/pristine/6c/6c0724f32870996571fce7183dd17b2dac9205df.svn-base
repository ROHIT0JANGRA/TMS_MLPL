using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class SupplierController : Controller
  {
    private readonly ISupplierRepository supplierRepository;

    public SupplierController()
    {
    }

    public SupplierController(ISupplierRepository _supplierRepository)
    {
      this.supplierRepository = _supplierRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.supplierRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterSupplier());
    }

    [ValidateAntiModelInjection("SupplierId")]
    [HttpPost]
    public ActionResult Insert(MasterSupplier objMasterSupplier)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterSupplier);
      objMasterSupplier.EntryBy = SessionUtility.LoginUserId;
      objMasterSupplier.WarehouseId = SessionUtility.WarehouseId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.supplierRepository.Insert(objMasterSupplier).DocumentId
      });
    }

    public ActionResult Update(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.supplierRepository.GetById(id.Value));
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("SupplierId")]
    public ActionResult Update(MasterSupplier objMasterSupplier)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterSupplier);
      objMasterSupplier.UpdateBy = new short?(SessionUtility.LoginUserId);
      objMasterSupplier.WarehouseId = SessionUtility.WarehouseId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.supplierRepository.Update(objMasterSupplier)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.supplierRepository.GetById(id.Value));
    }

    [ValidateAntiModelInjection("SupplierId")]
    [HttpPost]
    public JsonResult IsSupplierNameAvailable(MasterSupplier objMasterSupplier)
    {
      return this.Json((object) this.supplierRepository.IsSupplierNameAvailable(objMasterSupplier.SupplierName, objMasterSupplier.SupplierId));
    }

    public JsonResult IsSupplierCodeExist(string supplierCode)
    {
      return this.Json((object) this.supplierRepository.IsSupplierCodeExist(SessionUtility.CompanyId, supplierCode));
    }

    public JsonResult GetAutoCompleteList(string supplierCode)
    {
      return this.Json((object) this.supplierRepository.GetAutoCompleteList(SessionUtility.CompanyId, supplierCode));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.supplierRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
