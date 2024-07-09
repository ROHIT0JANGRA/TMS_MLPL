//  
// Type: CodeLock.Areas.Contract.Repository.ICustomerContractRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Contract.Repository
{
  public interface ICustomerContractRepository : IDisposable
  {
    IEnumerable<CustomerContract> GetAll();

    IEnumerable<CustomerContract> GetVendorContract(short? customerId);

    CustomerContract GetById(short id, bool isCustomerContract);

    Response Insert(CustomerContract objCustomerContract);

    Response Update(CustomerContract objCustomerContract);

    IEnumerable<CustomerContractRiskMatrix> GetCarrierRiskList(
      short contractId);

    IEnumerable<CustomerContractRiskMatrix> GetOwnerRiskList(
      short contractId);

    IEnumerable<CustomerContractServiceAccess> GetServiceAccessById(
      short id);

    IEnumerable<AutoCompleteResult> GetRiskMatrixRateTypeList();

    IEnumerable<AutoCompleteResult> GetFuelSurchargeRateTypeList();

    IEnumerable<AutoCompleteResult> GetSlabTypeList();

    IEnumerable<AutoCompleteResult> GetChargeBaseList();

    IEnumerable<AutoCompleteResult> GetBaseCodeList();

    CustomerContract GetContractHeaderInformation(short id);

    IEnumerable<AutoCompleteResult> GetTransportModeList(
      short contractId);

    IEnumerable<CustomerContractDefineChargeMatrix> GetDefineChargeMatrixList(
      CustomerContractDefineChargeMatrixHDR objCustomerContractDefineChargeMatrixHDR);

    IEnumerable<AutoCompleteResult> GetMatrixTypeListByContractId(
      short id);

    IEnumerable<AutoCompleteResult> GetRateTypeListByContractId(
      short contractId);

    byte GetCreditDaysByCustomerIdAndPaybasId(short customerId, byte paybasId);

    bool CheckDate(
      short contractId,
      short customerId,
      byte paybasId,
      bool isCustomerContract,
      DateTime startDate,
      DateTime endDate);

    bool CheckDateIsValid(
      short contractId,
      short customerId,
      byte paybasId,
      bool isCustomerContract,
      DateTime contractDate);

    AutoCompleteResult GetCustomerDetailByType(short customerId, bool isCustomer);

    CustomerContractServices GetServicesById(short id);

    Response InsertServices(
      CustomerContractServices objCustomerContractServices);

    Response InsertModewiseServices(
      CustomerContractModewiseServices objCustomerContractModewiseServices);

    CustomerContractModewiseServices GetModewiseServicesDetails(
      short contractId,
      short transportmodeId);

    Response UpdateDefineChargeMatrix(CustomerContractDefineChargeMatrixHDR objFilter);

    IEnumerable<CustomerContractChargeMatrixSTD> GetChargeMatrixSTDDetailBySearchingCriteria(
      short id,
      byte baseOn1,
      byte baseOn2,
      byte baseCode1,
      short baseCode2,
      byte chargeCode,
      byte matrixType,
      short fromLocation,
      short toLocation,
      byte transportModeId,
      bool isBooking,
      byte ftlTypeId,
      short consignorId,
      short consigneeId);

    Response InsertChargeMatrixSTD(CustomerContractChargeMatrixSTD objChargeMatrixSTD);

    IEnumerable<AutoCompleteResult> GetChargeList(
      short contractId,
      byte baseOn,
      byte baseCode,
      bool isBooking);

    bool CheckOdaApplicable(short contractId);

    byte GetChargeBase(
      short contractId,
      byte baseOn,
      byte baseCode,
      bool isBooking,
      byte chargeCode);

    IEnumerable<AutoCompleteResult> GetBaseCode2List(
      short contractId,
      byte baseOn,
      byte baseCode,
      bool isBooking,
      byte chargeCode);

    CustomerContractDefineChargeMatrix GetDetail(
      short contractId,
      byte baseOn,
      byte baseCode,
      bool isBooking,
      byte chargeCode);

    IEnumerable<CustomerContract> GetFreightContractDetailsByManualContractId(
      short contractId,
      string manualContractId,
      string customerCode,
      string customerName);

    CustomerContractBillingInfo GetBillingInfoByCustomerId(
      short customerId);

    IEnumerable<CustomerContract> GetDetailsForFreightContract(
      short contractId);

    bool IsFovApplicable();

    IEnumerable<CustomerContract> GetDetails();

    IEnumerable<CustomerContract> GetDetailsByManualContractId(
      string manualContractId,
      string customerCode,
      string customerName);

    IEnumerable<CustomerContract> GetAll(
      short customerId,
      bool isCustomerContract);

    Response InsertODA(MasterODA objODA);

    MasterODA GetOdaDetail(short id);

    CustomerContractBillingInfo GetBillingDetails(short contractId);

    Response InsertBillingInfo(
      CustomerContractBillingInfo objCustomerContractBillingInfo);

    Response UpdateRateMatrix(
      CustomerContractChargeMatrixLTLHeader objRateMatrix);

    IEnumerable<CustomerContractChargeMatrixLTL> GetRateMatrixList(
      CustomerContractChargeMatrixLTLHeader objRateMatrix);

    IEnumerable<CustomerContractRateMatrixSlabRange> GetRateMatrixSlabRangeDetailBySearchingCriteria(
      short id,
      byte chargeCode);

    Response InsertRateMatrixSlabRange(
      CustomerContractRateMatrix objCustomerContractRateMatrix);

    IEnumerable<CustomerContractRateMetrixSlabRate> GetRateMatrixSlabDetailBySearchingCriteria(
      short id,
      byte chargeCode);

    IEnumerable<CustomerContractRateMatrix> GetRateMatrixSlabRateDetailBySearchingCriteria(
      short id,
      byte baseOn1,
      byte baseOn2,
      byte baseCode1,
      short baseCode2,
      byte chargeCode,
      byte matrixType,
      short fromLocation,
      short toLocation,
      byte transportModeId,
      bool isBooking,
      byte ftlTypeId,
      short consignorId,
      short consigneeId);

    Response InsertRateMatrixSlabRate(
      List<CustomerContractRateMatrix> objCustomerContractRateMatrixList);

    IEnumerable<AutoCompleteResult> GetMatrixTypeList(short id);

    StandardChargeMatrixUpload StandardChargeMatrixUpload(
      StandardChargeMatrixUpload objCustomerContractChargeMatrixSTD);

    IEnumerable<AutoCompleteResult> GetMovementTypeList();

    IEnumerable<CustomerContractFleetCharge> GetFleetChargeBySearchingCriteria(
      short id,
      byte chargeCode,
      byte matrixType,
      short toLocation,
      byte ftlTypeId);

    Response InsertFleetCharge(
      CustomerContractFleetCharge objCustomerContractFleetCharge);

    CustomerContractChargeMatrixSTD GetExpenseRate(
      byte transportModeId,
      byte matrixTypeId,
      short fromLocationId,
      short toLocationId,
      byte rateTypeId);

        RateInquiry GetRateInquiry(
          short customerId,
          byte matrixTypeId,
          short fromLocationId,
          short toLocationId);

    Response CopyContract(CopyCustomerContract objCopyCustomerContract);

   IEnumerable<CustomerContractRateMatrix> GetRateMatrixSlabRateDetailBySearchingCriteriaSimply(
              short id,
              byte baseOn1,
              byte baseOn2,
              byte baseCode1,
              short baseCode2,
              byte chargeCode,
              byte matrixType,
              short fromLocation,
              short toLocation,
              byte transportModeId,
              bool isBooking,
              byte ftlTypeId,
              short consignorId,
              short consigneeId);
        
        IEnumerable<LaneDetail> GetLaneList(short companyId, short customerId, short? laneId);

    }

}
