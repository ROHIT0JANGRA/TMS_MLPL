//  
// Type: CodeLock.Areas.WMS.Repository.DispatchRepository
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
  public class DispatchRepository : BaseRepository, IDispatchRepository, IDisposable
  {
    public IEnumerable<Order> GetOrderListForDispatch(
      byte companyId,
      short warehouseId,
      string orderNo,
      string invoiceNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WareHouseId", (object) warehouseId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OrderNo", (object) orderNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@InvoiceNo", (object) invoiceNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return (IEnumerable<Order>) DataBaseFactory.QuerySP<Order>("Usp_Dispatch_GetOrderListForDispatch", (object) dynamicParameters, "Dispatch - GetOrderListForDispatch").ToList<Order>();
    }

    public IEnumerable<DispatchDetail> GetOrderDetails(
      byte companyId,
      short warehouseId,
      long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WareHouseId", (object) warehouseId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Id", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return (IEnumerable<DispatchDetail>) DataBaseFactory.QuerySP<DispatchDetail>("Usp_Dispatch_GetOrderDetails", (object) dynamicParameters, "Dispatch - GetDispatchDetail").ToList<DispatchDetail>();
    }

    public Response Insert(Dispatch objDispatch)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDispatch", (object) XmlUtility.XmlSerializeToString((object) objDispatch), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Dispatch_Insert", (object) dynamicParameters, "Dispatch  - Insert").FirstOrDefault<Response>();
    }

    public IEnumerable<DispatchRegister> GetRegisterDispatchDetail(
      string dispatchNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@DispatchNo", (object) dispatchNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return (IEnumerable<DispatchRegister>) DataBaseFactory.QuerySP<DispatchRegister>("Usp_Dispatch_GetRegisterDispatchDetail", (object) dynamicParameters, "Dispatch - GetRegisterDispatchDetail").ToList<DispatchRegister>();
    }
  }
}
