//  
// Type: CodeLock.Areas.Master.Repository.ProductRepository
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
  public class ProductRepository : BaseRepository, IProductRepository, IDisposable
  {
    public IEnumerable<MasterProduct> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterProduct>("Usp_MasterProduct_GetAll", (object) null, "Product Master -GetAll");
    }

    public int Insert(MasterProduct objMasterproduct)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlProduct", (object) XmlUtility.XmlSerializeToString((object) objMasterproduct), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterProduct_Insert", (object) dynamicParameters, "Product Master - Insert");
      return dynamicParameters.Get<int>("@ProductId");
    }

    public int Update(MasterProduct objMasterproduct)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlProduct", (object) XmlUtility.XmlSerializeToString((object) objMasterproduct), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterProduct_Update", (object) dynamicParameters, "Product Master - Update");
      return dynamicParameters.Get<int>("@ProductId");
    }

    public MasterProduct GetById(byte companyId, int productId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterProduct>("Usp_MasterProduct_GetById", (object) dynamicParameters, "Product Master - GetById").FirstOrDefault<MasterProduct>();
    }

    public IEnumerable<AutoCompleteResult> GetPartAutoCompleteList(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ProductName", (object) productName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ConsignorId", (object) consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ConsigneeId", (object) consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterProduct_GetPartAutoCompleteList", (object) dynamicParameters, "Product Master - GetPartAutoCompleteList");
    }

    public MasterProduct IsPartCodeExist(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ProductName", (object) productName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ConsignorId", (object) consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ConsigneeId", (object) consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterProduct>("Usp_MasterProduct_IsPartCodeExist", (object) dynamicParameters, "Product Master - IsPartCodeExist").FirstOrDefault<MasterProduct>();
    }

    public bool IsProductNameAvailable(string productName, int productId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductName", (object) productName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterProduct_IsNameAvailable", (object) dynamicParameters, "Product Master - IsProductNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteProductList(
      byte companyId,
      string productCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductCode", (object) productCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterProduct_GetAutoCompleteList", (object) dynamicParameters, "Product Master - GetAutoCompleteProductList");
    }

    public MasterProduct IsProductCodeExist(byte companyId, string productCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductCode", (object) productCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterProduct>("Usp_MasterProduct_IsProductCodeExist", (object) dynamicParameters, "Product Master - IsProductCodeExist").FirstOrDefault<MasterProduct>();
    }

    public IEnumerable<ProductCustomerMappingDetail> GetCustomerMappingList(
      int productId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      List<ProductCustomerMappingDetail> list = DataBaseFactory.QuerySP<ProductCustomerMappingDetail>("Usp_MasterProduct_GetCustomerMappingList", (object) dynamicParameters, "Product Master - GetCustomerMappingList").ToList<ProductCustomerMappingDetail>();
      if (list.Count > 0)
        return (IEnumerable<ProductCustomerMappingDetail>) list;
      List<ProductCustomerMappingDetail> customerMappingDetailList1 = new List<ProductCustomerMappingDetail>();
      List<ProductCustomerMappingDetail> customerMappingDetailList2 = customerMappingDetailList1;
      ProductCustomerMappingDetail customerMappingDetail1 = new ProductCustomerMappingDetail();
      customerMappingDetail1.ConsignorId = (short) 0;
      customerMappingDetail1.ConsignorCode = "";
      customerMappingDetail1.ConsigneeId = (short) 0;
      customerMappingDetail1.ConsigneeCode = "";
      customerMappingDetail1.IsActive = false;
      customerMappingDetail1.CompanyId = (byte) 0;
      ProductCustomerMappingDetail customerMappingDetail2 = customerMappingDetail1;
      customerMappingDetailList2.Add(customerMappingDetail2);
      return (IEnumerable<ProductCustomerMappingDetail>) customerMappingDetailList1;
    }

    public ProductCustomerMapping GetProductCodeAndNameById(int productId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ProductCustomerMapping>("Usp_MasterProduct_GetProductCodeAndNameById", (object) dynamicParameters, "Product Master - GetProductCodeAndNameById").FirstOrDefault<ProductCustomerMapping>();
    }

    public Response Mapping(ProductCustomerMapping objProductCustomerMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlProductCustomerMapping", (object) XmlUtility.XmlSerializeToString((object) objProductCustomerMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_ProductCustomerMapping", (object) dynamicParameters, "ProductCustomerMapping Master - Mapping").FirstOrDefault<Response>();
    }
    public MasterProductPartExist IsPartCodeExistByPart(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ProductName", (object)productName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterProductPartExist>("Usp_MasterProduct_IsPartCodeExist", (object)dynamicParameters, "Product Master - IsPartCodeExist").FirstOrDefault<MasterProductPartExist>();
        }

       public MasterProductPartExist IsPartCodeExistByPartName(
       string productName,
       short consignorId,
       short consigneeId,
       byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ProductName", (object)productName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterProductPartExist>("Usp_MasterProduct_IsPartCodeExistByName", (object)dynamicParameters, "Product Master - IsPartCodeExist").FirstOrDefault<MasterProductPartExist>();
        }
    }
}
