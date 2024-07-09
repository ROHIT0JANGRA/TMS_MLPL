//  
// Type: CodeLock.Areas.Finance.Repository.IAccountsRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CodeLock.Areas.Finance.Repository
{
    public interface IAccountsRepository : IDisposable
    {
        IEnumerable<VoucherCancellation> GetVoucherCancellation(
            string VoucherNos,
            DateTime fromDate,
            DateTime toDate,
            DateTime finStartDate,
            DateTime finEndDate,
            byte companyId);

        Response VoucherCancellation(VoucherCancellation objVoucherCancellation);

        IEnumerable<AdviceCancellation> GetAdviceCancellation(
           string AdviceNos,
           DateTime fromDate,
           DateTime toDate,
           DateTime finStartDate,
           DateTime finEndDate,
           byte companyId);

        Response AdviceCancellation(AdviceCancellation objAdviceCancellation);

        IEnumerable<SelectListItem> GetAccountCodeListForPaymentModeBank();

        Response ContraVoucher(ContraVoucher objContraVoucher);

        Response CreditDebitVoucher(CreditDebitVoucher objCreditDebitVoucher);

        Response VoucherSummary(VoucherSummary objVoucherSummary);

        Response SpecialCostVoucher(SpecialCostVoucher objSpecialCostVoucher);

        Response JournalVoucher(JournalVoucher objJournalVoucher);

        Response CrossLocationVoucher(CrossLocationVoucher objCrossLocationVoucher);

        Response Advice(Advice objAdvice);

        IEnumerable<AdviceAcknowledgement> GetAdviceListForAcknowledgement(
          string adviceNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId,
          DateTime finStartDate,
          DateTime finEndDate,
          byte companyId);

        Response AdviceAcknowledgement(AdviceAcknowledgement objAdviceAcknowledgement);

        string GetTransactionTypeByVoucherId(long voucherId);

        IEnumerable<Advice> GetAdviceListByAcknowledgementId(long acknowledgementId);

        IEnumerable<CustomerAdjustmentDetail> GetCustomerBillListForAdjustment(
           short vendorId,
         short customerId,
         DateTime fromDate,
         DateTime toDate,
         string billNos,
         string manualbillNos);
        IEnumerable<VendorAdjustmentDetail> GetVendorBillListForAdjustment(
           short vendorId,
         short customerId,
         DateTime fromDate,
         DateTime toDate,
         string billNos,
         string manualbillNos);

        Response CustomerVendorAdjustment(CustomerVendorAdjustment objCustomerVendorAdjustment);
        IEnumerable<AutoCompleteResult> GetAdjustmentList();
    }
}
