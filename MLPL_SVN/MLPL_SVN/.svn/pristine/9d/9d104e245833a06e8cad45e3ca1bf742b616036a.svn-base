using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class RoleBasedAccessRightController : Controller
  {
    private readonly IRoleBasedAccessRightRepository roleBasedAccessRightRepository;
    private readonly IMenuRepository menuRepository;
    private readonly IRoleRepository roleRepository;

    public RoleBasedAccessRightController()
    {
    }

    public RoleBasedAccessRightController(
      IRoleBasedAccessRightRepository _roleBasedAccessRightRepository,
      IMenuRepository _menuRepository,
      IRoleRepository _roleRepository)
    {
      this.roleBasedAccessRightRepository = _roleBasedAccessRightRepository;
      this.menuRepository = _menuRepository;
      this.roleRepository = _roleRepository;
    }

        public ActionResult Index()
        {
            ((dynamic)base.ViewBag).RoleList = this.roleRepository.GetRoleList();
            ((dynamic)base.ViewBag).Message = false;
            return base.View();
        }

        [HttpPost]
        public ActionResult Index(MasterRoleBasedAccessRight objMasterRoleBasedAccessRight)
        {
            if (base.ModelState.IsValid)
            {
                objMasterRoleBasedAccessRight.CompanyId = SessionUtility.CompanyId;
                objMasterRoleBasedAccessRight.MasterMenuList.RemoveAll((MasterMenu m) => !m.IsActive);
                objMasterRoleBasedAccessRight.MasterMenuList.ForEach((MasterMenu m) => {
                    m.RoleId = objMasterRoleBasedAccessRight.RoleId;
                    m.UserId = objMasterRoleBasedAccessRight.UserId;
                    m.EntryBy = SessionUtility.LoginUserId;
                    m.CompanyId = SessionUtility.CompanyId;
                });
                ((dynamic)base.ViewBag).Message = this.roleBasedAccessRightRepository.Update(objMasterRoleBasedAccessRight).IsSuccessfull;
            }
            ((dynamic)base.ViewBag).RoleList = this.roleRepository.GetRoleList();
            return base.View();
        }

        public JsonResult GetMenuAccessListByRoleIdAndUserId(byte roleId, short userId)
    {
      return this.Json((object) this.roleBasedAccessRightRepository.GetMenuAccessListByRoleIdAndUserId(roleId, userId, SessionUtility.CompanyId));
    }
  }
}
