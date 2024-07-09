//  
// Type: CodeLock.Areas.WMS.Repository.GatePassRepository
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
  public class GatePassRepository : BaseRepository, IGatePassRepository, IDisposable
  {
    public IEnumerable<GatePass> GetGatePassInList(
      byte SupplierType,
      long SupplierId,
      string PurchseOrderNo,
      string InvoiceNo,
      string AsnNo,
      DateTime FromDate,
      DateTime ToDate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupplierType", (object) SupplierType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupplierId", (object) SupplierId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PurchseOrderNo", (object) PurchseOrderNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@InvoiceNo", (object) InvoiceNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AsnNo", (object) AsnNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) FromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) ToDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return (IEnumerable<GatePass>) DataBaseFactory.QuerySP<GatePass>("Usp_GatePass_GetGatePassInList", (object) dynamicParameters, "GatePass - GetGatePassInList").ToList<GatePass>();
    }

    public IEnumerable<AutoCompleteResult> GetGatePassNoList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_GatePass_GetGatePassNoList", (object) null, "GatePass - GetGatePassNoList");
    }

    public IEnumerable<GatePass> GetSkuDetails(long AsnId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AsnId", (object) AsnId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return (IEnumerable<GatePass>) DataBaseFactory.QuerySP<GatePass>("Usp_GatePass_GetSkuDetails", (object) dynamicParameters, "GatePass - GetGatePassInList").ToList<GatePass>();
    }

    public Response GatePassIn(GatePass objGatePass)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGatePass", (object) XmlUtility.XmlSerializeToString((object) objGatePass), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_GatePass_Insert", (object) dynamicParameters, "GatePass  - Insert").FirstOrDefault<Response>();
    }
  }
}
