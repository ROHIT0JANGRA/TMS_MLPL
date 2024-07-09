using CodeLock.Areas.Master.Repository;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class JobOrderApprovalMatrixController : Controller
  {
    private readonly IJobOrderApprovalMatrixRepository jobOrderApprovalMatrixRepository;

    public JobOrderApprovalMatrixController()
    {
    }

    public JobOrderApprovalMatrixController(
      IJobOrderApprovalMatrixRepository _jobOrderApprovalMatrixRepository)
    {
      this.jobOrderApprovalMatrixRepository = _jobOrderApprovalMatrixRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }
  }
}
