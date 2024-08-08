using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Areas.Reports.Repository;
using CodeLock.Models;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Reports.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IOperationRepository operationRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IRouteRepository routeRepository;
        private readonly IPrsRepository prsRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IAnalysisRepository analysisRepository;

        public AnalysisController()
        {
        }

        public AnalysisController(IOperationRepository operationRepository
            , ILocationRepository locationRepository, ICompanyRepository companyRepository
            , IGeneralRepository generalRepository
            ,ICustomerRepository _customerRepository, IAnalysisRepository _analysisRepository)
        {
            this.operationRepository = new OperationRepository();
            this.generalRepository = new GeneralRepository();
            this.locationRepository = new LocationRepository();
            this.companyRepository = new CompanyRepository();
            this.routeRepository = new RouteRepository();
            this.customerRepository = _customerRepository;
            this.analysisRepository = _analysisRepository;

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.operationRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult PrsReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("PRSReport");
            // Convert IEnumerable<AdvanceFilterColumn> to List<AdvanceFilterColumn>
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            // Create and populate the PRSReport object
            PRSReport objPrs = new PRSReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };           
            return View(objPrs);
        }
       
        [HttpPost]
        public ActionResult GetPRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames,List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if(AdvanceFilterColumnsList!=null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var prsReports = this.operationRepository.GetPRSReport(fromDate, toDate, locationID,  companyId,  CheckedFieldNames, AdvanceFilterColumnsList);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DrsReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("DRSReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            DRSReportModel objDRS = new DRSReportModel
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return base.View(objDRS);
        }

        [HttpPost]
        public ActionResult GetDRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var prsReports = this.operationRepository.GetDRSReports(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BookingReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("BookingReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            BookingReport objBookingReport = new BookingReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);

            ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;
            return base.View(objBookingReport);
        }      
        [HttpPost]
        public ActionResult GetBookingReports(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames, int customerId, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var bookingReport = this.operationRepository.GetBookingReports( fromDate,  toDate,  FromLocationID,  CompanyId,  ToLocationId,  CheckedFieldNames,customerId, AdvanceFilterColumnsList);
            return Json(bookingReport, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BookingDetailsReport()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult BookingDetailsReports(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var prsReports = this.operationRepository.GetBookingDetailsReport(fromDate, toDate, level, levelType);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InvoiceBookingReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("BookingReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            BookingReport objBookingReport = new BookingReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);

            ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;
            return base.View(objBookingReport);
        }
        public ActionResult GetInvoiceBookingReport(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames, int customerId, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var bookingReport = this.operationRepository.GetInvoiceBookingReport(fromDate, toDate, FromLocationID, CompanyId, ToLocationId, CheckedFieldNames, customerId, AdvanceFilterColumnsList);
            return Json(bookingReport, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ManifiestReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("ManifestReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            ManifestReport objManifest = new ManifestReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return View(objManifest);
        }
        [HttpPost]
        public ActionResult GetManifiestReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var manifestReport = this.operationRepository.GetManifestReport(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList);
            return Json(manifestReport, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ThcReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("THCReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            THCReport objTHCReport = new THCReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return View(objTHCReport);
        }
        [HttpPost]
        public ActionResult GetThcReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var thcReports = this.operationRepository.GetThcReport(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList);            
            return Json(thcReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult THCDetailsReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("THCReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            THCReport objTHCReport = new THCReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return View(objTHCReport);
        }
        [HttpPost]
        public ActionResult GetTHCDetailsReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var thcReports = this.operationRepository.GetTHCDetailsReports(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList);
            return Json(thcReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExpenseRegisterReport()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult GetExpenseRegisterReports(DateTime fromDate, DateTime toDate, string DocumentNos, string ManualDocumentNos, string DocumentTypes)
        {
            var _ExpenseRegister = this.operationRepository.GetExpenseRegisterReport(fromDate, toDate, DocumentNos, ManualDocumentNos, DocumentTypes);
            return Json(_ExpenseRegister, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UnloadingReport()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("UnloadingReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            UnloadingReportModel objUnloading = new UnloadingReportModel
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return View(objUnloading);
        }
        [HttpPost]
        public ActionResult UnloadingReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                AdvanceFilterColumnsList = AdvanceFilterColumnsList.Where(m => m.SearchingColumnValue != "" || m.SearchingColumnValue != null).ToList();
            }
            var thcReports = this.operationRepository.GetUnloadingReport(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList);
            return Json(thcReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingArrivals()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("PendingArrivalReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            ArrivalReport objArrivalReport = new ArrivalReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return View(objArrivalReport);
        }
        [HttpPost]
        public ActionResult PendingArrival(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            var _arrivalReports = this.operationRepository.GeArrivalPendingReport(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList);
            return Json(_arrivalReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult POD_Reports()
        {
            IEnumerable<AdvanceFilterColumns> AdvanceFilterColumnList = this.analysisRepository.GetAdvanceSearchingColumnList("PODPendingReport");
            List<AdvanceFilterColumns> advanceFilterColumnsList = AdvanceFilterColumnList.ToList();
            PODPendingReport objPODPending = new PODPendingReport
            {
                AdvanceFilterColumnList = advanceFilterColumnsList
            };
            return View(objPODPending);
        }

        [HttpPost]
        public ActionResult POD_Report(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            var _podlReports = this.operationRepository.GetPODPendingReport(fromDate, toDate, locationID, companyId, CheckedFieldNames, AdvanceFilterColumnsList); ;
            return Json(_podlReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BillGenerateReport()
        {
            return base.View();
        }
        /*  ##########################################################################################    -------    Finance Analysis -------------  ########################################################################  */
        [HttpPost]
        public ActionResult BillGenerateReports(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType)
        {
            var _podlReports = this.operationRepository.GetBillGenarte(fromDate, toDate, level, levelType, Customer, BillType);
            try
            {
                if (_podlReports == null)
                {
                    return ViewBag.Error = "Data Not Found & Not Connected";
                }
                else
                {
                    return Json(_podlReports, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();

        }

        public ActionResult GetBillSubmissionGenerateReport()
        {
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return base.View();
        }

        [HttpPost]
        public ActionResult GetBillSubmissionGenerateReporturl(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType)
        {
            var _podlReports = this.operationRepository.GetBillSubmissionGenerate(fromDate, toDate, level, levelType, Customer, BillType);
            try
            {
                if (_podlReports == null)
                {
                    return ViewBag.Error = "Data Not Found & Not Connected";
                }
                else
                {
                    return Json(_podlReports, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();

        }

        /*  ##########################################################################################    -------    Finance Analysis -------------  ########################################################################  */


        public ActionResult TripSheetReport()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult GetTripStartReports(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames)
        {
            var _podlReports = this.operationRepository.GetTripStartReport(fromDate, toDate, FromLocationID, CompanyId, ToLocationId, CheckedFieldNames);
            {
                try
                {
                    if (_podlReports == null)
                    {
                        return ViewBag.Error = "Data Not Found & Not Connected";
                    }
                    else
                    {
                        return Json(_podlReports, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
                return View();

            }

        }
        public JsonResult GetColumnListByReportId(byte reportId)
        {
            JsonResult jsonResult = base.Json(this.operationRepository.GetColumnListByReportId(reportId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
        public JsonResult GetColumnListByReport(string FormName)
        {
            JsonResult jsonResult = base.Json(this.operationRepository.GetColumnListByReport(FormName), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
        public JsonResult GetSearchingCheckedField(string formName)
        {
            JsonResult jsonResult = base.Json(this.operationRepository.GetSearchingCheckedField(formName), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
    }
    }
