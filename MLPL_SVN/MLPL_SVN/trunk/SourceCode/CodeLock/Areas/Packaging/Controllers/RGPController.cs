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

namespace CodeLock.Areas.Packaging.Controllers
{
    public class RGPController : Controller
    {


        // GET: Packaging/RGP

        public ActionResult Index()
        {
            return base.View();
        }
        public ActionResult RgpList()
        {
            return base.View();
        }
        public ActionResult RgpInsert()
        {
            var warehouseData = new List<SelectListItem>
        {
            new SelectListItem { Value = SessionUtility.WarehouseId.ToString(), Text = SessionUtility.WarehouseName }
        };
            ViewBag.WarehouseList = warehouseData;

            return base.View();
        }
        [HttpPost]
        public ActionResult RgpInsert(RgpChallanModal rgpChallanModal)
        {
            return base.View();
        }
        public ActionResult RRgpInsert()
        {
            return base.View();
        }
        //***************************************------Sap RGP Insert Api Fetch ---------------**************************************

        private static List<BusinessPartnerDetails> _allBusinessPartners = new List<BusinessPartnerDetails>();

        //public async Task<ActionResult> GetRGPData(int start, int length, int draw)
        //{
        //    try
        //    {
        //        string sessionId = SapSessionManagerController.GetSessionId();

        //        if (string.IsNullOrEmpty(sessionId))
        //        {
        //            sessionId = await SapSessionManagerController.GenerateToken();
        //        }
        //        ViewBag.SessionId = sessionId;

        //        // Create HttpClient instance with handlers to ignore certificate validation
        //        HttpClientHandler handler = new HttpClientHandler();
        //        handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

        //        using (HttpClient client = new HttpClient(handler))
        //        {
        //            // Set headers
        //            client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
        //            client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        //            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

        //            // Set cookies for session management
        //            CookieContainer cookies = new CookieContainer();
        //            cookies.Add(new Cookie("B1SESSION", sessionId) { Domain = "103.194.8.71" }); // Replace with your session ID
        //            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "103.194.8.71" });
        //            handler.CookieContainer = cookies;

        //            // Calculate skip and top based on DataTables parameters
        //            int skip = start;
        //            int top = length;

        //            // Send GET request
        //            HttpResponseMessage response = await client.GetAsync($"https://103.194.8.71:50000/b1s/v1/BusinessPartners?$skip={skip}&$top={top}");

        //            // Check if successful
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string responseBody;
        //                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
        //                {
        //                    using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
        //                    using (var streamReader = new StreamReader(gzipStream))
        //                    {
        //                        responseBody = await streamReader.ReadToEndAsync();
        //                    }
        //                }
        //                else
        //                {
        //                    responseBody = await response.Content.ReadAsStringAsync();
        //                }

        //                // Parse the responseBody into a JSON object and return the required data
        //                var jsonData = JsonConvert.DeserializeObject<dynamic>(responseBody);
        //                var data = jsonData.value;

        //                return Json(new
        //                {
        //                    draw = draw,
        //                    recordsTotal = jsonData["@odata.count"], // Assuming the count is present in the response
        //                    recordsFiltered = jsonData["@odata.count"],
        //                    data = data
        //                });
        //            }
        //            else
        //            {
        //                sessionId = await SapSessionManagerController.GenerateToken();
        //                return Content($"Failed to retrieve data. Status code: {response.StatusCode}", "text/plain");
        //            }
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        return Content($"HttpRequestException: {ex.Message}", "text/plain");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content($"Exception: {ex.Message}", "text/plain");
        //    }
        //}








        //private static List<BusinessPartnerDetails> _allBusinessPartners = new List<BusinessPartnerDetails>();

