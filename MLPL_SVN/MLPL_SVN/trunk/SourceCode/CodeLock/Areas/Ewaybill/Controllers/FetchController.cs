using CodeLock.Areas.Ewaybill.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Ewaybill.Controllers
{
    public class FetchController : Controller
    {
        private readonly IEwaybillRepository ewayBillInterface;
        public FetchController(IEwaybillRepository ewayBillInterfaces)
        {
            this.ewayBillInterface = ewayBillInterfaces;
        }
        public FetchController(){}

        // GET: Ewaybill/EwayBillPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsolidateEwb()
        {
            return View();
        }
        public string GeneratedEwayBillCode()
        {
            var result = ewayBillInterface.GenerateEwayBill();
            return result;
        }
        //DocketController
        [HttpPost]
        public async Task<ActionResult> GetData(int txtEwbFetchDate)
        {
            if (ModelState.IsValid)
            {
                short loginLocationId = SessionUtility.LoginLocationId.ConvertToShort();
                MasterLocation objUser = ewayBillInterface.GetAPIUSER(loginLocationId);
                if (loginLocationId == 1)
                {
                    var Error = new
                    {
                        Error = "Please Change your Virtual Location"
                    };
                    var responseData = Newtonsoft.Json.JsonConvert.SerializeObject(Error);
                    return Json(responseData);
                }
                else
                {
                    var httpClient = new HttpClient();

                    var authHeaderValue = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "IalkRmh3z4=:::ZH4TUvIeJ3A=");

                    // Set the Authorization header using DefaultRequestHeaders
                    httpClient.DefaultRequestHeaders.Authorization = authHeaderValue;

                    dynamic requestBody = new System.Dynamic.ExpandoObject();
                    requestBody.Date = txtEwbFetchDate; // 20240709;
                    requestBody.EWBUserName = objUser.API_USER;
                    requestBody.EWBPassword = objUser.API_PASSWORD;
                    requestBody.GSTIN = objUser.GstTinNo;
                    if (objUser.StateId == "4") // for use testing scenario
                    {
                        requestBody.Year = 2024;
                        requestBody.Month = 7;
                        requestBody.EFUserName = "29AAACW3775F000";
                        requestBody.EFPassword = "Admin!23..";
                        requestBody.CDKey = 1000687;
                    }
                    else // it live scenrio
                    {
                        requestBody.Year = 2024;
                        requestBody.Month = 7;
                        requestBody.EFUserName = "039C10BA-5F49-4C9C-98B7-2B14AAFA38E8";
                        requestBody.EFPassword = "1D4331EF-1DFB-43D3-A065-4F24DBBEB1CD";
                        requestBody.CDKey = 1550859;
                    }

                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = objUser.StateId == "4"
                        ? "http://ewaysandbox.webtel.in/Sandbox/EWayBill/v1.3/GetEWB"
                        : "http://ewayasp.webtel.in/EWayBill/v1.3/GetEWBForTransporter";

                    var response = await httpClient.PostAsync(url, content);

                    ViewBag.statusCode = response;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        dynamic parsedResponse = JsonConvert.DeserializeObject(responseData);

                        return Json(parsedResponse);
                    }
                    else
                    {
                        string responseData = null;
                        return View(responseData);
                    }
                }
            }
            // If model state is not valid or no data found, return to the same view with the entered ID.
            return View();
        }
    }
}