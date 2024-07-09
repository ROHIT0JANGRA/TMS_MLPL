//  
// Type: CodeLock.Areas.Finance.Repository.ITrackingRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Finance.Repository
{
	public interface ITrackingRepository : IDisposable
	{
		IEnumerable<CustomerBill> GetCustomerBillList(
		  short locationId,
		  short customerId,
		  byte billTypeId,
		  DateTime fromDate,
		  DateTime toDate,
		  string billNos,
		  string manualBillNos);

		IEnumerable<CustomerBill> GetDeliveryMrCustomerBillList(
	  short locationId,
	  short customerId,
	  byte billTypeId,
	  DateTime fromDate,
	  DateTime toDate,
	  string billNos,
	  string manualBillNos);



		IEnumerable<MrTracking> GetMrList(
		  short locationId,
		  short customerId,
		  DateTime fromDate,
		  DateTime toDate,
		  string mrNos,
		  string manualMrNos);

		IEnumerable<MrTracking> GetDeliveryMrList(
		  short locationId,
		  short customerId,
		  DateTime fromDate,
		  DateTime toDate,
		  string mrNos,
		  string manualMrNos);

		IEnumerable<TplBillEntry> GetVendorBillList(
		  short locationId,
		  short vendorId,
		  byte billTypeId,
		  DateTime fromDate,
		  DateTime toDate,
		  string billNos,
		  string manualBillNos);

		IEnumerable<Voucher> GetVoucherList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo,
		  byte partyType,
		  string partyName);

		IEnumerable<BillPayment> GetVendorBillPaymentList(
		  short locationId,
		  byte billTypeId,
		  DateTime fromDate,
		  DateTime toDate,
		  string paymentNo);

		IEnumerable<CreditDebitNote> GetCreditDebitNoteList(
	  short locationId,
	  DateTime fromDate,
	  DateTime toDate,
	  string documentNo,
	  string manualDocumentNo,
	  short partyId,
	  byte noteTypeId);
	}
}
