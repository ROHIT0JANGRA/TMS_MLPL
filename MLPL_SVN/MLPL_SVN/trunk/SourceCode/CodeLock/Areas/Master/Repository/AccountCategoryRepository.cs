//  
// Type: CodeLock.Areas.Master.Repository.AccountCategoryRepository
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
  public class AccountCategoryRepository : BaseRepository, IAccountCategoryRepository, IDisposable
  {
    public IEnumerable<MasterAccountCategory> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterAccountCategory>("Usp_MasterAccountCategory_GetAll", (object) null, "AccountCategory Master - GetAll");
    }

    public MasterAccountCategory GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountCategoryId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterAccountCategory>("Usp_MasterAccountCategory_GetById", (object) dynamicParameters, "AccountCategory Master - GetById").FirstOrDefault<MasterAccountCategory>();
    }

    public byte Insert(MasterAccountCategory objMasterAccountCategory)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAccountCategory", (object) XmlUtility.XmlSerializeToString((object) objMasterAccountCategory), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountCategoryId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountCategory_Insert", (object) dynamicParameters, "AccountCategory Master - Insert");
      return dynamicParameters.Get<byte>("@AccountCategoryId");
    }

    public byte Update(MasterAccountCategory objMasterAccountCategory)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAccountCategory", (object) XmlUtility.XmlSerializeToString((object) objMasterAccountCategory), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountCategoryId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountCategory_Update", (object) dynamicParameters, "AccountCategory Master - Update");
      return dynamicParameters.Get<byte>("@AccountCategoryId");
    }

    public bool IsAccountCategoryNameAvailable(string categoryName, short accountCategoryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AccountCategoryId", (object) accountCategoryId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CategoryName", (object) categoryName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAccountCategory_IsNameAvailable", (object) dynamicParameters, "AccountCategory Master - IsAccountCategoryAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetMainAccountCategoryList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccountCategory_GetMainAccountCategoryList", (object) null, "AccountCategory Master - GetMainAccountCategoryList");
    }

    public IEnumerable<AutoCompleteResult> GetAccountCategoryList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAccountCategory_GetAccountCategoryList", (object) null, "AccountCategory Master - GetAccountCategoryList");
    }
  }
}
