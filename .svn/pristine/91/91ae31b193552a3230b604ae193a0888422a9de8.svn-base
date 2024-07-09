using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Reports.Repository
{
    public interface IFinanceRepository : IDisposable
    {
        IEnumerable<SalesInvoiceRegisterExcelData> GetAutorenewalEwayBillErorReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId);
        IEnumerable<SalesInvoiceRegisterExcelData> GetAutorenewalEwayBillReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId);
        bool IsFinanceReportDataExistByReportTypeId(DateTime fromDate, DateTime toDate, short reportTypeId, short locationId, bool isCumulative);
        IEnumerable<SalesRegisterExcelData> GetSalesRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId);
        IEnumerable<ExpenseRegisterExcelData> GetExpenseRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long VendorId);
        IEnumerable<SalesRegisterExcelData> GetCustomerUnbilledRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId);
        IEnumerable<SalesRegisterExcelData> GetVendorUnbilledRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long VendorId);
        IEnumerable<SalesInvoiceRegisterExcelData> GetSalesInvoiceRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId);
        IEnumerable<SalesRegisterExcelData> GetSalesRegisterReportWithPartDetails(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId);
    }
}
