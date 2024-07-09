//  
// Type: CodeLock.Areas.Contract.Repository.VendorContractRepository
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

namespace CodeLock.Areas.Contract.Repository
{
    public class VendorContractRepository : BaseRepository, IVendorContractRepository, IDisposable
    {
        public CustomerContractDefineChargeMatrix GetDetail(
          short contractId,
          byte baseOn,
          byte baseCode,
          bool isBooking,
          byte chargeCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseOn", (object)baseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseCode", (object)baseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerContractDefineChargeMatrix>("Usp_VendorContract_GetDefineChargeMatrixDetail", (object)dynamicParameters, "CustomerContract Master - GetDetail").FirstOrDefault<CustomerContractDefineChargeMatrix>();
        }
        public Response InsertFleetCharge(
          CustomerContractFleetCharge objCustomerContractFleetCharge)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerContractFleetCharge", (object)XmlUtility.XmlSerializeToString((object)objCustomerContractFleetCharge), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractId", (object)objCustomerContractFleetCharge.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChargeCode", (object)objCustomerContractFleetCharge.ChargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocation", (object)objCustomerContractFleetCharge.ToLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)objCustomerContractFleetCharge.FtlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MatrixType", (object)objCustomerContractFleetCharge.MatrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objCustomerContractFleetCharge.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContract_FleetChargeInsert", (object)dynamicParameters, "CustomerContract Master - InsertFleetCharge").FirstOrDefault<Response>();
        }
        public IEnumerable<CustomerContractFleetCharge> GetFleetChargeBySearchingCriteria(
          short id,
          byte chargeCode,
          byte matrixType,
          short toLocation,
          byte ftlTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocation", (object)toLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MatrixType", (object)matrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerContractFleetCharge>("Usp_VendorContract_GetFleetChargeBySearchingCriteria", (object)dynamicParameters, "CustomerContract Master - GetChargeMatrixSTDDetail");
        }
        public IEnumerable<VendorContract> GetAll(short vendorId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContract>("Usp_VendorContract_GetAll", (object)dynamicParameters, "Vendor Contract - GetAll");
        }

        public VendorContract GetDetailById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<VendorContract>, IEnumerable<VendorContractBasicInfo>> tuple = DataBaseFactory.QueryMultipleSP<VendorContract, VendorContractBasicInfo>("Usp_VendorContract_GetById", (object)dynamicParameters, "Vendor Contract - GetById");
            VendorContract vendorContract = new VendorContract();
            if (tuple != null && tuple.Item1 != null)
            {
                vendorContract = tuple.Item1.FirstOrDefault<VendorContract>();
                if (tuple.Item2 != null)
                    vendorContract.VendorContractBasicInfo = tuple.Item2.FirstOrDefault<VendorContractBasicInfo>();
            }
            return vendorContract;
        }

        public Response Insert(VendorContract objVendorContract)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContract", (object)XmlUtility.XmlSerializeToString((object)objVendorContract), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContract_Insert", (object)dynamicParameters, "Vendor Contract  - Insert").FirstOrDefault<Response>();
        }

        public Response Update(VendorContract objVendorContract)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContract", (object)XmlUtility.XmlSerializeToString((object)objVendorContract), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContract_Update", (object)dynamicParameters, "Vendor Contract  - Update").FirstOrDefault<Response>();
        }

        public bool CheckDate(short contractId, short vendorId, DateTime startDate, DateTime endDate)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@StartDate", (object)startDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EndDate", (object)endDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDateValid", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_VendorContract_CheckDate", (object)dynamicParameters, "Vendor Contract - CheckDate");
            return dynamicParameters.Get<bool>("@IsDateValid");
        }

        public bool CheckDateIsValid(short contractId, short vendorId, DateTime contractDate)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractDate", (object)contractDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDateValid", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_VendorContract_CheckDateIsValid", (object)dynamicParameters, "Vendor Contract - CheckDateIsValid");
            return dynamicParameters.Get<bool>("@IsDateValid");
        }

        public IEnumerable<VendorContractRouteBased> GetRouteBasedDetailById(
          short id,
          short routeId,
          short vehicleId,
          byte ftlTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteId", (object)routeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleId", (object)vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractRouteBased>("Usp_VendorContractRouteBased_GetDetailById", (object)dynamicParameters, "Vendor Contract  - GetRouteBasedDetailById");
        }

        public Response InsertRouteBased(
          List<VendorContractRouteBased> objMasterRouteBasedList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContractRouteBased", (object)XmlUtility.XmlSerializeToString((object)objMasterRouteBasedList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContractRouteBased_Insert", (object)dynamicParameters, "Vendor Contract  - InsertRouteBased").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorContractDistanceBased> GetDistanceBasedDetailById(
          short id,
          byte transportModeId,
          byte ftlTypeId,
          short vehicleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleId", (object)vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractDistanceBased>("Usp_VendorContractDistanceBased_GetDetailById", (object)dynamicParameters, "Vendor Contract  - GetDistanceBasedDetailById");
        }

        public Response InsertDistanceBased(
          List<VendorContractDistanceBased> objMasterDistanceBasedList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContractDistanceBased", (object)XmlUtility.XmlSerializeToString((object)objMasterDistanceBasedList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContractDistanceBased_Insert", (object)dynamicParameters, "Vendor Contract  - InsertDistanceBased").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorContractCityBased> GetCityBasedDetailById(
          short id,
          int fromCityId,
          int toCityId,
          byte transportModeId,
          byte ftlTypeId,
          short vehicleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromCityId", (object)fromCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)toCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleId", (object)vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractCityBased>("Usp_VendorContractCityBased_GetDetailById", (object)dynamicParameters, "Vendor Contract  - GetCityBasedDetailById");
        }

        public Response InsertCityBased(
          List<VendorContractCityBased> objMasterCityBasedList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContractCityBased", (object)XmlUtility.XmlSerializeToString((object)objMasterCityBasedList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContractCityBased_Insert", (object)dynamicParameters, "Vendor Contract  - InsertCityBased").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorContractDocketBased> GetDocketBasedDetailById(
          short id,
          short fromLocationId,
          short toLocationId,
          bool isBooking,
          short baContractTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)toLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaContractTypeId", (object)baContractTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractDocketBased>("Usp_VendorContractDocketBased_GetDetailById", (object)dynamicParameters, "Vendor Contract  - GetDocketBasedDetailById");
        }

        public Response InsertDocketBased(
          List<VendorContractDocketBased> objMasterDocketBasedList,
          short contractId,
          short fromLocationId,
          short toLocationId,
          bool isBooking,
          short baContractTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContractDocketBased", (object)XmlUtility.XmlSerializeToString((object)objMasterDocketBasedList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)toLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaContractTypeId", (object)baContractTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContractDocketBased_Insert", (object)dynamicParameters, "Vendor Contract  - InsertDocketBased").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorContractCrossingBased> GetCrossingBasedDetailById(
          short id,
          short fromLocationId,
          int toCityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)toCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractCrossingBased>("Usp_VendorContractCrossingBased_GetDetailById", (object)dynamicParameters, "Vendor Contract  - GetCrossingBasedDetailById");
        }

        public Response InsertCrossingBased(
          List<VendorContractCrossingBased> objMasterCrossingBasedList)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objMasterCrossingBasedList[0].ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)objMasterCrossingBasedList[0].FromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)objMasterCrossingBasedList[0].ToCityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContractCrossingBased_Insert", (object)dynamicParameters, "Vendor Contract  - InsertCrossingBased").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetPaymentBasisList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "CASH", Name = "CASH" },
        new AutoCompleteResult()
        {
          Value = "CHEQUE",
          Name = "CHEQUE"
        },
        new AutoCompleteResult() { Value = "DD", Name = "DD" },
        new AutoCompleteResult() { Value = "NEFT", Name = "NEFT" }
      };
        }

        public IEnumerable<AutoCompleteResult> GetPaymentIntervalList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "Q", Name = "Quarterly" },
        new AutoCompleteResult() { Value = "M", Name = "Monthly" },
        new AutoCompleteResult() { Value = "W", Name = "Weekly" }
      };
        }

        public IEnumerable<AutoCompleteResult> GetBookingList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "True",
          Name = "Booking"
        },
        new AutoCompleteResult()
        {
          Value = "False",
          Name = "Delivery"
        }
      };
        }

        public MasterVendor GetVendorTypeIdByContractId(short contractId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterVendor>("Usp_VendorContract_GetVendorTypeIdByContractId", (object)dynamicParameters, "Vendor Contract  - GetVendorTypeIdByContractId").FirstOrDefault<MasterVendor>();
        }

        public VendorContractBasicInfo GetActiveVendorContract(
          short vendorId,
          DateTime documentDate)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentDate", (object)documentDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractBasicInfo>("Usp_VendorContract_GetActiveVendorContract", (object)dynamicParameters, "Vendor Contract - GetActiveVendorContract").FirstOrDefault<VendorContractBasicInfo>();
        }

        public VendorContract GetVendorContractAmount(
          short contractId,
          byte matrixTypeId,
          byte transportModeId,
          short routeId,
          int fromCityId,
          int toCityId,
          byte ftlTypeId,
          short vehicleId,
          Decimal totalWeight)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MatrixTypeId", (object)matrixTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteId", (object)routeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromCityId", (object)fromCityId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToCityId", (object)toCityId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleId", (object)vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TotalWeight", (object)totalWeight, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContract>("Usp_VendorContract_GetVendorContractAmount", (object)dynamicParameters, "Vendor Contract - GetVendorContractAmount").FirstOrDefault<VendorContract>();
        }

        public byte GetCreditDaysByVendorId(short vendorId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Date", (object)SessionUtility.Now, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CreditDays", (object)null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_VendorContract_GetCreditDaysByVendorId", (object)dynamicParameters, "VendorContract Master - GetCreditDaysByVendorId");
            return dynamicParameters.Get<byte>("@CreditDays");
        }

        public int[] GetSystemCharges()
        {
            return new int[5] { 4, 5, 6, 7, 8 };
        }

        public IEnumerable<VendorContractDefineChargeMatrix> GetDefineChargeMatrixList(
            VendorContractDefineChargeMatrixHDR objVendorContractDefineChargeMatrixHDR)
        {
            this.GetSystemCharges();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)objVendorContractDefineChargeMatrixHDR.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)objVendorContractDefineChargeMatrixHDR.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDelivery", (object)objVendorContractDefineChargeMatrixHDR.IsDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseOn", (object)objVendorContractDefineChargeMatrixHDR.BaseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseCode", (object)objVendorContractDefineChargeMatrixHDR.BaseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<VendorContractDefineChargeMatrix>)DataBaseFactory.QuerySP<VendorContractDefineChargeMatrix>("Usp_VendorContract_GetDefineChargeMatrixList", (object)dynamicParameters, "VendorContract Master - GetDefineChargeMatrixList").ToList<VendorContractDefineChargeMatrix>();
        }

        public Response UpdateDefineChargeMatrix(VendorContractDefineChargeMatrixHDR objFilter)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContractDefineChargeMatrix", (object)XmlUtility.XmlSerializeToString((object)objFilter), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractId", (object)objFilter.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseOn", (object)objFilter.BaseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BaseCode", (object)objFilter.BaseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBooking", (object)objFilter.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContract_UpdateDefineChargeMatrix", (object)dynamicParameters, "VendorContract Master - DefineChargeMatrixEdit").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetSlabTypeList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "N", Name = "NA" },
        new AutoCompleteResult() { Value = "D", Name = "Direct" },
        new AutoCompleteResult()
        {
          Value = "P",
          Name = "Progressive"
        }
      };
        }
        public IEnumerable<AutoCompleteResult> GetChargeBaseList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "0", Name = "NA" },
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "Product Type"
        },
        new AutoCompleteResult()
        {
          Value = "2",
          Name = "Packaging Type"
        }
      };
        }

        public IEnumerable<AutoCompleteResult> GetBaseCodeList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "0", Name = "NONE" }
      };
        }
        public IEnumerable<AutoCompleteResult> GetTransportModeList(
                   short contractId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<AutoCompleteResult>)DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VendorContract_GetTransportModeList", (object)dynamicParameters, "CustomerContract Master - GetTransportModeList").ToList<AutoCompleteResult>();
        }

        public Response InsertModewiseServices(VendorContractModewiseServices objVendorContractModewiseServices)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorContractModewiseServices", (object)XmlUtility.XmlSerializeToString((object)objVendorContractModewiseServices), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractId", (object)objVendorContractModewiseServices.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objVendorContractModewiseServices.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorContract_InsertModewiseServices", (object)dynamicParameters, "CustomerContract Master - InsertModewiseServices").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetFuelSurchargeRateTypeList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "3", Name = "Per KG" },
        new AutoCompleteResult()
        {
          Value = "8",
          Name = "% Of Freight"
        },
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "Flat in RS"
        }
      };
        }

        public IEnumerable<AutoCompleteResult> GetMatrixTypeListByContractId(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<AutoCompleteResult>)DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VendorContract_GetMatrixTypeListByContractId", (object)dynamicParameters, "VendorContract Master - GetMatrixTypeListByContractId").ToList<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetRateTypeListByContractId(short contractId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<AutoCompleteResult>)DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VendorContract_GetRateTypeListByContractId", (object)dynamicParameters, "CustomerContract Master - GetRateTypeListByContractId").ToList<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetRiskMatrixRateTypeList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "7",
          Name = "% Of Invoice"
        },
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "Flat in RS"
        },
        new AutoCompleteResult()
        {
          Value = "6",
          Name = "Per Package"
        }
      };
        }


        public IEnumerable<VendorContractServiceAccess> GetServiceAccessById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<VendorContractServiceAccess>)DataBaseFactory.QuerySP<VendorContractServiceAccess>("Usp_VendorContract_GetServiceAccessById", (object)dynamicParameters, "CustomerContract Master - GetServiceAccessById").ToList<VendorContractServiceAccess>();
        }

        public IEnumerable<VendorContractRiskMatrix> GetCarrierRiskList(short contractId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<VendorContractRiskMatrix>)DataBaseFactory.QuerySP<VendorContractRiskMatrix>("Usp_VendorContract_GetCarrierRiskList", (object)dynamicParameters, "CustomerContract Master - GetCarrierRiskList").ToList<VendorContractRiskMatrix>();
        }

        public IEnumerable<VendorContractRiskMatrix> GetOwnerRiskList(short contractId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<VendorContractRiskMatrix>)DataBaseFactory.QuerySP<VendorContractRiskMatrix>("Usp_CustomerContract_GetOwnerRiskList", (object)dynamicParameters, "CustomerContract Master - GetOwnerRiskList").ToList<VendorContractRiskMatrix>();
        }

        public VendorContractChargeMatrixSTD GetExpenseRate(
     byte transportModeId,
     byte matrixTypeId,
     short fromLocationId,
     short toLocationId,
     byte rateTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MatrixTypeId", (object)matrixTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)toLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RateTypeId", (object)rateTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorContractChargeMatrixSTD>("Usp_VendorContract_GetExpenseRate", (object)dynamicParameters, "VendorContract Master - GetExpenseRate").FirstOrDefault<VendorContractChargeMatrixSTD>();
        }

        public Response InsertServices(VendorContractServices objVendorContractServices)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerContractServices", (object)XmlUtility.XmlSerializeToString((object)objVendorContractServices), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractId", (object)objVendorContractServices.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertServices", (object)dynamicParameters, "CustomerContract Master - InsertServices").FirstOrDefault<Response>();
        }
    }
}
