using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class UserCompanyController : Controller
  {
    private readonly IUserCompanyRepository userCompanyRepository;
    private readonly IUserRepository userRepository;

    public UserCompanyController()
    {
    }

    public UserCompanyController(
      IUserCompanyRepository _userCompanyRepository,
      IUserRepository _userRepository)
    {
      this.userCompanyRepository = _userCompanyRepository;
      this.userRepository = _userRepository;
    }

    public ActionResult UserVehicleIndex()
    {
        return (ActionResult)this.View((object)this.userCompanyRepository.GetUserVehicleMapping());
    }

    [HttpPost]
    public JsonResult GetVahicleMappingByUserId(short userId)
    {
        return this.Json((object)this.userCompanyRepository.GetVahicleMappingByUserId(userId), JsonRequestBehavior.AllowGet);
    }

    public ActionResult UserVehicleMapping(long? Id)
    {
        MasterUserVehicleMapping masterUserCompanyMapping = new MasterUserVehicleMapping();
        ((dynamic)base.ViewBag).UserList = this.userRepository.GetUserList();

        if (!Id.HasValue)
        {
            masterUserCompanyMapping.UserId = (long)0;
        }
        else
        {
            masterUserCompanyMapping.UserId = Id.Value;
        }

        var VehicleList = this.userCompanyRepository.GetVahicleMappingByUserId(masterUserCompanyMapping.UserId);
        masterUserCompanyMapping.VehicleList = (List<MasterUserVehicleMapping>) VehicleList;

       return base.View(masterUserCompanyMapping);
    }

        [HttpPost]
        public ActionResult UserVehicleMapping(MasterUserVehicleMapping objMasterUserCompanyMapping)
        {
            ActionResult action;
            ((dynamic)base.ViewBag).UserList = this.userRepository.GetUserList();
            if (base.ModelState.IsValid)
            {
                objMasterUserCompanyMapping.UpdateBy = new short?(SessionUtility.LoginUserId);
                objMasterUserCompanyMapping.CompanyId = SessionUtility.CompanyId;
                objMasterUserCompanyMapping.VehicleList.ForEach((MasterUserVehicleMapping m) => {
                    m.UserId = objMasterUserCompanyMapping.UserId;
                    m.UpdateBy = new short?(SessionUtility.LoginUserId);
                });
                objMasterUserCompanyMapping.VehicleList.RemoveAll((MasterUserVehicleMapping m) => !m.IsChecked);
                if (this.userCompanyRepository.VehicleMapping(objMasterUserCompanyMapping).IsSuccessfull)
                {
                    action = base.RedirectToAction("UserVehicleIndex");
                    return action;
                }
            }
            action = base.View(objMasterUserCompanyMapping);
            return action;
        }
        public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.userCompanyRepository.GetMapping());
    }

        public ActionResult Mapping()
        {
            MasterUserCompanyMapping masterUserCompanyMapping = new MasterUserCompanyMapping();
            ((dynamic)base.ViewBag).UserList = this.userRepository.GetUserList();
            return base.View(masterUserCompanyMapping);
        }

        [HttpPost]
        public ActionResult Mapping(MasterUserCompanyMapping objMasterUserCompanyMapping)
        {
            ActionResult action;
            ((dynamic)base.ViewBag).UserList = this.userRepository.GetUserList();
            if (base.ModelState.IsValid)
            {
                objMasterUserCompanyMapping.UpdateBy = new short?(SessionUtility.LoginUserId);
                objMasterUserCompanyMapping.CompanyId = SessionUtility.CompanyId;
                objMasterUserCompanyMapping.CompanyList.ForEach((MasterUserCompanyMapping m) => {
                    m.UserId = objMasterUserCompanyMapping.UserId;
                    m.UpdateBy = new short?(SessionUtility.LoginUserId);
                });
                objMasterUserCompanyMapping.CompanyList.RemoveAll((MasterUserCompanyMapping m) => !m.IsActive);
                if (this.userCompanyRepository.Mapping(objMasterUserCompanyMapping).IsSuccessfull)
                {
                    action = base.RedirectToAction("Index");
                    return action;
                }
            }
            action = base.View(objMasterUserCompanyMapping);
            return action;
        }
        [HttpPost]
    public JsonResult GetMappingByUserId(short userId)
    {
      return this.Json((object) this.userCompanyRepository.GetMappingByUserId(userId), JsonRequestBehavior.AllowGet);
    }
  }
}
