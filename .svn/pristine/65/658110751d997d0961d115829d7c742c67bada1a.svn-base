//  
// Type: CodeLock.Areas.FMS.Controllers.TrackingController
//  
//  
//  

using CodeLock.Areas.FMS.Repository;
using CodeLock.Models;
using System;
using System.Web.Mvc;

namespace CodeLock.Areas.FMS.Controllers
{
  public class TrackingController : Controller
  {
    private readonly ITrackingRepository trackingRepository;

    public TrackingController()
    {
    }

    public TrackingController(ITrackingRepository _trackingRepository)
    {
      this.trackingRepository = _trackingRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) new FleetDocumentTracking());
    }

    [HttpPost]
    public JsonResult GetTripsheetList(
      short locationId,
      DateTime fromDate,
      DateTime toDate,
      string tripsheetNos,
      string manualTripsheetNos,
      string vehicalNos)
    {
      return this.Json((object) this.trackingRepository.GetTripsheetList(locationId, fromDate, toDate, tripsheetNos, manualTripsheetNos, vehicalNos));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.trackingRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
