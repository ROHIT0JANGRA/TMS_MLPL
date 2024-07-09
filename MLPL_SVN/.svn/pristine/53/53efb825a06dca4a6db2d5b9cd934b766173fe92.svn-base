//  
// Type: CodeLock.Areas.Operation.Repository.IDocketRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CodeLock.Areas.Operation.Repository
{
    public interface IDocketRepository : IDisposable
    {

        ModelNICEwayBillAppKeyResponse IRISEwayBillAuthentication();
        Task<TaxProEwayExtendValidityApiResponse> TaxProExtendValidityAuthToken(TaxProEwayExtendValidityRequest req, string authToken);
        Task<string> GetTaxProGetAuthDetail();
        Task<TaxProGetEwayApiResponse> ValidateTaxProEwayBillAuthToken(string ewbNo, string authToken);
        IEnumerable<TripsheetForAdityaBirlaSummary> GetAdityaBirlaTripsheetBulk(string UserId);
        Response InsertEWayBillForExtension(TaxProEwayExtendValidityApiResponse obj);
        IEnumerable<TaxProEwayExtendValidityRequest> GetEWayBillForExtensionList(string UserId);
        ResponseResult ApiOrderUploadPumaDarcl(PickUpDetailRequest pickUpDetailRequest);
        Task<TaxProGetEwayApiResponse> ValidateTaxProEwayBill(string ewbNo);
        DocketStep3 GetStep3DetailforPincode(Docket objDocket);
        DocketStatusApi UpdayeAdityaBirlaTripsheetById(string tripsheetsumid);
        ResponseResult ApiOrderUploadAdityaBirlaEssential(PickUpDetailRequest pickUpDetailRequest);
        TripsheetForAdityaBirlaMain GetAdityaBirlaTripsheetById(string tripsheetsumid);
        IEnumerable<TripsheetForAdityaBirlaSummary> GetAdityaBirlaTripsheet(string UserId);
        DocketStatusApi InsertTripsheetForAdityaBirlaEWBN(TripsheetForAdityaBirlaMain obj);
        DocketStatusApi InsertTripsheetForAdityaBirlaSummary(TripsheetForAdityaBirlaMain obj);
        DocketStatusApi InsertTripsheetForAdityaBirla(TripsheetForAdityaBirlaMain obj);
        Response EssentialDocketInsert(Docket objDocket);
        IEnumerable<DocketBarcodeDetail> GetDocketBarcodeGetById(string documentId);
        IEnumerable<DocketBarcodeDetail> DocketBarcodeList(string UserId);
        Response CreatePktBarCode(long DocketId, string DocumentType);
        Task<string> RivigoBookingCreate();
        //Task<string> RivigoGetAuthAtcive();
        Task<string> RivigoGetAuthDetail();
        IEnumerable<TaxProEwayTripSheetApiResponse> TaxProGetEwayBillConsolidateList(string UserId);
        Task<byte[]> TaxProPrintEwayConsolidated(string cEwbNo);
        Task<TaxProEwayConsolidateApiResponse> TaxProEwayConsolidated(string DocumentId, string DocumentType, string EntryBy);
        IEnumerable<TaxProGetEwayDetailsForTransporterByStateApiResponse> TaxProGetEwayBillList(string UserId);
        TaxProGetEwayDetailsForTransporterByStateApiResponse TaxProGetEwayDetails(string ewbNo);
        Task<TaxProGetEwayDetailsForTransporterByStateApiResponse> TaxProGetEwayBillDetail(string ewbNo);
        Task<TaxProEwayExtendValidityApiResponse> TaxProExtendValidity(TaxProEwayExtendValidityRequest req);
        Task<IEnumerable<TaxProGetEwayForTransporterByStateApiResponse>> GetEwayBillsForTransporterByState(TaxProGetEwayForTransporterByStateRequest transporterRequest);
        Task<IEnumerable<GetEwayForDetails>> GetEWBTransporter(GetEwayDetailsRequest ewayreq, string baseURI);
        Task<IEnumerable<ExtandValidityModel>> ExtandEwayValidity(ExtandValidityRequest extandValidity, string baseURI);
        IEnumerable<GetEwayForTransporter> GetEWBForTransporter(GetEwayForTransporterRequest transporterRequest, string baseURI);

        Response GetStep6DetailForReinvoke(string DocketId);
        Docket GetStep6DetailByIdByChangeAmount(long docketId);
        DocketStep6 ChangeDocketList(string DocketId);
        Response CheckValidTHCNoForUpdate(string THCNo, int ToSave);
        IEnumerable<Response> CheckValidThcForUpdate(string ThcId, string VendorId, string updateFor, string LRNo);
        Thc ThcGetDetailById(string ThcId);
        long CheckDocketDimension(string DocketId);
        Docket DocketGetDetailById(string DocketId);
        IEnumerable<MasterCharge> GetDocketChargeList(string DocketId);
        IEnumerable<LoadingSheetDocket> GetDocketListForRecalculate(
                   byte companyId,
                   short locationId,
                   string docketList,
                   DateTime fromDate,
                   DateTime toDate,
                   byte transportModeId,
                   int fromCityId,
                   int toCityId,
                   string toLocationList,
                   string zoneList,
                   long CustomerId
                   , string PickupList);
        IEnumerable<RecalculateDetail> GetRecalculate(DocketSearch objDocket);
        DocketStatus DocketStatusGetByCode(string DocketNo);
        IEnumerable<DocketStatus> DocketStatusGetAll(string CustomerId, string Fromdate, string ToDate, string flag);
        Response InsertDocketStatus(DocketStatus objDocket);
        DocketStatus DocketStatusGetById(string DocketId);
        IEnumerable<AutoCompleteResult> DocketStatusList(string DocketId);

        Response InsertDocketReAssign(DocketReAssign objDocket);
        DocketReAssign CheckValidDocketNoForReAssign(string docketNo);
        IEnumerable<DocketGPRO_Details> GetGPRODetails(long id,byte CompanyId);

        DocketStep1 GetStep1Detail(short locationId, byte companyId);

        DocketStep2 GetStep2Detail(Docket objDocket);

        DocketStep3 GetStep3Detail(Docket objDocket);

        DocketStep4 GetStep4Detail(Docket objDocket);

        DocketStep5 GetStep5Detail(Docket objDocket);

        DocketStep6 GetStep6Detail(Docket objDocket);

        DocketStep6 GetStep6DetailTrispeed(Docket objDocket);

        DocketStep6 GetPaymentDetail(long docketId);

        Response Insert(Docket objDocket);

        Response DumptcoDocketInsert(Docket objDocket);

        Response Update(Docket objDocket);

        Docket GetStep1DetailById(long docketId);

        Docket GetStep2DetailById(long docketId);

        Docket GetStep3DetailById(long docketId);

        Docket GetStep4DetailById(long docketId);

        Docket GetStep5DetailById(long docketId);

        Docket GetStep6DetailById(long docketId);

        long CheckValidDocketNoForUpdate(string docketNo, bool isFinancialUpdate, string searchType);

        bool CheckManifestStatusAndUnderDrsForUpdate(long docketId);

        IEnumerable<Docket> GetDocketListForCancellation(
          string docketNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId);

        Response Cancellation(DocketCancellation objDocketCancellation);

        Response IsDocketValidForCancellation(long docketId, string docketNomenClature);

        AutoCompleteResult IsDocketNoExistByLocation(
          string docketNo,
          short locationId);
        AutoCompleteResult IsDocketNoExistByBillingParty(
          string docketNo,
          short billingPartyId);
        Docket GetDetailById(long id, byte companyId);

        IEnumerable<DocketDocument> GetDocumentDetails(long id, byte companyId);

        IEnumerable<DocketInvoice> GetInvoiceDetails(long id, byte companyId);

        IEnumerable<MasterCharge> GetChargeDetails(
          long id,
          byte businessTypeId,
          byte serviceTypeId,
          byte companyId);

        IEnumerable<MasterTax> GetTaxDetails(long id, byte companyId);

        MasterCustomer GetCustomerDetailByGstTinNo(
          short locationId,
          byte paybasId,
          string gstTinNo,
          bool allowWalkIn);

        IEnumerable<AutoCompleteResult> GetDocketSuffixList();

        Response DocketBookingChallanInsert(DocketBookingChallan objDocketBookingChallan);

        AutoCompleteResult CheckValidDocketNo(string docketNo);
        DocketDetailForSolex CheckValidDocketNoForSolex(string docketNo);
        Response DocketTalkInsert(DocketTalk objDocketTalk);

        IEnumerable<DocketTalk> GetDocketTalkData(long docketId);

        IEnumerable<DocketHold> GetDocketHoldAll();

        Response DocketHold(DocketHold objDocketHold);

        DocketHold GetDocketHoldData(long docketId);

        Response DocketUnhold(DocketHold objDocketHold);

        DocketHold GetDocketUnHoldData(long holdId);

        AutoCompleteResult CheckValidDocketForHold(short docketId);

        long CheckValidDocketNoForDacc(string docketNo);

        Response DocketDaccInsert(DocketDacc objDocketDacc);

        DocketUpload Upload(DocketUpload objDocketUpload);

        DocketUploadInSystem UploadInSystem(DocketUploadInSystem objDocketUploadInSystem);

        Response InsertDocketChangeStatus(DocketReAssign objDocket);
        DocketReAssign CheckValidDocketNoForChangeStatus(string docketNo);

        DocketUploadInSystem UploadInSystemRemarks(DocketUploadInSystem objDocketUploadInSystem);
        DocketUploadInSystem UploadInSystemTrispeed(DocketUploadInSystem objDocketUploadInSystem);

        IEnumerable<AutoCompleteResult> TripsheetList(string EntryBy);

        FastTagUploadInSystem FastTagUploadInSystem(FastTagUploadInSystem objDocketUploadInSystem);

        DocketUploadInSystem UploadInSystemBarcodeLBH(DocketUploadInSystem objDocketUploadInSystem);
        Response InsertDocketOtherCharges(DocketOtherCharges objDocket);
        IEnumerable<DocketOtherCharges> GetListForOtherCharges(
          string ChargeTypeId,
          string LocationId,
          DateTime fromDate,
          DateTime toDate
         );
        DocketStep5 GetStep5DetailSimply(Docket objDocket);
        DocketStep6 GetStep6DetailSimply(Docket objDocket);
        Response InsertDocketBarcode(DocketBarcode objDocket);
        IEnumerable<DocketBarcode> GetBarcodeList(
          byte companyId);
        IEnumerable<BarCodeModel> GetBarCode(int barcodeIndex, string fk_companyId);
        DocketUploadInSystem UploadInSystemByContract(DocketUploadInSystem objDocketUploadInSystem);
        DocketBarcode CheckValidDocketNoForScanIn(string docketNo);

        PickupRequest PickupRequestById(long PickupRequestId);

        Response InsertPickupRequest(PickupRequest objDocket);

        DocketUploadInSystem UploadInSystemKExpress(
        DocketUploadInSystem objDocketUploadInSystem);

        IEnumerable<PickupRequest> PickupRequestGetAll(short LoginUserId, string flag);

        Response UpdateVehicleeWayBill(MastersIndiaEway objEway);
        Response InserteWayBill(MastersIndiaEway objEway);
        MastersIndiaEway eWayBillView(string eway_bill_number);
        IEnumerable<MastersIndiaEway> eWayBillList();
        MastersIndiaEway getEwayBillData(string eway_bill_number);

        MastersIndiaEway CalculateDistance(string fromPincode, string toPincode);
        Response ImportManualEWayBill(string eway_bill_number);

        EwayBillDetails GetEwayBillDetails(string ewbNo);
        DataSet GetEwayBillDetail(string ewbNo);
        string GetAuthorizationToken();
        ApiDocketResponse OrderUpload(ApiDocketRequest apiDocketRequest);
        bool IsInvoiceNoAvailable(long docketId, long invoiceId, string invoiceNo, short customerId);
        Docket GetCustomerContractByCustomerId(Docket objDocket);
        DocketUpload UploadSpeedFox(DocketUpload objDocketUpload);
        DocketUploadInSystem UploadSolex(DocketUploadInSystem objDocketUploadInSystem);
        DocketUploadInSystem UploadHarshita(DocketUploadInSystem objDocketUploadInSystem);
        DocketUpload UploadMCLS(DocketUpload objDocketUpload);
        DocketUploadInSystem UploadDocketTripsheetCarton(
         DocketUploadInSystem objDocketUploadTripsheetCarton);
        DataTable GetDocketBarcodeInfo(long docketId);
        IEnumerable<DocketPackages> GetPackagesByDocketId(long docketId);
        ResponseResult ApiOrderUploadPumaEssential(PickUpDetailRequest pickUpDetailRequest);
        ResponseResult ApiOrderUploadArvindEssential(PickUpDetailRequest pickUpDetailRequest);
        DocketUploadInSystem UploadDocketTripsheetCartonEssential(DocketUploadInSystem objDocketUploadTripsheetCarton);
        void InsertFareyeWebhookResult(long docketId, string result);
        bool IsEwayBillNoAvailable(string ewaybillNo);
        IEnumerable<AutoCompleteResult> GetMappedBillingParty(
         short consignorId,
         short consigneeId);

    }
}
