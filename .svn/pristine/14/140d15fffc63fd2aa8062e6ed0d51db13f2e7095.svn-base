using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class MenuController : Controller
  {
    private readonly IMenuRepository menuRepository;
    private readonly IRoleRepository roleRepository;

        public MenuController()
        {
        }

        public MenuController(IMenuRepository _menuRepository, IRoleRepository _roleRepository)
        {
            this.menuRepository = _menuRepository;
            this.roleRepository = _roleRepository;
        }

        public JsonResult GetMenuAccessListByRoleId(byte roleId)
        {
            JsonResult jsonResult = base.Json(this.menuRepository.GetMenuAccessListByRoleId(roleId, SessionUtility.CompanyId));
            return jsonResult;
        }

        public JsonResult GetMenuListByParentMenuId(short parentMenuId)
        {
            return base.Json(this.menuRepository.GetMenuListByParentMenuId(parentMenuId));
        }

        public ActionResult Index()
        {
            ((dynamic)base.ViewBag).RoleList = this.roleRepository.GetRoleList();
            ((dynamic)base.ViewBag).Message = false;
            return base.View();
        }

        [HttpPost]
        public ActionResult Index(MasterMenuAccess objMasterMenuAccess)
        {
            if (base.ModelState.IsValid)
            {
                objMasterMenuAccess.CompanyId = SessionUtility.CompanyId;
                objMasterMenuAccess.MasterMenuList.RemoveAll((MasterMenu m) => !m.IsActive);
                objMasterMenuAccess.MasterMenuList.ForEach((MasterMenu m) => {
                    m.RoleId = objMasterMenuAccess.RoleId;
                    m.EntryBy = SessionUtility.LoginUserId;
                    m.CompanyId = SessionUtility.CompanyId;
                });
                ((dynamic)base.ViewBag).Message = this.menuRepository.Update(objMasterMenuAccess).IsSuccessfull;
            }
             ((dynamic)base.ViewBag).RoleList = this.roleRepository.GetRoleList();

            return base.View();
        }



    }
}