        public async Task<ActionResult> GetRGPData(int start, int length, int draw)
        {
            try
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

                    // Calculate skip and top based on DataTables parameters
                    int skip = start;
                    int top = length;

                    // Send GET request
                    HttpResponseMessage response = await client.GetAsync($"https://103.194.8.71:50000/b1s/v1/BusinessPartners?$skip={skip}&$top={top}");

                    // Check if successful
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                        {
                            using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                            using (var streamReader = new StreamReader(gzipStream))
                            {
                                string responseBody = await streamReader.ReadToEndAsync();
                                return Content(responseBody, "application/json");
                            }
                        }
                        else
                        {
                            // Handle unsuccessful request
                            return Content("response is ok but data not retrieve", "text/plain");
                        }
                    }
                    else
                    {
                        sessionId = await SapSessionManagerController.GenerateToken();
                        return Content($"Failed to retrieve data. Status code: {response.StatusCode}", "text/plain");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return Content($"HttpRequestException: {ex.Message}", "text/plain");
            }
            catch (Exception ex)
            {
                return Content($"Exception: {ex.Message}", "text/plain");
            }
        }




        //public async Task<ActionResult> GetRGPData()
        //{

        //        string sessionId = SapSessionManagerController.GetSessionId();

        //        if (string.IsNullOrEmpty(sessionId))
        //        {
        //            sessionId = await SapSessionManagerController.GenerateToken();
        //        }
        //        ViewBag.SessionId = sessionId;

        //        // Create HttpClient instance with handlers to ignore certificate validation
        //        HttpClientHandler handler = new HttpClientHandler();
        //        handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

        //        using (HttpClient client = new HttpClient(handler))
        //        {
        //            try
        //            {
        //                // Set headers
        //                client.DefaultRequestHeaders.Add("B1S-WCFCompatible", "true");
        //                client.DefaultRequestHeaders.Add("B1S-MetadataWithoutSession", "true");
        //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        //                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

        //                // Set cookies for session management
        //                CookieContainer cookies = new CookieContainer();
        //                cookies.Add(new Cookie("B1SESSION", sessionId) { Domain = "103.194.8.71" }); // Replace with your session ID
        //                cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "103.194.8.71" });
        //                handler.CookieContainer = cookies;

        //                // Send GET request
        //                HttpResponseMessage response = await client.GetAsync("https://103.194.8.71:50000/b1s/v1/BusinessPartners"); // ('V0137')";

        //                // Check if successful
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    if (response.Content.Headers.ContentEncoding.Contains("gzip"))
        //                    {
        //                        using (var gzipStream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
        //                        using (var streamReader = new StreamReader(gzipStream))
        //                        {
        //                            string responseBody = await streamReader.ReadToEndAsync();
        //                            // string responseObject = JsonConvert.DeserializeObject<string>(responseBody);
        //                            ViewBag.responseData = responseBody;

        //                            return Json(responseBody, JsonRequestBehavior.AllowGet);
        //                            // return View();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // Handle unsuccessful request (e.g., log, throw exception, return error response)
        //                        // return Json("response is ok but data not retrive", JsonRequestBehavior.AllowGet);
        //                        return ViewBag.responseData = "response is ok but data not retrive";
        //                    }
        //                }
        //                else
        //                {
        //                    sessionId = await SapSessionManagerController.GenerateToken();
        //                    ViewBag.responseData = $"Failed to retrieve data. Status code: {response.StatusCode}";
        //                    return View();
        //                }
        //            }
        //            catch (HttpRequestException ex)
        //            {
        //                // Handle HTTP request exceptions
        //                // return Json(new { error = $"HttpRequestException: {ex.Message}" }, JsonRequestBehavior.AllowGet);
        //                return ViewBag.responseData = $"HttpRequestException: {ex.Message}";
        //            }
        //            catch (Exception ex)
        //            {
        //                // Handle other exceptions
        //                // return Json(new { error = $"Exception: {ex.Message}" }, JsonRequestBehavior.AllowGet);
        //                return ViewBag.responseData = $"Exception: {ex.Message}";
        //            }
        //        }
        //    }


    }
}