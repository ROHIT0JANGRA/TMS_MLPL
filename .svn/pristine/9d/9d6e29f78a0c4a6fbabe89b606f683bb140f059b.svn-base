//  
// Type: CodeLock.Areas.Operation.Repository.ManifestRepository
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
  public class ManifestRepository : BaseRepository, IManifestRepository, IDisposable
  {

        public IEnumerable<LabourDCTracking> GetManifestListForLabourDCForTracking(
          string locationId,
          string docketList,
          DateTime fromDate,
          DateTime toDate,
          string DocumentType,
          string THCType,
          string VendorId,
          string companyId
          )
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketList", (object)docketList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentType", (object)DocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@THCType", (object)THCType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            //
            return DataBaseFactory.QuerySP<LabourDCTracking>("Usp_Manifest_GetDocketListForLabourDCForTracking", (object)dynamicParameters, "Manifest - GetDocketListForManifest");
        }

        public IEnumerable<LabourDCManifest> GetManifestListForLabourDC(
          byte companyId,
          string locationId,
          DateTime fromDate,
          DateTime toDate,
          string docketList,
          string DocumentType,
          string THCType
          )
        {

            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketList", (object)docketList, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentType", (object)DocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@THCType", (object)THCType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<LabourDCManifest>("Usp_Manifest_GetDocketListForLabourDC", (object)dynamicParameters, "Manifest - GetDocketListForManifest");
        }

        public IEnumerable<ManifestDocket> GetDocketListForManifest(
      byte companyId,
      short locationId,
      string docketList,
      DateTime fromDate,
      DateTime toDate,
      byte transportModeId,
      int fromCityId,
      int toCityId,
      string toLocationList,
      string zoneList,
      short vendorId)
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
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ManifestDocket>("Usp_Manifest_GetDocketListForManifest", (object) dynamicParameters, "Manifest - GetDocketListForManifest");
    }

    public Response InsertLabourDC(LabourDCModule objManifest)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlManifest", (object) XmlUtility.XmlSerializeToString((object) objManifest), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_ManifestLabourDC_Insert", (object) dynamicParameters, "Manifest - Insert").FirstOrDefault<Response>();
    }

        public Response Insert(Manifest objManifest)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlManifest", (object)XmlUtility.XmlSerializeToString((object)objManifest), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Manifest_Insert", (object)dynamicParameters, "Manifest - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<Manifest> GetManifestListForCancellation(
      string manifestNos,
      string manualManifestNos,
      DateTime fromDate,
      DateTime toDate,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ManifestNos", (object) manifestNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualManifestNos", (object) manualManifestNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Manifest>("Usp_Manifest_GetManifestListForCancellation", (object) dynamicParameters, "Manifest - GetManifestListForCancellation");
    }

    public Response Cancellation(ManifestCancellation objManifestCancellation)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlManifest", (object) XmlUtility.XmlSerializeToString((object) objManifestCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Manifest_Cancellation", (object) dynamicParameters, "Manifest - Cancel").FirstOrDefault<Response>();
    }

        public Response CancellationLabourDC(LabourDCModule objLabourDCCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlManifest", (object)XmlUtility.XmlSerializeToString((object)objLabourDCCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_LabourDC_Cancellation", (object)dynamicParameters, "Manifest - Cancel").FirstOrDefault<Response>();
        }

        public IEnumerable<LabourDCModule> GetLabourDCListForCancellation(
        string LabourDCNos,
        DateTime fromDate,
        DateTime toDate,
        short locationId

         )
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LabourDCNos", (object)LabourDCNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<LabourDCModule>("Usp_LabourDC_GetLabourDCListForCancellation", (object)dynamicParameters, "Manifest - GetManifestListForCancellation");
        }

        public IEnumerable<ManifestDocket> GetDocketListByManifestId(
     long manifestId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ManifestId", (object)manifestId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ManifestDocket>("Usp_Manifest_GetDocketListByManifestId", (object)dynamicParameters, "Manifest - GetDocketListByManifestId");
        }
    }
}
