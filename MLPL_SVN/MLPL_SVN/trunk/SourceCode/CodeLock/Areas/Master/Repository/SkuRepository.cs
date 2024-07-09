//  
// Type: CodeLock.Areas.Master.Repository.SkuRepository
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
  public class SkuRepository : BaseRepository, ISkuRepository, IDisposable
  {
        public IEnumerable<Stock> InventoryAll()
        {
            return DataBaseFactory.QuerySP<Stock>("CL_Stock_GetAll", (object)null, "Stock  List- GetAll");
        }

    public IEnumerable<MasterSku> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterSku>("Usp_MasterSku_GetAll", (object) null, "Sku  Master- GetAll");
    }

    public MasterSku GetDetailById(int id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SkuId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSku>("Usp_MasterSku_GetDetailById", (object) dynamicParameters, "Sku  Master - GetDetailById").FirstOrDefault<MasterSku>();
    }

    public Response Insert(MasterSku objSku)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSku", (object) XmlUtility.XmlSerializeToString((object) objSku), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterSku_Insert", (object) dynamicParameters, "Sku  Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterSku objWorkGroup)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSku", (object) XmlUtility.XmlSerializeToString((object) objWorkGroup), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterSku_Update", (object) dynamicParameters, "Sku  Master - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteSkuList(
      byte companyId,
      string skuCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SkuCode", (object) skuCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSku_GetAutoCompleteList", (object) dynamicParameters, "Sku Master - GetAutoCompleteSkuList");
    }

    public MasterSku IsSkuCodeExist(byte companyId, string skuCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SkuCode", (object) skuCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSku>("Usp_MasterSku_IsSkuCodeExist", (object) dynamicParameters, "Sku Master - IsSkuCodeExist").FirstOrDefault<MasterSku>();
    }

    public bool IsSkuNameAvailable(string SkuName, int SkuId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SkuId", (object) SkuId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SkuName", (object) SkuName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSku_IsSkuAvailable", (object) dynamicParameters, "Sku  Master - IsSkuNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsSkuCodeAvailable(string SkuCode, int SkuId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SkuId", (object) SkuId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SkuCode", (object) SkuCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSku_IsSkuCodeAvailable", (object) dynamicParameters, "Sku  Master - IsSkuCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetSkuList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSku_GetSkuList", (object) null, " Sku  Master - GetSkuList");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteListByMaterialCategoryId(
      string skuName,
      byte materialCategoryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SkuName", (object) skuName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@MaterialCategoryId", (object) materialCategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSku_GetAutoCompleteListByMaterialCategoryId", (object) dynamicParameters, " Sku  Master - Get AutoComplete List By MaterialCategoryId");
    }

    public AutoCompleteResult IsSkuNameExistForPurchaseOrder(
      string skuName,
      byte materialCategoryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SkuName", (object) skuName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@MaterialCategoryId", (object) materialCategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSku_IsSkuNameExistForPurchaseOrder", (object) dynamicParameters, " Sku  Master - IsSkuNameExistForPurchaseOrder").FirstOrDefault<AutoCompleteResult>();
    }
  }
}
