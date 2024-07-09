//  
// Type: CodeLock.Areas.Operation.Repository.LoadingSheetRepository
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

namespace CodeLock.Areas.Operation.Repository
{
  public class LoadingSheetRepository : BaseRepository, ILoadingSheetRepository, IDisposable
  {
    public IEnumerable<LoadingSheetDocket> GetDocketListForLoadingSheet(
      byte companyId,
      short locationId,
      string docketList,
      DateTime fromDate,
      DateTime toDate,
      byte transportModeId,
      int fromCityId,
      int toCityId,
      string toLocationList,
      string zoneList)
    {
      if (!string.IsNullOrEmpty(docketList))
      {
        transportModeId = (byte) 0;
        fromCityId = (int) 0;
        toCityId = (int) 0;
        toLocationList = string.Empty;
        zoneList = string.Empty;
      }
      if (toDate > SessionUtility.Now)
        toDate = SessionUtility.Now;
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DocketList", (object) docketList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TransportModeId", (object) transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromCityId", (object) fromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToCityId", (object) toCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToLocationList", (object) toLocationList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ZoneList", (object) zoneList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<LoadingSheetDocket>("Usp_LoadingSheet_GetDocketListForLoadingSheet", (object) dynamicParameters, "LoadingSheet - GetDocketListForLoadingSheet");
    }

    public Response Insert(LoadingSheet objLoadingSheet)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLoadingSheet", (object) XmlUtility.XmlSerializeToString((object) objLoadingSheet), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_LoadingSheet_Insert", (object) dynamicParameters, "LoadingSheet - Insert").FirstOrDefault<Response>();
    }

    public Response Update(Manifest objLoadingSheet)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLoadingSheetUpdate", (object) XmlUtility.XmlSerializeToString((object) objLoadingSheet), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_LoadingSheet_Update", (object) dynamicParameters, "LoadingSheet - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<LoadingSheet> GetLoadingSheetListForUpdate(
      short locationId,
      DateTime fromDate,
      DateTime toDate,
      short nextLocationId,
      string loadingSheetNo)
    {
      if (toDate > SessionUtility.Now)
        toDate = SessionUtility.Now;
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@NextLocationId", (object) nextLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LoadingSheetNo", (object) loadingSheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<LoadingSheet>("Usp_LoadingSheet_GetLoadingSheetListForUpdate", (object) dynamicParameters, "LoadingSheet - GetLoadingSheetListForUpdate");
    }

    public LoadingSheet GetLoadingSheetById(long loadingSheetId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LoadingSheetId", (object) loadingSheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<LoadingSheet>("Usp_LoadingSheet_GetLoadingSheetById", (object) dynamicParameters, "LoadingSheet - GetLoadingSheetById").FirstOrDefault<LoadingSheet>();
    }

    public IEnumerable<ManifestDocket> GetDocketListByLoadingSheetId(
      long loadingSheetId,
      short vendorId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LoadingSheetId", (object) loadingSheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ManifestDocket>("Usp_LoadingSheet_GetDocketListByLoadingSheetId", (object) dynamicParameters, "LoadingSheet Update - GetDocketListByLoadingSheetId");
    }

    public IEnumerable<LoadingSheet> GetLoadingSheetListForCancellation(
      string loadingSheetNo,
      string manualLoadingSheetNo,
      DateTime fromDate,
      DateTime toDate,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualLoadingSheetNos", (object) manualLoadingSheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LoadingSheetNos", (object) loadingSheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<LoadingSheet>("Usp_LoadingSheet_GetLoadingSheetListForCancellation", (object) dynamicParameters, "LoadingSheet - GetLoadingSheetListForCancellation");
    }

    public Response Cancellation(
      LoadingSheetCancellation objLoadingSheetCancellation)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLoadingSheet", (object) XmlUtility.XmlSerializeToString((object) objLoadingSheetCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_LoadingSheet_Cancellation", (object) dynamicParameters, "LoadingSheet - Cancel").FirstOrDefault<Response>();
    }

    public IEnumerable<AutoCompleteResult> GetVendorList(short locationId)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@locationId", (object)locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetAutoCompleteVendorListForParcel", (object)dynamicParameters, "Gst Master - GetManifestList");
        }
    }
}
