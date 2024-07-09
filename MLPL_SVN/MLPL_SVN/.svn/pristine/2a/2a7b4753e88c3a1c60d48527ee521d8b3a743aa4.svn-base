//  
// Type: CodeLock.Areas.Master.Repository.RoleRepository
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
  public class RoleRepository : BaseRepository, IRoleRepository, IDisposable
  {
    public IEnumerable<MasterRole> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterRole>("Usp_MasterRole_GetAll", (object) null, "Role Master - GetAll");
    }

    public MasterRole GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RoleId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterRole>("Usp_MasterRole_GetById", (object) dynamicParameters, "Role Master - GetById").FirstOrDefault<MasterRole>();
    }

    public byte Insert(MasterRole objMasterRole)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlRole", (object) XmlUtility.XmlSerializeToString((object) objMasterRole), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RoleId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterRole_Insert", (object) dynamicParameters, "Role Master - Insert");
      return dynamicParameters.Get<byte>("@RoleId");
    }

    public byte Update(MasterRole objMasterRole)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlRole", (object) XmlUtility.XmlSerializeToString((object) objMasterRole), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RoleId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterRole_Update", (object) dynamicParameters, "Role Master - Update");
      return dynamicParameters.Get<byte>("@RoleId");
    }

    public IEnumerable<AutoCompleteResult> GetRoleList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRole_GetRoleList", (object) null, "Role Master - GetRoleList");
    }

    public bool IsRoleNameAvailable(string roleName, short roleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RoleId", (object) roleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@RoleName", (object) roleName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterRole_IsNameAvailable", (object) dynamicParameters, "Role Master - IsRoleNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
