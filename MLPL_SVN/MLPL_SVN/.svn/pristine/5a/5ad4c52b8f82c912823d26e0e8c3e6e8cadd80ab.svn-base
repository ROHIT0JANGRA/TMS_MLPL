//  
// Type: CodeLock.Areas.Contract.Repository.CustomerContractRepository
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
	public class CustomerContractRepository : BaseRepository, ICustomerContractRepository, IDisposable
	{
		public IEnumerable<CustomerContract> GetAll()
		{
			return DataBaseFactory.QuerySP<CustomerContract>("Usp_CustomerContract_GetAll", (object)null, "Customer Contract Master - GetAll");
		}

		public IEnumerable<CustomerContract> GetVendorContract(
		  short? customerId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContract>("Usp_CustomerContract_GetVendorContract", (object)dynamicParameters, "Customer Contract Master - GetVendorContract");
		}

		public CustomerContract GetById(short id, bool isCustomerContract)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsCustomerContract", (object)isCustomerContract, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			Tuple<IEnumerable<CustomerContract>, IEnumerable<CustomerContractBasicInfo>> tuple = DataBaseFactory.QueryMultipleSP<CustomerContract, CustomerContractBasicInfo>("Usp_CustomerContract_GetById", (object)dynamicParameters, "CustomerContract Master - GetById");
			CustomerContract customerContract = new CustomerContract();
			if (tuple != null && tuple.Item1 != null)
			{
				customerContract = tuple.Item1.FirstOrDefault<CustomerContract>();
				if (tuple.Item2 != null)
					customerContract.CustomerContractBasicInfo = tuple.Item2.FirstOrDefault<CustomerContractBasicInfo>();
			}
			return customerContract;
		}

		public Response Insert(CustomerContract objCustomerContract)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContract", (object)XmlUtility.XmlSerializeToString((object)objCustomerContract), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_Insert", (object)dynamicParameters, "CustomerContract Master - Insert").FirstOrDefault<Response>();
		}

		public Response Update(CustomerContract objCustomerContract)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContract", (object)XmlUtility.XmlSerializeToString((object)objCustomerContract), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_Update", (object)dynamicParameters, "CustomerContract Master - Update").FirstOrDefault<Response>();
		}

		public Response CopyContract(CopyCustomerContract objCopyCustomerContract)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCopyCustomerContract", (object)XmlUtility.XmlSerializeToString((object)objCopyCustomerContract), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_CopyContract", (object)dynamicParameters, "CustomerContract Master - CopyContract").FirstOrDefault<Response>();
		}

		public IEnumerable<CustomerContractRiskMatrix> GetCarrierRiskList(
		  short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CustomerContractRiskMatrix>)DataBaseFactory.QuerySP<CustomerContractRiskMatrix>("Usp_CustomerContract_GetCarrierRiskList", (object)dynamicParameters, "CustomerContract Master - GetCarrierRiskList").ToList<CustomerContractRiskMatrix>();
		}

		public IEnumerable<CustomerContractRiskMatrix> GetOwnerRiskList(
		  short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CustomerContractRiskMatrix>)DataBaseFactory.QuerySP<CustomerContractRiskMatrix>("Usp_CustomerContract_GetOwnerRiskList", (object)dynamicParameters, "CustomerContract Master - GetOwnerRiskList").ToList<CustomerContractRiskMatrix>();
		}

		public IEnumerable<CustomerContractServiceAccess> GetServiceAccessById(
		  short id)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CustomerContractServiceAccess>)DataBaseFactory.QuerySP<CustomerContractServiceAccess>("Usp_CustomerContract_GetServiceAccessById", (object)dynamicParameters, "CustomerContract Master - GetServiceAccessById").ToList<CustomerContractServiceAccess>();
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
		},

        new AutoCompleteResult()
        {
          Value = "10",
          Name = "% Of Total Amount"
        }

      };
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

		public CustomerContract GetContractHeaderInformation(short id)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContract>("Usp_CustomerContract_GetContractHeaderInformation", (object)dynamicParameters, "CustomerContract Master - GetContractHeaderInformation").FirstOrDefault<CustomerContract>();
		}

		public IEnumerable<AutoCompleteResult> GetTransportModeList(
		  short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<AutoCompleteResult>)DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetTransportModeList", (object)dynamicParameters, "CustomerContract Master - GetTransportModeList").ToList<AutoCompleteResult>();
		}

		public IEnumerable<AutoCompleteResult> GetRateTypeListByContractId(
		  short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<AutoCompleteResult>)DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetRateTypeListByContractId", (object)dynamicParameters, "CustomerContract Master - GetRateTypeListByContractId").ToList<AutoCompleteResult>();
		}

		public int[] GetSystemCharges()
		{
			return new int[5] { 4, 5, 6, 7, 8 };
		}

		public IEnumerable<CustomerContractDefineChargeMatrix> GetDefineChargeMatrixList(
		  CustomerContractDefineChargeMatrixHDR objCustomerContractDefineChargeMatrixHDR)
		{
			this.GetSystemCharges();
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)objCustomerContractDefineChargeMatrixHDR.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)objCustomerContractDefineChargeMatrixHDR.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsDelivery", (object)objCustomerContractDefineChargeMatrixHDR.IsDelivery, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn", (object)objCustomerContractDefineChargeMatrixHDR.BaseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode", (object)objCustomerContractDefineChargeMatrixHDR.BaseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CustomerContractDefineChargeMatrix>)DataBaseFactory.QuerySP<CustomerContractDefineChargeMatrix>("Usp_CustomerContract_GetDefineChargeMatrixList", (object)dynamicParameters, "CustomerContract Master - GetDefineChargeMatrixList").ToList<CustomerContractDefineChargeMatrix>();
		}

		public IEnumerable<AutoCompleteResult> GetMatrixTypeListByContractId(
		  short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<AutoCompleteResult>)DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetMatrixTypeListByContractId", (object)dynamicParameters, "CustomerContract Master - GetMatrixTypeListByContractId").ToList<AutoCompleteResult>();
		}

		public byte GetCreditDaysByCustomerIdAndPaybasId(short customerId, byte paybasId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CreditDays", (object)null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			DataBaseFactory.QuerySP("Usp_CustomerContract_GetCreditDaysByCustomerIdAndPaybasId", (object)dynamicParameters, "CustomerContract Master - GetCreditDaysByCustomerIdAndPaybasId");
			return dynamicParameters.Get<byte>("@CreditDays");
		}

		public bool CheckDate(
		  short contractId,
		  short customerId,
		  byte paybasId,
		  bool isCustomerContract,
		  DateTime startDate,
		  DateTime endDate)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsCustomerContract", (object)isCustomerContract, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@StartDate", (object)startDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@EndDate", (object)endDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsDateValid", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			DataBaseFactory.QuerySP("Usp_CustomerContract_CheckDate", (object)dynamicParameters, "CustomerContract Master - CheckDate");
			return dynamicParameters.Get<bool>("@IsDateValid");
		}

		public bool CheckDateIsValid(
		  short contractId,
		  short customerId,
		  byte paybasId,
		  bool isCustomerContract,
		  DateTime contractDate)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsCustomerContract", (object)isCustomerContract, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractDate", (object)contractDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsDateValid", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			DataBaseFactory.QuerySP("Usp_CustomerContract_CheckDateIsValid", (object)dynamicParameters, "CustomerContract Master - CheckDateIsValid");
			return dynamicParameters.Get<bool>("@IsDateValid");
		}

		public AutoCompleteResult GetCustomerDetailByType(
		  short customerId,
		  bool isCustomer)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsCustomer", (object)isCustomer, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetCustomerDetailByType", (object)dynamicParameters, "CustomerContract Master - GetMatrixTypeListByContractId").FirstOrDefault<AutoCompleteResult>();
		}

		public CustomerContractServices GetServicesById(short id)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractServices>("Usp_CustomerContract_GetServicesById", (object)dynamicParameters, "CustomerContract Master - GetServicesById").FirstOrDefault<CustomerContractServices>();
		}

		public Response InsertServices(
		  CustomerContractServices objCustomerContractServices)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractServices", (object)XmlUtility.XmlSerializeToString((object)objCustomerContractServices), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objCustomerContractServices.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertServices", (object)dynamicParameters, "CustomerContract Master - InsertServices").FirstOrDefault<Response>();
		}

		public Response InsertModewiseServices(
		  CustomerContractModewiseServices objCustomerContractModewiseServices)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractModewiseServices", (object)XmlUtility.XmlSerializeToString((object)objCustomerContractModewiseServices), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objCustomerContractModewiseServices.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)objCustomerContractModewiseServices.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertModewiseServices", (object)dynamicParameters, "CustomerContract Master - InsertModewiseServices").FirstOrDefault<Response>();
		}

		public CustomerContractModewiseServices GetModewiseServicesDetails(
		  short contractId,
		  short transportModeId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			Tuple<IEnumerable<CustomerContractModewiseServices>, IEnumerable<MasterGeneral>> tuple = DataBaseFactory.QueryMultipleSP<CustomerContractModewiseServices, MasterGeneral>("Usp_CustomerContract_GetModewiseServicesDetails", (object)dynamicParameters, "CustomerContract Master - GetModewiseServicesDetails");
			CustomerContractModewiseServices modewiseServices = new CustomerContractModewiseServices();
			if (tuple != null)
			{
				modewiseServices = tuple.Item1.FirstOrDefault<CustomerContractModewiseServices>();
				modewiseServices.ServiceTaxPayer = tuple.Item2.ToArray<MasterGeneral>();
			}
			return modewiseServices;
		}

		public Response UpdateDefineChargeMatrix(CustomerContractDefineChargeMatrixHDR objFilter)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractDefineChargeMatrix", (object)XmlUtility.XmlSerializeToString((object)objFilter), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objFilter.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn", (object)objFilter.BaseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode", (object)objFilter.BaseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)objFilter.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_UpdateDefineChargeMatrix", (object)dynamicParameters, "CustomerContract Master - DefineChargeMatrixEdit").FirstOrDefault<Response>();
		}

		public IEnumerable<CustomerContractChargeMatrixSTD> GetChargeMatrixSTDDetailBySearchingCriteria(
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
		  short consigneeId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn1", (object)baseOn1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn2", (object)baseOn2, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode1", (object)baseCode1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode2", (object)baseCode2, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromLocation", (object)fromLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToLocation", (object)toLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)matrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractChargeMatrixSTD>("Usp_CustomerContract_GetChargeMatrixSTDDetail", (object)dynamicParameters, "CustomerContract Master - GetChargeMatrixSTDDetail");
		}

		public Response InsertChargeMatrixSTD(CustomerContractChargeMatrixSTD objChargeMatrixSTD)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractChargeMatrixSTD", (object)XmlUtility.XmlSerializeToString((object)objChargeMatrixSTD), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objChargeMatrixSTD.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn1", (object)objChargeMatrixSTD.BaseOn1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn2", (object)objChargeMatrixSTD.BaseOn2, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode1", (object)objChargeMatrixSTD.BaseCode1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode2", (object)objChargeMatrixSTD.BaseCode2, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)objChargeMatrixSTD.ChargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromLocation", (object)objChargeMatrixSTD.FromLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToLocation", (object)objChargeMatrixSTD.ToLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)objChargeMatrixSTD.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)objChargeMatrixSTD.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FtlTypeId", (object)objChargeMatrixSTD.FtlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)objChargeMatrixSTD.MatrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsignorId", (object)objChargeMatrixSTD.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsigneeId", (object)objChargeMatrixSTD.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@EntryBy", (object)objChargeMatrixSTD.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_ChargeMatrixSTDInsert", (object)dynamicParameters, "CustomerContract Master - InsertChargeMatrixSTD").FirstOrDefault<Response>();
		}

		public StandardChargeMatrixUpload StandardChargeMatrixUpload(
		  StandardChargeMatrixUpload objCustomerContractChargeMatrixSTD)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("FieldName"));
			dataTable.Columns.Add(new DataColumn("FieldCaption"));
			DataRow row1 = dataTable.NewRow();
			row1["FieldName"] = (object)"ContractNo";
			row1["FieldCaption"] = (object)"Contract No";
			dataTable.Rows.Add(row1);
			DataRow row2 = dataTable.NewRow();
			row2["FieldName"] = (object)"ChargeCodeType";
			row2["FieldCaption"] = (object)"Charge Code Type";
			dataTable.Rows.Add(row2);
			DataRow row3 = dataTable.NewRow();
			row3["FieldName"] = (object)"IsBooking";
			row3["FieldCaption"] = (object)"Is Booking";
			dataTable.Rows.Add(row3);
			DataRow row4 = dataTable.NewRow();
			row4["FieldName"] = (object)"Matrix";
			row4["FieldCaption"] = (object)"Matrix";
			dataTable.Rows.Add(row4);
			DataRow row5 = dataTable.NewRow();
			row5["FieldName"] = (object)"From";
			row5["FieldCaption"] = (object)"From";
			dataTable.Rows.Add(row5);
			DataRow row6 = dataTable.NewRow();
			row6["FieldName"] = (object)"To";
			row6["FieldCaption"] = (object)"To";
			dataTable.Rows.Add(row6);
			DataRow row7 = dataTable.NewRow();
			row7["FieldName"] = (object)"TransportMode";
			row7["FieldCaption"] = (object)"Transport Mode";
			dataTable.Rows.Add(row7);
			DataRow row8 = dataTable.NewRow();
			row8["FieldName"] = (object)"FtlType";
			row8["FieldCaption"] = (object)"Ftl Type";
			dataTable.Rows.Add(row8);
			DataRow row9 = dataTable.NewRow();
			row9["FieldName"] = (object)"ConsignorName";
			row9["FieldCaption"] = (object)"Consignor Name";
			dataTable.Rows.Add(row9);
			DataRow row10 = dataTable.NewRow();
			row10["FieldName"] = (object)"ConsigneeName";
			row10["FieldCaption"] = (object)"Consignee Name";
			dataTable.Rows.Add(row10);
			DataRow row11 = dataTable.NewRow();
			row11["FieldName"] = (object)"Rate";
			row11["FieldCaption"] = (object)"Rate";
			dataTable.Rows.Add(row11);
			DataRow row12 = dataTable.NewRow();
			row12["FieldName"] = (object)"RateTypeDescription";
			row12["FieldCaption"] = (object)"Rate Type";
			dataTable.Rows.Add(row12);
			DataRow row13 = dataTable.NewRow();
			row13["FieldName"] = (object)"TransitDays";
			row13["FieldCaption"] = (object)"Transit Days";
			dataTable.Rows.Add(row13);
			DataRow row14 = dataTable.NewRow();
			row14["FieldName"] = (object)"BillLocation";
			row14["FieldCaption"] = (object)"Bill Location";
			dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"BillingCode";
            row15["FieldCaption"] = (object)"Billing Code";
            dataTable.Rows.Add(row15);
            DataRow row16= dataTable.NewRow();
            row16["FieldName"] = (object)"PartNo";
            row16["FieldCaption"] = (object)"Part No";
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"PackagingType";
            row17["FieldCaption"] = (object)"Packaging Type";
            dataTable.Rows.Add(row17);
            StandardChargeMatrixUploadHepler matrixUploadHepler1 = new StandardChargeMatrixUploadHepler();
			matrixUploadHepler1.fileUploadControl = objCustomerContractChargeMatrixSTD.File;
			matrixUploadHepler1.dtFormat = dataTable;
			matrixUploadHepler1.strFileNamePrefix = "StandardChargeMatrix";
			matrixUploadHepler1.strFilePath = "~/UploadedFiles/CustomerContract";
			matrixUploadHepler1.strModuleName = "StandardChargeMatrix";
			matrixUploadHepler1.strProcedureName = "Usp_CustomerContract_StandardChargeMatrix_Upload";
			StandardChargeMatrixUploadHepler matrixUploadHepler2 = matrixUploadHepler1;
			try
			{
				string str1 = matrixUploadHepler2.Upload(true);
				DynamicParameters dynamicParameters = new DynamicParameters();
				dynamicParameters.Add("@XmlCustomerContractChargeMatrixSTD", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
				dynamicParameters.Add("@EntryBy", (object)objCustomerContractChargeMatrixSTD.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
				matrixUploadHepler2.Result = DataBaseFactory.QuerySP<CustomerContractChargeMatrixSTD>(matrixUploadHepler2.strProcedureName, (object)dynamicParameters, "CustomerContract Master - UploadStandardChargeMatrix").ToList<CustomerContractChargeMatrixSTD>();
				if (matrixUploadHepler2.Result != null && matrixUploadHepler2.Result.Count > 0)
				{
					int num1 = matrixUploadHepler2.Result.Count<CustomerContractChargeMatrixSTD>((Func<CustomerContractChargeMatrixSTD, bool>)(x => x.UploadStatus == "Uploaded"));
					int num2 = matrixUploadHepler2.Result.Count - num1;
					string str2 = "";
					if (num1 > 0)
						str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
					if (num1 == 0 && num2 > 0)
						str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
					else if (num1 > 0 && num2 > 0)
						str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
					matrixUploadHepler2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
				}
				else
					matrixUploadHepler2.strResultMessage = "No Data Uploaded";
				objCustomerContractChargeMatrixSTD.IsSuccessfull = true;
				objCustomerContractChargeMatrixSTD.ErrorMessage = matrixUploadHepler2.strResultMessage;
				objCustomerContractChargeMatrixSTD.Details = matrixUploadHepler2.Result;
			}
			catch (Exception ex)
			{
				objCustomerContractChargeMatrixSTD.IsSuccessfull = false;
				objCustomerContractChargeMatrixSTD.ErrorMessage = ex.Message;
			}
			return objCustomerContractChargeMatrixSTD;
		}

		public IEnumerable<AutoCompleteResult> GetChargeList(
		  short contractId,
		  byte baseOn,
		  byte baseCode,
		  bool isBooking)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn", (object)baseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode", (object)baseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetChargeList", (object)dynamicParameters, "CustomerContract Master - GetChargeList");
		}

		public bool CheckOdaApplicable(short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsOdaApplicable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			DataBaseFactory.QuerySP("Usp_CustomerContract_IsOdaApplicable", (object)dynamicParameters, "CustomerContract Master - CheckOdaApplicable");
			return dynamicParameters.Get<bool>("@IsOdaApplicable");
		}

		public byte GetChargeBase(
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
			dynamicParameters.Add("@ChargeBase", (object)null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			DataBaseFactory.QuerySP("Usp_CustomerContract_GetChargeBase", (object)dynamicParameters, "CustomerContract Master - GetChargeBase");
			return dynamicParameters.Get<byte>("@ChargeBase");
		}

		public IEnumerable<AutoCompleteResult> GetBaseCode2List(
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
			return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetBaseCode2List", (object)dynamicParameters, "CustomerContract Master - GetBaseCode2List");
		}

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
			return DataBaseFactory.QuerySP<CustomerContractDefineChargeMatrix>("Usp_CustomerContract_GetDefineChargeMatrixDetail", (object)dynamicParameters, "CustomerContract Master - GetDetail").FirstOrDefault<CustomerContractDefineChargeMatrix>();
		}

		public IEnumerable<CustomerContract> GetFreightContractDetailsByManualContractId(
		  short contractId,
		  string manualContractId,
		  string customerCode,
		  string customerName)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualContractId", (object)manualContractId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerName", (object)customerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			Tuple<IEnumerable<CustomerContract>, IEnumerable<CustomerContractBasicInfo>> tuple = DataBaseFactory.QueryMultipleSP<CustomerContract, CustomerContractBasicInfo>("Usp_CustomerContract_GetFreightContractDetailsByManualContractId", (object)dynamicParameters, "CustomerContract Master - GetDetail");
			List<CustomerContract> customerContractList = new List<CustomerContract>();
			if (tuple != null && tuple.Item2 != null)
			{
				foreach (CustomerContract customerContract in tuple.Item1)
				{
					foreach (CustomerContractBasicInfo contractBasicInfo in tuple.Item2)
					{
						if ((int)contractBasicInfo.ContractId == (int)customerContract.ContractId)
							customerContract.CustomerContractBasicInfo = contractBasicInfo;
					}
					customerContractList.Add(customerContract);
				}
			}
			return (IEnumerable<CustomerContract>)customerContractList;
		}

		public CustomerContractBillingInfo GetBillingInfoByCustomerId(
		  short customerId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractBillingInfo>("Usp_CustomerContract_CustomerContractBillingInfo", (object)dynamicParameters, "CustomerContract Master - CustomerContractBillingInfo").FirstOrDefault<CustomerContractBillingInfo>();
		}

		public IEnumerable<CustomerContract> GetDetailsForFreightContract(
		  short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			Tuple<IEnumerable<CustomerContract>, IEnumerable<CustomerContractBasicInfo>> tuple = DataBaseFactory.QueryMultipleSP<CustomerContract, CustomerContractBasicInfo>("Usp_CustomerContract_GetDetailsForFreightContract", (object)dynamicParameters, "CustomerContract Master - GetDetailsForFreightContract");
			List<CustomerContract> customerContractList = new List<CustomerContract>();
			if (tuple != null && tuple.Item2 != null)
			{
				foreach (CustomerContract customerContract in tuple.Item1)
				{
					foreach (CustomerContractBasicInfo contractBasicInfo in tuple.Item2)
					{
						if ((int)contractBasicInfo.ContractId == (int)customerContract.ContractId)
							customerContract.CustomerContractBasicInfo = contractBasicInfo;
					}
					customerContractList.Add(customerContract);
				}
			}
			return (IEnumerable<CustomerContract>)customerContractList;
		}

		public bool IsFovApplicable()
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@IsFovApplicable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			DataBaseFactory.QuerySP("Usp_CustomerContract_IsFovApplicable", (object)dynamicParameters, "CustomerContract Master - IsFovApplicable");
			return dynamicParameters.Get<bool>("@IsFovApplicable");
		}

		public IEnumerable<CustomerContract> GetDetails()
		{
			return DataBaseFactory.QuerySP<CustomerContract>("Usp_CustomerContract_GetDetails", (object)new DynamicParameters(), "CustomerContract Master - GetDetails");
		}

		public IEnumerable<CustomerContract> GetDetailsByManualContractId(
		  string manualContractId,
		  string customerCode,
		  string customerName)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CustomerCode", (object)customerCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerName", (object)customerName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualContractId", (object)manualContractId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContract>("Usp_CustomerContract_GetDetailsByManualContractId", (object)dynamicParameters, "CustomerContract Master - GetDetailsByManualContractId");
		}

		public IEnumerable<CustomerContract> GetAll(
		  short customerId,
		  bool isCustomerContract)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsCustomerContract", (object)isCustomerContract, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContract>("Usp_CustomerContract_GetById", (object)dynamicParameters, "CustomerContract Master - GetAll");
		}

		public Response InsertODA(MasterODA objODA)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractODA", (object)XmlUtility.XmlSerializeToString((object)objODA), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertODA", (object)dynamicParameters, "CustomerContract Master - InsertODA").FirstOrDefault<Response>();
		}

		public MasterODA GetOdaDetail(short id)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<MasterODA>("Usp_CustomerContract_GetOdaDetail", (object)dynamicParameters, "CustomerContract Master - GetOdaDetail").FirstOrDefault<MasterODA>();
		}

		public CustomerContractBillingInfo GetBillingDetails(short contractId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractBillingInfo>("Usp_CustomerContract_GetBillingDetails", (object)dynamicParameters, "CustomerContract Master - GetBillingDetails").FirstOrDefault<CustomerContractBillingInfo>();
		}

		public Response InsertBillingInfo(
		  CustomerContractBillingInfo objCustomerContractBillingInfo)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractBillingInfo", (object)XmlUtility.XmlSerializeToString((object)objCustomerContractBillingInfo), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objCustomerContractBillingInfo.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertBillingInfo", (object)dynamicParameters, "CustomerContract Master - InsertBillingInfo").FirstOrDefault<Response>();
		}

		public Response UpdateRateMatrix(
		  CustomerContractChargeMatrixLTLHeader objRateMatrix)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractRateMatrix", (object)XmlUtility.XmlSerializeToString((object)objRateMatrix), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_UpdateRateMatrix", (object)dynamicParameters, "CustomerContract Master - RateMatrixUpdate").FirstOrDefault<Response>();
		}

		public IEnumerable<CustomerContractChargeMatrixLTL> GetRateMatrixList(
		  CustomerContractChargeMatrixLTLHeader objRateMatrix)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)objRateMatrix.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn1", (object)objRateMatrix.BaseOn1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn2", (object)objRateMatrix.BaseOn2, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode1", (object)objRateMatrix.BaseCode1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode2", (object)objRateMatrix.BaseCode2, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsignorId", (object)objRateMatrix.ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsigneeId", (object)objRateMatrix.ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)objRateMatrix.TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)objRateMatrix.IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)objRateMatrix.MatrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractChargeMatrixLTL>("Usp_CustomerContract_GetRateMatrixList", (object)dynamicParameters, "CustomerContract Master - GetRateMatrixList");
		}

		public IEnumerable<CustomerContractRateMatrixSlabRange> GetRateMatrixSlabRangeDetailBySearchingCriteria(
		  short id,
		  byte chargeCode)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractRateMatrixSlabRange>("Usp_CustomerContract_GetRateMatrixSlabRangeDetail", (object)dynamicParameters, "CustomerContract Master - GetRateMatrixSlabRangeDetail");
		}

		public Response InsertRateMatrixSlabRange(
		  CustomerContractRateMatrix objCustomerContractRateMatrix)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractRateMatrixSlabRange", (object)XmlUtility.XmlSerializeToString((object)objCustomerContractRateMatrix), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objCustomerContractRateMatrix.ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)objCustomerContractRateMatrix.ChargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertRateMatrixSlabRange", (object)dynamicParameters, "CustomerContract Master - RateMatrixSlabRangeInsert").FirstOrDefault<Response>();
		}

		public IEnumerable<CustomerContractRateMetrixSlabRate> GetRateMatrixSlabDetailBySearchingCriteria(
		  short id,
		  byte chargeCode)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<CustomerContractRateMetrixSlabRate>("Usp_CustomerContract_GetRateMatrixSlabDetail", (object)dynamicParameters, "CustomerContract Master - GetRateMatrixSlabDetailBySearchingCriteria");
		}

		public IEnumerable<CustomerContractRateMatrix> GetRateMatrixSlabRateDetailBySearchingCriteria(
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
		  short consigneeId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn1", (object)baseOn1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn2", (object)baseOn2, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode1", (object)baseCode1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode2", (object)baseCode2, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromLocation", (object)fromLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToLocation", (object)toLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)matrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			Tuple<IEnumerable<CustomerContractRateMatrix>, IEnumerable<CustomerContractRateMetrixSlabRate>> tuple = DataBaseFactory.QueryMultipleSP<CustomerContractRateMatrix, CustomerContractRateMetrixSlabRate>("Usp_CustomerContract_GetRateMatrixSlabRateDetail", (object)dynamicParameters, "CustomerContract Master - GetRateMatrixSlabRateDetail");
			List<CustomerContractRateMatrix> contractRateMatrixList = new List<CustomerContractRateMatrix>();
			if (tuple != null)
			{
				//foreach (CustomerContractRateMetrixSlabRate slab in tuple.Item2)
				//{
				//	foreach (CustomerContractRateMatrix rate in tuple.Item1)
				//	{
				//		if ((int)rate.ContractId == (int)slab.ContractId && (int)rate.FromLocation == (int)slab.FromLocation && (int)rate.ToLocation == (int)slab.ToLocation && (int)rate.RateMatrixId == (int)slab.RateMatrixId)
				//			rate.RateDetails.Add(slab);
				//	}
				//}



				foreach (CustomerContractRateMatrix contractRateMatrix in tuple.Item1)
				{
					foreach (CustomerContractRateMetrixSlabRate rateMetrixSlabRate in tuple.Item2)
					{
						if ((int)contractRateMatrix.ContractId == (int)rateMetrixSlabRate.ContractId && (int)contractRateMatrix.FromLocation == (int)rateMetrixSlabRate.FromLocation && (int)contractRateMatrix.ToLocation == (int)rateMetrixSlabRate.ToLocation )
							contractRateMatrix.RateDetails.Add(rateMetrixSlabRate);
					}
					contractRateMatrixList.Add(contractRateMatrix);
				}
			}
			return (IEnumerable<CustomerContractRateMatrix>)contractRateMatrixList;
		}

		public Response InsertRateMatrixSlabRate(List<CustomerContractRateMatrix> objRateMatrix)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@XmlCustomerContractRateMatrix", (object)XmlUtility.XmlSerializeToString((object)objRateMatrix), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ContractId", (object)objRateMatrix[0].ContractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn1", (object)objRateMatrix[0].BaseOn1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn2", (object)objRateMatrix[0].BaseOn2, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode1", (object)objRateMatrix[0].BaseCode1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode2", (object)objRateMatrix[0].BaseCode2, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)objRateMatrix[0].ChargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)objRateMatrix[0].TransportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)objRateMatrix[0].IsBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FtlTypeId", (object)objRateMatrix[0].FtlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)objRateMatrix[0].MatrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsignorId", (object)objRateMatrix[0].ConsignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsigneeId", (object)objRateMatrix[0].ConsigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_InsertRateMatrixSlabRate", (object)dynamicParameters, "CustomerContract Master - RateMatrixSlabRateInsert").FirstOrDefault<Response>();
		}

		public IEnumerable<AutoCompleteResult> GetMatrixTypeList(short id)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerContract_GetMatrixTypeList", (object)dynamicParameters, "CustomerContract Master - GetMatrixTypeList");
		}

		public IEnumerable<AutoCompleteResult> GetMovementTypeList()
		{
			return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
	  {
		new AutoCompleteResult() { Value = "1", Name = "AC" },
		new AutoCompleteResult() { Value = "2", Name = "EMPTY" },
		new AutoCompleteResult() { Value = "3", Name = "NON AC" }
	  };
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
			return DataBaseFactory.QuerySP<CustomerContractFleetCharge>("Usp_CustomerContract_GetFleetChargeBySearchingCriteria", (object)dynamicParameters, "CustomerContract Master - GetChargeMatrixSTDDetail");
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
			return DataBaseFactory.QuerySP<Response>("Usp_CustomerContract_FleetChargeInsert", (object)dynamicParameters, "CustomerContract Master - InsertFleetCharge").FirstOrDefault<Response>();
		}

		public CustomerContractChargeMatrixSTD GetExpenseRate(
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
			return DataBaseFactory.QuerySP<CustomerContractChargeMatrixSTD>("Usp_CustomerContract_GetExpenseRate", (object)dynamicParameters, "CustomerContract Master - GetExpenseRate").FirstOrDefault<CustomerContractChargeMatrixSTD>();
		}

		public RateInquiry GetRateInquiry(
		  short customerId,
		  byte matrixTypeId,
		  short fromLocationId,
		  short toLocationId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)matrixTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromLocation", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToLocation", (object)toLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			//      dynamicParameters.Add("@IsCustomerContract", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
			//      DataBaseFactory.QuerySP<RateInquiry>("Usp_CustomerContract_RateInquiry", (object) dynamicParameters, "CustomerContract Master - GetRateInquiry");
			// return dynamicParameters.Get<bool>("@IsCustomerContract");
			return DataBaseFactory.QuerySP<RateInquiry>("Usp_CustomerContract_RateInquiry", (object)dynamicParameters, "CustomerContract Master - GetOdaDetail").FirstOrDefault<RateInquiry>();
		}

		public IEnumerable<CustomerContractRateMatrix> GetRateMatrixSlabRateDetailBySearchingCriteriaSimply(
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
			  short consigneeId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@ContractId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn1", (object)baseOn1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseOn2", (object)baseOn2, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode1", (object)baseCode1, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BaseCode2", (object)baseCode2, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ChargeCode", (object)chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromLocation", (object)fromLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToLocation", (object)toLocation, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@IsBooking", (object)isBooking, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MatrixType", (object)matrixType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsignorId", (object)consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ConsigneeId", (object)consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			Tuple<IEnumerable<CustomerContractRateMatrix>, IEnumerable<CustomerContractRateMetrixSlabRate>> tuple = DataBaseFactory.QueryMultipleSP<CustomerContractRateMatrix, CustomerContractRateMetrixSlabRate>("Usp_CustomerContract_GetRateMatrixSlabRateDetail", (object)dynamicParameters, "CustomerContract Master - GetRateMatrixSlabRateDetail");
			List<CustomerContractRateMatrix> contractRateMatrixList = new List<CustomerContractRateMatrix>();
			if (tuple != null)
			{
				foreach (CustomerContractRateMatrix contractRateMatrix in tuple.Item1)
				{
					foreach (CustomerContractRateMetrixSlabRate rateMetrixSlabRate in tuple.Item2)
					{
						if ((int)contractRateMatrix.ContractId == (int)rateMetrixSlabRate.ContractId &&
							(int)contractRateMatrix.FromLocation == (int)rateMetrixSlabRate.FromLocation &&
							(int)contractRateMatrix.ToLocation == (int)rateMetrixSlabRate.ToLocation &&
							(int)contractRateMatrix.rowIndex == (int)rateMetrixSlabRate.rowIndex)
							contractRateMatrix.RateDetails.Add(rateMetrixSlabRate);
					}
					contractRateMatrixList.Add(contractRateMatrix);
				}
			}
			return (IEnumerable<CustomerContractRateMatrix>)contractRateMatrixList;
		}



		public IEnumerable<LaneDetail> GetLaneList(short companyId, short customerId, short? laneId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@LaneId", (object)laneId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			var lstLanes = DataBaseFactory.QuerySP<LaneDetail>("Usp_CustomerContract_GetLaneList", (object)dynamicParameters, "Customer Contract Master - GetLaneList");
			//var lst = lstLanes.Select(row => new AutoCompleteResult() { Name = row.LaneId, Value = row.LaneId }).ToList();
			return lstLanes;
		}

	}
}
