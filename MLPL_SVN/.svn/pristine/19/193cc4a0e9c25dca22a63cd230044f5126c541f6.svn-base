using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using CodeLock.Repository;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Services;

namespace CodeLock.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository homeRepository;
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IDocketRepository docketRepository;
        private readonly IRulesRepository rulesRepository;

        public HomeController()
        {
        }

        public HomeController(IHomeRepository _homeRepository, IUserRepository _userRepository, ICompanyRepository _companyRepository, IWarehouseRepository _warehouseRepository, ILocationRepository _locationRepository, IMenuRepository _menuRepository, IDocketRepository _docketRepository, IRulesRepository _rulesRepository)
        {
            this.homeRepository = _homeRepository;
            this.userRepository = _userRepository;
            this.companyRepository = _companyRepository;
            this.warehouseRepository = _warehouseRepository;
            this.locationRepository = _locationRepository;
            this.menuRepository = _menuRepository;
            this.docketRepository = _docketRepository;
            this.rulesRepository = _rulesRepository;
        }

        public ActionResult IndexDocket()
        {
            ActionResult action;
            action = base.View();
            return action;
        }
        public ActionResult IndexDocketStatus(string DocketNo)
        {
            CodeLock.Models.DocketStatus objStatus = new Models.DocketStatus();
            objStatus.StatusDate = DateTime.Now;

            objStatus = this.homeRepository.DocketStatusGetByCode(DocketNo);
            objStatus.ShowPaybas = this.rulesRepository.GetModuleRuleByIdAndRuleId(1, 205) == "Y";
            return base.View(objStatus);
        }

        [HttpPost]
        public ActionResult IndexDocketStatus(DocketStatus obj)
        {
            return base.RedirectToAction("IndexDocket");
        }

        [HttpPost]
        public ActionResult IndexDocket(DocketStatus obj)
        {
            bool flag = this.homeRepository.IsDocketNoAvailable(obj.DocketNo, 0);

            if (flag == false)
            {
                return base.RedirectToAction("IndexDocketStatus", new { DocketNo = obj.DocketNo });
            }

            return base.View(obj);
        }

        public PartialViewResult AddUserPartialView()
        {
            base.ModelState.AddModelError("MasterUser", "Some Error.");
            return this.PartialView("AddUserPartialView", new MasterUser());
        }

        public ActionResult Dashboard()
        {
            ((dynamic)base.ViewBag).MenuList = this.menuRepository.GetMenuListByUserId(SessionUtility.LoginUserId, SessionUtility.CompanyId);
            return base.View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.userRepository.Dispose();
                this.companyRepository.Dispose();
                this.warehouseRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Error(int id)
        {
            ((dynamic)base.ViewBag).ErrorId = id;
            return base.View();
        }

        [HttpPost]
        public JsonResult GetAppSettingById(short id)
        {
            JsonResult jsonResult = base.Json(this.homeRepository.GetAppSettingById(id), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult Index()
        {
            ActionResult action;
            if (!string.IsNullOrEmpty(SessionUtility.LoginUserName))
            {
                action = base.RedirectToAction("Index", "Dashboard");
            }
            else if (!(ConfigurationManager.AppSettings["IsLocalEnvironment"] == "Y"))
            {
                action = base.View();
            }
            else
            {
                this.ManageSession(this.userRepository.GetByUserName("Admin"));
                action = base.RedirectToAction("Index", "Dashboard");
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login objLogin)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                MasterUser byUserName = this.userRepository.GetByUserName(objLogin.UserName);
                if (byUserName == null)
                {
                    base.ModelState.AddModelError("UserName", "Invalid User Name");
                }
                else if (byUserName.IsActive)
                {
                    if (byUserName.Password != objLogin.Password)
                    {
                        base.ModelState.AddModelError("Password", "Invalid Password");
                        action = base.View(objLogin);
                        return action;
                    }
                    this.ManageSession(byUserName);
                    action = base.RedirectToAction("Index", "Dashboard");
                    return action;
                }
                else
                {
                    base.ModelState.AddModelError("UserName", "Inactive User");
                }
            }
            action = base.View(objLogin);
            return action;
        }

        public ActionResult Logout()
        {
            base.Session.Clear();
            base.Session.RemoveAll();
            base.Session.Abandon();
            base.Session.Abandon();
            base.Response.AddHeader("Cache-control", "no-store, must-revalidate, private,no-cache");
            base.Response.AddHeader("Pragma", "no-cache");
            base.Response.AddHeader("Expires", "0");
            base.Response.AppendToLog("window.location.reload();");
            return base.RedirectToAction("Index", "Home");
        }

        private void ManageSession(MasterUser objMasterUser)
        {
            DateTime now;
            string str;
            SessionUtility.LoginUserId = objMasterUser.UserId;
            SessionUtility.LocationHierarchyId = objMasterUser.LocationHierarchyId;
            SessionUtility.LoginUserName = objMasterUser.UserName;
            SessionUtility.LoginUserLocationId = objMasterUser.LocationId;
            SessionUtility.LoginLocationId = objMasterUser.LocationId;
            SessionUtility.LoginLocationCode = objMasterUser.LocationCode;
            SessionUtility.CompanyId = objMasterUser.DefaultCompanyId.ConvertToByte();
            SessionUtility.WarehouseId = objMasterUser.DefaultWarehouseId.ConvertToShort();
            SessionUtility.CompanyCode = objMasterUser.DefaultCompanyCode;
            SessionUtility.CompanyName = objMasterUser.DefaultCompanyName;
            SessionUtility.WarehouseName = objMasterUser.DefaultWarehouseName;
            SessionUtility.LoginUserRoleName = objMasterUser.RoleName;
            SessionUtility.DocketNomenClature = this.homeRepository.GetAppSettingById(Nomenclature.DocketNomenclature);
            SessionUtility.PrsNomenclature = this.homeRepository.GetAppSettingById(Nomenclature.PrsNomenclature);
            SessionUtility.LoadingSheetNomenclature = this.homeRepository.GetAppSettingById(Nomenclature.LoadingSheetNomenclature);
            SessionUtility.ManifestNomenclature = this.homeRepository.GetAppSettingById(Nomenclature.ManifestNomenclature);
            SessionUtility.ThcNomenclature = this.homeRepository.GetAppSettingById(Nomenclature.ThcNomenclature);
            SessionUtility.DrsNomenclature = this.homeRepository.GetAppSettingById(Nomenclature.DrsNomenclature);
            if (DateTime.Now.Month >= 4)
            {
                string str1 = DateTime.Now.ToString("yy");
                now = DateTime.Now.AddYears(1);
                str = string.Concat(str1, now.ToString("yy"));
            }
            else
            {
                now = DateTime.Now.AddYears(-1);
                string str2 = now.ToString("yy");
                now = DateTime.Now;
                str = string.Concat(str2, now.ToString("yy"));
            }
            string str3 = str;
            SessionUtility.ManageFinYear(str3, this.companyRepository.GetVirtualLoginFinanceYearById(str3));
        }

        public ActionResult Test()
        {
            return base.View(new Docket());
        }

        public ActionResult VirtualLogin(short? id, byte? companyId, short? warehouseId, string finYearId)
        {
            int? nullable;
            int? nullable1;
            int? nullable2;
            int? nullable3;
            short? nullable4 = id;
            if (nullable4.HasValue)
            {
                nullable1 = new int?(nullable4.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                SessionUtility.LoginLocationId = id.ConvertToShort();
                SessionUtility.LoginLocationCode = this.locationRepository.GetById(SessionUtility.LoginLocationId).LocationCode;
                SessionUtility.LocationHierarchyId = this.locationRepository.GetById(SessionUtility.LoginLocationId).LocationHierarchyId;
            }
            byte? nullable5 = companyId;
            if (nullable5.HasValue)
            {
                nullable2 = new int?((int)nullable5.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable2 = nullable;
            }
            nullable = nullable2;
            if (nullable.HasValue)
            {
                SessionUtility.CompanyId = companyId.ConvertToByte();
                MasterCompany byId = this.companyRepository.GetById(SessionUtility.CompanyId);
                SessionUtility.CompanyCode = byId.CompanyCode;
                SessionUtility.CompanyName = byId.CompanyName;
            }
            nullable4 = warehouseId;
            if (nullable4.HasValue)
            {
                nullable3 = new int?(nullable4.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable3 = nullable;
            }
            nullable = nullable3;
            if (nullable.HasValue)
            {
                SessionUtility.WarehouseId = warehouseId.ConvertToShort();
                SessionUtility.WarehouseName = this.warehouseRepository.GetById(SessionUtility.WarehouseId).WarehouseName;
            }
            if (!string.IsNullOrEmpty(finYearId))
            {
                SessionUtility.ManageFinYear(finYearId, this.companyRepository.GetVirtualLoginFinanceYearById(finYearId));
            }
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetVirtualLoginCompanyList(SessionUtility.LoginUserId);
            ((dynamic)base.ViewBag).WarehouseList = this.warehouseRepository.GetVirtualLoginWarehouseList(SessionUtility.LoginUserId);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationListByLocationId(SessionUtility.LoginLocationId, SessionUtility.LoginUserLocationId);
            ((dynamic)base.ViewBag).FinYearList = this.companyRepository.GetVirtualLoginFinanceYearListByUserId(SessionUtility.LoginUserId);
            return base.View();
        }

        public JsonResult CheckValidDocketNo(string docketNo)
        {
            SessionUtility.LoginUserId = 1;
            SessionUtility.LoginUserName = "Admin";
            return base.Json(this.docketRepository.CheckValidDocketNoForSolex(docketNo));
        }

        public ActionResult BarcodePrint(long id)
        {
            ViewBag.WCPPDetectionScript = Neodynamic.SDK.Web.WebClientPrint.CreateWcppDetectionScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);
            ViewBag.WCPScript = Neodynamic.SDK.Web.WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), "", HttpContext.Session.SessionID);
            return View();
        }

        public ActionResult Samples()
        {
            return View();
        }

        public ActionResult PrintersInfo()
        {
            ViewBag.WCPScript = Neodynamic.SDK.Web.WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), "", HttpContext.Session.SessionID);

            return View();
        }

        public ActionResult printinfo(DocketBarcodePrint person)
        {
            return View();
        }

        [WebMethod]
        public string GetDocketBarcodeInfo(DocketBarcodePrint docketBarcodePrint)
        {
            DataTable dsResult = new DataTable();
            string JSONString = string.Empty;
            dsResult = docketRepository.GetDocketBarcodeInfo(docketBarcodePrint.DocketId);
            if (dsResult != null)
                JSONString = JsonConvert.SerializeObject(dsResult);
            return JSONString;
        }

        [WebMethod]
        public string BarCodePrintersInfo()
        {
            string JSONString = string.Empty;
            List<LocationCodePrint> licodeprint = new List<LocationCodePrint>();
            LocationCodePrint objLocationCodePrint = new LocationCodePrint();
            objLocationCodePrint = (LocationCodePrint)Session["objLocationCodePrint"];
            string[] lines = objLocationCodePrint.DocketNo.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (objLocationCodePrint.PRINTTYPE == "BinCodeLabel")
            {
                for (int i = 0; i <= lines.Length - 1; i++)
                {
                    //String[] arrstr = objLocationCodePrint.USNNO.Split(',');
                    LocationCodePrint l = new LocationCodePrint
                    {
                        DocketNo = lines[i],
                        PRINTTYPE = objLocationCodePrint.PRINTTYPE,
                    };
                    licodeprint.Add(l);
                }
                JSONString = JsonConvert.SerializeObject(licodeprint);
            }
            else if (objLocationCodePrint.PRINTTYPE == "USN_Reprint_Label_Param1_USN")
            {
                for (int i = 0; i <= lines.Length - 1; i++)
                {
                    DataTable dsResult = new DataTable();
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CodeLockDBConnection"].ToString()))
                    {
                        SqlCommand sqlComm = new SqlCommand("Isourse_PrintBarCode_USN", conn);
                        sqlComm.Parameters.AddWithValue("@DocketNo", lines[i].Split(',')[0]);


                        sqlComm.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlComm;

                        da.Fill(dsResult);
                    }
                    if (dsResult != null && dsResult.Rows.Count > 0)
                    {

                        for (int r = 1; r <= Convert.ToInt32(lines[i].Split(',')[1]); r++)
                        {
                            LocationCodePrint l = new LocationCodePrint
                            {
                                DocketNo = dsResult.Rows[0]["DocketNo"].ToString(),
                                FromLocation = dsResult.Rows[0]["SkuName"].ToString(),
                                EntryDate = dsResult.Rows[0]["EntryDate"].ToString(),
                                PRICE = dsResult.Rows[0]["MsrpMrp"].ToString(),
                                PRINTTYPE = objLocationCodePrint.PRINTTYPE,
                                USNCOUNT = lines[i].Split(',')[1].ToString(),

                            };
                            licodeprint.Add(l);
                        }
                        JSONString = JsonConvert.SerializeObject(licodeprint);
                    }

                }
            }
            return JSONString;

        }

    }
}
