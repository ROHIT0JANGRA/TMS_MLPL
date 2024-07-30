using CodeLock.Api_Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO.Compression;
using CodeLock.Models;
using Newtonsoft.Json;
using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Repository;
using System.Runtime.CompilerServices;
using CodeLock.Areas.Packaging.Repository;
using System.Data;
using Newtonsoft.Json.Linq;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CodeLock.Areas.Packaging.Controllers
{
    public class RGPController : Controller
    {

        private readonly ICustomerRepository customerRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IRgpRepository _rgpRepository;

        public RGPController(ICustomerRepository customerRepository, IGeneralRepository generalRepository, ILocationRepository locationRepository, ICompanyRepository companyRepository, IRgpRepository rgpRepository)
        {
            this.customerRepository = customerRepository;
            this.locationRepository = locationRepository;
            this.companyRepository = companyRepository;
            this.generalRepository = generalRepository;
            this._rgpRepository = rgpRepository;
        }

        // GET: Packaging/RGP
        public ActionResult RgpList()
        {
            return View();
        }
    

        public ActionResult RgpInsert()
        {
            // Set up warehouse data
            var warehouseData = new List<SelectListItem>{new SelectListItem{Value = SessionUtility.WarehouseId.ToString(),Text =  SessionUtility.WarehouseName.ToString()}};

            // Ensure correct creation of SelectListItem
            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);
            IEnumerable<AutoCompleteResult> PkgwarehouseList = this.generalRepository.GetAllPkgWarehouseList();
            IEnumerable<AutoCompleteResult> IGetRgpSeriesList = this._rgpRepository.RGP_SeriesList();
            IEnumerable<SelectListItem> items = warehouseData;

            ((dynamic)base.ViewBag).WarehouseList = items;
            ((dynamic)base.ViewBag).RGPListSeries = IGetRgpSeriesList;
            ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;
            ((dynamic)base.ViewBag).PkgWarehouseList = PkgwarehouseList;
            return View();
        }

        [HttpPost]
        public ActionResult RgpInsert(PackagingModel rgpChallanModal)
        {
            var result = rgpChallanModal;
            ViewBag.show = result;
            return View();
        }


        public async Task<JsonResult> GetRGPDataList(int draw, int start, int length, string search)
        {
            try
            {
                var result = await _rgpRepository.GetRGPDataListFromApi(draw, start, length, search);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = $"Exception: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
        // ***************************   Get RGP Data getBySeriesNo    *****************************************
        //public async Task<ActionResult> ViewRGPDetails(int? Reference1)
        //{
        //    try
        //    {
        //        var warehouseData = new List<SelectListItem> { new SelectListItem { Value = SessionUtility.WarehouseId.ToString(), Text = SessionUtility.WarehouseName.ToString() } };

        //        // Ensure correct creation of SelectListItem
        //        IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);
        //        IEnumerable<AutoCompleteResult> PkgwarehouseList = this.generalRepository.GetAllPkgWarehouseList();
        //        IEnumerable<AutoCompleteResult> IGetRgpSeriesList = this._rgpRepository.RGP_SeriesList();
        //        IEnumerable<SelectListItem> items = warehouseData;

        //        ((dynamic)base.ViewBag).WarehouseList = items;
        //        ((dynamic)base.ViewBag).RGPListSeries = IGetRgpSeriesList;
        //        ((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;
        //        ((dynamic)base.ViewBag).PkgWarehouseList = PkgwarehouseList;
        //        if (Reference1.HasValue)
        //        {
        //            await GetTheDetailsOfRgpBySeresNo(Reference1.Value);


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //    }
        //    return View();
        //}
        public async Task<ActionResult> ViewRGPDetails(int? Reference1)
        {
            try
            {
                // Fetch data
                var warehouseData = new List<SelectListItem>
        {
            new SelectListItem
            {
                 Value = SessionUtility.WarehouseName.ToString(),
                Text = SessionUtility.WarehouseName.ToString()
            }
        };

                IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);
                IEnumerable<AutoCompleteResult> PkgwarehouseList = this.generalRepository.GetAllPkgWarehouseList();
                IEnumerable<AutoCompleteResult> IGetRgpSeriesList = this._rgpRepository.RGP_SeriesList();

                var viewModel = new PackagingModel(); // Create an instance of your model

                if (Reference1.HasValue)
                {
                    // Fetch the details using the Reference1
                    var result = await _rgpRepository.FetchRGPDataBySeriesNo(Reference1.Value);
                    if (result.ContainsKey("RgpDataList"))
                    {
                        var rgpDataBySeriesNoListJson = result["RgpDataList"] as JArray;
                        var rgpDataMasterList = rgpDataBySeriesNoListJson?.ToObject<List<PackagingModel>>()?.FirstOrDefault();

                        if (rgpDataMasterList != null)
                        {
                            // Set the view model with fetched data
                            viewModel = rgpDataMasterList;
                        }
                    }
                }

                // Pass the necessary data to ViewBag
                ViewBag.WarehouseList = warehouseData;
                ViewBag.RGPListSeries = IGetRgpSeriesList;
                ViewBag.CustomerList = iEnumerabledocket;
                ViewBag.PkgWarehouseList = PkgwarehouseList;

                // Pass the view model to the view
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult ViewRGPDetails()
        {
            return View();
        }
        public async Task<JsonResult> GetTheDetailsOfRgpBySeresNo(int? Reference1)
        {
            try
            {
                // Fetch data from repository
                var result = await _rgpRepository.FetchRGPDataBySeriesNo(Reference1);

                // Check for errors in the result
                if (result.ContainsKey("error"))
                {
                    return Json(new { error = result["error"] }, JsonRequestBehavior.AllowGet);
                }

                // Extract total records and data list
                var rgpDataBySeriesNoListJson = result["RgpDataList"] as JArray;
                var rgpDataMasterList = rgpDataBySeriesNoListJson?.ToObject<List<PackagingModel>>() ?? new List<PackagingModel>();

                // Construct the response object for DataTables
                var responseOK = new
                {                  
                    data = rgpDataMasterList
                };

                return Json(responseOK, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Return error message if an exception occurs
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        // *******************************----- Sap  GetThe Item Details By Customer Code and TO Warehouse code-------------------- ************************************************
        public async Task<JsonResult> GetTheRgpItemDetailsByIds()
        {
            try
            {
                // Await the async call to the repository method
                var result = await _rgpRepository.GetTheRgpItemDetails();

                // Check for errors in the result
                if (result.Count > 0 && result[0].ContainsKey("error"))
                {
                    return Json(new { error = result[0]["error"] }, JsonRequestBehavior.AllowGet);
                }

                // Convert list of dictionaries to list of PackagingModel
                var rgpDataMasterList = result.Select(item => new StockTransferLine
                {
                    // Assuming PackagingModel has properties that match the keys in the dictionary
                    // Adjust property assignments as necessary
                    ItemCode = item.ContainsKey("ItemCode") ? item["ItemCode"].ToString() : null,
                    ItemDescription = item.ContainsKey("ItemName") ? item["ItemName"].ToString() : null,
                    Quantity = item.ContainsKey("Quantity") ? Convert.ToInt32(item["Quantity"]) : 0,
                    // Add other properties as needed
                }).ToList();

                // Construct the response object
                var responseOK = new
                {
                    data = rgpDataMasterList
                };

                return Json(responseOK, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }





        // ***************************  Pagination List of Stock transfer Data only this method is call in ajax and call rgp repository methods ***********************************************

        public async Task<JsonResult> StockTransferPagination(int draw, int start, int length, string search = null)
   {
            try
            {
                // Fetch data from repository
                var result = await _rgpRepository.FetchBPMasterPagination(start, length, search);

                // Check for errors in the result
                if (result.ContainsKey("error"))
                {
                    return Json(new { error = result["error"] }, JsonRequestBehavior.AllowGet);
                }

                // Extract total records and data list
                var totalRecords = (int)result["totalRecords"];
                var bpmMasterListJson = result["BPMasterList"] as JArray;
                var bpmMasterList = bpmMasterListJson?.ToObject<List<PackagingModel>>() ?? new List<PackagingModel>();

                // Construct the response object for DataTables
                var responseOK = new
                {
                    draw = draw,
                    recordsTotal = totalRecords,
                    recordsFiltered = totalRecords,
                    data = bpmMasterList
                };

                return Json(responseOK, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Return error message if an exception occurs
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //***************************************------Sap RGP Insert Api Fetch ---------------**************************************



        public async Task<ActionResult> GetRGPData()
        {

            string sessionId = SapSessionManagerController.GetSessionId();

            if (string.IsNullOrEmpty(sessionId))
            {
                sessionId = await SapSessionManagerController.GenerateToken();
            }
            ViewBag.SessionId = sessionId;

            // Create HttpClient instance with handlers to ignore certificate validation
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    // Set headers
                    client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
                    client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

                    // Set cookies for session management
                    CookieContainer cookies = new CookieContainer();
                    cookies.Add(new Cookie("B1SESSION", sessionId) { Domain = "103.194.8.71" }); // Replace with your session ID
                    cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "103.194.8.71" });
                    handler.CookieContainer = cookies;

                    // Send GET request
                    HttpResponseMessage response = await client.GetAsync("https://103.194.8.71:50000/b1s/v1/StockTransfers"); // ('V0137')";

                    // Check if successful
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                        {
                            using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                            using (var streamReader = new StreamReader(gzipStream))
                            {
                                string responseBody = await streamReader.ReadToEndAsync();
                                // string responseObject = JsonConvert.DeserializeObject<string>(responseBody);
                                ViewBag.responseData = responseBody;

                                return Json(responseBody, JsonRequestBehavior.AllowGet);
                                // return View();
                            }
                        }
                        else
                        {
                            // Handle unsuccessful request (e.g., log, throw exception, return error response)
                            // return Json("response is ok but data not retrive", JsonRequestBehavior.AllowGet);
                            return ViewBag.responseData = "response is ok but data not retrive";
                        }
                    }
                    else
                    {
                        sessionId = await SapSessionManagerController.GenerateToken();
                        ViewBag.responseData = $"Failed to retrieve data. Status code: {response.StatusCode}";
                        return View();
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request exceptions
                    // return Json(new { error = $"HttpRequestException: {ex.Message}" }, JsonRequestBehavior.AllowGet);
                    return ViewBag.responseData = $"HttpRequestException: {ex.Message}";
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    // return Json(new { error = $"Exception: {ex.Message}" }, JsonRequestBehavior.AllowGet);
                    return ViewBag.responseData = $"Exception: {ex.Message}";
                }
            }
        }


    }
}