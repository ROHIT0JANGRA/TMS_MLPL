
using CodeLock.Areas.Finance.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Controllers
{
  public class TripsheetBillController : Controller
  {
    private readonly ITripsheetBillRepository tripsheetBillRepository;
    private readonly IGeneralRepository generalRepository;

    public TripsheetBillController(
      ITripsheetBillRepository _tripsheetBillRepository,
      IGeneralRepository _generalRepository)
    {
      this.tripsheetBillRepository = _tripsheetBillRepository;
      this.generalRepository = _generalRepository;
    }

        public ActionResult BillGeneration()
        {
            TripsheetBill tripsheetBill = new TripsheetBill();
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            return base.View(tripsheetBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BillGeneration(TripsheetBill objTripsheetBill)
        {
            ActionResult action;
            objTripsheetBill.CompanyId = SessionUtility.CompanyId;
            objTripsheetBill.LocationId = SessionUtility.LoginLocationId;
            objTripsheetBill.EntryBy = SessionUtility.LoginUserId;
            objTripsheetBill.Details.RemoveAll((TripsheetBillDetail m) => !m.IsChecked);
            Response response = this.tripsheetBillRepository.Generate(objTripsheetBill);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
                action = base.View(objTripsheetBill);
            }
            else
            {
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, documentId = response.DocumentId });
            }
            return action;
        }



        public ActionResult Done()
    {
      return (ActionResult) this.View();
    }

    public JsonResult GetTripsheettListForBillGeneration(
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      byte ftlTypeId,
      short vehicleId,
      short generationLocationId)
    {
      return this.Json((object) this.tripsheetBillRepository.GetTripsheettListForBillGeneration(customerId, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, ftlTypeId, vehicleId, SessionUtility.LoginLocationId, SessionUtility.CompanyId, generationLocationId));
    }
  }
}
