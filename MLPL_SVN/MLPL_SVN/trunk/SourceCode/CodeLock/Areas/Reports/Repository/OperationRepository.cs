using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CodeLock.Areas.Reports.Repository
{
  public class OperationRepository : BaseRepository, IOperationRepository, IDisposable
  {
        public IEnumerable<ReportFieldDetail> GetColumnListByReportId(
        byte reportId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ReportId", (object)reportId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ReportFieldDetail>("Usp_Report_GetColumnListByReportId", (object)dynamicParameters, "Report - GetColumnListReportId");
        }
        public IEnumerable<ReportFieldDetail> GetColumnListByReport(string FormName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FormName", (object)FormName, new DbType?(DbType.String), new ParameterDirection?());
            return DataBaseFactory.QuerySP<ReportFieldDetail>("Usp_Report_GetColumnListByReport", (object)dynamicParameters, "Report - GetColumnListReportId");
        }
        public IEnumerable<DocketCharge> GetDocketCharges(
          byte baseOn,
          byte baseCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BaseOn", (object)baseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseCode", (object)baseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketCharge>("Usp_Report_GetDocketCharges", (object)dynamicParameters, "Report - GetDocketCharges");
        }

        public IEnumerable<DocketCharge> GetDeliveryMrCharges(
          byte baseOn,
          byte baseCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BaseOn", (object)baseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseCode", (object)baseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketCharge>("Usp_Report_GetDeliveryMrCharges", (object)dynamicParameters, "Report - GetDeliveryMrCharges");
        }
        // ***************************************************************   Analysis Report  Modules ***************************************************************************                 
        public IEnumerable<IDictionary<string, object>> GetPRSReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            // Define the dynamic parameters
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if(AdvanceFilterColumnsList!=null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_PRS_Test", dynamicParameters, "PRS Reports - GetPRSReports", "PRSReport");
        }
        public IEnumerable<IDictionary<string, object>> GetDRSReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_DRS", dynamicParameters, "DRS Reports - GetDRSReports","DRSReport");

        }

        public IEnumerable<IDictionary<string, object>> GetBookingReports(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames,int customerId, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@FromLocationID", FromLocationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", CompanyId, DbType.Int32);
            dynamicParameters.Add("@ToLocationId", ToLocationId, DbType.Int32);
            dynamicParameters.Add("@CustomerId", customerId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            // Execute the stored procedure and return the results
            return DataBaseFactory.QuerySP("Usp_Report_Booking", dynamicParameters, "BookingDetails Reports - GetBookingDetailsReport","BookingReport");
        }

        public IEnumerable<IDictionary<string, object>> GetInvoiceBookingReport(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames, int customerId, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@FromLocationID", FromLocationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", CompanyId, DbType.Int32);
            dynamicParameters.Add("@ToLocationId", ToLocationId, DbType.Int32);
            dynamicParameters.Add("@CustomerId", customerId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            // Execute the stored procedure and return the results
            return DataBaseFactory.QuerySP("Usp_Report_InvoiceBooking_Details", dynamicParameters, "Invoice Booking Report - GetInvoiceBookingReport", "BookingReport");
        }
        public IEnumerable<BookingReport> GetBookingDetailsReport(DateTime fromDate, DateTime toDate, short level, short levelType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@Level", level, DbType.Int16);
            dynamicParameters.Add("@LevelType", levelType, DbType.Int16);

            // Execute the stored procedure and return the results
            return DataBaseFactory.QuerySP<BookingReport>("Usp_Report_Booking_Details", dynamicParameters, "BookingDetails Reports - GetBookingDetailsReport");
        }
        public IEnumerable<IDictionary<string, object>> GetManifestReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_Manifest", dynamicParameters, "ManifestReport - GetManifiestReport", "ManifestReport");

        }
        public IEnumerable<IDictionary<string, object>> GetThcReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_THC", dynamicParameters, "Usp_Report_THC - GetThcReport", "ThcReport");

        }
        public IEnumerable<IDictionary<string, object>> GetTHCDetailsReports(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_THCDetails", dynamicParameters, "THCDetailsReports - GetTHCDetailsReports", "THCDetailsReports");

        }       
        public IEnumerable<ExpenseRegisterModel> GetExpenseRegisterReport(DateTime fromDate, DateTime toDate, string DocumentNos, string ManualDocumentNos, string DocumentTypes)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@DocumentNos", DocumentNos, DbType.String);
            dynamicParameters.Add("@ManualDocumentNos", ManualDocumentNos, DbType.String);
            dynamicParameters.Add("@DocumentTypes", DocumentTypes, DbType.String);

            // Execute the stored procedure and return the results
            return DataBaseFactory.QuerySP<ExpenseRegisterModel>("[Usp_Report_ExpenseRegister]", dynamicParameters, "ExpenseRegister Reports - GetExpenseRegisterReport");

        }
        public IEnumerable<IDictionary<string, object>> GetUnloadingReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_Unloading", dynamicParameters, "Usp_Report_Unloading - GetUnloadingReport", "UnloadingReport");

        }      

        public IEnumerable<PRSReport> GetPRSReportsbyPagination(
        DateTime fromDate, DateTime toDate, short level, short levelType, int pageNumber, int pageSize)
        {
            // Define the dynamic parameters
            DynamicParameters dynamicParameters = new DynamicParameters();            
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@Level", level, DbType.Int16);
            dynamicParameters.Add("@LevelType", levelType, DbType.Int16);
            dynamicParameters.Add("@PageNumber", pageNumber, DbType.Int32);
            dynamicParameters.Add("@PageSize", pageSize, DbType.Int32);

            // Execute the stored procedure and return the results
            return DataBaseFactory.QuerySP<PRSReport>(
                "Usp_PRS_Reports",
                dynamicParameters,
                "PRS Reports - GetPRSReports");
        }
        public IEnumerable<IDictionary<string, object>> GeArrivalPendingReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_PendingArrival", dynamicParameters, "Usp_Report_PendingArrival - GeArrivalPendingReport", "ArrivalPendingReport");

        }

        public IEnumerable<IDictionary<string, object>> GetPODPendingReport(DateTime fromDate, DateTime toDate, short locationID, short companyId, string CheckedFieldNames, List<AdvanceFilterColumns> AdvanceFilterColumnsList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@LocationID", locationID, DbType.Int32);
            dynamicParameters.Add("@CompanyId", companyId, DbType.Int32);
            dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
            if (AdvanceFilterColumnsList != null && AdvanceFilterColumnsList.Count > 0)
            {
                dynamicParameters.Add("@AdvanceFilterColumnsList", (object)XmlUtility.XmlSerializeToString((object)AdvanceFilterColumnsList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());        // Execute the stored procedure and return the results
            }
            return DataBaseFactory.QuerySP("Usp_Report_PODPending", dynamicParameters, "Usp_Report_PODPending - GePODPendingReport", "PODPendingReport");

        }
        public IEnumerable<BillReportModel> GetBillGenarte(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
            dynamicParameters.Add("@ToDate", toDate, DbType.Date);
            dynamicParameters.Add("@Level", level, DbType.Int16);
            dynamicParameters.Add("@LevelType", levelType, DbType.Int16);
            dynamicParameters.Add("@Customer", Customer, DbType.String);
            dynamicParameters.Add("@BillType", BillType, DbType.Int16);


            // Execute the stored procedure and return the results
            return DataBaseFactory.QuerySP<BillReportModel>("Usp_Report_Bill", dynamicParameters, "Usp_Report_Bills Reports - GetBillGenarteReport");
        }
        public IEnumerable<ReportBillSubmissionModel> GetBillSubmissionGenerate(DateTime fromDate, DateTime toDate, short level, short levelType, string Customer, int BillType)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
                dynamicParameters.Add("@ToDate", toDate, DbType.Date);
                dynamicParameters.Add("@Level", level, DbType.Int16);
                dynamicParameters.Add("@LevelType", levelType, DbType.Int16);
                dynamicParameters.Add("@Customer", Customer, DbType.String);
                dynamicParameters.Add("@BillType", BillType, DbType.Int16);

                // Execute the stored procedure and return the results
                var results = DataBaseFactory.QuerySP<ReportBillSubmissionModel>("Usp_Report_Bill_Submission", dynamicParameters, "Usp_Report_Bill_Submission Reports - GetBillSubmissionGenerate");

                // Convert SubmissionNo to string if necessary
                foreach (var result in results)
                {
                    result.SubmissionNo = result.SubmissionNo.ToString(); // Convert int to string
                }

                return results;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Exception occurred: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                throw;
            }
        }

        /* **********************************************************************    FMS ANALYSIS ***************************************************************************** */
        public IEnumerable<ReportTripStartModel> GetTripStartReport(DateTime fromDate, DateTime toDate, short FromLocationID, short CompanyId, short ToLocationId, string CheckedFieldNames)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromDate", fromDate, DbType.Date);
                dynamicParameters.Add("@ToDate", toDate, DbType.Date);
                dynamicParameters.Add("@FromLocationID", FromLocationID, DbType.Int32);
                dynamicParameters.Add("@CompanyId", CompanyId, DbType.Int32);
                dynamicParameters.Add("@ToLocationId", ToLocationId, DbType.Int32);
                dynamicParameters.Add("@CheckedFieldNames", CheckedFieldNames, DbType.String);
                // Execute the stored procedure and return the results
                return DataBaseFactory.QuerySP<ReportTripStartModel>("Usp_Report_TripStart", dynamicParameters, "Usp_Report_TripStart Reports - GetTripStartReport");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Exception occurred: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                throw;
            }
        }
        public string GetSearchingCheckedField(string FormName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FormName", FormName, DbType.String);
            dynamicParameters.Add("@CheckboxFieldName", "", new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            var res = DataBaseFactory.QuerySP("USP_GetSearchingCheckedField", (object)dynamicParameters, "USP_GetSearchingCheckedField- GetSearchingCheckedField");
            return dynamicParameters.Get<string>("@CheckboxFieldName");           
        }

    }
}
