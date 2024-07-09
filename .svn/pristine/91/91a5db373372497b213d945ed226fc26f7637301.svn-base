//  
// Type: CodeLock.Areas.Master.Repository.RoleBasedAccessRightRepository
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
  public class RoleBasedAccessRightRepository : BaseRepository, IRoleBasedAccessRightRepository, IDisposable
  {
    public Response Update(
      MasterRoleBasedAccessRight objMasterRoleBasedAccessRight)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlMasterRoleBasedAccessRight", (object) XmlUtility.XmlSerializeToString((object) objMasterRoleBasedAccessRight), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterRoleBasedAccessRight_Update", (object) dynamicParameters, "Role Based Access Right Master - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<MasterMenu> GetMenuAccessListByRoleIdAndUserId(
      byte roleId,
      short userId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RoleId", (object) roleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@UserId", (object) userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterMenu>("Usp_MasterMenu_GetMenuAccessListByRoleIdAndUserId", (object) dynamicParameters, "Menu Master - GetMenuAccessListByRoleIdAndUserId");
    }
  }
}
