//  
// Type: CodeLock.Areas.Master.Repository.CustomerGroupRepository
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
  public class CustomerGroupRepository : BaseRepository, ICustomerGroupRepository, IDisposable
  {
    public IEnumerable<MasterCustomerGroup> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterCustomerGroup>("Usp_MasterCustomerGroup_GetAll", (object) null, "CustomerGroup Master - GetAll");
    }

    public MasterCustomerGroup GetById(string id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GroupCode", (object) id, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCustomerGroup>("Usp_MasterCustomerGroup_GetById", (object) dynamicParameters, "CustomerGroup Master - GetById").FirstOrDefault<MasterCustomerGroup>();
    }

    public string Insert(MasterCustomerGroup objMasterCustomerGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCustomerGroup", (object) XmlUtility.XmlSerializeToString((object) objMasterCustomerGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GroupCode", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(5));
      DataBaseFactory.QuerySP("Usp_MasterCustomerGroup_Insert", (object) dynamicParameters, "CustomerGroup Master - Insert");
      return dynamicParameters.Get<string>("@GroupCode");
    }

    public string Update(MasterCustomerGroup objMasterCustomerGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCustomerGroup", (object) XmlUtility.XmlSerializeToString((object) objMasterCustomerGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GroupCode", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(5));
      DataBaseFactory.QuerySP("Usp_MasterCustomerGroup_Update", (object) dynamicParameters, "CustomerGroup Master - Update");
      return dynamicParameters.Get<string>("@GroupCode");
    }

    public bool IsGroupNameAvailable(string groupName, string groupCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GroupCode", (object) groupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GroupName", (object) groupName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCustomerGroup_IsNameAvailable", (object) dynamicParameters, "CustomerGroup Master - IsGroupNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetCustomerGroupList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerGroup_GetCustomerGroupList", (object) null, "CustomerGroup Master - GetCustomerGroupList");
    }
  }
}
