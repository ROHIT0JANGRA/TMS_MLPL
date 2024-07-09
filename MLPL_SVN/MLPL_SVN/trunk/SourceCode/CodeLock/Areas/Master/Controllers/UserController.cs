using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ICompanyRepository companyRepository;

        public UserController()
        {
        }

        public UserController(
          IUserRepository _userRepository,
          ILocationRepository _locationRepository,
          IRoleRepository _roleRepository,
          IGeneralRepository _generalRepository,
          IWarehouseRepository _warehouseRepository,
          ICompanyRepository companyRepository)
        {
            this.userRepository = _userRepository;
            this.locationRepository = _locationRepository;
            this.roleRepository = _roleRepository;
            this.generalRepository = _generalRepository;
            this.warehouseRepository = _warehouseRepository;
            this.companyRepository = companyRepository;
        }

        public ActionResult Index()
        {
            return (ActionResult)this.View((object)this.userRepository.GetAll());
        }

        private void Init()
        {
            ((dynamic)base.ViewBag).UserTypeList = this.generalRepository.GetByIdList(1);
            dynamic viewBag = base.ViewBag;
            List<AutoCompleteResult> autoCompleteResults = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult = new AutoCompleteResult()
            {
                Value = "true",
                Name = "Permanent"
            };
            autoCompleteResults.Add(autoCompleteResult);
            AutoCompleteResult autoCompleteResult1 = new AutoCompleteResult()
            {
                Value = "false",
                Name = "Contractual"
            };
            autoCompleteResults.Add(autoCompleteResult1);
            viewBag.UserStatusList = autoCompleteResults;

            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).RoleList = this.roleRepository.GetRoleList();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
        }

        public ActionResult Insert()
        {
            this.Init();
            return (ActionResult)this.View((object)new MasterUser()
            {
                CompanyStartDate = new DateTime?(new CompanyRepository().GetById(SessionUtility.CompanyId).StartDate)
            });
        }

        [ValidateAntiModelInjection("UserId")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MasterUser objMasterUser)
        {
            this.Init();
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterUser);
            objMasterUser.EntryBy = SessionUtility.LoginUserId;
            if (objMasterUser.PhotoAttachment != null)
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                DataBaseFactory.QuerySP("Usp_MasterUser_GetMaxUserId", (object)dynamicParameters, "Master User - GetMaxUserId");
                short num = dynamicParameters.Get<short>("@UserId");
                string str;
                if (ConfigHelper.IsLocalStorage)
                {
                    str = num.ToString() + "_" + objMasterUser.PhotoAttachment.FileName;
                    string filename = ConfigHelper.LocalStoragePath + "User/" + str;
                    objMasterUser.PhotoAttachment.SaveAs(filename);
                }
                else
                {
                    str = AzureStorageHelper.GetFileName("User", "DOC_TYPE", objMasterUser.UserName.ToString(), num.ToString(), objMasterUser.PhotoAttachment.FileName);
                    AzureStorageHelper.UploadBlob("User", objMasterUser.PhotoAttachment, str, str);
                }
                objMasterUser.Photo = str;
                objMasterUser.PhotoAttachment = (HttpPostedFileBase)null;
            }
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.userRepository.Insert(objMasterUser)
            });
        }

        public ActionResult Update(short? id)
        {
            this.Init();
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            this.userRepository.GetById(id.Value).CompanyStartDate = new DateTime?(new CompanyRepository().GetById(SessionUtility.CompanyId).StartDate);
            return (ActionResult)this.View((object)this.userRepository.GetById(id.Value));
        }

        [ValidateAntiModelInjection("UserId")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MasterUser objMasterUser)
        {
            this.Init();
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objMasterUser);
            objMasterUser.UpdateBy = new short?(SessionUtility.LoginUserId);
            if (objMasterUser.PhotoAttachment != null)
            {
                string str;
                if (ConfigHelper.IsLocalStorage)
                {
                    if (objMasterUser.Photo != null)
                        System.IO.File.Delete(Path.Combine(ConfigHelper.LocalStoragePath + "User/", objMasterUser.Photo));
                    str = objMasterUser.UserId.ToString() + "_" + objMasterUser.PhotoAttachment.FileName;
                    string filename = ConfigHelper.LocalStoragePath + "User/" + str;
                    objMasterUser.PhotoAttachment.SaveAs(filename);
                }
                else
                {
                    if (objMasterUser.Photo != null)
                        AzureStorageHelper.DeleteBlob("User", objMasterUser.Photo);
                    str = AzureStorageHelper.GetFileName("User", "DOC_TYPE", objMasterUser.UserName.ToString(), objMasterUser.UserId.ToString(), objMasterUser.PhotoAttachment.FileName);
                    AzureStorageHelper.UploadBlob("User", objMasterUser.PhotoAttachment, str, str);
                }
                objMasterUser.Photo = str;
                objMasterUser.PhotoAttachment = (HttpPostedFileBase)null;
            }
            return (ActionResult)this.RedirectToAction("View", (object)new
            {
                id = this.userRepository.Update(objMasterUser)
            });
        }

        public ActionResult ChangePassword(short id)
        {
            return (ActionResult)this.View((object)new ChangePassword()
            {
                UserId = id
            });
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword objChangePassword)
        {
            if (this.ModelState.IsValid)
            {
                objChangePassword.UpdateBy = new short?(SessionUtility.LoginUserId);
                objChangePassword.CompanyId = SessionUtility.CompanyId;
                if (this.userRepository.ChangePassword(objChangePassword).IsSuccessfull)
                {
                    this.TempData["result"] = (object)new Response()
                    {
                        ErrorMessage = "Password reset successfuly",
                        IsSuccessfull = false
                    };
                    return (ActionResult)this.RedirectToAction("Index", "Dashboard", (object)new
                    {
                        area = ""
                    });
                }
            }
            return (ActionResult)this.View((object)objChangePassword);
        }

        public ActionResult View(short? id)
        {
            short? nullable = id;
            if (!(nullable.HasValue ? new int?((int)nullable.GetValueOrDefault()) : new int?()).HasValue)
                return (ActionResult)new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return (ActionResult)this.View((object)this.userRepository.GetById(id.Value));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteUserList(string userName, byte userTypeId)
        {
            return this.Json((object)this.userRepository.GetAutoCompleteUserList(userName, userTypeId));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteUserCodeList(string userName, byte userTypeId)
        {
            return this.Json((object)this.userRepository.GetAutoCompleteUserCodeList(userName, userTypeId));
        }



        [HttpPost]
        public JsonResult GetAutoCompleteUserListByLocationId(
          short locationId,
          string userName)
        {
            return this.Json((object)this.userRepository.GetAutoCompleteUserListByLocationId(locationId, userName));
        }

        [HttpPost]
        public JsonResult IsUserNameExist(string userName, byte userTypeId)
        {
            return this.Json((object)this.userRepository.IsUserNameExist(userName, userTypeId));
        }

        [HttpPost]
        public JsonResult IsUserCodeExist(string userName, byte userTypeId)
        {
            return this.Json((object)this.userRepository.IsUserCodeExist(userName, userTypeId));
        }

        [HttpPost]
        public JsonResult IsUserNameExistByLocation(short locationId, string userName)
        {
            return this.Json((object)this.userRepository.IsUserNameExistByLocation(locationId, userName));
        }

        [HttpPost]
        [ValidateAntiModelInjection("UserId")]
        public JsonResult IsUserNameAvailable(MasterUser objMasterUser)
        {
            return this.Json((object)this.userRepository.IsUserNameAvailable(objMasterUser.UserName, objMasterUser.UserId));
        }

        [HttpPost]
        public JsonResult GetUserNameListByLocationId(short locationId)
        {
            return this.Json((object)this.userRepository.GetUserNameListByLocationId(locationId));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteUserListByRoleId(string userName, byte roleId)
        {
            return this.Json((object)this.userRepository.GetAutoCompleteUserListByRoleId(userName, roleId));
        }

        [HttpPost]
        public JsonResult IsUserNameExistByRoleId(string userName, byte roleId)
        {
            return this.Json((object)this.userRepository.IsUserNameExistByRoleId(userName, roleId));
        }

        [HttpPost]
        public JsonResult GetLocationListByUserId(int userId)
        {
            return this.Json((object)this.userRepository.GetLocationListByUserId(userId));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.userRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
