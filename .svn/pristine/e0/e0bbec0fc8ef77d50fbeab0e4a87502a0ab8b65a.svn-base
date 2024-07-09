//  
// Type: CodeLock.Areas.Master.Repository.CustomerBillFormatRepository
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
  public class CustomerBillFormatRepository : BaseRepository, ICustomerBillFormatRepository, IDisposable
  {
    public IEnumerable<MasterCustomerBillFormat> GetAll(
      string groupCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GroupCode", (object) groupCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCustomerBillFormat>("Usp_MasterCustomerBillFormat_GetAll", (object) dynamicParameters, "CustomerBillFormat Master - GetAll");
    }

    public MasterCustomerBillFormat GetById(byte formatId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FormatId", (object) formatId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCustomerBillFormat>("Usp_MasterCustomerBillFormat_GetById", (object) dynamicParameters, "CustomerBillFormat Master - GetById").FirstOrDefault<MasterCustomerBillFormat>();
    }

    public Response Mapping(MasterCustomerBillFormat objBillFormat)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCustomerBillFormatMapping", (object) XmlUtility.XmlSerializeToString((object) objBillFormat), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomerBillFormatMapping", (object) dynamicParameters, "CustomerBillFormatMapping Master - Insert").FirstOrDefault<Response>();
    }

    public Response BillFormatMapping(
      MasterCustomerBillFormat objMasterCustomerBillFormatMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCustomerBillFormatMapping", (object) XmlUtility.XmlSerializeToString((object) objMasterCustomerBillFormatMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomerBillFormat_InsertNEW", (object)dynamicParameters, "CustomerBillFormatMapping Master - Insert").FirstOrDefault<Response>();
//            return DataBaseFactory.QuerySP<Response>("Usp_MasterCustomerBillFormat_Insert", (object) dynamicParameters, "CustomerBillFormatMapping Master - Insert").FirstOrDefault<Response>();
    }

    public bool IsBillFormatMapped(short customerId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CustomerId", (object) customerId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterlCustomerBillFormatMapping_IsBillFormatMapped", (object) dynamicParameters, "CustomerBillFormatMapping Master - IsBillFormatMapped");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetBillFormatList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerBillFormatMapping_GetBillFormatList", (object) null, "CustomerBillFormatMapping Master - GetBillFormatList");
    }

    public AutoCompleteResult GetBillFormatByCustomerId(
      short customerId,
      byte paybasId,
      byte transportModeId,
      byte serviceTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CustomerId", (object) customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PayBasId", (object) paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TransportModeId", (object) transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ServiceTypeId", (object) serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomerBillFormat_GetBillFormatByCustomerId", (object) dynamicParameters, "CustomerBillFormatMapping Master - CustomerBillFormatGetByCustomerId").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<MasterCustomerBillFormat> GetBillFormat(
      string paybasId,
      string transportModeId,
      string serviceTypeId,
      byte formatId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PayBasId", (object) paybasId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TransportModeId", (object) transportModeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ServiceTypeId", (object) serviceTypeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FormatId", (object) formatId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCustomerBillFormat>("Usp_MasterCustomerBillFormat_GetBillFormat", (object) dynamicParameters, "CustomerBillFormat Master - GetBillFormat");
    }
  }
}
