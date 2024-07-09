//  
// Type: CodeLock.Areas.FMS.Repository.TrackingRepository
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

namespace CodeLock.Areas.FMS.Repository
{
  public class TrackingRepository : BaseRepository, ITrackingRepository, IDisposable
  {
    public IEnumerable<FleetDocumentTracking> GetTripsheetList(
      short locationId,
      DateTime fromDate,
      DateTime toDate,
      string tripsheetNos,
      string manualTripsheetNos,
      string vehicalNos)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DocumentNos", (object) tripsheetNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualDocumentNos", (object) manualTripsheetNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicalNos", (object) vehicalNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<FleetDocumentTracking>("Usp_Tracking_GetTripsheetList", (object) dynamicParameters, "Fleet Tracking - GetTripsheetList");
    }
  }
}
