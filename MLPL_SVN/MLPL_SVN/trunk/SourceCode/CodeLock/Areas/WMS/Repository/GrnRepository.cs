//  
// Type: CodeLock.Areas.WMS.Repository.GrnRepository
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

namespace CodeLock.Areas.WMS.Repository
{
  public class GrnRepository : BaseRepository, IGrnRepository, IDisposable
  {
    public Response Insert(Grn objGrn)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGrn", (object) XmlUtility.XmlSerializeToString((object) objGrn), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Grn_Insert", (object) dynamicParameters, "Grn  - Insert").FirstOrDefault<Response>();
    }

    public bool IsFirstSerialNoExistForDispatch(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FirstSerialNumber", (object) firstSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsFirstSerialNoExistForDispatch", (object) dynamicParameters, "Grn - IsFirstSerialNoExistForDispatch");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsGrnExist(byte companyId, short warehouseId, int productId, long grnId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GrnId", (object) grnId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsGrnExist", (object) dynamicParameters, "Grn - IsGrnExist");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsFirstSerialNoExistByGrnId(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      long grnId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FirstSerialNumber", (object) firstSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GrnId", (object) grnId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsFirstSerialNoExistByGrnId", (object) dynamicParameters, "Grn - IsFirstSerialNoExistByGrnId");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsFirstSerialNoExist(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FirstSerialNumber", (object) firstSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsFirstSerialNoExist", (object) dynamicParameters, "Grn - IsFirstSerialNoExist");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsSecondSerialNoExistForDispatch(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      string secondSerialNumber)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FirstSerialNumber", (object) firstSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SecondSerialNumber", (object) secondSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsSecondSerialNoExistForDispatch", (object) dynamicParameters, "Grn - IsSecondSerialNoExistForDispatch");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsSecondSerialNoExistByGrnId(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      string secondSerialNumber,
      long grnId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FirstSerialNumber", (object) firstSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SecondSerialNumber", (object) secondSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GrnId", (object) grnId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsSecondSerialNoExistByGrnId", (object) dynamicParameters, "Grn - IsSecondSerialNoExistByGrnId");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsSecondSerialNoExist(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      string secondSerialNumber)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) productId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FirstSerialNumber", (object) firstSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SecondSerialNumber", (object) secondSerialNumber, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_Grn_IsSecondSerialNoExist", (object) dynamicParameters, "Grn - IsSecondSerialNoExist");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<Grn> GetGrnListForPutAway(
      byte companyId,
      short warehouseId,
      string grnNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate)
    {
      if (toDate > DateTime.Now)
        toDate = DateTime.Now;
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GrnNo", (object) grnNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Grn>("Usp_Grn_GetGrnListForPutAway", (object) dynamicParameters, "GRN - GetGrnListForPutAway");
    }

    public IEnumerable<GrnDetail> GetGrnDetailsForPutAway(long[] grnIdList)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GrnIdList", (object) string.Join<long>(",", (IEnumerable<long>) grnIdList), new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GrnDetail>("Usp_Grn_GetGrnDetailsForPutAway", (object) dynamicParameters, "GRN - GetGrnDetailsForPutAway");
    }

    public IEnumerable<GrnRegister> GetRegisterGrnDetail(
      string grnNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GrnNo", (object) grnNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GrnRegister>("Usp_Grn_GetRegisterGrnDetail", (object) dynamicParameters, "GRN - GetRegisterGrnDetail");
    }

    public Response InsertFromAsn(Grn objGrn)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGrnInsertFromAsn", (object) XmlUtility.XmlSerializeToString((object) objGrn), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Grn_InsertFromAsn", (object) dynamicParameters, "Grn  - InsertFromAsn").FirstOrDefault<Response>();
    }
  }
}
