using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Operation.Controllers
{
  public class QuickDocketController : Controller
  {
    private readonly IQuickDocketRepository quickDocketRepository;
    private readonly IRulesRepository rulesRepository;

    public QuickDocketController()
    {
    }

    public QuickDocketController(
      IQuickDocketRepository _quickDocketRepository,
      IRulesRepository _rulesRepository)
    {
      this.quickDocketRepository = _quickDocketRepository;
      this.rulesRepository = _rulesRepository;
    }

        public ActionResult Insert(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();
            DocketStep1 step1Detail = this.quickDocketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;
            }
            else
            {
                docket.DocketId = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }


        [HttpPost]
    public ActionResult Insert(Docket objDocket)
    {
      objDocket.EntryBy = SessionUtility.LoginUserId;
      objDocket.EntryDate = DateTime.Now;
      objDocket.CompanyId = SessionUtility.CompanyId;
      int num = 0;
      for (byte index = 0; (int) index < objDocket.InvoiceList.Count; ++index)
      {
        ++num;
        objDocket.InvoiceList[(int) index].InvoiceId = num;
        foreach (InvoicePart part in objDocket.InvoiceList[(int) index].PartList)
        {
          if (part.PartId > 0)
            part.InvoiceId = num;
        }
      }
      Response response1 = new Response();
      string str = !objDocket.UsePreviousHistory || !objDocket.IsAdd ? (objDocket.DocketId > 0L ? "EditDone" : "EntryDone") : "EntryDone";
      objDocket.DocumentList.RemoveAll((Predicate<DocketDocument>) (m => m.DocumentName == string.Empty));
      Response response2 = !objDocket.UsePreviousHistory || !objDocket.IsAdd ? (objDocket.DocketId <= 0L ? this.quickDocketRepository.Insert(objDocket) : this.quickDocketRepository.Update(objDocket)) : this.quickDocketRepository.Insert(objDocket);
      if (response2.IsSuccessfull)
        return (ActionResult) this.RedirectToAction("InsertDone", (object) new
        {
          documentId = response2.DocumentId,
          documentNo = response2.DocumentNo,
          status = str,
          documentId2 = response2.DocumentId2,
          documentNo2 = response2.DocumentNo2
        });
      return (ActionResult) this.View((object) objDocket);
    }

    public ActionResult InsertDone()
    {
      return (ActionResult) this.View();
    }

    public ActionResult UpdateDone()
    {
      return (ActionResult) this.View();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.quickDocketRepository.Dispose();
      base.Dispose(disposing);
      if (disposing)
        this.rulesRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
