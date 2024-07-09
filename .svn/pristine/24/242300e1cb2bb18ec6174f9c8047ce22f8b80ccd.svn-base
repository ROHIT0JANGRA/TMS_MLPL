using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Drawing;
using BarcodeLib;
using System.Drawing.Imaging;
using Microsoft.Reporting.WebForms;
using CodeLock.Helper;
using CodeLock.Repository;
using System.Threading.Tasks;
using System.Web.Helpers;
using Google.Apis.Auth.OAuth2;
using System.Net.Http;
using System.Text;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Apis.Util;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using DocumentFormat.OpenXml.Bibliography;
using Excel.Log;
using DocumentFormat.OpenXml.Office2010.Word;
using iTextSharp.text.pdf.qrcode;
using System.Diagnostics;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace CodeLock.Areas.Operation.Controllers
{
    public class DocketController : Controller
    {
        private readonly IDocketRepository docketRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IRulesRepository rulesRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IVendorRepository vendorRepository;
        private readonly IUserRepository userRepository;
        private readonly IHomeRepository homeRepository;
        private readonly IZoneRepository zoneRepository;
        private readonly ITrackingRepository trackingRepository;

        public DocketController()
        {

        }

        public DocketController(IDocketRepository _docketRepository, IGeneralRepository _generalRepository,
            IRulesRepository _rulesRepository, ILocationRepository _locationRepository,
            ICustomerRepository _customerRepository, IVendorRepository _vendorRepository,
            IUserRepository _userRepository, IHomeRepository _homeRepository, IZoneRepository _zoneRepository, ITrackingRepository _trackingRepository)
        {
            this.docketRepository = _docketRepository;
            this.generalRepository = _generalRepository;
            this.rulesRepository = _rulesRepository;
            this.locationRepository = _locationRepository;
            this.customerRepository = _customerRepository;
            this.vendorRepository = _vendorRepository;
            this.userRepository = _userRepository;
            this.homeRepository = _homeRepository;
            this.zoneRepository = _zoneRepository;
            this.trackingRepository = _trackingRepository;
        }

        public ActionResult ViewDocketAdityaBirla(string tripsheetsumid)
        {
            return (ActionResult)this.View((object)this.docketRepository.GetAdityaBirlaTripsheetById(tripsheetsumid));
        }

        public JsonResult GenerateDocketAdityaBirlaById(string tripsheetsumid)
        {
            return CreateDocketAdityaBirlaById(tripsheetsumid);
        }

        public JsonResult GenerateBulkDocketAdityaBirlaById(string tripsheetno)
        {
            JsonResult jsonResult   = new JsonResult();

            IEnumerable<TripsheetForAdityaBirlaSummary>  objMain = this.docketRepository.GetAdityaBirlaTripsheet(tripsheetno);

            foreach(var item in objMain)
            {
                jsonResult = CreateDocketAdityaBirlaById(item.tripsheetsumid);
            }

            return jsonResult; 
        }


        private JsonResult CreateDocketAdityaBirlaById(string tripsheetsumid)
        {
            PickUpDetailRequest request = new PickUpDetailRequest();
            ResponseResult responseResult = new ResponseResult();
            TripsheetForAdityaBirlaMain main = this.docketRepository.GetAdityaBirlaTripsheetById(tripsheetsumid);
            List<ApiPickUpDetail> PickUpDetails = new List<ApiPickUpDetail>();
            ApiPickUpDetail apiPickUpDetail = new ApiPickUpDetail();

            string MobileNo = ""; string address = ""; string fromCity = ""; string toCity = "";
            string toPinNo = "";

            try
            {
                foreach (var item in main.TripsheetList)
                {
                    MobileNo = item.shroomphone;
                    address = item.shroomaddress1 + item.shroomaddress2;
                    fromCity = item.fromcity;
                    toCity  =item.shroomcity;
                    toPinNo = item.shroompin;
                    break;
                }

                if (main.SummaryList.Count>0)
                {
                    apiPickUpDetail.DocketNo = main.SummaryList[0].lrno;
                    string[] dates = main.SummaryList[0].tripsheetdate.Split('/');
                    string dt = dates[2]+"/"+ dates[1]+"/"+dates[0];
                    apiPickUpDetail.DocketDate = Convert.ToDateTime(dt);
                    
                    if(!string.IsNullOrEmpty(main.EWBNList[0].docno))
                        apiPickUpDetail.RefNo = main.EWBNList[0].docno;
                    else
                        apiPickUpDetail.RefNo = "1";

                    apiPickUpDetail.ContactPersonName = "--";

                    if (string.IsNullOrEmpty(MobileNo))
                    {
                        MobileNo="0000000000";
                    }

                    if (string.IsNullOrEmpty(fromCity))
                    {
                        fromCity="BANGALORE";
                    }

                    if (string.IsNullOrEmpty(toCity))
                    {
                        toCity="BANGALORE";
                    }
                    apiPickUpDetail.MobileNo = MobileNo;
                    apiPickUpDetail.TelephoneNo = MobileNo;
                    apiPickUpDetail.ConsignorName = "ADITYA BIRLA FASHION AND REATIL LTD";
                    apiPickUpDetail.ConsignorAddress = "KH NO 118/110/1 BUILDING 2, DIVYASREE TECHNOPOLIS YAMALUR POST";
                    apiPickUpDetail.ConsignorCity = fromCity;
                    apiPickUpDetail.ConsignorPin = "560037";
                    apiPickUpDetail.ConsigneeName = main.SummaryList[0].custname;
                    apiPickUpDetail.ConsigneeAddress = address;
                    apiPickUpDetail.ConsigneeCity = toCity;
                    apiPickUpDetail.ConsigneePin = toPinNo;

                    apiPickUpDetail.Origin = main.SummaryList[0].branch_code;
                    apiPickUpDetail.Destination = main.SummaryList[0].branch_code;
                    apiPickUpDetail.TransportMode = "ROAD";

                    if (main.SummaryList[0].weight == 0)
                        apiPickUpDetail.ShipmentWeight = 1;
                    else
                        apiPickUpDetail.ShipmentWeight = main.SummaryList[0].weight;


                    apiPickUpDetail.NoOfCartons = main.TripsheetList.Count;
                    apiPickUpDetail.ProductDescription = "Sports Goods";

                    if (main.SummaryList[0].invoicevalue ==0)
                        apiPickUpDetail.ProductValue = 1;
                    else
                        apiPickUpDetail.ProductValue = main.SummaryList[0].invoicevalue;

                    List<DocketInvoice> InvoiceDetails = new List<DocketInvoice>();
                    DocketInvoice docketInvoice = new DocketInvoice();


                    if(main.EWBNList[0].invoiceno != null)
                    {
                        docketInvoice.InvoiceNo = main.EWBNList[0].invoiceno;
                    }
                    else
                    {
                        docketInvoice.InvoiceNo="INV-1";
                    }

                    if(main.EWBNList[0].invoicedate != null)
                    {
                        string[] INdates = main.EWBNList[0].invoicedate.Split('/');
                        string INdt = dates[2]+"/"+ dates[1]+"/"+dates[0];
                        docketInvoice.InvoiceDate =Convert.ToDateTime(INdt);
                    }
                    else
                    {
                        docketInvoice.InvoiceDate =Convert.ToDateTime(dt);
                    }

                    if (main.EWBNList[0].invoicevalue != null)
                    {
                        docketInvoice.InvoiceAmount = main.EWBNList[0].invoicevalue;
                    }
                    else
                    {
                        docketInvoice.InvoiceAmount = 1;
                    }

                    docketInvoice.ActualWeight = main.SummaryList[0].weight;
                    docketInvoice.ChargedWeight = main.SummaryList[0].weight;
                    docketInvoice.EwayBill =main.EWBNList[0].ewaybillno;
                    docketInvoice.Height = 0;
                    docketInvoice.Length = 0;
                    docketInvoice.Breadth = 0;
                    docketInvoice.Packages = main.TripsheetList.Count.ConvertToShort();
                    InvoiceDetails.Add(docketInvoice);
                    apiPickUpDetail.InvoiceDetails = InvoiceDetails;

                    List<BoxDetail> BoxDetails = new List<BoxDetail>();
                    BoxDetail boxDetail = new BoxDetail();
                    boxDetail.Pkgs = main.TripsheetList.Count.ConvertToShort();
                    boxDetail.Length = 0;
                    boxDetail.Breadth = 0;
                    boxDetail.Height = 0;
                    BoxDetails.Add(boxDetail);
                    apiPickUpDetail.BoxDetails  = BoxDetails;

                    // Carton 

                    List<DocketInvoiceCarton> docketInvoiceCartons = new List<DocketInvoiceCarton>();
                    foreach (var item in main.TripsheetList)
                    {
                        DocketInvoiceCarton docketInvoiceCarton = new DocketInvoiceCarton();
                        docketInvoiceCarton.TripsheetNo = item.tripsheetno;
                        docketInvoiceCarton.CartonNo = item.cartonno;
                        docketInvoiceCartons.Add(docketInvoiceCarton);

                    }
                    apiPickUpDetail.DocketInvoiceCartons  = docketInvoiceCartons;


                    PickUpDetails.Add(apiPickUpDetail);
                    request.PickUpDetails = PickUpDetails;
                    request.UserName =SessionUtility.LoginUserName;
                    responseResult = docketRepository.ApiOrderUploadAdityaBirlaEssential(request);
                }

                foreach (var item in responseResult.BookingDetail)
                {

                    if (item.Status.Contains("Data Saved Successfully"))
                    {

                        docketRepository.UpdayeAdityaBirlaTripsheetById(tripsheetsumid);
                        item.StatusCode="OK";
                    }
                    else
                    {
                        item.StatusCode="NOT OK";
                    }
                }

            }
            catch (Exception ex)
            {
                if (responseResult.BookingDetail.Count == 0)
                {
                    ApiDocketNewResponse apiDocketNewResponse = new ApiDocketNewResponse();
                    apiDocketNewResponse.Status = ex.Message;
                    apiDocketNewResponse.StatusCode = "NOT OK";
                }
                foreach (var item in responseResult.BookingDetail)
                {
                    item.Status = ex.Message;
                    item.StatusCode = "NOT OK";
                }
            }

            JsonResult jsonResult = base.Json(responseResult);
            return jsonResult;
        }

        public ActionResult GenerateDocketAdityaBirla(string tripsheetno)
        {
            return (ActionResult)this.View((object)this.docketRepository.GetAdityaBirlaTripsheet(tripsheetno));
        }
        public ActionResult GenerateDocketAdityaBirlaForTripsheet()
        {
            return (ActionResult)this.View((object)this.docketRepository.GetAdityaBirlaTripsheetBulk(SessionUtility.LoginUserId.ToString()));
        }


        [HttpPost]
        public JsonResult GetStep6DetailForReinvoke(string DocketId)
        {
            Docket obj = new Docket();
            obj.IsSuccessfull = false;

            Response response = this.docketRepository.GetStep6DetailForReinvoke(DocketId);

            if (response.IsSuccessfull == true)
            {
                obj = this.docketRepository.GetStep6DetailByIdByChangeAmount(DocketId.ConvertToLong());
                obj.IsSuccessfull = true;
            }

            return base.Json(obj);
        }

        public ActionResult CustomerDocketPopup(string DocketId)
        {
            return base.View(this.docketRepository.GetDocketChargeList(DocketId));
        }

        [HttpPost]
        public JsonResult GetDocketListForRecalculate(byte companyId, short locationId, string docketList, DateTime fromDate, DateTime toDate,
            byte transportModeId, int fromCityId, int toCityId, string toLocationList, string zoneList, long CustomerId, string PickupList)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetDocketListForRecalculate(companyId, locationId, docketList, fromDate, toDate,
                transportModeId, fromCityId, toCityId, toLocationList, zoneList, CustomerId, PickupList), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetRecalculate(string docketList)
        {
            string[] docketsplit = docketList.Split(',');

            DocketSearch obj = new DocketSearch();

            for (int item = 0; item < docketsplit.Length; item++)
            {
                DocketSearchDetail detail = new DocketSearchDetail();
                detail.DocketId = docketsplit[item];
                detail.EntryBy = SessionUtility.LoginUserId;
                obj.DocketList.Add(detail);
            }

            JsonResult jsonResult = base.Json(this.docketRepository.GetRecalculate(obj), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult DocketRecalculate()
        {
            LoadingSheet loadingSheet = new LoadingSheet();
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).ZoneList = this.zoneRepository.GetZoneList();
            return base.View(loadingSheet);
        }


        [HttpPost]
        public ActionResult InsertRCM(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDumptcoDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }
        public ActionResult InsertRCM(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }
        public ActionResult InsertRCMDone()
        {
            return base.View();
        }

        public ActionResult UpdateRCM()
        {
            return base.View();
        }
        public ActionResult UpdateScan()
        {
            return base.View();
        }


        public ActionResult _DocketFinanceVerification(long? docketId, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();
            ((dynamic)base.ViewBag).DocketId = docketId;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            if (!docketId.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;
            }
            else
            {
                docket.DocketId = docketId.Value;
            }
            return base.View(docket);
        }
        [HttpGet]
        public FileResult DownloadFile(string filename)
        {
            string contenttype = "image/jpeg";
            string fileExtension = Path.GetExtension(filename);

            if (fileExtension == ".png")
            {
                contenttype = "image/png";
            }
            if (fileExtension == ".gif")
            {
                contenttype = "image/gif";
            }
            if (fileExtension == ".jpe" || fileExtension == ".jpeg" || fileExtension == ".jpg")
            {
                contenttype = "image/jpeg";
            }
            if (fileExtension == ".bmp")
            {
                contenttype = "image/bmp";
            }

            string fullpath = Path.Combine(Server.MapPath("~/Storage/POD/"), filename);

            return File(fullpath, contenttype);
        }

        public ActionResult DocketStatus(string DocketId)
        {
            CodeLock.Models.DocketStatus objStatus = new Models.DocketStatus();
            objStatus.StatusDate = DateTime.Now;

            objStatus = this.docketRepository.DocketStatusGetById(DocketId);
            ((dynamic)base.ViewBag).StatusList = this.docketRepository.DocketStatusList(DocketId);

            return base.View(objStatus);
        }
        public ActionResult DocketStatusCustomerList()
        {
            ((dynamic)base.ViewBag).CustomerId = "";
            ((dynamic)base.ViewBag).Fromdate = "Hi";
            ((dynamic)base.ViewBag).ToDate = "13-07-2020";

            int rIndex;
            string CustomerId;

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
                ((dynamic)base.ViewBag).CustomerId = CustomerId;
            }

            return base.View(this.docketRepository.DocketStatusGetAll("", "", "", "No"));
        }

        [HttpPost]
        public ActionResult DocketStatusCustomerList(string CustomerId, string Fromdate, string ToDate)
        {
            Session["CustomerSearchId"] = CustomerId;
            Session["FromDateSearchId"] = Fromdate;
            Session["ToDateSearchId"] = ToDate;
            ((dynamic)base.ViewBag).CustomerId = Session["CustomerSearchId"].ToString();
            ((dynamic)base.ViewBag).Fromdate = Fromdate;
            ((dynamic)base.ViewBag).ToDate = ToDate;

            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);
            ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;

            return base.View(this.docketRepository.DocketStatusGetAll(CustomerId, Fromdate, ToDate, "Yes"));
        }
        public ActionResult DocketStatusList()
        {
            ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerListAssignUserwise(SessionUtility.LoginUserId);
            ((dynamic)base.ViewBag).CustomerId = "";
            ((dynamic)base.ViewBag).Fromdate = "";
            ((dynamic)base.ViewBag).ToDate = "";

            return base.View(this.docketRepository.DocketStatusGetAll("", "", "", "No"));
        }

        [HttpPost]
        public ActionResult DocketStatusList(string CustomerId, string Fromdate, string ToDate)
        {
            ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerListAssignUserwise(SessionUtility.LoginUserId);
            Session["CustomerSearchId"] = CustomerId;
            Session["FromDateSearchId"] = Fromdate;
            Session["ToDateSearchId"] = ToDate;
            ((dynamic)base.ViewBag).CustomerId = Session["CustomerSearchId"].ToString();
            ((dynamic)base.ViewBag).Fromdate = Session["FromDateSearchId"].ToString();
            ((dynamic)base.ViewBag).ToDate = Session["ToDateSearchId"].ToString();

            return base.View(this.docketRepository.DocketStatusGetAll(CustomerId, Fromdate, ToDate, "Yes"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DocketStatus(CodeLock.Models.DocketStatus objDetail, HttpPostedFileBase file)
        {

            string Extension = "", FileLoc = "";

            objDetail.CompanyId = SessionUtility.CompanyId;
            objDetail.WarehouseId = SessionUtility.WarehouseId;
            objDetail.EntryBy = SessionUtility.LoginUserId;
            objDetail.EntryDate = DateTime.Now;

            if (file != null)
            {
                FileLoc = Server.MapPath("~/Storage/POD/");
                Extension = Path.GetExtension(file.FileName);
                objDetail.Extension = Extension;
            }
            else
            {
                objDetail.Extension = "";
            }

            Response response = this.docketRepository.InsertDocketStatus(objDetail);
            if (response.IsSuccessfull)
            {
                if (file != null)
                {
                    if (System.IO.Directory.Exists(FileLoc)) { }
                    else
                    {
                        System.IO.Directory.CreateDirectory(FileLoc);
                    }

                    FileLoc = FileLoc + response.DocumentId.ToString() + Extension;
                    file.SaveAs(FileLoc);
                }
            }
            string CustomerId, Fromdate, ToDate;

            if (Session["CustomerSearchId"] == null)
            {
                CustomerId = "";
                Fromdate = "";
                ToDate = "";
                ((dynamic)base.ViewBag).CustomerId = "";
                ((dynamic)base.ViewBag).Fromdate = "";
                ((dynamic)base.ViewBag).ToDate = "";
            }
            else
            {
                CustomerId = Session["CustomerSearchId"].ToString();
                Fromdate = Session["FromDateSearchId"].ToString();
                ToDate = Session["ToDateSearchId"].ToString();

                ((dynamic)base.ViewBag).CustomerId = Session["CustomerSearchId"].ToString();
                ((dynamic)base.ViewBag).Fromdate = Session["FromDateSearchId"].ToString();
                ((dynamic)base.ViewBag).ToDate = Session["ToDateSearchId"].ToString();
            }
             ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);


            return base.View("DocketStatusList", this.docketRepository.DocketStatusGetAll(CustomerId, Fromdate, ToDate, "No"));
        }


        public ActionResult Cancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancellation(DocketCancellation objDocketCancellation)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objDocketCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objDocketCancellation.LocationId = SessionUtility.LoginLocationId;
                objDocketCancellation.Details.RemoveAll((DocketCancellationDetails m) => !m.IsChecked);
                if (this.docketRepository.Cancellation(objDocketCancellation).IsSuccessfull)
                {
                    action = base.RedirectToAction("CancellationDone", new { status = "DocketCancel" });
                    return action;
                }
            }
            action = base.View(objDocketCancellation);
            return action;
        }

        public ActionResult CancellationDone()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult CheckManifestStatusAndUnderDrsForUpdate(long docketId)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckManifestStatusAndUnderDrsForUpdate(docketId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckValidDocketForHold(short docketId)
        {
            return base.Json(this.docketRepository.CheckValidDocketForHold(docketId));
        }

        [HttpPost]
        public JsonResult CheckValidDocketNo(string docketNo)
        {
            return base.Json(this.docketRepository.CheckValidDocketNo(docketNo));
        }

        [HttpPost]
        public JsonResult CheckValidDocketNoForDacc(string docketNo)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidDocketNoForDacc(docketNo));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckValidDocketNoForReAssign(string docketNo)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidDocketNoForReAssign(docketNo));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckValidDocketNoForUpdate(string docketNo, bool isFinancialUpdate, string searchType)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidDocketNoForUpdate(docketNo, isFinancialUpdate, searchType));
            return jsonResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.docketRepository.Dispose();
                this.generalRepository.Dispose();
                this.rulesRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DocketBookingChallan()
        {
            DocketBookingChallan docketBookingChallan = new DocketBookingChallan()
            {
                Details = new List<DocketBookingChallanDetail>()
            };
            List<DocketBookingChallanDetail> details = docketBookingChallan.Details;
            DocketBookingChallanDetail docketBookingChallanDetail = new DocketBookingChallanDetail()
            {
                DocketId = (long)0,
                DocketNo = "",
                DocketDate = SessionUtility.Now,
                PaybasId = 0,
                FromCity = "",
                FromCityId = 0,
                ToCity = "",
                ToCityId = 0,
                ConsignorName = "",
                ConsigneeName = "",
                Packages = 0,
                ActualWeight = new decimal(0),
                ChargeWeight = new decimal(0),
                DocketTotal = new decimal(0),
                IsBulky = false,
                Freight = new decimal(0),
                OtherCharges = new decimal(0),
                GrandTotal = new decimal(0)
            };
            details.Add(docketBookingChallanDetail);
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            return base.View(docketBookingChallan);
        }

        [HttpPost]
        [ValidateAntiModelInjection("ChallanId")]
        public ActionResult DocketBookingChallan(DocketBookingChallan objDocketBookingChallan)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objDocketBookingChallan.EntryBy = SessionUtility.LoginUserId;
                objDocketBookingChallan.UpdateBy = new short?(SessionUtility.LoginUserId);
                objDocketBookingChallan.LocationId = SessionUtility.LoginLocationId;
                objDocketBookingChallan.CompanyId = SessionUtility.CompanyId;
                Response response = this.docketRepository.DocketBookingChallanInsert(objDocketBookingChallan);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
                base.TempData["result"] = response;
            }
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            action = base.View(objDocketBookingChallan);
            return action;
        }

        public ActionResult DocketReAssignDone()
        {
            return base.View();
        }

        public ActionResult DocketReAssign()
        {
            DocketReAssign docketDacc = new DocketReAssign();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationListOnlyBranch();

            return base.View(docketDacc);
        }

        [HttpPost]
        public ActionResult DocketReAssign(DocketReAssign objDocketDacc)
        {
            objDocketDacc.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            response = this.docketRepository.InsertDocketReAssign(objDocketDacc);

            if (response.IsSuccessfull)
            {
                return base.RedirectToAction("DocketReAssignDone");
            }

            return base.View();
        }

        public ActionResult DocketDacc(string docketNo)
        {
            DocketDacc docketDacc = new DocketDacc()
            {
                DocketNo = docketNo.ConvertToString()
            };
            return base.View(docketDacc);
        }

        [HttpPost]
        public ActionResult DocketDacc(DocketDacc objDocketDacc)
        {
            objDocketDacc.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            response = this.docketRepository.DocketDaccInsert(objDocketDacc);
            return base.RedirectToAction("DocketDaccDone");
        }

        public ActionResult DocketDaccDone()
        {
            return base.View();
        }

        public ActionResult DocketHold(string docketNo)
        {
            DocketHold docketHold = new DocketHold()
            {
                DocketNo = docketNo.ConvertToString()
            };
            return base.View(docketHold);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DocketHold(DocketHold objDocketHold)
        {
            objDocketHold.HoldBy = SessionUtility.LoginUserId;
            objDocketHold.HoldLocationId = SessionUtility.LoginLocationId;
            Response response = new Response();
            response = this.docketRepository.DocketHold(objDocketHold);
            ActionResult action = base.RedirectToAction("DocketHoldDone", new { status = "DocketHold" });
            return action;
        }

        public ActionResult DocketHoldDone()
        {
            return base.View();
        }

        public ActionResult DocketHoldIndex()
        {
            return base.View(this.docketRepository.GetDocketHoldAll());
        }

        public ActionResult DocketTalk(string docketNo)
        {
            DocketTalk docketTalk = new DocketTalk()
            {
                DocketNo = docketNo.ConvertToString()
            };
            return base.View(docketTalk);
        }

        [HttpPost]
        public ActionResult DocketTalk(DocketTalk objDocketTalk)
        {
            objDocketTalk.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            if (objDocketTalk.DocumentAttachment != null)
            {
                string fileName = "";
                if (!ConfigHelper.IsLocalStorage)
                {
                    string str = objDocketTalk.DocketNo.ToString();
                    DateTime now = DateTime.Now;
                    fileName = AzureStorageHelper.GetFileName("DocketTalk", "DOC_TYPE", str, now.ToString(), objDocketTalk.DocumentAttachment.FileName);
                    AzureStorageHelper.UploadBlob("DocketTalk", objDocketTalk.DocumentAttachment, fileName, fileName);
                }
                else
                {
                    fileName = string.Concat(Convert.ToString(objDocketTalk.DocketId), "_", objDocketTalk.DocumentAttachment.FileName);
                    string str1 = string.Concat(ConfigHelper.LocalStoragePath, "DocketTalk/", fileName);
                    objDocketTalk.DocumentAttachment.SaveAs(str1);
                }
                objDocketTalk.DocumentName = fileName;
                objDocketTalk.DocumentAttachment = null;
            }
            response = this.docketRepository.DocketTalkInsert(objDocketTalk);
            return base.View(objDocketTalk);
        }

        public ActionResult DocketUnhold(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            (new DocketHold()).HoldId = (long)id.ConvertToShort();
            short? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                httpStatusCodeResult = base.View(this.docketRepository.GetDocketUnHoldData((long)id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("HoldId")]
        public ActionResult DocketUnhold(DocketHold objDocketHold)
        {
            objDocketHold.UnholdBy = SessionUtility.LoginUserId;
            objDocketHold.UnholdLocationId = SessionUtility.LoginLocationId;
            Response response = new Response();
            response = this.docketRepository.DocketUnhold(objDocketHold);
            ActionResult action = base.RedirectToAction("DocketHoldDone", new { status = "DocketUnhold" });
            return action;
        }

        [HttpPost]
        public JsonResult GetChargeDetails(long id, byte businessTypeId, byte serviceTypeId)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetChargeDetails(id, businessTypeId, serviceTypeId, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetCustomerDetailByGstTinNo(short locationId, byte paybasId, string gstTinNo, bool allowWalkIn)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetCustomerDetailByGstTinNo(locationId, paybasId, gstTinNo, allowWalkIn), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketHoldData(long docketId)
        {
            return base.Json(this.docketRepository.GetDocketHoldData(docketId));
        }

        [HttpPost]
        public JsonResult GetDocketListForCancellation(string docketNos, DateTime fromDate, DateTime toDate)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetDocketListForCancellation(docketNos, fromDate, toDate, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketTalkData(long docketId)
        {
            return base.Json(this.docketRepository.GetDocketTalkData(docketId));
        }

        [HttpPost]
        public JsonResult GetDocketUnHoldData(long holdId)
        {
            return base.Json(this.docketRepository.GetDocketUnHoldData(holdId));
        }

        [HttpPost]
        public JsonResult GetDocumentDetails(long id)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetDocumentDetails(id, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetInvoiceDetails(long id)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetInvoiceDetails(id, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetPaymentDetail(long docketId)
        {
            return base.Json(this.docketRepository.GetPaymentDetail(docketId));
        }

        public JsonResult GetStep1DetailById(long docketId)
        {
            return base.Json(this.docketRepository.GetStep1DetailById(docketId));
        }

        public JsonResult GetStep2Detail(short CustomerId, byte PaybasId, DateTime DocketDate)
        {
            Docket docket = new Models.Docket();
            docket.CustomerId = CustomerId;
            docket.PaybasId = PaybasId;
            docket.DocketDate = DocketDate;

            return base.Json(this.docketRepository.GetStep2Detail(docket));
        }

        public JsonResult GetStep2DetailById(long docketId)
        {
            return base.Json(this.docketRepository.GetStep2DetailById(docketId));
        }

        public JsonResult GetStep3Detail(string ContractId, string PaybasId, string CustomerId, string DocketDate, string FromLocationId,
            string ToLocationId, string ConsignorId, string ConsigneeId, string ConsignorGroupCode, string ConsignorName, string ConsignorAddress1, string ConsignorAddress2,
            string ConsignorCityId, string ConsignorPincode, string ConsignorMobileNo, string ConsignorEmailId, string ConsignorGstTinNo, string ConsigneeGroupCode,
            string ConsigneeName, string ConsigneeAddress1, string ConsigneeAddress2, string ConsigneeCityId, string ConsigneePincode, string ConsigneeMobileNo,
            string ConsigneeEmailId, string ConsigneeGstTinNo, string MappingBillingPartyId, string IsConsignorConsigneePartyMapping, string IsConsignorFromMaster, string IsConsigneeFromMaster,
            string IsWalkInConsignorSaveInSystem, string IsWalkInConsigneeSaveInSystem, string EntryBy, string CompanyId, string ConsigneePhoneNo, string ConsignorPhoneNo, string ConsignorSearchPanNo, string ConsigneeSearchPanNo, string ConsignorPanNo, string ConsigneePanNo, string ConsignorSearchMobileNo, string ConsigneeSearchMobileNo, bool IsConsignorGst = true, bool IsConsigneeGst = true)
        {
            Docket docket = new Models.Docket();
            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (PaybasId != "") docket.PaybasId = PaybasId.ConvertToByte();
            if (CustomerId != "") docket.CustomerId = CustomerId.ConvertToShort();
            if (DocketDate != "") docket.DocketDate = DocketDate.ConvertToDateTime();
            if (FromLocationId != "") docket.FromLocationId = FromLocationId.ConvertToShort();
            if (ToLocationId != "") docket.ToLocationId = ToLocationId.ConvertToShort();
            if (ConsignorId != "") docket.ConsignorId = ConsignorId.ConvertToShort();
            if (ConsigneeId != "") docket.ConsigneeId = ConsigneeId.ConvertToShort();
            if (MappingBillingPartyId != "") docket.MappingBillingPartyId = MappingBillingPartyId.ConvertToShort();

            docket.ConsignorGroupCode = ConsignorGroupCode;
            docket.ConsignorName = ConsignorName; docket.ConsignorAddress1 = ConsignorAddress1; docket.ConsignorAddress2 = ConsignorAddress2;
            if (ConsignorCityId != "") docket.ConsignorCityId = ConsignorCityId.ConvertToShort();
            docket.ConsignorPincode = ConsignorPincode; docket.ConsignorMobileNo = IsConsignorGst ? ConsignorMobileNo : ConsignorSearchMobileNo;
            docket.ConsignorEmailId = ConsignorEmailId; docket.ConsignorGstTinNo = ConsignorGstTinNo; docket.ConsigneeGroupCode = ConsigneeGroupCode;
            docket.ConsigneeName = ConsigneeName; docket.ConsigneeAddress1 = ConsigneeAddress1; docket.ConsigneeAddress2 = ConsigneeAddress2;
            if (ConsigneeCityId != "") docket.ConsigneeCityId = ConsigneeCityId.ConvertToShort();
            docket.ConsigneePincode = ConsigneePincode; docket.ConsigneeMobileNo = IsConsigneeGst ? ConsigneeMobileNo : ConsigneeSearchMobileNo;
            docket.ConsigneeEmailId = ConsigneeEmailId; docket.ConsigneeGstTinNo = ConsigneeGstTinNo;
            if (IsConsignorConsigneePartyMapping != "") docket.IsConsignorConsigneePartyMapping = IsConsignorConsigneePartyMapping.ConvertToBool();
            if (IsConsignorFromMaster != "") docket.IsConsignorFromMaster = IsConsignorFromMaster.ConvertToBool();
            if (IsConsigneeFromMaster != "") docket.IsConsigneeFromMaster = IsConsigneeFromMaster.ConvertToBool();
            docket.ConsignorSearchPanNo = ConsignorSearchPanNo;
            docket.ConsigneeSearchPanNo = ConsigneeSearchPanNo;
            docket.ConsignorPanNo = IsConsignorGst ? ConsignorPanNo : ConsignorSearchPanNo;
            docket.ConsigneePanNo = IsConsignorGst ? ConsigneePanNo : ConsigneeSearchPanNo;
            docket.ConsignorPhoneNo = ConsignorPhoneNo;
            docket.ConsigneePhoneNo = ConsigneePhoneNo;
            if (IsWalkInConsignorSaveInSystem != "") docket.IsWalkInConsignorSaveInSystem = IsWalkInConsignorSaveInSystem.ConvertToBool();
            if (IsWalkInConsigneeSaveInSystem != "") docket.IsWalkInConsigneeSaveInSystem = IsWalkInConsigneeSaveInSystem.ConvertToBool();
            docket.IsConsignorGst = IsConsignorGst;
            docket.IsConsigneeGst = IsConsigneeGst;
            if (EntryBy != "") docket.EntryBy = EntryBy.ConvertToShort();
            if (CompanyId != "") docket.CompanyId = CompanyId.ConvertToByte();

            return base.Json(this.docketRepository.GetStep3Detail(docket));
        }
        public JsonResult GetStep3DetailforPincode(string ContractId, string PaybasId, string CustomerId, string DocketDate, string FromLocationId,
             string ToLocationId, string ConsignorId, string ConsigneeId, string ConsignorGroupCode, string ConsignorName, string ConsignorAddress1, string ConsignorAddress2,
             string ConsignorCityId, string ConsignorPincode, string ConsignorMobileNo, string ConsignorEmailId, string ConsignorGstTinNo, string ConsigneeGroupCode,
             string ConsigneeName, string ConsigneeAddress1, string ConsigneeAddress2, string ConsigneeCityId, string ConsigneePincode, string ConsigneeMobileNo,
             string ConsigneeEmailId, string ConsigneeGstTinNo, string MappingBillingPartyId, string IsConsignorConsigneePartyMapping, string IsConsignorFromMaster, string IsConsigneeFromMaster,
             string IsWalkInConsignorSaveInSystem, string IsWalkInConsigneeSaveInSystem, string EntryBy, string CompanyId, string PinCodeId)
        {
            Docket docket = new Models.Docket();
            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (PaybasId != "") docket.PaybasId = PaybasId.ConvertToByte();
            if (CustomerId != "") docket.CustomerId = CustomerId.ConvertToShort();
            if (DocketDate != "") docket.DocketDate = DocketDate.ConvertToDateTime();
            if (FromLocationId != "") docket.FromLocationId = FromLocationId.ConvertToShort();
            if (ToLocationId != "") docket.ToLocationId = ToLocationId.ConvertToShort();
            if (ConsignorId != "") docket.ConsignorId = ConsignorId.ConvertToShort();
            if (ConsigneeId != "") docket.ConsigneeId = ConsigneeId.ConvertToShort();
            if (MappingBillingPartyId != "") docket.MappingBillingPartyId = MappingBillingPartyId.ConvertToShort();

            docket.ConsignorGroupCode = ConsignorGroupCode;
            docket.ConsignorName = ConsignorName; docket.ConsignorAddress1 = ConsignorAddress1; docket.ConsignorAddress2 = ConsignorAddress2;
            if (ConsignorCityId != "") docket.ConsignorCityId = ConsignorCityId.ConvertToShort();
            docket.ConsignorPincode = ConsignorPincode; docket.ConsignorMobileNo = ConsignorMobileNo;
            docket.ConsignorEmailId = ConsignorEmailId; docket.ConsignorGstTinNo = ConsignorGstTinNo; docket.ConsigneeGroupCode = ConsigneeGroupCode;
            docket.ConsigneeName = ConsigneeName; docket.ConsigneeAddress1 = ConsigneeAddress1; docket.ConsigneeAddress2 = ConsigneeAddress2;
            if (ConsigneeCityId != "") docket.ConsigneeCityId = ConsigneeCityId.ConvertToShort();
            docket.ConsigneePincode = ConsigneePincode; docket.ConsigneeMobileNo = ConsigneeMobileNo;
            docket.ConsigneeEmailId = ConsigneeEmailId; docket.ConsigneeGstTinNo = ConsigneeGstTinNo;
            if (IsConsignorConsigneePartyMapping != "") docket.IsConsignorConsigneePartyMapping = IsConsignorConsigneePartyMapping.ConvertToBool();
            if (IsConsignorFromMaster != "") docket.IsConsignorFromMaster = IsConsignorFromMaster.ConvertToBool();
            if (IsConsigneeFromMaster != "") docket.IsConsigneeFromMaster = IsConsigneeFromMaster.ConvertToBool();
            if (IsWalkInConsignorSaveInSystem != "") docket.IsWalkInConsignorSaveInSystem = IsWalkInConsignorSaveInSystem.ConvertToBool();
            if (IsWalkInConsigneeSaveInSystem != "") docket.IsWalkInConsigneeSaveInSystem = IsWalkInConsigneeSaveInSystem.ConvertToBool();
            if (EntryBy != "") docket.EntryBy = EntryBy.ConvertToShort();
            if (CompanyId != "") docket.CompanyId = CompanyId.ConvertToByte();
            if (PinCodeId !="") docket.PincodeId = PinCodeId;


            return base.Json(this.docketRepository.GetStep3DetailforPincode(docket));
        }
        public JsonResult GetStep3DetailById(long docketId)
        {
            return base.Json(this.docketRepository.GetStep3DetailById(docketId));
        }

        public JsonResult GetStep4Detail(string FromCityId, string ToCityId)
        {
            Docket docket = new Models.Docket();

            if (FromCityId != "") docket.FromCityId = FromCityId.ConvertToInt();
            if (ToCityId != "") docket.ToCityId = ToCityId.ConvertToInt();

            return base.Json(this.docketRepository.GetStep4Detail(docket));
        }

        public JsonResult GetStep4DetailById(long docketId)
        {
            return base.Json(this.docketRepository.GetStep4DetailById(docketId));
        }

        public JsonResult GetStep5Detail(string ContractId, string TransportModeId, string InvoiceNo)
        {
            Docket docket = new Models.Docket();

            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (TransportModeId != "") docket.TransportModeId = TransportModeId.ConvertToByte();
            if (InvoiceNo != "") docket.WmsInvoiceNo = InvoiceNo;

            return base.Json(this.docketRepository.GetStep5Detail(docket));
        }

        public JsonResult GetStep5DetailById(long docketId)
        {
            return base.Json(this.docketRepository.GetStep5DetailById(docketId));
        }

        [HttpPost]
        public JsonResult GetStep6Detail(string DocketDate, string ContractId, string TransportModeId, string PaybasId, string ServiceTypeId,
            string BusinessTypeId, string ProductTypeId, string PackagingTypeId, string FtlTypeId, string FromLocationId, string ToLocationId,
            string FromCityId, string ToCityId, string ConsignorId, string ConsigneeId, string ActualWeight, string ChargedWeight, string Packages,
            string InvoiceAmount, string IsOda, string IsCod, string IsDacc, string IsLocal, string IsCarrierRisk, string IsDoorDelivery,
            string IsBooking, string IsMultiPickup, string IsMultiDelivery
            )
        {
            Docket docket = new Models.Docket();

            if (DocketDate != "") docket.DocketDate = DocketDate.ConvertToDateTime();
            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (TransportModeId != "") docket.TransportModeId = TransportModeId.ConvertToByte();
            if (PaybasId != "") docket.PaybasId = PaybasId.ConvertToByte();
            if (ServiceTypeId != "") docket.ServiceTypeId = ServiceTypeId.ConvertToByte();
            if (BusinessTypeId != "") docket.BusinessTypeId = BusinessTypeId.ConvertToByte();
            if (ProductTypeId != "") docket.ProductTypeId = ProductTypeId.ConvertToShort();
            if (PackagingTypeId != "") docket.PackagingTypeId = PackagingTypeId.ConvertToByte();
            if (FtlTypeId != "") docket.FtlTypeId = FtlTypeId.ConvertToByte();
            if (FromLocationId != "") docket.FromLocationId = FromLocationId.ConvertToShort();
            if (ToLocationId != "") docket.ToLocationId = ToLocationId.ConvertToShort();
            if (FromCityId != "") docket.FromCityId = FromCityId.ConvertToShort();
            if (ToCityId != "") docket.ToCityId = ToCityId.ConvertToShort();
            if (ConsignorId != "") docket.ConsignorId = ConsignorId.ConvertToShort();
            if (ConsigneeId != "") docket.ConsigneeId = ConsigneeId.ConvertToShort();
            if (ActualWeight != "") docket.ActualWeight = ActualWeight.ConvertToDecimal();
            if (ChargedWeight != "") docket.ChargedWeight = ChargedWeight.ConvertToDecimal();
            if (Packages != "") docket.Packages = Packages.ConvertToInt();
            if (InvoiceAmount != "") docket.InvoiceAmount = InvoiceAmount.ConvertToDecimal();
            if (IsOda != "") docket.IsOda = IsOda.ConvertToBool();
            if (IsCod != "") docket.IsCod = IsCod.ConvertToBool();
            if (IsDacc != "") docket.IsDacc = IsDacc.ConvertToBool();
            if (IsLocal != "") docket.IsLocal = IsLocal.ConvertToBool();
            if (IsCarrierRisk != "") docket.IsCarrierRisk = IsCarrierRisk.ConvertToBool();
            if (IsDoorDelivery != "") docket.IsDoorDelivery = IsDoorDelivery.ConvertToBool();
            if (IsBooking != "") docket.IsBooking = IsBooking.ConvertToBool();
            if (IsMultiPickup != "") docket.IsMultiPickup = IsMultiPickup.ConvertToBool();
            if (IsMultiDelivery != "") docket.IsMultiDelivery = IsMultiDelivery.ConvertToBool();

            return base.Json(this.docketRepository.GetStep6Detail(docket));
        }

        public JsonResult GetCustomerContractByCustomerId(short CustomerId, byte PaybasId, DateTime DocketDate)
        {
            Docket docket = new Models.Docket();
            docket.CustomerId = CustomerId;
            docket.PaybasId = PaybasId;
            docket.DocketDate = DocketDate;

            return base.Json(this.docketRepository.GetCustomerContractByCustomerId(docket));
        }

        [HttpPost]
        public JsonResult GetStep6DetailTrispeed(string DocketDate, string ContractId, string TransportModeId, string PaybasId, string ServiceTypeId,
           string BusinessTypeId, string ProductTypeId, string PackagingTypeId, string FtlTypeId, string FromLocationId, string ToLocationId,
           string FromCityId, string ToCityId, string ConsignorId, string ConsigneeId, string ActualWeight, string ChargedWeight, string Packages,
           string InvoiceAmount, string IsOda, string IsCod, string IsDacc, string IsLocal, string IsCarrierRisk, string IsDoorDelivery,
           string IsBooking, string IsMultiPickup, string IsMultiDelivery, string PartQuantity
           )
        {
            Docket docket = new Models.Docket();

            if (DocketDate != "") docket.DocketDate = DocketDate.ConvertToDateTime();
            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (TransportModeId != "") docket.TransportModeId = TransportModeId.ConvertToByte();
            if (PaybasId != "") docket.PaybasId = PaybasId.ConvertToByte();
            if (ServiceTypeId != "") docket.ServiceTypeId = ServiceTypeId.ConvertToByte();
            if (BusinessTypeId != "") docket.BusinessTypeId = BusinessTypeId.ConvertToByte();
            if (ProductTypeId != "") docket.ProductTypeId = ProductTypeId.ConvertToByte();
            if (PackagingTypeId != "") docket.PackagingTypeId = PackagingTypeId.ConvertToByte();
            if (FtlTypeId != "") docket.FtlTypeId = FtlTypeId.ConvertToByte();
            if (FromLocationId != "") docket.FromLocationId = FromLocationId.ConvertToShort();
            if (ToLocationId != "") docket.ToLocationId = ToLocationId.ConvertToShort();
            if (FromCityId != "") docket.FromCityId = FromCityId.ConvertToInt();
            if (ToCityId != "") docket.ToCityId = ToCityId.ConvertToInt();
            if (ConsignorId != "") docket.ConsignorId = ConsignorId.ConvertToShort();
            if (ConsigneeId != "") docket.ConsigneeId = ConsigneeId.ConvertToShort();
            if (ActualWeight != "") docket.ActualWeight = ActualWeight.ConvertToDecimal();
            if (ChargedWeight != "") docket.ChargedWeight = ChargedWeight.ConvertToDecimal();
            if (Packages != "") docket.Packages = Packages.ConvertToInt();
            if (InvoiceAmount != "") docket.InvoiceAmount = InvoiceAmount.ConvertToDecimal();
            if (IsOda != "") docket.IsOda = IsOda.ConvertToBool();
            if (IsCod != "") docket.IsCod = IsCod.ConvertToBool();
            if (IsDacc != "") docket.IsDacc = IsDacc.ConvertToBool();
            if (IsLocal != "") docket.IsLocal = IsLocal.ConvertToBool();
            if (IsCarrierRisk != "") docket.IsCarrierRisk = IsCarrierRisk.ConvertToBool();
            if (IsDoorDelivery != "") docket.IsDoorDelivery = IsDoorDelivery.ConvertToBool();
            if (IsBooking != "") docket.IsBooking = IsBooking.ConvertToBool();
            if (IsMultiPickup != "") docket.IsMultiPickup = IsMultiPickup.ConvertToBool();
            if (IsMultiDelivery != "") docket.IsMultiDelivery = IsMultiDelivery.ConvertToBool();
            if (PartQuantity != "") docket.TotalPartQuantity = PartQuantity.ConvertToDecimal();

            return base.Json(this.docketRepository.GetStep6DetailTrispeed(docket));
        }

        public JsonResult GetStep6DetailById(long docketId)
        {
            return base.Json(this.docketRepository.GetStep6DetailById(docketId));
        }

        [HttpPost]
        public JsonResult GetTaxDetails(long id)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetTaxDetails(id, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetGPRODetails(long id)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetGPRODetails(id, SessionUtility.CompanyId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
        public ActionResult GstVerification()
        {
            return base.View();
        }

        public ActionResult InsertTest(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();
            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            string[] strArrays = new string[] { "Market", "Attached", "Own" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
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
        public ActionResult InsertTriSpeed(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;
                docket.GPROList.Add(new DocketGPRO_Details());
            }
            else
            {
                docket.DocketId = id.Value;
                docket.GPROList = (List<DocketGPRO_Details>)this.docketRepository.GetGPRODetails(docket.DocketId, SessionUtility.CompanyId);
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());


            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertTriSpeed(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }


            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }

            //DataSet dsError = new DataSet();
            //dsError.Tables.Add("List");
            //dsError.Tables[0].Columns.Add("Error");

            //foreach (ModelState modelState in ViewData.ModelState.Values)
            //{
            //    foreach (ModelError error in modelState.Errors)
            //    {
            //        DataRow dr = dsError.Tables[0].NewRow();
            //        dr["Error"] = error.ErrorMessage;
            //        dsError.Tables[0].Rows.Add(dr);
            //    }
            //}


            //this.ModelState.Remove()
            //if (this.ModelState.IsValid)
            //{
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }

                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            //    }
            //        else
            //        {
            //            action = base.View(objDocket);
            //}
            return action;
        }

        public ActionResult InsertAllTime(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
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
        public ActionResult InsertAllTime(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDoneAllTime", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            //}
            //else
            //{
            //    action = base.View(objDocket);
            //}
            return action;
        }


        public ActionResult Insert(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
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
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            //}
            //else
            //{
            //    action = base.View(objDocket);
            //}
            return action;
        }

        [HttpPost]
        public ActionResult InsertDumptco(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDumptcoDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }
        public ActionResult InsertDumptco(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }
        public ActionResult InsertDumptcoDocketPinCode(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }
        [HttpPost]
        public ActionResult InsertDumptcoDocketPinCode(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.DumptcoDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.DumptcoDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;

                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(25, 1) == "Y")
                {

                    Response docketresponse = this.docketRepository.CreatePktBarCode(response.DocumentId, "Docket");
                    if (docketresponse != null)
                    {
                        response.DocumentId3 = docketresponse.DocumentId;
                        response.DocumentNo3 = response.DocumentNo;
                    }
                    //SavePrintBarcodeInPdf(docketresponse.DocumentId.ToString());
                }
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDumptcoDocketPinCodeDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
            }

            return action;
        }

        public ActionResult InsertDumptcoDocket(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertDumptcoDocket(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.DumptcoDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.DumptcoDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;

                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 78) == "Y")
                {

                    Response docketresponse = this.docketRepository.CreatePktBarCode(response.DocumentId, "Docket");
                    if (docketresponse != null)
                    {
                        response.DocumentId3 = docketresponse.DocumentId;
                        response.DocumentNo3 = response.DocumentNo;
                    }
                    //SavePrintBarcodeInPdf(docketresponse.DocumentId.ToString());
                }
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDumptcoDocketDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
            }

            return action;
        }

        public ActionResult InsertDumptcoDocketDone(long? documentId)
        {
            List<DocketPackages> docketPackages = new List<DocketPackages>();
            docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
            return base.View(docketPackages);
        }
        public ActionResult InsertDumptcoDocketPinCodeDone(long? documentId)
        {
            List<DocketPackages> docketPackages = new List<DocketPackages>();
            docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
            return base.View(docketPackages);
        }
        public ActionResult InsertARB2B(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertARB2B(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertARB2BDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertARB2BDone()
        {
            return base.View();
        }

        public ActionResult InsertInnofyDocket(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertInnofyDocket(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertInnofyDocketDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertInnofyDocketDone()
        {
            return base.View();
        }

        public ActionResult InsertmtcDocket(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertmtcDocket(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertmtcDocketDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertmtcDocketDone()
        {
            return base.View();
        }


        public ActionResult InsertEverKoolDocket(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertEverKoolDocket(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertEverKoolDocketDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertEverKoolDocketDone()
        {
            return base.View();
        }


        public ActionResult InsertDumptcoDone()
        {
            return base.View();
        }
        public ActionResult InsertDone()
        {
            return base.View();
        }
        public ActionResult InsertDoneAllTime()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult InsertDone(string hdnDocumentId, string hdnDocumentType, HttpPostedFileBase fuFileName)
        {
            string FileLoc = Server.MapPath("~/Storage/DocumentPrint/");
            string FileName = "";

            if (System.IO.Directory.Exists(FileLoc)) { }
            else
            {
                System.IO.Directory.CreateDirectory(FileLoc);
            }
            FileName = hdnDocumentType + "_" + hdnDocumentId + Path.GetExtension(fuFileName.FileName);

            FileLoc = FileLoc + FileName;

            fuFileName.SaveAs(FileLoc);
            Response response = this.generalRepository.InsertFormDocumentImage(hdnDocumentId, hdnDocumentType, FileName);
            ActionResult action = base.RedirectToAction("InsertDoneImage", new { documentId = response.DocumentId, documentNo = response.DocumentNo, DocumentFile = FileName });

            return action;
        }
        public ActionResult InsertDoneImage()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult IsDocketNoExistByLocation(string docketNo, short locationId)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.IsDocketNoExistByLocation(docketNo, locationId));
            return jsonResult;
        }
        public JsonResult IsDocketNoExistByBillingParty(string docketNo, short billingPartyId)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.IsDocketNoExistByBillingParty(docketNo, billingPartyId));
            return jsonResult;
        }
        [HttpPost]
        public JsonResult IsDocketValidForCancellation(long docketId, string docketNomenClature)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.IsDocketValidForCancellation(docketId, SessionUtility.DocketNomenClature));
            return jsonResult;
        }
        public ActionResult UpdateDumptcoDocketPinCode()
        {
            return base.View();
        }
        public ActionResult Update()
        {

            return base.View();
        }

        public ActionResult UpdateTriSpeed()
        {
            return base.View();
        }
        public ActionResult UpdateDumptco()
        {
            return base.View();
        }

        public ActionResult UpdateDocketDumptco()
        {
            return base.View();
        }
        public ActionResult UpdateD2D()
        {
            return base.View();
        }

        public ActionResult UpdateARB2B()
        {

            //string EntryBy = SessionUtility.LoginUserId.ToString();

            //Task<TaxProEwayConsolidateApiResponse> taskEx = Task.Run<TaxProEwayConsolidateApiResponse>(async () => await this.docketRepository.TaxProEwayConsolidated(DocumentId.ToString(), "THC", EntryBy));
            //TaxProEwayConsolidateApiResponse objTaskEx = taskEx.Result;

            return base.View();
        }

        public ActionResult UpdateDocketInnofy()
        {
            return base.View();
        }

        public ActionResult UpdateDocketMTC()
        {
            return base.View();
        }

        public ActionResult UpdateChaudhary()
        {
            return base.View();
        }

        public ActionResult Upload()
        {
            return base.View(new DocketUpload());
        }
        public ActionResult UpdateAllTime()
        {
            return base.View();
        }

        public ActionResult UpdateFalwings()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult Upload(DocketUpload objDocketUpload)
        {
            DocketUpload docketUpload = new DocketUpload()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUpload docketUpload1 = docketUpload;
            if (objDocketUpload.File != null)
            {
                objDocketUpload.EntryBy = SessionUtility.LoginUserId;
                docketUpload1 = this.docketRepository.Upload(objDocketUpload);
            }
            return base.View(docketUpload1);
        }

        public ActionResult UploadInSystem()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystem(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadInSystem(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        public ActionResult View(long? id)
        {
            ActionResult httpStatusCodeResult;
            if (id.HasValue)
            {
                Docket detailById = this.docketRepository.GetDetailById(id.Value, SessionUtility.CompanyId);
                if (detailById != null)
                {
                    httpStatusCodeResult = base.View(detailById);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        public ActionResult InsertChaudhary(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);


            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertChaudhary(Docket objDocket)
        {
            ActionResult action;
            string str;
            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();
            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        [HttpPost]
        public JsonResult CheckValidDocketNoForChangeStatus(string docketNo)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidDocketNoForChangeStatus(docketNo));
            return jsonResult;
        }

        public ActionResult DocketChangeStatus()
        {
            DocketReAssign docketDacc = new DocketReAssign();
            //((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationListOnlyBranch();

            return base.View(docketDacc);
        }
        public ActionResult DocketChangeStatusDone()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult DocketChangeStatus(DocketReAssign objDocketDacc)
        {
            objDocketDacc.EntryBy = SessionUtility.LoginUserId;
            Response response = new Response();
            response = this.docketRepository.InsertDocketChangeStatus(objDocketDacc);

            if (response.IsSuccessfull)
            {
                return base.RedirectToAction("DocketChangeStatusDone");
            }

            return base.View();
        }

        public ActionResult UploadInSystemRemarks()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemRemarks(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadInSystemRemarks(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        public ActionResult UploadInSystemTrispeed()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemTrispeed(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadInSystemTrispeed(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }


        [HttpPost]
        public ActionResult InsertKExpress(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                GenerateDocketBarCode(response.DocumentId.ToString(), response.DocumentNo);
                action = base.RedirectToAction("InsertKExpressDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertKExpress(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }
        public ActionResult InsertKExpressDone()
        {
            return base.View();
        }

        public ActionResult UpdateKExpress()
        {
            return base.View();
        }

        public ActionResult FastTagUploadInSystem()
        {
            ((dynamic)base.ViewBag).TripsheetList = this.docketRepository.TripsheetList(SessionUtility.LoginUserId.ToString());

            return base.View(new FastTagUploadInSystem());
        }

        [HttpPost]
        public ActionResult FastTagUploadInSystem(FastTagUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            FastTagUploadInSystem docketUploadInSystem = new FastTagUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            FastTagUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.FastTagUploadInSystem(objDocketUploadInSystem);
            }
          ((dynamic)base.ViewBag).TripsheetList = this.docketRepository.TripsheetList(SessionUtility.LoginUserId.ToString());

            return base.View(docketUploadInSystem1);
        }

        public JsonResult GetListForOtherCharges
     (
     string ChargeTypeId,
     string LocationId,
     DateTime fromDate,
     DateTime toDate
     )
        {
            return this.Json((object)this.docketRepository.GetListForOtherCharges(ChargeTypeId, LocationId, fromDate, toDate));
        }
        public ActionResult DocketOtherCharges()
        {
            Session["ClickResponse"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult DocketOtherCharges(DocketOtherCharges objOther)
        {
            Response response = new Response();
            ActionResult action;

            if (Session["ClickResponse"] == null)
            {
                response = this.docketRepository.InsertDocketOtherCharges(objOther);

                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objOther);
            }
            else
            {
                action = base.RedirectToAction("InsertDoneOtherCharges", new { documentId = response.DocumentId, documentNo = response.DocumentNo });
            }

            return action;
        }

        public ActionResult InsertDoneOtherCharges()
        {
            return View();
        }

        public ActionResult ScanIn()
        {
            ((dynamic)base.ViewBag).BarcodeList = this.docketRepository.GetBarcodeList(SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Message = "";
            return View();
        }
        public void CreatePktBarCode(int barcodeIndex)
        {
            BarCodeModel objMaster = new BarCodeModel();

            IEnumerable<BarCodeModel> obj = this.docketRepository.GetBarCode(barcodeIndex, SessionUtility.CompanyId.ToString());
        }


        [HttpPost]
        public ActionResult ScanIn(DocketBarcode Obj)
        {
            Response response = new Response();
            response = this.docketRepository.InsertDocketBarcode(Obj);

            if (response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).Message = "Record submitted successfully";

            }
            else
            {
                ((dynamic)base.ViewBag).Message = "Barcode has been mapped with other dockets, Please try again";
            }
            Obj.DocketNo = "";
            Obj.DocketId = 0;

            return View();
        }

        public ActionResult BarCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BarCode(BarCodeModel obj)
        {
            string barcode = obj.BarCode;

            int barcodeI = 0;
            int.TryParse(barcode, out barcodeI);

            ActionResult action = base.RedirectToAction("GenerateBarCode", new { barcodeIndex = barcodeI });
            return action;
        }

        public ActionResult PrintBarcodeInPdfUsingCommand(string documentId)
        {
            IEnumerable<DocketBarcodeDetail> obj = this.docketRepository.GetDocketBarcodeGetById(documentId);

            string textToAdd = "";
            string fileName = documentId + ".pdf";
            foreach (var item in obj)
            {
                fileName = item.DocketNo + ".pdf";
                break;
            }
            string outputPath = Server.MapPath("~/Storage/" + fileName);
            string logoFile = Server.MapPath("~/assets/images/logo.png");
            string AppPath = @"D:\Solutions\RND\Barcode Printing\BarcodePrinting\bin\Debug\net6.0\BarcodePrinting.exe";
            string argsString = "";


            //DocketNo; FromCity; ToCity; BarCode; ConsignorName; ConsigneeName; outputPath; logoFile#
            int index = 0;
            foreach (var item in obj)
            {
                if (index == 0)
                {
                    argsString = item.DocketNo + ";" + item.FromCity + ";" + item.ToCity + ";" + item.BarCode + ";" + item.sno + ";" + item.ConsignorName + ";" + item.ConsigneeName + ";" + outputPath + ";" + logoFile;
                }
                else
                {
                    argsString = argsString + "#" + item.DocketNo + ";" + item.FromCity + ";" + item.ToCity + ";" + item.BarCode + ";" + item.sno + ";" + item.ConsignorName + ";" + item.ConsigneeName + ";" + outputPath + ";" + logoFile;
                }
                index = 1;
            }


            Process process = new Process();
            process.StartInfo.FileName = AppPath; // relative path. absolute path works too.
            process.StartInfo.Arguments = argsString;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();

            byte[] bytes = System.IO.File.ReadAllBytes(outputPath);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();

            return View();
        }

        public ActionResult PrintBarcodeNameInPdf(string documentId)
        {
            string textToAdd = "";
            string fileName = "";

            IEnumerable<DocketBarcodeDetail> obj = this.docketRepository.GetDocketBarcodeGetById(documentId);

            //foreach (var item in obj)
            //{
            //    fileName = item.DocketNo+".pdf";
            //    break;
            //}

            // Create a new document with custom dimensions
            iTextSharp.text.Document document = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(iTextSharp.text.Utilities.MillimetersToPoints(80), iTextSharp.text.Utilities.MillimetersToPoints(55)));

            // Specify the output path for the PDF
            // string outputPath = @"D:\Solutions\RND\CustomSizePDF.pdf";
            // string outputPath = Server.MapPath("~/Storage/") + fileName;
            // Create a PdfWriter instance to write to the document
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            // Create a new MemoryStream to hold the PDF content
            //MemoryStream memoryStream = new MemoryStream();
            //PdfWriter writer1 = PdfWriter.GetInstance(document, memoryStream);
            // Return the PDF file for download
            //return File(memoryStream, "application/pdf", "GeneratedPDF.pdf");
            //@Html.ActionLink("Download PDF", "DownloadPdf", "Pdf")

            // Open the document for writing
            document.Open();
            int totalPkt = ((List<DocketBarcodeDetail>)obj).Count;
            //   long barcode = 38000356216;


            int i = 0;
            foreach (var item in obj)
            {
                fileName = item.DocketNo + ".pdf";

                // Get the content byte of the PDF
                PdfContentByte contentByte = writer.DirectContent;

                // Set the rectangle coordinates and dimensions
                float x = 10;      // x-coordinate of the lower-left corner
                float y = 5;      // y-coordinate of the lower-left corner
                float width = document.PageSize.Width - 20; //200;  // Width of the rectangle
                float height = document.PageSize.Height - 10;// 100; // Height of the rectangle

                // Draw the rectangle
                contentByte.Rectangle(x, y, width, height);
                contentByte.Stroke(); // Draw the outline

                // Set the coordinates
                int xco = (Convert.ToInt32(document.PageSize.Width) / 3) - 20; // x-coordinate
                int yco = Convert.ToInt32(document.PageSize.Height) - 20; // y-coordinate
                iTextSharp.text.Font font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD);// new iTextSharp.text.Font();
                yco = yco - 10;
                // Add barcode image to the PDF
                //string logoFile = Server.MapPath("~/assets/images/Barcode_logo.png");

                //iTextSharp.text.Image logoImagePDF = iTextSharp.text.Image.GetInstance(logoFile);
                //logoImagePDF.SetAbsolutePosition(xco, yco);
                //logoImagePDF.ScaleAbsolute(100, 22);
                //contentByte.AddImage(logoImagePDF);


                textToAdd = item.CompanyName;// "Spanda Logistics Private Limited";
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, font), xco, yco, 0);



                BarcodeLib.Barcode barcodeAPI = new BarcodeLib.Barcode();

                // Define basic settings of the image
                int imageWidth = 200;
                int imageHeight = 30;
                System.Drawing.Color foreColor = System.Drawing.Color.Black;
                System.Drawing.Color backColor = System.Drawing.Color.Transparent;
                //string data = obj.BarCode;
                System.Drawing.Image barcodeImage = barcodeAPI.Encode(TYPE.CODE128, item.BarCode, foreColor, backColor, imageWidth, imageHeight);

                // Add barcode image to the PDF
                iTextSharp.text.Image barcodeImagePDF = iTextSharp.text.Image.GetInstance(barcodeImage, BaseColor.WHITE);
                xco = 15;
                yco = yco - 35;
                barcodeImagePDF.SetAbsolutePosition(xco, yco);
                contentByte.AddImage(barcodeImagePDF);

                iTextSharp.text.Font fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 80;
                yco = yco - 10;
                textToAdd = item.BarCode;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                yco = yco - 5;
                // Set the starting and ending points of the line
                float x1 = 10; // x-coordinate of the starting point
                float y1 = yco; // y-coordinate of the starting point
                float x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                float y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Docket No
                fontCus = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.DocketNo;//  "2324BGL004567";
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                // Add Docket No
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 150;
                //yco = yco-12;
                textToAdd = "Pkt. " + item.sno + "/" + totalPkt.ToString();
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                yco = yco - 5;
                // Set the starting and ending points of the line
                x1 = 10; // x-coordinate of the starting point
                y1 = yco; // y-coordinate of the starting point
                x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Location
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.FromCity + " - " + item.ToCity;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                //// Add Customer
                //fontCus = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                //xco = 40;
                //yco = yco-12;
                //textToAdd = item.CustomerName;
                //ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                yco = yco - 5;
                // Set the starting and ending points of the line
                x1 = 10; // x-coordinate of the starting point
                y1 = yco; // y-coordinate of the starting point
                x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Consignor
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.ConsignorName;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                // Add Consignee
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.ConsigneeName;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                if (i != totalPkt)
                {
                    document.NewPage();
                }
                i = i + 1;
            }

            // Close the document
            document.Close();

            //string originalPath = Server.MapPath("~/Storage/") + fileName;
            //string reducePath = Server.MapPath("~/Storage/") +"Reduce_"+ fileName;
            //// Write the MemoryStream data to the file
            //System.IO.File.WriteAllBytes(originalPath, memoryStream.ToArray());
            //MemoryStream reducedPdfStream = new MemoryStream();

            //using (PdfReader pdfReader = new PdfReader(outputPath))
            //{
            //    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, reducedPdfStream))
            //    {
            //        // Reduce PDF size by removing unused objects and streams
            //        //pdfStamper.Writer.SetFullCompression();

            //        // Optionally, set other compression options if needed
            //         pdfStamper.Writer.CompressionLevel = PdfStream.BEST_COMPRESSION;

            //        // Close the stamper
            //        pdfStamper.Close();
            //    }
            //}

            //memoryStream.Close();
            //memoryStream.Position = 0;
            //return File(memoryStream.GetBuffer(), "application/pdf", "GeneratedPDF.pdf");
            //byte[] bytes = System.IO.File.ReadAllBytes(outputPath);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());

            Response.End();

            //using (FileStream fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            //{
            //    // Set the content type and file name for the response
            //    Response.ContentType = "application/pdf";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename="+fileName);

            //    // Read and write the file in chunks to prevent memory issues
            //    const int bufferSize = 4096;
            //    byte[] buffer = new byte[bufferSize];
            //    int bytesRead;

            //    while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
            //    {
            //        Response.OutputStream.Write(buffer, 0, bytesRead);
            //        Response.Flush();
            //    }
            //}

            //   Response.End();



            //memoryStream.Close();

            return View();
        }


        public ActionResult PrintBarcodeInPdf(string documentId)
        {
            string textToAdd = "";
            string fileName = "";

            IEnumerable<DocketBarcodeDetail> obj = this.docketRepository.GetDocketBarcodeGetById(documentId);

            //foreach (var item in obj)
            //{
            //    fileName = item.DocketNo+".pdf";
            //    break;
            //}

            // Create a new document with custom dimensions
            iTextSharp.text.Document document = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(iTextSharp.text.Utilities.MillimetersToPoints(80), iTextSharp.text.Utilities.MillimetersToPoints(55)));

            // Specify the output path for the PDF
            // string outputPath = @"D:\Solutions\RND\CustomSizePDF.pdf";
            // string outputPath = Server.MapPath("~/Storage/") + fileName;
            // Create a PdfWriter instance to write to the document
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            // Create a new MemoryStream to hold the PDF content
            //MemoryStream memoryStream = new MemoryStream();
            //PdfWriter writer1 = PdfWriter.GetInstance(document, memoryStream);
            // Return the PDF file for download
            //return File(memoryStream, "application/pdf", "GeneratedPDF.pdf");
            //@Html.ActionLink("Download PDF", "DownloadPdf", "Pdf")

            // Open the document for writing
            document.Open();
            int totalPkt = ((List<DocketBarcodeDetail>)obj).Count;
            //   long barcode = 38000356216;


            int i = 0;
            foreach (var item in obj)
            {
                fileName = item.DocketNo + ".pdf";

                // Get the content byte of the PDF
                PdfContentByte contentByte = writer.DirectContent;

                // Set the rectangle coordinates and dimensions
                float x = 10;      // x-coordinate of the lower-left corner
                float y = 5;      // y-coordinate of the lower-left corner
                float width = document.PageSize.Width - 20; //200;  // Width of the rectangle
                float height = document.PageSize.Height - 10;// 100; // Height of the rectangle

                // Draw the rectangle
                contentByte.Rectangle(x, y, width, height);
                contentByte.Stroke(); // Draw the outline

                // Set the coordinates
                int xco = (Convert.ToInt32(document.PageSize.Width) / 3) - 20; // x-coordinate
                int yco = Convert.ToInt32(document.PageSize.Height) - 20; // y-coordinate
                iTextSharp.text.Font font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD);// new iTextSharp.text.Font();
                yco = yco - 10;
                // Add barcode image to the PDF
                string logoFile = Server.MapPath("~/assets/images/Barcode_logo.png");

                iTextSharp.text.Image logoImagePDF = iTextSharp.text.Image.GetInstance(logoFile);
                logoImagePDF.SetAbsolutePosition(xco, yco);
                logoImagePDF.ScaleAbsolute(100, 22);
                contentByte.AddImage(logoImagePDF);



                //textToAdd = item.CompanyName;// "Spanda Logistics Private Limited";
                //ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, font), xco, yco, 0);



                BarcodeLib.Barcode barcodeAPI = new BarcodeLib.Barcode();

                // Define basic settings of the image
                int imageWidth = 200;
                int imageHeight = 30;
                System.Drawing.Color foreColor = System.Drawing.Color.Black;
                System.Drawing.Color backColor = System.Drawing.Color.Transparent;
                //string data = obj.BarCode;
                System.Drawing.Image barcodeImage = barcodeAPI.Encode(TYPE.CODE128, item.BarCode, foreColor, backColor, imageWidth, imageHeight);

                // Add barcode image to the PDF
                iTextSharp.text.Image barcodeImagePDF = iTextSharp.text.Image.GetInstance(barcodeImage, BaseColor.WHITE);
                xco = 15;
                yco = yco - 35;
                barcodeImagePDF.SetAbsolutePosition(xco, yco);
                contentByte.AddImage(barcodeImagePDF);

                iTextSharp.text.Font fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 80;
                yco = yco - 10;
                textToAdd = item.BarCode;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                yco = yco - 5;
                // Set the starting and ending points of the line
                float x1 = 10; // x-coordinate of the starting point
                float y1 = yco; // y-coordinate of the starting point
                float x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                float y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Docket No
                fontCus = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.DocketNo;//  "2324BGL004567";
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                // Add Docket No
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 170;
                //yco = yco-12;
                textToAdd = "Pkt. " + item.sno + "/" + totalPkt.ToString();
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                yco = yco - 5;
                // Set the starting and ending points of the line
                x1 = 10; // x-coordinate of the starting point
                y1 = yco; // y-coordinate of the starting point
                x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Location
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.FromCity + " - " + item.ToCity;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                //// Add Customer
                //fontCus = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                //xco = 40;
                //yco = yco-12;
                //textToAdd = item.CustomerName;
                //ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                yco = yco - 5;
                // Set the starting and ending points of the line
                x1 = 10; // x-coordinate of the starting point
                y1 = yco; // y-coordinate of the starting point
                x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Consignor
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.ConsignorName;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                // Add Consignee
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.ConsigneeName;
                if(textToAdd.Length> 31 )
                {
                    string str1 = textToAdd.Substring(0, 31);
                    string str2 ="-"+ textToAdd.Substring(31, textToAdd.Length-31);

                    ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(str1, fontCus), xco, yco, 0);
                    yco = yco - 11;
                    ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(str2, fontCus), xco, yco, 0);
                }
                else
                {
                    ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);
                }

                if (i != totalPkt)
                {
                    document.NewPage();
                }
                i = i + 1;
            }

            // Close the document
            document.Close();

            //string originalPath = Server.MapPath("~/Storage/") + fileName;
            //string reducePath = Server.MapPath("~/Storage/") +"Reduce_"+ fileName;
            //// Write the MemoryStream data to the file
            //System.IO.File.WriteAllBytes(originalPath, memoryStream.ToArray());
            //MemoryStream reducedPdfStream = new MemoryStream();

            //using (PdfReader pdfReader = new PdfReader(outputPath))
            //{
            //    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, reducedPdfStream))
            //    {
            //        // Reduce PDF size by removing unused objects and streams
            //        //pdfStamper.Writer.SetFullCompression();

            //        // Optionally, set other compression options if needed
            //         pdfStamper.Writer.CompressionLevel = PdfStream.BEST_COMPRESSION;

            //        // Close the stamper
            //        pdfStamper.Close();
            //    }
            //}

            //memoryStream.Close();
            //memoryStream.Position = 0;
            //return File(memoryStream.GetBuffer(), "application/pdf", "GeneratedPDF.pdf");
            //byte[] bytes = System.IO.File.ReadAllBytes(outputPath);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
           
            Response.End();

            //using (FileStream fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            //{
            //    // Set the content type and file name for the response
            //    Response.ContentType = "application/pdf";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename="+fileName);

            //    // Read and write the file in chunks to prevent memory issues
            //    const int bufferSize = 4096;
            //    byte[] buffer = new byte[bufferSize];
            //    int bytesRead;

            //    while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
            //    {
            //        Response.OutputStream.Write(buffer, 0, bytesRead);
            //        Response.Flush();
            //    }
            //}

            //   Response.End();



            //memoryStream.Close();

            return View();
        }
        private void ReducePdfSize(string inputPdfPath, string outputPdfPath)
        {
            using (var reader = new PdfReader(inputPdfPath))
            using (var fs = new FileStream(outputPdfPath, FileMode.Create))
            using (var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10))
            using (var writer = PdfWriter.GetInstance(document, fs))
            {
                document.Open();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    var page = writer.GetImportedPage(reader, i);
                    document.NewPage();
                    document.Add(iTextSharp.text.Image.GetInstance(page));
                }

                document.Close();
            }
        }


        [OutputCache(Duration = 3600)]
        public async Task<ActionResult> PrintBarcodeInPdfNew(string documentId)
        {
            string textToAdd = "";
            string fileName = "";

            IEnumerable<DocketBarcodeDetail> obj = this.docketRepository.GetDocketBarcodeGetById(documentId);

            foreach (var item in obj)
            {
                fileName = item.DocketNo + ".pdf";
                break;
            }

            // Create a new document with custom dimensions
            iTextSharp.text.Document document = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(iTextSharp.text.Utilities.MillimetersToPoints(80), iTextSharp.text.Utilities.MillimetersToPoints(55)));

            // Specify the output path for the PDF
            string outputPath = Server.MapPath("~/Storage/" + fileName);// @"D:\Solutions\RND\CustomSizePDF.pdf";
            // string outputPath = Server.MapPath("~/Storage/") + fileName;
            // Create a PdfWriter instance to write to the document
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            //MemoryStream memoryStream = new MemoryStream();
            //PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            // Create a new MemoryStream to hold the PDF content
            //MemoryStream memoryStream = new MemoryStream();
            //PdfWriter writer1 = PdfWriter.GetInstance(document, memoryStream);
            // Return the PDF file for download
            //return File(memoryStream, "application/pdf", "GeneratedPDF.pdf");
            //@Html.ActionLink("Download PDF", "DownloadPdf", "Pdf")

            // Open the document for writing
            document.Open();
            int totalPkt = ((List<DocketBarcodeDetail>)obj).Count;
            //   long barcode = 38000356216;
            List<DocketBarcodeDetail> ItemList = (List<DocketBarcodeDetail>)obj;


            int index = 0;

            await Task.WhenAll(Enumerable.Range(1, totalPkt).Select(async i =>
            {
                DocketBarcodeDetail item = ItemList[i - 1];

                PdfContentByte contentByte = writer.DirectContent;

                // Set the rectangle coordinates and dimensions
                float x = 10;      // x-coordinate of the lower-left corner
                float y = 5;      // y-coordinate of the lower-left corner
                float width = document.PageSize.Width - 20; //200;  // Width of the rectangle
                float height = document.PageSize.Height - 10;// 100; // Height of the rectangle

                // Draw the rectangle
                contentByte.Rectangle(x, y, width, height);
                contentByte.Stroke(); // Draw the outline

                // Set the coordinates
                int xco = (Convert.ToInt32(document.PageSize.Width) / 3) - 20; // x-coordinate
                int yco = Convert.ToInt32(document.PageSize.Height) - 20; // y-coordinate
                iTextSharp.text.Font font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD);// new iTextSharp.text.Font();
                yco = yco - 10;
                // Add barcode image to the PDF
                string logoFile = Server.MapPath("~/assets/images/logo.png");

                iTextSharp.text.Image logoImagePDF = iTextSharp.text.Image.GetInstance(logoFile);
                logoImagePDF.SetAbsolutePosition(xco, yco);
                logoImagePDF.ScaleAbsolute(100, 22);
                contentByte.AddImage(logoImagePDF);



                //textToAdd = item.CompanyName;// "Spanda Logistics Private Limited";
                //ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, font), xco, yco, 0);



                BarcodeLib.Barcode barcodeAPI = new BarcodeLib.Barcode();

                // Define basic settings of the image
                int imageWidth = 200;
                int imageHeight = 30;
                System.Drawing.Color foreColor = System.Drawing.Color.Black;
                System.Drawing.Color backColor = System.Drawing.Color.Transparent;
                //string data = obj.BarCode;
                System.Drawing.Image barcodeImage = barcodeAPI.Encode(TYPE.CODE128, item.BarCode, foreColor, backColor, imageWidth, imageHeight);

                // Add barcode image to the PDF
                iTextSharp.text.Image barcodeImagePDF = iTextSharp.text.Image.GetInstance(barcodeImage, BaseColor.WHITE);
                xco = 15;
                yco = yco - 35;
                barcodeImagePDF.SetAbsolutePosition(xco, yco);
                contentByte.AddImage(barcodeImagePDF);

                iTextSharp.text.Font fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 80;
                yco = yco - 10;
                textToAdd = item.BarCode;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                yco = yco - 5;
                // Set the starting and ending points of the line
                float x1 = 10; // x-coordinate of the starting point
                float y1 = yco; // y-coordinate of the starting point
                float x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                float y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Docket No
                fontCus = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.DocketNo;//  "2324BGL004567";
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                // Add Docket No
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);// new iTextSharp.text.Font(); 
                xco = 150;
                //yco = yco-12;
                textToAdd = "Pkt. " + item.sno + "/" + totalPkt.ToString();
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                yco = yco - 5;
                // Set the starting and ending points of the line
                x1 = 10; // x-coordinate of the starting point
                y1 = yco; // y-coordinate of the starting point
                x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Location
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.FromCity + " - " + item.ToCity;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                //// Add Customer
                //fontCus = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                //xco = 40;
                //yco = yco-12;
                //textToAdd = item.CustomerName;
                //ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                yco = yco - 5;
                // Set the starting and ending points of the line
                x1 = 10; // x-coordinate of the starting point
                y1 = yco; // y-coordinate of the starting point
                x2 = document.PageSize.Width - 10; // x-coordinate of the ending point
                y2 = yco; // y-coordinate of the ending point

                // Draw the line
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();

                // Add Consignor
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.ConsignorName;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);

                // Add Consignee
                fontCus = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC);// new iTextSharp.text.Font(); 
                xco = 40;
                yco = yco - 12;
                textToAdd = item.ConsigneeName;
                ColumnText.ShowTextAligned(contentByte, Element.ALIGN_LEFT, new iTextSharp.text.Phrase(textToAdd, fontCus), xco, yco, 0);


                if (index != totalPkt)
                {
                    document.NewPage();
                }
                index = index + 1;


                // Simulate some processing time for demonstration purposes
                await Task.Delay(100);
            }));

            foreach (var item in obj)
            {
                // fileName = item.DocketNo+".pdf";

                // Get the content byte of the PDF

            }

            // Close the document
            document.Close();

            //memoryStream.Close();
            //memoryStream.Position = 0;
            //return File(memoryStream.GetBuffer(), "application/pdf", "GeneratedPDF.pdf");
            byte[] bytes = System.IO.File.ReadAllBytes(outputPath);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            //Response.BinaryWrite(memoryStream.ToArray());
            // Write the PDF to the response stream
            // memoryStream.Seek(0, SeekOrigin.Begin);
            // memoryStream.CopyTo(Response.OutputStream);
            // Clean up the memory stream
            //memoryStream.Dispose();

            //            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();

            //using (FileStream fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            //{
            //    // Set the content type and file name for the response
            //    Response.ContentType = "application/pdf";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename="+fileName);

            //    // Read and write the file in chunks to prevent memory issues
            //    const int bufferSize = 4096;
            //    byte[] buffer = new byte[bufferSize];
            //    int bytesRead;

            //    while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
            //    {
            //        Response.OutputStream.Write(buffer, 0, bytesRead);
            //        Response.Flush();
            //    }
            //}

            //   Response.End();



            //memoryStream.Close();

            return View();
        }

        public ActionResult GenerateBarCode(int barcodeIndex)
        {
            string FileLoc = "";
            string barcode = "";
            string StartCode = "";
            string EndCode = "";
            long sCode, eCode;
            int i = 1;

            StartCode = "";
            EndCode = "";
            sCode = 0;
            eCode = 0;


            BarCodeModel objMaster = new BarCodeModel();

            IEnumerable<BarCodeModel> obj = this.docketRepository.GetBarCode(barcodeIndex, SessionUtility.CompanyId.ToString());

            foreach (var index in obj)
            {
                FileLoc = Server.MapPath("~/Storage/BarCode/");
                if (System.IO.Directory.Exists(FileLoc)) { }
                else
                {
                    System.IO.Directory.CreateDirectory(FileLoc);
                }
                barcode = index.BarCode;
                FileLoc = FileLoc + index.BarCodeFile;

                GenerateCode(FileLoc, barcode);

                BarCodeModel objItem = new BarCodeModel();
                objItem.BarCode = barcode;
                objItem.BarCodeFile = index.BarCodeFile;
                objMaster.Details.Add(objItem);

                if (i == 1)
                {
                    StartCode = barcode;
                }

                EndCode = barcode;

                i = i + 1;
            }

            if (StartCode != "" & EndCode != "")
            {
                StartCode = StartCode.Substring(4);
                EndCode = EndCode.Substring(4);
                long.TryParse(StartCode, out sCode);
                long.TryParse(EndCode, out eCode);
            }

            ((dynamic)base.ViewBag).sCode = sCode;
            ((dynamic)base.ViewBag).eCode = eCode;
            return View(objMaster);
        }

        [HttpPost]
        public ActionResult GenerateBarCode(string barcode)
        {

            return View();
        }
        private void GenerateCode(string FileLoc, string barcode)
        {

            // Create an instance of the API
            BarcodeLib.Barcode barcodeAPI = new BarcodeLib.Barcode();

            // Define basic settings of the image
            int imageWidth = 290;
            int imageHeight = 120;
            System.Drawing.Color foreColor = System.Drawing.Color.Black;
            System.Drawing.Color backColor = System.Drawing.Color.Transparent;
            string data = barcode; //"038000356216";

            // Generate the barcode with your settings
            System.Drawing.Image barcodeImage = barcodeAPI.Encode(TYPE.CODE128, data, foreColor, backColor, imageWidth, imageHeight);

            // Store image in some path with the desired format
            barcodeImage.Save(FileLoc, ImageFormat.Png);

            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    using (Bitmap bitMap = new Bitmap(barcode.Length * 30, 80))
            //    {
            //        using (Graphics graphics = Graphics.FromImage(bitMap))
            //        {
            //            Font oFont = new Font("IDAutomationHC39M Free Version", 16);
            //            PointF point = new PointF(2f, 2f);
            //            SolidBrush whiteBrush = new SolidBrush(Color.White);
            //            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
            //            SolidBrush blackBrush = new SolidBrush(Color.DarkBlue);
            //            graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
            //            graphics.DrawString("Simply Logistics", oFont, blackBrush, point);

            //        }
            //        bitMap.Save(memoryStream, ImageFormat.Jpeg);
            //        bitMap.Save(FileLoc, System.Drawing.Imaging.ImageFormat.Gif);
            //        ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
            //    }
            //}
        }

        public JsonResult GetStep5DetailSimply(string ContractId, string TransportModeId, string InvoiceNo, string ServiceTypeId)
        {
            Docket docket = new Models.Docket();

            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (TransportModeId != "") docket.TransportModeId = TransportModeId.ConvertToByte();
            if (InvoiceNo != "") docket.WmsInvoiceNo = InvoiceNo;
            if (ServiceTypeId != "") docket.ServiceTypeId = ServiceTypeId.ConvertToByte();

            return base.Json(this.docketRepository.GetStep5DetailSimply(docket));
        }


        [HttpPost]
        public JsonResult GetStep6DetailSimply(string DocketDate, string ContractId, string TransportModeId, string PaybasId, string ServiceTypeId,
            string BusinessTypeId, string ProductTypeId, string PackagingTypeId, string FtlTypeId, string FromLocationId, string ToLocationId,
            string FromCityId, string ToCityId, string ConsignorId, string ConsigneeId, string ActualWeight, string ChargedWeight, string Packages,
            string InvoiceAmount, string CODCollectableAmount, string IsOda, string IsCod, string IsDacc, string IsLocal, string IsCarrierRisk, string IsDoorDelivery,
            string IsBooking, string IsMultiPickup, string IsMultiDelivery, string ApplyRateType, string ContractSlabId, string handlingChargedWeight
            )
        {
            Docket docket = new Models.Docket();

            if (DocketDate != "") docket.DocketDate = DocketDate.ConvertToDateTime();
            if (ContractId != "") docket.ContractId = ContractId.ConvertToShort();
            if (TransportModeId != "") docket.TransportModeId = TransportModeId.ConvertToByte();
            if (PaybasId != "") docket.PaybasId = PaybasId.ConvertToByte();
            if (ServiceTypeId != "") docket.ServiceTypeId = ServiceTypeId.ConvertToByte();
            if (BusinessTypeId != "") docket.BusinessTypeId = BusinessTypeId.ConvertToByte();
            if (ProductTypeId != "") docket.ProductTypeId = ProductTypeId.ConvertToByte();
            if (PackagingTypeId != "") docket.PackagingTypeId = PackagingTypeId.ConvertToByte();
            if (FtlTypeId != "") docket.FtlTypeId = FtlTypeId.ConvertToByte();
            if (FromLocationId != "") docket.FromLocationId = FromLocationId.ConvertToShort();
            if (ToLocationId != "") docket.ToLocationId = ToLocationId.ConvertToShort();
            if (FromCityId != "") docket.FromCityId = FromCityId.ConvertToShort();
            if (ToCityId != "") docket.ToCityId = ToCityId.ConvertToShort();
            if (ConsignorId != "") docket.ConsignorId = ConsignorId.ConvertToShort();
            if (ConsigneeId != "") docket.ConsigneeId = ConsigneeId.ConvertToShort();
            if (ActualWeight != "") docket.ActualWeight = ActualWeight.ConvertToDecimal();
            if (ChargedWeight != "") docket.ChargedWeight = ChargedWeight.ConvertToDecimal();
            if (Packages != "") docket.Packages = Packages.ConvertToInt();
            if (InvoiceAmount != "") docket.InvoiceAmount = InvoiceAmount.ConvertToDecimal();
            if (CODCollectableAmount != "") docket.CODCollectableAmount = CODCollectableAmount.ConvertToDecimal();
            if (IsOda != "") docket.IsOda = IsOda.ConvertToBool();
            if (IsCod != "") docket.IsCod = IsCod.ConvertToBool();
            if (IsDacc != "") docket.IsDacc = IsDacc.ConvertToBool();
            if (IsLocal != "") docket.IsLocal = IsLocal.ConvertToBool();
            if (IsCarrierRisk != "") docket.IsCarrierRisk = IsCarrierRisk.ConvertToBool();
            if (IsDoorDelivery != "") docket.IsDoorDelivery = IsDoorDelivery.ConvertToBool();
            if (IsBooking != "") docket.IsBooking = IsBooking.ConvertToBool();
            if (IsMultiPickup != "") docket.IsMultiPickup = IsMultiPickup.ConvertToBool();
            if (IsMultiDelivery != "") docket.IsMultiDelivery = IsMultiDelivery.ConvertToBool();
            if (ApplyRateType != "") docket.ApplyRateType = ApplyRateType;
            if (ContractSlabId != "") docket.ContractSlabId = ContractSlabId;
            if (handlingChargedWeight != "") docket.handlingChargedWeight = handlingChargedWeight;
            //
            return base.Json(this.docketRepository.GetStep6DetailSimply(docket));
        }

        public ActionResult InsertSimply(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            ((dynamic)base.ViewBag).HandOverVendor = vendorRepository.GetVendorNameList();
            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertSimply(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                ((dynamic)base.ViewBag).HandOverVendor = vendorRepository.GetVendorNameList();
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertSimplyDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertSimplyDone()
        {
            return base.View();
        }

        public ActionResult UpdateSimply()
        {
            return base.View();
        }
        public ActionResult UploadInSystemBarcodeLBH()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemBarcodeLBH(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadInSystemBarcodeLBH(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }



        public ActionResult UploadInSystemByContract()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemByContract(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadInSystemByContract(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        [HttpPost]
        public JsonResult CheckValidDocketNoForScanIn(string docketNo)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CheckValidDocketNoForScanIn(docketNo));
            return jsonResult;
        }


        public ActionResult PendingPickupRequestList()
        {
            return base.View(this.docketRepository.PickupRequestGetAll(SessionUtility.LoginUserId, "PendingList"));
        }
        public ActionResult PickupRequestList()
        {
            return base.View(this.docketRepository.PickupRequestGetAll(SessionUtility.LoginUserId, "User"));
        }
        public ActionResult PickupRequestView(long? id)
        {
            ActionResult httpStatusCodeResult;
            if (id.HasValue)
            {
                PickupRequest detailById = this.docketRepository.PickupRequestById(id.Value);
                if (detailById != null)
                {
                    httpStatusCodeResult = base.View(detailById);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        public ActionResult PickupRequest()
        {
            MasterUser user = this.userRepository.GetById(SessionUtility.LoginUserId);

            if (user.UserTypeId != "2")
            {
                ((dynamic)base.ViewBag).OptionEnabled = "N";
            }
            else
            {
                ((dynamic)base.ViewBag).OptionEnabled = "Y";
            }
            ((dynamic)base.ViewBag).UserTypeMapCode = user.UserTypeMapCode;
            ((dynamic)base.ViewBag).UserTypeMapName = user.UserTypeMapName;
            ((dynamic)base.ViewBag).UserTypeMapId = user.UserTypeMapId;

            return base.View();
        }

        [HttpPost]
        public ActionResult PickupRequest(PickupRequest obj)
        {
            obj.EntryBy = SessionUtility.LoginUserId;
            obj.EntryDate = DateTime.Now;
            obj.LocationId = SessionUtility.LoginLocationId;
            Response response = this.docketRepository.InsertPickupRequest(obj);
            if (response.IsSuccessfull)
            {
                ActionResult action = base.RedirectToAction("PickupRequestView", new { id = response.DocumentId });
                return action;
            }
            return base.View(obj);
        }

        public ActionResult UploadInSystemKExpress()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemKExpress(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadInSystemKExpress(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        private bool GenerateDocketBarCode(string DocketId, string barcode)
        {
            string FileLoc = "";
            bool rValue;
            try
            {
                FileLoc = Server.MapPath("~/Storage/BarCode/");

                if (System.IO.Directory.Exists(FileLoc)) { }
                else
                {
                    System.IO.Directory.CreateDirectory(FileLoc);
                }

                FileLoc = FileLoc + DocketId + ".png";

                GenerateCode(FileLoc, barcode);
                rValue = true;
            }
            catch (Exception ex)
            {
                rValue = false;
            }
            return rValue;
        }


        public ActionResult eWayBillUpdateVehicle(string Eway_bill_number)
        {
            MastersIndiaEway obj = this.docketRepository.getEwayBillData(Eway_bill_number);
            ActionResult httpStatusCodeResult = base.View(obj);
            //            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ErrorMessage = "";
            return httpStatusCodeResult;
        }


        [HttpPost]
        public ActionResult eWayBillUpdateVehicle(MastersIndiaEway objEway)
        {
            objEway.vehicle_type = VehicleType(objEway.mode_of_transport);
            objEway.reason_code_for_vehicle_updation = VehicleUpdateReasonCode(objEway.extend_validity_reason);
            objEway.mode_of_transport = "road";
            Response response = this.docketRepository.UpdateVehicleeWayBill(objEway);
            if (response.IsSuccessfull)
            {
                ActionResult action = base.RedirectToAction("eWayBillView", new { Eway_bill_number = response.DocumentNo });
                ((dynamic)base.ViewBag).ErrorMessage = "";
                return action;
            }
            else
            {
                //                ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
                ((dynamic)base.ViewBag).ErrorMessage = response.ErrorMessage;
            }
            return base.View();
        }
        public ActionResult eWayBillExtend(string Eway_bill_number)
        {
            MastersIndiaEway obj = this.docketRepository.getEwayBillData(Eway_bill_number);
            ActionResult httpStatusCodeResult = base.View(obj);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ErrorMessage = "";
            return httpStatusCodeResult;
        }

        [HttpPost]
        public ActionResult eWayBillExtend(MastersIndiaEway objEway)
        {
            objEway.mode_of_transport = TransportMode(objEway.mode_of_transport);
            objEway.extend_validity_reason = Reasonsforextension(objEway.extend_validity_reason);

            Response response = this.docketRepository.InserteWayBill(objEway);
            if (response.IsSuccessfull)
            {
                ActionResult action = base.RedirectToAction("eWayBillView", new { Eway_bill_number = response.DocumentNo });
                ((dynamic)base.ViewBag).ErrorMessage = "";
                return action;
            }
            else
            {
                ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
                ((dynamic)base.ViewBag).ErrorMessage = response.ErrorMessage;
            }
            return base.View();
        }

        [HttpPost]
        public JsonResult CalculateDistance(string fromPincode, string toPincode)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.CalculateDistance(fromPincode, toPincode));
            return jsonResult;
        }

        public ActionResult ImportManualEWayBill()
        {
            ((dynamic)base.ViewBag).ErrorMessage = "";
            ActionResult httpStatusCodeResult = base.View();
            return httpStatusCodeResult;
        }

        [HttpPost]
        public ActionResult ImportManualEWayBill(MastersIndiaEway objEway)
        {
            Response response = this.docketRepository.ImportManualEWayBill(objEway.eway_bill_number);
            if (response.IsSuccessfull)
            {
                ActionResult action = base.RedirectToAction("eWayBillView", new { Eway_bill_number = response.DocumentNo });
                ((dynamic)base.ViewBag).ErrorMessage = "";
                return action;
            }
            return base.View();
        }

        private string VehicleType(string code)
        {
            string vehicleType = "";

            if (code == "1")
                vehicleType = "regular";
            else
                vehicleType = "over dimensional cargo";

            return vehicleType;
        }
        private string VehicleUpdateReasonCode(string code)
        {
            string Reason = "";

            if (code == "1")
                Reason = "Due to Break Down";
            else if (code == "2")
                Reason = "Due to Transhipment";
            else if (code == "3")
                Reason = "Others";
            else if (code == "4")
                Reason = "Accident";
            else
                Reason = "First Time";

            return Reason;
        }
        private string Reasonsforextension(string code)
        {
            string Reason = "";

            if (code == "1")
                Reason = "Natural Calamity";
            else if (code == "2")
                Reason = "Law and Order Situation";
            else if (code == "3")
                Reason = "Transhipment";
            else if (code == "4")
                Reason = "Accident";
            else
                Reason = "Other";

            return Reason;
        }
        private string TransportMode(string code)
        {
            string Mode = "";

            if (code == "1")
                Mode = "Road";
            else if (code == "2")
                Mode = "Rail";
            else if (code == "3")
                Mode = "Air";
            else if (code == "4")
                Mode = "4";
            else
                Mode = "";

            return Mode;
        }

        public ActionResult DownloadConsolidateeWayBillPdf(string tripNo)
        {
            //string tripNo = "5010005157";

            Task<byte[]> taskEx = Task.Run<byte[]>(async () => await this.docketRepository.TaxProPrintEwayConsolidated(tripNo));
            byte[] pdfBytes = taskEx.Result;


            string contentType = "application/pdf";
            string fileName = "Consolidated E-Way Bill" + tripNo + ".pdf";

            return File(pdfBytes, contentType, fileName);
        }

        public ActionResult eWayConsolidateTaxProList()
        {
            IEnumerable<TaxProEwayTripSheetApiResponse> obj = this.docketRepository.TaxProGetEwayBillConsolidateList(SessionUtility.LoginUserId.ToString());

            return base.View(obj);
        }
        public ActionResult DocketBarcodeList()
        {
            IEnumerable<DocketBarcodeDetail> obj = this.docketRepository.DocketBarcodeList(SessionUtility.LoginUserId.ToString());

            return base.View(obj);
        }
        public ActionResult DocketBarcodeNameList()
        {
            IEnumerable<DocketBarcodeDetail> obj = this.docketRepository.DocketBarcodeList(SessionUtility.LoginUserId.ToString());

            return base.View(obj);
        }


        public ActionResult eWayTaxProList()
        {
            //string LoginUserId = SessionUtility.LoginUserId.ToString();
            //TaxProEwayConsolidated req = new TaxProEwayConsolidated();
            //   List<TaxProEwayTripSheetEwbBills> lsttripSheetEwbBills = new List<TaxProEwayTripSheetEwbBills>();
            //TaxProEwayTripSheetEwbBills tripSheetEwbBills;


            //req.fromPlace = "BANGALORE SOUTH";
            //req.fromState = "34";
            //req.vehicleNo = "KA12AB1234";
            //req.transMode = "1";
            //req.transDocNo = "1238";
            //req.transDocDate = "19/08/2023";

            //tripSheetEwbBills  = new TaxProEwayTripSheetEwbBills();
            //tripSheetEwbBills.ewbNo = "551008891665";
            //lsttripSheetEwbBills.Add(tripSheetEwbBills);

            //tripSheetEwbBills  = new TaxProEwayTripSheetEwbBills();
            //tripSheetEwbBills.ewbNo = "521008891666";
            //lsttripSheetEwbBills.Add(tripSheetEwbBills);
            //req.tripSheetEwbBills = lsttripSheetEwbBills;


            //Task<TaxProEwayConsolidateApiResponse> taskEx = Task.Run<TaxProEwayConsolidateApiResponse>(async () => await this.docketRepository.TaxProEwayConsolidated(req, LoginUserId));
            //TaxProEwayConsolidateApiResponse objTaskEx = taskEx.Result;

            //string tripNo = "5010005157";

            //Task<string> taskEx = Task.Run<string>(async () => await this.docketRepository.TaxProPrintEwayConsolidated(tripNo));
            //string objTaskEx = taskEx.Result;



            //return View();


            //TaxProGetEwayForTransporterByStateRequest transporterRequest = new TaxProGetEwayForTransporterByStateRequest();

            //transporterRequest.date = "20230812";
            //transporterRequest.statecode = "34";
            //transporterRequest.gstIn = "34AACCC1596Q002";
            //List<TaxProGetEwayDetailsForTransporterByStateApiResponse> obj = new List<TaxProGetEwayDetailsForTransporterByStateApiResponse>();
            //Task<IEnumerable<TaxProGetEwayForTransporterByStateApiResponse>> task = Task.Run<IEnumerable<TaxProGetEwayForTransporterByStateApiResponse>>(async () => await this.docketRepository.GetEwayBillsForTransporterByState(transporterRequest));
            //IEnumerable<TaxProGetEwayForTransporterByStateApiResponse> objTask = task.Result;

            //if (objTask != null)
            //{
            //    foreach (var item in objTask)
            //    {
            //        if (item.ewaydtl != null)
            //            obj = item.ewaydtl;
            //    }
            //}

            IEnumerable<TaxProGetEwayDetailsForTransporterByStateApiResponse> obj = this.docketRepository.TaxProGetEwayBillList(SessionUtility.LoginUserId.ToString());

            return base.View(obj);
        }


        public ActionResult eWayWebtelList()
        {
            List<EwbDetail> obj = new List<EwbDetail>();
            IEnumerable<GetEwayForTransporter> mainObj = GetEwayBill1();

            foreach (var item in mainObj)
            {
                if (item.ewbDetails != null)
                    obj = item.ewbDetails;
            }
            return base.View((IEnumerable<EwbDetail>)obj);
        }

        private IEnumerable<GetEwayForTransporter> GetEwayBill1()
        {
            GetEwayForTransporterRequest transporterRequest = new GetEwayForTransporterRequest()
            {
                GSTIN = System.Configuration.ConfigurationManager.AppSettings["WebtelGSTIN"].ToString(),
                Date = "20230617",
                EWBUserName = System.Configuration.ConfigurationManager.AppSettings["WebtelGSPEwbUserName"].ToString(),
                EWBPassword = System.Configuration.ConfigurationManager.AppSettings["WebtelGSPEwbPassword"].ToString(),
                Year = 2023,
                Month = 7,
                EFUserName = System.Configuration.ConfigurationManager.AppSettings["WebtelEFUserName"].ToString(),
                EFPassword = System.Configuration.ConfigurationManager.AppSettings["WebtelEFPassword"].ToString(),
                CDKey = System.Configuration.ConfigurationManager.AppSettings["WebtelCDKey"].ToString()
            };
            string baseURL = System.Configuration.ConfigurationManager.AppSettings["WebtelBaseUrl"].ToString();
            var response = this.docketRepository.GetEWBForTransporter(transporterRequest, baseURL);
            return response;
        }

        public ActionResult eWayBillViewTaxPro(string ewbNo)
        {
            TaxProGetEwayDetailsForTransporterByStateApiResponse obj = this.docketRepository.TaxProGetEwayDetails(ewbNo);
            return base.View(obj);
        }
        public ActionResult eWayBillView(string Eway_bill_number)
        {
            MastersIndiaEway obj = this.docketRepository.getEwayBillData(Eway_bill_number);
            ActionResult httpStatusCodeResult = base.View(obj);

            return httpStatusCodeResult;
        }
        public JsonResult GetEwayBillData(string Eway_bill_number)
        {
            Task<TaxProGetEwayApiResponse> task = Task.Run<TaxProGetEwayApiResponse>(async () => await this.docketRepository.ValidateTaxProEwayBill(Eway_bill_number));
            TaxProGetEwayApiResponse objTask = task.Result;

            if(objTask == null)
            {

            }

           // MastersIndiaEway obj = this.docketRepository.eWayBillView(Eway_bill_number);

            return base.Json(objTask);
        }


        public ActionResult UpdateSpeedFox()
        {

            Task<string> taskEx = Task.Run<string>(async () => await this.docketRepository.RivigoBookingCreate());
            string objTaskEx = taskEx.Result;

            return base.View();
        }

        public ActionResult InsertSpeedFoxDone()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult InsertSpeedFox(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.Insert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.Insert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertSpeedFoxDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }

        public ActionResult InsertSpeedFox(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public JsonResult GetEwayBillDetails(string Eway_bill_number)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetEwayBillDetails(Eway_bill_number));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsInvoiceNoAvailable(long docketId, long invoiceId, string invoiceNo, short customerId)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.IsInvoiceNoAvailable(docketId, invoiceId, invoiceNo, customerId));
            return jsonResult;
        }

        public ActionResult UploadSpeedFox()
        {
            return base.View(new DocketUpload());
        }
        [HttpPost]
        public ActionResult UploadSpeedFox(DocketUpload objDocketUpload)
        {
            DocketUpload docketUpload = new DocketUpload()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUpload docketUpload1 = docketUpload;
            if (objDocketUpload.File != null)
            {
                objDocketUpload.EntryBy = SessionUtility.LoginUserId;
                docketUpload1 = this.docketRepository.UploadSpeedFox(objDocketUpload);
            }
            return base.View(docketUpload1);
        }

        public ActionResult UploadInSystemSolex()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemSolex(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadSolex(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        public ActionResult UploadMCLS()
        {
            return base.View(new DocketUpload());
        }
        [HttpPost]
        public ActionResult UploadMCLS(DocketUpload objDocketUpload)
        {
            DocketUpload docketUpload = new DocketUpload()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUpload docketUpload1 = docketUpload;
            if (objDocketUpload.File != null)
            {
                objDocketUpload.EntryBy = SessionUtility.LoginUserId;
                docketUpload1 = this.docketRepository.UploadMCLS(objDocketUpload);
            }
            return base.View(docketUpload1);
        }

        #region UploadDocketTripsheetCartonSolex
        public ActionResult UploadInSystemDocketCartonSolex()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemDocketCartonSolex(DocketUploadInSystem objDocketUploadTripsheetCarton, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadTripsheetCarton = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadTripsheetCarton1 = docketUploadTripsheetCarton;
            objDocketUploadTripsheetCarton.File = file;

            if (objDocketUploadTripsheetCarton.File != null)
            {
                objDocketUploadTripsheetCarton.EntryBy = SessionUtility.LoginUserId;
                docketUploadTripsheetCarton1 = this.docketRepository.UploadDocketTripsheetCarton(objDocketUploadTripsheetCarton);
            }
            return base.View(docketUploadTripsheetCarton1);
        }
        #endregion

        #region UploadInSystemDocketCartonEssential
        public ActionResult UploadInSystemDocketCartonEssential()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemDocketCartonEssential(DocketUploadInSystem objDocketUploadTripsheetCarton, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadTripsheetCarton = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadTripsheetCarton1 = docketUploadTripsheetCarton;
            objDocketUploadTripsheetCarton.File = file;

            if (objDocketUploadTripsheetCarton.File != null)
            {
                objDocketUploadTripsheetCarton.EntryBy = SessionUtility.LoginUserId;
                docketUploadTripsheetCarton1 = this.docketRepository.UploadDocketTripsheetCartonEssential(objDocketUploadTripsheetCarton);
            }
            return base.View(docketUploadTripsheetCarton1);
        }
        #endregion

        #region UploadDocketTripsheetCartonHarshita

        public ActionResult UploadInSystemHarshita()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemHarshita(DocketUploadInSystem objDocketUploadInSystem, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadInSystem = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadInSystem1 = docketUploadInSystem;
            objDocketUploadInSystem.File = file;

            if (objDocketUploadInSystem.File != null)
            {
                objDocketUploadInSystem.EntryBy = SessionUtility.LoginUserId;
                docketUploadInSystem1 = this.docketRepository.UploadHarshita(objDocketUploadInSystem);
            }
            return base.View(docketUploadInSystem1);
        }

        public ActionResult UploadInSystemDocketCartonHarshita()
        {
            return base.View(new DocketUploadInSystem());
        }

        [HttpPost]
        public ActionResult UploadInSystemDocketCartonHarshita(DocketUploadInSystem objDocketUploadTripsheetCarton, HttpPostedFileBase file)
        {
            DocketUploadInSystem docketUploadTripsheetCarton = new DocketUploadInSystem()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            DocketUploadInSystem docketUploadTripsheetCarton1 = docketUploadTripsheetCarton;
            objDocketUploadTripsheetCarton.File = file;

            if (objDocketUploadTripsheetCarton.File != null)
            {
                objDocketUploadTripsheetCarton.EntryBy = SessionUtility.LoginUserId;
                docketUploadTripsheetCarton1 = this.docketRepository.UploadDocketTripsheetCarton(objDocketUploadTripsheetCarton);
            }
            return base.View(docketUploadTripsheetCarton1);
        }
        #endregion 

        public ActionResult InsertMLPL(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        public JsonResult GetDocketBarcodeInfo(long docketId)
        {
            return Json(docketRepository.GetDocketBarcodeInfo(docketId));
        }

        [HttpPost]
        public ActionResult InsertMLPL(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    //if (partList.PartId > 0)
                    //{
                        partList.InvoiceId = num;
                    //}
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.DumptcoDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.DumptcoDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertMLPLDocketDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });

                List<ReportParameter> reportParameter = new List<ReportParameter>();
                reportParameter.Add(new ReportParameter("DocketId", Convert.ToString(response.DocumentId)));

                Docket docket = new Docket();
                docket = docketRepository.GetDetailById(response.DocumentId, SessionUtility.CompanyId);
                List<DocketInvoice> docketInvoice = new List<DocketInvoice>();
                docketInvoice = docketRepository.GetInvoiceDetails(response.DocumentId, SessionUtility.CompanyId).ToList();

                string mailBodyDocketInvoiceTable = string.Empty;
                foreach (var invoice in docketInvoice)
                {
                    mailBodyDocketInvoiceTable += "<tr>";

                    mailBodyDocketInvoiceTable += "<td>" + docket.DocketNo + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + invoice.InvoiceNo + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + invoice.Packages + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.FromLocation + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.ToLocation + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.ConsignorName + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.ConsigneeName + "</td>";

                    mailBodyDocketInvoiceTable += "</tr>";
                }

                string subject = "Booking Report Date - " + docket.DocketDate.ToString("dd MMM yyyy") + " " + docket.CustomerName;
                string mailBodyHtml = @"<html>
                        <body style=""font-size: 12px;font-family: Verdana; width:100%;"">Dear Sir/Madam,<br /> <br />
                        <p>We would like to inform you that our System has found consignments booked with us against your material as mentioned below:   <br /> <br /></p>
                        <table border=""1"" style=""border-collapse:collapse;"">
                        <tr>
                        <td> CN No. </td><td> Invoice No. </td><td> Pkgs. </td><td> Source </td><td> Destination </td><td> Consignor </td><td> Consignee </td>
                        </tr>
                        " + mailBodyDocketInvoiceTable + @"</table>
                        <p>Sincerely,<br>Mahalakshmi Logistic Pvt. Ltd.</br></p>
                      </body>
                      </html>
                     ";
                string attachementPath = ConfigHelper.LocalStoragePath + "Report\\" + response.DocumentNo + ".pdf";

                bool isReportPdfGenerated = SsrsHelper.ExportReportToPdf("DocketViewMail", attachementPath, reportParameter);
                var emailConfig = homeRepository.GetEmailConfig();

                if (emailConfig != null && isReportPdfGenerated)
                {
                    EmailHelper.SendEmail(emailConfig.FromMailAddress, docket.CustomerEmailId, subject, mailBodyHtml, true, attachementPath, emailConfig.Host, emailConfig.Port, emailConfig.UserName, emailConfig.Password, emailConfig.SslEnabled);
                }

                if (isReportPdfGenerated)
                    System.IO.File.Delete(attachementPath);
            }

            return action;
        }

        public ActionResult InsertMLPLDocketDone(long? documentId)
        {
            List<DocketPackages> docketPackages = new List<DocketPackages>();
            docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
            return base.View(docketPackages);
        }

        public ActionResult UpdateMLPL()
        {
            return base.View();
        }

        public ActionResult InsertEssential(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertEssential(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.EssentialDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.EssentialDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(25, 1) == "Y")
                {

                    Response docketresponse = this.docketRepository.CreatePktBarCode(response.DocumentId, "Docket");
                    if (docketresponse != null)
                    {
                        response.DocumentId3 = docketresponse.DocumentId;
                        response.DocumentNo3 = response.DocumentNo;
                    }
                }

                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 81) == "Y" && objDocket.CustomerId == 13)
                {
                    try
                    {
                        DocketTrackingResponseForFarEyeSuccess doketTrackingApiResponse = new DocketTrackingResponseForFarEyeSuccess();
                        DocketTrackingResponseForFarEyeFailure docketTrackingResponseForFarEye = new DocketTrackingResponseForFarEyeFailure();
                        string json = string.Empty;
                        doketTrackingApiResponse = trackingRepository.OrderTrackingForFarEye(response.DocumentNo);
                        if (doketTrackingApiResponse.order_no == null)
                        {
                            docketTrackingResponseForFarEye.order_no = response.DocumentNo;
                            docketTrackingResponseForFarEye.Status = "Not Found";
                            json = JsonConvert.SerializeObject(docketTrackingResponseForFarEye);
                        }
                        else
                            json = JsonConvert.SerializeObject(doketTrackingApiResponse);
                        CallFareyeWebhook(response.DocumentId, json);
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.LogException(ex, "Call Fareye Webhook", SessionUtility.LoginUserId, nameof(InsertEssential));
                    }
                    finally
                    {
                        action = base.RedirectToAction("InsertEssentialDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
                    }
                }
                action = base.RedirectToAction("InsertEssentialDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }
            return action;
        }

        public ActionResult InsertEssentialDone(long? documentId)
        {
            List<DocketPackages> docketPackages = new List<DocketPackages>();
            docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
            return base.View(docketPackages);
        }

        public ActionResult UpdateEssential()
        {
            return base.View();
        }

        public async Task CallFareyeWebhook(long docketId, string payloadData)
        {
            try
            {
                // Replace 'webhookUrl' with your actual webhook endpoint URL
                string webhookUrl = "https://api.fareyeconnect.com/carrier/v1/essential/webhook";
                string bearerToken = "33b2b59b-0201-4814-96c8-484e55be46b5";

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(webhookUrl);
                    // Set the Bearer Token in the request's authorization header
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

                    // Set the content type to application/json if your webhook expects JSON data
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a StringContent with your payload data and the desired encoding (UTF8 in this case)
                    var content = new StringContent(payloadData, Encoding.UTF8, "application/json");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                    // Make the HTTP POST request to the webhook
                    var response = httpClient.PostAsync(webhookUrl, content);
                    response.Wait();
                    var webhookResult = response.Result;
                    docketRepository.InsertFareyeWebhookResult(docketId, Convert.ToString(webhookResult));
                }

            }
            catch (Exception ex)
            {

            }

        }

        [HttpPost]
        public JsonResult IsEwayBillNoAvailable(string ewaybillNo)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.IsEwayBillNoAvailable(ewaybillNo));
            return jsonResult;
        }

        public JsonResult GetMappedBillingParty(short consignorId, short consigneeId)
        {
            JsonResult jsonResult = base.Json(this.docketRepository.GetMappedBillingParty(consignorId, consigneeId));
            return jsonResult;
        }

        public ActionResult InsertFalwings(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            ((dynamic)base.ViewBag).MappedBillingPartyList = this.customerRepository.GetCustomerListByLocation(SessionUtility.LoginLocationId);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            docket.InvoiceVolumetricList.Add(new InvoiceVolumetric());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertFalwings(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }

            int invoiceId = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i++)
            {
                invoiceId++;
                objDocket.InvoiceList[i].InvoiceId = invoiceId;
                int partId = 0;
                foreach (InvoicePart partItem in objDocket.InvoiceList[i].PartList)
                {
                    if (partItem.PartId <= 0)
                    {
                        partId++;
                        partItem.PartId = partId;
                        partItem.InvoiceId = invoiceId;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.DumptcoDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.DumptcoDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertFalwingsDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });
            }

            return action;
        }
        public ActionResult InsertFalwingsDone(long? documentId)
        {
            List<DocketPackages> docketPackages = new List<DocketPackages>();
            docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
            return base.View(docketPackages);
        }



        public ActionResult InsertMLPLV1(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }
        [HttpPost]
        public ActionResult InsertMLPLV1(Docket objDocket)
        {
            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.DumptcoDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.DumptcoDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertMLPLDocketDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2 });

                List<ReportParameter> reportParameter = new List<ReportParameter>();
                reportParameter.Add(new ReportParameter("DocketId", Convert.ToString(response.DocumentId)));

                Docket docket = new Docket();
                docket = docketRepository.GetDetailById(response.DocumentId, SessionUtility.CompanyId);
                List<DocketInvoice> docketInvoice = new List<DocketInvoice>();
                docketInvoice = docketRepository.GetInvoiceDetails(response.DocumentId, SessionUtility.CompanyId).ToList();

                string mailBodyDocketInvoiceTable = string.Empty;
                foreach (var invoice in docketInvoice)
                {
                    mailBodyDocketInvoiceTable += "<tr>";

                    mailBodyDocketInvoiceTable += "<td>" + docket.DocketNo + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + invoice.InvoiceNo + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + invoice.Packages + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.FromLocation + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.ToLocation + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.ConsignorName + "</td>";
                    mailBodyDocketInvoiceTable += "<td>" + docket.ConsigneeName + "</td>";

                    mailBodyDocketInvoiceTable += "</tr>";
                }

                string subject = "Booking Report Date - " + docket.DocketDate.ToString("dd MMM yyyy") + " " + docket.CustomerName;
                string mailBodyHtml = @"<html>
                        <body style=""font-size: 12px;font-family: Verdana; width:100%;"">Dear Sir/Madam,<br /> <br />
                        <p>We would like to inform you that our System has found consignments booked with us against your material as mentioned below:   <br /> <br /></p>
                        <table border=""1"" style=""border-collapse:collapse;"">
                        <tr>
                        <td> CN No. </td><td> Invoice No. </td><td> Pkgs. </td><td> Source </td><td> Destination </td><td> Consignor </td><td> Consignee </td>
                        </tr>
                        " + mailBodyDocketInvoiceTable + @"</table>
                        <p>Sincerely,<br>Mahalakshmi Logistic Pvt. Ltd.</br></p>
                      </body>
                      </html>
                     ";
                string attachementPath = ConfigHelper.LocalStoragePath + "Report\\" + response.DocumentNo + ".pdf";

                bool isReportPdfGenerated = SsrsHelper.ExportReportToPdf("DocketViewMail", attachementPath, reportParameter);
                var emailConfig = homeRepository.GetEmailConfig();

                if (emailConfig != null && isReportPdfGenerated)
                {
                    EmailHelper.SendEmail(emailConfig.FromMailAddress, docket.CustomerEmailId, subject, mailBodyHtml, true, attachementPath, emailConfig.Host, emailConfig.Port, emailConfig.UserName, emailConfig.Password, emailConfig.SslEnabled);
                }

                System.IO.File.Delete(attachementPath);
            }

            return action;
        }


        public ActionResult InsertD2D(long? id, bool? isFinancialUpdate)
        {
            Docket docket = new Docket();

            Session["ClickResponse"] = null;

            DocketStep1 step1Detail = this.docketRepository.GetStep1Detail(SessionUtility.LoginLocationId, SessionUtility.CompanyId);
            ((dynamic)base.ViewBag).Step1Details = JsonConvert.SerializeObject(step1Detail);
            ((dynamic)base.ViewBag).PaybasList = step1Detail.PaybasList;
            ((dynamic)base.ViewBag).DocketDateMinDate = step1Detail.DocketDateMinDate;
            ((dynamic)base.ViewBag).DocketDateMaxDate = step1Detail.DocketDateMaxDate;
            ((dynamic)base.ViewBag).IsFinancialUpdate = isFinancialUpdate;
            ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);

            string[] strArrays = new string[] { "Market", "Attached", "OWN" };
            ((dynamic)base.ViewBag).VendorTypeList = (
                from m in this.generalRepository.GetByIdList(29)
                where strArrays.Contains<string>(m.Name)
                select m).ToList<AutoCompleteResult>();
            if (!id.HasValue)
            {
                docket.DocketId = (long)0;
                docket.IsAdd = true;

                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(false);
            }
            else
            {
                docket.DocketId = id.Value;
                ((dynamic)base.ViewBag).DocketIdExts = JsonConvert.SerializeObject(true);
                // ((dynamic)base.ViewBag).DocketIdExts = id.Value;
            }
            docket.InvoiceList.Add(new DocketInvoice());
            docket.InvoiceList[0].PartList.Add(new InvoicePart());
            ((dynamic)base.ViewBag).CreateTripsheet = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 50) == "Y";
            return base.View(docket);
        }

        [HttpPost]
        public ActionResult InsertD2D(Docket objDocket)
        {

            ActionResult action;
            string str;

            if (objDocket.TransportModeId == 0)
            {
                this.ModelState.AddModelError("TransportModeId", "Transport Mode is not valid");
                return View(objDocket);
            }

            //if (this.ModelState.IsValid)
            //{
            objDocket.EntryBy = SessionUtility.LoginUserId;
            objDocket.EntryDate = DateTime.Now;
            objDocket.CompanyId = SessionUtility.CompanyId;
            //objDocket.CurrentLocationId = SessionUtility.LoginLocationId.ToString();
            objDocket.CurrentLocationId = objDocket.DocketId <= (long)0 ? SessionUtility.LoginLocationId.ToString() : objDocket.FromLocationId.ToString();

            //if (objDocket.ConsignorId == 1)
            //{
            //    MasterCustomer objMasterCustomer = new MasterCustomer();
            //    MasterCustomerDetail masterCustomerDetail = new MasterCustomerDetail();
            //    MasterCustomerAddressInfo masterCustomerAddressInfo = new MasterCustomerAddressInfo();
            //    objMasterCustomer.GroupCode = "C0001";
            //    objMasterCustomer.CustomerId = objDocket.CustomerId;
            //    objMasterCustomer.CustomerCode = objDocket.ConsignorCode;
            //    objMasterCustomer.CustomerName = objDocket.ConsignorName;
            //    objMasterCustomer.CompanyId = SessionUtility.CompanyId;
            //    objMasterCustomer.IsActive = true;
            //    masterCustomerDetail.PanNo = objDocket.ConsignorPanNo;
            //    masterCustomerDetail.GstTinNo = objDocket.ConsignorGstTinNo;
            //    masterCustomerDetail.MobileNo = objDocket.ConsignorMobileNo;
            //    masterCustomerDetail.EmailId = objDocket.ConsignorEmailId;
            //    masterCustomerDetail.PhoneNo = objDocket.ConsignorPhoneNo;
            //    masterCustomerAddressInfo.Address1 = objDocket.ConsignorAddress1;
            //    masterCustomerAddressInfo.CityId = objDocket.ConsignorCityId;
            //    masterCustomerAddressInfo.Pincode = objDocket.ConsignorPincode;
            //    masterCustomerDetail.EntryBy = SessionUtility.LoginUserId;
            //    masterCustomerDetail.CustomerTypeId = (byte)2;
            //    objMasterCustomer.MasterCustomerAddressInfo = masterCustomerAddressInfo;
            //    objMasterCustomer.MasterCustomerDetail = masterCustomerDetail;
            //    int customerId = customerRepository.Insert(objMasterCustomer);
            //    objDocket.ConsignorId = (short)customerId;
            //}

            //if (objDocket.ConsigneeId == 1)
            //{
            //    MasterCustomer objMasterCustomer = new MasterCustomer();
            //    MasterCustomerDetail masterCustomerDetail = new MasterCustomerDetail();
            //    MasterCustomerAddressInfo masterCustomerAddressInfo = new MasterCustomerAddressInfo();
            //    objMasterCustomer.GroupCode = "C0001";
            //    objMasterCustomer.CustomerId = objDocket.CustomerId;
            //    objMasterCustomer.CustomerCode = objDocket.ConsigneeCode;
            //    objMasterCustomer.CustomerName = objDocket.ConsigneeName;
            //    objMasterCustomer.CompanyId = SessionUtility.CompanyId;
            //    objMasterCustomer.IsActive = true;
            //    masterCustomerDetail.PanNo = objDocket.ConsigneePanNo;
            //    masterCustomerDetail.GstTinNo = objDocket.ConsigneeGstTinNo;
            //    masterCustomerDetail.MobileNo = objDocket.ConsigneeMobileNo;
            //    masterCustomerDetail.EmailId = objDocket.ConsigneeEmailId;
            //    masterCustomerDetail.PhoneNo = objDocket.ConsigneePhoneNo;
            //    masterCustomerAddressInfo.Address1 = objDocket.ConsigneeAddress1;
            //    masterCustomerAddressInfo.CityId = objDocket.ConsigneeCityId;
            //    masterCustomerAddressInfo.Pincode = objDocket.ConsigneePincode;

            //    masterCustomerDetail.EntryBy = SessionUtility.LoginUserId;
            //    masterCustomerDetail.CustomerTypeId = (byte)2;
            //    //masterCustomerDetail.CustomerTypeId = (byte)2;
            //    objMasterCustomer.MasterCustomerAddressInfo = masterCustomerAddressInfo;
            //    objMasterCustomer.MasterCustomerDetail = masterCustomerDetail;
            //    int customerId = customerRepository.Insert(objMasterCustomer);
            //    objDocket.ConsigneeId = (short)customerId;
            //}
            int num = 0;
            for (byte i = 0; i < objDocket.InvoiceList.Count; i = (byte)(i + 1))
            {
                num++;
                objDocket.InvoiceList[i].InvoiceId = num;
                foreach (InvoicePart partList in objDocket.InvoiceList[i].PartList)
                {
                    if (partList.PartId > 0)
                    {
                        partList.InvoiceId = num;
                    }
                }
            }
            Response response = new Response();
            if (!objDocket.UsePreviousHistory || !objDocket.IsAdd)
            {
                str = (objDocket.DocketId > (long)0 ? "EditDone" : "EntryDone");
            }
            else
            {
                str = "EntryDone";
            }
            string str1 = str;

            if (Session["ClickResponse"] == null)
            {
                if ((!objDocket.UsePreviousHistory ? true : !objDocket.IsAdd))
                {
                    response = (objDocket.DocketId <= (long)0 ? this.docketRepository.DumptcoDocketInsert(objDocket) : this.docketRepository.Update(objDocket));
                }
                else
                {
                    response = this.docketRepository.DumptcoDocketInsert(objDocket);
                }
                Session["ClickResponse"] = response;

                if (this.rulesRepository.GetModuleRuleByIdAndRuleId(25, 1) == "Y")
                {

                    Response docketresponse = this.docketRepository.CreatePktBarCode(response.DocumentId, "Docket");
                    if (docketresponse != null)
                    {
                        response.DocumentId3 = docketresponse.DocumentId;
                        response.DocumentNo3 = response.DocumentNo;
                    }
                }
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (!response.IsSuccessfull)
            {
                action = base.View(objDocket);
            }
            else
            {
                action = base.RedirectToAction("InsertD2DDone", new { documentId = response.DocumentId, documentNo = response.DocumentNo, status = str1, documentId2 = response.DocumentId2, documentNo2 = response.DocumentNo2, documentId3 = response.DocumentId3, documentNo3 = response.DocumentNo3 });
            }

            return action;
        }

        public ActionResult InsertD2DDone(long? documentId)
        {
            List<DocketPackages> docketPackages = new List<DocketPackages>();
            docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
            return base.View(docketPackages);
        }

        //public ActionResult InsertMLPLDocketDone(long? documentId)
        //{
        //    List<DocketPackages> docketPackages = new List<DocketPackages>();
        //    docketPackages.AddRange(this.docketRepository.GetPackagesByDocketId((long)documentId));
        //    return base.View(docketPackages);
        //}
    }

}
