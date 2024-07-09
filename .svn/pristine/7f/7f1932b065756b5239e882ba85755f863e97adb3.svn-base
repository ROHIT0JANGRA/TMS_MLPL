using CodeLock.Areas.FMS.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2013.Excel;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using OfficeOpenXml.Drawing.Slicer.Style;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml;
//using System.Web.Mvc;
using ITrackingRepository = CodeLock.Areas.Operation.Repository.ITrackingRepository;

namespace CodeLock.Areas.Operation.Api
{
    [RoutePrefix("api/Docket")]
    public class DocketController : ApiController
    {
        private readonly IDocketRepository docketRepository;
        private readonly ITrackingRepository trackingRepository;
        private readonly ITripsheetRepository tripsheetRepository;

        public DocketController(IDocketRepository _docketRepository, ITrackingRepository _trackingRepository,
            ITripsheetRepository _tripsheetRepository)
        {
            docketRepository = _docketRepository;
            trackingRepository = _trackingRepository;
            tripsheetRepository = _tripsheetRepository;
        }


        [Route(nameof(IRISExtendValidity))]
        [HttpGet]
        public HttpResponseMessage IRISExtendValidity()
        {
            HttpResponseMessage response = null;
            DocketStatusApi docketStatusApiResponse = new DocketStatusApi();
            string json = string.Empty;

            try
            {

                ModelNICEwayBillAppKeyResponse res = this.docketRepository.IRISEwayBillAuthentication();

                docketStatusApiResponse.IsSuccess = true;
                docketStatusApiResponse.Message=res.sek;

            }
            catch (Exception ex)
            {
                docketStatusApiResponse.IsSuccess = false;
                docketStatusApiResponse.Message=ex.Message;
            }


            json = JsonConvert.SerializeObject(docketStatusApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }




        [Route(nameof(ImportTripsheetForAdityaBirla))]
        [HttpGet]
        public HttpResponseMessage ImportTripsheetForAdityaBirla()
        {
            HttpResponseMessage response = null;
            DocketStatusApi docketStatusApiResponse = new DocketStatusApi();
            string json = string.Empty;

            try
            {

                List<TripsheetForAdityaBirla> tripsheetList = new List<TripsheetForAdityaBirla>();
                List<TripsheetForAdityaBirlaSummary> SummaryList = new List<TripsheetForAdityaBirlaSummary>();
                List<TripsheetForAdityaBirlaEWBN> EWBNList = new List<TripsheetForAdityaBirlaEWBN>();

                string fileName = "";
                String Username = System.Configuration.ConfigurationManager.AppSettings["FTPUsername"].ToString();// "1313551";
                String Password = System.Configuration.ConfigurationManager.AppSettings["FTPPassword"].ToString();// "pass@123";
                String ftpServerIP = System.Configuration.ConfigurationManager.AppSettings["FTPServerIP"].ToString();// "ftp://mgorder.abfrl.com";
                String filePath = "";// "D://MUJ_REGR_1560_2022_0001.pdfFTPServerIP

                ArrayList fileList = GetLatestFile(ftpServerIP, Username, Password);
                foreach (String file in fileList)
                {
                    fileName = file;
                    String ftpFilePath = fileName;

                    string path = HttpContext.Current.Server.MapPath("~/Storage/AdityaBirla)/");

                    if (System.IO.Directory.Exists(path)) { }
                    else
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    filePath = path + fileName;

                    WebClient request = new WebClient();
                    request.Credentials = new NetworkCredential(Username, Password);
                    byte[] fileData = request.DownloadData(
                                                String.Format("{0}/{1}", ftpServerIP, ftpFilePath));
                    System.IO.File.WriteAllBytes(filePath, fileData);

                    if(!fileName.Contains("Summary") && !fileName.Contains("EWBN"))
                    {
                        List<TripsheetForAdityaBirla> obj1 = ReadTripsheet(filePath);

                        if (obj1 != null)
                        {
                            TripsheetForAdityaBirlaMain tripsheetForAdityaBirlaMain = new TripsheetForAdityaBirlaMain();
                            tripsheetForAdityaBirlaMain.TripsheetList = obj1;
                            docketStatusApiResponse = docketRepository.InsertTripsheetForAdityaBirla(tripsheetForAdityaBirlaMain);
                        }
                    }
                    else if (fileName.Contains("Summary"))
                    {
                        List<TripsheetForAdityaBirlaSummary> obj2 =  ReadTripsheetSummary(filePath);
                        if (obj2 != null)
                        {
                            TripsheetForAdityaBirlaMain tripsheetForAdityaBirlaMain = new TripsheetForAdityaBirlaMain();
                            tripsheetForAdityaBirlaMain.SummaryList = obj2;
                            docketStatusApiResponse = docketRepository.InsertTripsheetForAdityaBirlaSummary(tripsheetForAdityaBirlaMain);
                        }

                    }
                    else if (fileName.Contains("EWBN"))
                    {
                        List<TripsheetForAdityaBirlaEWBN> obj3 = ReadTripsheetEWBN(filePath);
                        if (obj3 != null)
                        {
                            TripsheetForAdityaBirlaMain tripsheetForAdityaBirlaMain = new TripsheetForAdityaBirlaMain();
                            tripsheetForAdityaBirlaMain.EWBNList = obj3;
                            docketStatusApiResponse = docketRepository.InsertTripsheetForAdityaBirlaEWBN(tripsheetForAdityaBirlaMain);
                        }
                    }

                }

                docketStatusApiResponse.IsSuccess = true;
                docketStatusApiResponse.Message="Get Eway bill successfully";
            }
            catch (Exception ex) {
                docketStatusApiResponse.IsSuccess = false;
                docketStatusApiResponse.Message=ex.Message;
            }

            json = JsonConvert.SerializeObject(docketStatusApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
        private List<TripsheetForAdityaBirla> ReadTripsheet(string csvFilePath)
        {
            List<TripsheetForAdityaBirla> tripsheetList = new List<TripsheetForAdityaBirla>();
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    int index = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                       
                        if (index > 0)
                        {
                            line = line.Replace("\",", "~");
                            line = line.Replace("\"", "");

                            var values = line.Split('~');

                            if (values.Length>0)
                            {
                                TripsheetForAdityaBirla obj = new TripsheetForAdityaBirla();
                                obj.tripsheetdate = values[0];
                                obj.whseid = values[1];
                                obj.fromcity = values[2];
                                obj.tripsheetno = values[3];
                                obj.dcno = values[4];
                                obj.lrno = values[5];
                                obj.cartonno = values[6];
                                obj.noofpieces = values[7];
                                obj.custtype = values[8];
                                obj.shroomno = values[9];
                                obj.shroomname = values[10];
                                obj.shroomaddress1 = values[11];
                                obj.shroomaddress2 = values[12];
                                obj.shroomcity = values[13];
                                obj.shroompin = values[14];
                                obj.shroomphone = values[15];
                                obj.shroommail = values[16];
                                obj.transportername = values[17];
                                obj.transcode = values[18];
                                tripsheetList.Add(obj);
                            }

                        }
                        index = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            return tripsheetList;
        }
        private List<TripsheetForAdityaBirlaSummary> ReadTripsheetSummary(string csvFilePath)
        {
            List<TripsheetForAdityaBirlaSummary> tripsheetList = new List<TripsheetForAdityaBirlaSummary>();
            bool bl;
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    int index = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                    //    var values = line.Split(',');
                     
                        if (index > 0)
                        {

                            line = line.Replace("\",", "~");
                            line = line.Replace("\"", "");

                            var values = line.Split('~');

                            if (values.Length>0)
                            {
                                TripsheetForAdityaBirlaSummary obj = new TripsheetForAdityaBirlaSummary();
                                obj.plantcode = values[0];
                                obj.tripsheetno = values[1];
                                obj.tripsheetdate = values[2];
                                obj.lrno = values[3];
                                obj.custcode = values[4];
                                obj.custname = values[5];
                               
                                decimal invoiceqty; 

                                bl = decimal.TryParse(values[6], out invoiceqty);
                                obj.invoiceqty = invoiceqty;

                                decimal noofboxes;

                                bl = decimal.TryParse(values[7], out noofboxes);
                                obj.noofboxes = noofboxes;

                                decimal weight;
                                bl = decimal.TryParse(values[8], out weight);
                                obj.weight = weight;

                                decimal invoicevalue;
                                bl = decimal.TryParse(values[9], out invoicevalue);
                                obj.invoicevalue = invoicevalue;
                                obj.cityname = values[10];
                                tripsheetList.Add(obj);
                            }

                        }
                        index = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            return tripsheetList;
        }
        private List<TripsheetForAdityaBirlaEWBN> ReadTripsheetEWBN(string csvFilePath)
        {
            List<TripsheetForAdityaBirlaEWBN> tripsheetList = new List<TripsheetForAdityaBirlaEWBN>();
            bool bl;
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    int index = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        //var values = line.Split(',');

                        if (index > 0)
                        {

                            line = line.Replace("\",", "~");
                            line = line.Replace("\"", "");

                            var values = line.Split('~');

                            if (values.Length>0)
                            {
                                TripsheetForAdityaBirlaEWBN obj = new TripsheetForAdityaBirlaEWBN();
                                obj.docno = values[0];
                                obj.invoiceno = values[1];
                                obj.lrno = values[2];
                                obj.tripsheetno = values[3];
                                obj.tripsheetdate = values[4];
                                obj.invoicedate = values[5];
                                obj.ewaybillno = values[6];

                                decimal invoicevalue;
                                bl = decimal.TryParse(values[7], out invoicevalue);
                                obj.invoicevalue = invoicevalue;

                                obj.plantcode = values[8];
                                obj.custcode = values[9];

                                tripsheetList.Add(obj);
                            }

                        }
                        index = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            return tripsheetList;
        }


        private ArrayList GetLatestFile(string ftpServerUri, string ftpUsername, string ftpPassword)
        {

            ArrayList fileList = new ArrayList();


            // Create the FTP request
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerUri);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            // Get the response
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            // Parse the directory listing to find the latest file
            string latestFileName = null;
            DateTime latestFileDate = DateTime.MinValue;
            string line = reader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string fileName = tokens[tokens.Length - 1];
                tokens[1] = tokens[1].Replace("PM", " PM");
                tokens[1] = tokens[1].Replace("AM", " AM");
                string[] dates = tokens[0].Split('-');

                //                string dt = dates[0]+"/"+dates[1]+"/20"+dates[2];
                string dt = "20"+dates[2]+"/"+ dates[0]+"/"+dates[1];

                //DateTime fileDate = DateTime.Parse(dt + " " + tokens[1]);
                DateTime fileDate = DateTime.Parse(dt);
                DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                if (fileDate  == currentDate && !fileName.EndsWith(".") && !fileName.EndsWith(".."))
                {
                    fileList.Add(fileName);
                }

                line = reader.ReadLine();
            }

            if (string.IsNullOrEmpty(latestFileName))
            {
                latestFileName = "";
            }

            return fileList;
        }

        [Route(nameof(TaxProExtendValidity))]
        [HttpGet]
        public HttpResponseMessage TaxProExtendValidity()
        {
            HttpResponseMessage response = null;
            DocketStatusApi docketStatusApiResponse = new DocketStatusApi();
            string json = string.Empty;

            try
            {

                 IEnumerable<TaxProEwayExtendValidityRequest> req = this.docketRepository.GetEWayBillForExtensionList("1");

                //List<TaxProEwayExtendValidityRequest> req = new List<TaxProEwayExtendValidityRequest>();
                //req.Add(new TaxProEwayExtendValidityRequest
                //{
                //    ewbNo = 121720820687,
                //    vehicleNo="MH04KF9368",
                //    fromPlace="BANGALORE",
                //    fromState=29,
                //    remainingDistance=26,
                //    transDocNo ="2627",
                //    transDocDate ="03/10/2023",
                //    transMode ="2",
                //    extnRsnCode=1,
                //    extnRemarks="Break Down",
                //    fromPincode=562162,
                //    consignmentStatus="M",
                //    transitType="",
                //    addressLine1="",
                //    addressLine2="",
                //    addressLine3="",
                //});

                Task<string> taskauthToken = Task.Run<string>(async () => await this.docketRepository.GetTaxProGetAuthDetail());
                string authToken = taskauthToken.Result;


                foreach (var transporterRequest in req )
                {

                    Task<TaxProGetEwayApiResponse> taskDistance = Task.Run<TaxProGetEwayApiResponse>(async () => await this.docketRepository.ValidateTaxProEwayBillAuthToken(transporterRequest.ewbNo, authToken));
                    TaxProGetEwayApiResponse objDistance = taskDistance.Result;

                    if (objDistance != null)
                    {

                        if (string.IsNullOrEmpty(transporterRequest.vehicleNo))
                        {
                            transporterRequest.vehicleNo ="";
                        }

                        if(transporterRequest.vehicleNo == "")
                        {
                            transporterRequest.vehicleNo = objDistance.vehicleNo;
                            transporterRequest.fromPincode = objDistance.fromPincode;
                            transporterRequest.fromPlace = objDistance.fromPlace;
                            transporterRequest.fromState = objDistance.fromStateCode;
                            transporterRequest.remainingDistance = objDistance.actualDist;
                        }


                        Task<TaxProEwayExtendValidityApiResponse> task = Task.Run<TaxProEwayExtendValidityApiResponse>(async () => await this.docketRepository.TaxProExtendValidityAuthToken(transporterRequest, authToken));
                        TaxProEwayExtendValidityApiResponse objTask = task.Result;

                        if (objTask != null)
                        {
                            try
                            {
                                if(objTask.IsSuccess == false)
                                {
                                    if (objTask.errorMsg.Contains("distance") && objTask.errorMsg.Contains("fromPinCode")
                                        && objTask.errorMsg.Contains("toPinCode"))
                                    {
                                        DataSet ds = jsonToDataSet(objTask.errorMsg);

                                        if(ds != null)
                                        {
                                            if(ds.Tables.Count > 0)
                                            {
                                                int distance; 
                                       
                                                bool fl = int.TryParse(ds.Tables[0].Rows[0]["distance"].ToString(), out distance);

                                                if (objDistance.actualDist < distance)
                                                {
                                                    objTask.errorMsg = objTask.errorMsg + "Pin code issue, actual Dist :" + objDistance.actualDist.ToString()+ " km & pin code : "+distance.ToString()+" km" ;
                                                }
                                                else if (objDistance.actualDist >= distance)
                                                {
                                                    transporterRequest.remainingDistance = distance;

                                                    Task<TaxProEwayExtendValidityApiResponse> task1 = Task.Run<TaxProEwayExtendValidityApiResponse>(async () => await this.docketRepository.TaxProExtendValidityAuthToken(transporterRequest, authToken));
                                                    objTask = task1.Result;
                                                }
                                            }
                                        }
                                    }
                                }

                                Response resIns = this.docketRepository.InsertEWayBillForExtension(objTask);
                                docketStatusApiResponse.IsSuccess = true;
                                docketStatusApiResponse.Message="Extend validity successfully";
                            }
                            catch (Exception ex)
                            {
                                docketStatusApiResponse.IsSuccess = false;
                                docketStatusApiResponse.Message="Error in extension validity";
                            }
                        }
                        else
                        {
                            docketStatusApiResponse.IsSuccess = false;
                            docketStatusApiResponse.Message="Error in extension validity";
                        }

                    }


                }

            }
            catch(Exception ex) {
                docketStatusApiResponse.IsSuccess = false;
                docketStatusApiResponse.Message=ex.Message;
            }


            json = JsonConvert.SerializeObject(docketStatusApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
     
        private DataSet jsonToDataSet(string jsonString)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xd));
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [Route(nameof(TaxProGetEwayBill))]
        [HttpGet]
        public HttpResponseMessage TaxProGetEwayBill([FromUri] string date, [FromUri] string statecode, [FromUri] string gstIn)
        {
            HttpResponseMessage response = null;
            DocketStatusApi docketStatusApiResponse = new DocketStatusApi();
            string json = string.Empty;

                TaxProGetEwayForTransporterByStateRequest transporterRequest = new TaxProGetEwayForTransporterByStateRequest();
                transporterRequest.date = date;// "20230812";
                transporterRequest.statecode = statecode;// "34";
                transporterRequest.gstIn = gstIn;// "34AACCC1596Q002";
                List<TaxProGetEwayDetailsForTransporterByStateApiResponse> obj = new List<TaxProGetEwayDetailsForTransporterByStateApiResponse>();
                Task<IEnumerable<TaxProGetEwayForTransporterByStateApiResponse>> task = Task.Run<IEnumerable<TaxProGetEwayForTransporterByStateApiResponse>>(async () => await this.docketRepository.GetEwayBillsForTransporterByState(transporterRequest));
                IEnumerable<TaxProGetEwayForTransporterByStateApiResponse> objTask = task.Result;

            docketStatusApiResponse.IsSuccess = true;
            docketStatusApiResponse.Message="Get Eway bill successfully";

            json = JsonConvert.SerializeObject(docketStatusApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }


        [BasicAuthentication]
        [Route(nameof(OrderUpload))]
        [HttpPost]
        public HttpResponseMessage OrderUpload([FromBody] ApiDocketRequest apiDocketRequest)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            apiDocketRequest.UserName = username;
            HttpResponseMessage response = null;
            ApiDocketResponse apiDocketResponse = new ApiDocketResponse();
            string json = string.Empty;
            apiDocketResponse = docketRepository.OrderUpload(apiDocketRequest);
            json = JsonConvert.SerializeObject(apiDocketResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        
        [Route(nameof(GetDocketStatus))]
        [HttpGet]
        public HttpResponseMessage GetDocketStatus([FromUri] string docketNo)
        {
            HttpResponseMessage response = null;
            DocketStatusApi docketStatusApiResponse = new DocketStatusApi();
            string json = string.Empty;
            docketStatusApiResponse = trackingRepository.GetApiDocketStatus(docketNo);
            json = JsonConvert.SerializeObject(docketStatusApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route(nameof(Login))]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] ApiLoginRequest apiRequest)
        {

            HttpResponseMessage response = null;
            MasterUserDetail apiDocketResponse = new MasterUserDetail();

            bool flag = true;
            string json = string.Empty;
            string clientid = string.Empty;
            string clientsecret = string.Empty;
            IEnumerable<string> client_id;
            IEnumerable<string> client_secret;

            HttpRequestMessage request = Request;

            if (request.Headers.TryGetValues("client-id", out client_id))
            {
                clientid = client_id.FirstOrDefault();
            }
            if (request.Headers.TryGetValues("client-secret", out client_secret))
            {
                clientsecret = client_secret.FirstOrDefault();
            }

            if (string.IsNullOrEmpty(clientid))
            {
                apiDocketResponse.IsSuccess = false;
                apiDocketResponse.Message ="Client id can not be blank";
                flag = false;
            }
            else if (string.IsNullOrEmpty(clientsecret))
            {
                apiDocketResponse.IsSuccess = false;
                apiDocketResponse.Message ="Client Secret can not be blank";
                flag = false;
            }
            else if (string.IsNullOrEmpty(apiRequest.UserName))
            {
                apiDocketResponse.IsSuccess = false;
                apiDocketResponse.Message ="User Name can not be blank";
                flag = false;
            }
            else if (string.IsNullOrEmpty(apiRequest.Password))
            {
                apiDocketResponse.IsSuccess = false;
                apiDocketResponse.Message ="Password can not be blank";
                flag = false;
            }

            if (flag == true)
            {
                UserRepository userRepository = new UserRepository();
                if (!userRepository.ValidateUser(clientid, clientsecret))
                {
                    apiDocketResponse.IsSuccess = false;
                    apiDocketResponse.Message ="Invalid Client id/secret";
                    flag = false;
                }
                else
                {
                    ApiLoginResultResponse resultResponse = userRepository.GetApiForLogin(apiRequest);
                    apiDocketResponse.UserId = resultResponse.Data.UserId;
                    apiDocketResponse.UserName = resultResponse.Data.UserName;
                    apiDocketResponse.CompanyName = resultResponse.Data.CompanyName;
                    apiDocketResponse.IsSuccess = resultResponse.Flag;
                    apiDocketResponse.Message =resultResponse.FlagMessage;
                    flag = false;
                }
            }


            json = JsonConvert.SerializeObject(apiDocketResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route(nameof(DocketCartonListByTripsheet))]
        [HttpPost]
        public HttpResponseMessage DocketCartonListByTripsheet([FromBody] TripsheetRequest tripsheetRequest)
        {
            HttpResponseMessage response = null;
            HttpRequestMessage request = Request;
            DocketCartonListByTripsheetResponse tripsheetResponse = new DocketCartonListByTripsheetResponse();

            bool flag = true;
            string json = string.Empty;
            string clientid = string.Empty;
            string clientsecret = string.Empty;
            IEnumerable<string> client_id;
            IEnumerable<string> client_secret;

            if (request.Headers.TryGetValues("client-id", out client_id))
            {
                clientid = client_id.FirstOrDefault();
            }
            if (request.Headers.TryGetValues("client-secret", out client_secret))
            {
                clientsecret = client_secret.FirstOrDefault();
            }

            if (string.IsNullOrEmpty(clientid))
            {
                tripsheetResponse.IsSuccess = false;
                tripsheetResponse.Message ="Client id can not be blank";
                flag = false;
            }
            else if (string.IsNullOrEmpty(clientsecret))
            {
                tripsheetResponse.IsSuccess = false;
                tripsheetResponse.Message ="Client Secret can not be blank";
                flag = false;
            }
            else if (string.IsNullOrEmpty(tripsheetRequest.tripsheetNo))
            {
                tripsheetResponse.IsSuccess = false;
                tripsheetResponse.Message ="Tripsheet No can not be blank";
                flag = false;
            }

            if (flag == true)
            {
                UserRepository userRepository = new UserRepository();
                if (!userRepository.ValidateUser(clientid, clientsecret))
                {
                    tripsheetResponse.IsSuccess = false;
                    tripsheetResponse.Message ="Invalid Client id/secret";
                }
                else
                {
                    tripsheetResponse = tripsheetRepository.GetDocketCartonListByTripsheet(tripsheetRequest.tripsheetNo);
                    tripsheetResponse.IsSuccess = true;
                    tripsheetResponse.Message ="";
                }
            }

            json = JsonConvert.SerializeObject(tripsheetResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(OrderTracking))]
        [HttpGet]
        public HttpResponseMessage OrderTracking([FromUri] string docketNo)
        {
            HttpResponseMessage response = null;
            OrderTrackingApi orderTrackingApiResponse = new OrderTrackingApi();
            string json = string.Empty;
            orderTrackingApiResponse = trackingRepository.OrderTracking(docketNo);
            json = JsonConvert.SerializeObject(orderTrackingApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(OrderTrackingForFarEye))]
        [HttpGet]
        public HttpResponseMessage OrderTrackingForFarEye([FromUri] string docketNo)
        {
            HttpResponseMessage response = null;
            DocketTrackingResponseForFarEyeSuccess doketTrackingApiResponse = new DocketTrackingResponseForFarEyeSuccess();
            DocketTrackingResponseForFarEyeFailure docketTrackingResponseForFarEye = new DocketTrackingResponseForFarEyeFailure();
            string json = string.Empty;
            doketTrackingApiResponse = trackingRepository.OrderTrackingForFarEye(docketNo);
            if(doketTrackingApiResponse.order_no == null)
            {
                docketTrackingResponseForFarEye.order_no = docketNo;
                docketTrackingResponseForFarEye.Status = "Not Found";
                json = JsonConvert.SerializeObject(docketTrackingResponseForFarEye);

            }
            else
                json = JsonConvert.SerializeObject(doketTrackingApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(ApiOrderUploadPumaDarcl))]
        [HttpPost]
        public HttpResponseMessage ApiOrderUploadPumaDarcl([FromBody] PickUpDetailRequest pickUpDetailRequest)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            pickUpDetailRequest.UserName = username;
            HttpResponseMessage response = null;
            ResponseResult responseResult = new ResponseResult();
            string json = string.Empty;
            responseResult = docketRepository.ApiOrderUploadPumaDarcl(pickUpDetailRequest);
            json = JsonConvert.SerializeObject(responseResult);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(ApiOrderUploadPumaEssential))]
        [HttpPost]
        public HttpResponseMessage ApiOrderUploadPumaEssential([FromBody] PickUpDetailRequest pickUpDetailRequest)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            pickUpDetailRequest.UserName = username;
            HttpResponseMessage response = null;
            ResponseResult responseResult = new ResponseResult();
            string json = string.Empty;
            responseResult = docketRepository.ApiOrderUploadPumaEssential(pickUpDetailRequest);
            json = JsonConvert.SerializeObject(responseResult);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }


        [BasicAuthentication]
        [Route(nameof(ApiOrderUploadArvindEssential))]
        [HttpPost]
        public HttpResponseMessage ApiOrderUploadArvindEssential([FromBody] PickUpDetailRequest pickUpDetailRequest)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            pickUpDetailRequest.UserName = username;
            HttpResponseMessage response = null;
            ResponseResult responseResult = new ResponseResult();
            string json = string.Empty;
            responseResult = docketRepository.ApiOrderUploadArvindEssential(pickUpDetailRequest);
            json = JsonConvert.SerializeObject(responseResult);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
