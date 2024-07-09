//  
// Type: CodeLock.Areas.Master.Repository.MenuRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
  public class MenuRepository : BaseRepository, IMenuRepository, IDisposable
  {
    public IEnumerable<MasterMenu> GetMenuListByUserId(
      short loginUserId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@UserId", (object) loginUserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterMenu>("Usp_MasterMenu_GetMenuByUserId", (object) dynamicParameters, "Menu Master - GetMenuListByUserId");
    }

    public Response Update(MasterMenuAccess objMasterMenuAccess)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterMenuAccess", (object) XmlUtility.XmlSerializeToString((object) objMasterMenuAccess), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterMenu_Update", (object) dynamicParameters, "Menu Master - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<MasterMenu> GetMenuAccessListByRoleId(
      byte roleId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RoleId", (object) roleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterMenu>("Usp_MasterMenu_GetMenuAccessListByRoleId", (object) dynamicParameters, "Menu Master - GetMenuAccessListByRoleId");
    }

    public IEnumerable<AutoCompleteResult> GetMainMenuList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterMenu_GetMainMenuList", (object) null, "Menu Master - GetMainMenuList");
    }

    public IEnumerable<AutoCompleteResult> GetMenuListByParentMenuId(
      short parentMenuId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ParentMenuId", (object) parentMenuId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterMenu_GetMenuListByParentMenuId", (object) dynamicParameters, "Menu Master - GetMenuListByParentMenuId");
    }
  }
}
