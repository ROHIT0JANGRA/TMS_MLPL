using CodeLock.Api_Services;
using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class DriverController : Controller
  {
    private readonly IDriverRepository driverRepository;
    private readonly IGeneralRepository generalRepository;


        public DriverController()
        {
        }

        public DriverController(IDriverRepository _driverRepository, IGeneralRepository _generalRepository)
        {
            this.driverRepository = _driverRepository;
            this.generalRepository = _generalRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.driverRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetAutoCompleteDriverListByLocation(string driverName)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetAutoCompleteDriverListByLocation(driverName, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAutoCompleteDriverCodeListByLocation(string driverName)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetAutoCompleteDriverCodeListByLocation(driverName, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        

        [HttpPost]
        public JsonResult GetAutoCompleteDriverList(string driverName)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetAutoCompleteDriverList(driverName));
            return jsonResult;
        }

        public JsonResult GetById(short driverId)
        {
            return base.Json(this.driverRepository.GetById(driverId));
        }

        [HttpPost]
        public JsonResult GetDriverDetailByVehicleId(short vehicleId)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetDriverDetailByVehicleId(SessionUtility.LoginLocationId, vehicleId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDriverListByLocation()
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetDriverListByLocation(SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDriverListByTripSheetRule(short? vehicleId)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetDriverListByTripSheetRule(SessionUtility.LoginLocationId, vehicleId));
            return jsonResult;
        }

        //public ActionResult Index()
        //{
        //    return base.View(this.driverRepository.GetAll());
        //}

        public ActionResult Insert()
        {
            MasterDriver masterDriver = new MasterDriver()
            {
                DocumentDetails = new List<DriverDocument>()
            };
            List<DriverDocument> documentDetails = masterDriver.DocumentDetails;
            DriverDocument driverDocument = new DriverDocument()
            {
                DocumentTypeId = 0,
                DocumentName = ""
            };
            documentDetails.Add(driverDocument);
            ((dynamic)base.ViewBag).EthnicityList = this.generalRepository.GetByIdList(37);
            ((dynamic)base.ViewBag).DriverDocumentList = this.generalRepository.GetByIdList(43);
            return base.View(masterDriver);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("DriverId")]
        public ActionResult Insert(MasterDriver objMasterDriver)
        {
            List<DriverDocument> driverDocuments = new List<DriverDocument>();
            // DriverDocument documentDetail = null;
            Response response;
            ActionResult action;
            long documentId;
            for (int i = 0; objMasterDriver.DocumentDetails.Count > i; i++)
            {
                base.ModelState.Remove(string.Concat("DocumentDetails[", i, "].DocumentTypeId"));
            }
            if (base.ModelState.IsValid)
            {
                if (objMasterDriver.VehicleNo == "" || objMasterDriver.VehicleNo == null)
                {
                    objMasterDriver.VehicleId = 0;
                }

                objMasterDriver.EntryBy = SessionUtility.LoginUserId;
                foreach (DriverDocument documentDetail in objMasterDriver.DocumentDetails)
                {
                    DriverDocument driverDocument = new DriverDocument()
                    {
                        DocumentTypeId = documentDetail.DocumentTypeId,
                        DocumentName = "",
                        DocumentAttachment = documentDetail.DocumentAttachment
                    };
                    driverDocuments.Add(driverDocument);
                }
                objMasterDriver.DocumentDetails.RemoveAll((DriverDocument m) => m.DocumentAttachment != null);
                response = this.driverRepository.Insert(objMasterDriver);

                foreach (DriverDocument num in driverDocuments)
                {
                    if ((num.DocumentAttachment == null ? false : num.DocumentTypeId != 0))
                    {
                        string fileName = "";
                        if (!ConfigHelper.IsLocalStorage)
                        {
                            byte documentTypeId = num.DocumentTypeId;
                            string str = string.Concat("DOC_TYPE", documentTypeId.ToString());
                            string str1 = objMasterDriver.ManualDriverCode.ToString();
                            documentId = response.DocumentId;
                            fileName = AzureStorageHelper.GetFileName("Driver", str, str1, documentId.ToString(), num.DocumentAttachment.FileName);
                            AzureStorageHelper.UploadBlob("Driver", num.DocumentAttachment, fileName, fileName);
                        }
                        else
                        {
                            documentId = response.DocumentId;
                            fileName = string.Concat(documentId.ToString(), "_", num.DocumentAttachment.FileName);
                            string FileLoc = Server.MapPath("~/Storage/Driver/");

                            if (System.IO.Directory.Exists(FileLoc)) { }
                            else
                            {
                                System.IO.Directory.CreateDirectory(FileLoc);
                            }
                            string str2 = Path.Combine(Server.MapPath("~/Storage/Driver/"), fileName);
                            //string str2 = string.Concat(ConfigHelper.StoragePath, "Driver/", fileName);
                            num.DocumentAttachment.SaveAs(str2);
                        }
                        num.DocumentName = fileName;
                        num.DocumentAttachment = null;
                        num.DriverId = response.DocumentId.ConvertToShort();
                        this.driverRepository.DocumentInsert(num);
                    }
                }
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
            }
            action = base.View(objMasterDriver);
            //return action;

            //((dynamic)base.ViewBag).EthnicityList = this.generalRepository.GetByIdList(37);
            //((dynamic)base.ViewBag).DriverDocumentList = this.generalRepository.GetByIdList(43);

            return action;
        }

        public async Task<dynamic> FetchDriverDetailsFromApi(string dlNo, string dlDobDate)
        {
            string token = UlipTokenManagerController.GetTokenId();
            if (string.IsNullOrEmpty(token))
            {
                token = await UlipTokenManagerController.GenerateToken();
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var requestBody = new
                {
                    dlnumber = dlNo,
                    dob = dlDobDate
                };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://www.ulipstaging.dpiit.gov.in/ulip/v1.0.0/SARATHI/01", content);
                var statusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return Json(responseData);
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

        [HttpPost]
        public JsonResult IsDriverNameExistByLocation(string driverName)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.IsDriverNameExistByLocation(driverName, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsDriverCodeExistByLocation(string driverName)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.IsDriverCodeExistByLocation(driverName, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsDriverNameExist(string driverName)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.IsDriverNameExist(driverName));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLocationListByDriverId(int driverId)
        {
            JsonResult jsonResult = base.Json(this.driverRepository.GetLocationListByDriverId(driverId));
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
                MasterDriver masterDriver = new MasterDriver();
                masterDriver = this.driverRepository.GetById((int)id.Value);
                if (masterDriver.DocumentDetails.Count == 0)
                {
                    List<DriverDocument> documentDetails = masterDriver.DocumentDetails;
                    DriverDocument driverDocument = new DriverDocument()
                    {
                        DocumentTypeId = 0,
                        DocumentName = ""
                    };
                    documentDetails.Add(driverDocument);
                }
                ((dynamic)base.ViewBag).EthnicityList = this.generalRepository.GetByIdList(37);
                ((dynamic)base.ViewBag).DriverDocumentList = this.generalRepository.GetByIdList(43);
                httpStatusCodeResult = base.View(masterDriver);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("DriverId")]
        public ActionResult Update(MasterDriver objMasterDriver)
        {
            for (int index = 0; objMasterDriver.DocumentDetails.Count > index; ++index)
                this.ModelState.Remove("DocumentDetails[" + (object)index + "].DocumentTypeId");
            if (this.ModelState.IsValid)
            {
                if (objMasterDriver.VehicleNo == "" || objMasterDriver.VehicleNo == null)
                {
                    objMasterDriver.VehicleId = 0;
                }

                objMasterDriver.UpdateBy = new short?(SessionUtility.LoginUserId);
                List<DriverDocument> driverDocumentList = new List<DriverDocument>();
                foreach (DriverDocument documentDetail in objMasterDriver.DocumentDetails)
                {
                    DriverDocument driverDocument = new DriverDocument()
                    {
                        DocumentTypeId = documentDetail.DocumentTypeId,
                        DocumentName = "",
                        DocumentAttachment = documentDetail.DocumentAttachment
                    };
                    driverDocumentList.Add(driverDocument);
                }
                objMasterDriver.DocumentDetails.RemoveAll((Predicate<DriverDocument>)(m => m.DocumentAttachment != null));
                Response response = this.driverRepository.Update(objMasterDriver);
                if (response.IsSuccessfull)
                {
                    string FileLoc = Server.MapPath("~/Storage/Driver/");

                    if (System.IO.Directory.Exists(FileLoc)) { }
                    else
                    {
                        System.IO.Directory.CreateDirectory(FileLoc);
                    }

                    foreach (DriverDocument objDriverDocument in driverDocumentList)
                    {
                        if (objDriverDocument.DocumentAttachment != null && objDriverDocument.DocumentTypeId != (byte)0)
                        {
                            DynamicParameters dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@DriverId", (object)objMasterDriver.DriverId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                            dynamicParameters.Add("@DocumentTypeId", (object)objDriverDocument.DocumentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                            dynamicParameters.Add("@DocumentName", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(200));
                            DataBaseFactory.QuerySP("Usp_MasterDriver_GetDocumentNameByDriverIdAndDocumentTypeId", (object)dynamicParameters, "Master Driver - GetDocumentNameByDriverIdAndDocumentTypeId");
                            string str1 = dynamicParameters.Get<string>("@DocumentName");
                            long documentId;
                            string str2;

                            documentId = response.DocumentId;
                            string filename = documentId.ToString() + "_" + objDriverDocument.DocumentAttachment.FileName;
                            // string filename = ConfigHelper.StoragePath + "Driver/" + str2;
                            str2 = Path.Combine(Server.MapPath("~/Storage/Driver/"), filename);

                            objDriverDocument.DocumentAttachment.SaveAs(str2);

                            objDriverDocument.DocumentName = filename;
                            objDriverDocument.DocumentAttachment = (HttpPostedFileBase)null;
                            objDriverDocument.DriverId = response.DocumentId.ConvertToShort();
                            int num = (int)this.driverRepository.DocumentUpdate(objDriverDocument);
                        }
                    }
                    return (ActionResult)this.RedirectToAction("View", (object)new
                    {
                        id = response.DocumentId
                    });
                }
            }
            return (ActionResult)this.View((object)objMasterDriver);
        }

        public ActionResult View(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
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
                httpStatusCodeResult = base.View(this.driverRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }
        public ActionResult Index()
        {
            return base.View();
        }
        [HttpPost]
        public ActionResult GetDriverListByPagination(Pagination pagination)
        {
            DTResponse DTResponse = new DTResponse();

            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ? "DriverId  asc" : pagination.data.columns[pagination.data.order[0].column].name + " " + pagination.data.order[0].dir;
            var customers = this.driverRepository.GetDriversByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value);
            DTResponse.recordsTotal = customers.FirstOrDefault() == null ? 0 : customers.FirstOrDefault().TotalDrivers;
            DTResponse.recordsFiltered = customers.FirstOrDefault() == null ? 0 : customers.FirstOrDefault().FilterDriver; //pagination.data.search.value == null? customers.FirstOrDefault().TotalCustomers : customers.Count();
            DTResponse.data = JsonConvert.SerializeObject(customers);
            return Json(DTResponse, JsonRequestBehavior.AllowGet);

        }
   
    }
}
