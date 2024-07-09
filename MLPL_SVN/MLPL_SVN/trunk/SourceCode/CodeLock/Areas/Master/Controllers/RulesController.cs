using CodeLock.Areas.Master.Repository;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class RulesController : Controller
  {
    private readonly IRulesRepository rulesRepository;

    public RulesController(IRulesRepository _rulesRepository)
    {
      this.rulesRepository = _rulesRepository;
    }

    public RulesController()
    {
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public JsonResult GetModuleRuleByIdAndRuleId(byte moduleId, short ruleId)
    {
      return this.Json((object) this.rulesRepository.GetModuleRuleByIdAndRuleId(moduleId, ruleId));
    }

    [HttpPost]
    public JsonResult GetModuleRuleByIdAndRuleIdAndPaybasId(
      byte moduleId,
      short ruleId,
      byte paybasId)
    {
      return this.Json((object) this.rulesRepository.GetModuleRuleByIdAndRuleIdAndPaybasId(moduleId, ruleId, paybasId));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.rulesRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
