using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class CustomerGroupController : Controller
  {
    private readonly ICustomerGroupRepository customerGroupRepository;

    public CustomerGroupController()
    {
    }

    public CustomerGroupController(ICustomerGroupRepository _customerGroupRepository)
    {
      this.customerGroupRepository = _customerGroupRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.customerGroupRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterCustomerGroup()
      {
        GroupCode = "C"
      });
    }

    [ValidateAntiModelInjection("GroupCode")]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Insert(MasterCustomerGroup objMasterCustomerGroup)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCustomerGroup);
      objMasterCustomerGroup.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.customerGroupRepository.Insert(objMasterCustomerGroup)
      });
    }

    public ActionResult Update(string id)
    {
      if (id == null)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.customerGroupRepository.GetById(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("GroupCode")]
    public ActionResult Update(MasterCustomerGroup objMasterCustomerGroup)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCustomerGroup);
      objMasterCustomerGroup.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.customerGroupRepository.Update(objMasterCustomerGroup)
      });
    }

    public ActionResult View(string id)
    {
      if (id == null)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.customerGroupRepository.GetById(id));
    }

    [ValidateAntiModelInjection("GroupCode")]
    [HttpPost]
    public JsonResult IsGroupNameAvailable(MasterCustomerGroup objMasterCustomerGroup)
    {
      return this.Json((object) this.customerGroupRepository.IsGroupNameAvailable(objMasterCustomerGroup.GroupName, objMasterCustomerGroup.GroupCode));
    }

    public JsonResult GetCustomerGroupList()
    {
      return this.Json((object) this.customerGroupRepository.GetCustomerGroupList());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.customerGroupRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
