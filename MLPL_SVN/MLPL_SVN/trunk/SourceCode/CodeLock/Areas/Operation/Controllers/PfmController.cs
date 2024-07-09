using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Operation.Controllers
{
  public class PfmController : Controller
  {
    private readonly IPfmRepository pfmRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly ICustomerRepository customerRepository;

        public PfmController()
    {
    }

        public PfmController(IPfmRepository _pfmRepository, IGeneralRepository _generalrepository,
            ICustomerRepository _customerRepository)
        {
            this.pfmRepository = _pfmRepository;
            this.generalRepository = _generalrepository;
            this.customerRepository = _customerRepository;
        }

        public ActionResult Forward()
    {
      return (ActionResult) this.View((object) new Pfm());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Forward(Pfm objPfm)
    {
      this.ModelState.Remove("ReceivedBy");
      if (this.ModelState.IsValid)
      {
        objPfm.LocationId = SessionUtility.LoginLocationId;
        objPfm.LocationCode = SessionUtility.LoginLocationCode;
        objPfm.CompanyId = SessionUtility.CompanyId;
        objPfm.EntryBy = SessionUtility.LoginUserId;
        objPfm.Details.RemoveAll((Predicate<PfmDetails>) (m => !m.IsChecked));
        Response response = this.pfmRepository.InsertPfm(objPfm);
        if (response.IsSuccessfull)
          return (ActionResult) this.RedirectToAction("PfmDone", (object) new
          {
            DocumentId = response.DocumentId,
            DocumentNo = response.DocumentNo,
            status = nameof (Forward)
          });
      }
      return (ActionResult) this.View((object) objPfm);
    }

    public ActionResult PfmDone()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Acknowledge()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public ActionResult Acknowledge(Pfm objPfm)
    {
      objPfm.EntryBy = SessionUtility.LoginUserId;
      objPfm.LocationId = SessionUtility.LoginLocationId;
      objPfm.CompanyId = SessionUtility.CompanyId;
      Response response = this.pfmRepository.AcknowledgePfm(objPfm);
      if (response.IsSuccessfull)
        return (ActionResult) this.RedirectToAction("PfmDone", (object) new
        {
          DocumentId = response.DocumentId,
          DocumentNo = response.DocumentNo,
          status = nameof (Acknowledge)
        });
      return (ActionResult) this.View((object) objPfm);
    }

        public ActionResult Scan()
        {
            Pod pod = new Pod();
            pod.Details.Add(new ScanDetail());
            ((dynamic)base.ViewBag).DocumentTypeId = this.generalRepository.GetByIdList(45);
            return base.View(pod);
        }


        [HttpPost]
        public ActionResult Scan(Pod objPfm)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).DocumentTypeId = this.generalRepository.GetByIdList(45);
                action = base.View(objPfm);
            }
            else
            {
                foreach (ScanDetail scanDetail in
                    from m in objPfm.Details
                    where m.Attachment != null
                    select m)
                {
                    object[] documentType = new object[] { scanDetail.DocumentType, "_", null, null, null, null, null, null, null };
                    DateTime now = DateTime.Now;
                    string FileLoc = "";

                    documentType[2] = now.Year;
                    documentType[3] = "_";
                    now = DateTime.Now;
                    documentType[4] = now.ToString("MMM");
                    documentType[5] = "_";
                    documentType[6] = scanDetail.DocumentNo.Replace("/", "_");
                    documentType[7] = ".";
                    string fileName = scanDetail.Attachment.FileName;
                    char[] chrArray = new char[] { '.' };
                    documentType[8] = fileName.Split(chrArray).Last<string>();
                    scanDetail.DocumentName = string.Concat(documentType);
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        AzureStorageHelper.UploadBlob("POD", scanDetail.Attachment, scanDetail.DocumentName, scanDetail.DocumentName);
                    }
                    else
                    {
                        if(scanDetail.DocumentTypeId == 8)
                        {
                            //FileLoc = Server.MapPath("~/Storage/DocumentPrint/");
                            FileLoc = string.Concat(ConfigHelper.LocalStoragePath, "DocumentPrint/");
                        }
                        else
                        {
                            //FileLoc = Server.MapPath("~/Storage/POD/");
                            FileLoc = string.Concat(ConfigHelper.LocalStoragePath, "POD/");
                        }

                        if (System.IO.Directory.Exists(FileLoc)) { }
                        else
                        {
                            System.IO.Directory.CreateDirectory(FileLoc);
                        }

                        FileLoc = FileLoc + scanDetail.DocumentName;
                        string str = FileLoc; // Path.Combine(string.Concat(ConfigHelper.LocalStoragePath, "POD/"), scanDetail.DocumentName);
                        scanDetail.Attachment.SaveAs(str);
                    }
                    scanDetail.Attachment = null;
                }
                objPfm.Details.ForEach((ScanDetail m) => m.EntryBy = SessionUtility.LoginUserId);
                objPfm.Details.ForEach((ScanDetail m) => m.LocationId = SessionUtility.LoginLocationId);
                objPfm.Details.ForEach((ScanDetail m) => m.CompanyId = SessionUtility.CompanyId);
                base.TempData["PfmDetails"] = this.pfmRepository.InsertPod(objPfm);
                action = base.RedirectToAction("ScanDone");
            }
            return action;
        }

    public ActionResult ScanDone()
    {
            Pod pod = this.TempData["PfmDetails"] as Pod;
            for (int i=0; i < pod.Details.Count; i++)
            {
                ScanDetail sd = pod.Details[i];
                //sd.DocumentPath = Server.MapPath("~/Storage/POD/");
                sd.DocumentPath = string.Concat(ConfigHelper.LocalStoragePath, "POD/");
            }
        if (pod != null)
        return (ActionResult) this.View((object) pod);

      return (ActionResult) this.RedirectToAction("Scan");
    }
        public ActionResult DownloadPOD(string filename)
        {
            string Content = "";
            //string FileLoc = Server.MapPath("~/Storage/POD/");
            string FileLoc = string.Concat(ConfigHelper.LocalStoragePath, "POD/");
            FileLoc = FileLoc + filename;

            if (System.IO.File.Exists(FileLoc))
            {
                if (Path.GetExtension(filename) == ".gif")
                {
                    Content = "image/gif";
                }

                else if (Path.GetExtension(filename) == ".jpeg")
                {
                    Content = "image/jpeg";
                }

                else if (Path.GetExtension(filename) == ".jpg")
                {
                    Content = "image/jpeg";
                }
                else if (Path.GetExtension(filename) == ".png")
                {
                    Content = "image/png";
                }
                else if (Path.GetExtension(filename) == ".dwf")
                {
                    Content = "Application/x-dwf";
                }
                else if (Path.GetExtension(filename) == ".pdf")
                {
                    Content = "Application/pdf";
                }
                else if (Path.GetExtension(filename) == ".doc")
                {
                    Content = "Application/vnd.ms-word";
                }
                else if (Path.GetExtension(filename) == ".ppt" ||
                    Path.GetExtension(filename) == ".pps")
                {
                    Content = "Application/vnd.ms-powerpoint";
                }
                else if (Path.GetExtension(filename) == ".doc")
                {
                    Content = "Application/vnd.ms-word";
                }
                else if (Path.GetExtension(filename) == ".xls")
                {
                    Content = "Application/vnd.ms-excel";
                }
                else if (Path.GetExtension(filename) == ".jfif")
                {
                        Content = "image/jfif";
                }
                return File(FileLoc, Content);
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
        }

        public JsonResult CheckPodScanStatus(string documentNo, byte podTypeId)
    {
      return this.Json((object) this.pfmRepository.CheckPodScanStatus(documentNo, podTypeId, SessionUtility.LoginLocationId, SessionUtility.LoginLocationCode));
    }

    public JsonResult GetDocketListForPfm(
      byte companyId,
      short locationId,
      string docketList,
      DateTime fromDate,
      DateTime toDate)
    {
      return this.Json((object) this.pfmRepository.GetDocketListForPfm(companyId, locationId, docketList, fromDate, toDate), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetPfmListForAcknowledge(
      byte companyId,
      short locationId,
      string pfmList,
      DateTime fromDate,
      DateTime toDate)
    {
      return this.Json((object) this.pfmRepository.GetPfmListForAcknowledge(companyId, locationId, pfmList, fromDate, toDate), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetPfmDocketListForAcknowledge(long pfmId)
    {
      return this.Json((object) this.pfmRepository.GetPfmDocketListForAcknowledge(pfmId), JsonRequestBehavior.AllowGet);
    }

        public ActionResult IndexPODHandOver()
        {
            int rIndex;
            string CustomerId;

            DocumentTracking obj = new DocumentTracking();
            //obj.localStoragePath = @Server.MapPath("~/Storage/POD/");
            obj.localStoragePath = string.Concat(ConfigHelper.LocalStoragePath, "POD/");
            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);

            ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;

            rIndex = 0;
            CustomerId = "";

            foreach (var docket in iEnumerabledocket)
            {
                rIndex = rIndex + 1;
                if (rIndex == 1)
                {
                    CustomerId = docket.Value;
                }
            }

            if (rIndex == 1)
            {
                obj.CustomerId = CustomerId;
            }

            return base.View(obj);
        }

        [HttpPost]
        public ActionResult IndexPODHandOver(DocumentTracking obj)
        {
            obj.DocumentTrackingDetails.RemoveAll((Predicate<DocumentTracking>)(m => !m.IsChecked));

            foreach (var item in obj.DocumentTrackingDetails)
            {
                item.EntryBy = SessionUtility.LoginUserId;
            }

            obj.EntryBy = SessionUtility.LoginUserId;

            Response response = this.pfmRepository.InsertPODHandOver(obj);


            if (response.IsSuccessfull)
                return (ActionResult)this.RedirectToAction("PODHandOverDone", (object)new
                {
                    DocumentId = response.DocumentId,
                    DocumentNo = response.DocumentNo
                });
            return base.View(obj);
        }

        public JsonResult GetDocketPODList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo,
          int CustomerId,
          int ListType
          )
        {

            IEnumerable<DocumentTracking> iEnumerabledocket = this.pfmRepository.GetDocketPODHandOverList(locationId, fromDate, toDate, documentNo, manualDocumentNo, CustomerId, ListType);

            DataSet ds = new DataSet();
            ds.Tables.Add("tblDocket");
            ds.Tables[0].Columns.Add("DocumentName");

            foreach (var docket in iEnumerabledocket)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["DocumentName"] = docket.DocumentName.ToString();
                ds.Tables[0].Rows.Add(dr);
            }
            Session["docketDocumentName"] = ds;

            return this.Json((object)iEnumerabledocket, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PODHandOverDone()
        {
            return (ActionResult)this.View();
        }


        protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.pfmRepository.Dispose();
      base.Dispose(disposing);
      if (disposing)
        this.generalRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
