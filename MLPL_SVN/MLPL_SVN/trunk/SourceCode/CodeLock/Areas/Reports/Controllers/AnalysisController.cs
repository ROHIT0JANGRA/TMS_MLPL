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

        public AnalysisController()
        {
        }

        public AnalysisController(IOperationRepository operationRepository
            , ILocationRepository locationRepository, ICompanyRepository companyRepository
            , IGeneralRepository generalRepository
            ,ICustomerRepository _customerRepository)
        {
            this.operationRepository = new OperationRepository();
            this.generalRepository = new GeneralRepository();
            this.locationRepository = new LocationRepository();
            this.companyRepository = new CompanyRepository();
            this.routeRepository = new RouteRepository();
            this.customerRepository = _customerRepository;

        }



        //public ActionResult PrsReport()
        //{
        //    Prs prs = new Prs();
        //    ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
        //    ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();

        //    return base.View(prs);
        //}



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
            return base.View();
        }

        [HttpPost]
        public ActionResult GetPRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames)
        {
            var prsReports = this.operationRepository.GetPRSReport(fromDate, toDate, locationID,  companyId,  CheckedFieldNames);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DrsReport()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult GetDRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames)
        {
            var drsReports = this.operationRepository.GetDRSReports(fromDate, toDate, locationID, companyId, CheckedFieldNames);
            return Json(drsReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BookingReport()
        {
            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);

            ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;
            return base.View();
        }      
        [HttpPost]
        public ActionResult GetBookingReports(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames, int customerId)
        {
            var prsReports = this.operationRepository.GetBookingReports( fromDate,  toDate,  FromLocationID,  CompanyId,  ToLocationId,  CheckedFieldNames,customerId);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
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
        public ActionResult ManifiestReport()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult ManifiestReports(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var prsReports = this.operationRepository.GetManifiestReport(fromDate, toDate, level, levelType);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ThcReport()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult ThcReports(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var prsReports = this.operationRepository.GetThcReport(fromDate, toDate, level, levelType);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }
        public ActionResult THCDetailsReport()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult ThcDetailsReports(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var prsReports = this.operationRepository.GetThcDetailsReport(fromDate, toDate, level, levelType);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
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
            return base.View();
        }
        [HttpPost]
        public ActionResult UnloadingReports(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var prsReports = this.operationRepository.GetUnloadingReport(fromDate, toDate, level, levelType);
            return Json(prsReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PendingArrivals()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult PendingArrival(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var _arrivalReports = this.operationRepository.GeArrivalPendingReport(fromDate, toDate, level, levelType);
            return Json(_arrivalReports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult POD_Reports()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult POD_Report(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            var _podlReports = this.operationRepository.GetPODPendingReport(fromDate, toDate, level, levelType);
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
        //[HttpPost]
        //public ActionResult GetPRSReport(DateTime fromDate, DateTime toDate, short level, short levelType)
        //{
        //    var prsReports = this.operationRepository.GetPRSReports(fromDate, toDate, level, levelType);
        //    return Json(prsReports, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult GetPRSReports(Pagination pagination, DateTime fromDate, DateTime toDate)
        //{
        //    try
        //    {
        //        // Ensure pagination and its properties are not null
        //        if (pagination == null || pagination.Data == null || pagination.Data.columns == null || pagination.Data.order == null || pagination.Data.order.Count == 0)
        //        {
        //            throw new ArgumentException("Invalid pagination object.");
        //        }

        //        // Extracting the sorting column and direction from pagination data
        //        string sortingColumn = pagination.Data.columns[pagination.Data.order[0].column].name;
        //        string sortingDirection = pagination.Data.order[0].dir;
        //        string sorting = string.IsNullOrEmpty(sortingColumn) ? "PrsDate DESC" : $"{sortingColumn} {sortingDirection}";

        //        short level = 0; // Default value
        //        if (!string.IsNullOrEmpty(pagination.Data.search.level))
        //        {
        //            short.TryParse(pagination.Data.search.level, out level);
        //        }

        //        short levelType = 0; // Default value
        //        if (!string.IsNullOrEmpty(pagination.Data.search.levelType))
        //        {
        //            short.TryParse(pagination.Data.search.levelType, out levelType);
        //        }

        //        int pageNumber = pagination.Data.start / pagination.Data.length + 1;
        //        int pageSize = pagination.Data.length;

        //        // Fetching the PRS reports from the repository
        //        var prsReports = this.operationRepository.GetPRSReportsbyPagination(fromDate, toDate, level, levelType, pageNumber, pageSize);

        //        // Setting up the response object
        //        var dtResponse = new DTResponse
        //        {
        //            recordsTotal = prsReports.FirstOrDefault()?.recordsTotal ?? 0,
        //            recordsFiltered = prsReports.FirstOrDefault()?.recordsFiltered ?? 0,
        //            data = prsReports // Assuming prsReports is already in the required format
        //        };

        //        dtResponse.data = JsonConvert.SerializeObject(dtResponse);
        //        return Json(dtResponse, JsonRequestBehavior.AllowGet);

        //    }

        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine($"Error in GetPRSReports: {ex.Message}");

        //        // Set error message in response object
        //        ViewBag.Error = "An error occurred while processing the request: " + ex.Message;
        //        return Json(new { error = "An error occurred while processing the request." });
        //    }
        //}


        //[HttpPost]
        //public ActionResult GetPRSReports(Pagination pagination, DateTime? fromDate, DateTime? toDate)
        //{
        //    try
        //    {
        //        // Ensure pagination and its properties are not null
        //        if (pagination == null || pagination.Data == null || pagination.Data.columns == null || pagination.Data.order == null || pagination.Data.order.Count == 0)
        //        {
        //            throw new ArgumentException("Invalid pagination object.");
        //        }

        //        // Extracting the sorting column and direction from pagination data
        //        string sortingColumn = pagination.Data.columns[pagination.Data.order[0].column].name;
        //        string sortingDirection = pagination.Data.order[0].dir;
        //        string sorting = string.IsNullOrEmpty(sortingColumn) ? "PrsDate DESC" : $"{sortingColumn} {sortingDirection}";

        //        short level = 0; // Default value
        //        if (!string.IsNullOrEmpty(pagination.Data.search.level))
        //        {
        //            short.TryParse(pagination.Data.search.level, out level);
        //        }

        //        short levelType = 0; // Default value
        //        if (!string.IsNullOrEmpty(pagination.Data.search.levelType))
        //        {
        //            short.TryParse(pagination.Data.search.levelType, out levelType);
        //        }

        //        int pageNumber = pagination.Data.start / pagination.Data.length + 1;
        //        int pageSize = pagination.Data.length;

        //        // Fetching the PRS reports from the repository
        //        var prsReports = this.operationRepository.GetPRSReports(fromDate, toDate, level, levelType, pageNumber, pageSize);

        //        // Setting up the response object
        //        var dtResponse = new DTResponse
        //        {
        //            recordsTotal = prsReports.FirstOrDefault()?.recordsTotal ?? 0,
        //            recordsFiltered = prsReports.FirstOrDefault()?.recordsFiltered ?? 0,
        //            data = prsReports // Assuming prsReports is already in the required format
        //        };

        //        return Json(dtResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine($"Error in GetPRSReports: {ex.Message}");

        //        // Set error message in response object
        //        ViewBag.Error = "An error occurred while processing the request: " + ex.Message;
        //        return Json(new { error = "An error occurred while processing the request." });
        //    }
        //}




        //[HttpPost]
        //public ActionResult GetPRSReports(Pagination pagination, DateTime? fromDate, DateTime? toDate)
        //{
        //    try
        //    {
        //        // Extracting the sorting column and direction from pagination data
        //        string sortingColumn = pagination.data.columns[pagination.data.order[0].column].name;
        //        string sortingDirection = pagination.data.order[0].dir;
        //        string sorting = string.IsNullOrEmpty(sortingColumn) ? "PrsDate DESC" : $"{sortingColumn} {sortingDirection}";

        //        short level = 0; // Default value
        //        if (!string.IsNullOrEmpty(pagination.data.search.level))
        //        {
        //            short.TryParse(pagination.data.search.level, out level);
        //        }

        //        short levelType = 0; // Default value
        //        if (!string.IsNullOrEmpty(pagination.data.search.levelType))
        //        {
        //            short.TryParse(pagination.data.search.levelType, out levelType);
        //        }

        //        int pageNumber = pagination.data.start / pagination.data.length + 1;
        //        int pageSize = pagination.data.length;

        //        // Fetching the PRS reports from the repository
        //        var prsReports = this.operationRepository.GetPRSReports(fromDate, toDate, level, levelType, pageNumber, pageSize);

        //        // Setting up the response object
        //        var dtResponse = new DTResponse
        //        {
        //            recordsTotal = prsReports.FirstOrDefault()?.recordsTotal ?? 0,
        //            recordsFiltered = prsReports.FirstOrDefault()?.recordsFiltered ?? 0,
        //            data = prsReports // Assuming prsReports is already in the required format
        //        };

        //        return Json(dtResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine($"Error in GetPRSReports: {ex.Message}");

        //        // Set error message in response object
        //        ViewBag.Error = "An error occurred while processing the request.";
        //        return Json(new { error = "An error occurred while processing the request." });
        //    }
        //}








        //public JsonResult PrsReport(Pagination pagination)
        //{


        //    // Call the repository method
        //    var products = operationRepository.PrsReport(
        //         pagination.data.fromDate,
        //        pagination.data.toDate,
        //        pagination.data.level,
        //        pagination.data.levelType,
        //        pagination.data.start / pagination.data.length + 1,
        //        pagination.data.length
        //    );

        //    // Prepare the response
        //    DTResponse dtResponse = new DTResponse
        //    {
        //        recordsTotal = products.FirstOrDefault()?.recordsTotal ?? 0,
        //        recordsFiltered = products.FirstOrDefault()?.recordsFiltered ?? 0, // Assuming no additional filtering applied here
        //        data = JsonConvert.SerializeObject(products)
        //    };

        //    return Json(dtResponse, JsonRequestBehavior.AllowGet);
        //}
    }
    }
