using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class IssueController : Controller
  {
    private readonly IIssueRepository issueRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly IMenuRepository menuRepository;

    public IssueController()
    {
    }

    public IssueController(
      IIssueRepository _issueRepository,
      IGeneralRepository _generalRepository,
      IMenuRepository _menuRepository)
    {
      this.issueRepository = _issueRepository;
      this.generalRepository = _generalRepository;
      this.menuRepository = _menuRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.issueRepository.GetAll());
    }

    public ActionResult History(long id)
    {
      return (ActionResult) this.View((object) this.issueRepository.GetHistoryById(id));
    }

    public ActionResult View(long? id)
    {
      if (!id.HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterIssue detailById = this.issueRepository.GetDetailById(id.Value);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

    public ActionResult HistoryView(long? id)
    {
      if (!id.HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterIssue historyDetailById = this.issueRepository.GetHistoryDetailById(id.Value);
      if (historyDetailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) historyDetailById);
    }

        public ActionResult Insert(long? id)
        {
            MasterIssue masterIssue = new MasterIssue();
            if (id.HasValue)
            {
                masterIssue = this.issueRepository.GetDetailById(id.Value);
            }
             ((dynamic)base.ViewBag).ClientList = this.generalRepository.GetByIdList(86);
            ((dynamic)base.ViewBag).MainMenuList = this.menuRepository.GetMainMenuList();
            return base.View(masterIssue);
        }

        [HttpPost]
        [ValidateAntiModelInjection("IssueId")]
        public ActionResult Insert(MasterIssue objIssue)
        {
            Response response;
            string fileName;
            string str;
            ActionResult action;
            string[] strArrays;
            long issueId;
            DateTime now;
            if (base.ModelState.IsValid)
            {
                objIssue.EntryBy = SessionUtility.LoginUserId;
                objIssue.UpdateBy = new short?(SessionUtility.LoginUserId);
                if (objIssue.IssueId <= (long)0)
                {
                    if (objIssue.IssueAttachment != null)
                    {
                        DynamicParameters dynamicParameter = new DynamicParameters();
                        int? nullable = null;
                        byte? nullable1 = null;
                        byte? nullable2 = nullable1;
                        nullable1 = null;
                        dynamicParameter.Add("@IssueId", null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), nullable, nullable2, nullable1);
                        DataBaseFactory.QuerySP("Usp_MasterIssue_GetMaxIssueId", dynamicParameter, "Master Issue - GetMaxIssueId");
                        long num = dynamicParameter.Get<long>("@IssueId");
                        fileName = "";
                        if (!ConfigHelper.IsLocalStorage)
                        {
                            object clientId = objIssue.ClientId;
                            now = SessionUtility.Now;
                            fileName = AzureStorageHelper.GetFileName("Issue", "DOC_TYPE", string.Concat(clientId, now.ToString()), num.ToString(), objIssue.IssueAttachment.FileName);
                            AzureStorageHelper.UploadBlob("Issue", objIssue.IssueAttachment, fileName, fileName);
                        }
                        else
                        {
                            strArrays = new string[] { num.ToString(), "_", null, null, null };
                            now = SessionUtility.Now;
                            strArrays[2] = now.ToString();
                            strArrays[3] = "_";
                            strArrays[4] = objIssue.IssueAttachment.FileName;
                            fileName = string.Concat(strArrays);
                            str = string.Concat(ConfigHelper.LocalStoragePath, "Issue/", fileName);
                            objIssue.IssueAttachment.SaveAs(str);
                        }
                        objIssue.IssueImage = fileName;
                        objIssue.IssueAttachment = null;
                    }
                    response = this.issueRepository.Insert(objIssue);
                }
                else
                {
                    if (objIssue.IssueAttachment != null)
                    {
                        fileName = "";
                        if (!ConfigHelper.IsLocalStorage)
                        {
                            object obj = objIssue.ClientId;
                            now = SessionUtility.Now;
                            string str1 = string.Concat(obj, now.ToString());
                            issueId = objIssue.IssueId;
                            fileName = AzureStorageHelper.GetFileName("Issue", "DOC_TYPE", str1, issueId.ToString(), objIssue.IssueAttachment.FileName);
                            AzureStorageHelper.UploadBlob("Issue", objIssue.IssueAttachment, fileName, fileName);
                        }
                        else
                        {
                            strArrays = new string[5];
                            issueId = objIssue.IssueId;
                            strArrays[0] = issueId.ToString();
                            strArrays[1] = "_";
                            now = SessionUtility.Now;
                            strArrays[2] = now.ToString();
                            strArrays[3] = "_";
                            strArrays[4] = objIssue.IssueAttachment.FileName;
                            fileName = string.Concat(strArrays);
                            str = string.Concat(ConfigHelper.LocalStoragePath, "Issue/", fileName);
                            objIssue.IssueAttachment.SaveAs(str);
                        }
                        objIssue.IssueImage = fileName;
                        objIssue.IssueAttachment = null;
                    }
                    response = this.issueRepository.Update(objIssue);
                }
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
                base.TempData["result"] = response;
            }
           ((dynamic)base.ViewBag).ClientList = this.generalRepository.GetByIdList(86);
            ((dynamic)base.ViewBag).MainMenuList = this.menuRepository.GetMainMenuList();
            action = base.View(objIssue);
            return action;
        }

        public ActionResult Close(long id)
    {
      return (ActionResult) this.View((object) new MasterIssueClose()
      {
        IssueId = id
      });
    }

    [HttpPost]
    [ValidateAntiModelInjection("IssueId")]
    public ActionResult Close(MasterIssueClose objMasterIssueClose)
    {
      if (objMasterIssueClose.ResolvedDocumentAttachment != null)
      {
        string str;
        if (ConfigHelper.IsLocalStorage)
        {
          str = objMasterIssueClose.IssueId.ToString() + "_" + SessionUtility.Now.ToString() + "_" + objMasterIssueClose.ResolvedDocumentAttachment.FileName;
          string filename = ConfigHelper.LocalStoragePath + "Issue/" + str;
          objMasterIssueClose.ResolvedDocumentAttachment.SaveAs(filename);
        }
        else
        {
          str = AzureStorageHelper.GetFileName("Issue", "DOC_TYPE", SessionUtility.Now.ToString(), objMasterIssueClose.IssueId.ToString(), objMasterIssueClose.ResolvedDocumentAttachment.FileName);
          AzureStorageHelper.UploadBlob("Issue", objMasterIssueClose.ResolvedDocumentAttachment, str, str);
        }
        objMasterIssueClose.ResolvedDocument = str;
        objMasterIssueClose.ResolvedDocumentAttachment = (HttpPostedFileBase) null;
      }
      Response response = this.issueRepository.Close(objMasterIssueClose);
      if (response.IsSuccessfull)
        return (ActionResult) this.RedirectToAction("View", (object) new
        {
          id = response.DocumentId
        });
      this.TempData["result"] = (object) response;
      return (ActionResult) this.View((object) objMasterIssueClose);
    }

    public ActionResult Approval(long id)
    {
      MasterIssueApproval masterIssueApproval = new MasterIssueApproval();
      masterIssueApproval.IssueId = id;
      MasterIssue detailById = this.issueRepository.GetDetailById(id);
      masterIssueApproval.IssueDocument = detailById.IssueImage;
      masterIssueApproval.ResolvedDocument = detailById.ResolvedDocument;
      return (ActionResult) this.View((object) masterIssueApproval);
    }

    [HttpPost]
    [ValidateAntiModelInjection("IssueId")]
    public ActionResult Approval(MasterIssueApproval objMasterIssueApproval)
    {
      Response response = this.issueRepository.Approval(objMasterIssueApproval);
      if (response.IsSuccessfull)
        return (ActionResult) this.RedirectToAction("View", (object) new
        {
          id = response.DocumentId
        });
      this.TempData["result"] = (object) response;
      return (ActionResult) this.View((object) objMasterIssueApproval);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.issueRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}
