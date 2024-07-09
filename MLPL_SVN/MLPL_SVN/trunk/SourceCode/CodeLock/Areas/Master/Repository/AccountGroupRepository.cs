//  
// Type: CodeLock.Areas.Master.Repository.AccountGroupRepository
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
  public class AccountGroupRepository : BaseRepository, IAccountGroupRepository, IDisposable
  {
    public IEnumerable<MasterAccountGroup> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterAccountGroup>("Usp_MasterAccountGroup_GetAll", (object) null, "AccountGroup Master - GetAll");
    }

    public MasterAccountGroup GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountGroupId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterAccountGroup>("Usp_MasterAccountGroup_GetById", (object) dynamicParameters, "AccountGroup Master - GetById").FirstOrDefault<MasterAccountGroup>();
    }

    public short Insert(MasterAccountGroup objMasterAccountGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAccountGroup", (object) XmlUtility.XmlSerializeToString((object) objMasterAccountGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountGroupId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountGroup_Insert", (object) dynamicParameters, "AccountGroup Master - Insert");
      return dynamicParameters.Get<short>("@AccountGroupId");
    }

    public short Update(MasterAccountGroup objMasterAccountGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAccountGroup", (object) XmlUtility.XmlSerializeToString((object) objMasterAccountGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountGroupId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountGroup_Update", (object) dynamicParameters, "AccountGroup Master - Update");
      return dynamicParameters.Get<short>("@AccountGroupId");
    }

    public bool IsGroupCodeAvailable(string groupCode, short accountGroupId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountGroupId", (object) accountGroupId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GroupCode", (object) groupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountGroup_IsCodeAvailable", (object) dynamicParameters, "AccountGroup Master - IsGroupCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsGroupNameAvailable(string groupName, short accountGroupId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountGroupId", (object) accountGroupId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GroupName", (object) groupName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountGroup_IsNameAvailable", (object) dynamicParameters, "AccountGroup Master - IsGroupNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAccountGroupListByCategoryId(
      short accountCategoryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountCategoryId", (object) accountCategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccountGroup_GetAccountGroupListByCategoryId", (object) dynamicParameters, "AccountGroup Master - GetAccountGroupListByCategoryId");
    }

    public IEnumerable<AutoCompleteResult> GetListByCategoryId(
      byte accountCategoryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountCategoryId", (object) accountCategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccountGroup_GetAccountGroupListByCategoryId", (object) dynamicParameters, "AccountGroup Master - GetListByCategoryId");
    }

    public IEnumerable<AutoCompleteResult> GetAccountGroupListByMainCategoryId(
      short maincategoryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@MaincategoryId", (object) maincategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccountGroup_GetAccountGroupListByMainCategoryId", (object) dynamicParameters, "AccountGroup Master - GetAccountGroupListByMainCategoryId");
    }

    public IEnumerable<AutoCompleteResult> GetAccountGroupList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccountGroup_GetAccountGroupList", (object) null, "AccountGroup Master - GetAccountGroupList");
    }
  }
}
