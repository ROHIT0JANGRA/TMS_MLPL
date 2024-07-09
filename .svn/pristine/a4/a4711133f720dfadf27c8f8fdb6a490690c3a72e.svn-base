//  
// Type: CodeLock.Areas.Finance.Repository.TrackingRepository
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

namespace CodeLock.Areas.Finance.Repository
{
	public class TrackingRepository : BaseRepository, ITrackingRepository, IDisposable
	{
		public IEnumerable<CustomerBill> GetCustomerBillList(
		  short locationId,
		  short customerId,
		  byte billTypeId,
		  DateTime fromDate,
		  DateTime toDate,
		  string billNos,
		  string manualBillNos)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillTypeId", (object)billTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CustomerBill>)DataBaseFactory.QuerySP<CustomerBill>("Usp_Tracking_GetCustomerBillList", (object)dynamicParameters, "Finance Tracking - GetCustomerBillList").ToList<CustomerBill>();
		}

		public IEnumerable<CustomerBill> GetDeliveryMrCustomerBillList(
	  short locationId,
	  short customerId,
	  byte billTypeId,
	  DateTime fromDate,
	  DateTime toDate,
	  string billNos,
	  string manualBillNos)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillTypeId", (object)billTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CustomerBill>)DataBaseFactory.QuerySP<CustomerBill>("Usp_Tracking_GetDeliveryMRBillList", (object)dynamicParameters, "Finance Tracking - GetDeliveryMrCustomerBillList").ToList<CustomerBill>();
		}



		public IEnumerable<MrTracking> GetMrList(
		  short locationId,
		  short customerId,
		  DateTime fromDate,
		  DateTime toDate,
		  string mrNos,
		  string manualMrNos)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MrNos", (object)mrNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualMrNos", (object)manualMrNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<MrTracking>)DataBaseFactory.QuerySP<MrTracking>("Usp_Tracking_GetMrList", (object)dynamicParameters, "Finance Tracking - GetMrList").ToList<MrTracking>();
		}

		public IEnumerable<MrTracking> GetDeliveryMrList(
		  short locationId,
		  short customerId,
		  DateTime fromDate,
		  DateTime toDate,
		  string mrNos,
		  string manualMrNos)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@MrNos", (object)mrNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualMrNos", (object)manualMrNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<MrTracking>)DataBaseFactory.QuerySP<MrTracking>("Usp_Tracking_GetDeliveryMrList", (object)dynamicParameters, "Finance Tracking - GetDeliveryMrList").ToList<MrTracking>();
		}

		public IEnumerable<TplBillEntry> GetVendorBillList(
		  short locationId,
		  short vendorId,
		  byte billTypeId,
		  DateTime fromDate,
		  DateTime toDate,
		  string billNos,
		  string manualBillNos)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillTypeId", (object)billTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<TplBillEntry>)DataBaseFactory.QuerySP<TplBillEntry>("Usp_Tracking_GetVendorBillList", (object)dynamicParameters, "Finance Tracking - GetVendorBillList").ToList<TplBillEntry>();
		}

		public IEnumerable<BillPayment> GetVendorBillPaymentList(
		  short locationId,
		  byte billTypeId,
		  DateTime fromDate,
		  DateTime toDate,
		  string paymentNo)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@BillTypeId", (object)billTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PaymentNo", (object)paymentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<BillPayment>)DataBaseFactory.QuerySP<BillPayment>("Usp_Tracking_GetVendorBillPaymentList", (object)dynamicParameters, "Finance Tracking - GetVendorBillPaymentList").ToList<BillPayment>();
		}

		public IEnumerable<Voucher> GetVoucherList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo,
		  byte partyType,
		  string partyName)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PartyType", (object)partyType, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PartyName", (object)partyName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<Voucher>)DataBaseFactory.QuerySP<Voucher>("Usp_Tracking_GetVoucherList", (object)dynamicParameters, "Tracking - GetVoucherList").ToList<Voucher>();
		}

		public IEnumerable<CreditDebitNote> GetCreditDebitNoteList(short locationId, DateTime fromDate, DateTime toDate, string documentNo, string manualDocumentNo, short partyId, byte noteTypeId)
		{
			DynamicParameters dynamicParameters = new DynamicParameters();
			dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@PartyId", (object)partyId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@NoteTypeId", (object)noteTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			return (IEnumerable<CreditDebitNote>)DataBaseFactory.QuerySP<CreditDebitNote>("Usp_Tracking_GetCreditDebitNoteList", (object)dynamicParameters, "Tracking - GetCreditDebitNoteList").ToList<CreditDebitNote>();
		}
	}
}
