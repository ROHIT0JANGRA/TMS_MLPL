using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using Microsoft.Ajax.Utilities;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.WebRequestMethods;
using DocumentFormat.OpenXml.Drawing;
using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Office2010.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web.Services.Description;

namespace CodeLock.Areas.Operation.Repository
{
    public class DocketRepository : BaseRepository, IDocketRepository, IDisposable
    {
        public ModelNICEwayBillAppKeyResponse IRISEwayBillAuthentication()
        {
            ModelNICEwayBillAppKeyResponse _authentication = new ModelNICEwayBillAppKeyResponse();
            try
            {
                ModelNICEwayBillAppKeyResponse _appKey = GetAppKey();
                if (_appKey != null)
                {
                    ModelNICEwayBillAppKeyResponse _authPayload = GetEncryptAuthPayload(_appKey);
                    if (_authPayload != null)
                    {
                        _authentication = GetAuthentication(_authPayload);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return _authentication;
        }

        private ModelNICEwayBillAppKeyResponse GetAuthentication(ModelNICEwayBillAppKeyResponse obj)
        {
            ModelNICEwayBillAppKeyResponse result = new ModelNICEwayBillAppKeyResponse();
            try
            {
                string url = "https://gsp.portal.irisgst.com/ewaybillapi/v1.03/auth";
                Class_IRISEwayBill sendingJson = new Class_IRISEwayBill();

                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };
                pHeaderscust.Add("clientid", "IRIS4e9cedc83299e1dd7a8a2c0d31f148c4");
                pHeaderscust.Add("client-secret", "aaa9668518ae5802774cf8799148d9e4");
                pHeaderscust.Add("Gstin", "03AAACD2086J1ZW");

                ModelNICEwayBillAuth req = new ModelNICEwayBillAuth();
                req.Data = obj.Data;

                var RequestJson = JsonConvert.SerializeObject(req);

                string responseText = sendingJson.newRequestPost("POST", url, RequestJson, pHeaderscust);

                result = JsonConvert.DeserializeObject<ModelNICEwayBillAppKeyResponse>(responseText);
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        private ModelNICEwayBillAppKeyResponse GetEncryptAuthPayload(ModelNICEwayBillAppKeyResponse obj)
        {
            ModelNICEwayBillAppKeyResponse result = new ModelNICEwayBillAppKeyResponse();
            try
            {
                string url = "https://gsp.portal.irisgst.com/helperapi/encrypt";
                Class_IRISEwayBill sendingJson = new Class_IRISEwayBill();

                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };

                pHeaderscust.Add("clientid", "IRIS4e9cedc83299e1dd7a8a2c0d31f148c4");
                pHeaderscust.Add("client-secret", "aaa9668518ae5802774cf8799148d9e4");
                ModelNICEwayBillAppKey req = new ModelNICEwayBillAppKey();
                ModelNICEwayBillAppKeyData regdata = new ModelNICEwayBillAppKeyData();
                regdata.action="ACCESSTOKEN";
                regdata.username   ="CJDarcl@PB_API_IRS";
                regdata.password = "Hrhk@123456789";
                regdata.app_key =obj.app_key;

                req.type="Public";
                req.portalType ="ewaybill";
                req.data = regdata;

                var RequestJson = JsonConvert.SerializeObject(req);

                string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);

                result = JsonConvert.DeserializeObject<ModelNICEwayBillAppKeyResponse>(responseText);
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        private ModelNICEwayBillAppKeyResponse GetAppKey()
        {
            ModelNICEwayBillAppKeyResponse result = new ModelNICEwayBillAppKeyResponse();
            try
            {
                string url = "https://gsp.portal.irisgst.com/helperapi/encrypt";
                Class_IRISEwayBill sendingJson = new Class_IRISEwayBill();

                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };

                pHeaderscust.Add("clientid", "IRIS4e9cedc83299e1dd7a8a2c0d31f148c4");
                pHeaderscust.Add("client-secret", "aaa9668518ae5802774cf8799148d9e4");
                ModelNICEwayBillAppKey req = new ModelNICEwayBillAppKey();
                ModelNICEwayBillAppKeyData regdata = new ModelNICEwayBillAppKeyData();
                regdata.action="AUTH";
                regdata.username   ="CJDarcl@PB_API_IRS";
                regdata.password = "Hrhk@123456789";
                req.type="Public";
                req.portalType ="ewaybill";
                req.data = regdata;

                var RequestJson = JsonConvert.SerializeObject(req);

                string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);

                result = JsonConvert.DeserializeObject<ModelNICEwayBillAppKeyResponse>(responseText);
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }
        public Response InsertEWayBillForExtension(TaxProEwayExtendValidityApiResponse obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ewayBillNo", (object)obj.ewayBillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@validUpto", (object)obj.validUpto, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@updatedDate", (object)obj.updatedDate, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsSuccess", (object)obj.IsSuccess, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@errorMsg", (object)obj.errorMsg, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_EWayBillForExtension_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<TaxProEwayExtendValidityRequest> GetEWayBillForExtensionList(string UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TaxProEwayExtendValidityRequest>("CL_EWayBillForExtension_GetAll", (object)dynamicParameters, "Docket - Insert");
        }


        //public async Task<string> RivigoGetAuthAtcive()
        //{
        //    string authtoken = "";
        //    try
        //    {

        //        authtoken = await RivigoGetAuthDetail();

        //        string url = string.Empty;
        //        WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
        //        url = "https://client-integration-api.rivigo.com/oauth/token";

        //        Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
        //        {
        //        };
        //        //pHeaderscust.Add("Accept", "*/*");
        //        pHeaderscust.Add("authorization", value: "bearer "+ authtoken);

        //        //ServicePointManager.Expect100Continue = true;
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        //               | SecurityProtocolType.Tls11
        //               | SecurityProtocolType.Tls12
        //               | SecurityProtocolType.Ssl3;

        //        string responseText = sendingJson.newRequest("POST", url, "", pHeaderscust);
        //        var result = JsonConvert.DeserializeObject<RivigoAuthApiResponse>(responseText);
        //        authtoken = result.payload.access_token;
        //    }
        //    catch (Exception ex)
        //    {
        //        authtoken ="";
        //    }
        //    return authtoken;
        //}
        public async Task<string> RivigoBookingCreate()
        {
            string authtoken = "";
            try
            {

                authtoken = await RivigoGetAuthDetail();

                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = "https://client-integration-api.rivigo.com/operations/booking";

                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };
                //pHeaderscust.Add("Accept", "*/*");
                pHeaderscust.Add("appUuid", value: "64c97da2-950c-497e-a04c-08f9d68350fd");
                pHeaderscust.Add("Authorization", value: "bearer " + authtoken);

                //ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;


                string dateString = DateTime.Now.ToString();

                DateTime epochTime = DateTime.Parse("1970-01-01");
                DateTime date = DateTime.Parse(dateString);

                var milliseconds = date.Subtract(epochTime).TotalMilliseconds;


                string RequestJson = "{\"scheduledBookingDateTime\": "+milliseconds+", \"fromAddress\": { \"addressDetails\": { \"detailedAddress\": \"THE MAURYA DIPLOMATYIC ENCLAVE, SADAR PATEL MARG, DELHI\", \"city\": \"Delhi\", \"pincode\": 110021, \"latitude\": 28.5884, \"longitude\": 77.1859, \"floorNumber\": 1 }, \"callDetails\": { \"name\": \"Mukesh Mehra\", \"phone\": 9000456567, \"email\": \"mukesh@rivigo.com\" }, \"companyDetails\": { \"companyName\": \"AMAZON SELLERS SERVICES PVT. LTD\", \"GSTIN\": \"27AACCH8930K1A1\", \"PAN\": \"BFERD2390D\" } }, \"individualBookingList\": [ { \"cnote\": 6100005001, \"toAddressList\": [ { \"addressDetails\": { \"detailedAddress\": \"3-18-237 & 238/NR , CELLAR 1, MAIN ROAD, PRAGATHI NAGAR, HYDERABAD\", \"city\": \"Hyderabad\", \"pincode\": 560001, \"latitude\": 17.5186, \"longitude\": 78.3963, \"floorNumber\": 1 }, \"callDetails\": { \"name\": \"Sunil Grover\", \"phone\": 9873498435, \"email\": \"sunil@rivigo.com\" }, \"companyDetails\": { \"companyName\": \"BLUE APPARELS\", \"GSTIN\": \"27AACCH8930K1B2\", \"PAN\": \"ASDRD2390D\" } } ], \"loadDetails\": { \"totalBoxes\": 2, \"weight\": 500, \"volume\": 31.1, \"unit\": \"IN\", \"boxTypesList\": [ { \"length\": 10, \"breadth\": 5, \"height\": 6, \"boxTypeCount\": 2 } ], \"invoicesList\": [ { \"invoiceNo\": \"CA2109\", \"invoiceValue\": 21000.5, \"ewaybillNumber\": 211212121212, \"hsnCodesList\": [ { \"hsnCode\": 4901, \"amount\": 15000 } ] } ], \"barcodesList\": [ \"DELBW600014468\", \"DELBW600014469\" ], \"retailType\": \"NORMAL\", \"paymentMode\": \"PAID\", \"taxId\": \"GTRTG4565T\", \"taxIdType\": \"PAN\", \"packaging\": \"BUNDLE\", \"contents\": \"Chemicals\", \"isFragile\": true, \"vasDetails\": { \"chequeDemandDraftDetails\": { \"paymentType\": \"CHEQUE\", \"inFavourOf\": \"Rakesh Kumar\", \"amount\": 10000, \"deliveryAddress\": { \"detailedAddress\": \"3-18-237 & 238/NR , CELLAR 1, MAIN ROAD, PRAGATHI NAGAR, HYDERABAD\", \"city\": \"Hyderabad\", \"pincode\": 560001, \"latitude\": 17.5186, \"longitude\": 78.3963, \"floorNumber\": 1 } } }, \"isLiquidHandlingApplicable\": true, \"isHazardousMaterialApplicable\": true, \"isDacc\": true, \"deliveryType\": \"NORMAL\", \"appointmentId\": \"A1234\", \"appointmentTime\": 1574361000000, \"deliveryClient\": \"AMAZON\", \"deliveryClientDetails\": { \"fcName\": \"string\", \"purchaseOrders\": [ { \"expiryTime\": 1631158200000, \"numberOfItems\": 2, \"orderNumber\": \"string\" } ] }, \"toPayAmount\": 200, \"isLogiFreightAirCn\": true }, \"clientReferenceNumbers\": [ \"string\" ] } ], \"clientCode\": \"ZRETL\"}";

                //\"" + invoice.Unit + "\"
                string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);
                //var result = JsonConvert.DeserializeObject<RivigoAuthApiResponse>(responseText);
                //authtoken = result.payload.access_token;
            }
            catch (Exception ex)
            {
                authtoken ="";
            }
            return authtoken;
        }
        public async Task<string> RivigoGetAuthDetail()
        {
            string authtoken = "";
            try
            {
                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = "https://client-integration-api.rivigo.com/oauth/token";

                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };
                //pHeaderscust.Add("Accept", "*/*");
                pHeaderscust.Add("authorization", value: "Basic NjRjOTdkYTItOTUwYy00OTdlLWEwNGMtMDhmOWQ2ODM1MGZkOkVUQTlWb0p4N1o1NzYyRVhvNzJBNUQzVWpGcXdsWDNiT2Jvc1dmZHZVTWw4NzRyOXVO");

                //ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseText = sendingJson.newRequest("POST", url, "", pHeaderscust);
                //var result = JsonConvert.DeserializeObject<RivigoAuthApiResponse>(responseText);
                //authtoken = result.payload.access_token;
            }
            catch (Exception ex)
            {
                authtoken ="";
            }
            return authtoken;
        }

        //

        public IEnumerable<DocketBarcodeDetail> GetDocketBarcodeGetById(string documentId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@documentId", (object)documentId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketBarcodeDetail>("CL_BarCode_GetById", (object)dynamicParameters, "Docket - Insert");
        }

        public IEnumerable<DocketBarcodeDetail> DocketBarcodeList(string UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketBarcodeDetail>("CL_BarCode_GetAll", (object)dynamicParameters, "Docket - Insert");
        }

        public IEnumerable<TaxProEwayTripSheetApiResponse> TaxProGetEwayBillConsolidateList(string UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TaxProEwayTripSheetApiResponse>("US_EWayBillConsolidate_Detail_TaxPro_GetAll", (object)dynamicParameters, "Docket - Insert");
        }

        public IEnumerable<TaxProGetEwayDetailsForTransporterByStateApiResponse> TaxProGetEwayBillList(string UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TaxProGetEwayDetailsForTransporterByStateApiResponse>("US_EWayBill_Detail_TaxPro_GetAll", (object)dynamicParameters, "Docket - Insert");
        }
        public TaxProGetEwayDetailsForTransporterByStateApiResponse TaxProGetEwayDetails(string ewbNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ewbNo", (object)ewbNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<TaxProGetEwayDetailsForTransporterByStateApiResponse>, IEnumerable<EwayItemList>, IEnumerable<EwayVehiclListDetail>> tuple = DataBaseFactory.QueryMultipleSP<TaxProGetEwayDetailsForTransporterByStateApiResponse, EwayItemList, EwayVehiclListDetail>("US_EWayBill_Detail_TaxPro_GetById", (object)dynamicParameters, "Docket - US_EWayBill_Detail_TaxPro_GetById");
           
            TaxProGetEwayDetailsForTransporterByStateApiResponse mainResult = new TaxProGetEwayDetailsForTransporterByStateApiResponse();
            mainResult = tuple.Item1.FirstOrDefault<TaxProGetEwayDetailsForTransporterByStateApiResponse>();
            mainResult.itemList = tuple.Item2.ToList();
            mainResult.VehiclListDetails = tuple.Item3.ToList();

            return mainResult;
        }

        public async Task<byte[]> TaxProPrintEwayConsolidated(string cEwbNo)
        {
            string url = string.Empty;
            byte[] result = null;
            string tokenURI, baseURI, aspid, asppassword, password, authToken, userName, gstin, printURI;

            try
            {
                tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
                baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
                gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
                aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
                asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
                userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
                password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();
                printURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbasePrintURI"].ToString();


                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);

                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = baseURI + "action=GetTripSheet&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&authtoken=" + authToken + "&TripSheetNo=" + cEwbNo;
                Dictionary<string, string> pHeaderscust1 = new Dictionary<string, string>()
                {
                };
                string responseTextTrip = sendingJson.newRequest("GET", url, "", pHeaderscust1);
                if (responseTextTrip != null)
                {
                    Dictionary<string, string> pHeaderscust2 = new Dictionary<string, string>()
                    {
                    };
                    pHeaderscust2.Add(key: "aspid", value: aspid);
                    pHeaderscust2.Add(key: "password", value: asppassword);
                    pHeaderscust2.Add(key: "gstin", value: gstin);

                    result = sendingJson.downloadRequest(printURI, responseTextTrip, pHeaderscust2);
                }
            }
            catch (Exception ex)
            {
                result = null;
            }


            return result;
        }

