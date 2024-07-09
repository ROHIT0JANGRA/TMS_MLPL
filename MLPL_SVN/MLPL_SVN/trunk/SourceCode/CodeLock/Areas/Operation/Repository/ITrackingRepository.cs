//  
// Type: CodeLock.Areas.Operation.Repository.ITrackingRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
	public interface ITrackingRepository : IDisposable
	{
		Response InsertDocketChangeStatus(DocumentTracking objDocket);
		IEnumerable<DocumentTracking> GetDocketListForChangeStatus(
		  string documentNo);
		IEnumerable<Docket> GetDocketList(
		short locationId,
		DateTime fromDate,
		DateTime toDate,
		string documentNo,
		string manualDocumentNo,
		int CustomerId);

		IEnumerable<Docket> GetDocketPODList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo,
		  int CustomerId,
		  int ListType);
		IEnumerable<Docket> GetDocketList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		string GetVehicleStatus(string vehicleNo);

		IEnumerable<ThcSummary> GetThcList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<Drs> GetDrsList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<Prs> GetPrsList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<LoadingSheet> GetLoadingSheetList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<Tripsheet> GetTripsheetList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<Manifest> GetManifestList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<Pfm> GetPfmList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<Vr> GetVrList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);

		IEnumerable<ConsignmentTracking> GetConsignmentDetailsList(
		  string documentNos,
		  bool documentType);

		ConsignmentTracking GetConsignmentTransitDetails(
		  long docketId,
		  string docketSuffix);

		IEnumerable<DocketTransitDetail> GetConsignmentTransitList(
		  long docketId,
		  string docketSuffix);

		IEnumerable<DocketTalkTracking> GetDocketTalkList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo);
		IEnumerable<UnLoadingSheet> GetUnLoadingSheetList(
		short locationId,
		DateTime fromDate,
		DateTime toDate,
		string documentNo,
		string manualDocumentNo);

		DocketTracking GetDocketTransitSummary(long docketId);

		DocketStatusApi GetApiDocketStatus(string docketNo);
        string GetVehicleGpsDetails(long fromDate, long toDate, string chassisNo);

        OrderTrackingApi OrderTracking(string docketNo);

        DocketTrackingResponseForFarEyeSuccess OrderTrackingForFarEye(string docketNo);

        IEnumerable<Docket> GetDocketListByPagination(int pageNo, int pageSize, string sorting, string search, short locationId,
		DateTime fromDate,
		DateTime toDate,
		string documentNo,
		string manualDocumentNo);



    }
}
