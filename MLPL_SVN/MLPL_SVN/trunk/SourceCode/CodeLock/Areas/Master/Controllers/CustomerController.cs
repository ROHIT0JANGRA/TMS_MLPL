using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using CodeLock.Helper;
using Newtonsoft.Json;
using ExpressiveAnnotations.Analysis;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using CodeLock.Api_Services;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Owin.BuilderProperties;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Reflection;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.SignalR.Hosting;
using System.Web.Helpers;
using CodeLock.Areas.Packaging.Repository;
using Newtonsoft.Json.Linq;

namespace CodeLock.Areas.Master.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IStateRepository stateRepository;
        private readonly ICityRepository cityRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ICustomerGroupRepository customerGroupRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IRgpRepository rgpRepository;
        public CustomerController()
        {
        }

        public CustomerController(ICustomerRepository _customerRepository, ICountryRepository _countryRepository, IStateRepository _stateRepository, ICityRepository _cityRepository, IGeneralRepository _generalRepository, ICustomerGroupRepository _customerGroupRepository, ILocationRepository _locationRepository, IRgpRepository rgpRepository)
        {
            this.customerRepository = _customerRepository;
            this.countryRepository = _countryRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
            this.generalRepository = _generalRepository;
            this.customerGroupRepository = _customerGroupRepository;
            this.locationRepository = _locationRepository;
            this.rgpRepository = rgpRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.customerRepository.Dispose();
            }
            base.Dispose(disposing);
        }
   
    
        public JsonResult GetAutocompleteConsigneeList(string consigneeName)
        {
            return base.Json(this.customerRepository.GetAutocompleteConsigneeList(consigneeName));
        }

        public JsonResult GetAutoCompleteCustomerList(string customerCode)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteCustomerList(customerCode, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetAutoCompleteCustomerListByLocation(string customerCode, short locationId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteCustomerListByLocation(customerCode, locationId, SessionUtility.CompanyId));
            return jsonResult;
        }
        public JsonResult GetAutoCompleteCustomerListByLocationPaybas(string customerName, short locationId, byte PaybasId, bool allowWalkin, bool isGstTypeCustomer = true)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteCustomerListByLocationPaybas(locationId, PaybasId, customerName, allowWalkin, isGstTypeCustomer));
            return jsonResult;
        }


        public JsonResult GetAutoCompleteListByPaybasId(string customerCode)
        {
            return base.Json(this.customerRepository.GetAutoCompleteListByPaybasId(customerCode));
        }

        public JsonResult GetConsigneeDetailByName(string consigneeName)
        {
            return base.Json(this.customerRepository.GetConsigneeDetailByName(consigneeName));
        }

        public JsonResult GetCustomerListByGroupCode(string groupCode)
        {
            return base.Json(this.customerRepository.GetCustomerListByGroupCode(groupCode));
        }

        public JsonResult GetCustomerListByPaybasId(byte payBasId)
        {
            return base.Json(this.customerRepository.GetCustomerListByPaybasId(payBasId));
        }

        public JsonResult GetLocationListByCustomerId(short customerId)
        {
            return base.Json(this.customerRepository.GetLocationListByCustomerId(customerId));
        }

        public ActionResult Index()
        {
            return base.View();
        }

        private void Init(byte countryId, short stateId)
        {
             countryId = 1;
            ((dynamic)base.ViewBag).IndustryList = this.generalRepository.GetByIdList(12);
            ((dynamic)base.ViewBag).OwnerShipList = this.generalRepository.GetByIdList(13);
            ((dynamic)base.ViewBag).CustomerTypeList = this.generalRepository.GetByIdList(303);
            ((dynamic)base.ViewBag).GroupList = this.customerGroupRepository.GetCustomerGroupList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);

            if ((countryId != 0 ? true : stateId != 0))
            {
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(countryId);
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(stateId);
            }
            else
            {
                ((dynamic)base.ViewBag).StateList = Enumerable.Empty<SelectListItem>();
                ((dynamic)base.ViewBag).CityList = Enumerable.Empty<SelectListItem>();
            }
        }
        public IEnumerable<AutoCompleteResult> GetCityStateWise(int StateId)
        {
          return this.cityRepository.GetCityListByStateId(StateId.ConvertToShort());
            
        }
        //public ActionResult Insert()
        //{
        //    ///MasterGeneral masterPayBas;

        //    //   MasterCustomer objCustomer = new MasterCustomer();
        //    // this.Init(0, 0);
        //    MasterCustomer objCustomer = new MasterCustomer()
        //    {
        //        MasterAddress = new List<MasterAddress>()
        //    };
        //    List<MasterAddress> addressDetails = objCustomer.MasterAddress;
        //    MasterAddress addressDocument = new MasterAddress()
        //    {
        //        CityId = 0,
        //        CityName = "",
        //        AddressId = 0,
        //        AddressCode = "",
        //        Address1 = "",
        //        EmailId = "",
        //        Address2 = "",
        //        Pincode = "",
        //        MobileNo = "",
        //        StatisticalChargesCode = "",
        //        IsMreNoApplicable = false,
        //        GstTinNo = "",
        //        ProvisionalId = "",
        //        IsActive = false
        //    };
        //    addressDetails.Add(addressDocument);

        //    this.Init(0, 0);



        //    objCustomer.PayBas = this.generalRepository.GetByGeneralList(14).ToArray<MasterGeneral>();


        //    for (int i = 0; i < objCustomer.PayBas.Length; i++)
        //    {
        //        objCustomer.PayBas[i].IsActive = false;
        //    }

        //     ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
        //    ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);

        //    ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);

        //    return base.View(objCustomer);
        //}
        //public async Task<BPMasterModel> MapMasterCustomerToBPMasterModel(MasterCustomer masterCustomer)
        //{
        //    List<ContactEmployee> BPContactEmployee = new List<ContactEmployee>();
        //    ContactEmployee bpContactEmpObj = new ContactEmployee();
        //    bpContactEmpObj.CardCode = masterCustomer.CustomerCode; // Example mapping
        //    bpContactEmpObj.Name = masterCustomer.MasterCustomerDetail.DecisionMakerName; // Example mapping
        //    bpContactEmpObj.MobilePhone = masterCustomer.MasterCustomerDetail.MobileNo; // Example mapping
        //    bpContactEmpObj.E_Mail = masterCustomer.MasterCustomerDetail.EmailId;
        //    BPContactEmployee.Add(bpContactEmpObj);
        //    // ************* For Add Bank **********************
        //    List<BPBankAccount> BPBankAccounts = new List<BPBankAccount>();
        //    BPBankAccount objBPBank = new BPBankAccount();
        //    objBPBank.BPCode = masterCustomer.BPCode;
        //    objBPBank.Branch = masterCustomer.Branch;
        //    objBPBank.Country = "INDIA";
        //    objBPBank.BankCode = masterCustomer.BankCode;
        //    objBPBank.AccountNo = masterCustomer.Account;
        //    objBPBank.AccountName = masterCustomer.BankAccountName;
        //    objBPBank.BICSwiftCode = masterCustomer.BICSWIFTCode;
        //    BPBankAccounts.Add(objBPBank);

        //    var bpmMasterModel = new BPMasterModel
        //    {
        //        // Map common fields
        //        CardCode = masterCustomer.CustomerCode,
        //        CardName = masterCustomer.CustomerName,
        //        GroupCode = int.TryParse(masterCustomer.GroupCode, out var groupCode) ? groupCode : 0, // Assuming GroupCode is an integer in BPMasterModel
        //        CardType = masterCustomer.GroupName, // Adjust based on your logic
        //        U_Controling_Branch = masterCustomer.U_Controling_Branch,
        //        DefaultAccount = masterCustomer.PhoneNo, // Example mapping, adjust as needed
        //        DefaultBranch = masterCustomer.Branch,
        //        // Map bank accounts (assuming multiple bank accounts are present)
        //        ContactEmployees = BPContactEmployee,
        //        BPBankAccounts = BPBankAccounts,
        //        // Map addresses
        //        BPAddresses = masterCustomer.MasterAddressList.Select(address => new BPAddress
        //        {
        //            AddressName = address.AddressCode,
        //            ZipCode = address.Pincode,
        //            City = address.CityName,
        //            Country = "INDIA",
        //            State = address.StateName,
        //            AddressType = address.AddressType,
        //            AddressName2 = address.Address1,
        //            AddressName3 = address.Address2,
        //            BPCode = address.AddressCode,
        //            RowNum = address.RowNum,
        //            GSTIN = address.GSTIN,
        //            GstType = address.GstType,
        //            CreateDate = address.CreateDate,
        //            CreateTime = address.CreateTime,
        //            U_PANNo = address.ProvisionalId
        //        }).ToList()
        //    };
        //    if (bpmMasterModel != null)
        //    {
        //        await SaveTheCustomerMasterDataInSap(bpmMasterModel);
        //    }
        //    return bpmMasterModel;
        //}
      

        public ActionResult Insert()
        {
            
            MasterCustomer objCustomer = new MasterCustomer()
            {
                MasterAddressList = new List<MasterAddress>()
            };
            MasterAddress objAdd = new MasterAddress()
            {
                AddressId = 0,
                AddressCode = "",
                Address1 = "",
                Address2 = "",
                CityId = 0,
                CityName = "",
                Pincode = "",
                MobileNo = "",
                EmailId = "",
                StatisticalChargesCode = "",
                IsActive = true,
                IsMreNoApplicable = false,
                CountryId = 0,
                StateId = 0
            };
            objCustomer.MasterAddressList.Add(objAdd);
            this.Init(0, 0);
            objCustomer.PayBas = this.generalRepository.GetByGeneralList(14).ToArray<MasterGeneral>();
            for (int i = 0; i < objCustomer.PayBas.Length; i++)
            {
                objCustomer.PayBas[i].IsActive = false;
            }
      ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);
            //((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);

            return base.View(objCustomer);
        }

     

        [HttpPost]
        [ValidateAntiModelInjection("CustomerId")]
        public  async Task<ActionResult> Insert(MasterCustomer objMasterCustomer)
        {
            ActionResult action;
            this.Init(0, 0);
            int num = 0;

            if (objMasterCustomer != null)
            {
                objMasterCustomer.EntryBy = SessionUtility.LoginUserId;
                objMasterCustomer.WarehouseId = SessionUtility.WarehouseId;

                if (objMasterCustomer.MasterCustomerDetail != null)
                {
                    objMasterCustomer.MasterCustomerDetail.EntryBy = SessionUtility.LoginUserId;
                }
             await this.customerRepository.MapMasterCustomerToBPMaster(objMasterCustomer);
                           
                  num = this.customerRepository.Insert(objMasterCustomer);
                
            }

            action = RedirectToAction("View", new { id = num });
            return action;
        }

     
        [HttpPost]
        public ActionResult GetNewCustomerAddress(int Index,int ClickCount)
        {
            var MasterAddress = new MasterAddress
            {
                IsActive = true
            };
            //if (ClickCount == -1)
            //{
            //    MasterAddress.AddressCode = this.customerRepository.GetCustomerAddressCode((Index == 0 ? 0 : Index));

            //}
            //else
            //{
            //    MasterAddress.AddressCode = this.customerRepository.GetCustomerAddressCode(ClickCount);

            //}
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);
            ((dynamic)base.ViewBag).CityList = Enumerable.Empty<SelectListItem>();

            ViewBag.Index = Index;
            ViewData.TemplateInfo.HtmlFieldPrefix = $"MasterAddressList[{Index}]";
            // Return partial view for Address
            return PartialView("_CustomerAddress", MasterAddress);
        }
        [HttpPost]
        public ActionResult GetCustomerAddressForAPI(string MasterAddressJson, int Index)
        {
            // Deserialize JSON string to MasterAddress object
            var masterAddress = JsonConvert.DeserializeObject<MasterAddress>(MasterAddressJson);

            // Fetch state and city IDs based on names
            short stateId = stateRepository.GetSateIdBySateName(masterAddress.StateName);
            short cityId = cityRepository.GetCityIdByStateId(stateId, masterAddress.CityName);

            // Assign the IDs to the MasterAddress object
            masterAddress.StateId = stateId;
            masterAddress.CityId = cityId;

            // Populate ViewBag with required lists
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();

            // Set ViewBag.Index and ViewData.TemplateInfo.HtmlFieldPrefix for the partial view
            ViewBag.Index = Index;
            ViewData.TemplateInfo.HtmlFieldPrefix = $"MasterAddressList[{Index}]";

            // Optional: Get the customer address code if needed
         //   masterAddress.AddressCode =  this.customerRepository.GetCustomerAddressCode(Index);

            // Return partial view with the masterAddress object
            return PartialView("_CustomerAddress", masterAddress);
        }

        //[HttpPost]
        //public ActionResult GetCustomerAddressForAPIS(MasterAddress MasterAddress, int Index)
        //{
        //    //((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
        //    //((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);
        //    //((dynamic)base.ViewBag).CityList = Enumerable.Empty<SelectListItem>();
        //    short stateId = this.stateRepository.GetSateIdBySateName(MasterAddress.StateName);
        //    short cityId = this.cityRepository.GetCityIdByStateId(stateId, MasterAddress.CityName);
        //    // Assign the IDs to the MasterAddress object
        //    MasterAddress.StateId = stateId;
        //    MasterAddress.CityId = cityId;
        //    // Fetch lists for dropdowns
        //    ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
        //    ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);
        //    ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();
        //    //   ((dynamic)base.ViewBag).CityList = Enumerable.Empty<SelectListItem>();
        //    //ViewBag.Index = Index;
        //    //ViewData.TemplateInfo.HtmlFieldPrefix = $"MasterAddressList[{Index}]";
        //    // Return partial view for Address
        //    MasterAddress.AddressCode = this.customerRepository.GetCustomerAddressCode(Index);

        //    return PartialView("_CustomerAddress", MasterAddress);
        //}
        public JsonResult GetCustomerAddressInfoForApi(string CityName, string StateName)
        {
            Dictionary<string, short> Dic = new Dictionary<string, short>();
            short StateId = this.stateRepository.GetSateIdBySateName(StateName);
            short CityId = this.cityRepository.GetCityIdByStateId(StateId,CityName);
            Dic["StateId"] = StateId;
            Dic["CityId"] = CityId;
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();

            return Json(Dic);

        }

        //*******************************************************************************************************************
        public async Task<dynamic> FetchCustomerDetailsFromApi(string gstin)
        {
            if (string.IsNullOrEmpty(gstin))
            {
                return Json(new { success = false, message = "GST number is required" });
            }
            string token = UlipTokenManagerController.GetTokenId();
            if (string.IsNullOrEmpty(token))
            {
                token = await UlipTokenManagerController.GenerateToken();
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var requestBody = new { gstin = gstin };

                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

              //  var response = await httpClient.PostAsync("https://www.ulipstaging.dpiit.gov.in/ulip/v1.0.0/GST/01", content);
                string ulipUrl = ConfigurationManager.AppSettings["UlipUrl"];

                var response = await httpClient.PostAsync($"{ulipUrl}/GST/01", content);
                var statusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return Json(responseData);
                    //var masterCustomer = Newtonsoft.Json.JsonConvert.DeserializeObject<MasterCustomer>(responseData);
                    //return Json(new { success = true, data = masterCustomer });

                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    token = await UlipTokenManagerController.GenerateToken();
                    var responseData = new
                    {
                        code = statusCode,
                        error = false,
                        message = "Status Code 403 : Forbidden error (Please try again later)."
                    };
                    var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(responseData);
                    return jsonResponse;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var responseData = new
                    {
                        code = statusCode,
                        error = false,
                        Message = "Status Code 401 : Unauthorized login (Please check your credentials).",
                    };
                    var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(responseData);
                    return jsonResponse;
                }
            }

            return null;
        }
        // ***********************  Fetch The List Of Sap BP Master ******************************

        public ActionResult SAPBPMasterList() { return View(); }
        public async Task<JsonResult> BpMasterPagination(int draw, int start, int length, string search = null)
        {
            try
            {
                // Fetch data from repository
                var result = await FetchBPMasterPaginations(start, length, search);

                // Check for errors in the result
                if (result.ContainsKey("error"))
                {
                    return Json(new { error = result["error"] }, JsonRequestBehavior.AllowGet);
                }

                // Extract total records and data list
                var totalRecords = (int)result["totalRecords"];
                var bpmMasterListJson = result["BPMasterList"] as JArray;
                var bpmMasterList = bpmMasterListJson?.ToObject<List<BpMasterTable>>() ?? new List<BpMasterTable>();

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
        public async Task<Dictionary<string, object>> FetchBPMasterPaginations(int start, int length, string search = null)
        {
            var result = new Dictionary<string, object>();
            try
            {
                string countUrl = "/BusinessPartners/$count";
                string BpMaasterurl = $"https://103.194.8.71:50000/b1s/v1/BusinessPartners?$select=CardName,CardCode,CardType,CreateDate&$skip={start}&$top={length}";
                if (!string.IsNullOrEmpty(search))
                {
                    // myurl += $"&$filter=contains(CardName,'{search}') or contains(CardCode,'{search}') or contains(U_VehicleNo,'{search}'or contains(Reference1,'{search}')";
                    BpMaasterurl += $"&$filter=contains(CardName,'{search}') or contains(CardCode,'{search}')";
                }
                int totalRecords = await rgpRepository.FetchBPMasterCount(countUrl).ConfigureAwait(false);
                var BPMasterListResponse = await rgpRepository.FetchBPMasterList(BpMaasterurl, start, length, search).ConfigureAwait(false);

                result["totalRecords"] = totalRecords;
                result["BPMasterList"] = BPMasterListResponse?.ContainsKey("value") == true ? BPMasterListResponse["value"] : new List<object>();
            }
            catch (Exception ex)
            {
                result["error"] = ex.Message;
            }

            return result;
        }
          public JsonResult IsCustomerCodeExist(string customerCode)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.IsCustomerCodeExist(customerCode, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult IsCustomerCodeExistByLocation(string customerCode, short locationId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.IsCustomerCodeExistByLocation(customerCode, locationId, SessionUtility.CompanyId));
            return jsonResult;
        }
        public JsonResult IsCustomerCodeExistForOrder(string customerCode)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.IsCustomerCodeExistForOrder(customerCode, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult IsCustomerExistByLocationPaybas(short locationId, byte paybasId, string customerCode, bool allowWalkIn)
        {
            MasterCustomer masterCustomer = this.customerRepository.IsCustomerExistByLocationPaybas(locationId, paybasId, customerCode, allowWalkIn);
            if (masterCustomer == null)
            {
                masterCustomer = new MasterCustomer();
            }
            return base.Json(masterCustomer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiModelInjection("CustomerId")]
        public JsonResult IsCustomerNameAvailable(MasterCustomer objMasterCustomer)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.IsCustomerNameAvailable(objMasterCustomer.CustomerName, objMasterCustomer.CustomerId));
            return jsonResult;
        }

        public JsonResult IsCustomerNameExist(string customerName)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.IsCustomerNameExistWithGstNo(customerName, string.Empty));
            return jsonResult;
        }

        public JsonResult IsCustomerNameExistWithGstNo(string customerName, string gstNo)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.IsCustomerNameExistWithGstNo(customerName, gstNo));
            return jsonResult;
        }

        public ActionResult Update(int? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            int? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?((int)nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                MasterCustomer objCustomer = new MasterCustomer();
                objCustomer = this.customerRepository.GetById(id.Value);
                this.Init(objCustomer.MasterCustomerAddressInfo.CountryId, objCustomer.MasterCustomerAddressInfo.StateId);
                objCustomer.PayBas = this.generalRepository.GetByGeneralList(14).ToArray<MasterGeneral>();
                if (objCustomer.MasterAddressList.Count == 0)
                {
                    List<MasterAddress> MasterAddressList = objCustomer.MasterAddressList;
                    MasterAddress objAdd = new MasterAddress()
                    {
                        AddressId = 0,
                        AddressCode = "",
                        Address1 = "",
                        Address2 = "",
                        CityId = 0,
                        CityName = "",
                        Pincode = ""                ,
                        MobileNo = "",
                        EmailId = "",
                        StatisticalChargesCode = "",
                        IsActive = true,
                        IsMreNoApplicable = false                ,
                        CountryId = 0,
                        StateId = 0
                    };
                    MasterAddressList.Add(objAdd);
                }
                for (int i = 0; i < objCustomer.PayBas.Length; i++)
                {
                    objCustomer.PayBas[i].IsActive = false;
                }

                if (objCustomer.PayBasId.Length > 1)
                {
                    string[] PaybasData = objCustomer.PayBasId.Split(',');

                    for (int i = 0; i < PaybasData.Length; i++)
                    {
                        for (int j = 0; j < objCustomer.PayBas.Length; j++)
                        {
                            if (PaybasData[i].ToString() == objCustomer.PayBas[j].CodeId.ToString())
                            {
                                objCustomer.PayBas[j].IsActive = true;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < objCustomer.PayBas.Length; i++)
                    {
                        if (objCustomer.PayBasId.ToString() == objCustomer.PayBas[i].CodeId.ToString())
                            {
                            objCustomer.PayBas[i].IsActive = true;
                        }
                    }
                }
                ViewBag.StateWiseCityList =null;

                httpStatusCodeResult = base.View(objCustomer);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("CustomerId")]
        public ActionResult Update(MasterCustomer objMasterCustomer)
        {
            ActionResult action;

            // action = base.View(objMasterCustomer);

            objMasterCustomer.UpdateBy = new short?(SessionUtility.LoginUserId);
            objMasterCustomer.WarehouseId = SessionUtility.WarehouseId;
            int num = this.customerRepository.Update(objMasterCustomer);
            action = base.RedirectToAction("View", new { id = num });

            //if (!base.ModelState.IsValid)
            //{
            //    action = base.View(objMasterCustomer);
            //}
            //else
            //{
            //    objMasterCustomer.UpdateBy = new short?(SessionUtility.LoginUserId);
            //    objMasterCustomer.WarehouseId = SessionUtility.WarehouseId;
            //    byte num = this.customerRepository.Update(objMasterCustomer);
            //    action = base.RedirectToAction("View", new { id = num });
            //}
            return action;
        }

        public ActionResult View(int? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            int? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?((int)nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                MasterCustomer masterCustomer = new MasterCustomer();
                masterCustomer = this.customerRepository.GetById(id.Value);

                httpStatusCodeResult = base.View(masterCustomer);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }
        public JsonResult GetAutoCompleteCustomerListByLocationPaybasWithGST(string customerName, short locationId, byte PaybasId, bool allowWalkin)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteCustomerListByLocationPaybasWithGST(locationId, PaybasId, customerName, allowWalkin));
            return jsonResult;
        }
        public JsonResult IsCustomerExistByLocationPaybasWithGST(short locationId, byte paybasId, string customerCode, bool allowWalkIn)
        {
            MasterCustomer masterCustomer = this.customerRepository.IsCustomerExistByLocationPaybasWithGST(locationId, paybasId, customerCode, allowWalkIn);
            if (masterCustomer == null)
            {
                masterCustomer = new MasterCustomer();
            }
            return base.Json(masterCustomer, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetCustomersByPagination(Pagination pagination)
        {
            DTResponse DTResponse = new DTResponse();
            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ?
            "CustomerId asc" : pagination.data.columns[pagination.data.order[0].column].name + " " +
                pagination.data.order[0].dir;
            var customers = this.customerRepository.GetCustomersByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value);
            DTResponse.recordsTotal = customers.FirstOrDefault() == null ? 0 : customers.FirstOrDefault().TotalCustomers;
            DTResponse.recordsFiltered = customers.FirstOrDefault() == null ? 0 : customers.FirstOrDefault().FilterCustomers; //pagination.data.search.value == null? customers.FirstOrDefault().TotalCustomers : customers.Count();
            DTResponse.data = JsonConvert.SerializeObject(customers);
            return Json(DTResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDropDownCustomerList()
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetDropDownCustomerList(SessionUtility.CompanyId));
            return jsonResult;
        }

        [HttpGet]
        public FileResult DownloadExcel()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string ReportName = string.Empty;

            ReportName = "CustomerList.xlsx";
            dt = CustomerListForDownloadExcel();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ReportName);
                }
            }
        }

        protected System.Data.DataTable CustomerListForDownloadExcel()
        {
            DataColumn dt;

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("Customer");

            List<CustomerExcelData> customerExcelData = this.customerRepository.GetCustomerExcelData().ToList();

            dt = new DataColumn();
            dt.Caption = "Sr No.";
            dt.ColumnName = "SrNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Group Code";
            dt.ColumnName = "GroupName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Customer Code";
            dt.ColumnName = "CustomerCode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Customer Name";
            dt.ColumnName = "CustomerName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Industry";
            dt.ColumnName = "IndustryName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "GstTin No";
            dt.ColumnName = "GstTinNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Is Active";
            dt.ColumnName = "IsActive";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Ownership Type";
            dt.ColumnName = "TypeOfOwnershipName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Customer Location";
            dt.ColumnName = "CustomerLocation";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "PayBas";
            dt.ColumnName = "PayBasName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Communication Address 1";
            dt.ColumnName = "Address1";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Communication Address 2";
            dt.ColumnName = "Address2";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "City";
            dt.ColumnName = "CityName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Pincode";
            dt.ColumnName = "Pincode";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Created Name";
            dt.ColumnName = "EntryByName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Created Date";
            dt.ColumnName = "EntryDate";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Update By";
            dt.ColumnName = "UpdateByName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Update Date";
            dt.ColumnName = "UpdateDate";
            dsExport.Tables[0].Columns.Add(dt);

           

            int i = 0;

            foreach (var item in customerExcelData)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                dr["SrNo"] = (i + 1).ToString();
                dr["GroupName"] = item.GroupName;
                dr["CustomerCode"] = item.CustomerCode;
                dr["CustomerName"] = item.CustomerName;
                dr["IndustryName"] = item.IndustryName;
                dr["GstTinNo"] = item.GstTinNo;
                dr["IsActive"] = item.IsActive ? "Yes" : "No";
                dr["TypeOfOwnershipName"] = item.TypeOfOwnershipName;
                dr["CustomerLocation"] = item.CustomerLocation;
                dr["PayBasName"] = item.PayBasName;
                dr["Address1"] = item.Address1;
                dr["Address2"] = item.Address2;
                dr["CityName"] = item.CityName;
                dr["Pincode"] = item.Pincode;
                dr["EntryByName"] = item.EntryByName;
                dr["EntryDate"] = item.EntryDate;
                dr["UpdateByName"] = item.UpdateByName;
                dr["UpdateDate"] = item.UpdateDate;
               
                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        public JsonResult GetAutoCompleteGstCustomerList(string customerCode, byte customerTypeId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteGstCustomerList(customerCode, customerTypeId,SessionUtility.CompanyId));
            return jsonResult;
        }
        public JsonResult GetAutoCompleteGstTinNo(string gstTinNo, byte paybasId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteGstTinNo(gstTinNo,paybasId));
            return jsonResult;
        }
        public JsonResult GetAutoCompletePanNoAndMobileNo(string panNo)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompletePanNoAndMobileNo(panNo));
            return jsonResult;
        }
        public JsonResult GetAutoCompleteMobileNo(string mobileNo, byte paybasId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompleteMobileNo(mobileNo, paybasId));
            return jsonResult;
        }
        public JsonResult GetAutoCompletePanNo(string panNo, byte paybasId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetAutoCompletePanNo(panNo, paybasId));
            return jsonResult;
        }

        public JsonResult GetById(short CustomerId)
        {
            JsonResult jsonResult = base.Json(this.customerRepository.GetById(CustomerId));
            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetCustomerAddressCode(int CustomerAddressId)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            Dic["CustomerAddressCode"]= this.customerRepository.GetCustomerAddressCode(CustomerAddressId);
            return Json(Dic);
        }
    }
}