using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Reports.Repository
{
  public interface IOperationRepository : IDisposable
  {
    IEnumerable<ReportFieldDetail> GetColumnListByReportId(byte reportId);
    IEnumerable<ReportFieldDetail> GetColumnListByReport(string FormName);

    IEnumerable<DocketCharge> GetDocketCharges(byte baseOn, byte baseCode);

    IEnumerable<DocketCharge> GetDeliveryMrCharges(
      byte baseOn,
      byte baseCode);


        /* ########################################################----------Analysis Reports Functions---------------------########################### */

        //IEnumerable<Prs> GetPrsAnalysisReport(DateTime fromDate, DateTime toDate, short locationId);
        IEnumerable<PRSReport> GetPRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames);

        IEnumerable<DRSReportModel> GetDRSReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames);

        IEnumerable<BookingReport> GetBookingReports(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames,int customerId);

        IEnumerable<PRSReport> GetPRSReportsbyPagination(DateTime fromDate, DateTime toDate, short level, short levelType, int pageNumber, int pageSize);
        IEnumerable<BookingReport> GetBookingDetailsReport(DateTime fromDate, DateTime toDate, short level, short levelType);
        IEnumerable<ManifestReport> GetManifiestReport(DateTime fromDate, DateTime toDate, short level, short levelType);
        IEnumerable<THCReport> GetThcReport(DateTime fromDate, DateTime toDate, short level, short levelType);
        IEnumerable<THCReport> GetThcDetailsReport(DateTime fromDate, DateTime toDate, short level, short levelType);
        IEnumerable<ExpenseRegisterModel> GetExpenseRegisterReport(DateTime fromDate, DateTime toDate, string DocumentNos, string ManualDocumentNos, string DocumentTypes);

        IEnumerable<UnloadingReportModel> GetUnloadingReport(DateTime fromDate, DateTime toDate, short level, short levelType);
        IEnumerable<ArrivalReport> GeArrivalPendingReport(DateTime fromDate, DateTime toDate, short level, short levelType);

        IEnumerable<PODPendingReport> GetPODPendingReport(DateTime fromDate, DateTime toDate, short level, short levelType);

        /* -------------------------------------------------------   Finance Ananlysis Report  -------------------------------------------------------------------               */

        IEnumerable<BillReportModel> GetBillGenarte(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType);
        IEnumerable<ReportBillSubmissionModel> GetBillSubmissionGenerate(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType);



        /* -------------------------------------------------------   FMS Ananlysis Report  -------------------------------------------------------------------               */


        IEnumerable<ReportTripStartModel> GetTripStartReport(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId,string CheckedFieldNames);


    }
}
