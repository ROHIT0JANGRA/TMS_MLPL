using CodeLock.Areas.Master.Repository;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class ChargeController : Controller
  {
    private readonly IChargeRepository chargeRepository;

    public ChargeController()
    {
    }

    public ChargeController(IChargeRepository _chargeRepository)
    {
      this.chargeRepository = _chargeRepository;
    }

    public JsonResult GetChargeByTypeId(byte chargeType, byte chargeCode)
    {
      return this.Json((object) this.chargeRepository.GetChargeByTypeId(chargeType, chargeCode), JsonRequestBehavior.AllowGet);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.chargeRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
