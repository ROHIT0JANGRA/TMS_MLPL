//  
// Type: CodeLock.Areas.Finance.Repository.ICustomerBillRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace CodeLock.Areas.Finance.Repository
{
  public interface ICustomerBillRepository : IDisposable
  {
        Docket AddDocketList(string docketNos, string CustomerId, byte TransactionTypeId);
        Response BillEInvoice(BillFinalizationDetail objBillFinalization);
        IEnumerable<BillFinalizationDetail> RegenerateEInvoice(long userId);
        IEnumerable<BillFinalizationDetail> GenerationErrorList(long userId);
        DataSet GenerateEInvoice(long BillId);
        Response ReGenerate(CustomerBill objCustomerBill);
        CustomerBill GetDocketListGstForCustomerBillEdit(long LoginLocationId,string BillNo, string DocketNo);
        CustomerBill GetDocketListGstForCustomerBillGenerationMLPL(
                short customerId,
                DateTime fromDate,
                DateTime toDate,
                byte gstServiceTypeId,
                byte customerGstStateId,
                byte companyGstStateId,
                byte paybasId,
                byte serviceTypeId,
                byte ftlTypeId,
                string finYear,
                DateTime finStartDate,
                DateTime finEndDate,
                short locationId,
                byte companyId, string ManifestId, string VendorId, string docketNos, byte TransactionTypeId);

        IEnumerable<CreditDebitNoteDetail> CreditDebitNoteBillData(bool isCreditNote,bool IsGst, byte billTypeId, string fromDate, string toDate, short partyId, string billNos, string manualBillNos, string transportModeId);
        Response InsertCreditDebitNote(CreditDebitNote objBilling);
        IEnumerable<CreditDebitNote> GetCreditDebitNoteListForCancellation(
        string NoteNo,
        DateTime fromDate,
        DateTime toDate,
        short locationId);
        Response CancellationCreditDebitNote(CreditDebitNote objCancellation);

        IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerBillGenerationDumtco(
       short customerId,
       DateTime fromDate,
       DateTime toDate,
       byte gstServiceTypeId,
       byte customerGstStateId,
       byte companyGstStateId,
       byte paybasId,
       byte serviceTypeId,
       byte ftlTypeId,
       string finYear,
       DateTime finStartDate,
       DateTime finEndDate,
       short locationId,
       byte companyId, string ManifestId, string VendorId, bool isRcm, String DocketNo);

        Response MilkRunSheetBill(MilkRunBilling objTripBilling);
      IEnumerable<MilkRunBillingDetail> GetMilkRunCustomerBillDetails(
                          short customerId,
                          DateTime fromDate,
                          DateTime toDate,
                          short GstServiceTypeId, string VehicleId, string TripsheetNo);
    Response TripSheetBill(TripBilling objTripBilling);
    IEnumerable<AutoCompleteResult> GetServiceTaxList();
    IEnumerable<TripBillDetail> GetTripCustomerBillDetailsNew(
                        short customerId,
                        DateTime fromDate,
                        DateTime toDate,
                        short GstServiceTypeId);


        IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerBillGenerationTriSpeed(
          short customerId,
          DateTime fromDate,
          DateTime toDate,
          byte gstServiceTypeId,
          byte customerGstStateId,
          byte companyGstStateId,
          byte paybasId,
          byte serviceTypeId,
          byte ftlTypeId,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId, byte DocketStatusId, string PONo, short billtypeInterIntra, short ownerType,short ownerId);
    IEnumerable<CustomerBillDetail> GetDocketListForCustomerBillGeneration(
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      byte serviceTax,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

        IEnumerable<CustomerBillDetail> GetTripCustomerBillDetails(
        short customerId,
        DateTime fromDate,
        DateTime toDate,
        byte serviceTypeId,
        string finYear,
        short locationId,
        byte companyId,
        short SacId,
        int fromcityid,
        int tocityid);

        Response Generate(CustomerBill objCustomerBill);

    CustomerBill GetCustomerBillDetailById(long billId);

    IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerBillGeneration(
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      byte gstServiceTypeId,
      byte customerGstStateId,
      byte companyGstStateId,
      byte paybasId,
      byte serviceTypeId,
      byte ftlTypeId,
      short billtypeInterIntra,
      short ownerType, 
      short ownerId,
      bool rcmyn,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

    CustomerBillSupplementryDetail GetGstRate(short servicesId);

    bool IsManualBillNoAvailable(long billId, string manualNo);

    IEnumerable<CustomerBill> GetCustomerBillListForSubmission(
      string billNos,
      string manualBillNos,
      byte paybas,
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

    Response Submission(CustomerBillSubmission objCustomerBillSubmission);

    IEnumerable<CustomerBill> GetCustomerBillListForUnSubmission(
      string billNos,
      string manualBillNos,
      byte paybas,
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

    Response UnSubmission(
      CustomerBillUnSubmission objCustomerBillUnSubmission);

    IEnumerable<CustomerBill> GetCustomerBillListForCollection(
      string billNos,
      string manualBillNos,
      byte paybas,
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId,
      string customerGroup);

    Response Collection(CustomerBillCollection objCollection);

    IEnumerable<BillFinalizationDetail> GetCustomerBillListForFinalization(
      string billNos,
      DateTime fromDate,
      DateTime toDate,
      short customerId,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId,
      byte paybas,
      string manualBillNos);

    Response BillFinalization(BillFinalization objBillFinalization);

    IEnumerable<Docket> GetDocketListForDocketFinalization(
      string docketNos,
      DateTime fromDate,
      DateTime toDate,
      short customerId,
      string finYear,
      short locationId,
      byte companyId);

    Response DocketFinalization(DocketFinalization objDocketFinalization);

    IEnumerable<CustomerBillDetail> GetMrDocketList(
      bool isDeliveredByConsignee,
      short customerId,
      string docketNos,
      string docketSuffix,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

    IEnumerable<CustomerBillDetail> GetMrDocketListByMrId(long mrId);

    CustomerBillCharges GetDeliveryCharges();

    IEnumerable<DeliveryMrDone> DeliveryMr(
      DeliveryMrHeader objDeliveryMrHeader);

    Response SupplementaryBill(SupplementryBill objSupplementryBill);

    Response GstSupDatailAdd(GstGeneration objCustomerBill);

    Response MiscellaneousBill(GstGeneration objCustomerBill);

    IEnumerable<CustomerBill> GetCustomerBillListForCancellation(
      string billNos,
      string manualBillNos,
      byte paybas,
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

    Response Cancellation(
      CustomerBillCancellation objCustomerBillCancellation);

    Response MrCancellation(MrCancellation objMrCancellation);
    Response DeliveryMrCancellation(MrCancellation objMrCancellation);

        IEnumerable<MrCancellation> GetMrBillListForCancellation(
      string mrNos,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId);

        IEnumerable<MrCancellation> GetDeliveryMrBillListForCancellation(
           string mrNos,
           DateTime fromDate,
           DateTime toDate,
           DateTime finStartDate,
           DateTime finEndDate,
           short locationId,
           byte companyId);

      

    IEnumerable<CustomerBillDetail> GetCustomerBillDocketListById(
      long billId);

    AutoCompleteResult IsBillNoExist(
      string billNo,
      string finYear,
      short locationId,
      byte companyId);

        IEnumerable<CustomerBillDetail> GetTHCNoFromManifest(
        string ManifestId);

        IEnumerable<AutoCompleteResult> GetManifestList(short locationId, string CustomerId, string VendorId, byte paybaseId);

        BillUploadInSystem UploadInSystem(BillUploadInSystem objDocketUploadInSystem);

        IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerGatePassBillGeneration(
     short customerId,
     DateTime fromDate,
     DateTime toDate,
     byte gstServiceTypeId,
     byte customerGstStateId,
     byte companyGstStateId,
     byte paybasId,
     byte serviceTypeId,
     byte ftlTypeId,
     string finYear,
     DateTime finStartDate,
     DateTime finEndDate,
     short locationId,
     byte companyId);

        Response GenerateDeliveryBill(CustomerBill objCustomerBill);

        Response InsertBillReAssign(BillReAssign objBill);
        BillReAssign CheckValidBillNoForReAssign(string BillNo);

        Docket GetDocketChargeDetails(Docket objDocket);
    }
}
