using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class HsnController : Controller
  {
    private readonly IHsnRepository hsnRepository;

    public HsnController()
    {
    }

    public HsnController(IHsnRepository _hsnRepository)
    {
      this.hsnRepository = _hsnRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.hsnRepository.GetAll());
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterHsn detailById = this.hsnRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

    public ActionResult Insert(byte? id)
    {
      MasterHsn masterHsn = new MasterHsn();
      byte? nullable = id;
      if ((nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        masterHsn = this.hsnRepository.GetDetailById(id.Value);
      return (ActionResult) this.View((object) masterHsn);
    }

    [ValidateAntiModelInjection("HsnId")]
    [HttpPost]
    public ActionResult Insert(MasterHsn objHsn)
    {
      if (this.ModelState.IsValid)
      {
        objHsn.EntryBy = SessionUtility.LoginUserId;
        objHsn.UpdateBy = new short?(SessionUtility.LoginUserId);
        Response response = objHsn.HsnId <= (byte) 0 ? this.hsnRepository.Insert(objHsn) : this.hsnRepository.Update(objHsn);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("View", (object) new
          {
            id = response.DocumentId
          });
        this.TempData["result"] = (object) response;
      }
      return (ActionResult) this.View((object) objHsn);
    }

    [ValidateAntiModelInjection("HsnId")]
    [HttpPost]
    public JsonResult IsHsnNameAvailable(MasterHsn objHsn)
    {
      return this.Json((object) this.hsnRepository.IsHsnNameAvailable(objHsn.HsnName, objHsn.HsnId));
    }

    [HttpPost]
    [ValidateAntiModelInjection("HsnId")]
    public JsonResult IsHsnCodeAvailable(MasterHsn objHsn)
    {
      return this.Json((object) this.hsnRepository.IsHsnCodeAvailable(objHsn.HsnCode, objHsn.HsnId));
    }

    public JsonResult GetHsnList()
    {
      return this.Json((object) this.hsnRepository.GetHsnList());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.hsnRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
