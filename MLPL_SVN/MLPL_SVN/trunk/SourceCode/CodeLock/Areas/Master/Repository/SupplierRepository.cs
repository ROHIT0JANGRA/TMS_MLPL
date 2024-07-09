//  
// Type: CodeLock.Areas.Master.Repository.SupplierRepository
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
  public class SupplierRepository : BaseRepository, ISupplierRepository, IDisposable
  {
    public IEnumerable<MasterSupplier> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterSupplier>("Usp_MasterSupplier_GetAll", (object) null, "Supplier Master - GetAll");
    }

    public MasterSupplier GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupplierId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSupplier>("Usp_MasterSupplier_GetById", (object) dynamicParameters, "Supplier Master - GetById").FirstOrDefault<MasterSupplier>();
    }

    public Response Insert(MasterSupplier objMasterSupplier)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSupplier", (object) XmlUtility.XmlSerializeToString((object) objMasterSupplier), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterSupplier_Insert", (object) dynamicParameters, "Supplier Master - Insert").FirstOrDefault<Response>();
    }

    public byte Update(MasterSupplier objMasterSupplier)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSupplier", (object) XmlUtility.XmlSerializeToString((object) objMasterSupplier), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupplierId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSupplier_Update", (object) dynamicParameters, "Supplier Master - Update");
      return dynamicParameters.Get<byte>("@SupplierId");
    }

    public bool IsSupplierNameAvailable(string supplierName, short supplierId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupplierId", (object) supplierId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupplierName", (object) supplierName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSupplier_IsNameAvailable", (object) dynamicParameters, "Supplier Master - IsSupplierNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public AutoCompleteResult IsSupplierCodeExist(
      byte companyId,
      string supplierCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupplierCode", (object) supplierCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSupplier_IsSupplierCodeExist", (object) dynamicParameters, "Supplier Master - IsSupplierCodeExist").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      byte companyId,
      string supplierCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupplierCode", (object) supplierCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSupplier_GetAutoCompleteList", (object) dynamicParameters, "Supplier Master - GetAutoCompleteList");
    }
  }
}
