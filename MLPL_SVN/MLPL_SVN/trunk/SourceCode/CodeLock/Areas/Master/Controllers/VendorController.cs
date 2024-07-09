﻿using ClosedXML.Excel;
using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class VendorController : Controller
  {
    private readonly IVendorRepository vendorRepository;
    private readonly IGeneralRepository generalRepository;
    private readonly ILocationRepository locationRepository;
    private readonly IAccountRepository accountRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IStateRepository stateRepository;
        private readonly ICityRepository cityRepository;
        private readonly IGstRepository gstRepository;
        private readonly IWarehouseRepository warehouseRepository;
        public VendorController()
        {
        }

        public VendorController(IVendorRepository _vendorRepository, IGeneralRepository _generalRepository, ILocationRepository _locationRepository, IAccountRepository  _accountRepository,ICountryRepository _countryRepository,IStateRepository _stateRepository, ICityRepository _cityRepository, IGstRepository _gstRepository, IWarehouseRepository _warehouseRepository)
        {
            this.vendorRepository = _vendorRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.accountRepository = _accountRepository;
            this.countryRepository = _countryRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
            this.gstRepository = _gstRepository;
            this.warehouseRepository = _warehouseRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.vendorRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetAutoCompleteListForFuelPumpVendor(string vendorCode)
        {
            return base.Json(this.vendorRepository.GetAutoCompleteListForFuelPumpVendor(vendorCode));
        }

        public JsonResult GetAutoCompleteVendorList(string vendorCode, byte vendorTypeId)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.GetAutoCompleteVendorList(vendorCode, vendorTypeId));
            return jsonResult;
        }

        public JsonResult GetAutoCompleteVendorListByLocation(string vendorCode, byte vendorTypeId)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.GetAutoCompleteVendorListByLocation(vendorCode, vendorTypeId, SessionUtility.LoginLocationId));
            return jsonResult;
        }


        [HttpPost]
        public JsonResult GetById(short vendorId)
        {
            return base.Json(this.vendorRepository.GetById((short)vendorId));
        }

        public JsonResult GetLocationListByVendorId(short VendorId)
        {
            return base.Json(this.vendorRepository.GetLocationListByVendorId(VendorId));
        }

        public JsonResult GetVenderTypeByVehicleId(short vehicleId)
        {
            return base.Json(this.vendorRepository.GetVenderTypeByVehicleId(vehicleId));
        }

        [HttpPost]
        public JsonResult GetVendorListByVendorTypeId(byte vendorTypeId)
        {
            return base.Json(this.vendorRepository.GetVendorListByVendorTypeId(vendorTypeId));
        }
        [HttpPost]
        public JsonResult GetAutoCompleteVendorListByLocationforFuel(short locationId)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.GetAutoCompleteVendorListByLocationforFuel(SessionUtility.LoginLocationId));
            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetVendorNameByVendorTypeId(byte vendorTypeId)
        {
            return base.Json(this.vendorRepository.GetVendorNameByVendorTypeId((short)vendorTypeId));
        }

        public JsonResult GetVendorServiceByVendorId(short vendorId)
        {
            return base.Json(this.vendorRepository.GetVendorServiceByVendorId(vendorId));
        }

        //public ActionResult Index()
        //{
        //    //ActionResult actionResult = base.View(
        //    //    from m in this.vendorRepository.GetAll()
        //    //    where m.VendorId != 1
        //    //    select m);

        //    ActionResult actionResult = base.View(this.vendorRepository.GetAll());
        //    return actionResult;
        //}

        public ActionResult Insert()
        {
            MasterVendor masterVendor = new MasterVendor();
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).VendorWarehouseList = this.warehouseRepository.GetWarehouseList();
            ((dynamic)base.ViewBag).ServiceList = this.generalRepository.GetByIdList(28);
            //((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();
            ((dynamic)base.ViewBag).TdsAccountList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            
            masterVendor.PayBas = this.generalRepository.GetByGeneralList(14).ToArray<MasterGeneral>();
            for (int i = 0; i < masterVendor.PayBas.Length; i++)
            {
                masterVendor.PayBas[i].IsActive = false;
            }

            return base.View(masterVendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("VendorId")]
        public ActionResult Insert(MasterVendor objMasterVendor)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objMasterVendor);
            }
            else
            {
                objMasterVendor.MasterVendorDetail.EntryBy = SessionUtility.LoginUserId;
                if (objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment != null)
                {
                    DynamicParameters dynamicParameter = new DynamicParameters();
                    int? nullable = null;
                    byte? nullable1 = null;
                    byte? nullable2 = nullable1;
                    nullable1 = null;
                    dynamicParameter.Add("@VendorId", null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), nullable, nullable2, nullable1);
                    DataBaseFactory.QuerySP("Usp_MasterVendor_GetMaxVendorId", dynamicParameter, "Master Vendor - GetMaxVendorId");
                    short num = dynamicParameter.Get<short>("@VendorId");
                    string fileName = "";
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        fileName = AzureStorageHelper.GetFileName("Vendor", "TDS_CERTIFICATE", objMasterVendor.VendorName.ToString(), num.ToString(), objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment.FileName);
                        AzureStorageHelper.UploadBlob("Vendor", objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment, fileName, fileName);
                    }
                    else
                    {
                        fileName = string.Concat(num.ToString(), "_", objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment.FileName);
                        string str = string.Concat(ConfigHelper.LocalStoragePath, "Vendor/", fileName);
                        objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment.SaveAs(str);
                    }
                    objMasterVendor.MasterVendorDetail.TdsCertificate = fileName;
                    objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment = null;
                }
                short num1 = this.vendorRepository.Insert(objMasterVendor);
                action = base.RedirectToAction("View", new { id = num1 });
            }
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).VendorWarehouseList = this.warehouseRepository.GetWarehouseList();
            ((dynamic)base.ViewBag).ServiceList = this.generalRepository.GetByIdList(28);
            //((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();
            ((dynamic)base.ViewBag).TdsAccountList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            return action;
        }

        public JsonResult IsVendorCodeExist(string vendorCode, byte vendorTypeId)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.IsVendorCodeExist(vendorCode, vendorTypeId));
            return jsonResult;
        }

        public JsonResult IsVendorCodeExistByLocation(string vendorCode, byte vendorTypeId)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.IsVendorCodeExistByLocation(vendorCode, vendorTypeId, SessionUtility.LoginLocationId));
            return jsonResult;
        }

        [HttpPost]
        [ValidateAntiModelInjection("VendorId")]
        public JsonResult IsVendorNameAvailable(MasterVendor objMasterVendor)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.IsVendorNameAvailable(objMasterVendor.VendorName, objMasterVendor.VendorId));
            return jsonResult;
        }

        public ActionResult Update(short? id)
        {
            ActionResult httpStatusCodeResult;

            int? nullable;
            int? nullable1;
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).VendorWarehouseList = this.warehouseRepository.GetWarehouseList();
            ((dynamic)base.ViewBag).ServiceList = this.generalRepository.GetByIdList(28);
            ((dynamic)base.ViewBag).TdsAccountList = this.accountRepository.GetAccountListByAccountCategoryId(9);
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();
            List<AutoCompleteResult> vendorGstStateList = new List<AutoCompleteResult>();
            var vendorGstState = this.gstRepository.GetGstStateList(5, (long)id,0);
            foreach(var item in vendorGstState)
            {
                vendorGstStateList.Add(new AutoCompleteResult() { Name = item.Name,Value = item.Description });
            }
            ((dynamic)base.ViewBag).VendorGstStateList = vendorGstStateList;

            List<AutoCompleteResult> companyGstStateList = new List<AutoCompleteResult>();
            var companyGstState = this.gstRepository.GetGstStateList(1, SessionUtility.CompanyId, 0);
            foreach (var item in companyGstState)
            {
                companyGstStateList.Add(new AutoCompleteResult() { Name = item.Name, Value = item.Description });
            }
            ((dynamic)base.ViewBag).CompanyGstStateList = companyGstStateList;

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
                MasterVendor masterVendor = new MasterVendor();
                masterVendor = this.vendorRepository.GetById(id.Value);
                //     this.Init(objCustomer.MasterCustomerAddressInfo.CountryId, objCustomer.MasterCustomerAddressInfo.StateId);
                masterVendor.PayBas = this.generalRepository.GetByGeneralList(14).ToArray<MasterGeneral>();

                for (int i = 0; i < masterVendor.PayBas.Length; i++)
                {
                    masterVendor.PayBas[i].IsActive = false;
                }
                int PayBasId = 2;


                httpStatusCodeResult = base.View(this.vendorRepository.GetById(id.Value));
                
                
                httpStatusCodeResult = base.View(masterVendor);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("VendorId")]
        public ActionResult Update(MasterVendor objMasterVendor)
        {
            ActionResult action;
            short vendorId;
            base.ModelState.Remove("MasterVendorDetail.Password");
            base.ModelState.Remove("MasterVendorDetail.CityId");
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
                ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
                ((dynamic)base.ViewBag).VendorWarehouseList = this.warehouseRepository.GetWarehouseList();
                ((dynamic)base.ViewBag).ServiceList = this.generalRepository.GetByIdList(28);
                ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityList();
                ((dynamic)base.ViewBag).TdsAccountList = this.accountRepository.GetAccountListByAccountCategoryId(9);

               
                action = base.View(objMasterVendor);
            }
            else
            {
                objMasterVendor.MasterVendorDetail.UpdateBy = new short?(SessionUtility.LoginUserId);
                if (objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment != null)
                {
                    string fileName = "";
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        if (objMasterVendor.MasterVendorDetail.TdsCertificate != null)
                        {
                            AzureStorageHelper.DeleteBlob("Vendor", objMasterVendor.MasterVendorDetail.TdsCertificate);
                        }
                        string str = objMasterVendor.VendorName.ToString();
                        vendorId = objMasterVendor.VendorId;
                        fileName = AzureStorageHelper.GetFileName("Vendor", "TDS_CERTIFICATE", str, vendorId.ToString(), objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment.FileName);
                        AzureStorageHelper.UploadBlob("Vendor", objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment, fileName, fileName);
                    }
                    else
                    {
                        if (objMasterVendor.MasterVendorDetail.TdsCertificate != null)
                        {
                            string str1 = Path.Combine(string.Concat(ConfigHelper.LocalStoragePath, "Vendor/"), objMasterVendor.MasterVendorDetail.TdsCertificate);
                            System.IO.File.Delete(str1);
                        }
                        vendorId = objMasterVendor.VendorId;
                        fileName = string.Concat(vendorId.ToString(), "_", objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment.FileName);
                        string str2 = string.Concat(ConfigHelper.LocalStoragePath, "Vendor/", fileName);
                        objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment.SaveAs(str2);
                    }
                    objMasterVendor.MasterVendorDetail.TdsCertificate = fileName;
                    objMasterVendor.MasterVendorDetail.TdsCertificateDocumentAttachment = null;
                }
                short num = this.vendorRepository.Update(objMasterVendor);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
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
                httpStatusCodeResult = base.View(this.vendorRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


        [HttpGet]
        public FileResult DownloadExcel()
        {
            DataTable dt = new DataTable();
            string ReportName = string.Empty;
            ReportName = "VendorList.xlsx";
            dt = VendorListForDownloadExcel();
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
        protected DataTable VendorListForDownloadExcel()
        {
            DataColumn dt;
            DataSet dsExport = new DataSet();
            dsExport.Tables.Add("Vendor");
            IEnumerable<VendorExcelData> vendorExcelData = this.vendorRepository.GetVendorExcelData();
            dt = new DataColumn();
            dt.Caption = "Vendor Name.";
            dt.ColumnName = "VendorName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor Type.";
            dt.ColumnName = "VendorTypeName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Mobile No";
            dt.ColumnName = "MobileNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Email Id";
            dt.ColumnName = "EmailId";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Address";
            dt.ColumnName = "Address";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "City";
            dt.ColumnName = "CityName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Is Active";
            dt.ColumnName = "IsActive";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor Location";
            dt.ColumnName = "VendorLocationName";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "PAN No";
            dt.ColumnName = "PanNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "GstTin No";
            dt.ColumnName = "GstTinNo";
            dsExport.Tables[0].Columns.Add(dt);

            dt = new DataColumn();
            dt.Caption = "Vendor Service";
            dt.ColumnName = "VendorServiceName";
            dsExport.Tables[0].Columns.Add(dt);

            int i = 0;
            foreach (var item in vendorExcelData)
            {
                DataRow dr = dsExport.Tables[0].NewRow();
                
                dr["VendorName"] = item.VendorName;
                dr["VendorTypeName"] = item.VendorTypeName;
                dr["MobileNo"] = item.MobileNo;
                dr["EmailId"] = item.EmailId;
                dr["Address"] = item.Address;
                dr["CityName"] = item.CityName;
                dr["IsActive"] = item.IsActive ? "Yes" : "No" ;
                dr["VendorLocationName"] = item.VendorLocationName;
                dr["PanNo"] = item.PanNo;
                dr["GstTinNo"] = item.GstTinNo;
                dr["VendorServiceName"] = item.VendorServiceName;

                dsExport.Tables[0].Rows.Add(dr);
                i = i + 1;
            }
            return dsExport.Tables[0];
        }

        public JsonResult GetWarehouseListByVendorId(short VendorId)
        {
            JsonResult jsonResult = base.Json(this.vendorRepository.GetWarehouseListByVendorId(VendorId));
            return jsonResult;
        }

        public ActionResult Index()
        {
            return base.View();
        }


        [HttpPost]
        public JsonResult GetVendorsByPagination(Pagination pagination)
        {
            DTResponse DTResponse = new DTResponse();
            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ?
            "VendorId asc" : pagination.data.columns[pagination.data.order[0].column].name + " " +
                pagination.data.order[0].dir;
            var Vendors = this.vendorRepository.GetVendorsByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value);
            DTResponse.recordsTotal = Vendors.FirstOrDefault() == null ? 0 : Vendors.FirstOrDefault().TotalVendors;
             DTResponse.recordsFiltered = Vendors.FirstOrDefault() == null ? 0 : Vendors.FirstOrDefault().FilterVendors; //pagination.data.search.value == null? customers.FirstOrDefault().TotalCustomers : customers.Count();
            DTResponse.data = JsonConvert.SerializeObject(Vendors);
            return Json(DTResponse, JsonRequestBehavior.AllowGet);
        }


    }
}