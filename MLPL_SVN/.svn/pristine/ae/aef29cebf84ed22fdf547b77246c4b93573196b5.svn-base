//  
// Type: CodeLock.Areas.Contract.Repository.IVendorContractRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Contract.Repository
{
    public interface IVendorContractRepository : IDisposable
    {
        CustomerContractDefineChargeMatrix GetDetail(
          short contractId,
          byte baseOn,
          byte baseCode,
          bool isBooking,
          byte chargeCode);
        Response InsertFleetCharge(
          CustomerContractFleetCharge objCustomerContractFleetCharge);
        IEnumerable<CustomerContractFleetCharge> GetFleetChargeBySearchingCriteria(
          short id,
          byte chargeCode,
          byte matrixType,
          short toLocation,
          byte ftlTypeId);
        IEnumerable<VendorContract> GetAll(short vendorId);

        VendorContract GetDetailById(short id);

        Response Insert(VendorContract objVendorContract);

        Response Update(VendorContract objVendorContract);

        bool CheckDate(short contractId, short vendorId, DateTime startDate, DateTime endDate);

        bool CheckDateIsValid(short contractId, short vendorId, DateTime contractDate);

        IEnumerable<VendorContractRouteBased> GetRouteBasedDetailById(
          short id,
          short routeId,
          short vehicleId,
          byte ftlTypeId);

        Response InsertRouteBased(
          List<VendorContractRouteBased> objMasterRouteBasedList);

        IEnumerable<VendorContractDistanceBased> GetDistanceBasedDetailById(
          short id,
          byte transportModeId,
          byte ftlTypeId,
          short vehicleId);

        Response InsertDistanceBased(
          List<VendorContractDistanceBased> objMasterDistanceBasedList);

        IEnumerable<VendorContractCityBased> GetCityBasedDetailById(
          short id,
          int fromCityId,
          int toCityId,
          byte transportModeId,
          byte ftlTypeId,
          short vehicleId);

        Response InsertCityBased(
          List<VendorContractCityBased> objMasterCityBasedList);

        IEnumerable<VendorContractDocketBased> GetDocketBasedDetailById(
          short id,
          short fromLocationId,
          short toLocationId,
          bool isBooking,
          short baContractTypeId);

        Response InsertDocketBased(
          List<VendorContractDocketBased> objMasterDocketBasedList,
          short contractId,
          short fromLocationId,
          short toLocationId,
          bool isBooking,
          short baContractTypeId);

        IEnumerable<VendorContractCrossingBased> GetCrossingBasedDetailById(
          short id,
          short fromLocationId,
          int toCityId);

        Response InsertCrossingBased(
          List<VendorContractCrossingBased> objMasterCrossingBasedList);

        IEnumerable<AutoCompleteResult> GetPaymentBasisList();

        IEnumerable<AutoCompleteResult> GetPaymentIntervalList();

        IEnumerable<AutoCompleteResult> GetBookingList();

        MasterVendor GetVendorTypeIdByContractId(short contractId);

        VendorContractBasicInfo GetActiveVendorContract(
          short vendorId,
          DateTime documentDate);

        VendorContract GetVendorContractAmount(
          short contractId,
          byte matrixTypeId,
          byte transportModeId,
          short routeId,
          int fromCityId,
          int toCityId,
          byte ftlTypeId,
          short vehicleId,
          Decimal totalWeight);

        byte GetCreditDaysByVendorId(short vendorId);

        IEnumerable<VendorContractDefineChargeMatrix> GetDefineChargeMatrixList(
                VendorContractDefineChargeMatrixHDR objCustomerContractDefineChargeMatrixHDR);


        IEnumerable<AutoCompleteResult> GetChargeBaseList();

        IEnumerable<AutoCompleteResult> GetBaseCodeList();
        IEnumerable<AutoCompleteResult> GetSlabTypeList();

        Response InsertModewiseServices(
                  VendorContractModewiseServices objVendorContractModewiseServices);

        Response UpdateDefineChargeMatrix(VendorContractDefineChargeMatrixHDR objFilter);

        IEnumerable<AutoCompleteResult> GetTransportModeList(
                 short contractId);
        IEnumerable<AutoCompleteResult> GetFuelSurchargeRateTypeList();

        IEnumerable<AutoCompleteResult> GetMatrixTypeListByContractId(
               short id);

        IEnumerable<AutoCompleteResult> GetRateTypeListByContractId(
                      short contractId);
        IEnumerable<AutoCompleteResult> GetRiskMatrixRateTypeList();

        IEnumerable<VendorContractServiceAccess> GetServiceAccessById(
                short id);

        IEnumerable<VendorContractRiskMatrix> GetCarrierRiskList(
            short contractId);

        IEnumerable<VendorContractRiskMatrix> GetOwnerRiskList(
                  short contractId);


        VendorContractChargeMatrixSTD GetExpenseRate(
              byte transportModeId,
              byte matrixTypeId,
              short fromLocationId,
              short toLocationId,
              byte rateTypeId);


        Response InsertServices(
                  VendorContractServices objVendorContractServices);
    }
}
