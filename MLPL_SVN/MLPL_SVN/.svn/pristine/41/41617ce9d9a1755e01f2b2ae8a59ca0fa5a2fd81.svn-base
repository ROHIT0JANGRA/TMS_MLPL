//  
// Type: CodeLock.Areas.Operation.Repository.PfmRepository
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
  public class PfmRepository : BaseRepository, IPfmRepository, IDisposable
  {
    public IEnumerable<PfmDetails> GetDocketListForPfm(
      byte companyId,
      short locationId,
      string docketNos,
      DateTime fromDate,
      DateTime toDate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DocketNos", (object) docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<PfmDetails>("Usp_Pfm_GetDocketListForPfm", (object) dynamicParameters, "Pfm Master - GetDocketListForPfm");
    }

    public Response InsertPfm(Pfm objPfm)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPfm", (object) XmlUtility.XmlSerializeToString((object) objPfm), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Pfm_Insert", (object) dynamicParameters, "Pfm Master - InsertPfm").FirstOrDefault<Response>();
    }

    public IEnumerable<Pfm> GetPfmListForAcknowledge(
      byte companyId,
      short locationId,
      string pfmNos,
      DateTime fromDate,
      DateTime toDate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PfmNos", (object) pfmNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Pfm>("Usp_Pfm_GetPfmListForAcknowledge", (object) dynamicParameters, "Pfm Master - GetPfmListForAcknowledge");
    }

    public IEnumerable<PfmDetails> GetPfmDocketListForAcknowledge(long pfmId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PfmId", (object) pfmId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<PfmDetails>("Usp_Pfm_GetPfmDocketListForAcknowledge", (object) dynamicParameters, "Pfm Master - GetPfmDocketListForAcknowledge");
    }

    public Response AcknowledgePfm(Pfm objPfm)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAcknowledgePfm", (object) XmlUtility.XmlSerializeToString((object) objPfm), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Pfm_AcknowledgePfm", (object) dynamicParameters, "Pfm Master - AcknowledgePfm").FirstOrDefault<Response>();
    }

    public Pod InsertPod(Pod objPfm)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPod", (object) XmlUtility.XmlSerializeToString((object) objPfm), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      if (DataBaseFactory.QuerySP<Response>("Usp_Pod_Insert", (object) dynamicParameters, "Pod Master - InsertPod").FirstOrDefault<Response>().IsSuccessfull)
        objPfm.Details.ForEach((Action<ScanDetail>) (m => m.IsSuccessfull = true));
      return objPfm;
    }

    public ScanDetail GetPodDetailByDocumentId(byte documentTypeId, long documentId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@DocumentTypeId", (object) documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DocumentId", (object) documentId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ScanDetail>("Usp_Pod_GetPodDetailByDocumentId", (object) dynamicParameters, "Pod Master - GetPodDetailByDocumentId").FirstOrDefault<ScanDetail>();
    }

    public ScanDetail CheckPodScanStatus(
      string documentNo,
      byte documentTypeId,
      short locationId,
      string locationCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@DocumentNo", (object) documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DocumentTypeId", (object) documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationCode", (object) locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ScanDetail>("Usp_Pod_CheckPodScanStatus", (object) dynamicParameters, "Pod Master - CheckPodScanStatus").FirstOrDefault<ScanDetail>();
    }

        public Response InsertPODHandOver(DocumentTracking objPfm)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Xml", (object)XmlUtility.XmlSerializeToString((object)objPfm), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_PODHandover_Insert", (object)dynamicParameters, "Pfm Master - InsertPfm").FirstOrDefault<Response>();
        }
        public IEnumerable<DocumentTracking> GetDocketPODHandOverList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo,
          int CustomerId,
          int ListType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ListType", (object)ListType, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return (IEnumerable<DocumentTracking>)DataBaseFactory.QuerySP<DocumentTracking>("Usp_Tracking_GetDocketPODHandoverList", (object)dynamicParameters, "Tracking - GetDocketList").ToList<DocumentTracking>();
        }
    }
}