        public async Task<TaxProEwayConsolidateApiResponse> TaxProEwayConsolidated(string DocumentId, string DocumentType, string EntryBy)
        {
            string url = string.Empty;

            string tokenURI, baseURI, aspid, asppassword, password, authToken, userName, gstin;

            TaxProEwayConsolidateApiResponse result  = new TaxProEwayConsolidateApiResponse();
            try
            {

                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("@DocumentId", (object)DocumentId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("@DocumentType", (object)DocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

                Tuple<IEnumerable<TaxProEwayConsolidated>, IEnumerable<TaxProEwayTripSheetEwbBills>> tuple = DataBaseFactory.QueryMultipleSP<TaxProEwayConsolidated, TaxProEwayTripSheetEwbBills>("US_EWayBillConsolidate_Detail_TaxPro_GetId", (object)dynamicParameters1, "Docket Master - ");
                TaxProEwayConsolidated req = tuple.Item1.FirstOrDefault<TaxProEwayConsolidated>();
                req.tripSheetEwbBills = tuple.Item2.ToList<TaxProEwayTripSheetEwbBills>();

                tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
                baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
                gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
                aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
                asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
                userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
                password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();

                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);


                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = baseURI + "action=GENCEWB&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&username=" + userName + "&authtoken=" + authToken;
                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };
                var RequestJson = JsonConvert.SerializeObject(req);
                string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);

                if (!responseText.Contains("error_cd"))
                {
                    result = JsonConvert.DeserializeObject<TaxProEwayConsolidateApiResponse>(responseText);

                    if (result != null)
                    {
                        url = baseURI + "action=GetTripSheet&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&authtoken=" + authToken + "&TripSheetNo=" + result.cEwbNo;
                        Dictionary<string, string> pHeaderscust1 = new Dictionary<string, string>()
                        {
                        };

                        string responseTextTrip = sendingJson.newRequest("GET", url, "", pHeaderscust);

                        if(!responseTextTrip.Contains("error_cd"))
                        {

                            var resultTrip = JsonConvert.DeserializeObject<TaxProEwayTripSheetApiResponse>(responseTextTrip);

                            if (resultTrip != null)
                            {
                                result.cEwbNo = resultTrip.tripSheetNo;
                                result.IsSuccess =true;
                                result.errorMsg = "";

                                resultTrip.EntryBy = EntryBy;
                                resultTrip.DocumentType =DocumentType;
                                DynamicParameters dynamicParameters = new DynamicParameters();
                                dynamicParameters.Add("@XmlTrip", (object)XmlUtility.XmlSerializeToString((object)resultTrip), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                                Response response = DataBaseFactory.QuerySP<Response>("Usp_EWayBill_Detail_TaxPro_Consolidate_Header_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
                            }
                        }
                        else
                        {
                            TaxProErrorList errorList = JsonConvert.DeserializeObject<TaxProErrorList>(responseText);
                            result.IsSuccess =false;
                            result.errorMsg = errorList.error.message;
                            InsertTaxProError(DocumentId, DocumentType, "GENCEWB", result.errorMsg);
                        }
                    }
                }
                else
                {
                    TaxProErrorList errorList = JsonConvert.DeserializeObject<TaxProErrorList>(responseText);
                    result.IsSuccess =false;
                    result.errorMsg = errorList.error.message;
                    InsertTaxProError(DocumentId, DocumentType, "GENCEWB", result.errorMsg);
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess =false;
                result.errorMsg = ex.Message;

                InsertTaxProError(DocumentId, DocumentType, "GENCEWB", result.errorMsg);
            }

            return result;
        }
        private Response ValidateEwaybillInDatabase(string ewbNo, string validUpto)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ewbNo", (object)ewbNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@validUpto", (object)validUpto, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
           return DataBaseFactory.QuerySP<Response>("CL_EWayBill_Detail_TaxPro_Ewaybill_Validate", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        private void InsertTaxProError( string DocumentId, string DocumentType, string DocumentAction, string DocumentError)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentId", (object)DocumentId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentType", (object)DocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentAction", (object)DocumentAction, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentError", (object)DocumentError, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Response response = DataBaseFactory.QuerySP<Response>("CL_EWayBill_Detail_TaxPro_Error_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }


        public async Task<TaxProEwayExtendValidityApiResponse> TaxProExtendValidity(TaxProEwayExtendValidityRequest req)
        {
            string url = string.Empty;

            string tokenURI, baseURI, aspid, asppassword, password, authToken, userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();
            TaxProEwayExtendValidityApiResponse result = new TaxProEwayExtendValidityApiResponse();

            try
            {
                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);


                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = baseURI + "action=EXTENDVALIDITY&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&username=" + userName + "&authtoken=" + authToken;
                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };
                var RequestJson = JsonConvert.SerializeObject(req);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);


                if (!responseText.Contains("error_cd"))
                {
                    result = JsonConvert.DeserializeObject<TaxProEwayExtendValidityApiResponse>(responseText);
                    result.IsSuccess =true;
                    result.errorMsg = "Extend validity successfully";
                }
                else
                {
                    TaxProErrorList errorList = JsonConvert.DeserializeObject<TaxProErrorList>(responseText);
                    result.IsSuccess =false;
                    result.errorMsg = errorList.error.message;
                    result.ewayBillNo = req.ewbNo;
                    result.validUpto = "";
                    result.updatedDate = "";
                    result.validUpto = "";


                }
            }
            catch (Exception ex)
            {
                result.IsSuccess =false;
                result.errorMsg = ex.Message;
                result.ewayBillNo = req.ewbNo;
                result.validUpto = "";
                result.updatedDate = "";
                result.validUpto = "";

            }
            return result;
        }

        public async Task<TaxProEwayExtendValidityApiResponse> TaxProExtendValidityAuthToken(TaxProEwayExtendValidityRequest req, string authToken)
        {
            string url = string.Empty;

            string tokenURI, baseURI, aspid, asppassword, password, userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();
            TaxProEwayExtendValidityApiResponse result = new TaxProEwayExtendValidityApiResponse();

            try
            {
                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                //authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);


                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = baseURI + "action=EXTENDVALIDITY&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&username=" + userName + "&authtoken=" + authToken;
                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };
                var RequestJson = JsonConvert.SerializeObject(req);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);


                if (!responseText.Contains("error_cd"))
                {
                    result = JsonConvert.DeserializeObject<TaxProEwayExtendValidityApiResponse>(responseText);
                    result.IsSuccess =true;
                    result.errorMsg = "Extend validity successfully";
                }
                else
                {
                    TaxProErrorList errorList = JsonConvert.DeserializeObject<TaxProErrorList>(responseText);
                    result.IsSuccess =false;
                    result.errorMsg = errorList.error.message;
                    result.ewayBillNo = req.ewbNo;
                    result.validUpto = "";
                    result.updatedDate = "";
                    result.validUpto = "";


                }
            }
            catch (Exception ex)
            {
                result.IsSuccess =false;
                result.errorMsg = ex.Message;
                result.ewayBillNo = req.ewbNo;
                result.validUpto = "";
                result.updatedDate = "";
                result.validUpto = "";

            }
            return result;
        }

        public async Task<TaxProGetEwayApiResponse> ValidateTaxProEwayBillAuthToken(string ewbNo, string authToken)
        {
            string tokenURI, baseURI, aspid, asppassword, password, userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();


            TaxProGetEwayApiResponse result = new TaxProGetEwayApiResponse();
            try
            {

                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                //authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);

                //if (authToken == "")
                //{
                //    result.status ="FAILED";
                //    result.errorMsg = "Token is not generated";
                //    return result;
                //}

                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();


                TaxProGetEwayDetailsForTransporterByStateApiResponse resulteway;
                string url2 = string.Empty;

                url2 = baseURI + "action=GetEwayBill&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&authtoken=" + authToken + "&ewbNo=" + ewbNo;

                Dictionary<string, string> pHeaders = new Dictionary<string, string>()
                {
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseeway = sendingJson.newRequest("GET", url2, "", pHeaders);

                if (!responseeway.Contains("error_cd"))
                {

                    resulteway = JsonConvert.DeserializeObject<TaxProGetEwayDetailsForTransporterByStateApiResponse>(responseeway);

                    result.status ="SUCCESS";
                    result.errorMsg = "";
                    result.ewbNo = resulteway.ewbNo;
                    result.ewbDate= resulteway.ewayBillDate;
                    result.validUpto = resulteway.validUpto;
                    result.actualDist = resulteway.actualDist;
                    result.fromPlace =  resulteway.fromPlace;
                    result.fromPincode =  resulteway.fromPincode;
                    result.toPincode =  resulteway.toPincode;
                    result.fromStateCode =  resulteway.fromStateCode;
                    result.vehicleNo = "";
                    foreach ( var item in  resulteway.VehiclListDetails)
                    {
                        result.vehicleNo = item.vehicleNo;
                        break;
                    }

                }
                else
                {
                    TaxProErrorList errorList = JsonConvert.DeserializeObject<TaxProErrorList>(responseeway);
                    result.status ="FAILED";
                    result.errorMsg = errorList.error.message;

                    InsertTaxProError(ewbNo, "Docket", "GetEwayBill", result.errorMsg);
                }
            }
            catch (WebException ex)
            {
                result.status ="FAILED";
                result.errorMsg = ex.Message;
                result.ewbDate= "";
                result.validUpto = "";
                result.actualDist = 0;
            }

            return result;
        }


        public async Task<TaxProGetEwayApiResponse> ValidateTaxProEwayBill(string ewbNo)
        {
            string tokenURI, baseURI, aspid, asppassword, password, authToken, userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();


            TaxProGetEwayApiResponse result = new TaxProGetEwayApiResponse ();
            try
            {

                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);

                if(authToken == "")
                {
                    result.status ="FAILED";
                    result.errorMsg = "Token is not generated";
                    return  result;
                }

                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();


                TaxProGetEwayDetailsForTransporterByStateApiResponse resulteway;
                string url2 = string.Empty;

                url2 = baseURI + "action=GetEwayBill&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&authtoken=" + authToken + "&ewbNo=" + ewbNo;

                Dictionary<string, string> pHeaders = new Dictionary<string, string>()
                {
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseeway = sendingJson.newRequest("GET", url2, "", pHeaders);

                if(!responseeway.Contains("error_cd"))
                {

                    resulteway = JsonConvert.DeserializeObject<TaxProGetEwayDetailsForTransporterByStateApiResponse>(responseeway);

                    result.status ="SUCCESS";
                    result.errorMsg = "";

                    if (string.IsNullOrEmpty(resulteway.validUpto))
                    {
                        resulteway.validUpto ="";
                    }

                    Response response = ValidateEwaybillInDatabase(resulteway.ewbNo.ToString(), resulteway.validUpto);

                    if(response != null)
                    {
                        if(!response.IsSuccessfull == true)
                        {
                            result.status ="FAILED";
                            result.errorMsg = response.ErrorMessage;
                        }
                    }

                    result.ewbNo = resulteway.ewbNo;
                    result.ewbDate= resulteway.ewayBillDate;
                    result.validUpto = resulteway.validUpto;
                    result.actualDist = resulteway.actualDist;
                    result.fromPlace =  resulteway.fromPlace;
                    result.fromPincode =  resulteway.fromPincode;
                    result.toPincode =  resulteway.toPincode;
                    result.fromStateCode =  resulteway.fromStateCode;
                }
                else
                {
                    TaxProErrorList errorList = JsonConvert.DeserializeObject<TaxProErrorList>(responseeway);
                    result.status ="FAILED";
                    result.errorMsg = errorList.error.message;
                   
                    InsertTaxProError(ewbNo, "Docket", "GetEwayBill", result.errorMsg);
                }
            }
            catch (WebException ex)
            {
                result.status ="FAILED";
                result.errorMsg = ex.Message;
                result.ewbDate= "";
                result.validUpto = "";
                result.actualDist = 0;
            }

            return result;
        }



        public async Task<IEnumerable<TaxProGetEwayForTransporterByStateApiResponse>> GetEwayBillsForTransporterByState(TaxProGetEwayForTransporterByStateRequest transporterRequest)
        {
            string tokenURI, baseURI, aspid, asppassword, password, authToken,  userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();


            List<TaxProGetEwayForTransporterByStateApiResponse> result;
            try
            {

                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);

                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
                url = baseURI + "action=GetEwayBillsForTransporterByState&aspid=" + aspid + "&password="+asppassword+"&gstin=" + gstin + "&username=" + userName + "&authtoken=" + authToken + "&date=" + transporterRequest.date + "&stateCode=" + transporterRequest.statecode;
                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseText = sendingJson.newRequest("GET", url, "", pHeaderscust);
                result = null;

                if (!responseText.Contains("error_cd"))
                {
                    result = JsonConvert.DeserializeObject<List<TaxProGetEwayForTransporterByStateApiResponse>>(responseText);
                    foreach (var item in result)
                    {
                        List<TaxProGetEwayDetailsForTransporterByStateApiResponse> gedbslist = new List<TaxProGetEwayDetailsForTransporterByStateApiResponse>();

                        gedbslist.Clear();

                        TaxProGetEwayDetailsForTransporterByStateApiResponse resulteway;
                        string url2 = string.Empty;

                        url2 = baseURI + "action=GetEwayBill&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&authtoken=" + authToken + "&ewbNo=" + item.ewbNo;

                        Dictionary<string, string> pHeaders = new Dictionary<string, string>()
                        {
                        };
                        string responseeway = sendingJson.newRequest("GET", url2, "", pHeaders);
                        resulteway = JsonConvert.DeserializeObject<TaxProGetEwayDetailsForTransporterByStateApiResponse>(responseeway);
                        foreach (var lst in resulteway.itemList)
                        {
                            lst.ewbNo = resulteway.ewbNo;
                        }
                        foreach (var lst in resulteway.VehiclListDetails)
                        {
                            lst.ewbNo = resulteway.ewbNo;
                        }

                        gedbslist.Add(resulteway);
                        //item.ewaydtl = gedbslist.ToList();

                        if (gedbslist != null && gedbslist.Count > 0)
                        {
                            DynamicParameters dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)gedbslist), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                            Response response = DataBaseFactory.QuerySP<Response>("US_EWayBill_Detail_TaxPro_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
                        }
                    }


                }





            }
            catch (Exception  ex)
            {
                result = null;

            }

            return result;
        }


        public async Task<TaxProGetEwayDetailsForTransporterByStateApiResponse> TaxProGetEwayBillDetail(string ewbNo)
        {
            string tokenURI, baseURI, aspid, asppassword, password, authToken, userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();

            TaxProGetEwayDetailsForTransporterByStateApiResponse resulteway;
            try
            {

                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);

                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;


                string url2 = string.Empty;

                url2 = baseURI + "action=GetEwayBill&aspid=" + aspid + "&password=" + asppassword + "&gstin=" + gstin + "&authtoken=" + authToken + "&ewbNo=" + ewbNo;

                Dictionary<string, string> pHeaders = new Dictionary<string, string>()
                {
                };
                string responseeway = sendingJson.newRequest("GET", url2, "", pHeaders);
                resulteway = JsonConvert.DeserializeObject<TaxProGetEwayDetailsForTransporterByStateApiResponse>(responseeway);


            }
            catch (Exception ex)
            {
                resulteway = null;

            }

            return resulteway;
        }


        public async Task<string> GetTaxProGetAuthDetail()
        {
            string tokenURI, baseURI, aspid, asppassword, password, authToken, userName, gstin;

            tokenURI = System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString();
            baseURI = System.Configuration.ConfigurationManager.AppSettings["TaxProbaseURI"].ToString();
            gstin = System.Configuration.ConfigurationManager.AppSettings["TaxProgstin"].ToString();
            aspid = System.Configuration.ConfigurationManager.AppSettings["TaxProaspid"].ToString();
            asppassword = System.Configuration.ConfigurationManager.AppSettings["TaxProasppassword"].ToString();
            userName = System.Configuration.ConfigurationManager.AppSettings["TaxProusername"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["TaxPropassword"].ToString();

            try
            {

                TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
                taxProAuthRequest.gstin = gstin;
                taxProAuthRequest.username = userName;
                taxProAuthRequest.ewbpwd = password;

                authToken = await TaxProGetAuthDetail(taxProAuthRequest, tokenURI, aspid, asppassword);


            }
            catch (Exception ex)
            {
                authToken = "";

            }

            return authToken;
        }


        private async Task<string> TaxProGetAuthDetail(TaxProAuthRequest authreq, string baseURI, string aspid, string asppassword)
        {
            string authtoken = "";
            try
            {
                string url = string.Empty;
                WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
//                url = baseURI + "action=ACCESSTOKEN&aspid=1637711520&password=Elpl@456789&gstin=" + authreq.gstin + "&username=" + authreq.username + "&ewbpwd=" + authreq.ewbpwd;
                url = baseURI + "action=ACCESSTOKEN&aspid="+aspid+"&password="+asppassword+"&gstin=" + authreq.gstin + "&username=" + authreq.username + "&ewbpwd=" + authreq.ewbpwd;

                Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
                {
                };

                //ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                string responseText = sendingJson.newRequest("GET", url, "", pHeaderscust);
                var result = JsonConvert.DeserializeObject<TaxProAuthApiResponse>(responseText);
                authtoken = result.authtoken;
            }
            catch(Exception ex)
            {
                authtoken ="";
            }


            return authtoken;
        }

        public async Task<TaxProEwayBillGenerationApiResponse> TaxProGenerateEwayBill(TaxProEwayBillGenerationRequest req, string baseURI, string aspid, string password, string gstIn, string userName)
        {
            string url = string.Empty;

            TaxProAuthRequest taxProAuthRequest = new TaxProAuthRequest();
            taxProAuthRequest.gstin = gstIn;
            taxProAuthRequest.username = userName;
            taxProAuthRequest.ewbpwd = password;
            var authRes = await TaxProGetAuthDetail(taxProAuthRequest, System.Configuration.ConfigurationManager.AppSettings["TaxProtokenURI"].ToString(), aspid, password);

            WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
            url = baseURI + "action=GENEWAYBILL&aspid=" + aspid + "&password=" + password + "&gstin=" + gstIn + "&username=" + userName + "&authtoken=" + authRes;
            Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
            {
            };
            var RequestJson = JsonConvert.SerializeObject(req);
            string responseText = sendingJson.newRequest("POST", url, RequestJson, pHeaderscust);
            var result = JsonConvert.DeserializeObject<TaxProEwayBillGenerationApiResponse>(responseText);

            DateTime ewayBillDate = Convert.ToDateTime(result.ewayBillDate);
            DateTime validUpto = Convert.ToDateTime(result.validUpto);

            return result;
        }

        public async Task<IEnumerable<ExtandValidityModel>> ExtandEwayValidity(ExtandValidityRequest extandValidity, string baseURI)
        {
            List<ExtandValidityModel> result;
            string url = string.Empty;
            WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
            var RequestJson = JsonConvert.SerializeObject(extandValidity);
            url = baseURI + "ExtendValidity";
            Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
            {
            };
            var responsecust = await sendingJson.Request(HttpMethod.Post, url, RequestJson, pHeaderscust);
            string responseText = await responsecust.Content.ReadAsStringAsync();
            string newres = responseText.Replace("\\", "");
            string newres1 = newres.Substring(1, newres.Length - 2).Replace("\"[", "[").Replace("]\"", "]");
            result = JsonConvert.DeserializeObject<List<ExtandValidityModel>>(newres1);
            return result;
        }

        public async Task<IEnumerable<GetEwayForDetails>> GetEWBTransporter(GetEwayDetailsRequest ewayreq, string baseURI)
        {

            string url2 = string.Empty;
            WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
            List<GetEwayForTransporter> result = new List<GetEwayForTransporter>();
            List<GetEwayForDetails> resulteway;

            List<EwbDetail> details = new List<EwbDetail>();
            url2 = baseURI + "GetEWB";

            var ewaydtlJson = JsonConvert.SerializeObject(ewayreq);
            Dictionary<string, string> pHeaderseway = new Dictionary<string, string>()
            {
            };

            var responseeway = await sendingJson.Request(HttpMethod.Post, url2, ewaydtlJson, pHeaderseway);
            string responseEwayText = await responseeway.Content.ReadAsStringAsync();
            string ewaydr = responseEwayText.Replace("\\", "");
            string ewaydtlr = ewaydr.Substring(1, ewaydr.Length - 2).Replace("\"[", "[").Replace("]\"", "]");
            string newewaydtlr = ewaydtlr.Replace("\"{", "{").Replace("}\"", "}");
            resulteway = JsonConvert.DeserializeObject<List<GetEwayForDetails>>(newewaydtlr);
            return resulteway;
        }

        public IEnumerable<GetEwayForTransporter> GetEWBForTransporter(GetEwayForTransporterRequest transporterRequest, string baseURI)
        {
            string url = string.Empty;
            string url2 = string.Empty;

            WebtelSendingJsonData sendingJson = new WebtelSendingJsonData();
            List<GetEwayForTransporter> result = new List<GetEwayForTransporter>();
            List<GetEwayForDetails> resulteway;

            List<EwbDetail> details = new List<EwbDetail>();
            url = baseURI + "GetEWBForTransporter";
            url2 = baseURI + "GetEWB";

            var ewayRequestJson = JsonConvert.SerializeObject(transporterRequest);
            Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
            {
            };

            string responseText = sendingJson.newRequest("POST", url, ewayRequestJson, pHeaderscust);

            //string responseText =  responsecust.Content.ReadAsString();
            string newres = responseText.Replace("\\", "");
            string newres1 = newres.Substring(1, newres.Length - 2).Replace("\"[", "[").Replace("]\"", "]");
            result = JsonConvert.DeserializeObject<List<GetEwayForTransporter>>(newres1);
            foreach (var item in result)
            {
                if (item.ewbDetails != null)
                {
                    foreach (var ed in item.ewbDetails)
                    {
                        GetEwayDetailsRequest getEway = new GetEwayDetailsRequest()
                        {
                            GSTIN = transporterRequest.GSTIN,
                            ewbNo = ed.ewbNo,
                            EWBUserName = transporterRequest.EWBUserName,
                            EWBPassword = transporterRequest.EWBPassword,
                            Year = transporterRequest.Year,
                            Month = transporterRequest.Month,
                            EFUserName = transporterRequest.EFUserName,
                            EFPassword = transporterRequest.EFPassword,
                            CDKey = transporterRequest.CDKey
                        };
                        var ewaydtlJson = JsonConvert.SerializeObject(getEway);
                        Dictionary<string, string> pHeaderseway = new Dictionary<string, string>()
                        {
                        };

                        string responseEwayText = sendingJson.newRequest("POST", url2, ewaydtlJson, pHeaderseway);
                        //string responseEwayText = await responseeway.Content.ReadAsStringAsync();
                        string ewaydr = responseEwayText.Replace("\\", "");
                        string ewaydtlr = ewaydr.Substring(1, ewaydr.Length - 2).Replace("\"[", "[").Replace("]\"", "]");
                        string newewaydtlr = ewaydtlr.Replace("\"{", "{").Replace("}\"", "}");
                        resulteway = JsonConvert.DeserializeObject<List<GetEwayForDetails>>(newewaydtlr);
                        ed.EwbDetails = resulteway.Select(x => x.ewbDetails).ToList();
                    }
                }
            }
            return result;
        }


        public Response GetStep6DetailForReinvoke(string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_GetStep6DetailForReinvoke", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public Docket GetStep6DetailByIdByChangeAmount(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Docket>, IEnumerable<MasterCharge>, IEnumerable<MasterTax>> tuple = DataBaseFactory.QueryMultipleSP<Docket, MasterCharge, MasterTax>("Usp_Docket_GetStep6DetailByIdByChangeAmount", (object)dynamicParameters, "Docket Master - GetStep6DetailById");
            Docket docket = new Docket();
            if (tuple != null)
            {
                docket = tuple.Item1.FirstOrDefault<Docket>();
                docket.ChargeList = tuple.Item2.ToList<MasterCharge>();
                docket.TaxList = tuple.Item3.ToList<MasterTax>();
            }
            return docket;
        }

        public DocketStep6 ChangeDocketList(string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<DocketEdit>, IEnumerable<TransportModeToServiceMapping>> tuple = DataBaseFactory.QueryMultipleSP<AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, DocketEdit, TransportModeToServiceMapping>("ChangeDocket_List", (object)dynamicParameters, "Docket Master - ");
            DocketStep6 docketStep6 = new DocketStep6();
            docketStep6.RateTypeList  =  tuple.Item1.ToList<AutoCompleteResult>();
            docketStep6.ServiceTaxPayerList  =  tuple.Item2.ToList<AutoCompleteResult>();
            docketStep6.CustomerGSTList  =  tuple.Item3.ToList<AutoCompleteResult>();
            docketStep6.CompanyGSTList  =  tuple.Item4.ToList<AutoCompleteResult>();
            docketStep6.DocketEditList  =  tuple.Item5.ToList<DocketEdit>();
            docketStep6.ServiceMappingList  =  tuple.Item6.ToList<TransportModeToServiceMapping>();

            return docketStep6;
        }
        public Response CheckValidTHCNoForUpdate(string THCNo, int ToSave)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@THCNo", (object)THCNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToSave", (object)ToSave, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_CheckValidThcNoForUpdate", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<Response> CheckValidThcForUpdate(string ThcId, string VendorId, string updateFor, string LRNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)ThcId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UpdateFor", (object)updateFor, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LRNo", (object)LRNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<Response>("Usp_Docket_CheckValidThcForUpdate", (object)dynamicParameters, "Docket - Insert");

        }
        public Thc ThcGetDetailById(string ThcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)ThcId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<Thc>, IEnumerable<DocketInvoice>, IEnumerable<DocketInvoice>> tuple = DataBaseFactory.QueryMultipleSP<Thc, DocketInvoice, DocketInvoice>("Usp_Thc_GetDetailById", (object)dynamicParameters, "Docket Master - ");
            Thc thc = tuple.Item1.FirstOrDefault<Thc>();
            thc.InvoiceList = tuple.Item2.ToList<DocketInvoice>();
            thc.LRList = tuple.Item3.ToList<DocketInvoice>();

            if (thc.LRList.Count==0)
            {
                thc.LRList.Add(new DocketInvoice(
                    ));

            }

            return thc;
        }
        public long CheckDocketDimension(string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDimension", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_CheckDocketDimension", (object)dynamicParameters, "Docket - Update");
            return dynamicParameters.Get<long>("@IsDimension");
        }
        public Docket DocketGetDetailById(string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<Docket>, IEnumerable<DocketInvoice>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>> tuple = DataBaseFactory.QueryMultipleSP<Docket, DocketInvoice, AutoCompleteResult, AutoCompleteResult>("Usp_DocketDetail_GetDetailById", (object)dynamicParameters, "Docket Master - ");
            Docket docket = tuple.Item1.FirstOrDefault<Docket>();
            docket.InvoiceList = tuple.Item2.ToList<DocketInvoice>();
            docket.ServiceTypeList = tuple.Item3.ToList<AutoCompleteResult>();
            docket.FtlTypeList = tuple.Item4.ToList<AutoCompleteResult>();

            return docket;
        }

        public IEnumerable<MasterCharge> GetDocketChargeList(string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCharge>("Usp_Docket_Upload_GetCharges", (object)dynamicParameters, "Docket - Update");
        }

        public IEnumerable<LoadingSheetDocket> GetDocketListForRecalculate(
                    byte companyId,
                    short locationId,
                    string docketList,
                    DateTime fromDate,
                    DateTime toDate,
                    byte transportModeId,
                    int fromCityId,
                    int toCityId,
                    string toLocationList,
                    string zoneList,
                    long CustomerId
                    , string PickupList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketList", (object)docketList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromCityId", (object)fromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)toCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationList", (object)toLocationList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ZoneList", (object)zoneList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PickupList", (object)PickupList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<LoadingSheetDocket>("Usp_LoadingSheet_GetDocketListForRecalculate", (object)dynamicParameters, "LoadingSheet - GetDocketListForRecalculate");
        }
        public IEnumerable<RecalculateDetail> GetRecalculate(DocketSearch objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketUpload", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<RecalculateDetail>("Usp_Docket_Upload_Recalculate", (object)dynamicParameters, "Docket - Update");
        }
        public DocketStatus DocketStatusGetByCode(string DocketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<DocketStatus>, IEnumerable<DocketStatusDetail>> tuple = DataBaseFactory.QueryMultipleSP<DocketStatus, DocketStatusDetail>("CL_Docket_Status_GetByCode", (object)dynamicParameters, "Docket Master - ");
            DocketStatus docketStatus = tuple.Item1.FirstOrDefault<DocketStatus>();
            docketStatus.StatusDetail = tuple.Item2.ToList<DocketStatusDetail>();

            return docketStatus;
        }
        public IEnumerable<DocketStatus> DocketStatusGetAll(string CustomerId, string Fromdate, string ToDate, string flag)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Fromdate", (object)Fromdate, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)ToDate, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@flag", (object)flag, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<DocketStatus>("CL_Docket_Status_GetAll", (object)dynamicParameters, "GetAll");
        }
        public Response InsertDocketStatus(DocketStatus objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_Docket_Status_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<AutoCompleteResult> DocketStatusList(
        string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("CL_Docket_StatusList", (object)dynamicParameters, "Status List");
        }
        public DocketStatus DocketStatusGetById(string DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<DocketStatus>, IEnumerable<DocketStatusDetail>> tuple = DataBaseFactory.QueryMultipleSP<DocketStatus, DocketStatusDetail>("CL_Docket_Status_GetById", (object)dynamicParameters, "Docket Master - ");
            DocketStatus docketStatus = tuple.Item1.FirstOrDefault<DocketStatus>();
            docketStatus.StatusDetail = tuple.Item2.ToList<DocketStatusDetail>();

            return docketStatus;
        }

        public DocketStep1 GetStep1Detail(short locationId, byte companyId)
        {
            DynamicParameters dynamicParameter = new DynamicParameters();
            ParameterDirection? nullable = null;
            int? nullable1 = null;
            byte? nullable2 = null;
            byte? nullable3 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@LocationId", locationId, new DbType?(DbType.Int16), nullable, nullable1, nullable3, nullable2);
            nullable = null;
            nullable1 = null;
            nullable2 = null;
            byte? nullable4 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@CompanyId", companyId, new DbType?(DbType.Byte), nullable, nullable1, nullable4, nullable2);
            Tuple<IEnumerable<DocketStep1>, IEnumerable<AutoCompleteResult>, IEnumerable<object>, IEnumerable<object>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep1, AutoCompleteResult, object, object>("Usp_Docket_GetStep1Detail", dynamicParameter, "Docket - GetStep1Detail");
            DocketStep1 docketStep1 = new DocketStep1();
            docketStep1 = tuple.Item1.FirstOrDefault<DocketStep1>();
            docketStep1.PaybasList = tuple.Item2;
            docketStep1.ConsignorConsigneePartyMappingSetting = new string[docketStep1.PaybasList.Count<AutoCompleteResult>(), 2];
            int num = 0;
            foreach (IDictionary<string, object> item3 in tuple.Item3)
            {
                int num1 = 0;
                foreach (KeyValuePair<string, object> keyValuePair in item3)
                {
                    docketStep1.ConsignorConsigneePartyMappingSetting[num, num1] = keyValuePair.Value.ToString();
                    num1++;
                }
                num++;
            }
            docketStep1.PartySetting = new string[docketStep1.PaybasList.Count<AutoCompleteResult>(), 2];
            int num2 = 0;
            foreach (IDictionary<string, object> item4 in tuple.Item4)
            {
                int num3 = 0;
                foreach (KeyValuePair<string, object> keyValuePair1 in item4)
                {
                    docketStep1.PartySetting[num2, num3] = keyValuePair1.Value.ToString();
                    num3++;
                }
                num2++;
            }
            return docketStep1;
        }

        public DocketStep2 GetStep2Detail(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)objDocket.CustomerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<DocketStep2>, IEnumerable<AutoCompleteResult>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep2, AutoCompleteResult>("Usp_Docket_GetStep2Detail", (object)dynamicParameters, "Docket - GetStep2Detail");
            DocketStep2 docketStep2_1 = new DocketStep2();
            DocketStep2 docketStep2_2 = tuple.Item1.FirstOrDefault<DocketStep2>();
            if (docketStep2_2.IsSuccessfull)
                docketStep2_2.CustomerGroupList = tuple.Item2;
            return docketStep2_2;
        }

        public DocketStep3 GetStep3Detail(Docket objDocket)
        {
            if (objDocket.ConsignorId == (short)1 && objDocket.IsWalkInConsignorSaveInSystem)
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@GroupCode", (object)objDocket.ConsignorGroupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerName", (object)objDocket.ConsignorName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address1", (object)objDocket.ConsignorAddress1, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address2", (object)objDocket.ConsignorAddress2, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CityId", (object)objDocket.ConsignorCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Pincode", (object)objDocket.ConsignorPincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@MobileNo", (object)objDocket.ConsignorMobileNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EmailId", (object)objDocket.ConsignorEmailId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@GstTinNo", (object)objDocket.ConsignorGstTinNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@LocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocket.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CompanyId", (object)objDocket.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@IsCustomerGst", (object)objDocket.IsConsignorGst, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PanNo", objDocket.ConsignorPanNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PhoneNo", (object)objDocket.ConsignorPhoneNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerCode", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(10));
                DataBaseFactory.QuerySP("Usp_MasterCustomer_WalkInInsert", (object)dynamicParameters, "Country Master - Consignor Insert");
                objDocket.ConsignorId = dynamicParameters.Get<short>("@CustomerId");
                objDocket.ConsignorCode = dynamicParameters.Get<string>("@CustomerCode");
            }
            if (objDocket.ConsigneeId == (short)1 && objDocket.IsWalkInConsigneeSaveInSystem)
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@GroupCode", (object)objDocket.ConsigneeGroupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerName", (object)objDocket.ConsigneeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address1", (object)objDocket.ConsigneeAddress1, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address2", (object)objDocket.ConsigneeAddress2, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CityId", (object)objDocket.ConsigneeCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Pincode", (object)objDocket.ConsigneePincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@MobileNo", (object)objDocket.ConsigneeMobileNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EmailId", (object)objDocket.ConsigneeEmailId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@GstTinNo", (object)objDocket.ConsigneeGstTinNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@LocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocket.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CompanyId", (object)objDocket.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@IsCustomerGst", (object)objDocket.IsConsigneeGst, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PanNo", objDocket.ConsigneePanNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PhoneNo", (object)objDocket.ConsigneePhoneNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerCode", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(10));
                DataBaseFactory.QuerySP("Usp_MasterCustomer_WalkInInsert", (object)dynamicParameters, "Country Master - Consignee Insert");
                objDocket.ConsigneeId = dynamicParameters.Get<short>("@CustomerId");
                objDocket.ConsigneeCode = dynamicParameters.Get<string>("@CustomerCode");
            }
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            dynamicParameters1.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@CustomerId", (object)objDocket.CustomerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@FromLocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@ToLocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@ConsignorId", (object)objDocket.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@ConsigneeId", (object)objDocket.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@MappingBillingPartyId", (object)objDocket.MappingBillingPartyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsConsignorConsigneePartyMapping", (object)objDocket.IsConsignorConsigneePartyMapping, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsConsignorFromMaster", (object)objDocket.IsConsignorFromMaster, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsConsigneeFromMaster", (object)objDocket.IsConsigneeFromMaster, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsWalkInConsignorSaveInSystem", (object)objDocket.IsWalkInConsignorSaveInSystem, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsWalkInConsigneeSaveInSystem", (object)objDocket.IsWalkInConsigneeSaveInSystem, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<DocketStep3>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, Tuple<IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep3, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult>("Usp_Docket_GetStep3Detail", (object)dynamicParameters1, "Docket - GetStep3Detail");
            DocketStep3 docketStep3_1 = new DocketStep3();
            DocketStep3 docketStep3_2 = tuple.Item1.FirstOrDefault<DocketStep3>();
            if (docketStep3_2.IsSuccessfull)
            {
                docketStep3_2.ConsignorId = objDocket.ConsignorId;
                docketStep3_2.ConsignorCode = objDocket.ConsignorCode;
                docketStep3_2.ConsigneeId = objDocket.ConsigneeId;
                docketStep3_2.ConsigneeCode = objDocket.ConsigneeCode;
                docketStep3_2.FromCity = tuple.Item2.FirstOrDefault<AutoCompleteResult>();
                docketStep3_2.ToCity = tuple.Item3.FirstOrDefault<AutoCompleteResult>();
                docketStep3_2.TransportModeList = tuple.Item4;
                docketStep3_2.ServiceTypeList = tuple.Item5;
                docketStep3_2.PickupDeliveryList = tuple.Item6;
                docketStep3_2.PackagingTypeList = tuple.Item7;
                docketStep3_2.ProductTypeList = tuple.Rest.Item1;
                docketStep3_2.BusinessTypeList = tuple.Rest.Item2;
                docketStep3_2.IndustryList = tuple.Rest.Item3;
                docketStep3_2.LoadTypeList = tuple.Rest.Item4;
                docketStep3_2.DivisionList = tuple.Rest.Item5;
                docketStep3_2.FtlTypeList = tuple.Rest.Item6;
            }
            return docketStep3_2;
        }
        public DocketStep3 GetStep3DetailforPincode(Docket objDocket)
        {
            if (objDocket.ConsignorId == (short)1 && objDocket.IsWalkInConsignorSaveInSystem)
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@GroupCode", (object)objDocket.ConsignorGroupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerName", (object)objDocket.ConsignorName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address1", (object)objDocket.ConsignorAddress1, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address2", (object)objDocket.ConsignorAddress2, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CityId", (object)objDocket.ConsignorCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Pincode", (object)objDocket.ConsignorPincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@MobileNo", (object)objDocket.ConsignorMobileNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EmailId", (object)objDocket.ConsignorEmailId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@GstTinNo", (object)objDocket.ConsignorGstTinNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@LocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocket.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CompanyId", (object)objDocket.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerCode", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(10));
                DataBaseFactory.QuerySP("Usp_MasterCustomer_WalkInInsert", (object)dynamicParameters, "Country Master - Consignor Insert");
                objDocket.ConsignorId = dynamicParameters.Get<short>("@CustomerId");
                objDocket.ConsignorCode = dynamicParameters.Get<string>("@CustomerCode");
            }
            if (objDocket.ConsigneeId == (short)1 && objDocket.IsWalkInConsigneeSaveInSystem)
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@GroupCode", (object)objDocket.ConsigneeGroupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerName", (object)objDocket.ConsigneeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address1", (object)objDocket.ConsigneeAddress1, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Address2", (object)objDocket.ConsigneeAddress2, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CityId", (object)objDocket.ConsigneeCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@Pincode", (object)objDocket.ConsigneePincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@MobileNo", (object)objDocket.ConsigneeMobileNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EmailId", (object)objDocket.ConsigneeEmailId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@GstTinNo", (object)objDocket.ConsigneeGstTinNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@LocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocket.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CompanyId", (object)objDocket.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@CustomerCode", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(10));
                DataBaseFactory.QuerySP("Usp_MasterCustomer_WalkInInsert", (object)dynamicParameters, "Country Master - Consignee Insert");
                objDocket.ConsigneeId = dynamicParameters.Get<short>("@CustomerId");
                objDocket.ConsigneeCode = dynamicParameters.Get<string>("@CustomerCode");
            }
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            dynamicParameters1.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@CustomerId", (object)objDocket.CustomerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@FromLocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@ToLocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@ConsignorId", (object)objDocket.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@ConsigneeId", (object)objDocket.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@MappingBillingPartyId", (object)objDocket.MappingBillingPartyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsConsignorConsigneePartyMapping", (object)objDocket.IsConsignorConsigneePartyMapping, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsConsignorFromMaster", (object)objDocket.IsConsignorFromMaster, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsConsigneeFromMaster", (object)objDocket.IsConsigneeFromMaster, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsWalkInConsignorSaveInSystem", (object)objDocket.IsWalkInConsignorSaveInSystem, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@IsWalkInConsigneeSaveInSystem", (object)objDocket.IsWalkInConsigneeSaveInSystem, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("@PinCodeId", (object)objDocket.PincodeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());


            Tuple<IEnumerable<DocketStep3>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, Tuple<IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep3, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult, AutoCompleteResult>("Usp_Docket_GetStep3Detail", (object)dynamicParameters1, "Docket - GetStep3Detail");
            DocketStep3 docketStep3_1 = new DocketStep3();
            DocketStep3 docketStep3_2 = tuple.Item1.FirstOrDefault<DocketStep3>();
            if (docketStep3_2.IsSuccessfull)
            {
                docketStep3_2.ConsignorId = objDocket.ConsignorId;
                docketStep3_2.ConsignorCode = objDocket.ConsignorCode;
                docketStep3_2.ConsigneeId = objDocket.ConsigneeId;
                docketStep3_2.ConsigneeCode = objDocket.ConsigneeCode;
                docketStep3_2.FromCity = tuple.Item2.FirstOrDefault<AutoCompleteResult>();
                docketStep3_2.ToCity = tuple.Item3.FirstOrDefault<AutoCompleteResult>();
                docketStep3_2.TransportModeList = tuple.Item4;
                docketStep3_2.ServiceTypeList = tuple.Item5;
                docketStep3_2.PickupDeliveryList = tuple.Item6;
                docketStep3_2.PackagingTypeList = tuple.Item7;
                docketStep3_2.ProductTypeList = tuple.Rest.Item1;
                docketStep3_2.BusinessTypeList = tuple.Rest.Item2;
                docketStep3_2.IndustryList = tuple.Rest.Item3;
                docketStep3_2.LoadTypeList = tuple.Rest.Item4;
                docketStep3_2.DivisionList = tuple.Rest.Item5;
                docketStep3_2.FtlTypeList = tuple.Rest.Item6;
            }
            return docketStep3_2;
        }
        public DocketStep4 GetStep4Detail(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromCityId", (object)objDocket.FromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)objDocket.ToCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<AutoCompleteResult>, IEnumerable<DocketDocument>> tuple = DataBaseFactory.QueryMultipleSP<AutoCompleteResult, DocketDocument>("Usp_Docket_GetStep4Detail", (object)dynamicParameters, "Docket - GetStep4Detail");
            return new DocketStep4()
            {
                PermitReceivedAtList = tuple.Item1,
                DocumentList = tuple.Item2
            };
        }
        
        public DocketStep5 GetStep5Detail(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objDocket.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceNo", (object)objDocket.WmsInvoiceNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<DocketStep5>, IEnumerable<DocketInvoice>, IEnumerable<MasterPackagingMeasurement>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep5, DocketInvoice, MasterPackagingMeasurement>("Usp_Docket_GetStep5Detail", (object)dynamicParameters, "Docket - GetStep5Detail");
            DocketStep5 docketStep5_1 = new DocketStep5();
            DocketStep5 docketStep5_2 = tuple.Item1.FirstOrDefault<DocketStep5>();
            docketStep5_2.InvoiceList = tuple.Item2;
            docketStep5_2.TypeOfPackageList = tuple.Item3;
            return docketStep5_2;
        }

        public DocketStep6 GetStep6Detail(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objDocket.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromCityId", (object)objDocket.FromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)objDocket.ToCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)objDocket.FtlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)objDocket.BusinessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)objDocket.ServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ProductTypeId", (object)objDocket.ProductTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PackagingTypeId", (object)objDocket.PackagingTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)objDocket.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)objDocket.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Packages", (object)objDocket.Packages, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ActualWeight", (object)objDocket.ActualWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChargedWeight", (object)objDocket.ChargedWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceAmount", (object)objDocket.InvoiceAmount, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsOda", (object)objDocket.IsOda, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCod", (object)objDocket.IsCod, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDacc", (object)objDocket.IsDacc, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsLocal", (object)objDocket.IsLocal, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCarrierRisk", (object)objDocket.IsCarrierRisk, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDoorDelivery", (object)objDocket.IsDoorDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)objDocket.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsMultiPickup", (object)objDocket.IsMultiPickup, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsMultiDelivery", (object)objDocket.IsMultiDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<ContractKeys>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<MasterCharge>, IEnumerable<MasterTax>, IEnumerable<MinimumFreightDetails>> tuple = DataBaseFactory.QueryMultipleSP<ContractKeys, AutoCompleteResult, AutoCompleteResult, MasterCharge, MasterTax, MinimumFreightDetails>("Usp_Docket_GetStep6Detail", (object)dynamicParameters, "Docket - GetStep6Detail");
            DocketStep6 docketStep6 = new DocketStep6();
            docketStep6.IsGst = objDocket.DocketDate >= ConfigHelper.GstDate;
            docketStep6.Keys = tuple.Item1.FirstOrDefault<ContractKeys>();
            if (docketStep6.Keys.IsSuccessfull)
            {
                docketStep6.RateTypeList = tuple.Item2;
                docketStep6.ServiceTaxPayerList = tuple.Item3;
                docketStep6.OtherChargeList = tuple.Item4;
                docketStep6.TaxList = tuple.Item5;
                if (tuple.Item6 != null)
                    docketStep6.MinimumFreightDetails = tuple.Item6.FirstOrDefault<MinimumFreightDetails>();
                else
                    docketStep6.MinimumFreightDetails = new MinimumFreightDetails()
                    {
                        MinimumFreightRate = new Decimal(0),
                        MinimumFreightRateType = "",
                        MinimumFreightAmount = new Decimal(0),
                        MinimumFreightLowerLimit = new Decimal(0),
                        MinimumFreightUpperLimit = new Decimal(0),
                        MinimumSubTotalAmount = new Decimal(0),
                        SubTotalLowerLimit = new Decimal(0),
                        SubTotalUpperLimit = new Decimal(0),
                        UseMinimumFreightTypeBaseWise = false,
                        UseFreightRateLimit = false,
                        UseSubTotalLimit = false
                    };
            }
            return docketStep6;
        }

        public DocketStep6 GetStep6DetailTrispeed(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objDocket.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromCityId", (object)objDocket.FromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)objDocket.ToCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)objDocket.FtlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)objDocket.BusinessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)objDocket.ServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ProductTypeId", (object)objDocket.ProductTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PackagingTypeId", (object)objDocket.PackagingTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)objDocket.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)objDocket.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Packages", (object)objDocket.Packages, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ActualWeight", (object)objDocket.ActualWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChargedWeight", (object)objDocket.ChargedWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceAmount", (object)objDocket.InvoiceAmount, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsOda", (object)objDocket.IsOda, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCod", (object)objDocket.IsCod, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDacc", (object)objDocket.IsDacc, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsLocal", (object)objDocket.IsLocal, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCarrierRisk", (object)objDocket.IsCarrierRisk, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDoorDelivery", (object)objDocket.IsDoorDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)objDocket.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsMultiPickup", (object)objDocket.IsMultiPickup, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsMultiDelivery", (object)objDocket.IsMultiDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartQuantity", (object)objDocket.TotalPartQuantity, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<ContractKeys>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<MasterCharge>, IEnumerable<MasterTax>, IEnumerable<MinimumFreightDetails>> tuple = DataBaseFactory.QueryMultipleSP<ContractKeys, AutoCompleteResult, AutoCompleteResult, MasterCharge, MasterTax, MinimumFreightDetails>("Usp_Docket_GetStep6Detail", (object)dynamicParameters, "Docket - GetStep6Detail");
            DocketStep6 docketStep6 = new DocketStep6();
            docketStep6.IsGst = objDocket.DocketDate >= ConfigHelper.GstDate;
            docketStep6.Keys = tuple.Item1.FirstOrDefault<ContractKeys>();
            if (docketStep6.Keys.IsSuccessfull)
            {
                docketStep6.RateTypeList = tuple.Item2;
                docketStep6.ServiceTaxPayerList = tuple.Item3;
                docketStep6.OtherChargeList = tuple.Item4;
                docketStep6.TaxList = tuple.Item5;
                if (tuple.Item6 != null)
                    docketStep6.MinimumFreightDetails = tuple.Item6.FirstOrDefault<MinimumFreightDetails>();
                else
                    docketStep6.MinimumFreightDetails = new MinimumFreightDetails()
                    {
                        MinimumFreightRate = new Decimal(0),
                        MinimumFreightRateType = "",
                        MinimumFreightAmount = new Decimal(0),
                        MinimumFreightLowerLimit = new Decimal(0),
                        MinimumFreightUpperLimit = new Decimal(0),
                        MinimumSubTotalAmount = new Decimal(0),
                        SubTotalLowerLimit = new Decimal(0),
                        SubTotalUpperLimit = new Decimal(0),
                        UseMinimumFreightTypeBaseWise = false,
                        UseFreightRateLimit = false,
                        UseSubTotalLimit = false
                    };
            }
            return docketStep6;
        }

        public DocketStep6 GetPaymentDetail(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<ContractKeys>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<MasterCharge>, IEnumerable<MasterTax>, IEnumerable<MinimumFreightDetails>> tuple = DataBaseFactory.QueryMultipleSP<ContractKeys, AutoCompleteResult, AutoCompleteResult, MasterCharge, MasterTax, MinimumFreightDetails>("Usp_Docket_GetPaymentDetail", (object)dynamicParameters, "Docket - GetPaymentDetail");
            DocketStep6 docketStep6 = new DocketStep6();
            docketStep6.Keys = tuple.Item1.FirstOrDefault<ContractKeys>();
            if (docketStep6.Keys.IsSuccessfull)
            {
                docketStep6.IsGst = docketStep6.Keys.DocketDate >= ConfigHelper.GstDate;
                docketStep6.RateTypeList = tuple.Item2;
                docketStep6.ServiceTaxPayerList = tuple.Item3;
                docketStep6.OtherChargeList = tuple.Item4;
                docketStep6.TaxList = tuple.Item5;
                if (tuple.Item6 != null)
                    docketStep6.MinimumFreightDetails = tuple.Item6.FirstOrDefault<MinimumFreightDetails>();
                else
                    docketStep6.MinimumFreightDetails = new MinimumFreightDetails()
                    {
                        MinimumFreightRate = new Decimal(0),
                        MinimumFreightRateType = "",
                        MinimumFreightAmount = new Decimal(0),
                        MinimumFreightLowerLimit = new Decimal(0),
                        MinimumFreightUpperLimit = new Decimal(0),
                        MinimumSubTotalAmount = new Decimal(0),
                        SubTotalLowerLimit = new Decimal(0),
                        SubTotalUpperLimit = new Decimal(0),
                        UseMinimumFreightTypeBaseWise = false,
                        UseFreightRateLimit = false,
                        UseSubTotalLimit = false
                    };
            }
            return docketStep6;
        }
        public Response InsertDocketReAssign(DocketReAssign objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)objDocket.DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)objDocket.ToLocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Remarks", (object)objDocket.Remarks, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objDocket.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_ReAssign", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public Response Insert(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public Response DumptcoDocketInsert(Docket objDocket)
        {
            //foreach (DocketInvoice invoiceList in objDocket.InvoiceList)
            //{
            //    if (!string.IsNullOrEmpty(invoiceList.EwayBillNo))
            //    {
            //        DataSet ds = GetEwayBillDetail(invoiceList.EwayBillNo);
            //        DynamicParameters param = new DynamicParameters();
            //        param.Add("@Doc", (object)ds.GetXml().ToString(), new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //        DataBaseFactory.QuerySP<Response>("CL_EWayBill_Config_Ins", (object)param, "Docket - Insert").FirstOrDefault<Response>();
            //    }
            //}

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var result = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
            return result;
        }


        public Response EssentialDocketInsert(Docket objDocket)
        {
            //foreach (DocketInvoice invoiceList in objDocket.InvoiceList)
            //{
            //    if (!string.IsNullOrEmpty(invoiceList.EwayBillNo))
            //    {
            //        DataSet ds = GetEwayBillDetail(invoiceList.EwayBillNo);
            //        DynamicParameters param = new DynamicParameters();
            //        param.Add("@Doc", (object)ds.GetXml().ToString(), new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //        DataBaseFactory.QuerySP<Response>("CL_EWayBill_Config_Ins", (object)param, "Docket - Insert").FirstOrDefault<Response>();
            //    }
            //}

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var result = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
            return result;
        }

        public Response Update(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_Update", (object)dynamicParameters, "Docket - Update").FirstOrDefault<Response>();
        }

        public Docket GetStep1DetailById(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetStep1DetailById", (object)dynamicParameters, "Docket Master - GetStep1DetailById").FirstOrDefault<Docket>();
        }

        public Docket GetStep2DetailById(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetStep2DetailById", (object)dynamicParameters, "Docket Master - GetStep2DetailById").FirstOrDefault<Docket>();
        }

        public Docket GetStep3DetailById(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetStep3DetailById", (object)dynamicParameters, "Docket Master - GetStep3DetailById").FirstOrDefault<Docket>();
        }

        public Docket GetStep4DetailById(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetStep4DetailById", (object)dynamicParameters, "Docket Master - GetStep4DetailById").FirstOrDefault<Docket>();
        }

        public Docket GetStep5DetailById(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Docket>, IEnumerable<DocketInvoice>, IEnumerable<InvoicePart>, IEnumerable<InvoiceVolumetric>> tuple = DataBaseFactory.QueryMultipleSP<Docket, DocketInvoice, InvoicePart, InvoiceVolumetric>("Usp_Docket_GetStep5DetailById", (object)dynamicParameters, "Docket Master - GetStep5DetailById");
            Docket docket = new Docket();
            if (tuple != null)
            {
                docket = tuple.Item1.FirstOrDefault<Docket>();
                foreach (DocketInvoice docketInvoice in tuple.Item2)
                {
                    foreach (InvoicePart invoicePart in tuple.Item3)
                    {
                        if (invoicePart.InvoiceId == docketInvoice.InvoiceId)
                            docketInvoice.PartList.Add(invoicePart);
                    }
                    docket.InvoiceList.Add(docketInvoice);
                }

                if (tuple.Item4 != null)
                {
                    foreach (InvoiceVolumetric invoiceVolumetric in tuple.Item4)
                    {
                        docket.InvoiceVolumetricList.Add(invoiceVolumetric);
                    }
                }
            }
           
            return docket;
        }

        public Docket GetStep6DetailById(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Docket>, IEnumerable<MasterCharge>, IEnumerable<MasterTax>> tuple = DataBaseFactory.QueryMultipleSP<Docket, MasterCharge, MasterTax>("Usp_Docket_GetStep6DetailById", (object)dynamicParameters, "Docket Master - GetStep6DetailById");
            Docket docket = new Docket();
            if (tuple != null)
            {
                docket = tuple.Item1.FirstOrDefault<Docket>();
                docket.ChargeList = tuple.Item2.ToList<MasterCharge>();
                docket.TaxList = tuple.Item3.ToList<MasterTax>();
            }
            return docket;
        }

        public long CheckValidDocketNoForUpdate(string docketNo, bool isFinancialUpdate, string searchType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsFinancialUpdate", (object)isFinancialUpdate, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@searchType", (object)searchType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_CheckValidDocketNoForUpdate", (object)dynamicParameters, "Docket Master - Update");
            return dynamicParameters.Get<long>("@DocketId");
        }

        public bool CheckManifestStatusAndUnderDrsForUpdate(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_CheckManifestStatusAndUnderDrsForUpdate", (object)dynamicParameters, "Docket Master - Update");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<Docket> GetDocketListForCancellation(
          string docketNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetDocketListForCancellation", (object)dynamicParameters, "Docket - GetDocketListForCancellation");
        }

        public Response Cancellation(DocketCancellation objDocketCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocketCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_Cancellation", (object)dynamicParameters, "Docket - Cancellation").FirstOrDefault<Response>();
        }

        public Response IsDocketValidForCancellation(long docketId, string docketNomenClature)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNomenClature", (object)docketNomenClature, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_IsDocketValidForCancellation", (object)dynamicParameters, "Docket - IsDocketValidForCancellation").FirstOrDefault<Response>();
        }

        public AutoCompleteResult IsDocketNoExistByLocation(
          string docketNo,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_IsDocketNoExistByLocation", (object)dynamicParameters, "Docket - IsDocketNoExistByLocation").FirstOrDefault<AutoCompleteResult>();
        }
        public AutoCompleteResult IsDocketNoExistByBillingParty(
          string docketNo,
          short billingPartyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillingPartyId", (object)billingPartyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_IsDocketNoExistByBillingParty", (object)dynamicParameters, "Docket - IsDocketNoExistByBillingParty").FirstOrDefault<AutoCompleteResult>();
        }
        public Docket GetDetailById(long id, byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Docket docket1 = DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetDetailById", (object)dynamicParameters, "Docket - GetDetailById").FirstOrDefault<Docket>();
            Docket docket2 = new Docket();
            if (docket2 != null)
            {
                docket2 = docket1;
                docket2.IsGst = docket2.DocketDate >= ConfigHelper.GstDate;
            }
            return docket2;
        }

        public IEnumerable<DocketDocument> GetDocumentDetails(
          long id,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketDocument>("Usp_Docket_GetDocumentDetails", (object)dynamicParameters, "Docket - GetDocumentDetails");
        }
        public IEnumerable<DocketGPRO_Details> GetGPRODetails(
          long id,
          byte CompanyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketGPRO_Details>("Usp_Docket_GetGPRODetails", (object)dynamicParameters, "Docket - GetDocumentDetails");
        }

        public IEnumerable<DocketInvoice> GetInvoiceDetails(
      long id,
      byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<DocketInvoice>, IEnumerable<InvoicePart>> tuple = DataBaseFactory.QueryMultipleSP<DocketInvoice, InvoicePart>("Usp_Docket_GetInvoiceDetails", (object)dynamicParameters, "Docket - GetInvoiceDetails");
            List<DocketInvoice> docketInvoiceList = new List<DocketInvoice>();
            if (tuple != null)
            {
                foreach (DocketInvoice docketInvoice in tuple.Item1)
                {
                    foreach (InvoicePart invoicePart in tuple.Item2)
                    {
                        if (invoicePart.InvoiceId == docketInvoice.InvoiceId)
                            docketInvoice.PartList.Add(invoicePart);
                    }
                    docketInvoiceList.Add(docketInvoice);
                }
            }
            return (IEnumerable<DocketInvoice>)docketInvoiceList;
        }

        public IEnumerable<MasterCharge> GetChargeDetails(
          long id,
          byte businessTypeId,
          byte serviceTypeId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)businessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCharge>("Usp_Docket_GetChargeDetails", (object)dynamicParameters, "Docket - GetChargeDetails");
        }

        public IEnumerable<MasterTax> GetTaxDetails(long id, byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterTax>("Usp_Docket_GetTaxDetails", (object)dynamicParameters, "Docket - GetTaxDetails");
        }

        public MasterCustomer GetCustomerDetailByGstTinNo(
          short locationId,
          byte paybasId,
          string gstTinNo,
          bool allowWalkIn)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstTinNo", (object)gstTinNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AllowWalkIn", (object)allowWalkIn, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterCustomer>("Usp_Docket_GetCustomerDetailByGstTinNo", (object)dynamicParameters, "Docket - GetCustomerDetailByGstTinNo").FirstOrDefault<MasterCustomer>();
        }

        public IEnumerable<AutoCompleteResult> GetDocketSuffixList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_GetDocketSuffixList", (object)null, "Docket - GetDocketSuffixList");
        }

        public Response DocketBookingChallanInsert(DocketBookingChallan objDocketBookingChallan)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketBookingChallan", (object)XmlUtility.XmlSerializeToString((object)objDocketBookingChallan), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocketBookingChallanInsert", (object)dynamicParameters, "Docket Booking Challan - Insert").FirstOrDefault<Response>();
        }

        public AutoCompleteResult CheckValidDocketNo(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_CheckValidDocketNo", (object)dynamicParameters, "Docket - CheckValidDocketNo").FirstOrDefault<AutoCompleteResult>();
        }

        public DocketDetailForSolex CheckValidDocketNoForSolex(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketDetailForSolex>("Usp_Docket_CheckValidDocketNoForSolex", (object)dynamicParameters, "Docket - CheckValidDocketNo").FirstOrDefault<DocketDetailForSolex>();
        }

        public Response DocketTalkInsert(DocketTalk objDocketTalk)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@xmlTalk", (object)XmlUtility.XmlSerializeToString((object)objDocketTalk), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocketTalk_Insert", (object)dynamicParameters, "DocketTalk - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<DocketTalk> GetDocketTalkData(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)null, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)null, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)null, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)null, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketTalk>("Usp_Docket_GetDocketTalkData", (object)dynamicParameters, "Docket - GetDocketTalkData");
        }

        public IEnumerable<DocketHold> GetDocketHoldAll()
        {
            return DataBaseFactory.QuerySP<DocketHold>("Usp_Docket_GetDocketHoldAll", (object)null, "DocketHold - GetDocketHoldAll");
        }

        public AutoCompleteResult CheckValidDocketForHold(short docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Docket_CheckValidDocketForHold", (object)dynamicParameters, "Docket - CheckValidDocketForHold").FirstOrDefault<AutoCompleteResult>();
        }

        public Response DocketHold(DocketHold objDocketHold)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketHold", (object)XmlUtility.XmlSerializeToString((object)objDocketHold), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocketHold_Insert", (object)dynamicParameters, "DocketHold - Insert").FirstOrDefault<Response>();
        }

        public DocketHold GetDocketHoldData(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketHold>("Usp_Docket_GetDocketHoldData", (object)dynamicParameters, "Docket - GetDocketHoldData").FirstOrDefault<DocketHold>();
        }

        public Response DocketUnhold(DocketHold objDocketHold)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketUnhold", (object)XmlUtility.XmlSerializeToString((object)objDocketHold), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocketUnhold_Insert", (object)dynamicParameters, "DocketUnhold - Insert").FirstOrDefault<Response>();
        }

        public DocketHold GetDocketUnHoldData(long holdId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@HoldId", (object)holdId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketHold>("Usp_Docket_GetDocketUnHoldData", (object)dynamicParameters, "DocketUnhold - GetDocketUnHoldData").FirstOrDefault<DocketHold>();
        }
        public DocketReAssign CheckValidDocketNoForReAssign(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketReAssign>("Usp_Docket_GetDocketReAssign", (object)dynamicParameters, "Docket- GetDocketData").FirstOrDefault<DocketReAssign>();
        }
        public long CheckValidDocketNoForDacc(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_CheckValidDocketNoForDacc", (object)dynamicParameters, "Docket Master - Update");
            return dynamicParameters.Get<long>("@DocketId");
        }

        public Response DocketDaccInsert(DocketDacc objDocketDacc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@xmlDacc", (object)XmlUtility.XmlSerializeToString((object)objDocketDacc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_Dacc_Insert", (object)dynamicParameters, "DocketDaccInsert - Insert").FirstOrDefault<Response>();
        }

        public DocketUpload Upload(DocketUpload objDocketUpload)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));
            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"ContractParty";
            row3["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"Paybas";
            row4["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"Origin";
            row5["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row5);
            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"Destination";
            row6["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"TransportMode";
            row7["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"ServiceType";
            row8["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"FTLType";
            row9["FieldCaption"] = (object)"FTL Type";
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"InvoiceAmount";
            row10["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"Packages";
            row11["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ActualWeight";
            row12["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"ChargedWeight";
            row13["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row13);
            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUpload.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUpload";
            docketUploadHelper1.strModuleName = "DocketUpload";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(true);
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUpload.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - Upload").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUpload.IsSuccessfull = true;
                objDocketUpload.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUpload.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUpload.IsSuccessfull = false;
                objDocketUpload.ErrorMessage = ex.Message;
            }
            return objDocketUpload;
        }

        public DocketUploadInSystem UploadInSystem(
          DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"EntryDate";
            row3["FieldCaption"] = (object)"Entry Date";
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"ADD";
            row4["FieldCaption"] = (object)"ADD";
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"EDD";
            row5["FieldCaption"] = (object)"EDD";
            dataTable.Rows.Add(row5);
            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"ArrivalDate";
            row6["FieldCaption"] = (object)"Arrival Date";
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Origin";
            row7["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Destination";
            row8["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"CurrentLocation";
            row9["FieldCaption"] = (object)"Current Location";
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"NextLocation";
            row10["FieldCaption"] = (object)"Next Location";
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"FromCity";
            row11["FieldCaption"] = (object)"From City";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ToCity";
            row12["FieldCaption"] = (object)"To City";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"Paybas";
            row13["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"TransportMode";
            row14["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ServiceType";
            row15["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row15);
            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"LoadType";
            row16["FieldCaption"] = (object)"Load Type";
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"BusinessType";
            row17["FieldCaption"] = (object)"Business Type";
            dataTable.Rows.Add(row17);
            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ProductType";
            row18["FieldCaption"] = (object)"Product Type";
            dataTable.Rows.Add(row18);
            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"RiskType";
            row19["FieldCaption"] = (object)"Risk Type";
            dataTable.Rows.Add(row19);
            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"ConsignorCode";
            row20["FieldCaption"] = (object)"Consignor Code";
            dataTable.Rows.Add(row20);
            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"ConsignorName";
            row21["FieldCaption"] = (object)"Consignor Name";
            dataTable.Rows.Add(row21);
            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"ConsigneeCode";
            row22["FieldCaption"] = (object)"Consignee Code";
            dataTable.Rows.Add(row22);
            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ConsigneeName";
            row23["FieldCaption"] = (object)"Consignee Name";
            dataTable.Rows.Add(row23);
            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ContractParty";
            row24["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row24);
            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"ContractPartyName";
            row25["FieldCaption"] = (object)"Contract Party Name";
            dataTable.Rows.Add(row25);

            //DataRow row26 = dataTable.NewRow();
            //row26["FieldName"] = (object)"BACode";
            //row26["FieldCaption"] = (object)"BA Code";
            //dataTable.Rows.Add(row26);
            //DataRow row27 = dataTable.NewRow();
            //row27["FieldName"] = (object)"BAName";
            //row27["FieldCaption"] = (object)"BA Name";
            //dataTable.Rows.Add(row27);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Packages";
            row28["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row28);
            DataRow row29 = dataTable.NewRow();
            row29["FieldName"] = (object)"ActualWeight";
            row29["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row29);
            DataRow row30 = dataTable.NewRow();
            row30["FieldName"] = (object)"ChargedWeight";
            row30["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row30);
            DataRow row31 = dataTable.NewRow();
            row31["FieldName"] = (object)"FreightRate";
            row31["FieldCaption"] = (object)"Freight Rate";
            dataTable.Rows.Add(row31);
            DataRow row32 = dataTable.NewRow();
            row32["FieldName"] = (object)"RateType";
            row32["FieldCaption"] = (object)"Rate Type";
            dataTable.Rows.Add(row32);
            DataRow row33 = dataTable.NewRow();
            row33["FieldName"] = (object)"Freight";
            row33["FieldCaption"] = (object)"Freight";
            dataTable.Rows.Add(row33);
            DataRow row49 = dataTable.NewRow();
            row49["FieldName"] = (object)"InvoiceNo";
            row49["FieldCaption"] = (object)"Invoice No";
            dataTable.Rows.Add(row49);
            DataRow row50 = dataTable.NewRow();
            row50["FieldName"] = (object)"InvoiceDate";
            row50["FieldCaption"] = (object)"Invoice Date";
            dataTable.Rows.Add(row50);
            DataRow row51 = dataTable.NewRow();
            row51["FieldName"] = (object)"InvoiceAmount";
            row51["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row51);
            DataRow row52 = dataTable.NewRow();
            row52["FieldName"] = (object)"Remarks";
            row52["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row52);
            DataRow row53 = dataTable.NewRow();
            row53["FieldName"] = (object)"IsAvailableForDRS";
            row53["FieldCaption"] = (object)"Is Available For DRS";
            dataTable.Rows.Add(row53);
            DataRow row54 = dataTable.NewRow();
            row54["FieldName"] = (object)"IsDelivered";
            row54["FieldCaption"] = (object)"Is Delivered";
            dataTable.Rows.Add(row54);

            //DataRow row61 = dataTable.NewRow();
            //row61["FieldName"] = (object)"PONO";
            //row61["FieldCaption"] = (object)"PO NO";
            //dataTable.Rows.Add(row61);

            DataRow row62 = dataTable.NewRow();
            row62["FieldName"] = (object)"PackagingType";
            row62["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row62);

            DataRow row63 = dataTable.NewRow();
            row63["FieldName"] = (object)"PickupDelivery";
            row63["FieldCaption"] = (object)"Pickup Delivery";
            dataTable.Rows.Add(row63);

            DataRow row64 = dataTable.NewRow();
            row64["FieldName"] = (object)"CompanyGSTState";
            row64["FieldCaption"] = (object)"Company GST State";
            dataTable.Rows.Add(row64);

            DataRow row65 = dataTable.NewRow();
            row65["FieldName"] = (object)"CustomerGSTState";
            row65["FieldCaption"] = (object)"Customer GST State";
            dataTable.Rows.Add(row65);

            DataRow row66 = dataTable.NewRow();
            row66["FieldName"] = (object)"GSTPayer";
            row66["FieldCaption"] = (object)"GST Payer";
            dataTable.Rows.Add(row66);

            DataRow row67 = dataTable.NewRow();
            row67["FieldName"] = (object)"DocketCharge";
            row67["FieldCaption"] = (object)"Docket Charge";
            dataTable.Rows.Add(row67);

            DataRow row68 = dataTable.NewRow();
            row68["FieldName"] = (object)"Hamali";
            row68["FieldCaption"] = (object)"Hamali";
            dataTable.Rows.Add(row68);

            DataRow row69 = dataTable.NewRow();
            row69["FieldName"] = (object)"Cartage";
            row69["FieldCaption"] = (object)"Cartage";
            dataTable.Rows.Add(row69);

            DataRow row70 = dataTable.NewRow();
            row70["FieldName"] = (object)"GreenTax";
            row70["FieldCaption"] = (object)"Green Tax";
            dataTable.Rows.Add(row70);

            DataRow row71 = dataTable.NewRow();
            row71["FieldName"] = (object)"PreviousFreight";
            row71["FieldCaption"] = (object)"Previous Freight";
            dataTable.Rows.Add(row71);

            DataRow row72 = dataTable.NewRow();
            row72["FieldName"] = (object)"HandlingCharge";
            row72["FieldCaption"] = (object)"Handling Charge";
            dataTable.Rows.Add(row72);

            DataRow row73 = dataTable.NewRow();
            row73["FieldName"] = (object)"OtherCharge";
            row73["FieldCaption"] = (object)"Other Charge";
            dataTable.Rows.Add(row73);

            DataRow row74 = dataTable.NewRow();
            row74["FieldName"] = (object)"COD";
            row74["FieldCaption"] = (object)"COD";
            dataTable.Rows.Add(row74);

            DataRow row75 = dataTable.NewRow();
            row75["FieldName"] = (object)"DoorDelivery";
            row75["FieldCaption"] = (object)"Door Delivery";
            dataTable.Rows.Add(row75);

            DataRow row76 = dataTable.NewRow();
            row76["FieldName"] = (object)"Insurance";
            row76["FieldCaption"] = (object)"Insurance";
            dataTable.Rows.Add(row76);

            DataRow row77 = dataTable.NewRow();
            row77["FieldName"] = (object)"SubTotal";
            row77["FieldCaption"] = (object)"Sub Total";
            dataTable.Rows.Add(row77);


            DataRow row81 = dataTable.NewRow();
            row81["FieldName"] = (object)"IGST";
            row81["FieldCaption"] = (object)"IGST";
            dataTable.Rows.Add(row81);

            DataRow row82 = dataTable.NewRow();
            row82["FieldName"] = (object)"CGST";
            row82["FieldCaption"] = (object)"CGST";
            dataTable.Rows.Add(row82);

            DataRow row83 = dataTable.NewRow();
            row83["FieldName"] = (object)"SGST";
            row83["FieldCaption"] = (object)"SGST";
            dataTable.Rows.Add(row83);

            DataRow row84 = dataTable.NewRow();
            row84["FieldName"] = (object)"GSTAmount";
            row84["FieldCaption"] = (object)"GST Amount";
            dataTable.Rows.Add(row84);

            DataRow row78 = dataTable.NewRow();
            row78["FieldName"] = (object)"DocketTotal";
            row78["FieldCaption"] = (object)"Docket Total";
            dataTable.Rows.Add(row78);

            DataRow row79 = dataTable.NewRow();
            row79["FieldName"] = (object)"IsAvailableForDeliveryMR";
            row79["FieldCaption"] = (object)"Is Available For Delivery MR";
            dataTable.Rows.Add(row79);

            DataRow row80 = dataTable.NewRow();
            row80["FieldName"] = (object)"OwnershipLocation";
            row80["FieldCaption"] = (object)"Ownership Location";
            dataTable.Rows.Add(row80);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }

        public Response InsertDocketChangeStatus(DocketReAssign objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)objDocket.DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketStatusId", (object)objDocket.DocketStatusId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Remarks", (object)objDocket.Remarks, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objDocket.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_ChangeStatus", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }
        public DocketReAssign CheckValidDocketNoForChangeStatus(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@docketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketReAssign>("Usp_Docket_GetDocketChangeStatus", (object)dynamicParameters, "Docket- GetDocketData").FirstOrDefault<DocketReAssign>();
        }

        public DocketUploadInSystem UploadInSystemRemarks(DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"DocketNo";
            dataTable.Rows.Add(row1);

            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"Remarks";
            row2["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row2);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_DocketRemarks_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }


        public DocketUploadInSystem UploadInSystemTrispeed(
         DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"DocketDate";
            dataTable.Rows.Add(row2);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Origin";
            row7["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Destination";
            row8["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row8);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"FromCity";
            row11["FieldCaption"] = (object)"FromCity";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ToCity";
            row12["FieldCaption"] = (object)"ToCity";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"Paybas";
            row13["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"TransportMode";
            row14["FieldCaption"] = (object)"TransportMode";
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ServiceType";
            row15["FieldCaption"] = (object)"ServiceType";
            dataTable.Rows.Add(row15);

            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ProductType";
            row18["FieldCaption"] = (object)"ProductType";
            dataTable.Rows.Add(row18);
            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"BusinessType";
            row16["FieldCaption"] = (object)"BusinessType";
            dataTable.Rows.Add(row16);

            DataRow row62 = dataTable.NewRow();
            row62["FieldName"] = (object)"PackagingType";
            row62["FieldCaption"] = (object)"PackagingType";
            dataTable.Rows.Add(row62);

            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"ConsignorCode";
            row20["FieldCaption"] = (object)"ConsignorCode";
            dataTable.Rows.Add(row20);
            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"ConsignorName";
            row21["FieldCaption"] = (object)"ConsignorName";
            dataTable.Rows.Add(row21);
            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"ConsigneeCode";
            row22["FieldCaption"] = (object)"ConsigneeCode";
            dataTable.Rows.Add(row22);
            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ConsigneeName";
            row23["FieldCaption"] = (object)"ConsigneeName";
            dataTable.Rows.Add(row23);
            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ContractParty";
            row24["FieldCaption"] = (object)"ContractParty";
            dataTable.Rows.Add(row24);
            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"ContractPartyName";
            row25["FieldCaption"] = (object)"ContractPartyName";
            dataTable.Rows.Add(row25);
            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Packages";
            row28["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row28);

            DataRow row49 = dataTable.NewRow();
            row49["FieldName"] = (object)"InvoiceNo";
            row49["FieldCaption"] = (object)"InvoiceNo";
            dataTable.Rows.Add(row49);
            DataRow row50 = dataTable.NewRow();
            row50["FieldName"] = (object)"InvoiceDate";
            row50["FieldCaption"] = (object)"InvoiceDate";
            dataTable.Rows.Add(row50);

            DataRow row51 = dataTable.NewRow();
            row51["FieldName"] = (object)"InvoiceAmount";
            row51["FieldCaption"] = (object)"InvoiceAmount";
            dataTable.Rows.Add(row51);

            DataRow row;

            row = dataTable.NewRow();
            row["FieldName"] = (object)"EWayBillNo";
            row["FieldCaption"] = (object)"EWayBillNo";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"EWayBillDate";
            row["FieldCaption"] = (object)"EWayBillDate";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"EWayBillExpireyDate";
            row["FieldCaption"] = (object)"EWayBillExpireyDate";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"RONo";
            row["FieldCaption"] = (object)"RONo";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"GPNo";
            row["FieldCaption"] = (object)"GPNo";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"L";
            row["FieldCaption"] = (object)"L";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row["FieldName"] = (object)"B";
            row["FieldCaption"] = (object)"B";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"H";
            row["FieldCaption"] = (object)"H";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"CFTWt";
            row["FieldCaption"] = (object)"CFTWt";
            dataTable.Rows.Add(row);

            DataRow row29 = dataTable.NewRow();
            row29["FieldName"] = (object)"ActualWeight";
            row29["FieldCaption"] = (object)"ActualWeight";
            dataTable.Rows.Add(row29);
            DataRow row30 = dataTable.NewRow();
            row30["FieldName"] = (object)"ChargedWeight";
            row30["FieldCaption"] = (object)"ChargedWeight";
            dataTable.Rows.Add(row30);

            DataRow row52 = dataTable.NewRow();
            row52["FieldName"] = (object)"Remarks";
            row52["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row52);

            DataRow row64 = dataTable.NewRow();
            row64["FieldName"] = (object)"CompanyGSTState";
            row64["FieldCaption"] = (object)"CompanyGSTState";
            dataTable.Rows.Add(row64);

            DataRow row65 = dataTable.NewRow();
            row65["FieldName"] = (object)"CustomerGSTState";
            row65["FieldCaption"] = (object)"CustomerGSTState";
            dataTable.Rows.Add(row65);



            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }

        public IEnumerable<AutoCompleteResult> TripsheetList(string EntryBy)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EntryBy", (object)EntryBy, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_GetList", (object)dynamicParameters, "Status List");
        }

        public FastTagUploadInSystem FastTagUploadInSystem(FastTagUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row;

            row = dataTable.NewRow();
            row["FieldName"] = (object)"TransactionId";
            row["FieldCaption"] = (object)"TransactionId";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"DateTime";
            row["FieldCaption"] = (object)"DateTime";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"Plaza";
            row["FieldCaption"] = (object)"Plaza";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"VehicleNo";
            row["FieldCaption"] = (object)"VehicleNo";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"VehicleClass";
            row["FieldCaption"] = (object)"VehicleClass";
            dataTable.Rows.Add(row);
            row = dataTable.NewRow();
            row["FieldName"] = (object)"LaneDirection";
            row["FieldCaption"] = (object)"LaneDirection";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["FieldName"] = (object)"Fare";
            row["FieldCaption"] = (object)"Fare";
            dataTable.Rows.Add(row);

            FastTagUploadHelper docketUploadHelper1 = new FastTagUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "FastTagUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/FastTagUploadInSystem";
            docketUploadHelper1.strModuleName = "FastTagUploadInSystem";
            docketUploadHelper1.strProcedureName = "USP_FastTag_TransactionUpload";
            FastTagUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@TripsheetId", (object)objDocketUploadInSystem.TripsheetId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<FastTag>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<FastTag>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<FastTag>((Func<FastTag, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }


        public DocketUploadInSystem UploadInSystemBarcodeLBH(
         DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow rows;

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"DocketNo";
            rows["FieldCaption"] = (object)"DocketNo";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"BarCode";
            rows["FieldCaption"] = (object)"BarCode";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"Length";
            rows["FieldCaption"] = (object)"Length";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"Breadth";
            rows["FieldCaption"] = (object)"Breadth";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"Height";
            rows["FieldCaption"] = (object)"Height";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ActualWeight";
            rows["FieldCaption"] = (object)"ActualWeight";
            dataTable.Rows.Add(rows);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_UploadBarcode_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }


        public DocketUploadInSystem UploadInSystemByContract(
           DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"DocketNo";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"DocketDate";
            dataTable.Rows.Add(row2);

            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Origin";
            row7["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Destination";
            row8["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row8);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"FromCity";
            row11["FieldCaption"] = (object)"FromCity";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ToCity";
            row12["FieldCaption"] = (object)"ToCity";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"Paybas";
            row13["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"TransportMode";
            row14["FieldCaption"] = (object)"TransportMode";
            dataTable.Rows.Add(row14);

            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ServiceType";
            row15["FieldCaption"] = (object)"ServiceType";
            dataTable.Rows.Add(row15);
            //DataRow row16 = dataTable.NewRow();
            //row16["FieldName"] = (object)"LoadType";
            //row16["FieldCaption"] = (object)"Load Type";
            //dataTable.Rows.Add(row16);
            //DataRow row17 = dataTable.NewRow();
            //row17["FieldName"] = (object)"BusinessType";
            //row17["FieldCaption"] = (object)"Business Type";
            //dataTable.Rows.Add(row17);
            //DataRow row18 = dataTable.NewRow();
            //row18["FieldName"] = (object)"ProductType";
            //row18["FieldCaption"] = (object)"Product Type";
            //dataTable.Rows.Add(row18);
            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"FTLType";
            row19["FieldCaption"] = (object)"FTLType";
            dataTable.Rows.Add(row19);

            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"ConsignorCode";
            row20["FieldCaption"] = (object)"ConsignorCode";
            dataTable.Rows.Add(row20);
            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"ConsigneeCode";
            row22["FieldCaption"] = (object)"ConsigneeCode";
            dataTable.Rows.Add(row22);
            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ConsigneeName";
            row23["FieldCaption"] = (object)"ConsigneeName";
            dataTable.Rows.Add(row23);
            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ContractParty";
            row24["FieldCaption"] = (object)"ContractParty";
            dataTable.Rows.Add(row24);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Packages";
            row28["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row28);
            DataRow row29 = dataTable.NewRow();
            row29["FieldName"] = (object)"ActualWeight";
            row29["FieldCaption"] = (object)"ActualWeight";
            dataTable.Rows.Add(row29);
            DataRow row30 = dataTable.NewRow();
            row30["FieldName"] = (object)"ChargedWeight";
            row30["FieldCaption"] = (object)"ChargedWeight";
            dataTable.Rows.Add(row30);

            DataRow row49 = dataTable.NewRow();
            row49["FieldName"] = (object)"InvoiceNo";
            row49["FieldCaption"] = (object)"InvoiceNo";
            dataTable.Rows.Add(row49);
            DataRow row50 = dataTable.NewRow();
            row50["FieldName"] = (object)"InvoiceDate";
            row50["FieldCaption"] = (object)"InvoiceDate";
            dataTable.Rows.Add(row50);
            DataRow row51 = dataTable.NewRow();
            row51["FieldName"] = (object)"InvoiceAmount";
            row51["FieldCaption"] = (object)"InvoiceAmount";
            dataTable.Rows.Add(row51);
            DataRow row52 = dataTable.NewRow();
            row52["FieldName"] = (object)"Remarks";
            row52["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row52);

            DataRow row63 = dataTable.NewRow();
            row63["FieldName"] = (object)"PickupDelivery";
            row63["FieldCaption"] = (object)"PickupDelivery";
            dataTable.Rows.Add(row63);

            DataRow row64 = dataTable.NewRow();
            row64["FieldName"] = (object)"CompanyGSTState";
            row64["FieldCaption"] = (object)"CompanyGSTState";
            dataTable.Rows.Add(row64);

            DataRow row65 = dataTable.NewRow();
            row65["FieldName"] = (object)"CustomerGSTState";
            row65["FieldCaption"] = (object)"CustomerGSTState";
            dataTable.Rows.Add(row65);

            DataRow row66 = dataTable.NewRow();
            row66["FieldName"] = (object)"GSTPayer";
            row66["FieldCaption"] = (object)"GSTPayer";
            dataTable.Rows.Add(row66);

            DataRow rows;

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ApplyRateType";
            rows["FieldCaption"] = (object)"ApplyRateType";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"PaymentType";
            rows["FieldCaption"] = (object)"PaymentType";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"CODCollectableAmount";
            rows["FieldCaption"] = (object)"CODCollectableAmount";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"EWayBillNo";
            rows["FieldCaption"] = (object)"EWayBillNo";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"EWayBillDate";
            rows["FieldCaption"] = (object)"EWayBillDate";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"EWayBillExpireyDate";
            rows["FieldCaption"] = (object)"EWayBillExpireyDate";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ClientOrderID";
            rows["FieldCaption"] = (object)"ClientOrderID";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ISDGProduct";
            rows["FieldCaption"] = (object)"ISDGProduct";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"BookingType";
            rows["FieldCaption"] = (object)"BookingType";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ConsigneeMobileNo";
            rows["FieldCaption"] = (object)"ConsigneeMobileNo";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ConsigneeMobileNo2";
            rows["FieldCaption"] = (object)"ConsigneeMobileNo2";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"ConsigneeAddress";
            rows["FieldCaption"] = (object)"ConsigneeAddress";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"VendorCode";
            rows["FieldCaption"] = (object)"VendorCode";
            dataTable.Rows.Add(rows);

            rows = dataTable.NewRow();
            rows["FieldName"] = (object)"WaybillNo";
            rows["FieldCaption"] = (object)"WaybillNo";
            dataTable.Rows.Add(rows);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }

        public DocketStep6 GetStep6DetailSimply(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objDocket.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)objDocket.FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)objDocket.ToLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromCityId", (object)objDocket.FromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)objDocket.ToCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)objDocket.FtlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)objDocket.BusinessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)objDocket.ServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ProductTypeId", (object)objDocket.ProductTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PackagingTypeId", (object)objDocket.PackagingTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)objDocket.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)objDocket.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Packages", (object)objDocket.Packages, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ActualWeight", (object)objDocket.ActualWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChargedWeight", (object)objDocket.ChargedWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceAmount", (object)objDocket.InvoiceAmount, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CODCollectableAmount", (object)objDocket.CODCollectableAmount, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsOda", (object)objDocket.IsOda, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCod", (object)objDocket.IsCod, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDacc", (object)objDocket.IsDacc, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsLocal", (object)objDocket.IsLocal, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCarrierRisk", (object)objDocket.IsCarrierRisk, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDoorDelivery", (object)objDocket.IsDoorDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)objDocket.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsMultiPickup", (object)objDocket.IsMultiPickup, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsMultiDelivery", (object)objDocket.IsMultiDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ApplyRateType", (object)objDocket.ApplyRateType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractSlabId", (object)objDocket.ContractSlabId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@handlingChargedWeight", (object)objDocket.handlingChargedWeight, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<ContractKeys>, IEnumerable<AutoCompleteResult>, IEnumerable<AutoCompleteResult>, IEnumerable<MasterCharge>, IEnumerable<MasterTax>, IEnumerable<MinimumFreightDetails>> tuple = DataBaseFactory.QueryMultipleSP<ContractKeys, AutoCompleteResult, AutoCompleteResult, MasterCharge, MasterTax, MinimumFreightDetails>("Usp_Docket_GetStep6Detail", (object)dynamicParameters, "Docket - GetStep6Detail");
            DocketStep6 docketStep6 = new DocketStep6();
            docketStep6.IsGst = objDocket.DocketDate >= ConfigHelper.GstDate;
            docketStep6.Keys = tuple.Item1.FirstOrDefault<ContractKeys>();
            if (docketStep6.Keys.IsSuccessfull)
            {
                docketStep6.RateTypeList = tuple.Item2;
                docketStep6.ServiceTaxPayerList = tuple.Item3;
                docketStep6.OtherChargeList = tuple.Item4;
                docketStep6.TaxList = tuple.Item5;
                if (tuple.Item6 != null)
                    docketStep6.MinimumFreightDetails = tuple.Item6.FirstOrDefault<MinimumFreightDetails>();
                else
                    docketStep6.MinimumFreightDetails = new MinimumFreightDetails()
                    {
                        MinimumFreightRate = new Decimal(0),
                        MinimumFreightRateType = "",
                        MinimumFreightAmount = new Decimal(0),
                        MinimumFreightLowerLimit = new Decimal(0),
                        MinimumFreightUpperLimit = new Decimal(0),
                        MinimumSubTotalAmount = new Decimal(0),
                        SubTotalLowerLimit = new Decimal(0),
                        SubTotalUpperLimit = new Decimal(0),
                        UseMinimumFreightTypeBaseWise = false,
                        UseFreightRateLimit = false,
                        UseSubTotalLimit = false
                    };
            }
            return docketStep6;
        }


        public DocketStep5 GetStep5DetailSimply(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objDocket.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objDocket.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceNo", (object)objDocket.WmsInvoiceNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)objDocket.ServiceTypeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<DocketStep5>, IEnumerable<DocketInvoice>, IEnumerable<MasterPackagingMeasurement>, IEnumerable<AutoCompleteResult>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep5, DocketInvoice, MasterPackagingMeasurement, AutoCompleteResult>("Usp_Docket_GetStep5Detail", (object)dynamicParameters, "Docket - GetStep5Detail");
            DocketStep5 docketStep5_1 = new DocketStep5();
            DocketStep5 docketStep5_2 = tuple.Item1.FirstOrDefault<DocketStep5>();
            docketStep5_2.InvoiceList = tuple.Item2;
            docketStep5_2.TypeOfPackageList = tuple.Item3;
            docketStep5_2.ContractSlabList = tuple.Item4;
            return docketStep5_2;
        }

        public Response InsertDocketOtherCharges(DocketOtherCharges objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocketOtherCharges_Insert", (object)dynamicParameters, "Docket Other Charges Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<DocketOtherCharges> GetListForOtherCharges(
          string ChargeTypeId,
          string LocationId,
          DateTime fromDate,
          DateTime toDate
         )
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ChargeTypeId", (object)ChargeTypeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<DocketOtherCharges>)DataBaseFactory.QuerySP<DocketOtherCharges>("Usp_Docket_OtherCharges_GetAll", (object)dynamicParameters, "Docket Other Charges").ToList<DocketOtherCharges>();
        }
        public Response InsertDocketBarcode(DocketBarcode objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_Docket_Invoice_BarCode_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<DocketBarcode> GetBarcodeList(
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketBarcode>("Usp_BarCode_GetAll", (object)dynamicParameters, "Docket - GetDocumentDetails");
        }
        public IEnumerable<BarCodeModel> GetBarCode(int barcodeIndex, string fk_companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@barcodeIndex", (object)barcodeIndex, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@fk_companyId", (object)fk_companyId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<BarCodeModel>("CL_BarCode_Ins", (object)dynamicParameters, "CL_BarCode");
        }
        public Response CreatePktBarCode(long DocketId, string DocumentType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentId", (object)DocketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentType", (object)DocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_BarCode_Ins", (object)dynamicParameters, "CL_BarCode").FirstOrDefault<Response>();
        }

        //

        public DocketBarcode CheckValidDocketNoForScanIn(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketBarcode>("Usp_Docket_CheckValidDocketNoForScanIn", (object)dynamicParameters, "Docket -").FirstOrDefault<DocketBarcode>();
        }

        public Response InsertPickupRequest(PickupRequest objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_Pickup_Header_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public PickupRequest PickupRequestById(long PickupRequestId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PickupRequestId", (object)PickupRequestId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<PickupRequest>("CL_Pickup_HeaderlById", (object)dynamicParameters, "Docket Master - GetStep1DetailById").FirstOrDefault<PickupRequest>();
        }

        public IEnumerable<PickupRequest> PickupRequestGetAll(short LoginUserId, string flag)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LoginUserId", (object)LoginUserId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@flag", (object)flag, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<PickupRequest>("CL_Pickup_Headerl_GetAll", (object)dynamicParameters, "PickupRequest - GetAll");
        }


        public DocketUploadInSystem UploadInSystemKExpress(
          DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"EntryDate";
            row3["FieldCaption"] = (object)"Entry Date";
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"ADD";
            row4["FieldCaption"] = (object)"ADD";
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"EDD";
            row5["FieldCaption"] = (object)"EDD";
            dataTable.Rows.Add(row5);
            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"ArrivalDate";
            row6["FieldCaption"] = (object)"Arrival Date";
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Origin";
            row7["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Destination";
            row8["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"CurrentLocation";
            row9["FieldCaption"] = (object)"Current Location";
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"NextLocation";
            row10["FieldCaption"] = (object)"Next Location";
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"FromCity";
            row11["FieldCaption"] = (object)"From City";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ToCity";
            row12["FieldCaption"] = (object)"To City";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"Paybas";
            row13["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"TransportMode";
            row14["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ServiceType";
            row15["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row15);
            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"LoadType";
            row16["FieldCaption"] = (object)"Load Type";
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"BusinessType";
            row17["FieldCaption"] = (object)"Business Type";
            dataTable.Rows.Add(row17);

            DataRow row62 = dataTable.NewRow();
            row62["FieldName"] = (object)"PackagingType";
            row62["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row62);

            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ProductType";
            row18["FieldCaption"] = (object)"Product Type";
            dataTable.Rows.Add(row18);

            DataRow row63 = dataTable.NewRow();
            row63["FieldName"] = (object)"PickupDelivery";
            row63["FieldCaption"] = (object)"Pickup Delivery";
            dataTable.Rows.Add(row63);

            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"RiskType";
            row19["FieldCaption"] = (object)"Risk Type";
            dataTable.Rows.Add(row19);

            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"ConsignorCode";
            row20["FieldCaption"] = (object)"Consignor Code";
            dataTable.Rows.Add(row20);
            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"ConsignorName";
            row21["FieldCaption"] = (object)"Consignor Name";
            dataTable.Rows.Add(row21);
            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"ConsigneeCode";
            row22["FieldCaption"] = (object)"Consignee Code";
            dataTable.Rows.Add(row22);
            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ConsigneeName";
            row23["FieldCaption"] = (object)"Consignee Name";
            dataTable.Rows.Add(row23);
            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ContractParty";
            row24["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row24);
            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"ContractPartyName";
            row25["FieldCaption"] = (object)"Contract Party Name";
            dataTable.Rows.Add(row25);

            DataRow row64 = dataTable.NewRow();
            row64["FieldName"] = (object)"CompanyGSTState";
            row64["FieldCaption"] = (object)"Company GST State";
            dataTable.Rows.Add(row64);

            DataRow row65 = dataTable.NewRow();
            row65["FieldName"] = (object)"CustomerGSTState";
            row65["FieldCaption"] = (object)"Customer GST State";
            dataTable.Rows.Add(row65);

            DataRow row90 = dataTable.NewRow();
            row90["FieldName"] = (object)"WalkingCustomerGSTNo";
            row90["FieldCaption"] = (object)"Walking Customer GST No";
            dataTable.Rows.Add(row90);

            DataRow row66 = dataTable.NewRow();
            row66["FieldName"] = (object)"GSTPayer";
            row66["FieldCaption"] = (object)"GST Payer";
            dataTable.Rows.Add(row66);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Packages";
            row28["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row28);
            DataRow row29 = dataTable.NewRow();
            row29["FieldName"] = (object)"ActualWeight";
            row29["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row29);
            DataRow row30 = dataTable.NewRow();
            row30["FieldName"] = (object)"ChargedWeight";
            row30["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row30);

            DataRow row31 = dataTable.NewRow();
            row31["FieldName"] = (object)"FreightRate";
            row31["FieldCaption"] = (object)"Freight Rate";
            dataTable.Rows.Add(row31);
            DataRow row32 = dataTable.NewRow();
            row32["FieldName"] = (object)"RateType";
            row32["FieldCaption"] = (object)"Rate Type";
            dataTable.Rows.Add(row32);
            DataRow row33 = dataTable.NewRow();
            row33["FieldName"] = (object)"Freight";
            row33["FieldCaption"] = (object)"Freight";
            dataTable.Rows.Add(row33);


            DataRow row67 = dataTable.NewRow();
            row67["FieldName"] = (object)"DocketCharge";
            row67["FieldCaption"] = (object)"Docket Charge";
            dataTable.Rows.Add(row67);

            DataRow row68 = dataTable.NewRow();
            row68["FieldName"] = (object)"ODA_OPA";
            row68["FieldCaption"] = (object)"ODA_OPA";
            dataTable.Rows.Add(row68);

            DataRow row69 = dataTable.NewRow();
            row69["FieldName"] = (object)"FuelSurcharge";
            row69["FieldCaption"] = (object)"Fuel Surcharge";
            dataTable.Rows.Add(row69);

            DataRow row70 = dataTable.NewRow();
            row70["FieldName"] = (object)"ToPay";
            row70["FieldCaption"] = (object)"To Pay";
            dataTable.Rows.Add(row70);

            DataRow row72 = dataTable.NewRow();
            row72["FieldName"] = (object)"HandlingCharge";
            row72["FieldCaption"] = (object)"Handling Charge";
            dataTable.Rows.Add(row72);

            DataRow row73 = dataTable.NewRow();
            row73["FieldName"] = (object)"OtherCharge";
            row73["FieldCaption"] = (object)"Other Charge";
            dataTable.Rows.Add(row73);

            DataRow row74 = dataTable.NewRow();
            row74["FieldName"] = (object)"COD";
            row74["FieldCaption"] = (object)"COD";
            dataTable.Rows.Add(row74);

            DataRow row75 = dataTable.NewRow();
            row75["FieldName"] = (object)"FOV";
            row75["FieldCaption"] = (object)"FOV";
            dataTable.Rows.Add(row75);

            DataRow row77 = dataTable.NewRow();
            row77["FieldName"] = (object)"SubTotal";
            row77["FieldCaption"] = (object)"Sub Total";
            dataTable.Rows.Add(row77);


            DataRow row81 = dataTable.NewRow();
            row81["FieldName"] = (object)"IGST";
            row81["FieldCaption"] = (object)"IGST";
            dataTable.Rows.Add(row81);

            DataRow row82 = dataTable.NewRow();
            row82["FieldName"] = (object)"CGST";
            row82["FieldCaption"] = (object)"CGST";
            dataTable.Rows.Add(row82);

            DataRow row83 = dataTable.NewRow();
            row83["FieldName"] = (object)"SGST";
            row83["FieldCaption"] = (object)"SGST";
            dataTable.Rows.Add(row83);

            DataRow row84 = dataTable.NewRow();
            row84["FieldName"] = (object)"GSTAmount";
            row84["FieldCaption"] = (object)"GST Amount";
            dataTable.Rows.Add(row84);

            DataRow row78 = dataTable.NewRow();
            row78["FieldName"] = (object)"DocketTotal";
            row78["FieldCaption"] = (object)"Docket Total";
            dataTable.Rows.Add(row78);

            DataRow row49 = dataTable.NewRow();
            row49["FieldName"] = (object)"InvoiceNo";
            row49["FieldCaption"] = (object)"Invoice No";
            dataTable.Rows.Add(row49);
            DataRow row50 = dataTable.NewRow();
            row50["FieldName"] = (object)"InvoiceDate";
            row50["FieldCaption"] = (object)"Invoice Date";
            dataTable.Rows.Add(row50);
            DataRow row51 = dataTable.NewRow();
            row51["FieldName"] = (object)"InvoiceAmount";
            row51["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row51);
            DataRow row52 = dataTable.NewRow();
            row52["FieldName"] = (object)"Remarks";
            row52["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row52);

            DataRow row79 = dataTable.NewRow();
            row79["FieldName"] = (object)"IsAvailableForDeliveryMR";
            row79["FieldCaption"] = (object)"Is Available For Delivery MR";
            dataTable.Rows.Add(row79);

            DataRow row53 = dataTable.NewRow();
            row53["FieldName"] = (object)"IsAvailableForDRS";
            row53["FieldCaption"] = (object)"Is Available For DRS";
            dataTable.Rows.Add(row53);
            DataRow row54 = dataTable.NewRow();
            row54["FieldName"] = (object)"IsDelivered";
            row54["FieldCaption"] = (object)"Is Delivered";
            dataTable.Rows.Add(row54);



            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }


        public Response UpdateVehicleeWayBill(MastersIndiaEway objEway)
        {
            MastersIndiaEway ResObj = new MastersIndiaEway();
            MastersIndiaEway ResultObj = new MastersIndiaEway();
            Response res = new Response();
            DataSet ds = new DataSet();
            try
            {
                ResObj = DataBaseFactory.QuerySP<MastersIndiaEway>("CL_GetEwayAccessDetail", (object)null, "Access Detail").FirstOrDefault<MastersIndiaEway>();

                if (ResObj != null)
                {
                    if (ResObj.access_token == "" || ResObj.access_gstin == "" || ResObj.access_url == "")
                    {
                        res.IsSuccessfull = false;
                        res.ErrorMessage = "Access token is null";
                        return res;
                    }
                    string contentStr = "";
                    string data_source = "erp";

                    contentStr += "{\"access_token\":\"" + ResObj.access_token + "\",\"userGstin\":\"" + ResObj.access_gstin + "\",\"eway_bill_number\":\"" + objEway.eway_bill_number + "\","
                                + "\"vehicle_number\":\"" + objEway.vehicle_number + "\",\"place_of_consignor\":\"" + objEway.place_of_consignor + "\",\"state_of_consignor\":\"" + objEway.state_of_consignor + "\","
                                + "\"vehicle_type\":\"" + objEway.vehicle_type + "\",\"reason_code_for_vehicle_updation\":\"" + objEway.reason_code_for_vehicle_updation + "\",\"reason_for_vehicle_updation\":\"" + objEway.reason_for_vehicle_updation + "\","
                                + "\"transporter_document_number\":\"" + objEway.transporter_document_number + "\",\"transporter_document_date\":\"" + objEway.transporter_document_date + "\","
                                + "\"mode_of_transport\":\"" + objEway.mode_of_transport + "\",\"data_source\":\"" + data_source + "\"}";

                    string AddressURL = ResObj.access_url + "updateVehicleNumber";
                    var baseAddress = new Uri(AddressURL);
                    HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
                    POSTRequest.ContentType = "application/json";
                    POSTRequest.Method = "POST";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                    using (var streamWriter = new StreamWriter(POSTRequest.GetRequestStream()))
                    {
                        streamWriter.Write(contentStr);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var resultmsg = streamReader.ReadToEnd();
                        ds = jsonToDataSet(resultmsg.ToString());
                    }

                    if (ds.Tables["results"].Rows.Count > 0)
                    {
                        if (ds.Tables["results"].Rows[0]["status"].ToString().ToUpper() != "SUCCESS")
                        {
                            res.IsSuccessfull = false;
                            res.ErrorMessage = ds.Tables["results"].Rows[0]["message"].ToString();
                            return res;
                        }
                    }
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables["message"].Rows.Count > 0)
                        {
                            objEway.eway_bill_valid_date = ds.Tables["message"].Rows[0]["validUpto"].ToString();

                            DynamicParameters dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objEway), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                            res = DataBaseFactory.QuerySP<Response>("CL_EWayBill_Detail_UpdateVehicle_Update", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
                        }
                    }
                    else
                    {
                        res.IsSuccessfull = false;
                        res.ErrorMessage = ds.Tables["results"].Rows[0]["message"].ToString();
                        return res;

                    }
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }


            return res;
        }
        public Response InserteWayBill(MastersIndiaEway objEway)
        {
            MastersIndiaEway ResObj = new MastersIndiaEway();
            MastersIndiaEway ResultObj = new MastersIndiaEway();
            Response res = new Response();
            DataSet ds = new DataSet();
            try
            {
                ResObj = DataBaseFactory.QuerySP<MastersIndiaEway>("CL_GetEwayAccessDetail", (object)null, "Access Detail").FirstOrDefault<MastersIndiaEway>();

                if (ResObj != null)
                {
                    if (ResObj.access_token == "" || ResObj.access_gstin == "" || ResObj.access_url == "")
                    {
                        res.IsSuccessfull = false;
                        res.ErrorMessage = "Access token is null";
                        return res;
                    }
                    string contentStr = "";
                    string consignment_status = "M";

                    if (objEway.mode_of_transport != "Road")
                    {
                        contentStr += "{\"access_token\":\"" + ResObj.access_token + "\",\"userGstin\":\"" + ResObj.access_gstin + "\",\"eway_bill_number\":\"" + objEway.eway_bill_number + "\","
                       + "\"vehicle_number\":\"" + objEway.vehicle_number + "\",\"place_of_consignor\":\"" + objEway.place_of_consignor + "\",\"state_of_consignor\":\"" + objEway.state_of_consignor + "\","
                       + "\"remaining_distance\":\"" + objEway.remaining_distance + "\",\"mode_of_transport\":\"" + objEway.mode_of_transport + "\",\"extend_validity_reason\":\"" + objEway.extend_validity_reason + "\","
                       + "\"address_line1\":\"" + objEway.state_of_consignor + "\",\"address_line2\":\"" + objEway.state_of_consignor + "\",\"address_line3\":\"" + objEway.state_of_consignor + "\","
                       + "\"extend_remarks\":\"" + objEway.extend_remarks + "\",\"from_pincode\":\"" + objEway.from_pincode + "\",\"consignment_status\":\"" + consignment_status + "\"}";
                    }
                    else
                    {
                        contentStr += "{\"access_token\":\"" + ResObj.access_token + "\",\"userGstin\":\"" + ResObj.access_gstin + "\",\"eway_bill_number\":\"" + objEway.eway_bill_number + "\","
                                    + "\"vehicle_number\":\"" + objEway.vehicle_number + "\",\"place_of_consignor\":\"" + objEway.place_of_consignor + "\",\"state_of_consignor\":\"" + objEway.state_of_consignor + "\","
                                    + "\"remaining_distance\":\"" + objEway.remaining_distance + "\",\"mode_of_transport\":\"" + objEway.mode_of_transport + "\",\"extend_validity_reason\":\"" + objEway.extend_validity_reason + "\","
                                    + "\"transporter_document_number\":\"" + objEway.transporter_document_number + "\",\"transporter_document_date\":\"" + objEway.transporter_document_date + "\","
                                    + "\"address_line1\":\"" + objEway.state_of_consignor + "\",\"address_line2\":\"" + objEway.state_of_consignor + "\",\"address_line3\":\"" + objEway.state_of_consignor + "\","
                                    + "\"extend_remarks\":\"" + objEway.extend_remarks + "\",\"from_pincode\":\"" + objEway.from_pincode + "\",\"consignment_status\":\"" + consignment_status + "\"}";
                    }

                    string AddressURL = ResObj.access_url + "ewayBillValidityExtend";
                    var baseAddress = new Uri(AddressURL);
                    HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
                    POSTRequest.ContentType = "application/json";
                    POSTRequest.Method = "POST";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                    using (var streamWriter = new StreamWriter(POSTRequest.GetRequestStream()))
                    {
                        streamWriter.Write(contentStr);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var resultmsg = streamReader.ReadToEnd();
                        ds = jsonToDataSet(resultmsg.ToString());
                    }

                    if (ds.Tables["results"].Rows.Count > 0)
                    {
                        if (ds.Tables["results"].Rows[0]["status"].ToString().ToUpper() != "SUCCESS")
                        {
                            res.IsSuccessfull = false;
                            res.ErrorMessage = ds.Tables["results"].Rows[0]["message"].ToString();
                            return res;
                        }
                    }
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables["message"].Rows.Count > 0)
                        {
                            objEway.eway_bill_valid_date = ds.Tables["message"].Rows[0]["validUpto"].ToString();

                            DynamicParameters dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objEway), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                            res = DataBaseFactory.QuerySP<Response>("CL_EWayBill_Detail_Update", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
                        }
                    }
                    else
                    {
                        res.IsSuccessfull = false;
                        res.ErrorMessage = ds.Tables["results"].Rows[0]["message"].ToString();
                        return res;

                    }
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }


            return res;
        }

        public MastersIndiaEway CalculateDistance(string fromPincode, string toPincode)
        {
            DataTable dtResponce = new DataTable();
            DataTable dt = new DataTable();
            MastersIndiaEway ResObj = new MastersIndiaEway();
            MastersIndiaEway ResponceObj = new MastersIndiaEway();

            try
            {
                ResObj = DataBaseFactory.QuerySP<MastersIndiaEway>("CL_GetEwayAccessDetail", (object)null, "Access Detail").FirstOrDefault<MastersIndiaEway>();

                if (ResObj != null)
                {
                    string AddressURL = ResObj.access_url + "distance?access_token=" + ResObj.access_token + "&fromPincode=" + fromPincode + "&toPincode=" + toPincode;

                    var baseAddress = new Uri(AddressURL);
                    HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
                    POSTRequest.ContentType = "application/json";
                    POSTRequest.Method = "GET";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                    var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var resultmsg = streamReader.ReadToEnd();
                        DataSet ds = jsonToDataSet(resultmsg.ToString());
                        DataTable dtresults = ds.Tables["results"];

                        if (ds.Tables.Contains("results"))
                        {
                            if (ds.Tables["results"].Rows.Count > 0)
                            {
                                if (ds.Tables["results"].Rows[0]["status"].ToString().ToUpper() == ("Success").ToUpper())
                                {
                                    ResponceObj.remaining_distance = ds.Tables["results"].Rows[0]["distance"].ToString();
                                }
                                else
                                {
                                    ResponceObj.remaining_distance = "Invalid";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ResponceObj.remaining_distance = "Invalid";
            }
            return ResponceObj;
        }

        public Response ImportManualEWayBill(string eway_bill_number)
        {
            DataTable dtResponce = new DataTable();
            MastersIndiaEway ResObj = new MastersIndiaEway();
            Response res = new Response();
            try
            {
                ResObj = DataBaseFactory.QuerySP<MastersIndiaEway>("CL_GetEwayAccessDetail", (object)null, "Access Detail").FirstOrDefault<MastersIndiaEway>();

                if (ResObj != null)
                {
                    DataSet Finds = new DataSet();
                    Finds = BindColumns(Finds);
                    //Finds = BindColumnsforAuthorization(Finds);

                    DataSet ds = eWayBillDetail(ResObj.access_token, ResObj.access_gstin, ResObj.access_url, eway_bill_number, Finds);

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Doc", (object)ds.GetXml().ToString(), new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    res = DataBaseFactory.QuerySP<Response>("CL_EWayBill_Config_Ins", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();

                }
            }
            catch (Exception ex)
            {
            }
            return res;

        }

        //private DataSet BindColumns(DataSet ds)
        //{
        //    ds.Tables.Add("eWayList");
        //    ds.Tables["eWayList"].Columns.Add("status");
        //    ds.Tables["eWayList"].Columns.Add("code");
        //    ds.Tables["eWayList"].Columns.Add("eway_bill_number");
        //    ds.Tables["eWayList"].Columns.Add("eway_bill_date");
        //    ds.Tables["eWayList"].Columns.Add("eway_bill_valid_date");
        //    ds.Tables["eWayList"].Columns.Add("number_of_valid_days");
        //    ds.Tables["eWayList"].Columns.Add("eway_bill_status");
        //    ds.Tables["eWayList"].Columns.Add("userGstin");
        //    ds.Tables["eWayList"].Columns.Add("document_type");
        //    ds.Tables["eWayList"].Columns.Add("document_number");
        //    ds.Tables["eWayList"].Columns.Add("document_date");
        //    ds.Tables["eWayList"].Columns.Add("gstin_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("legal_name_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("address1_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("address2_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("place_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("pincode_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("state_of_consignor");
        //    ds.Tables["eWayList"].Columns.Add("actual_from_state_name");
        //    ds.Tables["eWayList"].Columns.Add("gstin_of_consignee");
        //    ds.Tables["eWayList"].Columns.Add("legal_name_of_consignee");
        //    ds.Tables["eWayList"].Columns.Add("address1_of_consignee");
        //    ds.Tables["eWayList"].Columns.Add("address2_of_consignee");
        //    ds.Tables["eWayList"].Columns.Add("place_of_consignee");
        //    ds.Tables["eWayList"].Columns.Add("pincode_of_consignee");
        //    ds.Tables["eWayList"].Columns.Add("state_of_supply");
        //    ds.Tables["eWayList"].Columns.Add("actual_to_state_name");
        //    ds.Tables["eWayList"].Columns.Add("vehicle_number");
        //    ds.Tables["eWayList"].Columns.Add("total_invoice_value");
        //    ds.Tables["eWayList"].Columns.Add("taxable_amount");
        //    ds.Tables["eWayList"].Columns.Add("cgst_amount");
        //    ds.Tables["eWayList"].Columns.Add("sgst_amount");
        //    ds.Tables["eWayList"].Columns.Add("igst_amount");
        //    ds.Tables["eWayList"].Columns.Add("transporter_id");
        //    ds.Tables["eWayList"].Columns.Add("transporter_name");
        //    ds.Tables["eWayList"].Columns.Add("transportation_distance");
        //    ds.Tables["eWayList"].Columns.Add("transporter_document_number");
        //    ds.Tables["eWayList"].Columns.Add("transporter_document_date");
        //    ds.Tables["eWayList"].Columns.Add("transportation_mode");

        //    //transportation_mode
        //    return ds;
        //}

        private DataSet BindColumns(DataSet ds)
        {
            ds.Tables.Add("eWayList");
            ds.Tables["eWayList"].Columns.Add("success");
            ds.Tables["eWayList"].Columns.Add("message");
            ds.Tables["eWayList"].Columns.Add("ewbNo");
            ds.Tables["eWayList"].Columns.Add("ewayBillDate");
            ds.Tables["eWayList"].Columns.Add("validUpto");
            ds.Tables["eWayList"].Columns.Add("noValidDays");
            ds.Tables["eWayList"].Columns.Add("status");
            ds.Tables["eWayList"].Columns.Add("userGstin");
            ds.Tables["eWayList"].Columns.Add("docType");
            ds.Tables["eWayList"].Columns.Add("docNo");
            ds.Tables["eWayList"].Columns.Add("docDate");
            ds.Tables["eWayList"].Columns.Add("fromGstin");
            ds.Tables["eWayList"].Columns.Add("fromTrdName");
            ds.Tables["eWayList"].Columns.Add("fromAddr1");
            ds.Tables["eWayList"].Columns.Add("fromAddr2");
            ds.Tables["eWayList"].Columns.Add("fromPlace");
            ds.Tables["eWayList"].Columns.Add("fromPincode");
            ds.Tables["eWayList"].Columns.Add("fromStateCode");
            ds.Tables["eWayList"].Columns.Add("actFromStateCode");
            ds.Tables["eWayList"].Columns.Add("toGstin");
            ds.Tables["eWayList"].Columns.Add("toTrdName");
            ds.Tables["eWayList"].Columns.Add("toAddr1");
            ds.Tables["eWayList"].Columns.Add("toAddr2");
            ds.Tables["eWayList"].Columns.Add("toPlace");
            ds.Tables["eWayList"].Columns.Add("toPincode");
            ds.Tables["eWayList"].Columns.Add("stateOfSupply");
            ds.Tables["eWayList"].Columns.Add("actToStateCode");
            ds.Tables["eWayList"].Columns.Add("vehicleNo");
            ds.Tables["eWayList"].Columns.Add("totInvValue");
            ds.Tables["eWayList"].Columns.Add("taxableAmount");
            ds.Tables["eWayList"].Columns.Add("cgstValue");
            ds.Tables["eWayList"].Columns.Add("sgstValue");
            ds.Tables["eWayList"].Columns.Add("igstValue");
            ds.Tables["eWayList"].Columns.Add("transporterId");
            ds.Tables["eWayList"].Columns.Add("transporterName");
            ds.Tables["eWayList"].Columns.Add("actualDist");
            ds.Tables["eWayList"].Columns.Add("transDocNo");
            ds.Tables["eWayList"].Columns.Add("transDocDate");
            ds.Tables["eWayList"].Columns.Add("transMode");

            //transportation_mode
            return ds;
        }

        //private DataSet eWayBillDetail(string access_token, string access_gstin,
        // string access_url, string eway_bill_number, DataSet dsObj)
        //{
        //    try
        //    {
        //        DataTable dtResponce = new DataTable();
        //        DataTable dt = new DataTable();

        //        string AddressURL = access_url + "getEwayBillData?access_token=" + access_token + "&action=GetEwayBill&gstin=" + access_gstin + "&eway_bill_number=" + eway_bill_number;

        //        var baseAddress = new Uri(AddressURL);
        //        HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
        //        POSTRequest.ContentType = "application/json";
        //        POSTRequest.Method = "GET";
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

        //        var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();

        //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            var resultmsg = streamReader.ReadToEnd();
        //            DataSet ds = jsonToDataSet(resultmsg.ToString());
        //            DataTable dtresults = ds.Tables["results"];

        //            if (ds.Tables.Contains("message"))
        //            {
        //                if (ds.Tables["message"].Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < ds.Tables["message"].Rows.Count; i++)
        //                    {
        //                        DataRow dr = dsObj.Tables["eWayList"].NewRow();
        //                        dr["status"] = ds.Tables["results"].Rows[0]["status"].ToString();
        //                        dr["code"] = ds.Tables["results"].Rows[0]["code"].ToString();
        //                        dr["eway_bill_number"] = ds.Tables["message"].Rows[0]["eway_bill_number"].ToString();
        //                        dr["eway_bill_date"] = ds.Tables["message"].Rows[0]["eway_bill_date"].ToString();
        //                        string[] eway_bill_date = ds.Tables["message"].Rows[0]["eway_bill_date"].ToString().Split(' ');
        //                        if (eway_bill_date.Length > 0)
        //                        {
        //                            dr["eway_bill_date"] = eway_bill_date[0].ToString();
        //                        }

        //                        dr["eway_bill_valid_date"] = ds.Tables["message"].Rows[0]["eway_bill_valid_date"].ToString();

        //                        string[] eway_bill_valid_date = ds.Tables["message"].Rows[0]["eway_bill_valid_date"].ToString().Split(' ');
        //                        if (eway_bill_valid_date.Length > 0)
        //                        {
        //                            dr["eway_bill_valid_date"] = eway_bill_valid_date[0].ToString();
        //                        }
        //                        dr["number_of_valid_days"] = ds.Tables["message"].Rows[0]["number_of_valid_days"].ToString();
        //                        dr["eway_bill_status"] = ds.Tables["message"].Rows[0]["eway_bill_status"].ToString();
        //                        dr["userGstin"] = ds.Tables["message"].Rows[0]["userGstin"].ToString();
        //                        dr["document_type"] = ds.Tables["message"].Rows[0]["document_type"].ToString();
        //                        dr["document_number"] = ds.Tables["message"].Rows[0]["document_number"].ToString();
        //                        dr["document_date"] = ds.Tables["message"].Rows[0]["document_date"].ToString();
        //                        dr["gstin_of_consignor"] = ds.Tables["message"].Rows[0]["gstin_of_consignor"].ToString();
        //                        dr["legal_name_of_consignor"] = ds.Tables["message"].Rows[0]["legal_name_of_consignor"].ToString();
        //                        dr["address1_of_consignor"] = ""; // ds.Tables["message"].Rows[0]["address1_of_consignor"].ToString();
        //                        dr["address2_of_consignor"] = "";// ds.Tables["message"].Rows[0]["address2_of_consignor"].ToString();
        //                        dr["place_of_consignor"] = ds.Tables["message"].Rows[0]["place_of_consignor"].ToString();
        //                        dr["pincode_of_consignor"] = ds.Tables["message"].Rows[0]["pincode_of_consignor"].ToString();
        //                        dr["state_of_consignor"] = ds.Tables["message"].Rows[0]["state_of_consignor"].ToString();
        //                        dr["actual_from_state_name"] = ds.Tables["message"].Rows[0]["actual_from_state_name"].ToString();
        //                        dr["gstin_of_consignee"] = ds.Tables["message"].Rows[0]["gstin_of_consignee"].ToString();
        //                        dr["legal_name_of_consignee"] = ds.Tables["message"].Rows[0]["legal_name_of_consignee"].ToString();
        //                        dr["address1_of_consignee"] = "";// ds.Tables["message"].Rows[0]["address1_of_consignee"].ToString();
        //                        dr["address2_of_consignee"] = "";// ds.Tables["message"].Rows[0]["address2_of_consignee"].ToString();
        //                        dr["place_of_consignee"] = ds.Tables["message"].Rows[0]["place_of_consignee"].ToString();
        //                        dr["pincode_of_consignee"] = ds.Tables["message"].Rows[0]["pincode_of_consignee"].ToString();
        //                        dr["state_of_supply"] = ds.Tables["message"].Rows[0]["state_of_supply"].ToString();
        //                        dr["actual_to_state_name"] = ds.Tables["message"].Rows[0]["actual_to_state_name"].ToString();
        //                        dr["total_invoice_value"] = ds.Tables["message"].Rows[0]["total_invoice_value"].ToString();
        //                        dr["taxable_amount"] = ds.Tables["message"].Rows[0]["taxable_amount"].ToString();
        //                        dr["cgst_amount"] = ds.Tables["message"].Rows[0]["cgst_amount"].ToString();
        //                        dr["sgst_amount"] = ds.Tables["message"].Rows[0]["sgst_amount"].ToString();
        //                        dr["igst_amount"] = ds.Tables["message"].Rows[0]["igst_amount"].ToString();
        //                        dr["transporter_id"] = ds.Tables["message"].Rows[0]["transporter_id"].ToString();
        //                        dr["transporter_name"] = ds.Tables["message"].Rows[0]["transporter_name"].ToString();
        //                        dr["transportation_distance"] = ds.Tables["message"].Rows[0]["transportation_distance"].ToString();

        //                        if (ds.Tables.Contains("VehiclListDetails"))
        //                        {
        //                            if (ds.Tables["VehiclListDetails"].Rows.Count > 0)
        //                            {
        //                                dr["vehicle_number"] = ds.Tables["VehiclListDetails"].Rows[0]["vehicle_number"].ToString();
        //                                dr["transporter_document_number"] = ds.Tables["VehiclListDetails"].Rows[0]["transporter_document_number"].ToString();
        //                                dr["transporter_document_date"] = ds.Tables["VehiclListDetails"].Rows[0]["transporter_document_date"].ToString();
        //                                dr["transportation_mode"] = ds.Tables["VehiclListDetails"].Rows[0]["transportation_mode"].ToString();
        //                            }
        //                        }
        //                        dsObj.Tables["eWayList"].Rows.Add(dr);
        //                    }

        //                }

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dsObj;
        //}

        private DataSet eWayBillDetail(string access_token, string access_gstin, string access_url, string ewbNo, DataSet dsObj)
        {
            try
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                access_token = GetAuthorizationToken();

                DataTable dtResponce = new DataTable();
                DataTable dt = new DataTable();
                access_url = "https://gsp.adaequare.com/test/enriched/ewb/ewayapi/";
                string AddressURL = access_url + "GetEwayBill?ewbNo=" + ewbNo;
                var baseAddress = new Uri(AddressURL);


                HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
                POSTRequest.ContentType = "application/json";
                POSTRequest.Method = "GET";
                POSTRequest.PreAuthenticate = true;
                POSTRequest.Headers.Add("username", ConfigurationManager.AppSettings["apiUsername"]);
                POSTRequest.Headers.Add("password", ConfigurationManager.AppSettings["apiUserPassword"]);
                POSTRequest.Headers.Add("gstin", ConfigurationManager.AppSettings["apiGstin"]);
                POSTRequest.Headers.Add("requestid", finalString);
                POSTRequest.Headers.Add("Authorization", access_token);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultmsg = streamReader.ReadToEnd();
                    DataSet ds = jsonToDataSet(resultmsg.ToString());
                    DataTable dtresults = ds.Tables["result"];

                    if (ds.Tables.Contains("result"))
                    {
                        if (ds.Tables["result"].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables["result"].Rows.Count; i++)
                            {
                                DataRow dr = dsObj.Tables["eWayList"].NewRow();
                                dr["success"] = ds.Tables["rootNode"].Rows[0]["success"].ToString();
                                dr["message"] = ds.Tables["rootNode"].Rows[0]["message"].ToString();
                                dr["ewbNo"] = ds.Tables["result"].Rows[0]["ewbNo"].ToString();
                                dr["ewayBillDate"] = ds.Tables["result"].Rows[0]["ewayBillDate"].ToString();
                                string[] ewayBillDate = ds.Tables["result"].Rows[0]["ewayBillDate"].ToString().Split(' ');
                                if (ewayBillDate.Length > 0)
                                {
                                    dr["ewayBillDate"] = ewayBillDate[0].ToString();
                                }

                                dr["validUpto"] = ds.Tables["result"].Rows[0]["validUpto"].ToString();

                                string[] validUpto = ds.Tables["result"].Rows[0]["validUpto"].ToString().Split(' ');
                                if (validUpto.Length > 0)
                                {
                                    dr["validUpto"] = validUpto[0].ToString();
                                }
                                dr["noValidDays"] = ds.Tables["result"].Rows[0]["noValidDays"].ToString();
                                dr["status"] = ds.Tables["result"].Rows[0]["status"].ToString();
                                dr["userGstin"] = ds.Tables["result"].Rows[0]["userGstin"].ToString();
                                dr["docType"] = ds.Tables["result"].Rows[0]["docType"].ToString();
                                dr["docNo"] = ds.Tables["result"].Rows[0]["docNo"].ToString();
                                dr["docDate"] = ds.Tables["result"].Rows[0]["docDate"].ToString();
                                dr["fromGstin"] = ds.Tables["result"].Rows[0]["fromGstin"].ToString();
                                dr["fromTrdName"] = ds.Tables["result"].Rows[0]["fromTrdName"].ToString();
                                dr["fromAddr1"] = string.Empty; // ds.Tables["result"].Rows[0]["fromAddr1"].ToString();
                                dr["fromAddr2"] = string.Empty;// ds.Tables["result"].Rows[0]["fromAddr2"].ToString();
                                dr["fromPlace"] = ds.Tables["result"].Rows[0]["fromPlace"].ToString();
                                dr["fromPincode"] = ds.Tables["result"].Rows[0]["fromPincode"].ToString();
                                dr["fromStateCode"] = ds.Tables["result"].Rows[0]["fromStateCode"].ToString();
                                dr["actFromStateCode"] = ds.Tables["result"].Rows[0]["actFromStateCode"].ToString();
                                dr["toGstin"] = ds.Tables["result"].Rows[0]["toGstin"].ToString();
                                dr["toTrdName"] = ds.Tables["result"].Rows[0]["toTrdName"].ToString();
                                dr["toAddr1"] = "";// ds.Tables["result"].Rows[0]["toAddr1"].ToString();
                                dr["toAddr2"] = "";// ds.Tables["result"].Rows[0]["toAddr2"].ToString();
                                dr["toPlace"] = ds.Tables["result"].Rows[0]["toPlace"].ToString();
                                dr["toPincode"] = ds.Tables["result"].Rows[0]["toPincode"].ToString();
                                dr["stateOfSupply"] = string.Empty;
                                dr["actToStateCode"] = ds.Tables["result"].Rows[0]["actToStateCode"].ToString();
                                dr["totInvValue"] = ds.Tables["result"].Rows[0]["totInvValue"].ToString();
                                dr["cgstValue"] = ds.Tables["result"].Rows[0]["cgstValue"].ToString();
                                dr["sgstValue"] = ds.Tables["result"].Rows[0]["sgstValue"].ToString();
                                dr["igstValue"] = ds.Tables["result"].Rows[0]["igstValue"].ToString();
                                dr["transporterId"] = ds.Tables["result"].Rows[0]["transporterId"].ToString();
                                dr["transporterName"] = ds.Tables["result"].Rows[0]["transporterName"].ToString();
                                dr["actualDist"] = ds.Tables["result"].Rows[0]["actualDist"].ToString();

                                if (ds.Tables.Contains("itemList"))
                                {
                                    if (ds.Tables["itemList"].Rows.Count > 0)
                                    {
                                        dr["taxableAmount"] = ds.Tables["itemList"].Rows[0]["taxableAmount"].ToString();
                                    }
                                }

                                if (ds.Tables.Contains("VehiclListDetails"))
                                {
                                    if (ds.Tables["VehiclListDetails"].Rows.Count > 0)
                                    {
                                        dr["vehicleNo"] = ds.Tables["VehiclListDetails"].Rows[0]["vehicleNo"].ToString();
                                        dr["transDocNo"] = ds.Tables["VehiclListDetails"].Rows[0]["transDocNo"].ToString();
                                        dr["transDocDate"] = ds.Tables["VehiclListDetails"].Rows[0]["transDocDate"].ToString();
                                        dr["transMode"] = ds.Tables["VehiclListDetails"].Rows[0]["transMode"].ToString();
                                    }
                                }
                                dsObj.Tables["eWayList"].Rows.Add(dr);
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return dsObj;
        }

        public EwayBillDetails GetEwayBillDetails(string ewbNo)
        {
            EwayBillDetails ewayBillDetails = new EwayBillDetails();

            DynamicParameters param = new DynamicParameters();
            param.Add("@ewbNo", (object)ewbNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var result = DataBaseFactory.QuerySP<EwayBillDetails>("Usp_EWayBill_Detail", (object)param, "GetEwayBillDetail").FirstOrDefault<EwayBillDetails>();

            if (result != null)
            {
                return result;
            }
            else
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                string access_token = GetAuthorizationToken();
                var stringChars = new char[8];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                try
                {
                    DataTable dtResponce = new DataTable();
                    DataTable dt = new DataTable();
                    string access_url = "https://gsp.adaequare.com/test/enriched/ewb/ewayapi/";
                    string AddressURL = access_url + "GetEwayBill?ewbNo=" + ewbNo;
                    var baseAddress = new Uri(AddressURL);
                    HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
                    POSTRequest.ContentType = "application/json";
                    POSTRequest.Method = "GET";
                    POSTRequest.PreAuthenticate = true;
                    POSTRequest.Headers.Add("username", ConfigurationManager.AppSettings["apiUsername"]);
                    POSTRequest.Headers.Add("password", ConfigurationManager.AppSettings["apiUserPassword"]);
                    POSTRequest.Headers.Add("gstin", ConfigurationManager.AppSettings["apiGstin"]);
                    POSTRequest.Headers.Add("requestid", finalString);
                    POSTRequest.Headers.Add("Authorization", access_token);

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                    var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var resultmsg = streamReader.ReadToEnd();
                        DataSet ds = jsonToDataSet(resultmsg.ToString());
                        DataTable dtresults = ds.Tables["result"];

                        if (ds.Tables.Contains("result"))
                        {
                            if (ds.Tables["result"].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables["result"].Rows.Count; i++)
                                {
                                    ewayBillDetails.Success = ds.Tables["rootNode"].Rows[0]["success"].ToString() == "true" ? true : false;
                                    string[] ewayBillDate = ds.Tables["result"].Rows[0]["ewayBillDate"].ToString().Split(' ');
                                    if (ewayBillDate.Length > 0)
                                    {
                                        ewayBillDetails.EwayBillDate = ewayBillDate[0].ToString();
                                    }
                                    string[] validUpto = ds.Tables["result"].Rows[0]["validUpto"].ToString().Split(' ');
                                    if (validUpto.Length > 0)
                                    {
                                        ewayBillDetails.EwayBillExpiryDate = validUpto[0].ToString();
                                    }
                                    ewayBillDetails.InvoiceNo = ds.Tables["result"].Rows[0]["docNo"].ToString();
                                    ewayBillDetails.InvoiceDate = ds.Tables["result"].Rows[0]["docDate"].ToString();
                                    ewayBillDetails.TotalInvoiceAmount = ds.Tables["result"].Rows[0]["totInvValue"].ToString();
                                }

                            }

                        }

                    }
                }
                catch (Exception ex)
                {

                }
                return ewayBillDetails;
            }
        }

        public DataSet GetEwayBillDetail(string ewbNo)
        {
            DataSet dsObj = new DataSet();
            dsObj = BindColumns(dsObj);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            string access_token = GetAuthorizationToken();
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            try
            {
                DataTable dtResponce = new DataTable();
                DataTable dt = new DataTable();
                string access_url = "https://gsp.adaequare.com/test/enriched/ewb/ewayapi/";
                string AddressURL = access_url + "GetEwayBill?ewbNo=" + ewbNo;

                var baseAddress = new Uri(AddressURL);
                HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
                POSTRequest.ContentType = "application/json";
                POSTRequest.Method = "GET";
                POSTRequest.PreAuthenticate = true;
                POSTRequest.Headers.Add("username", ConfigurationManager.AppSettings["apiUsername"]);
                POSTRequest.Headers.Add("password", ConfigurationManager.AppSettings["apiUserPassword"]);
                POSTRequest.Headers.Add("gstin", ConfigurationManager.AppSettings["apiGstin"]);
                POSTRequest.Headers.Add("requestid", finalString);
                POSTRequest.Headers.Add("Authorization", access_token);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultmsg = streamReader.ReadToEnd();
                    DataSet ds = jsonToDataSet(resultmsg.ToString());
                    DataTable dtresults = ds.Tables["result"];

                    if (ds.Tables.Contains("result"))
                    {
                        if (ds.Tables["result"].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables["result"].Rows.Count; i++)
                            {
                                DataRow dr = dsObj.Tables["eWayList"].NewRow();
                                dr["success"] = ds.Tables["rootNode"].Rows[0]["success"].ToString();
                                dr["message"] = ds.Tables["rootNode"].Rows[0]["message"].ToString();
                                dr["ewbNo"] = ds.Tables["result"].Rows[0]["ewbNo"].ToString();
                                dr["ewayBillDate"] = ds.Tables["result"].Rows[0]["ewayBillDate"].ToString();
                                string[] ewayBillDate = ds.Tables["result"].Rows[0]["ewayBillDate"].ToString().Split(' ');
                                if (ewayBillDate.Length > 0)
                                {
                                    dr["ewayBillDate"] = ewayBillDate[0].ToString();
                                }

                                dr["validUpto"] = ds.Tables["result"].Rows[0]["validUpto"].ToString();

                                string[] validUpto = ds.Tables["result"].Rows[0]["validUpto"].ToString().Split(' ');
                                if (validUpto.Length > 0)
                                {
                                    dr["validUpto"] = validUpto[0].ToString();
                                }
                                dr["noValidDays"] = ds.Tables["result"].Rows[0]["noValidDays"].ToString();
                                dr["status"] = ds.Tables["result"].Rows[0]["status"].ToString();
                                dr["userGstin"] = ds.Tables["result"].Rows[0]["userGstin"].ToString();
                                dr["docType"] = ds.Tables["result"].Rows[0]["docType"].ToString();
                                dr["docNo"] = ds.Tables["result"].Rows[0]["docNo"].ToString();
                                dr["docDate"] = ds.Tables["result"].Rows[0]["docDate"].ToString();
                                dr["fromGstin"] = ds.Tables["result"].Rows[0]["fromGstin"].ToString();
                                dr["fromTrdName"] = ds.Tables["result"].Rows[0]["fromTrdName"].ToString();
                                dr["fromAddr1"] = string.Empty; // ds.Tables["result"].Rows[0]["fromAddr1"].ToString();
                                dr["fromAddr2"] = string.Empty;// ds.Tables["result"].Rows[0]["fromAddr2"].ToString();
                                dr["fromPlace"] = ds.Tables["result"].Rows[0]["fromPlace"].ToString();
                                dr["fromPincode"] = ds.Tables["result"].Rows[0]["fromPincode"].ToString();
                                dr["fromStateCode"] = ds.Tables["result"].Rows[0]["fromStateCode"].ToString();
                                dr["actFromStateCode"] = ds.Tables["result"].Rows[0]["actFromStateCode"].ToString();
                                dr["toGstin"] = ds.Tables["result"].Rows[0]["toGstin"].ToString();
                                dr["toTrdName"] = ds.Tables["result"].Rows[0]["toTrdName"].ToString();
                                dr["toAddr1"] = "";// ds.Tables["result"].Rows[0]["toAddr1"].ToString();
                                dr["toAddr2"] = "";// ds.Tables["result"].Rows[0]["toAddr2"].ToString();
                                dr["toPlace"] = ds.Tables["result"].Rows[0]["toPlace"].ToString();
                                dr["toPincode"] = ds.Tables["result"].Rows[0]["toPincode"].ToString();
                                dr["stateOfSupply"] = string.Empty;
                                dr["actToStateCode"] = ds.Tables["result"].Rows[0]["actToStateCode"].ToString();
                                dr["totInvValue"] = ds.Tables["result"].Rows[0]["totInvValue"].ToString();
                                dr["cgstValue"] = ds.Tables["result"].Rows[0]["cgstValue"].ToString();
                                dr["sgstValue"] = ds.Tables["result"].Rows[0]["sgstValue"].ToString();
                                dr["igstValue"] = ds.Tables["result"].Rows[0]["igstValue"].ToString();
                                dr["transporterId"] = ds.Tables["result"].Rows[0]["transporterId"].ToString();
                                dr["transporterName"] = ds.Tables["result"].Rows[0]["transporterName"].ToString();
                                dr["actualDist"] = ds.Tables["result"].Rows[0]["actualDist"].ToString();

                                if (ds.Tables.Contains("itemList"))
                                {
                                    if (ds.Tables["itemList"].Rows.Count > 0)
                                    {
                                        dr["taxableAmount"] = ds.Tables["itemList"].Rows[0]["taxableAmount"].ToString();
                                    }
                                }

                                if (ds.Tables.Contains("VehiclListDetails"))
                                {
                                    if (ds.Tables["VehiclListDetails"].Rows.Count > 0)
                                    {
                                        dr["vehicleNo"] = ds.Tables["VehiclListDetails"].Rows[0]["vehicleNo"].ToString();
                                        dr["transDocNo"] = ds.Tables["VehiclListDetails"].Rows[0]["transDocNo"].ToString();
                                        dr["transDocDate"] = ds.Tables["VehiclListDetails"].Rows[0]["transDocDate"].ToString();
                                        dr["transMode"] = ds.Tables["VehiclListDetails"].Rows[0]["transMode"].ToString();
                                    }
                                }
                                dsObj.Tables["eWayList"].Rows.Add(dr);
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return dsObj;
        }

        public string GetAuthorizationToken()
        {
            string access_token = string.Empty;
            string access_url = "https://gsp.adaequare.com/gsp/authenticate?grant_type=token";

            var baseAddress = new Uri(access_url);
            HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseAddress);
            POSTRequest.ContentType = "application/json";
            POSTRequest.Method = "POST";
            POSTRequest.PreAuthenticate = true;
            POSTRequest.Headers.Add("gspappid", "87712B75AAE34C4F8DA3BC97BECFD209");
            POSTRequest.Headers.Add("gspappsecret", "1D410F73G5486G4E20GB673G1166661FC8B1");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            var httpResponse = (HttpWebResponse)POSTRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resultmsg = streamReader.ReadToEnd();
                DataSet ds = jsonToDataSet(resultmsg.ToString());
                access_token = "Bearer " + ds.Tables["rootNode"].Rows[0]["access_token"].ToString();
            }
            return access_token;
        }

        public IEnumerable<MastersIndiaEway> eWayBillList()
        {
            return DataBaseFactory.QuerySP<MastersIndiaEway>("CL_EWayBill_Detail_GetAll", (object)null, "eWay Bill - GetAll");
        }
        public MastersIndiaEway eWayBillView(string eway_bill_number)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@eway_bill_number", (object)eway_bill_number, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MastersIndiaEway>("CL_EWayBill_Detail_GetById", (object)dynamicParameters, "eWay Bill - GetAll").FirstOrDefault<MastersIndiaEway>();
        }
        public MastersIndiaEway getEwayBillData(string eway_bill_number)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@eway_bill_number", (object)eway_bill_number, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MastersIndiaEway>("CL_EWayBill_Detail_GetByIdView", (object)dynamicParameters, "eWay Bill - GetAll").FirstOrDefault<MastersIndiaEway>();
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
        //private MastersIndiaEway datasetToObject(DataSet ds)
        //{
        //    MastersIndiaEway objEway = new MastersIndiaEway();
        //    try
        //    {
        //        if (ds.Tables["results"].Rows.Count > 0)
        //        {
        //            objEway.status = ds.Tables["results"].Rows[0]["status"].ToString().ToUpper();
        //            objEway.code = ds.Tables["results"].Rows[0]["code"].ToString();
        //        }
        //        if (ds.Tables.Count == 1)
        //        {
        //            return objEway;
        //        }

        //        if (ds.Tables["message"].Rows.Count > 0)
        //        {
        //            objEway.eway_bill_number = ds.Tables["message"].Rows[0]["eway_bill_number"].ToString();
        //            objEway.eway_bill_date = ds.Tables["message"].Rows[0]["eway_bill_date"].ToString();

        //            string[] eway_bill_date = objEway.eway_bill_date.Split(' ');
        //            if (eway_bill_date.Length > 0)
        //            {
        //                objEway.eway_bill_date = eway_bill_date[0].ToString();
        //            }

        //            objEway.eway_bill_valid_date = ds.Tables["message"].Rows[0]["eway_bill_valid_date"].ToString();

        //            string[] eway_bill_valid_date = objEway.eway_bill_valid_date.Split(' ');
        //            if (eway_bill_valid_date.Length > 0)
        //            {
        //                objEway.eway_bill_valid_date = eway_bill_valid_date[0].ToString();
        //            }

        //            objEway.number_of_valid_days = ds.Tables["message"].Rows[0]["number_of_valid_days"].ToString();
        //            objEway.eway_bill_status = ds.Tables["message"].Rows[0]["eway_bill_status"].ToString();
        //            objEway.userGstin = ds.Tables["message"].Rows[0]["userGstin"].ToString();
        //            objEway.document_type = ds.Tables["message"].Rows[0]["document_type"].ToString();
        //            objEway.document_number = ds.Tables["message"].Rows[0]["document_number"].ToString();
        //            objEway.document_date = ds.Tables["message"].Rows[0]["document_date"].ToString();
        //            objEway.gstin_of_consignor = ds.Tables["message"].Rows[0]["gstin_of_consignor"].ToString();
        //            objEway.legal_name_of_consignor = ds.Tables["message"].Rows[0]["legal_name_of_consignor"].ToString();
        //            objEway.address1_of_consignor = ds.Tables["message"].Rows[0]["address1_of_consignor"].ToString();
        //            objEway.address2_of_consignor = ds.Tables["message"].Rows[0]["address2_of_consignor"].ToString();
        //            objEway.place_of_consignor = ds.Tables["message"].Rows[0]["place_of_consignor"].ToString();
        //            objEway.pincode_of_consignor = ds.Tables["message"].Rows[0]["pincode_of_consignor"].ToString();
        //            objEway.state_of_consignor = ds.Tables["message"].Rows[0]["state_of_consignor"].ToString();
        //            objEway.actual_from_state_name = ds.Tables["message"].Rows[0]["actual_from_state_name"].ToString();
        //            objEway.gstin_of_consignee = ds.Tables["message"].Rows[0]["gstin_of_consignee"].ToString();
        //            objEway.legal_name_of_consignee = ds.Tables["message"].Rows[0]["legal_name_of_consignee"].ToString();
        //            objEway.address1_of_consignee = ds.Tables["message"].Rows[0]["address1_of_consignee"].ToString();
        //            objEway.address2_of_consignee = ds.Tables["message"].Rows[0]["address2_of_consignee"].ToString();
        //            objEway.place_of_consignee = ds.Tables["message"].Rows[0]["place_of_consignee"].ToString();
        //            objEway.pincode_of_consignee = ds.Tables["message"].Rows[0]["pincode_of_consignee"].ToString();
        //            objEway.state_of_supply = ds.Tables["message"].Rows[0]["state_of_supply"].ToString();
        //            objEway.actual_to_state_name = ds.Tables["message"].Rows[0]["actual_to_state_name"].ToString();
        //        }
        //        if (ds.Tables["VehiclListDetails"].Rows.Count > 0)
        //        {
        //            objEway.vehicle_number = ds.Tables["VehiclListDetails"].Rows[0]["vehicle_number"].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return objEway;
        //}

        private MastersIndiaEway datasetToObject(DataSet ds)
        {
            MastersIndiaEway objEway = new MastersIndiaEway();
            try
            {
                if (ds.Tables["result"].Rows.Count > 0)
                {
                    objEway.success = ds.Tables["result"].Rows[0]["success"].ToString().ToUpper();
                    objEway.message = ds.Tables["result"].Rows[0]["message"].ToString();
                }
                if (ds.Tables.Count == 1)
                {
                    return objEway;
                }

                if (ds.Tables["message"].Rows.Count > 0)
                {
                    objEway.eway_bill_number = ds.Tables["message"].Rows[0]["ewbNo"].ToString();
                    objEway.eway_bill_date = ds.Tables["message"].Rows[0]["ewayBillDate"].ToString();

                    string[] eway_bill_date = objEway.eway_bill_date.Split(' ');
                    if (eway_bill_date.Length > 0)
                    {
                        objEway.eway_bill_date = eway_bill_date[0].ToString();
                    }

                    objEway.eway_bill_valid_date = ds.Tables["message"].Rows[0]["validUpto"].ToString();

                    string[] eway_bill_valid_date = objEway.eway_bill_valid_date.Split(' ');
                    if (eway_bill_valid_date.Length > 0)
                    {
                        objEway.eway_bill_valid_date = eway_bill_valid_date[0].ToString();
                    }

                    objEway.number_of_valid_days = ds.Tables["message"].Rows[0]["noValidDays"].ToString();
                    objEway.eway_bill_status = ds.Tables["message"].Rows[0]["status"].ToString();
                    objEway.userGstin = ds.Tables["message"].Rows[0]["userGstin"].ToString();
                    objEway.document_type = ds.Tables["message"].Rows[0]["docType"].ToString();
                    objEway.document_number = ds.Tables["message"].Rows[0]["docNo"].ToString();
                    objEway.document_date = ds.Tables["message"].Rows[0]["docDate"].ToString();
                    objEway.gstin_of_consignor = ds.Tables["message"].Rows[0]["fromGstin"].ToString();
                    objEway.legal_name_of_consignor = ds.Tables["message"].Rows[0]["fromTrdName"].ToString();
                    objEway.address1_of_consignor = ds.Tables["message"].Rows[0]["fromAddr1"].ToString();
                    objEway.address2_of_consignor = ds.Tables["message"].Rows[0]["fromAddr2"].ToString();
                    objEway.place_of_consignor = ds.Tables["message"].Rows[0]["fromPlace"].ToString();
                    objEway.pincode_of_consignor = ds.Tables["message"].Rows[0]["fromPincode"].ToString();
                    objEway.state_of_consignor = ds.Tables["message"].Rows[0]["fromStateCode"].ToString();
                    objEway.actual_from_state_name = ds.Tables["message"].Rows[0]["actFromStateCode"].ToString();
                    objEway.gstin_of_consignee = ds.Tables["message"].Rows[0]["toGstin"].ToString();
                    objEway.legal_name_of_consignee = ds.Tables["message"].Rows[0]["toTrdName"].ToString();
                    objEway.address1_of_consignee = ds.Tables["message"].Rows[0]["toAddr1"].ToString();
                    objEway.address2_of_consignee = ds.Tables["message"].Rows[0]["toAddr2"].ToString();
                    objEway.place_of_consignee = ds.Tables["message"].Rows[0]["toPlace"].ToString();
                    objEway.pincode_of_consignee = ds.Tables["message"].Rows[0]["toPincode"].ToString();
                    objEway.state_of_supply = ds.Tables["message"].Rows[0]["state_of_supply"].ToString();
                    objEway.actual_to_state_name = ds.Tables["message"].Rows[0]["actToStateCode"].ToString();
                    objEway.total_invoice_value = ds.Tables["message"].Rows[0]["totInvValue"].ToString();
                }
                if (ds.Tables["VehiclListDetails"].Rows.Count > 0)
                {
                    objEway.vehicle_number = ds.Tables["VehiclListDetails"].Rows[0]["vehicleNo"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return objEway;
        }
        public IEnumerable<DocketPackages> GetPackagesByDocketId(
             long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketPackages>("Usp_Docket_GetPackagesByDocketId", (object)dynamicParameters, "Docket - GetPackagesByDocketId");
        }


        public DataTable GetDocketBarcodeInfo(long docketId)
        {
            var pram = new DynamicParameters();
            pram.Add("@DocketId", docketId, DbType.Int64);
            var result = DataBaseFactory.QuerySP<DocketBarcodeInfo>("Usp_Docket_GetDocketBarcodeInfo", pram, module: "Docket Master - GetDocketBarcodeInfo").ToList();

            DataTable dataTable = new DataTable(typeof(DocketBarcodeInfo).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(DocketBarcodeInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (DocketBarcodeInfo item in result)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public ApiDocketResponse OrderUpload(ApiDocketRequest apiDocketRequest)
        {
            ApiDocketResponse apiDocketResponse = new ApiDocketResponse();
            ApiDocketDataResponse apiDocketDataResponse = new ApiDocketDataResponse();
            UserRepository userRepository = new UserRepository();
            LocationRepository locationRepository = new LocationRepository();
            GeneralRepository generalRepository = new GeneralRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            ProductRepository productRepository = new ProductRepository();

            var objUser = userRepository.GetDetailByUserName((string)apiDocketRequest.UserName);

            apiDocketRequest.DocumentList.DocketDateTime = apiDocketRequest.DocumentList.OrderDateTime.ToDateTime();
            apiDocketRequest.DocumentList.TransportMode = "Road";
            apiDocketRequest.DocumentList.Paybas = "TBB";
            apiDocketRequest.DocumentList.BillDetail.BillLocation = objUser.LocationCode;
            apiDocketRequest.DocumentList.BillDetail.RateType = "Flat(In RS)";

            var pram = new DynamicParameters();
            pram.Add("@Xml", XmlUtility.XmlSerializeToString(apiDocketRequest), DbType.Xml);
            var result = DataBaseFactory.QuerySP<DocumentDetail>("Usp_Docket_CheckValidationForOrderUpload", pram, module: "Docket - CheckValidationForOrderUpload").FirstOrDefault();

            //if (objUser == null)
            //{
            //    apiDocketResponse.UploadStatusCode = "401";
            //    apiDocketResponse.IsSuccess = false;
            //    apiDocketResponse.Message = "Invalid User.";
            //}
            //else if (objUser.Password != apiDocketRequest.Password)
            //{
            //    apiDocketResponse.UploadStatusCode = "401";
            //    apiDocketResponse.IsSuccess = false;
            //    apiDocketResponse.Message = "Invalid Password.";
            //}
            if (apiDocketRequest.DocumentList.DocketDateTime.Year == 1)
            {
                apiDocketResponse.UploadStatusCode = "401";
                apiDocketResponse.IsSuccess = false;
                apiDocketResponse.Message = "Invalid Order Date.";
            }
            else if (result.UploadStatus != "Uploaded")
            {
                apiDocketResponse.UploadStatusCode = "401";
                apiDocketResponse.IsSuccess = false;
                apiDocketResponse.Message = result.UploadStatus;
            }
            else
            {
                var objConsignor = customerRepository.GetDetailByName(apiDocketRequest.DocumentList.ConsignorName);
                if (objConsignor != null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = objConsignor.CustomerId;
                }
                else if (objConsignor == null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = 1;
                }

                var objConsignee = customerRepository.GetDetailByName(apiDocketRequest.DocumentList.ConsigneeName);
                if (objConsignee != null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = objConsignee.CustomerId;
                }
                else if (objConsignee == null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = 1;
                }

                int invoiceId = 1;
                foreach (DocketInvoice invoice in apiDocketRequest.DocumentList.InvoiceList)
                {
                    invoice.InvoiceId = invoiceId;
                    invoice.InvoiceDate = apiDocketRequest.DocumentList.DocketDateTime;
                    int partId = 1;
                    foreach (var part in invoice.PartList)
                    {
                        //var objProduct = productRepository.IsPartCodeExistByPartName(part.PartName, apiDocketRequest.DocumentList.ConsignorId, apiDocketRequest.DocumentList.ConsigneeId, objUser.CompanyId);
                        //if (objProduct == null)
                        //{
                        //    apiDocketResponse.UploadStatusCode = "401";
                        //    apiDocketResponse.IsSuccess = false;
                        //    apiDocketResponse.Message = "Invalid Part Code";
                        //    break;
                        //}
                        //else if (objProduct.ProductId != 0)
                        //{
                        //    part.InvoiceId = invoice.InvoiceId;
                        //    part.PartId = objProduct.ProductId;
                        //}

                        part.InvoiceId = invoice.InvoiceId;
                        part.PartId = partId;
                        partId = partId + 1;
                    }
                    invoiceId = invoiceId + 1;
                }

                if (apiDocketResponse.UploadStatusCode != "401")
                {
                    apiDocketRequest.DocumentList.PaybasId = result.PaybasId;
                    apiDocketRequest.DocumentList.Edd = apiDocketRequest.DocumentList.OrderDateTime.ToDateTime();
                    apiDocketRequest.DocumentList.FromLocationId = result.FromLocationId;
                    apiDocketRequest.DocumentList.ToLocationId = result.ToLocationId;
                    apiDocketRequest.DocumentList.ConsignorCityId = result.ConsignorCityId;
                    apiDocketRequest.DocumentList.ConsigneeCityId = result.ConsigneeCityId;
                    apiDocketRequest.DocumentList.TransportModeId = result.TransportModeId;
                    apiDocketRequest.DocumentList.FromCity = apiDocketRequest.DocumentList.FromCity;
                    apiDocketRequest.DocumentList.ToCity = apiDocketRequest.DocumentList.ToCity;
                    apiDocketRequest.DocumentList.FromCityId = result.FromCityId;
                    apiDocketRequest.DocumentList.ToCityId = result.ToCityId;
                    apiDocketRequest.DocumentList.BillDetail.BillLocationId = result.BillLocationId;
                    apiDocketRequest.DocumentList.BillDetail.RateTypeId = result.RateTypeId;


                    if (apiDocketRequest.DocumentList.PaybasId == 1)
                    {
                        apiDocketRequest.DocumentList.ContractId = 1;
                    }
                    else if (apiDocketRequest.DocumentList.PaybasId == 2)
                    {
                        apiDocketRequest.DocumentList.ContractId = 2;
                    }
                    else if (apiDocketRequest.DocumentList.PaybasId == 3)
                    {
                        apiDocketRequest.DocumentList.ContractId = 3;
                    }
                    else if (apiDocketRequest.DocumentList.PaybasId == 4)
                    {
                        apiDocketRequest.DocumentList.ContractId = 4;
                    }

                    //if (apiDocketRequest.DocumentList.FromLocationId == apiDocketRequest.DocumentList.ToLocationId)
                    //{
                    //    apiDocketRequest.DocumentList.IsLocal = true;
                    //}
                    //else
                    //{
                    //    apiDocketRequest.DocumentList.IsLocal = false;
                    //}
                    apiDocketRequest.DocumentList.IsLocal = false;
                    apiDocketRequest.DocumentList.DocketType = "M";
                    apiDocketRequest.DocumentList.DocketNo = apiDocketRequest.DocumentList.OrderNo;
                    apiDocketRequest.OperationType = "B";
                    apiDocketRequest.DocumentList.CustomerId = objUser.UserTypeMapId;
                    apiDocketRequest.DocumentList.TransportMode = "ROAD";
                    apiDocketRequest.DocumentList.BusinessTypeId = 1;
                    apiDocketRequest.DocumentList.ServiceTypeId = 1;
                    apiDocketRequest.DocumentList.Packages = Convert.ToInt16(apiDocketRequest.DocumentList.InvoiceList.Sum(i => i.Packages));
                    apiDocketRequest.DocumentList.ActualWeight = Convert.ToInt16(apiDocketRequest.DocumentList.InvoiceList.Sum(i => i.ActualWeight));
                    apiDocketRequest.DocumentList.ChargedWeight = Convert.ToInt16(apiDocketRequest.DocumentList.InvoiceList.Sum(i => i.ChargedWeight));
                    apiDocketRequest.DocumentList.EntryDate = DateTime.Now;
                    apiDocketRequest.DocumentList.EntryBy = objUser.UserId;
                    apiDocketRequest.DocumentList.CompanyId = objUser.CompanyId;

                    objUser.UserName = apiDocketRequest.UserName;
                    //objUser.Password = apiDocketRequest.Password;
                    apiDocketRequest.OperationType = "B";

                    apiDocketRequest.DocumentList.PrivateMark = "NA";
                    apiDocketRequest.DocumentList.Remarks = "NA";


                    apiDocketRequest.DocumentList.BillDetail.Freight = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.FreightRate = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.IGST = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.SGST = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.CGST = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.UGST = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.SubTotal = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.TaxTotal = Convert.ToDecimal(0);
                    apiDocketRequest.DocumentList.BillDetail.GrandTotal = Convert.ToDecimal(0);


                    var pram1 = new DynamicParameters();
                    string xml = XmlUtility.XmlSerializeToString(apiDocketRequest);
                    xml = xml.Replace("ApiDocketRequest", "Docket");
                    xml = xml.Replace("<DocumentList>", "");
                    xml = xml.Replace("</DocumentList>", "");
                    xml = xml.Replace("<BillDetail>", "");
                    xml = xml.Replace("</BillDetail>", "");
                    pram1.Add("@XmlDocket", xml, DbType.Xml);

                    Response obj = new Response();
                    obj = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", pram1, module: "Docket Insert").FirstOrDefault();
                    if (obj.IsSuccessfull)
                    {
                        apiDocketResponse.UploadStatusCode = "200";
                        apiDocketResponse.IsSuccess = true;
                        apiDocketResponse.Message = "Data Uploaded Successfully";
                        apiDocketDataResponse.IsSuccess = true;
                        apiDocketDataResponse.ReasonCode = 100;
                        apiDocketDataResponse.Message = "Order Uploaded Successfully";
                        apiDocketDataResponse.DocketNo = obj.DocumentNo;
                        apiDocketDataResponse.OrderNo = apiDocketRequest.DocumentList.OrderNo;
                        apiDocketResponse.Documents = apiDocketDataResponse;
                    }
                    else
                    {
                        apiDocketResponse.UploadStatusCode = "401";
                        apiDocketResponse.IsSuccess = false;
                        apiDocketResponse.Message = "Data Not Uploaded Successfully";
                        apiDocketDataResponse.IsSuccess = false;
                        apiDocketDataResponse.Message = "Lsp Not Mapped";
                        apiDocketDataResponse.ReasonCode = 103;
                        apiDocketDataResponse.DocketNo = obj.DocumentNo;
                        apiDocketDataResponse.OrderNo = apiDocketRequest.DocumentList.OrderNo;
                        apiDocketResponse.Documents = apiDocketDataResponse;
                    }
                }

            }
            return apiDocketResponse;
        }


        public ResponseResult ApiOrderUploadAdityaBirlaEssential(PickUpDetailRequest pickUpDetailRequest)
        {

            ResponseResult responseResult = new ResponseResult();
            ApiDocketNewResponse apiDocketNewResponse = new ApiDocketNewResponse();
            UserRepository userRepository = new UserRepository();
            LocationRepository locationRepository = new LocationRepository();
            GeneralRepository generalRepository = new GeneralRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            ProductRepository productRepository = new ProductRepository();
            List<ApiDocketNewResponse> apiDocketNewResponses = new List<ApiDocketNewResponse>();

            short userId = 1;
            //var user = userRepository.GetDetailById(userId);
            var objUser = userRepository.GetDetailByUserName((string)pickUpDetailRequest.UserName);

            foreach (var item in pickUpDetailRequest.PickUpDetails)
            {
                ApiDocketRequest apiDocketRequest = new ApiDocketRequest();
                DocumentDetail documentDetail = new DocumentDetail();
                apiDocketRequest.UserName = pickUpDetailRequest.UserName;
                documentDetail.DocketDateTime = item.DocketDate;
                documentDetail.TransportMode = item.TransportMode;
                documentDetail.Paybas = "TBB";
                documentDetail.BillDetail.BillLocation = objUser.LocationCode;
                documentDetail.BillDetail.RateType = "Flat(In RS)";
                documentDetail.FromLocation = item.Origin;
                documentDetail.ToLocation = item.Destination;
                documentDetail.ConsignorCity = item.ConsignorCity;
                documentDetail.ConsigneeCity = item.ConsigneeCity;
                documentDetail.FromCity = item.ConsignorCity;
                documentDetail.ToCity = item.ConsigneeCity;
                documentDetail.OrderNo = item.DocketNo;
                documentDetail.CustomerReferenceNo = item.RefNo;
                documentDetail.ProductType = item.ProductDescription;
                documentDetail.ProductValue = item.ProductValue;
                documentDetail.ContactPersonName = item.ContactPersonName;
                documentDetail.ContactPersonMobileNo = item.MobileNo;
                documentDetail.ChargedWeight = item.ShipmentWeight;
                documentDetail.Packages = (short)item.NoOfCartons;
                documentDetail.DocketDateTime = item.DocketDate;
                apiDocketRequest.DocumentList = documentDetail;

                var objConsignor = customerRepository.GetDetailByName(item.ConsignorName);
                apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                if (objConsignor != null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = objConsignor.CustomerId;
                    apiDocketRequest.DocumentList.CustomerId = objConsignor.CustomerId;

                }
                else if (objConsignor == null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = 1;
                    apiDocketRequest.DocumentList.CustomerId = 0;
                }

                var objConsignee = customerRepository.GetDetailByName(item.ConsigneeName);
                apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                if (objConsignee != null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = objConsignee.CustomerId;
                }
                else if (objConsignee == null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = 1;
                }


                var pram = new DynamicParameters();
                pram.Add("@Xml", XmlUtility.XmlSerializeToString(apiDocketRequest), DbType.Xml);
                var result = DataBaseFactory.QuerySP<DocumentDetail>("Usp_Docket_CheckValidation_OrderUploadAdityaBirla", pram, module: "Docket - CheckValidation_OrderUploadPuma").FirstOrDefault();

                string statusCode = "";
                if (item.DocketDate.Year == 1)
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "Docket Date Does not exist or not in proper format." });
                else if (result != null && result.UploadStatus != "Uploaded")
                {
                    statusCode = "401";
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "401", Status = result.UploadStatus });
                }
                else
                {
                    int invoiceId = 1;
                    foreach (DocketInvoice invoice in item.InvoiceDetails)
                    {
                        invoice.InvoiceId = invoiceId;
                        invoice.InvoiceDate = item.DocketDate;
                        invoice.EwayBillNo = invoice.EwayBill;
                        invoice.EwayBillIssueDate = invoice.EwayBillDate;
                        invoice.EwayBillExpiryDate = invoice.EwayExpDate;
                        invoice.ActualWeight = invoice.ActualWeight;
                        invoice.ChargedWeight = invoice.ChargedWeight;

                        int boxId = 1;
                        foreach (var box in item.BoxDetails)
                        {
                            if (invoiceId == boxId)
                            {
                                invoice.Length = box.Length;
                                invoice.Breadth = box.Breadth;
                                invoice.Height = box.Height;
                                invoice.Packages = box.Pkgs;
                            }
                            boxId = boxId + 1;
                        }
                        invoiceId = invoiceId + 1;
                    }
                    apiDocketRequest.DocumentList.InvoiceList = item.InvoiceDetails;
                    apiDocketRequest.DocumentList.InvoiceCartonList = item.DocketInvoiceCartons;


                    if (statusCode != "401")
                    {
                        apiDocketRequest.DocumentList.PaybasId = 2;
                        apiDocketRequest.DocumentList.Edd = item.DocketDate;
                        apiDocketRequest.DocumentList.FromLocationId = result.FromLocationId;
                        apiDocketRequest.DocumentList.ToLocationId = result.ToLocationId;
                        apiDocketRequest.DocumentList.ConsignorCityId = result.ConsignorCityId;
                        apiDocketRequest.DocumentList.ConsigneeCityId = result.ConsigneeCityId;
                        apiDocketRequest.DocumentList.TransportModeId = result.TransportModeId;
                        apiDocketRequest.DocumentList.FromCity = item.ConsignorCity;
                        apiDocketRequest.DocumentList.ToCity = item.ConsigneeCity;
                        apiDocketRequest.DocumentList.FromCityId = result.FromCityId;
                        apiDocketRequest.DocumentList.ToCityId = result.ToCityId;

                        if (apiDocketRequest.DocumentList.PaybasId == 1)
                        {
                            apiDocketRequest.DocumentList.ContractId = 1;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 2)
                        {
                            apiDocketRequest.DocumentList.ContractId = 2;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 3)
                        {
                            apiDocketRequest.DocumentList.ContractId = 3;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 4)
                        {
                            apiDocketRequest.DocumentList.ContractId = 4;
                        }

                        apiDocketRequest.DocumentList.IsLocal = false;
                        apiDocketRequest.DocumentList.DocketType = "M";
                        apiDocketRequest.DocumentList.DocketNo = item.DocketNo;
                        apiDocketRequest.OperationType = "B";
                       // apiDocketRequest.DocumentList.CustomerId = objUser.UserTypeMapId;
                        apiDocketRequest.DocumentList.TransportMode = item.TransportMode;
                        apiDocketRequest.DocumentList.BusinessTypeId = 1;
                        apiDocketRequest.DocumentList.ServiceTypeId = 1;
                        apiDocketRequest.DocumentList.Packages = Convert.ToInt16(item.InvoiceDetails.Sum(i => i.Packages));
                        apiDocketRequest.DocumentList.ActualWeight = 1;
                        apiDocketRequest.DocumentList.ChargedWeight = item.ShipmentWeight;
                        apiDocketRequest.DocumentList.EntryDate = DateTime.Now;
                        apiDocketRequest.DocumentList.EntryBy = objUser.UserId;
                        apiDocketRequest.DocumentList.CompanyId = 1;
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;

                        objUser.UserName = apiDocketRequest.UserName;
                        apiDocketRequest.DocumentList.PrivateMark = "NA";
                        apiDocketRequest.DocumentList.Remarks = "NA";

                        var objContractCustomer = customerRepository.GetDetailByName(item.ConsignorName);
                        if (objContractCustomer != null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = objContractCustomer.CustomerId;
                        }
                        else if (objContractCustomer == null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = 1;
                        }
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;
                        apiDocketRequest.DocumentList.ContactPersonName = item.ContactPersonName;
                        apiDocketRequest.DocumentList.ContactPersonMobileNo = item.MobileNo;
                        apiDocketRequest.DocumentList.ContactPersonTelephoneNo = item.TelephoneNo;
                        apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                        apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                        apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                        apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                        apiDocketRequest.DocumentList.ConsignorPincode = item.ConsignorPin;
                        apiDocketRequest.DocumentList.ConsigneePincode = item.ConsigneePin;
                        apiDocketRequest.DocumentList.ProductTypeId = result.ProductTypeId;
                        apiDocketRequest.DocumentList.ProductValue = item.ProductValue;


                        ApiBillDetail objBillDetail = new ApiBillDetail();

                        objBillDetail.Freight = Convert.ToDecimal(0);
                        objBillDetail.FreightRate = Convert.ToDecimal(0);
                        objBillDetail.IGST = Convert.ToDecimal(0);
                        objBillDetail.SGST = Convert.ToDecimal(0);
                        objBillDetail.CGST = Convert.ToDecimal(0);
                        objBillDetail.UGST = Convert.ToDecimal(0);
                        objBillDetail.SubTotal = Convert.ToDecimal(0);
                        objBillDetail.TaxTotal = Convert.ToDecimal(0);
                        objBillDetail.GrandTotal = Convert.ToDecimal(0);
                        apiDocketRequest.DocumentList.BillDetail = objBillDetail;
                        apiDocketRequest.DocumentList.BillDetail.BillLocationId = result.BillLocationId;
                        apiDocketRequest.DocumentList.BillDetail.RateTypeId = result.RateTypeId;

                        var pram1 = new DynamicParameters();
                        string xml = XmlUtility.XmlSerializeToString(apiDocketRequest);
                        xml = xml.Replace("ApiDocketRequest", "Docket");
                        xml = xml.Replace("<DocumentList>", "");
                        xml = xml.Replace("</DocumentList>", "");
                        xml = xml.Replace("<BillDetail>", "");
                        xml = xml.Replace("</BillDetail>", "");
                        pram1.Add("@XmlDocket", xml, DbType.Xml);

                        Response obj = new Response();
                        obj = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", pram1, module: "Docket Insert").FirstOrDefault();
                        if (obj.IsSuccessfull)
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "200", Status = "Data Saved Successfully." });
                        }
                        else
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "API Key validation FAILED" });
                        }
                    }

                }

            }
            responseResult.BookingDetail = apiDocketNewResponses;
            return responseResult;
        }

        public ResponseResult ApiOrderUploadPumaDarcl(PickUpDetailRequest pickUpDetailRequest)
        {

            ResponseResult responseResult = new ResponseResult();
            ApiDocketNewResponse apiDocketNewResponse = new ApiDocketNewResponse();
            UserRepository userRepository = new UserRepository();
            LocationRepository locationRepository = new LocationRepository();
            GeneralRepository generalRepository = new GeneralRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            ProductRepository productRepository = new ProductRepository();
            List<ApiDocketNewResponse> apiDocketNewResponses = new List<ApiDocketNewResponse>();

            short userId = 1;
            //var user = userRepository.GetDetailById(userId);
            var objUser = userRepository.GetDetailByUserName((string)pickUpDetailRequest.UserName);

            foreach (var item in pickUpDetailRequest.PickUpDetails)
            {
                ApiDocketRequest apiDocketRequest = new ApiDocketRequest();
                DocumentDetail documentDetail = new DocumentDetail();
                apiDocketRequest.UserName = pickUpDetailRequest.UserName;
                documentDetail.DocketDateTime = item.DocketDate;
                documentDetail.TransportMode = item.TransportMode;
                documentDetail.Paybas = "TBB";
                documentDetail.BillDetail.BillLocation = objUser.LocationCode;
                documentDetail.BillDetail.RateType = "Flat(In RS)";
                documentDetail.FromLocation = item.Origin;
                documentDetail.ToLocation = item.Destination;
                documentDetail.ConsignorCity = item.ConsignorCity;
                documentDetail.ConsigneeCity = item.ConsigneeCity;
                documentDetail.FromCity = item.ConsignorCity;
                documentDetail.ToCity = item.ConsigneeCity;
                documentDetail.OrderNo = item.DocketNo;
                documentDetail.CustomerReferenceNo = item.RefNo;
                documentDetail.ProductType = item.ProductDescription;
                documentDetail.ProductValue = item.ProductValue;
                documentDetail.ContactPersonName = item.ContactPersonName;
                documentDetail.ContactPersonMobileNo = item.MobileNo;
                documentDetail.ChargedWeight = item.ShipmentWeight;
                documentDetail.Packages = (short)item.NoOfCartons;
                documentDetail.DocketDateTime = item.DocketDate;
                documentDetail.ConsignorPincode = item.ConsignorPin;
                documentDetail.ConsigneePincode = item.ConsigneePin;


                apiDocketRequest.DocumentList = documentDetail;

                var objConsignor = customerRepository.GetDetailByName(item.ConsignorName);
                apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                if (objConsignor != null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = objConsignor.CustomerId;
                }
                else if (objConsignor == null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = 1;
                }

                var objConsignee = customerRepository.GetDetailByName(item.ConsigneeName);
                apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                if (objConsignee != null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = objConsignee.CustomerId;
                }
                else if (objConsignee == null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = 1;
                }


                var pram = new DynamicParameters();
                pram.Add("@Xml", XmlUtility.XmlSerializeToString(apiDocketRequest), DbType.Xml);
                var result = DataBaseFactory.QuerySP<DocumentDetail>("Usp_Docket_CheckValidation_OrderUploadPuma", pram, module: "Docket - CheckValidation_OrderUploadPuma").FirstOrDefault();

                string statusCode = "";
                if (item.DocketDate.Year == 1)
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "Docket Date Does not exist or not in proper format." });
                else if (result != null && result.UploadStatus != "Uploaded")
                {
                    statusCode = "401";
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "401", Status = result.UploadStatus });
                }
                else
                {
                    List<DocketInvoice> InvoiceList = new List<DocketInvoice>();

                    int invoiceId = 1;
                    foreach (DocketInvoice invoice in item.InvoiceDetails)
                    {
                        int boxId = 1;
                        foreach (var box in item.BoxDetails)
                        {
                            DocketInvoice docketInvoice = new DocketInvoice();

                            if (boxId == 1)
                            {

                                invoice.InvoiceId = boxId;
                                invoice.InvoiceDate = item.DocketDate;

                                docketInvoice.InvoiceId = invoice.InvoiceId;
                                docketInvoice.InvoiceNo = invoice.InvoiceNo;
                                docketInvoice.InvoiceDate = invoice.InvoiceDate;
                                docketInvoice.InvoiceAmount = invoice.InvoiceValue;
                                docketInvoice.EwayBillNo = invoice.EwayBill;
                                docketInvoice.EwayBillIssueDate = invoice.EwayBillDate;
                                docketInvoice.EwayBillExpiryDate = invoice.EwayExpDate;
                                docketInvoice.ChargedWeight = documentDetail.ChargedWeight;
                                docketInvoice.ActualWeight = documentDetail.ChargedWeight;
                                
                                docketInvoice.Length = box.Length;
                                docketInvoice.Breadth = box.Breadth;
                                docketInvoice.Height = box.Height;
                                docketInvoice.Packages = box.Pkgs;
                            }
                            else
                            {
                                docketInvoice.InvoiceId = boxId;
                                docketInvoice.InvoiceNo = invoice.InvoiceNo+"-"+ (boxId-1).ToString();
                                docketInvoice.InvoiceDate = invoice.InvoiceDate;
                                docketInvoice.InvoiceAmount = 0;
                                docketInvoice.EwayBillNo = "";
                                docketInvoice.EwayBillIssueDate = null;
                                docketInvoice.EwayBillExpiryDate = null;

                                docketInvoice.Length = box.Length;
                                docketInvoice.Breadth = box.Breadth;
                                docketInvoice.Height = box.Height;
                                docketInvoice.Packages = box.Pkgs;
                            }

                            InvoiceList.Add(docketInvoice);
                            boxId = boxId + 1;
                        }

                        invoiceId = invoiceId + 1;
                    }
                    apiDocketRequest.DocumentList.InvoiceList = InvoiceList;

                    if (statusCode != "401")
                    {
                        apiDocketRequest.DocumentList.PaybasId = 2;
                        apiDocketRequest.DocumentList.Edd = item.DocketDate;
                        apiDocketRequest.DocumentList.FromLocationId = result.FromLocationId;
                        apiDocketRequest.DocumentList.FromLocation = result.FromLocation;

                        apiDocketRequest.DocumentList.ToLocationId = result.ToLocationId;
                        apiDocketRequest.DocumentList.ToLocation = result.ToLocation;

                        apiDocketRequest.DocumentList.ConsignorCityId = result.ConsignorCityId;
                        apiDocketRequest.DocumentList.ConsignorCity = result.ConsignorCity;
                        apiDocketRequest.DocumentList.ConsigneeCityId = result.ConsigneeCityId;
                        apiDocketRequest.DocumentList.ConsigneeCity = result.ConsigneeCity;

                        apiDocketRequest.DocumentList.TransportModeId = result.TransportModeId;
                        apiDocketRequest.DocumentList.FromCity =result.FromCity;// item.ConsignorCity;
                        apiDocketRequest.DocumentList.ToCity = result.ToCity;// item.ConsigneeCity;
                        apiDocketRequest.DocumentList.FromCityId = result.FromCityId;
                        apiDocketRequest.DocumentList.ToCityId = result.ToCityId;
                        documentDetail.PincodeId =  result.PincodeId;

                        if (apiDocketRequest.DocumentList.PaybasId == 1)
                        {
                            apiDocketRequest.DocumentList.ContractId = 1;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 2)
                        {
                            apiDocketRequest.DocumentList.ContractId = 2;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 3)
                        {
                            apiDocketRequest.DocumentList.ContractId = 3;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 4)
                        {
                            apiDocketRequest.DocumentList.ContractId = 4;
                        }

                        apiDocketRequest.DocumentList.IsLocal = false;
                        apiDocketRequest.DocumentList.DocketType = "M";
                        apiDocketRequest.DocumentList.DocketNo = item.DocketNo;
                        apiDocketRequest.OperationType = "B";
                        apiDocketRequest.DocumentList.CustomerId = objUser.UserTypeMapId;
                        apiDocketRequest.DocumentList.TransportMode = item.TransportMode;
                        apiDocketRequest.DocumentList.BusinessTypeId = 1;
                        apiDocketRequest.DocumentList.ServiceTypeId = 1;
                        apiDocketRequest.DocumentList.Packages = Convert.ToInt16(apiDocketRequest.DocumentList.InvoiceList.Sum(i => i.Packages));
                        apiDocketRequest.DocumentList.ActualWeight = item.ShipmentWeight;
                        apiDocketRequest.DocumentList.ChargedWeight = item.ShipmentWeight;
                        apiDocketRequest.DocumentList.EntryDate = DateTime.Now;
                        apiDocketRequest.DocumentList.EntryBy = objUser.UserId;
                        apiDocketRequest.DocumentList.CompanyId = objUser.CompanyId;
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;

                        objUser.UserName = apiDocketRequest.UserName;
                        apiDocketRequest.DocumentList.PrivateMark = "NA";
                        apiDocketRequest.DocumentList.Remarks = "NA";

                        var objContractCustomer = customerRepository.GetDetailByName("PUMA SPORTS INDIA PVT LTD");
                        if (objContractCustomer != null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = objContractCustomer.CustomerId;
                        }
                        else if (objContractCustomer == null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = 1;
                        }
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;
                        apiDocketRequest.DocumentList.ContactPersonName = item.ContactPersonName;
                        apiDocketRequest.DocumentList.ContactPersonMobileNo = item.MobileNo;
                        apiDocketRequest.DocumentList.ContactPersonTelephoneNo = item.TelephoneNo;
                        apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                        apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                        apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                        apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                        apiDocketRequest.DocumentList.ConsignorPincode = item.ConsignorPin;
                        apiDocketRequest.DocumentList.ConsigneePincode = item.ConsigneePin;
                        apiDocketRequest.DocumentList.ProductTypeId = result.ProductTypeId;
                        apiDocketRequest.DocumentList.ProductValue = item.ProductValue;
                        apiDocketRequest.DocumentList.IsVolumetric = true;
                        apiDocketRequest.DocumentList.CftRatio = 6;

                        ApiBillDetail objBillDetail = new ApiBillDetail();

                        objBillDetail.Freight = Convert.ToDecimal(0);
                        objBillDetail.FreightRate = Convert.ToDecimal(0);
                        objBillDetail.IGST = Convert.ToDecimal(0);
                        objBillDetail.SGST = Convert.ToDecimal(0);
                        objBillDetail.CGST = Convert.ToDecimal(0);
                        objBillDetail.UGST = Convert.ToDecimal(0);
                        objBillDetail.SubTotal = Convert.ToDecimal(0);
                        objBillDetail.TaxTotal = Convert.ToDecimal(0);
                        objBillDetail.GrandTotal = Convert.ToDecimal(0);
                        apiDocketRequest.DocumentList.BillDetail = objBillDetail;
                        apiDocketRequest.DocumentList.BillDetail.BillLocationId = result.BillLocationId;
                        apiDocketRequest.DocumentList.BillDetail.RateTypeId = result.RateTypeId;

                        var pram1 = new DynamicParameters();
                        string xml = XmlUtility.XmlSerializeToString(apiDocketRequest);
                        xml = xml.Replace("ApiDocketRequest", "Docket");
                        xml = xml.Replace("<DocumentList>", "");
                        xml = xml.Replace("</DocumentList>", "");
                        xml = xml.Replace("<BillDetail>", "");
                        xml = xml.Replace("</BillDetail>", "");
                        pram1.Add("@XmlDocket", xml, DbType.Xml);

                        Response obj = new Response();
                        obj = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", pram1, module: "Docket Insert").FirstOrDefault();
                        if (obj.IsSuccessfull)
                        {
                            Response docketresponse = CreatePktBarCode(obj.DocumentId, "Docket");
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "200", Status = "Data Saved Successfully." });
                        }
                        else
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "API Key validation FAILED" });
                        }
                    }

                }

            }
            responseResult.BookingDetail = apiDocketNewResponses;
            return responseResult;
        }


        public ResponseResult ApiOrderUploadPumaEssential(PickUpDetailRequest pickUpDetailRequest)
        {
            
            ResponseResult responseResult = new ResponseResult();
            ApiDocketNewResponse apiDocketNewResponse = new ApiDocketNewResponse();
            UserRepository userRepository = new UserRepository();
            LocationRepository locationRepository = new LocationRepository();
            GeneralRepository generalRepository = new GeneralRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            ProductRepository productRepository = new ProductRepository();
            List<ApiDocketNewResponse> apiDocketNewResponses = new List<ApiDocketNewResponse>();

            short userId = 1;
            //var user = userRepository.GetDetailById(userId);
            var objUser = userRepository.GetDetailByUserName((string)pickUpDetailRequest.UserName);
           
            foreach (var item in pickUpDetailRequest.PickUpDetails)
            {
                ApiDocketRequest apiDocketRequest = new ApiDocketRequest();
                DocumentDetail documentDetail = new DocumentDetail();
                apiDocketRequest.UserName = pickUpDetailRequest.UserName;
                documentDetail.DocketDateTime = item.DocketDate;
                documentDetail.TransportMode = item.TransportMode;
                documentDetail.Paybas = "TBB";
                documentDetail.BillDetail.BillLocation = objUser.LocationCode;
                documentDetail.BillDetail.RateType = "Flat(In RS)";
                documentDetail.FromLocation = item.Origin;
                documentDetail.ToLocation = item.Destination;
                documentDetail.ConsignorCity = item.ConsignorCity;
                documentDetail.ConsigneeCity = item.ConsigneeCity;
                documentDetail.FromCity = item.ConsignorCity;
                documentDetail.ToCity = item.ConsigneeCity;
                documentDetail.OrderNo = item.DocketNo;
                documentDetail.CustomerReferenceNo = item.RefNo;
                documentDetail.ProductType = item.ProductDescription;
                documentDetail.ProductValue = item.ProductValue;
                documentDetail.ContactPersonName = item.ContactPersonName;
                documentDetail.ContactPersonMobileNo = item.MobileNo;
                documentDetail.ChargedWeight = item.ShipmentWeight;
                documentDetail.Packages = (short)item.NoOfCartons;
                documentDetail.DocketDateTime = item.DocketDate;
                documentDetail.ConsignorPincode = item.ConsignorPin;
                documentDetail.ConsigneePincode = item.ConsigneePin;

                apiDocketRequest.DocumentList = documentDetail;

                var objConsignor = customerRepository.GetDetailByName(item.ConsignorName);
                apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                if (objConsignor != null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = objConsignor.CustomerId;
                }
                else if (objConsignor == null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = 1;
                }

                var objConsignee = customerRepository.GetDetailByName(item.ConsigneeName);
                apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                if (objConsignee != null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = objConsignee.CustomerId;
                }
                else if (objConsignee == null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = 1;
                }

                


                var pram = new DynamicParameters();
                pram.Add("@Xml", XmlUtility.XmlSerializeToString(apiDocketRequest), DbType.Xml);
                var result = DataBaseFactory.QuerySP<DocumentDetail>("Usp_Docket_CheckValidation_OrderUploadPuma", pram, module: "Docket - CheckValidation_OrderUploadPuma").FirstOrDefault();

                string statusCode = "";
                if (item.DocketDate.Year == 1)
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "Docket Date Does not exist or not in proper format." });
                else if (result != null && result.UploadStatus != "Uploaded")
                {
                    statusCode = "401";
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "401", Status = result.UploadStatus });
                }
                else
                {

                    List<DocketInvoice> InvoiceList = new List<DocketInvoice>();

                    int invoiceId = 1;
                    foreach (DocketInvoice invoice in item.InvoiceDetails)
                    {
                        int boxId = 1;
                        foreach (var box in item.BoxDetails)
                        {
                            DocketInvoice docketInvoice = new DocketInvoice();

                            if (boxId == 1)
                            {

                                invoice.InvoiceId = boxId;
                                invoice.InvoiceDate = item.DocketDate;

                                docketInvoice.InvoiceId = invoice.InvoiceId;
                                docketInvoice.InvoiceNo = invoice.InvoiceNo;
                                docketInvoice.InvoiceDate = invoice.InvoiceDate;
                                docketInvoice.InvoiceAmount = invoice.InvoiceValue;
                                docketInvoice.EwayBillNo = invoice.EwayBill;
                                docketInvoice.EwayBillIssueDate = invoice.EwayBillDate;
                                docketInvoice.EwayBillExpiryDate = invoice.EwayExpDate;

                                docketInvoice.ChargedWeight = documentDetail.ChargedWeight;
                                docketInvoice.ActualWeight = documentDetail.ChargedWeight;

                                docketInvoice.Length = box.Length;
                                docketInvoice.Breadth = box.Breadth;
                                docketInvoice.Height = box.Height;
                                docketInvoice.Packages = box.Pkgs;
                            }
                            else
                            {
                                docketInvoice.InvoiceId = boxId;
                                docketInvoice.InvoiceNo = invoice.InvoiceNo+"-"+ (boxId-1).ToString();
                                docketInvoice.InvoiceDate = invoice.InvoiceDate;
                                docketInvoice.InvoiceAmount = 0;
                                docketInvoice.EwayBillNo = "";
                                docketInvoice.EwayBillIssueDate = null;
                                docketInvoice.EwayBillExpiryDate = null;

                                docketInvoice.Length = box.Length;
                                docketInvoice.Breadth = box.Breadth;
                                docketInvoice.Height = box.Height;
                                docketInvoice.Packages = box.Pkgs;
                            }

                            InvoiceList.Add(docketInvoice);
                            boxId = boxId + 1;
                        }

                        invoiceId = invoiceId + 1;
                    }
                    apiDocketRequest.DocumentList.InvoiceList = InvoiceList;

                    if (statusCode != "401")
                    {
                        apiDocketRequest.DocumentList.PaybasId = 2;
                        apiDocketRequest.DocumentList.Edd = item.DocketDate;
                        apiDocketRequest.DocumentList.FromLocationId = result.FromLocationId;
                     //   apiDocketRequest.DocumentList.FromLocation = result.FromLocation;

                        apiDocketRequest.DocumentList.ToLocationId = result.ToLocationId;
                       // apiDocketRequest.DocumentList.ToLocation = result.ToLocation;

                        apiDocketRequest.DocumentList.ConsignorCityId = result.ConsignorCityId;
                        //apiDocketRequest.DocumentList.ConsignorCity = result.ConsignorCity;
                        apiDocketRequest.DocumentList.ConsigneeCityId = result.ConsigneeCityId;
                        //apiDocketRequest.DocumentList.ConsigneeCity = result.ConsigneeCity;

                        apiDocketRequest.DocumentList.TransportModeId = result.TransportModeId;
                        apiDocketRequest.DocumentList.FromCity = item.ConsignorCity;
                        apiDocketRequest.DocumentList.ToCity =  item.ConsigneeCity;
                        apiDocketRequest.DocumentList.FromCityId = result.FromCityId;
                        apiDocketRequest.DocumentList.ToCityId = result.ToCityId;

                        if (apiDocketRequest.DocumentList.PaybasId == 1)
                        {
                            apiDocketRequest.DocumentList.ContractId = 1;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 2)
                        {
                            apiDocketRequest.DocumentList.ContractId = 2;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 3)
                        {
                            apiDocketRequest.DocumentList.ContractId = 3;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 4)
                        {
                            apiDocketRequest.DocumentList.ContractId = 4;
                        }

                        apiDocketRequest.DocumentList.IsLocal = false;
                        apiDocketRequest.DocumentList.DocketType = "M";
                        apiDocketRequest.DocumentList.DocketNo = item.DocketNo;
                        apiDocketRequest.OperationType = "B";
                        apiDocketRequest.DocumentList.CustomerId = objUser.UserTypeMapId;
                        apiDocketRequest.DocumentList.TransportMode = item.TransportMode;
                        apiDocketRequest.DocumentList.BusinessTypeId = 1;
                        apiDocketRequest.DocumentList.ServiceTypeId = 1;
                        apiDocketRequest.DocumentList.Packages = Convert.ToInt16(item.InvoiceDetails.Sum(i => i.Packages));
                        apiDocketRequest.DocumentList.ActualWeight = 1;
                        apiDocketRequest.DocumentList.ChargedWeight = item.ShipmentWeight;
                        apiDocketRequest.DocumentList.EntryDate = DateTime.Now;
                        apiDocketRequest.DocumentList.EntryBy = objUser.UserId;
                        apiDocketRequest.DocumentList.CompanyId = objUser.CompanyId;
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;
                        
                        objUser.UserName = apiDocketRequest.UserName;
                        apiDocketRequest.DocumentList.PrivateMark = "NA";
                        apiDocketRequest.DocumentList.Remarks = "NA";

                        var objContractCustomer = customerRepository.GetDetailByName("PUMA SPORTS INDIA PVT LTD");
                        if (objContractCustomer != null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = objContractCustomer.CustomerId;
                        }
                        else if(objContractCustomer == null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = 1;
                        }
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;
                        apiDocketRequest.DocumentList.ContactPersonName = item.ContactPersonName;
                        apiDocketRequest.DocumentList.ContactPersonMobileNo = item.MobileNo;
                        apiDocketRequest.DocumentList.ContactPersonTelephoneNo = item.TelephoneNo;
                        apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                        apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                        apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                        apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                        apiDocketRequest.DocumentList.ConsignorPincode = item.ConsignorPin;
                        apiDocketRequest.DocumentList.ConsigneePincode = item.ConsigneePin;
                        apiDocketRequest.DocumentList.ProductTypeId = result.ProductTypeId;
                        apiDocketRequest.DocumentList.ProductValue = item.ProductValue;
                        apiDocketRequest.DocumentList.IsVolumetric = true;


                        ApiBillDetail objBillDetail = new ApiBillDetail();

                        objBillDetail.Freight = Convert.ToDecimal(0);
                        objBillDetail.FreightRate = Convert.ToDecimal(0);
                        objBillDetail.IGST = Convert.ToDecimal(0);
                        objBillDetail.SGST = Convert.ToDecimal(0);
                        objBillDetail.CGST = Convert.ToDecimal(0);
                        objBillDetail.UGST = Convert.ToDecimal(0);
                        objBillDetail.SubTotal = Convert.ToDecimal(0);
                        objBillDetail.TaxTotal = Convert.ToDecimal(0);
                        objBillDetail.GrandTotal = Convert.ToDecimal(0);
                        apiDocketRequest.DocumentList.BillDetail = objBillDetail;
                        apiDocketRequest.DocumentList.BillDetail.BillLocationId = result.BillLocationId;
                        apiDocketRequest.DocumentList.BillDetail.RateTypeId = result.RateTypeId;

                        var pram1 = new DynamicParameters();
                        string xml = XmlUtility.XmlSerializeToString(apiDocketRequest);
                        xml = xml.Replace("ApiDocketRequest", "Docket");
                        xml = xml.Replace("<DocumentList>", "");
                        xml = xml.Replace("</DocumentList>", "");
                        xml = xml.Replace("<BillDetail>", "");
                        xml = xml.Replace("</BillDetail>", "");
                        pram1.Add("@XmlDocket", xml, DbType.Xml);

                        Response obj = new Response();
                        obj = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", pram1, module: "Docket Insert").FirstOrDefault();
                        if (obj.IsSuccessfull)
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "200", Status = "Data Saved Successfully." });
                        }
                        else
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "API Key validation FAILED" });
                        }
                    }

                }

            }
            responseResult.BookingDetail = apiDocketNewResponses;
            return responseResult;
        }

        public ResponseResult ApiOrderUploadArvindEssential(PickUpDetailRequest pickUpDetailRequest)
        {

            ResponseResult responseResult = new ResponseResult();
            ApiDocketNewResponse apiDocketNewResponse = new ApiDocketNewResponse();
            UserRepository userRepository = new UserRepository();
            LocationRepository locationRepository = new LocationRepository();
            GeneralRepository generalRepository = new GeneralRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            CompanyRepository companyRepository = new CompanyRepository();
            ProductRepository productRepository = new ProductRepository();
            List<ApiDocketNewResponse> apiDocketNewResponses = new List<ApiDocketNewResponse>();

            short userId = 1;
            var user = userRepository.GetDetailById(userId);
            var objUser = userRepository.GetDetailByUserName((string)user.UserName);

            foreach (var item in pickUpDetailRequest.PickUpDetails)
            {
                ApiDocketRequest apiDocketRequest = new ApiDocketRequest();
                DocumentDetail documentDetail = new DocumentDetail();
                apiDocketRequest.UserName = user.UserName;
                documentDetail.DocketDateTime = item.DocketDate;
                documentDetail.TransportMode = item.TransportMode;
                documentDetail.Paybas = "TBB";
                documentDetail.BillDetail.BillLocation = objUser.LocationCode;
                documentDetail.BillDetail.RateType = "Flat(In RS)";
                documentDetail.FromLocation = item.Origin;
                documentDetail.ToLocation = item.Destination;
                documentDetail.ConsignorCity = item.ConsignorCity;
                documentDetail.ConsigneeCity = item.ConsigneeCity;
                documentDetail.FromCity = item.ConsignorCity;
                documentDetail.ToCity = item.ConsigneeCity;
                documentDetail.OrderNo = item.DocketNo;
                documentDetail.CustomerReferenceNo = item.RefNo;
                documentDetail.ProductType = item.ProductDescription;
                documentDetail.ProductValue = item.ProductValue;
                documentDetail.ContactPersonName = item.ContactPersonName;
                documentDetail.ContactPersonMobileNo = item.MobileNo;
                documentDetail.ChargedWeight = item.ShipmentWeight;
                documentDetail.Packages = (short)item.NoOfCartons;
                documentDetail.DocketDateTime = item.DocketDate;
                apiDocketRequest.DocumentList = documentDetail;

                var objConsignor = customerRepository.GetDetailByName(item.ConsignorName);
                apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                if (objConsignor != null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = objConsignor.CustomerId;
                }
                else if (objConsignor == null)
                {
                    apiDocketRequest.DocumentList.ConsignorId = 1;
                }

                var objConsignee = customerRepository.GetDetailByName(item.ConsigneeName);
                apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                if (objConsignee != null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = objConsignee.CustomerId;
                }
                else if (objConsignee == null)
                {
                    apiDocketRequest.DocumentList.ConsigneeId = 1;
                }




                var pram = new DynamicParameters();
                pram.Add("@Xml", XmlUtility.XmlSerializeToString(apiDocketRequest), DbType.Xml);
                var result = DataBaseFactory.QuerySP<DocumentDetail>("Usp_Docket_CheckValidation_OrderUploadArvind", pram, module: "Docket - CheckValidation_OrderUploadArvind").FirstOrDefault();

                string statusCode = "";
                if (item.DocketDate.Year == 1)
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "Docket Date Does not exist or not in proper format." });
                else if (result != null && result.UploadStatus != "Uploaded")
                {
                    statusCode = "401";
                    apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "401", Status = result.UploadStatus });
                }
                else
                {


                    int invoiceId = 1;
                    foreach (DocketInvoice invoice in item.InvoiceDetails)
                    {
                        invoice.InvoiceId = invoiceId;
                        invoice.InvoiceDate = item.DocketDate;
                        invoice.EwayBillNo = invoice.EwayBill;
                        invoice.EwayBillIssueDate = invoice.EwayBillDate;
                        invoice.EwayBillExpiryDate = invoice.EwayExpDate;


                        int boxId = 1;
                        foreach (var box in item.BoxDetails)
                        {
                            if (invoiceId == boxId)
                            {
                                invoice.Length = box.Length;
                                invoice.Breadth = box.Breadth;
                                invoice.Height = box.Height;
                                invoice.Packages = box.Pkgs;
                            }
                            boxId = boxId + 1;
                        }
                        invoiceId = invoiceId + 1;
                    }
                    apiDocketRequest.DocumentList.InvoiceList = item.InvoiceDetails;

                    if (statusCode != "401")
                    {
                        apiDocketRequest.DocumentList.PaybasId = 2;
                        apiDocketRequest.DocumentList.Edd = item.DocketDate;
                        apiDocketRequest.DocumentList.FromLocationId = result.FromLocationId;
                        apiDocketRequest.DocumentList.ToLocationId = result.ToLocationId;
                        apiDocketRequest.DocumentList.ConsignorCityId = result.ConsignorCityId;
                        apiDocketRequest.DocumentList.ConsigneeCityId = result.ConsigneeCityId;
                        apiDocketRequest.DocumentList.TransportModeId = result.TransportModeId;
                        apiDocketRequest.DocumentList.FromCity = item.ConsignorCity;
                        apiDocketRequest.DocumentList.ToCity = item.ConsigneeCity;
                        apiDocketRequest.DocumentList.FromCityId = result.FromCityId;
                        apiDocketRequest.DocumentList.ToCityId = result.ToCityId;

                        if (apiDocketRequest.DocumentList.PaybasId == 1)
                        {
                            apiDocketRequest.DocumentList.ContractId = 1;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 2)
                        {
                            apiDocketRequest.DocumentList.ContractId = 2;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 3)
                        {
                            apiDocketRequest.DocumentList.ContractId = 3;
                        }
                        else if (apiDocketRequest.DocumentList.PaybasId == 4)
                        {
                            apiDocketRequest.DocumentList.ContractId = 4;
                        }

                        apiDocketRequest.DocumentList.IsLocal = false;
                        apiDocketRequest.DocumentList.DocketType = "M";
                        apiDocketRequest.DocumentList.DocketNo = item.DocketNo;
                        apiDocketRequest.OperationType = "B";
                        apiDocketRequest.DocumentList.CustomerId = objUser.UserTypeMapId;
                        apiDocketRequest.DocumentList.TransportMode = item.TransportMode;
                        apiDocketRequest.DocumentList.BusinessTypeId = 1;
                        apiDocketRequest.DocumentList.ServiceTypeId = 1;
                        apiDocketRequest.DocumentList.Packages = Convert.ToInt16(item.InvoiceDetails.Sum(i => i.Packages));
                        apiDocketRequest.DocumentList.ActualWeight = 1;
                        apiDocketRequest.DocumentList.ChargedWeight = item.ShipmentWeight;
                        apiDocketRequest.DocumentList.EntryDate = DateTime.Now;
                        apiDocketRequest.DocumentList.EntryBy = objUser.UserId;
                        apiDocketRequest.DocumentList.CompanyId = objUser.CompanyId;
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;

                        objUser.UserName = apiDocketRequest.UserName;
                        apiDocketRequest.DocumentList.PrivateMark = "NA";
                        apiDocketRequest.DocumentList.Remarks = "NA";

                        var objContractCustomer = customerRepository.GetDetailByName(item.ContactPersonName);
                        if (objContractCustomer != null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = objContractCustomer.CustomerId;
                        }
                        else if (objContractCustomer == null)
                        {
                            apiDocketRequest.DocumentList.CustomerId = 1;
                        }
                        apiDocketRequest.DocumentList.CustomerReferenceNo = item.RefNo;
                        apiDocketRequest.DocumentList.ContactPersonName = item.ContactPersonName;
                        apiDocketRequest.DocumentList.ContactPersonMobileNo = item.MobileNo;
                        apiDocketRequest.DocumentList.ContactPersonTelephoneNo = item.TelephoneNo;
                        apiDocketRequest.DocumentList.ConsignorName = item.ConsignorName;
                        apiDocketRequest.DocumentList.ConsigneeName = item.ConsigneeName;
                        apiDocketRequest.DocumentList.ConsignorAddress1 = item.ConsignorAddress;
                        apiDocketRequest.DocumentList.ConsigneeAddress1 = item.ConsigneeAddress;
                        apiDocketRequest.DocumentList.ConsignorPincode = item.ConsignorPin;
                        apiDocketRequest.DocumentList.ConsigneePincode = item.ConsigneePin;
                        apiDocketRequest.DocumentList.ProductTypeId = result.ProductTypeId;
                        apiDocketRequest.DocumentList.ProductValue = item.ProductValue;
                        ApiBillDetail objBillDetail = new ApiBillDetail();

                        objBillDetail.Freight = Convert.ToDecimal(0);
                        objBillDetail.FreightRate = Convert.ToDecimal(0);
                        objBillDetail.IGST = Convert.ToDecimal(0);
                        objBillDetail.SGST = Convert.ToDecimal(0);
                        objBillDetail.CGST = Convert.ToDecimal(0);
                        objBillDetail.UGST = Convert.ToDecimal(0);
                        objBillDetail.SubTotal = Convert.ToDecimal(0);
                        objBillDetail.TaxTotal = Convert.ToDecimal(0);
                        objBillDetail.GrandTotal = Convert.ToDecimal(0);
                        apiDocketRequest.DocumentList.BillDetail = objBillDetail;
                        apiDocketRequest.DocumentList.BillDetail.BillLocationId = result.BillLocationId;
                        apiDocketRequest.DocumentList.BillDetail.RateTypeId = result.RateTypeId;

                        var pram1 = new DynamicParameters();
                        string xml = XmlUtility.XmlSerializeToString(apiDocketRequest);
                        xml = xml.Replace("ApiDocketRequest", "Docket");
                        xml = xml.Replace("<DocumentList>", "");
                        xml = xml.Replace("</DocumentList>", "");
                        xml = xml.Replace("<BillDetail>", "");
                        xml = xml.Replace("</BillDetail>", "");
                        pram1.Add("@XmlDocket", xml, DbType.Xml);

                        Response obj = new Response();
                        obj = DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", pram1, module: "Docket Insert").FirstOrDefault();
                        if (obj.IsSuccessfull)
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "200", Status = "Data Saved Successfully." });
                        }
                        else
                        {
                            apiDocketNewResponses.Add(new ApiDocketNewResponse() { DocketNo = item.DocketNo, ReferenceNo = item.RefNo, StatusCode = "400", Status = "API Key validation FAILED" });
                        }
                    }

                }

            }
            responseResult.BookingDetail = apiDocketNewResponses;
            return responseResult;
        }
        public bool IsInvoiceNoAvailable(long docketId, long invoiceId,string invoiceNo, short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceId", (object)invoiceId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@InvoiceNo", (object)invoiceNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsExist", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_IsInvoiceNoAvailable", (object)dynamicParameters, "Docket - IsInvoiceNoAvailable");
            return dynamicParameters.Get<bool>("@IsExist");
        }



        public Docket GetCustomerContractByCustomerId(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)objDocket.CustomerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketDate", (object)objDocket.DocketDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)objDocket.PaybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_CustomerContract_GetContractByCustomerId", (object)dynamicParameters, "Docket - GetCustomerContractByCustomerId").FirstOrDefault();
        }

        #region UploadSpeedFox
        public DocketUpload UploadSpeedFox(DocketUpload objDocketUpload)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);

            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);

            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"EntryDate";
            row3["FieldCaption"] = (object)"Entry Date";
            dataTable.Rows.Add(row3);

            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"FromLocation";
            row4["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row4);

            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"ToLocation";
            row5["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row5);

            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"FromCity";
            row6["FieldCaption"] = (object)"From City";
            dataTable.Rows.Add(row6);

            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"ToCity";
            row7["FieldCaption"] = (object)"To City";
            dataTable.Rows.Add(row7);

            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Paybas";
            row8["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row8);

            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"TransportMode";
            row9["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row9);

            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"ServiceType";
            row10["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row10);

            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"PackagingType";
            row11["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row11);

            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ProductType";
            row12["FieldCaption"] = (object)"Product Type";
            dataTable.Rows.Add(row12);

            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"RiskType";
            row13["FieldCaption"] = (object)"Risk Type";
            dataTable.Rows.Add(row13);

            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"ConsignorCode";
            row14["FieldCaption"] = (object)"Consignor Code";
            dataTable.Rows.Add(row14);

            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ConsignorName";
            row15["FieldCaption"] = (object)"Consignor Name";
            dataTable.Rows.Add(row15);

            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"ConsigneeCode";
            row16["FieldCaption"] = (object)"Consignee Code";
            dataTable.Rows.Add(row16);

            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"ConsigneeName";
            row17["FieldCaption"] = (object)"Consignee Name";
            dataTable.Rows.Add(row17);

            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ContractParty";
            row18["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row18);

            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"ContractPartyName";
            row19["FieldCaption"] = (object)"Contract Party Name";
            dataTable.Rows.Add(row19);

            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"CompanyGstState";
            row20["FieldCaption"] = (object)"Company GST State";
            dataTable.Rows.Add(row20);

            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"GstState";
            row21["FieldCaption"] = (object)"Customer GST State";
            dataTable.Rows.Add(row21);

            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"Packages";
            row22["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row22);

            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ActualWeight";
            row23["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row23);

            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ChargedWeight";
            row24["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row24);

            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"InvoiceNo";
            row25["FieldCaption"] = (object)"Invoice No";
            dataTable.Rows.Add(row25);

            DataRow row26 = dataTable.NewRow();
            row26["FieldName"] = (object)"InvoiceDate";
            row26["FieldCaption"] = (object)"Invoice Date";
            dataTable.Rows.Add(row26);

            DataRow row27 = dataTable.NewRow();
            row27["FieldName"] = (object)"InvoiceAmount";
            row27["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row27);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Remarks";
            row28["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row28);

            DataRow row33 = dataTable.NewRow();
            row33["FieldName"] = (object)"PickupDeliveryType";
            row33["FieldCaption"] = (object)"Pickup Delivery";
            dataTable.Rows.Add(row33);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUpload.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUpload";
            docketUploadHelper1.strModuleName = "DocketUpload";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUpload.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - Upload").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUpload.IsSuccessfull = true;
                objDocketUpload.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUpload.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUpload.IsSuccessfull = false;
                objDocketUpload.ErrorMessage = ex.Message;
            }
            return objDocketUpload;
        }
        #endregion

        #region UploadSolex
        public DocketUploadInSystem UploadSolex(
          DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"EntryDate";
            row3["FieldCaption"] = (object)"Entry Date";
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"ADD";
            row4["FieldCaption"] = (object)"ADD";
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"EDD";
            row5["FieldCaption"] = (object)"EDD";
            dataTable.Rows.Add(row5);
            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"ArrivalDate";
            row6["FieldCaption"] = (object)"Arrival Date";
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Origin";
            row7["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Destination";
            row8["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"CurrentLocation";
            row9["FieldCaption"] = (object)"Current Location";
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"NextLocation";
            row10["FieldCaption"] = (object)"Next Location";
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"FromCity";
            row11["FieldCaption"] = (object)"From City";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ToCity";
            row12["FieldCaption"] = (object)"To City";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"Paybas";
            row13["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"TransportMode";
            row14["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ServiceType";
            row15["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row15);
            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"LoadType";
            row16["FieldCaption"] = (object)"Load Type";
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"BusinessType";
            row17["FieldCaption"] = (object)"Business Type";
            dataTable.Rows.Add(row17);
            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ProductType";
            row18["FieldCaption"] = (object)"Product Type";
            dataTable.Rows.Add(row18);
            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"RiskType";
            row19["FieldCaption"] = (object)"Risk Type";
            dataTable.Rows.Add(row19);
            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"ConsignorCode";
            row20["FieldCaption"] = (object)"Consignor Code";
            dataTable.Rows.Add(row20);
            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"ConsignorName";
            row21["FieldCaption"] = (object)"Consignor Name";
            dataTable.Rows.Add(row21);
            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"ConsigneeCode";
            row22["FieldCaption"] = (object)"Consignee Code";
            dataTable.Rows.Add(row22);
            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ConsigneeName";
            row23["FieldCaption"] = (object)"Consignee Name";
            dataTable.Rows.Add(row23);
            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ContractParty";
            row24["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row24);
            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"ContractPartyName";
            row25["FieldCaption"] = (object)"Contract Party Name";
            dataTable.Rows.Add(row25);

            //DataRow row26 = dataTable.NewRow();
            //row26["FieldName"] = (object)"BACode";
            //row26["FieldCaption"] = (object)"BA Code";
            //dataTable.Rows.Add(row26);
            //DataRow row27 = dataTable.NewRow();
            //row27["FieldName"] = (object)"BAName";
            //row27["FieldCaption"] = (object)"BA Name";
            //dataTable.Rows.Add(row27);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Packages";
            row28["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row28);
            DataRow row29 = dataTable.NewRow();
            row29["FieldName"] = (object)"ActualWeight";
            row29["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row29);
            DataRow row30 = dataTable.NewRow();
            row30["FieldName"] = (object)"ChargedWeight";
            row30["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row30);
            DataRow row31 = dataTable.NewRow();
            row31["FieldName"] = (object)"FreightRate";
            row31["FieldCaption"] = (object)"Freight Rate";
            dataTable.Rows.Add(row31);
            DataRow row32 = dataTable.NewRow();
            row32["FieldName"] = (object)"RateType";
            row32["FieldCaption"] = (object)"Rate Type";
            dataTable.Rows.Add(row32);
            DataRow row33 = dataTable.NewRow();
            row33["FieldName"] = (object)"Freight";
            row33["FieldCaption"] = (object)"Freight";
            dataTable.Rows.Add(row33);
            DataRow row49 = dataTable.NewRow();
            row49["FieldName"] = (object)"InvoiceNo";
            row49["FieldCaption"] = (object)"Invoice No";
            dataTable.Rows.Add(row49);
            DataRow row50 = dataTable.NewRow();
            row50["FieldName"] = (object)"InvoiceDate";
            row50["FieldCaption"] = (object)"Invoice Date";
            dataTable.Rows.Add(row50);
            DataRow row51 = dataTable.NewRow();
            row51["FieldName"] = (object)"InvoiceAmount";
            row51["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row51);
            DataRow row52 = dataTable.NewRow();
            row52["FieldName"] = (object)"Remarks";
            row52["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row52);
            DataRow row53 = dataTable.NewRow();
            row53["FieldName"] = (object)"IsAvailableForDRS";
            row53["FieldCaption"] = (object)"Is Available For DRS";
            dataTable.Rows.Add(row53);
            DataRow row54 = dataTable.NewRow();
            row54["FieldName"] = (object)"IsDelivered";
            row54["FieldCaption"] = (object)"Is Delivered";
            dataTable.Rows.Add(row54);

            //DataRow row61 = dataTable.NewRow();
            //row61["FieldName"] = (object)"PONO";
            //row61["FieldCaption"] = (object)"PO NO";
            //dataTable.Rows.Add(row61);

            DataRow row62 = dataTable.NewRow();
            row62["FieldName"] = (object)"PackagingType";
            row62["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row62);

            DataRow row63 = dataTable.NewRow();
            row63["FieldName"] = (object)"PickupDelivery";
            row63["FieldCaption"] = (object)"Pickup Delivery";
            dataTable.Rows.Add(row63);

            DataRow row64 = dataTable.NewRow();
            row64["FieldName"] = (object)"CompanyGSTState";
            row64["FieldCaption"] = (object)"Company GST State";
            dataTable.Rows.Add(row64);

            DataRow row65 = dataTable.NewRow();
            row65["FieldName"] = (object)"CustomerGSTState";
            row65["FieldCaption"] = (object)"Customer GST State";
            dataTable.Rows.Add(row65);

            DataRow row66 = dataTable.NewRow();
            row66["FieldName"] = (object)"GSTPayer";
            row66["FieldCaption"] = (object)"GST Payer";
            dataTable.Rows.Add(row66);

            DataRow row67 = dataTable.NewRow();
            row67["FieldName"] = (object)"DocketCharge";
            row67["FieldCaption"] = (object)"Docket Charge";
            dataTable.Rows.Add(row67);

            DataRow row68 = dataTable.NewRow();
            row68["FieldName"] = (object)"Hamali";
            row68["FieldCaption"] = (object)"Hamali";
            dataTable.Rows.Add(row68);

            DataRow row69 = dataTable.NewRow();
            row69["FieldName"] = (object)"Cartage";
            row69["FieldCaption"] = (object)"Cartage";
            dataTable.Rows.Add(row69);

            DataRow row70 = dataTable.NewRow();
            row70["FieldName"] = (object)"GreenTax";
            row70["FieldCaption"] = (object)"Green Tax";
            dataTable.Rows.Add(row70);

            DataRow row71 = dataTable.NewRow();
            row71["FieldName"] = (object)"PreviousFreight";
            row71["FieldCaption"] = (object)"Previous Freight";
            dataTable.Rows.Add(row71);

            DataRow row72 = dataTable.NewRow();
            row72["FieldName"] = (object)"HandlingCharge";
            row72["FieldCaption"] = (object)"Handling Charge";
            dataTable.Rows.Add(row72);

            DataRow row73 = dataTable.NewRow();
            row73["FieldName"] = (object)"OtherCharge";
            row73["FieldCaption"] = (object)"Other Charge";
            dataTable.Rows.Add(row73);

            DataRow row74 = dataTable.NewRow();
            row74["FieldName"] = (object)"COD";
            row74["FieldCaption"] = (object)"COD";
            dataTable.Rows.Add(row74);

            DataRow row75 = dataTable.NewRow();
            row75["FieldName"] = (object)"DoorDelivery";
            row75["FieldCaption"] = (object)"Door Delivery";
            dataTable.Rows.Add(row75);

            DataRow row76 = dataTable.NewRow();
            row76["FieldName"] = (object)"Insurance";
            row76["FieldCaption"] = (object)"Insurance";
            dataTable.Rows.Add(row76);

            DataRow row77 = dataTable.NewRow();
            row77["FieldName"] = (object)"SubTotal";
            row77["FieldCaption"] = (object)"Sub Total";
            dataTable.Rows.Add(row77);


            DataRow row81 = dataTable.NewRow();
            row81["FieldName"] = (object)"IGST";
            row81["FieldCaption"] = (object)"IGST";
            dataTable.Rows.Add(row81);

            DataRow row82 = dataTable.NewRow();
            row82["FieldName"] = (object)"CGST";
            row82["FieldCaption"] = (object)"CGST";
            dataTable.Rows.Add(row82);

            DataRow row83 = dataTable.NewRow();
            row83["FieldName"] = (object)"SGST";
            row83["FieldCaption"] = (object)"SGST";
            dataTable.Rows.Add(row83);

            DataRow row84 = dataTable.NewRow();
            row84["FieldName"] = (object)"GSTAmount";
            row84["FieldCaption"] = (object)"GST Amount";
            dataTable.Rows.Add(row84);

            DataRow row78 = dataTable.NewRow();
            row78["FieldName"] = (object)"DocketTotal";
            row78["FieldCaption"] = (object)"Docket Total";
            dataTable.Rows.Add(row78);

            DataRow row79 = dataTable.NewRow();
            row79["FieldName"] = (object)"IsAvailableForDeliveryMR";
            row79["FieldCaption"] = (object)"Is Available For Delivery MR";
            dataTable.Rows.Add(row79);

            DataRow row80 = dataTable.NewRow();
            row80["FieldName"] = (object)"OwnershipLocation";
            row80["FieldCaption"] = (object)"Ownership Location";
            dataTable.Rows.Add(row80);

            DataRow row85 = dataTable.NewRow();
            row85["FieldName"] = (object)"TripsheetNo";
            row85["FieldCaption"] = (object)"Tripsheet No";
            dataTable.Rows.Add(row85);

            DataRow row86 = dataTable.NewRow();
            row86["FieldName"] = (object)"TripsheetDate";
            row86["FieldCaption"] = (object)"Tripsheet Date";
            dataTable.Rows.Add(row86);

            DataRow row87 = dataTable.NewRow();
            row87["FieldName"] = (object)"CustomerDocketNo";
            row87["FieldCaption"] = (object)"Customer Docket No";
            dataTable.Rows.Add(row87);

            DataRow row88 = dataTable.NewRow();
            row88["FieldName"] = (object)"Plant Code";
            row88["FieldCaption"] = (object)"Plant Code";
            dataTable.Rows.Add(row88);


            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }
        #endregion

        #region UploadHarhita
        public DocketUploadInSystem UploadHarshita(DocketUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"EntryDate";
            row3["FieldCaption"] = (object)"Entry Date";
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"ADD";
            row4["FieldCaption"] = (object)"ADD";
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"EDD";
            row5["FieldCaption"] = (object)"EDD";
            dataTable.Rows.Add(row5);
            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"ArrivalDate";
            row6["FieldCaption"] = (object)"Arrival Date";
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Origin";
            row7["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Destination";
            row8["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"CurrentLocation";
            row9["FieldCaption"] = (object)"Current Location";
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"NextLocation";
            row10["FieldCaption"] = (object)"Next Location";
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"FromCity";
            row11["FieldCaption"] = (object)"From City";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ToCity";
            row12["FieldCaption"] = (object)"To City";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"Paybas";
            row13["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"TransportMode";
            row14["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ServiceType";
            row15["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row15);
            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"LoadType";
            row16["FieldCaption"] = (object)"Load Type";
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"BusinessType";
            row17["FieldCaption"] = (object)"Business Type";
            dataTable.Rows.Add(row17);
            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ProductType";
            row18["FieldCaption"] = (object)"Product Type";
            dataTable.Rows.Add(row18);
            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"RiskType";
            row19["FieldCaption"] = (object)"Risk Type";
            dataTable.Rows.Add(row19);
            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"ConsignorCode";
            row20["FieldCaption"] = (object)"Consignor Code";
            dataTable.Rows.Add(row20);
            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"ConsignorName";
            row21["FieldCaption"] = (object)"Consignor Name";
            dataTable.Rows.Add(row21);
            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"ConsigneeCode";
            row22["FieldCaption"] = (object)"Consignee Code";
            dataTable.Rows.Add(row22);
            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ConsigneeName";
            row23["FieldCaption"] = (object)"Consignee Name";
            dataTable.Rows.Add(row23);
            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ContractParty";
            row24["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row24);
            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"ContractPartyName";
            row25["FieldCaption"] = (object)"Contract Party Name";
            dataTable.Rows.Add(row25);

            //DataRow row26 = dataTable.NewRow();
            //row26["FieldName"] = (object)"BACode";
            //row26["FieldCaption"] = (object)"BA Code";
            //dataTable.Rows.Add(row26);
            //DataRow row27 = dataTable.NewRow();
            //row27["FieldName"] = (object)"BAName";
            //row27["FieldCaption"] = (object)"BA Name";
            //dataTable.Rows.Add(row27);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Packages";
            row28["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row28);
            DataRow row29 = dataTable.NewRow();
            row29["FieldName"] = (object)"ActualWeight";
            row29["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row29);
            DataRow row30 = dataTable.NewRow();
            row30["FieldName"] = (object)"ChargedWeight";
            row30["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row30);
            DataRow row31 = dataTable.NewRow();
            row31["FieldName"] = (object)"FreightRate";
            row31["FieldCaption"] = (object)"Freight Rate";
            dataTable.Rows.Add(row31);
            DataRow row32 = dataTable.NewRow();
            row32["FieldName"] = (object)"RateType";
            row32["FieldCaption"] = (object)"Rate Type";
            dataTable.Rows.Add(row32);
            DataRow row33 = dataTable.NewRow();
            row33["FieldName"] = (object)"Freight";
            row33["FieldCaption"] = (object)"Freight";
            dataTable.Rows.Add(row33);
            DataRow row49 = dataTable.NewRow();
            row49["FieldName"] = (object)"InvoiceNo";
            row49["FieldCaption"] = (object)"Invoice No";
            dataTable.Rows.Add(row49);
            DataRow row50 = dataTable.NewRow();
            row50["FieldName"] = (object)"InvoiceDate";
            row50["FieldCaption"] = (object)"Invoice Date";
            dataTable.Rows.Add(row50);
            DataRow row51 = dataTable.NewRow();
            row51["FieldName"] = (object)"InvoiceAmount";
            row51["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row51);
            DataRow row52 = dataTable.NewRow();
            row52["FieldName"] = (object)"Remarks";
            row52["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row52);
            DataRow row53 = dataTable.NewRow();
            row53["FieldName"] = (object)"IsAvailableForDRS";
            row53["FieldCaption"] = (object)"Is Available For DRS";
            dataTable.Rows.Add(row53);
            DataRow row54 = dataTable.NewRow();
            row54["FieldName"] = (object)"IsDelivered";
            row54["FieldCaption"] = (object)"Is Delivered";
            dataTable.Rows.Add(row54);

            //DataRow row61 = dataTable.NewRow();
            //row61["FieldName"] = (object)"PONO";
            //row61["FieldCaption"] = (object)"PO NO";
            //dataTable.Rows.Add(row61);

            DataRow row62 = dataTable.NewRow();
            row62["FieldName"] = (object)"PackagingType";
            row62["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row62);

            DataRow row63 = dataTable.NewRow();
            row63["FieldName"] = (object)"PickupDelivery";
            row63["FieldCaption"] = (object)"Pickup Delivery";
            dataTable.Rows.Add(row63);

            DataRow row64 = dataTable.NewRow();
            row64["FieldName"] = (object)"CompanyGSTState";
            row64["FieldCaption"] = (object)"Company GST State";
            dataTable.Rows.Add(row64);

            DataRow row65 = dataTable.NewRow();
            row65["FieldName"] = (object)"CustomerGSTState";
            row65["FieldCaption"] = (object)"Customer GST State";
            dataTable.Rows.Add(row65);

            DataRow row66 = dataTable.NewRow();
            row66["FieldName"] = (object)"GSTPayer";
            row66["FieldCaption"] = (object)"GST Payer";
            dataTable.Rows.Add(row66);

            DataRow row67 = dataTable.NewRow();
            row67["FieldName"] = (object)"DocketCharge";
            row67["FieldCaption"] = (object)"Docket Charge";
            dataTable.Rows.Add(row67);

            DataRow row68 = dataTable.NewRow();
            row68["FieldName"] = (object)"Hamali";
            row68["FieldCaption"] = (object)"Hamali";
            dataTable.Rows.Add(row68);

            DataRow row69 = dataTable.NewRow();
            row69["FieldName"] = (object)"Cartage";
            row69["FieldCaption"] = (object)"Cartage";
            dataTable.Rows.Add(row69);

            DataRow row70 = dataTable.NewRow();
            row70["FieldName"] = (object)"GreenTax";
            row70["FieldCaption"] = (object)"Green Tax";
            dataTable.Rows.Add(row70);

            DataRow row71 = dataTable.NewRow();
            row71["FieldName"] = (object)"PreviousFreight";
            row71["FieldCaption"] = (object)"Previous Freight";
            dataTable.Rows.Add(row71);

            DataRow row72 = dataTable.NewRow();
            row72["FieldName"] = (object)"HandlingCharge";
            row72["FieldCaption"] = (object)"Handling Charge";
            dataTable.Rows.Add(row72);

            DataRow row73 = dataTable.NewRow();
            row73["FieldName"] = (object)"OtherCharge";
            row73["FieldCaption"] = (object)"Other Charge";
            dataTable.Rows.Add(row73);

            DataRow row74 = dataTable.NewRow();
            row74["FieldName"] = (object)"COD";
            row74["FieldCaption"] = (object)"COD";
            dataTable.Rows.Add(row74);

            DataRow row75 = dataTable.NewRow();
            row75["FieldName"] = (object)"DoorDelivery";
            row75["FieldCaption"] = (object)"Door Delivery";
            dataTable.Rows.Add(row75);

            DataRow row76 = dataTable.NewRow();
            row76["FieldName"] = (object)"Insurance";
            row76["FieldCaption"] = (object)"Insurance";
            dataTable.Rows.Add(row76);

            DataRow row77 = dataTable.NewRow();
            row77["FieldName"] = (object)"SubTotal";
            row77["FieldCaption"] = (object)"Sub Total";
            dataTable.Rows.Add(row77);


            DataRow row81 = dataTable.NewRow();
            row81["FieldName"] = (object)"IGST";
            row81["FieldCaption"] = (object)"IGST";
            dataTable.Rows.Add(row81);

            DataRow row82 = dataTable.NewRow();
            row82["FieldName"] = (object)"CGST";
            row82["FieldCaption"] = (object)"CGST";
            dataTable.Rows.Add(row82);

            DataRow row83 = dataTable.NewRow();
            row83["FieldName"] = (object)"SGST";
            row83["FieldCaption"] = (object)"SGST";
            dataTable.Rows.Add(row83);

            DataRow row84 = dataTable.NewRow();
            row84["FieldName"] = (object)"GSTAmount";
            row84["FieldCaption"] = (object)"GST Amount";
            dataTable.Rows.Add(row84);

            DataRow row78 = dataTable.NewRow();
            row78["FieldName"] = (object)"DocketTotal";
            row78["FieldCaption"] = (object)"Docket Total";
            dataTable.Rows.Add(row78);

            DataRow row79 = dataTable.NewRow();
            row79["FieldName"] = (object)"IsAvailableForDeliveryMR";
            row79["FieldCaption"] = (object)"Is Available For Delivery MR";
            dataTable.Rows.Add(row79);

            DataRow row80 = dataTable.NewRow();
            row80["FieldName"] = (object)"OwnershipLocation";
            row80["FieldCaption"] = (object)"Ownership Location";
            dataTable.Rows.Add(row80);

            DataRow row85 = dataTable.NewRow();
            row85["FieldName"] = (object)"TripsheetNo";
            row85["FieldCaption"] = (object)"Tripsheet No";
            dataTable.Rows.Add(row85);

            DataRow row86 = dataTable.NewRow();
            row86["FieldName"] = (object)"TripsheetDate";
            row86["FieldCaption"] = (object)"Tripsheet Date";
            dataTable.Rows.Add(row86);

            DataRow row87 = dataTable.NewRow();
            row87["FieldName"] = (object)"CustomerDocketNo";
            row87["FieldCaption"] = (object)"Customer Docket No";
            dataTable.Rows.Add(row87);

            DataRow row88 = dataTable.NewRow();
            row88["FieldName"] = (object)"Plant Code";
            row88["FieldCaption"] = (object)"Plant Code";
            dataTable.Rows.Add(row88);

            DataRow row89 = dataTable.NewRow();
            row89["FieldName"] = (object)"ConsignorAddress";
            row89["FieldCaption"] = (object)"Consignor Address";
            dataTable.Rows.Add(row89);

            DataRow row90 = dataTable.NewRow();
            row90["FieldName"] = (object)"ConsigneeAddress";
            row90["FieldCaption"] = (object)"Consignee Address";
            dataTable.Rows.Add(row90);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "DocketUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }
        #endregion

        #region UploadMCLS
        public DocketUpload UploadMCLS(DocketUpload objDocketUpload)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"DocketNo";
            row1["FieldCaption"] = (object)"Docket No";
            dataTable.Rows.Add(row1);

            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketDate";
            row2["FieldCaption"] = (object)"Docket Date";
            dataTable.Rows.Add(row2);

            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"EntryDate";
            row3["FieldCaption"] = (object)"Entry Date";
            dataTable.Rows.Add(row3);

            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"FromLocation";
            row4["FieldCaption"] = (object)"Origin";
            dataTable.Rows.Add(row4);

            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"ToLocation";
            row5["FieldCaption"] = (object)"Destination";
            dataTable.Rows.Add(row5);

            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"FromCity";
            row6["FieldCaption"] = (object)"From City";
            dataTable.Rows.Add(row6);

            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"ToCity";
            row7["FieldCaption"] = (object)"To City";
            dataTable.Rows.Add(row7);

            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Paybas";
            row8["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row8);

            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"TransportMode";
            row9["FieldCaption"] = (object)"Transport Mode";
            dataTable.Rows.Add(row9);

            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"ServiceType";
            row10["FieldCaption"] = (object)"Service Type";
            dataTable.Rows.Add(row10);

            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"PackagingType";
            row11["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row11);

            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ProductType";
            row12["FieldCaption"] = (object)"Product Type";
            dataTable.Rows.Add(row12);

            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"RiskType";
            row13["FieldCaption"] = (object)"Risk Type";
            dataTable.Rows.Add(row13);

            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"ConsignorCode";
            row14["FieldCaption"] = (object)"Consignor Code";
            dataTable.Rows.Add(row14);

            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"ConsignorName";
            row15["FieldCaption"] = (object)"Consignor Name";
            dataTable.Rows.Add(row15);

            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"ConsigneeCode";
            row16["FieldCaption"] = (object)"Consignee Code";
            dataTable.Rows.Add(row16);

            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"ConsigneeName";
            row17["FieldCaption"] = (object)"Consignee Name";
            dataTable.Rows.Add(row17);

            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"ContractParty";
            row18["FieldCaption"] = (object)"Contract Party";
            dataTable.Rows.Add(row18);

            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"ContractPartyName";
            row19["FieldCaption"] = (object)"Contract Party Name";
            dataTable.Rows.Add(row19);

            DataRow row20 = dataTable.NewRow();
            row20["FieldName"] = (object)"CompanyGstState";
            row20["FieldCaption"] = (object)"Company GST State";
            dataTable.Rows.Add(row20);

            DataRow row21 = dataTable.NewRow();
            row21["FieldName"] = (object)"GstState";
            row21["FieldCaption"] = (object)"Customer GST State";
            dataTable.Rows.Add(row21);

            DataRow row22 = dataTable.NewRow();
            row22["FieldName"] = (object)"Packages";
            row22["FieldCaption"] = (object)"Packages";
            dataTable.Rows.Add(row22);

            DataRow row23 = dataTable.NewRow();
            row23["FieldName"] = (object)"ActualWeight";
            row23["FieldCaption"] = (object)"Actual Weight";
            dataTable.Rows.Add(row23);

            DataRow row24 = dataTable.NewRow();
            row24["FieldName"] = (object)"ChargedWeight";
            row24["FieldCaption"] = (object)"Charged Weight";
            dataTable.Rows.Add(row24);

            DataRow row25 = dataTable.NewRow();
            row25["FieldName"] = (object)"InvoiceNo";
            row25["FieldCaption"] = (object)"Invoice No";
            dataTable.Rows.Add(row25);

            DataRow row26 = dataTable.NewRow();
            row26["FieldName"] = (object)"InvoiceDate";
            row26["FieldCaption"] = (object)"Invoice Date";
            dataTable.Rows.Add(row26);

            DataRow row27 = dataTable.NewRow();
            row27["FieldName"] = (object)"InvoiceAmount";
            row27["FieldCaption"] = (object)"Invoice Amount";
            dataTable.Rows.Add(row27);

            DataRow row28 = dataTable.NewRow();
            row28["FieldName"] = (object)"Remarks";
            row28["FieldCaption"] = (object)"Remarks";
            dataTable.Rows.Add(row28);

            DataRow row33 = dataTable.NewRow();
            row33["FieldName"] = (object)"PickupDeliveryType";
            row33["FieldCaption"] = (object)"Pickup Delivery";
            dataTable.Rows.Add(row33);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUpload.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUpload";
            docketUploadHelper1.strModuleName = "DocketUpload";
            docketUploadHelper1.strProcedureName = "Usp_Docket_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUpload.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - Upload").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUpload.IsSuccessfull = true;
                objDocketUpload.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUpload.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUpload.IsSuccessfull = false;
                objDocketUpload.ErrorMessage = ex.Message;
            }
            return objDocketUpload;
        }
        #endregion

        #region UploadDocketTripsheetCartonSolex
        public DocketUploadInSystem UploadDocketTripsheetCarton(
         DocketUploadInSystem objDocketUploadTripsheetCarton)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"TripsheetNo";
            row1["FieldCaption"] = (object)"TripsheetNo";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketNo";
            row2["FieldCaption"] = (object)"DocketNo";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"CartonNo";
            row3["FieldCaption"] = (object)"CartonNo";
            dataTable.Rows.Add(row3);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadTripsheetCarton.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/UploadDocketTripSheetCartonInSystem";
            docketUploadHelper1.strModuleName = "UploadInSystemDocketCartonSolex";
            docketUploadHelper1.strProcedureName = "Usp_Docket_TripSheet_Carton_Upload_InSystem";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketTripSheetCartonUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadTripsheetCarton.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadTripsheetCarton.IsSuccessfull = true;
                objDocketUploadTripsheetCarton.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadTripsheetCarton.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadTripsheetCarton.IsSuccessfull = false;
                objDocketUploadTripsheetCarton.ErrorMessage = ex.Message;
            }
            return objDocketUploadTripsheetCarton;
        }
        #endregion
       
        #region UploadDocketTripsheetCartonEssential
        public DocketUploadInSystem UploadDocketTripsheetCartonEssential(
         DocketUploadInSystem objDocketUploadTripsheetCarton)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"TripsheetNo";
            row1["FieldCaption"] = (object)"TripsheetNo";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"DocketNo";
            row2["FieldCaption"] = (object)"DocketNo";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"CartonNo";
            row3["FieldCaption"] = (object)"CartonNo";
            dataTable.Rows.Add(row3);

            DocketUploadHelper docketUploadHelper1 = new DocketUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadTripsheetCarton.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "DocketUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/UploadDocketTripSheetCartonInSystem";
            docketUploadHelper1.strModuleName = "UploadInSystemDocketCartonEssential";
            docketUploadHelper1.strProcedureName = "Usp_Docket_TripSheet_Carton_Upload_InSystem_For_Essential";
            DocketUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketTripSheetCartonUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadTripsheetCarton.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<Docket>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Docket Upload - UploadInSystem").ToList<Docket>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<Docket>((Func<Docket, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadTripsheetCarton.IsSuccessfull = true;
                objDocketUploadTripsheetCarton.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadTripsheetCarton.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadTripsheetCarton.IsSuccessfull = false;
                objDocketUploadTripsheetCarton.ErrorMessage = ex.Message;
            }
            return objDocketUploadTripsheetCarton;
        }
        #endregion

        public void InsertFareyeWebhookResult(long docketId, string result)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Result", (object)result, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_FareyeWebhook_Result_Insert", (object)dynamicParameters, "Docket - InsertFareyeWebhookResult");
        }

        public bool IsEwayBillNoAvailable(string ewaybillNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EwayBillNo", (object)ewaybillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_IsEwayBillNoAvailable", (object)dynamicParameters, "Docket - IsEwayBillNoAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<AutoCompleteResult> GetMappedBillingParty(
         short consignorId,
         short consigneeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("USP_Docket_GetMappedBillingParty", (object)dynamicParameters, "Docket - GetBillingPartyByConsignorAndConsignee");
        }

        public DocketStatusApi InsertTripsheetForAdityaBirla(TripsheetForAdityaBirlaMain obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketUpload", (object)XmlUtility.XmlSerializeToString((object)obj), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketStatusApi>("Usp_TripsheetForAdityaBirla_Insert", (object)dynamicParameters, "Docket - Usp_TripsheetForAdityaBirla_Insert").FirstOrDefault();
        }
        public DocketStatusApi InsertTripsheetForAdityaBirlaSummary(TripsheetForAdityaBirlaMain obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketUpload", (object)XmlUtility.XmlSerializeToString((object)obj), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketStatusApi>("Usp_TripsheetForAdityaBirlaSummary_Insert", (object)dynamicParameters, "Docket - Usp_TripsheetForAdityaBirla_Insert").FirstOrDefault();
        }

        public DocketStatusApi InsertTripsheetForAdityaBirlaEWBN(TripsheetForAdityaBirlaMain obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketUpload", (object)XmlUtility.XmlSerializeToString((object)obj), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketStatusApi>("Usp_TripsheetForAdityaBirlaEWBN_Insert", (object)dynamicParameters, "Docket - Usp_TripsheetForAdityaBirla_Insert").FirstOrDefault();
        }

        public IEnumerable<TripsheetForAdityaBirlaSummary> GetAdityaBirlaTripsheet(string UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@tripsheetno", (object)UserId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetForAdityaBirlaSummary>("CL_AdityaBirlaTripsheet_GetAll", (object)dynamicParameters, "Docket - GetBillingPartyByConsignorAndConsignee");
        }
        public IEnumerable<TripsheetForAdityaBirlaSummary> GetAdityaBirlaTripsheetBulk(string UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetForAdityaBirlaSummary>("CL_AdityaBirlaTripsheet_GetAllBulk", (object)dynamicParameters, "Docket - GetBillingPartyByConsignorAndConsignee");
        }

        public TripsheetForAdityaBirlaMain GetAdityaBirlaTripsheetById(string tripsheetsumid)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@tripsheetsumid", (object)tripsheetsumid, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<TripsheetForAdityaBirlaSummary>, IEnumerable<TripsheetForAdityaBirlaEWBN>, IEnumerable<TripsheetForAdityaBirla>> tuple = DataBaseFactory.QueryMultipleSP<TripsheetForAdityaBirlaSummary, TripsheetForAdityaBirlaEWBN, TripsheetForAdityaBirla>("CL_AdityaBirlaTripsheet_GetById", (object)dynamicParameters, "Docket Master - ");
            TripsheetForAdityaBirlaMain MainObj = new TripsheetForAdityaBirlaMain();
            MainObj.SummaryList = tuple.Item1.ToList<TripsheetForAdityaBirlaSummary>();
            MainObj.EWBNList = tuple.Item2.ToList<TripsheetForAdityaBirlaEWBN>();
            MainObj.TripsheetList = tuple.Item3.ToList<TripsheetForAdityaBirla>();
            
            if (MainObj.EWBNList.Count == 0)
            {
                TripsheetForAdityaBirlaEWBN ewbn = new TripsheetForAdityaBirlaEWBN ();
                ewbn.ewaybillno="";
                ewbn.invoicevalue= 0;
                MainObj.EWBNList.Add(ewbn);
            }

            string fromCity = "", toCity = "", toPinCode = "";

            foreach(var item in MainObj.TripsheetList)
            {
                fromCity = item.fromcity;
                toCity = item.shroomcity;
                toPinCode = item.shroompin;
                break;
            }

            foreach(var item in MainObj.SummaryList)
            {
                item.fromCity = fromCity;
                item.toCity = toCity;
                item.toPinCode = toPinCode;
            }

            return MainObj;
        }
        public DocketStatusApi UpdayeAdityaBirlaTripsheetById(string tripsheetsumid)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@tripsheetsumid", (object)tripsheetsumid, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketStatusApi>("CL_AdityaBirlaTripsheet_Update", (object)dynamicParameters, "Docket - Usp_TripsheetForAdityaBirla_Insert").FirstOrDefault();
        }



    }
}
