//  
// Type: CodeLock.Areas.Finance.Repository.TripsheetBillRepository
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

namespace CodeLock.Areas.Finance.Repository
{
  public class TripsheetBillRepository : BaseRepository, ITripsheetBillRepository, IDisposable
  {
    public IEnumerable<TripsheetBillDetail> GetTripsheettListForBillGeneration(
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      byte ftlTypeId,
      short vehicleId,
      short locationId,
      byte companyId,
      short generationLocationId)
    {
      if (toDate > SessionUtility.Now)
        toDate = SessionUtility.Now;
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CustomerId", (object) customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FtlTypeId", (object) ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GenerationLocationId", (object) generationLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<TripsheetBillDetail>("Usp_TripsheetBillGeneration_GetTripsheettListForBillGeneration", (object) dynamicParameters, "Tripsheet Bill Generation - GetTripsheettListForBillGeneration");
    }

    public Response Generate(TripsheetBill objTripsheetBill)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTripsheetBill", (object) XmlUtility.XmlSerializeToString((object) objTripsheetBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_TripsheetBillGeneration_Insert", (object) dynamicParameters, "Tripsheet Bill Generation - Insert").FirstOrDefault<Response>();
    }
  }
}
