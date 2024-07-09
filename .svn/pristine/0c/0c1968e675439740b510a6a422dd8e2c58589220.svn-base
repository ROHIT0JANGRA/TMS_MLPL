
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class AccountCategoryController : Controller
  {
    private readonly IAccountCategoryRepository accountCategoryRepository;

    public AccountCategoryController()
    {
    }

    public AccountCategoryController(
      IAccountCategoryRepository _accountCategoryRepository)
    {
      this.accountCategoryRepository = _accountCategoryRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.accountCategoryRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterAccountCategory());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("AccountCategoryId")]
    public ActionResult Insert(MasterAccountCategory objMasterAccountCategory)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterAccountCategory);
      objMasterAccountCategory.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.accountCategoryRepository.Insert(objMasterAccountCategory)
      });
    }

    public ActionResult Update(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.accountCategoryRepository.GetById(id.Value));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("AccountCategoryId")]
    public ActionResult Update(MasterAccountCategory objMasterAccountCategory)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterAccountCategory);
      objMasterAccountCategory.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.accountCategoryRepository.Update(objMasterAccountCategory)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.accountCategoryRepository.GetById(id.Value));
    }

    [ValidateAntiModelInjection("AccountCategoryId")]
    [HttpPost]
    public JsonResult IsAccountCategoryNameAvailable(
      MasterAccountCategory objMasterAccountCategory)
    {
      return this.Json((object) this.accountCategoryRepository.IsAccountCategoryNameAvailable(objMasterAccountCategory.CategoryName, (short) objMasterAccountCategory.AccountCategoryId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.accountCategoryRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
