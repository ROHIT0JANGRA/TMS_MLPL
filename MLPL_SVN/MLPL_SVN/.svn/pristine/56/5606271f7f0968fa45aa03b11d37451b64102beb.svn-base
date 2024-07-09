using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class RoleController : Controller
  {
    private readonly IRoleRepository roleRepository;

    public RoleController()
    {
    }

    public RoleController(IRoleRepository _roleRepository)
    {
      this.roleRepository = _roleRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.roleRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterRole());
    }

    [ValidateAntiModelInjection("RoleId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterRole objMasterRole)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterRole);
      objMasterRole.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = (short) this.roleRepository.Insert(objMasterRole)
      });
    }

    public ActionResult Update(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.roleRepository.GetById((byte) id.Value));
    }

    [ValidateAntiModelInjection("RoleId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterRole objMasterRole)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterRole);
      objMasterRole.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = (short) this.roleRepository.Update(objMasterRole)
      });
    }

    public ActionResult View(short? id)
    {
      short? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.roleRepository.GetById((byte) id.Value));
    }

    [HttpPost]
    [ValidateAntiModelInjection("RoleId")]
    public JsonResult IsRoleNameAvailable(MasterRole objMasterRole)
    {
      return this.Json((object) this.roleRepository.IsRoleNameAvailable(objMasterRole.RoleName, (short) objMasterRole.RoleId));
    }

    [HttpPost]
    public JsonResult GetRoleList()
    {
      return this.Json((object) this.roleRepository.GetRoleList());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.roleRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
