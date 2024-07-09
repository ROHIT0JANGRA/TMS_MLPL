//  
// Type: CodeLock.Areas.Finance.Repository.IVendorPaymentRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Finance.Repository
{
    public interface IVendorPaymentRepository : IDisposable
    {
        IEnumerable<VendorBillDetail> GetBillListForBillCancellation(
            short vendorId,
            DateTime fromDate,
            DateTime toDate,
            DateTime finStartDate,
            DateTime FinEndDate,
            string billNos);

        Response VendorBillCancellation(VendorBillCancellation objBillCancellation);


        IEnumerable<VendorDocument> GetDocumentListForAdvancePayment(
      VendorAdvancePayment objVendorAdvancePayment);

        Response AdvancePaymentInsert(VendorAdvancePayment objVendorAdvancePayment);

        IEnumerable<VendorDocument> GetDocumentDetailForAdvancePayment(
          List<VendorDocument> objVendorDocument, short LocationId);

        IEnumerable<VendorDocument> GetDocumentListForVehicleHireBillGeneration(
          VendorBillGeneration objVendorBillGeneration);

        IEnumerable<VendorDocument> GetDocumentDetailForVehicleHireBillGeneration(
          List<VendorDocument> objVendorDocument);

        Response VehicleHireBillInsert(VendorBillGeneration objVendorBillGeneration);

        VendorBillCharges GetBillCharges();

        Response OtherBillInsert(OtherBillEntry objOtherBillEntry);

        IEnumerable<BaBillDetail> GetDocumentListForBaBillGeneration(
          short VendorId, DateTime FromDate, DateTime ToDate, string DocumentNo, short LocationId);

        IEnumerable<BaBillDetail> GetDocumentDetailForBaBillGeneration(
          List<long> DocketId);

        Response BaBillInsert(BaBillEntry objBaBillEntry);

        IEnumerable<VendorBillDetail> GetBillListForBillFinalization(
          short locationId,
          short vendorId,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime FinEndDate,
          string billNos);

        Response BillFinalization(VendorBillFinalization objBillFinalization);
        Response VendorBillFinalization(VendorBillFinalizationProcess objBillFinalization);
        Response VendorBillFinalizationV1(VendorBillFinalizationProcess objBillFinalization);

        IEnumerable<VendorBillDetail> GetBillListForBillPayment(
      VendorBillPayment objVendorBillPayment);

        IEnumerable<VendorBillDetail> GetBillDetailForBillPayment(
          string billId);

        Response BillPayment(VendorBillPayment objVendorBillPayment);

        VendorBillUpload InsertVendorBill(VendorBillUpload objVendorBillUpload);

        ChangeAdvanceBalanceLocation ValidateDocumentIdForAdvanceBalanceLocation(
          string DocumentNo);

        Response ChangeAdvanceBalanceLocation(
          ChangeAdvanceBalanceLocation objChangeAdvanceBalanceLocation);

        Response VendorBillPaymentCancellation(VendorBillPaymentCancellation objVendorBillPaymentCancellation);

        IEnumerable<VendorBillPaymentCancellation> GetVendorBillPaymentCancellation(
      string PaymentNos,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

        IEnumerable<VendorAdvancePaymentCancellation> GetVendorAdvancePaymentCancellation(
      string PaymentNos,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

        Response VendorAdvancePaymentCancellation(VendorAdvancePaymentCancellation objVendorAdvancePaymentCancellation);

        VendorBillUploadInSystem UploadInSystem(VendorBillUploadInSystem objDocketUploadInSystem);

        IEnumerable<ThcAdvBalPaymnt_Details> GetMultiAdvanceBalanceData(string DocumentNo);

        Response InsertBillReAssign(LabourDCModule objBill);
        LabourDCModule CheckValidBillNoForReAssign(string LabourDCNo);

        Response InsertVendorBillReAssign(VendorBillReAssign objBill);
        VendorBillReAssign CheckValidVendorBillNoForReAssign(string BillNo);

        AutoCompleteResult IsOtherManualBillNoExist(short vendorId, string manualBillNo, string finYear, short locationId, byte companyId);
    }
}
