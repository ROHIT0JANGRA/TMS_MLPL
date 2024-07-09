using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class DcrController : Controller
    {
        private readonly IDcrRepository dcrRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IDocumentControlRepository documentControlRepository;
        private readonly ICompanyRepository companyRepository;

        public DcrController()
        {
        }

        public DcrController(IDcrRepository _dcrRepository, IGeneralRepository _generalRepository, ILocationRepository _locationRepository, IDocumentControlRepository _documentControlRepository, ICompanyRepository _companyRepository)
        {
            this.dcrRepository = _dcrRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.documentControlRepository = _documentControlRepository;
            this.companyRepository = _companyRepository;

        }

        [HttpPost]
        public JsonResult CheckValidSeriesFrom(string dcrSeriesFrom, string dcrSeriesTo, string seriesFrom)
        {
            bool flag = this.dcrRepository.CheckValidSeriesFrom(dcrSeriesFrom, dcrSeriesTo, seriesFrom);
            return base.Json(flag, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DocumentVoid()
        {
            ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(23);
            return base.View();
        }

        [HttpPost]
        public ActionResult DocumentVoid(MasterDcr objMasterDcr)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                if (this.dcrRepository.DocumentVoidInsert(objMasterDcr.Id, objMasterDcr.DocumentNumber, SessionUtility.LoginUserId, SessionUtility.CompanyId).IsSuccessfull)
                {
                    action = base.RedirectToAction("DocumentVoidDone", new { documentId = objMasterDcr.Id, documentNo = objMasterDcr.DocumentNumber });
                    return action;
                }
            }
            action = base.View(objMasterDcr);
            return action;
        }

        public ActionResult DocumentVoidDone()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult GetDetailByDocumentTypeIdAndDocumentNumber(byte documentTypeId, string seriesFrom)
        {
            MasterDcr detailByDocumentTypeIdAndDocumentNumber = this.dcrRepository.GetDetailByDocumentTypeIdAndDocumentNumber(documentTypeId, seriesFrom);
            return base.Json(detailByDocumentTypeIdAndDocumentNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetListByDocumentTypeId(byte documentTypeId)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.GetListByDocumentTypeId(documentTypeId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetManagementHistoryByDocumentTypeIdAndDocumentNumber(byte documentTypeId, string seriesFrom)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.GetManagementHistoryByDocumentTypeIdAndDocumentNumber(documentTypeId, seriesFrom));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetMaxDocumentNumber(long documentId, string dcrSeriesFrom, string seriesFrom)
        {
            string maxDocumentNumber = this.dcrRepository.GetMaxDocumentNumber(documentId, dcrSeriesFrom, seriesFrom);
            return base.Json(maxDocumentNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetTotalLeaf(string seriesFrom, string dcrSeriesTo)
        {
            int totalLeaf = this.dcrRepository.GetTotalLeaf(seriesFrom, dcrSeriesTo);
            return base.Json(totalLeaf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>();
            masterDcrs = this.dcrRepository.GetAll().ToList<MasterDcr>();
            return base.View(masterDcrs);
        }

        private void Init()
        {
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).DcrTotalLeafList = this.generalRepository.GetByIdList(82);
            ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(23);
            ((dynamic)base.ViewBag).DocumentTypeDetails = JsonConvert.SerializeObject(this.documentControlRepository.GetDcrDocumentList(SessionUtility.CompanyId));
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            dynamic viewBag = base.ViewBag;
            List<AutoCompleteResult> autoCompleteResults = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult = new AutoCompleteResult()
            {
                Name = "50",
                Value = "50"
            };
            autoCompleteResults.Add(autoCompleteResult);
            AutoCompleteResult autoCompleteResult1 = new AutoCompleteResult()
            {
                Name = "100",
                Value = "100"
            };
            autoCompleteResults.Add(autoCompleteResult1);
            AutoCompleteResult autoCompleteResult2 = new AutoCompleteResult()
            {
                Name = "10000",
                Value = "10000"
            };
            autoCompleteResults.Add(autoCompleteResult2);

            AutoCompleteResult autoCompleteResult3 = new AutoCompleteResult()
            {
                Name = "20000",
                Value = "20000"
            };
            autoCompleteResults.Add(autoCompleteResult3);

            AutoCompleteResult autoCompleteResult4 = new AutoCompleteResult()
            {
                Name = "30000",
                Value = "30000"
            };
            autoCompleteResults.Add(autoCompleteResult4);

            viewBag.PageList = autoCompleteResults;
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
        }

        public ActionResult InsertDumptco()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }

        public ActionResult InsertDarcl()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }

        [HttpPost]
        public ActionResult InsertDarcl(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.Insert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("ResultDarcl");
            }
            return action;
        }

        [HttpPost]
        public ActionResult InsertDumptco(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.Insert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("Result");
            }
            return action;
        }
        public ActionResult InsertDarclDcr()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }

        [HttpPost]
        public ActionResult InsertDarclDcr(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.DumtcoDcrInsert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("ResultDarcl");
            }
            return action;
        }


        public ActionResult InsertDumptcoDcr()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }


        [HttpPost]
        public ActionResult InsertDumptcoDcr(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.DumtcoDcrInsert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("Result");
            }
            return action;
        }

        public ActionResult InsertEssential()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }
        [HttpPost]
        public ActionResult InsertEssential(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                //objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.DumtcoDcrInsert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("Result");
            }
            return action;
        }

        public ActionResult InsertMLPL()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }
        [HttpPost]
        public ActionResult InsertMLPL(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.DumtcoDcrInsert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("Result");
            }
            return action;
        }

        public ActionResult InsertHarshitha()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }
        [HttpPost]
        public ActionResult InsertHarshitha(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.DumtcoDcrInsert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("Result");
            }
            return action;
        }

        public ActionResult Insert()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            return base.View(masterDcrs);
        }

        [HttpPost]
        public ActionResult Insert(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.Insert(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("Result");
            }
            return action;
        }

        [HttpPost]
        public JsonResult IsBookCodeAvailable(byte documentTypeId, string bookCode)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.IsBookCodeAvailable(documentTypeId, bookCode));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsDocumentAvailableForVoid(byte documentTypeId, string documentNo)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.IsDocumentAvailableForVoid(documentTypeId, documentNo, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsDocumentNoExist(byte documentTypeId, string documentNo, short locationId)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.IsDocumentNoExist(documentTypeId, documentNo, locationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsDocumentNoDcrDumptcoExist(byte documentTypeId, string documentNo, short locationId)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.IsDocumentNoDcrDumptcoExist(documentTypeId, documentNo, SessionUtility.LoginLocationId, SessionUtility.CompanyId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsSeriesFromAvailable(byte documentTypeId, string seriesFrom, int totalLeaf)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.IsSeriesFromAvailable(documentTypeId, seriesFrom, totalLeaf));
            return jsonResult;
        }

        public ActionResult Manage()
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                Id = (long)0
            };
            this.Init();
            return base.View(masterDcr);
        }
        public ActionResult ManageDarcl()
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                Id = (long)0
            };
            this.Init();
            return base.View(masterDcr);
        }
        public ActionResult ManageDumptco()
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                Id = (long)0
            };
            this.Init();
            return base.View(masterDcr);
        }
        public ActionResult ManageResultDarcl()
        {
            return base.View();
        }

        public ActionResult ManageResult()
        {
            return base.View();
        }
        public ActionResult ReallocateDarcl(byte documentTypeId, string documentNo)
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                DocumentTypeId = documentTypeId,
                SeriesFrom = documentNo
            };
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return base.View(masterDcr);
        }

        [HttpPost]
        public ActionResult ReallocateDarcl(MasterDcr objMasterDcr)
        {
            ActionResult action;
            //objMasterDcr.CompanyId = SessionUtility.CompanyId;
            objMasterDcr.UpdateBy = new short?(SessionUtility.LoginUserId);
            if (!this.dcrRepository.Reallocate(objMasterDcr).IsSuccessfull)
            {
                action = base.View(objMasterDcr);
            }
            else
            {
                action = base.RedirectToAction("ManageResultDarcl", new { bookCode = objMasterDcr.BookCode, seriesFrom = objMasterDcr.SeriesFrom, seriesTo = objMasterDcr.SeriesTo, status = "Reallocate" });
            }
                ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return action;
        }
        public ActionResult ReallocateDumptco(byte documentTypeId, string documentNo)
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                DocumentTypeId = documentTypeId,
                SeriesFrom = documentNo
            };
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return base.View(masterDcr);
        }

        [HttpPost]
        public ActionResult ReallocateDumptco(MasterDcr objMasterDcr)
        {
            ActionResult action;
            //objMasterDcr.CompanyId = SessionUtility.CompanyId;
            objMasterDcr.UpdateBy = new short?(SessionUtility.LoginUserId);
            if (!this.dcrRepository.Reallocate(objMasterDcr).IsSuccessfull)
            {
                action = base.View(objMasterDcr);
            }
            else
            {
                action = base.RedirectToAction("ManageResult", new { bookCode = objMasterDcr.BookCode, seriesFrom = objMasterDcr.SeriesFrom, seriesTo = objMasterDcr.SeriesTo, status = "Reallocate" });
            }
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return action;
        }

        public ActionResult Reallocate(byte documentTypeId, string documentNo)
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                DocumentTypeId = documentTypeId,
                SeriesFrom = documentNo
            };
            return base.View(masterDcr);
        }

        [HttpPost]
        public ActionResult Reallocate(MasterDcr objMasterDcr)
        {
            ActionResult action;
            objMasterDcr.CompanyId = SessionUtility.CompanyId;
            objMasterDcr.UpdateBy = new short?(SessionUtility.LoginUserId);
            if (!this.dcrRepository.Reallocate(objMasterDcr).IsSuccessfull)
            {
                action = base.View(objMasterDcr);
            }
            else
            {
                action = base.RedirectToAction("ManageResult", new { bookCode = objMasterDcr.BookCode, seriesFrom = objMasterDcr.SeriesFrom, seriesTo = objMasterDcr.SeriesTo, status = "Reallocate" });
            }
            return action;
        }
        public ActionResult ResultDarcl()
        {
            ActionResult action;
            List<MasterDcr> item = base.TempData["DcrAddData"] as List<MasterDcr>;
            if (item == null)
            {
                action = base.RedirectToAction("Insert");
            }
            else
            {
                action = base.View(item);
            }
            return action;
        }
        public ActionResult Result()
        {
            ActionResult action;
            List<MasterDcr> item = base.TempData["DcrAddData"] as List<MasterDcr>;
            if (item == null)
            {
                action = base.RedirectToAction("Insert");
            }
            else
            {
                action = base.View(item);
            }
            return action;
        }

        public ActionResult Split(byte documentTypeId, string documentNo)
        {
            MasterDcr masterDcr = new MasterDcr()
            {
                DocumentTypeId = documentTypeId
            };
            ((dynamic)base.ViewBag).DCRSeriesFrom = documentNo;
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return base.View(masterDcr);
        }

        [HttpPost]
        public ActionResult Split(MasterDcr objMasterDcr)
        {
            ActionResult action;
            base.ModelState.Remove("DocumentNumber");
            if (base.ModelState.IsValid)
            {
                //objMasterDcr.CompanyId = SessionUtility.CompanyId;
                objMasterDcr.EntryBy = SessionUtility.LoginUserId;
                objMasterDcr.UpdateBy = new short?(SessionUtility.LoginUserId);
                objMasterDcr.AllotedDate = SessionUtility.Now;
                objMasterDcr.EntryDate = SessionUtility.Now;
                if (this.dcrRepository.Split(objMasterDcr).IsSuccessfull)
                {
                    action = base.RedirectToAction("ManageResult", new { bookCode = objMasterDcr.BookCode, seriesFrom = objMasterDcr.SeriesFrom, seriesTo = objMasterDcr.SeriesTo, status = "Split" });
                    return action;
                }
            }
            action = base.View(objMasterDcr);
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return action;
        }

        public ActionResult Track()
        {
            DcrTrack dcrTrack = new DcrTrack();
            this.Init();
            return base.View(dcrTrack);
        }

        public ActionResult InsertAFC()
        {
            List<MasterDcr> masterDcrs = new List<MasterDcr>()
            {
                new MasterDcr()
            };
            this.Init();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationAllList("ALL");
            return base.View(masterDcrs);
        }
        [HttpPost]
        public ActionResult InsertAFC(List<MasterDcr> objList)
        {
            ActionResult action;
            for (int i = 0; i < objList.Count; i++)
            {
                base.ModelState[string.Concat("[", i.ToString(), "].AllotedToName")].Errors.Clear();
                base.ModelState[string.Concat("[", i.ToString(), "].DocumentNumber")].Errors.Clear();
                objList[i].CompanyId = SessionUtility.CompanyId;
                objList[i].EntryBy = SessionUtility.LoginUserId;
            }
            if (!base.ModelState.IsValid)
            {
                this.Init();
                action = base.View(objList);
            }
            else
            {
                base.TempData["DcrAddData"] = this.dcrRepository.InsertAFC(objList).ToList<MasterDcr>();
                action = base.RedirectToAction("ResultAFC");
            }
            return action;
        }

        [HttpPost]
        public JsonResult IsSeriesFromAvailableAFC(byte documentTypeId, string seriesFrom, int totalLeaf)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.IsSeriesFromAvailableAFC(documentTypeId, seriesFrom, totalLeaf));
            return jsonResult;
        }

        public ActionResult ResultAFC()
        {
            ActionResult action;
            List<MasterDcr> item = base.TempData["DcrAddData"] as List<MasterDcr>;
            if (item == null)
            {
                action = base.RedirectToAction("Insert");
            }
            else
            {
                action = base.View(item);
            }
            return action;
        }

        public JsonResult GetDcrNoLength(byte documentTypeId)
        {
            JsonResult jsonResult = base.Json(this.dcrRepository.GetDcrNoLength(documentTypeId));
            return jsonResult;
        }

    }
}
