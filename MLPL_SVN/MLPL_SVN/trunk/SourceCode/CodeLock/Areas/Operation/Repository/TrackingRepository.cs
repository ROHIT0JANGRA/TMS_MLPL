﻿//  
// Type: CodeLock.Areas.Operation.Repository.TrackingRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace CodeLock.Areas.Operation.Repository
{
    public class TrackingRepository : BaseRepository, ITrackingRepository, IDisposable
    {
        public Response InsertDocketChangeStatus(DocumentTracking objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocket", (object)XmlUtility.XmlSerializeToString((object)objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_ChangeStatus_Insert", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<DocumentTracking> GetDocketListForChangeStatus(
          string documentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return (IEnumerable<DocumentTracking>)DataBaseFactory.QuerySP<DocumentTracking>("Usp_Tracking_GetDocketList", (object)dynamicParameters, "Tracking - GetDocketList").ToList<DocumentTracking>();
        }

        public IEnumerable<Docket> GetDocketPODList(
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

            return (IEnumerable<Docket>)DataBaseFactory.QuerySP<Docket>("Usp_Tracking_GetDocketPODList", (object)dynamicParameters, "Tracking - GetDocketList").ToList<Docket>();
        }

        public IEnumerable<Docket> GetDocketList(
        short locationId,
        DateTime fromDate,
        DateTime toDate,
        string documentNo,
        string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", 0, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Docket>)DataBaseFactory.QuerySP<Docket>("Usp_Tracking_GetDocketList", (object)dynamicParameters, "Tracking - GetDocketList").ToList<Docket>();
        }
        public IEnumerable<Docket> GetDocketList(
        short locationId,
        DateTime fromDate,
        DateTime toDate,
        string documentNo,
        string manualDocumentNo,
        int CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return (IEnumerable<Docket>)DataBaseFactory.QuerySP<Docket>("Usp_Tracking_GetDocketList", (object)dynamicParameters, "Tracking - GetDocketList").ToList<Docket>();
        }
        public string GetVehicleStatus(string vehicleNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Tracking_GetVehicleStatus", (object)dynamicParameters, "Tracking - GetVehicleStatus");
            return dynamicParameters.Get<string>("@VehicleId");
        }

        public IEnumerable<ThcSummary> GetThcList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<ThcSummary>)DataBaseFactory.QuerySP<ThcSummary>("Usp_Tracking_GetThcList", (object)dynamicParameters, "Tracking - GetThcList").ToList<ThcSummary>();
        }

        public IEnumerable<Drs> GetDrsList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Drs>)DataBaseFactory.QuerySP<Drs>("Usp_Tracking_GetDrsList", (object)dynamicParameters, "Tracking - GetDrsList").ToList<Drs>();
        }

        public IEnumerable<Prs> GetPrsList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Prs>)DataBaseFactory.QuerySP<Prs>("Usp_Tracking_GetPrsList", (object)dynamicParameters, "Tracking - GetPrsList").ToList<Prs>();
        }

        public IEnumerable<LoadingSheet> GetLoadingSheetList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<LoadingSheet>)DataBaseFactory.QuerySP<LoadingSheet>("Usp_Tracking_GetLoadingSheetList", (object)dynamicParameters, "Tracking - GetLoadingSheetList").ToList<LoadingSheet>();
        }

        public IEnumerable<Tripsheet> GetTripsheetList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Tripsheet>)DataBaseFactory.QuerySP<Tripsheet>("Usp_Tracking_GetTripsheetList", (object)dynamicParameters, "Tracking - GetTripsheetList").ToList<Tripsheet>();
        }

        public IEnumerable<Manifest> GetManifestList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Manifest>)DataBaseFactory.QuerySP<Manifest>("Usp_Tracking_GetManifestList", (object)dynamicParameters, "Tracking - GetManifestList").ToList<Manifest>();
        }

        public IEnumerable<Pfm> GetPfmList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Pfm>)DataBaseFactory.QuerySP<Pfm>("Usp_Tracking_GetPfmList", (object)dynamicParameters, "Tracking - GetPfmList").ToList<Pfm>();
        }

        public IEnumerable<Vr> GetVrList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<Vr>)DataBaseFactory.QuerySP<Vr>("Usp_Tracking_GetVrList", (object)dynamicParameters, "Tracking - GetVrList").ToList<Vr>();
        }

        public IEnumerable<ConsignmentTracking> GetConsignmentDetailsList(
          string documentNos,
          bool documentType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentNos", (object)documentNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentType", (object)documentType, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<ConsignmentTracking>)DataBaseFactory.QuerySP<ConsignmentTracking>("Usp_Tracking_GetConsignmentDetailsList", (object)dynamicParameters, "Tracking - GetConsignmentDetailsList").ToList<ConsignmentTracking>();
        }

        public ConsignmentTracking GetConsignmentTransitDetails(
          long docketId,
          string docketSuffix)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("DocketSuffix", (object)docketSuffix, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ConsignmentTracking>("Usp_Tracking_GetConsignmentTransitDetails", (object)dynamicParameters, "Tracking - GetConsignmentTransitDetails").FirstOrDefault<ConsignmentTracking>();
        }

        public IEnumerable<DocketTalkTracking> GetDocketTalkList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<DocketTalkTracking>)DataBaseFactory.QuerySP<DocketTalkTracking>("Usp_Docket_GetDocketTalkData", (object)dynamicParameters, "Tracking - GetDocketTalkList").ToList<DocketTalkTracking>();
        }
        public IEnumerable<UnLoadingSheet> GetUnLoadingSheetList(
        short locationId,
        DateTime fromDate,
        DateTime toDate,
        string documentNo,
        string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<UnLoadingSheet>)DataBaseFactory.QuerySP<UnLoadingSheet>("Usp_Tracking_GetUnLoadingSheetList", (object)dynamicParameters, "Tracking - GetUnLoadingSheetList").ToList();
        }

        public IEnumerable<DocketTransitDetail> GetConsignmentTransitList(
          long docketId,
          string docketSuffix)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("DocketSuffix", (object)docketSuffix, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<DocketTransitDetail>)DataBaseFactory.QuerySP<DocketTransitDetail>("Usp_Tracking_GetConsignmentTransitList", (object)dynamicParameters, "Tracking - GetConsignmentTransitList").ToList<DocketTransitDetail>();
        }

        public DocketTracking GetDocketTransitSummary(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketTracking>("Usp_Tracking_GetDocketTransitSummary", (object)dynamicParameters, "Tracking - GetDocketTransitSummary").FirstOrDefault<DocketTracking>();
        }

        public DocketStatusApi GetApiDocketStatus(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<DocketStatusApi>, IEnumerable<DocketStatusDetailApi>, IEnumerable<DocketInvoiceApi>, IEnumerable<DocketInvoicePartApi>> tuple = DataBaseFactory.QueryMultipleSP<DocketStatusApi, DocketStatusDetailApi, DocketInvoiceApi, DocketInvoicePartApi>("Usp_Api_GetDocketStatus", dynamicParameters, "Tracking - GetApiDocketStatus");
            DocketStatusApi docketStatusApi = new DocketStatusApi();
            if (tuple.Item1.Count() > 0)
            {
                docketStatusApi = tuple.Item1.FirstOrDefault<DocketStatusApi>();
                docketStatusApi.DocketStatusDetailApiList = tuple.Item2;
                foreach (DocketInvoiceApi docketInvoice in tuple.Item3)
                {
                    foreach (DocketInvoicePartApi invoicePart in tuple.Item4)
                    {
                        if (invoicePart.InvoiceId == docketInvoice.InvoiceId)
                            docketInvoice.PartList.Add(invoicePart);
                    }
                    docketStatusApi.DocketInvoiceList.Add(docketInvoice);
                }
                docketStatusApi.IsSuccess = true;
                docketStatusApi.Message = "Docket details successfully fatched.";
            }
            else
            {
                docketStatusApi.IsSuccess = false;
                docketStatusApi.Message = "Invalid Docket No.";
            }
            return docketStatusApi;
        }

        public OrderTrackingApi OrderTracking(string docketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<OrderTrackingApi>, IEnumerable<DocketPartListApi>> tuple = DataBaseFactory.QueryMultipleSP<OrderTrackingApi, DocketPartListApi>("Usp_Api_GetOrderTracking", dynamicParameters, "Tracking - OrderTracking");
            OrderTrackingApi orderTrackingApi = new OrderTrackingApi();
            if (tuple.Item1.Count() > 0)
            {
                orderTrackingApi = tuple.Item1.FirstOrDefault<OrderTrackingApi>();
                foreach (DocketPartListApi docketPartListApi in tuple.Item2)
                {
                    docketPartListApi.PartName = docketPartListApi.PartName;
                    orderTrackingApi.PartList.Add(docketPartListApi);
                }

            }
            return orderTrackingApi;

        }

        public DocketTrackingResponseForFarEyeSuccess OrderTrackingForFarEye(string docketNo)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<DocketTrackingResponseForFarEyeSuccess>, IEnumerable<PodInfoForFarEye>> tuple = DataBaseFactory.QueryMultipleSP<DocketTrackingResponseForFarEyeSuccess, PodInfoForFarEye>("Usp_Api_GetOrderTrackingForFarEye", dynamicParameters, "Tracking - OrderTracking");
            DocketTrackingResponseForFarEyeSuccess result = new DocketTrackingResponseForFarEyeSuccess();
            PodLinkForFarEye objPod = new PodLinkForFarEye();
            if (tuple.Item1.Count() > 0)
            {
                result = tuple.Item1.FirstOrDefault<DocketTrackingResponseForFarEyeSuccess>();
                result.extra_info = tuple.Item2.FirstOrDefault<PodInfoForFarEye>();
            }
            return result;
        }
        public IEnumerable<Docket> GetDocketListByPagination(int pageNo, int pageSize, string sorting, string search, short locationId,
  DateTime fromDate,
  DateTime toDate,
  string documentNo,
  string manualDocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", 0, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_Tracking_GetDocketListByPagination", (object)dynamicParameters, "Tracking - GetDocketListByPagination");
        }
        //public IEnumerable<Docket> GetDocketListByPagination(int pageNo, int pageSize, string sorting, string search, short locationId, DateTime fromDate, DateTime toDate, string documentNo, string manualDocumentNo)
        //{
        //    try
        //    {
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@PageNo", pageNo, DbType.Int32, ParameterDirection.Input);
        //        dynamicParameters.Add("@PageSize", pageSize, DbType.Int32, ParameterDirection.Input);
        //        dynamicParameters.Add("@Sorting", sorting, DbType.String, ParameterDirection.Input);
        //        dynamicParameters.Add("@Search", search, DbType.String, ParameterDirection.Input);
        //        dynamicParameters.Add("@LocationId", locationId, DbType.Int16, ParameterDirection.Input);
        //        dynamicParameters.Add("@FromDate", fromDate, DbType.DateTime, ParameterDirection.Input);
        //        dynamicParameters.Add("@ToDate", toDate, DbType.DateTime, ParameterDirection.Input);
        //        dynamicParameters.Add("@DocumentNos", documentNo, DbType.String, ParameterDirection.Input);
        //        dynamicParameters.Add("@ManualDocumentNos", manualDocumentNo, DbType.String, ParameterDirection.Input);
        //        dynamicParameters.Add("@CustomerId", 0, DbType.Int32, ParameterDirection.Input);

        //        // Log the SQL query being executed (for debugging purposes)
        //        var query = "EXEC Usp_Tracking_GetDocketListByPagination @PageNo, @PageSize, @Sorting, @Search, @LocationId, @FromDate, @ToDate, @DocumentNos, @ManualDocumentNos";
        //        Console.WriteLine("Executing query: " + query); // Replace with your preferred logging method

        //        // Execute the query and return data
        //        return DataBaseFactory.QuerySP<Docket>("Usp_Tracking_GetDocketListByPagination", dynamicParameters, "Tracking - GetDocketListByPagination");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error fetching Docket list from database: " + ex.Message); // Replace with your preferred logging method
        //        throw; // Rethrow the exception or handle accordingly
        //    }
        //}


        //public IEnumerable<Docket> GetDocketListByPagination(int pageNo, int pageSize, string sorting, string search, short locationId,
        //DateTime fromDate,
        //DateTime toDate,
        //string documentNo,
        //string manualDocumentNo)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();
        //    dynamicParameters.Add("@PageNo", 1, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());

        //    //dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        //    dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

        //    dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

        //    return DataBaseFactory.QuerySP<Docket>("Usp_Tracking_GetDocketListByPagination", (object)dynamicParameters, "Tracking - GetDocketListByPagination");
        //}

        public string GetVehicleGpsDetails(long fromDate, long toDate, string chassisNo)
        {
            try
            {
                decimal latitude = 0;
                decimal longitude = 0;
                string vehicleLatLongAddress = string.Empty;

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                string vehicleGpsUrl = "https://api.eu-de.apiconnect.appdomain.cloud/vecv-org-dev/production/v2/vehiclelocationdeviceidtracking/vehiclelocationdeviceiddetails";
                var baseVehicleGpsUrl = new Uri(vehicleGpsUrl);
                HttpWebRequest httpVehicleGpsWebRequest = (HttpWebRequest)WebRequest.Create(baseVehicleGpsUrl);
                httpVehicleGpsWebRequest.ContentType = "application/json";
                httpVehicleGpsWebRequest.Method = "POST";
                httpVehicleGpsWebRequest.Headers.Add("X-IBM-Client-Id", "e035ba14-36d3-4ded-81e2-34168ed23a70");
                httpVehicleGpsWebRequest.Headers.Add("X-IBM-Client-Secret", "vC3uD0wD1mT6uH5tO5tQ1uO1lB6dN4vB7wH3kB2tK1eS4eC8eL");
                using (var streamWriter = new StreamWriter(httpVehicleGpsWebRequest.GetRequestStream()))
                {
                    string json = "{\"startDateTime\":" + fromDate.ConvertToString() + ",\"chassisno\":[\"" + chassisNo + "\"],\"endDateTime\":" + toDate.ToString() + ",\"latestOnly\":true }";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }


                var httpVehicleGpsResponse = (HttpWebResponse)httpVehicleGpsWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpVehicleGpsResponse.GetResponseStream()))
                {
                    var vehicleGpsLog = streamReader.ReadToEnd();
                    JArray jsonArray = JArray.Parse(vehicleGpsLog);
                    var data = JObject.Parse(jsonArray[0].ToString());
                    if (data["positiondata"] != null)
                    {
                        latitude = Convert.ToDecimal(data["positiondata"][0]["lattitude"].ToString());
                        longitude = Convert.ToDecimal(data["positiondata"][0]["longitude"].ToString());
                    }
                }

                string latlongAddressUrl = "http://api.positionstack.com/v1/reverse?access_key=5d00eee9dae8e2348a3b0eab0335f8e5&query=" + latitude + "," + longitude;
                var baselatlonAddressUrl = new Uri(latlongAddressUrl);
                HttpWebRequest httplatlonAddressWebRequest = (HttpWebRequest)WebRequest.Create(baselatlonAddressUrl);
                httplatlonAddressWebRequest.ContentType = "application/json";
                httplatlonAddressWebRequest.Method = "GET";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                var httplatlonAddressWebResponse = (HttpWebResponse)httplatlonAddressWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httplatlonAddressWebResponse.GetResponseStream()))
                {
                    var resultmsg = streamReader.ReadToEnd();
                    DataSet ds = jsonToDataSet(resultmsg.ToString());
                    DataTable dtresults = ds.Tables["data"];
                    if (ds.Tables.Contains("data"))
                    {
                        vehicleLatLongAddress = ds.Tables["data"].Rows[0]["label"].ToString();
                    }
                }

                return vehicleLatLongAddress;
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Get Vehicle Gps Details", SessionUtility.LoginUserId, nameof(GetVehicleGpsDetails));
                return string.Empty;
            }
        }

        private DataSet jsonToDataSet(string jsonString)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xd));
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }

}