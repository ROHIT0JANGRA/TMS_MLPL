using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CodeLock.Areas.Ewaybill.Repository;
using CodeLock.Models;
using Newtonsoft.Json;


namespace CodeLock.Areas.Ewaybill.Controllers
{
    public class FetchByTransporterController : Controller
    {
        private readonly IEwaybillRepository ewaybillRepository;
        
        public FetchByTransporterController() { }
        public FetchByTransporterController(IEwaybillRepository _ewaybillRepository)
        {
            this.ewaybillRepository = _ewaybillRepository;
        }


        // GET: Ewaybill/FetchByTransporter
        public ActionResult Index()
        {
            var stateList = ewaybillRepository.GetAllState(); // Fetching the state list
            var stateListModel = new StateListViewModel // Using the new view model
            {
                StateList = stateList // Assigning the state list to the view model
            };
            return View(stateListModel); // Passing the view model to the view

        }

        public class EwaybillGetDetailFromWebNoAndDate
        {
            public int StateId { get; set; } // Adjust data type as needed
            public string EwbDate { get; set; }
        }
        public async Task<ActionResult> GetData(EwaybillGetDetailFromWebNoAndDate model)
        {
            if (ModelState.IsValid)
            {
                var stateList = ewaybillRepository.GetAllState();
                var stateModel = new StateListViewModel { StateList = stateList };

                var dbStateId = stateModel.StateList.Select(s => s.StateId);
                var ajaxStateId = model.StateId;

                GetAllStateCredential stateData = stateModel.StateList.FirstOrDefault(s => s.StateId == model.StateId);

                string ewbDate = model.EwbDate;
                if (stateData != null)
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var authHeaderValue = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "IalkRmh3z4=:::ZH4TUvIeJ3A=");

                        // Set the Authorization header using DefaultRequestHeaders
                        httpClient.DefaultRequestHeaders.Authorization = authHeaderValue;

                        dynamic requestBody = new System.Dynamic.ExpandoObject();
                        requestBody.Date = ewbDate;
                        requestBody.EWBUserName = stateData.API_USER;
                        requestBody.EWBPassword = stateData.API_PASSWORD;
                        requestBody.GSTIN = stateData.GstTinNo;
                        if (stateData.StateId == 4) // for use testing scenario
                        {
                            requestBody.Year = 2017;
                            requestBody.Month = 1;
                            requestBody.EFUserName = "29AAACW3775F000";
                            requestBody.EFPassword = "Admin!23..";
                            requestBody.CDKey = 1000687;
                        }
                        else // it live scenrio
                        {
                            requestBody.Year = 2024;
                            requestBody.Month = 6;
                            requestBody.EFUserName = "039C10BA-5F49-4C9C-98B7-2B14AAFA38E8";
                            requestBody.EFPassword = "1D4331EF-1DFB-43D3-A065-4F24DBBEB1CD";
                            requestBody.CDKey = 1550859;
                        }

                        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                        string url = stateData.StateId == 4
                            ? "http://ewaysandbox.webtel.in/Sandbox/EWayBill/v1.3/GetEWBForTransporter"
                            : "http://ewayasp.webtel.in/EWayBill/v1.3/GetEWBForTransporter";

                        var response = await httpClient.PostAsync(url, content);

                        ViewBag.statusCode = response;

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                            // dynamic myDeserializedClass = JsonConvert.DeserializeObject(responseData);

                            // Replace unnecessary escape characters
                            responseData = responseData.Replace("\\\"", "\""); // Replace \" with "
                            responseData = responseData.Replace("\\", ""); // Replace \\ with \
                            responseData = responseData.Replace("\"[", "[");
                            responseData = responseData.Replace("]\"", "]");

                            List<EWBMain> rootList = JsonConvert.DeserializeObject<List<EWBMain>>(responseData);
                            List<EWBDetail> ewbDetail = rootList[0].EWBDetails;

                            return Json(rootList);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        // Log the exception
                        Console.WriteLine($"HTTP request exception: {ex.Message}");
                        ViewBag.ErrorMessage = "Internal server error";
                        return View("Error");
                    }
                    catch (JsonSerializationException ex)
                    {
                        // Log or handle JSON deserialization exception
                        Console.WriteLine($"JSON deserialization exception: {ex.Message}");
                        ViewBag.ErrorMessage = "Error deserializing JSON";
                        return View("Error");
                    }
                    catch (Exception ex)
                    {
                        // Handle other unexpected exceptions
                        Console.WriteLine($"Unexpected exception: {ex.Message}");
                        ViewBag.ErrorMessage = "Unexpected error";
                        return View("Error");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No data found for the provided ID.");
                }
            }
            // If model state is not valid or no data found, return to the same view with the entered ID.
            return View(model);
        }


        // POST: EwaybillDataFetchByTransporter/GetDataSubmit
        [HttpPost]
        public ActionResult GetDataSubmit(EWBMain rootObj)
        {
            try
            {
                if (!this.ModelState.IsValid)
                    return (ActionResult)this.View((object)rootObj);

                ewaybillRepository.Insert(rootObj);
                return Json(rootObj);
            }
            catch (Exception ex)
            {
                var response = $"Error: {ex.Message}";
                return Json(new { error = response });
            }
        }
        }
}