//  
// Type: CodeLock.Areas.Finance.Repository.AccountsRepository
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
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Repository
{
    public class AccountsRepository : BaseRepository, IAccountsRepository, IDisposable
    {

        public IEnumerable<VoucherCancellation> GetVoucherCancellation(
                   string VoucherNos,
                   DateTime fromDate,
                   DateTime toDate,
                   DateTime finStartDate,
                   DateTime finEndDate,
                   byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VoucherNos", (object)VoucherNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VoucherCancellation>("Usp_VoucherCancellation_GetVoucherList", (object)dynamicParameters, "Voucher Cancellation - GetVoucherCancellation");
        }

        public Response VoucherCancellation(VoucherCancellation objVoucherCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVoucherCancellation", (object)XmlUtility.XmlSerializeToString((object)objVoucherCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VoucherCancellation_Insert", (object)dynamicParameters, "Voucher - VoucherCancellation").FirstOrDefault<Response>();
        }


        public IEnumerable<AdviceCancellation> GetAdviceCancellation(
                  string AdviceNos,
           DateTime fromDate,
           DateTime toDate,
           DateTime finStartDate,
           DateTime finEndDate,
           byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AdviceNos", (object)AdviceNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AdviceCancellation>("Usp_Advice_GetCancellationList", (object)dynamicParameters, "Advice Cancellation - GetAdviceCancellation");
        }

        public Response AdviceCancellation(AdviceCancellation objAdviceCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlAdviceCancellation", (object)XmlUtility.XmlSerializeToString((object)objAdviceCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_AdviceCancellation_Insert", (object)dynamicParameters, "Advice - AdviceCancellation").FirstOrDefault<Response>();
        }


        public IEnumerable<SelectListItem> GetAccountCodeListForPaymentModeBank()
        {
            return (IEnumerable<SelectListItem>)new List<SelectListItem>()
      {
        new SelectListItem() { Value = "H", Text = "HDFC Bank" }
      };
        }

        public Response ContraVoucher(ContraVoucher objContraVoucher)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlContraVoucher", (object)XmlUtility.XmlSerializeToString((object)objContraVoucher), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_ContraVoucher_Insert", (object)dynamicParameters, "Accounting - ContraVoucher").FirstOrDefault<Response>();
        }

        public Response CreditDebitVoucher(CreditDebitVoucher objCreditDebitVoucher)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCreditDebitVoucher", (object)XmlUtility.XmlSerializeToString((object)objCreditDebitVoucher), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CreditDebitVoucher_Insert", (object)dynamicParameters, "Accounting - CreditDebitVoucher").FirstOrDefault<Response>();
        }

        public Response VoucherSummary(VoucherSummary objVoucherSummary)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVoucherSummary", (object)XmlUtility.XmlSerializeToString((object)objVoucherSummary), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VoucherSummary_Insert", (object)dynamicParameters, "Accounting - VoucherSummary").FirstOrDefault<Response>();
        }

        public Response SpecialCostVoucher(SpecialCostVoucher objSpecialCostVoucher)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlSpecialCostVoucher", (object)XmlUtility.XmlSerializeToString((object)objSpecialCostVoucher), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_SpecialCostVoucher_Insert", (object)dynamicParameters, "Accounting - SpecialCostVoucher").FirstOrDefault<Response>();
        }

        public Response JournalVoucher(JournalVoucher objJournalVoucher)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlJournalVoucher", (object)XmlUtility.XmlSerializeToString((object)objJournalVoucher), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_JournalVoucher_Insert", (object)dynamicParameters, "Accounting - JournalVoucher").FirstOrDefault<Response>();
        }

        public Response CrossLocationVoucher(CrossLocationVoucher objCrossLocationVoucher)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlContraVoucher", (object)XmlUtility.XmlSerializeToString((object)objCrossLocationVoucher), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CrossLocationVoucher_Insert", (object)dynamicParameters, "Accounting - CrossLocationVoucher").FirstOrDefault<Response>();
        }

        public Response Advice(Advice objAdvice)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlAdvice", (object)XmlUtility.XmlSerializeToString((object)objAdvice), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Advice_Insert", (object)dynamicParameters, "Accounting - Advice Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<AdviceAcknowledgement> GetAdviceListForAcknowledgement(
          string adviceNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId,
          DateTime finStartDate,
          DateTime finEndDate,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AdviceNos", (object)adviceNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AdviceAcknowledgement>("Usp_Advice_GetAdviceListForAcknowledgement", (object)dynamicParameters, "Advice - GetAdviceListForAcknowledgement");
        }

        public Response AdviceAcknowledgement(AdviceAcknowledgement objAdviceAcknowledgement)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlAdviceAcknowledgement", (object)XmlUtility.XmlSerializeToString((object)objAdviceAcknowledgement), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Advice_AdviceAcknowledgement_Insert", (object)dynamicParameters, "Advice - AdviceAcknowledgement").FirstOrDefault<Response>();
        }

        public string GetTransactionTypeByVoucherId(long voucherId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@voucherId", (object)voucherId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            AutoCompleteResult autoCompleteResult = new AutoCompleteResult();
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_GetTransactionTypeByVoucherId", (object)dynamicParameters, "Accounting - GetTransactionTypeByVoucherId").FirstOrDefault<AutoCompleteResult>().Description;
        }

        public IEnumerable<Advice> GetAdviceListByAcknowledgementId(
          long acknowledgementId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AcknowledgementId", (object)acknowledgementId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Advice>("Usp_Advice_GetAdviceListByAcknowledgementId", (object)dynamicParameters, "Advice - GetAdviceListByAcknowledgementId");
        }

        public IEnumerable<CustomerAdjustmentDetail> GetCustomerBillListForAdjustment(
           short vendorId,
         short customerId,
         DateTime fromDate,
         DateTime toDate,
         string billNos,
         string manualbillNos)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualbillNos", (object)manualbillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerAdjustmentDetail>("Usp_Adjustment_GetCustomerBillListForAdjustment", (object)dynamicParameters, "Adjustment - GetCustomerBillListForAdjustment");
        }
        public IEnumerable<VendorAdjustmentDetail> GetVendorBillListForAdjustment(
           short vendorId,
         short customerId,
         DateTime fromDate,
         DateTime toDate,
         string billNos,
         string manualbillNos)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualbillNos", (object)manualbillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorAdjustmentDetail>("Usp_Adjustment_GetVendorBillListForAdjustment", (object)dynamicParameters, "Adjustment - GetVendorBillListForAdjustment");
        }

        public Response CustomerVendorAdjustment(CustomerVendorAdjustment objCustomerVendorAdjustment)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Xml", (object)XmlUtility.XmlSerializeToString((object)objCustomerVendorAdjustment), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Adjustment_Insert", (object)dynamicParameters, "Adjustment - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetAdjustmentList()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Adjustment_GetAdjustmentList", (object)dynamicParameters, "Adjustment - GetVendorBillListForAdjustment");
        }
    }
}
