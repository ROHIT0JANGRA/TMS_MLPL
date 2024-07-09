using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace CodeLock.Areas.Reports.Repository
{
    public class FinanceRepository : BaseRepository, IFinanceRepository, IDisposable
    {
        public bool IsFinanceReportDataExistByReportTypeId(DateTime fromDate, DateTime toDate, short reportTypeId, short locationId, bool isCumulative)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ReportType", (object)reportTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDataExist", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Report_IsFinanceReportDataExistByReportTypeId", (object)dynamicParameters, "Report Excel Download - IsFinanceReportDataExistByReportTypeId");
            return dynamicParameters.Get<bool>("@IsDataExist");
        }

        public IEnumerable<SalesRegisterExcelData> GetSalesRegisterReportData(DateTime fromDate, DateTime toDate,short locationId, bool isCumulative, long CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesRegisterExcelData>("Usp_ReportExcel_SalesRegister", (object)dynamicParameters, "Report Excel Download - SalesRegister");
        }
        public IEnumerable<ExpenseRegisterExcelData> GetExpenseRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long VendorId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ExpenseRegisterExcelData>("Usp_ReportExcel_ExpenseRegister", (object)dynamicParameters, "Report Excel Download - ExpenseRegister");
        }
        public IEnumerable<SalesRegisterExcelData> GetCustomerUnbilledRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesRegisterExcelData>("Usp_ReportExcel_CustomerUnbilledRegister", (object)dynamicParameters, "Report Excel Download - CustomerUnbilledRegister");
        }

        public IEnumerable<SalesRegisterExcelData> GetVendorUnbilledRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long VendorId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesRegisterExcelData>("Usp_ReportExcel_VendorUnbilledRegister", (object)dynamicParameters, "Report Excel Download - VendorUnbilledRegister");
        }

        public IEnumerable<SalesInvoiceRegisterExcelData> GetSalesInvoiceRegisterReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesInvoiceRegisterExcelData>("Usp_ReportExcel_SalesInvoiceRegister", (object)dynamicParameters, "Report Excel Download - SalesInvoiceRegister");
        }
        public IEnumerable<SalesInvoiceRegisterExcelData> GetAutorenewalEwayBillReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesInvoiceRegisterExcelData>("Usp_ReportExcel_AutorenewalEwayBillRegister", (object)dynamicParameters, "Report Excel Download - SalesInvoiceRegister");
        }
        public IEnumerable<SalesInvoiceRegisterExcelData> GetAutorenewalEwayBillErorReportData(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesInvoiceRegisterExcelData>("Usp_ReportExcel_AutorenewalEwayBillErrorRegister", (object)dynamicParameters, "Report Excel Download - SalesInvoiceRegister");
        }

        public IEnumerable<SalesRegisterExcelData> GetSalesRegisterReportWithPartDetails(DateTime fromDate, DateTime toDate, short locationId, bool isCumulative, long CustomerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)isCumulative, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<SalesRegisterExcelData>("Usp_ReportExcel_SalesRegisterWithPartDetails", (object)dynamicParameters, "Report Excel Download - SalesRegister");
        }

    }
}