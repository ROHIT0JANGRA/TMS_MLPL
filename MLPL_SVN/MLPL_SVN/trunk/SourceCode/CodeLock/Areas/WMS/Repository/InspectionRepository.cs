//  
// Type: CodeLock.Areas.WMS.Repository.InspectionRepository
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
  public class InspectionRepository : BaseRepository, IInspectionRepository, IDisposable
  {
    public IEnumerable<InspectionDetail> GetInspectionList(
      byte warehouseId,
      byte companyId,
      DateTime fromDate,
      DateTime toDate,
      string invoiceNos,
      string grnNos)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GrnNos", (object) grnNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@InvoiceNos", (object) invoiceNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<InspectionDetail>("Usp_Inspection_GetInspectionList", (object) dynamicParameters, "Inspection - GetInspectionList");
    }

    public Response Insert(Inspection objInspection)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlInspection", (object) XmlUtility.XmlSerializeToString((object) objInspection), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Inspection_Insert", (object) dynamicParameters, "Inspection  - Insert").FirstOrDefault<Response>();
    }
  }
}
