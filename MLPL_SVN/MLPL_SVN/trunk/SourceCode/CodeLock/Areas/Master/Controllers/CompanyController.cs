using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class CompanyController : Controller
  {
    private readonly ICompanyRepository companyRepository;

    public CompanyController()
    {
    }

    public CompanyController(ICompanyRepository _companyRepository)
    {
      this.companyRepository = _companyRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.companyRepository.GetAll());
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new MasterCompany());
    }

    [ValidateAntiModelInjection("CompanyId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterCompany objMasterCompany)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCompany);
      objMasterCompany.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.companyRepository.Insert(objMasterCompany)
      });
    }

    [ValidateAntiModelInjection("CompanyId")]
    [HttpPost]
    public JsonResult IsCompanyNameAvailable(MasterCompany objMasterCompany)
    {
      return this.Json((object) this.companyRepository.IsCompanyNameAvailable(objMasterCompany.CompanyName, (short) objMasterCompany.CompanyId));
    }

    public ActionResult Update(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.companyRepository.GetById(id.Value));
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("CompanyId")]
    public ActionResult Update(MasterCompany objMasterCompany)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterCompany);
      objMasterCompany.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.companyRepository.Update(objMasterCompany)
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.companyRepository.GetById(id.Value));
    }

    [HttpPost]
    public JsonResult GetCompanyList()
    {
      return this.Json((object) this.companyRepository.GetCompanyList());
    }

    public JsonResult IsCompanyCodeExist(string companyCode)
    {
      return this.Json((object) this.companyRepository.IsCompanyCodeExist(companyCode));
    }

    public JsonResult GetAutoCompleteCompanyList(string companyCode)
    {
      return this.Json((object) this.companyRepository.GetAutoCompleteCompanyList(companyCode));
    }

    [HttpPost]
    public JsonResult GetVirtualLoginFinanceYearListByUserId(short loginUserId)
    {
      return this.Json((object) this.companyRepository.GetVirtualLoginFinanceYearListByUserId(loginUserId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.companyRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
