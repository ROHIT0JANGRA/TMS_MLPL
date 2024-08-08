using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Reports.Repository
{
  public interface IOperationRepository : IDisposable
  {
    IEnumerable<ReportFieldDetail> GetColumnListByReportId(byte reportId);
    IEnumerable<ReportFieldDetail> GetColumnListByReport(string FormName);
        string GetSearchingCheckedField(string FormName);

    IEnumerable<DocketCharge> GetDocketCharges(byte baseOn, byte baseCode);

    IEnumerable<DocketCharge> GetDeliveryMrCharges(
      byte baseOn,
      byte baseCode);


        /* ########################################################----------Analysis Reports Functions---------------------########################### */

        IEnumerable<IDictionary<string, object>> GetPRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<IDictionary<string, object>> GetDRSReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<IDictionary<string, object>> GetBookingReports(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames,int customerId, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<IDictionary<string, object>> GetInvoiceBookingReport(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames, int customerId, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<PRSReport> GetPRSReportsbyPagination(DateTime fromDate, DateTime toDate, short level, short levelType, int pageNumber, int pageSize);
        IEnumerable<BookingReport> GetBookingDetailsReport(DateTime fromDate, DateTime toDate, short level, short levelType);
        IEnumerable<IDictionary<string, object>> GetManifestReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<IDictionary<string, object>> GetThcReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<IDictionary<string, object>> GetTHCDetailsReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<ExpenseRegisterModel> GetExpenseRegisterReport(DateTime fromDate, DateTime toDate, string DocumentNos, string ManualDocumentNos, string DocumentTypes);
        IEnumerable<IDictionary<string, object>> GetUnloadingReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);
        IEnumerable<IDictionary<string, object>> GeArrivalPendingReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);

        IEnumerable<IDictionary<string, object>> GetPODPendingReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList);

        /* -------------------------------------------------------   Finance Ananlysis Report  -------------------------------------------------------------------               */

        IEnumerable<BillReportModel> GetBillGenarte(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType);
        IEnumerable<ReportBillSubmissionModel> GetBillSubmissionGenerate(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType);



        /* -------------------------------------------------------   FMS Ananlysis Report  -------------------------------------------------------------------               */


        IEnumerable<ReportTripStartModel> GetTripStartReport(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId,string CheckedFieldNames);


    }
}
