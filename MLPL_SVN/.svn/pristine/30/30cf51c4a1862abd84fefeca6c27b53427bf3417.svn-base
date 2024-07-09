using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CodeLock.Areas.Operation.Controllers
{
  public class VendorDocumentApprovalController : Controller
  {
    private readonly IVendorDocumentApprovalRepository vendorDocumentApprovalRepository;
    private readonly IGeneralRepository generalRepository;

    public VendorDocumentApprovalController(
      IVendorDocumentApprovalRepository _vendorDocumentApprovalRepository,
      IGeneralRepository _generalRepository)
    {
      this.vendorDocumentApprovalRepository = _vendorDocumentApprovalRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Insert()
    {
      return (ActionResult) this.View((object) new VendorDocumentApproval()
      {
        DocumentTypes = this.generalRepository.GetByGeneralList((short) 83).ToArray<MasterGeneral>()
      });
    }

    [HttpPost]
    public ActionResult Insert(VendorDocumentApproval objVendorDocumentApproval)
    {
      if (this.ModelState.IsValid)
      {
        objVendorDocumentApproval.Details.RemoveAll((Predicate<VendorDocumentDetail>) (x => !x.IsChecked));
        Response response = this.vendorDocumentApprovalRepository.Insert(objVendorDocumentApproval);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Done", (object) new
          {
            historyId = response.DocumentId
          });
      }
      return (ActionResult) this.View((object) objVendorDocumentApproval);
    }

    public ActionResult Done(long historyId)
    {
      List<VendorDocumentDetail> vendorDocumentDetailList = new List<VendorDocumentDetail>();
      vendorDocumentDetailList.AddRange(this.vendorDocumentApprovalRepository.GetVendorDocumentDetailListByDocumentId(historyId));
      return (ActionResult) this.View((object) vendorDocumentDetailList);
    }

    public JsonResult GetDocumentListForApproval(
      short locationId,
      string SelectedDocumentType)
    {
      return this.Json((object) this.vendorDocumentApprovalRepository.GetDocumentListForApproval(locationId, SelectedDocumentType));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.vendorDocumentApprovalRepository.Dispose();
      base.Dispose(disposing);
      if (disposing)
        this.generalRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
