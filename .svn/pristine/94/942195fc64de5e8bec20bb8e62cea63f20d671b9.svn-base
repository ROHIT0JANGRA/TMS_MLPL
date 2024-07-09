//  
// Type: CodeLock.Areas.Finance.Repository.VendorPaymentRepository
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
    public class VendorPaymentRepository : BaseRepository, IVendorPaymentRepository, IDisposable
    {
        public IEnumerable<VendorBillDetail> GetBillListForBillCancellation(
                 short vendorId,
                 DateTime fromDate,
                 DateTime toDate,
                 DateTime finStartDate,
                 DateTime FinEndDate,
                 string billNos)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)FinEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillDetail>("Usp_VendorBillCancellation_GetBillList", (object)dynamicParameters, "Vendor Payment - GetBillListForBillCancellation");
        }


        public Response VendorBillCancellation(VendorBillCancellation objBillCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorBillCancellation", (object)XmlUtility.XmlSerializeToString((object)objBillCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBillCancellation_Insert", (object)dynamicParameters, "Vendor Payment - VendorBillCancellation").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorDocument> GetDocumentListForAdvancePayment(
      VendorAdvancePayment objVendorAdvancePayment)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)objVendorAdvancePayment.VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)objVendorAdvancePayment.LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BAMappedLocationid", (object)objVendorAdvancePayment.BAMappedLocationid, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)objVendorAdvancePayment.FromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)objVendorAdvancePayment.ToDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)objVendorAdvancePayment.DocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)objVendorAdvancePayment.ManualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentTypes", (object)objVendorAdvancePayment.SelectedDocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsTDSApplicable", (object)objVendorAdvancePayment.IsTDSApplicable, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorDocument>("Usp_VendorAdvancePayment_GetDocumentList", (object)dynamicParameters, "Vendor Payment - GetDocumentListForAdvancePayment");
        }

        public IEnumerable<VendorDocument> GetDocumentDetailForAdvancePayment(
          List<VendorDocument> objVendorDocument, short LocationId)
        {
            string str1 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.PRS)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str2 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.DRS)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str3 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.THC)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string st4 = string.Join<short>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.THC)).Select<VendorDocument, short>((Func<VendorDocument, short>)(x => x.BAMappedLocationid)));
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsNos", (object)str1, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DrsNos", (object)str2, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)str3, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BAMappedLocationid", (object)st4, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorDocument>("Usp_VendorAdvancePayment_GetDocumentDetail", (object)dynamicParameters, "Vendor Payment - GetDocumentDetailForAdvancePayment");
        }

        public Response AdvancePaymentInsert(VendorAdvancePayment objVendorAdvancePayment)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorAdvancePayment", (object)XmlUtility.XmlSerializeToString((object)objVendorAdvancePayment), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorAdvancePayment_Insert", (object)dynamicParameters, "Vendor Payment - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorDocument> GetDocumentListForVehicleHireBillGeneration(
          VendorBillGeneration objVendorBillGeneration)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)objVendorBillGeneration.VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)objVendorBillGeneration.FromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)objVendorBillGeneration.ToDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorGstStateId", (object)objVendorBillGeneration.VendorGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)objVendorBillGeneration.LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BAMappedLocationid", (object)objVendorBillGeneration.BAMappedLocationid, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)objVendorBillGeneration.DocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)objVendorBillGeneration.ManualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentTypes", (object)objVendorBillGeneration.SelectedDocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)objVendorBillGeneration.GstServiceTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)objVendorBillGeneration.TransportModeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsTDSApplicable", (object)objVendorBillGeneration.IsTDSApplicable, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorDocument>("Usp_VendorVehicleHireBill_GetDocumentList", (object)dynamicParameters, "Vendor Payment - GetDocumentListForAdvancePayment");
        }

        public IEnumerable<VendorDocument> GetDocumentDetailForVehicleHireBillGeneration(
           List<VendorDocument> objVendorDocument)
        {
            long vendorId = objVendorDocument.Where(w => w.VendorId > 0).FirstOrDefault().VendorId;
            string str1 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.PRS)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str2 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.DRS)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str3 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.THC)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str4 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.BABill)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str5 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.LabourDCBill)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str6 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.LoadingLabourBill)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str7 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.UnloadingLabourBill)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str8 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.BABillDelivery)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str9 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.FuelSlipBill)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));
            string str10 = string.Join<long>(",", objVendorDocument.Where<VendorDocument>((Func<VendorDocument, bool>)(m => (int)m.DocumentTypeId == (int)VendorDocumentType.BABillDoorDelivery)).Select<VendorDocument, long>((Func<VendorDocument, long>)(x => x.DocumentId)));

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PrsNos", (object)str1, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DrsNos", (object)str2, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)str3, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)str4, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LabourDCNos", (object)str5, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LoadingNos", (object)str6, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UnloadingNos", (object)str7, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BABillDeliveryNos", (object)str8, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FuelSlipBill", (object)str9, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BABillDoorDeliveryNos", (object)str10, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorDocument>("Usp_VendorVehicleHireBill_GetDocumentDetail", (object)dynamicParameters, "Vendor Payment - GetDocumentDetailForVehicleHireBillGeneration");
        }

        public Response VehicleHireBillInsert(VendorBillGeneration objVendorBillGeneration)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorVehicleHireBill", (object)XmlUtility.XmlSerializeToString((object)objVendorBillGeneration), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorVehicleHireBill_Insert", (object)dynamicParameters, "Vendor Payment - VehicleHireBillGeneration").FirstOrDefault<Response>();
        }

        public VendorBillCharges GetBillCharges()
        {
            IEnumerable<MasterCharge> source = DataBaseFactory.QuerySP<MasterCharge>("Usp_VendorPayment_GetChargeList", (object)null, "Vendor Payment - VehicleHireBillGeneration");
            return new VendorBillCharges()
            {
                OtherChargeList = source.ToList<MasterCharge>()
            };
        }

        public Response OtherBillInsert(OtherBillEntry objOtherBillEntry)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorOtherBill", (object)XmlUtility.XmlSerializeToString((object)objOtherBillEntry), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorOtherBill_Insert", (object)dynamicParameters, "Vendor Payment - OtherBillInsert").FirstOrDefault<Response>();
        }

        public IEnumerable<BaBillDetail> GetDocumentListForBaBillGeneration(
          short VendorId, DateTime FromDate, DateTime ToDate, string DocumentNo, short LocationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)FromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)ToDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)DocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<BaBillDetail>("Usp_VendorBaBill_GetDocumentList", (object)dynamicParameters, "Vendor Payment - GetDocumentListForBaBillGeneration");
        }

        public IEnumerable<BaBillDetail> GetDocumentDetailForBaBillGeneration(
          List<long> DocketId)
        {
            string str = string.Join<long>(",", (IEnumerable<long>)DocketId);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketIds", (object)str, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<BaBillDetail>("Usp_VendorBaBill_GetDocumentDetail", (object)dynamicParameters, "Vendor Payment - GetDocumentDetailForBaBillGeneration");
        }

        public Response BaBillInsert(BaBillEntry objBaBillEntry)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlBaBill", (object)XmlUtility.XmlSerializeToString((object)objBaBillEntry), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBaBill_Insert", (object)dynamicParameters, "Vendor Payment - BaBillInsert").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorBillDetail> GetBillListForBillFinalization(
          short locationId,
          short vendorId,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime FinEndDate,
          string billNos)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)FinEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillDetail>("Usp_VendorBillFinalization_GetBillList", (object)dynamicParameters, "Vendor Payment - GetBillListForBillPayment");
        }

        public Response BillFinalization(VendorBillFinalization objBillFinalization)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorBillFinalization", (object)XmlUtility.XmlSerializeToString((object)objBillFinalization), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBillFinalization_Insert", (object)dynamicParameters, "Vendor Payment - BillFinalization").FirstOrDefault<Response>();
        }


        public Response VendorBillFinalization(VendorBillFinalizationProcess objBillFinalization)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorBillFinalizationProcess", (object)XmlUtility.XmlSerializeToString((object)objBillFinalization), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBillFinalizationChange_Insert", (object)dynamicParameters, "Vendor Payment - BillFinalization").FirstOrDefault<Response>();
        }

        public Response VendorBillFinalizationV1(VendorBillFinalizationProcess objBillFinalization)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorBillFinalizationProcess", (object)XmlUtility.XmlSerializeToString((object)objBillFinalization), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBillFinalization_Insert_V1", (object)dynamicParameters, "Vendor Payment - BillFinalization").FirstOrDefault<Response>();
        }


        public IEnumerable<VendorBillDetail> GetBillListForBillPayment(
      VendorBillPayment objVendorBillPayment)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)objVendorBillPayment.VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)objVendorBillPayment.FromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)objVendorBillPayment.ToDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)objVendorBillPayment.LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)objVendorBillPayment.BillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)objVendorBillPayment.ManualBillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorServiceTypeId", (object)objVendorBillPayment.VendorServiceId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillDetail>("Usp_VendorBillPayment_GetBillList", (object)dynamicParameters, "Vendor Payment - GetBillListForBillPayment");
        }

        public IEnumerable<VendorBillDetail> GetBillDetailForBillPayment(
          string billId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillIds", (object)billId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillDetail>("Usp_VendorBillPayment_GetBillDetail", (object)dynamicParameters, "Vendor Payment - GetBillDetailForBillPayment");
        }


        public Response BillPayment(VendorBillPayment objVendorBillPayment)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorBillPayment", (object)XmlUtility.XmlSerializeToString((object)objVendorBillPayment), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBillPayment_Insert", (object)dynamicParameters, "Vendor Payment - VehicleHireBillGeneration").FirstOrDefault<Response>();
        }

        public VendorBillUpload InsertVendorBill(VendorBillUpload objVendorBillUpload)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));
            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"ManualBillNo";
            row1["FieldCaption"] = (object)"Manual Bill No";
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"BillDate";
            row2["FieldCaption"] = (object)"Bill Date";
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"DueDate";
            row3["FieldCaption"] = (object)"Due Date";
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"VendorCode";
            row4["FieldCaption"] = (object)"Vendor Code";
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"BillingBranch";
            row5["FieldCaption"] = (object)"Billing Branch";
            dataTable.Rows.Add(row5);
            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"PaymentBranch";
            row6["FieldCaption"] = (object)"Payment Branch";
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Narration";
            row7["FieldCaption"] = (object)"Narration";
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"AccountCode";
            row8["FieldCaption"] = (object)"Account Code";
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"Amount";
            row9["FieldCaption"] = (object)"Amount";
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"GstApplicable";
            row10["FieldCaption"] = (object)"GST Applicable";
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"GstRate";
            row11["FieldCaption"] = (object)"GST Rate";
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"Rcm";
            row12["FieldCaption"] = (object)"RCM";
            dataTable.Rows.Add(row12);
            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"SacCode";
            row13["FieldCaption"] = (object)"SAC Code";
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["FieldName"] = (object)"StateOfSupply";
            row14["FieldCaption"] = (object)"State Of Supply";
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["FieldName"] = (object)"StateOfBilling";
            row15["FieldCaption"] = (object)"State Of Billing";
            dataTable.Rows.Add(row15);
            DataRow row16 = dataTable.NewRow();
            row16["FieldName"] = (object)"VendorGstNo";
            row16["FieldCaption"] = (object)"Vendor GST No";
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["FieldName"] = (object)"GstNoOfBillingBranch";
            row17["FieldCaption"] = (object)"GST No Of Billing Branch";
            dataTable.Rows.Add(row17);
            DataRow row18 = dataTable.NewRow();
            row18["FieldName"] = (object)"TdsRate";
            row18["FieldCaption"] = (object)"TDS Rate";
            dataTable.Rows.Add(row18);
            DataRow row19 = dataTable.NewRow();
            row19["FieldName"] = (object)"TdsLedger";
            row19["FieldCaption"] = (object)"TDS Ledger";
            dataTable.Rows.Add(row19);
            FileUploadHelper fileUploadHelper = new FileUploadHelper();
            fileUploadHelper.fileUploadControl = objVendorBillUpload.File;
            fileUploadHelper.dtFormat = dataTable;
            fileUploadHelper.strFileNamePrefix = "VehicleStatus";
            fileUploadHelper.strFilePath = "~/UploadedFiles/";
            fileUploadHelper.strModuleName = "VehicleStatus";
            fileUploadHelper.strProcedureName = "Usp_XlsUpload_VehicleStatus";
            try
            {
                fileUploadHelper.Upload(true);
                objVendorBillUpload.IsSuccessfull = true;
                objVendorBillUpload.ErrorMessage = fileUploadHelper.strResultMessage;
            }
            catch (Exception ex)
            {
                objVendorBillUpload.IsSuccessfull = false;
                objVendorBillUpload.ErrorMessage = ex.Message;
            }
            return objVendorBillUpload;
        }

        public ChangeAdvanceBalanceLocation ValidateDocumentIdForAdvanceBalanceLocation(
          string DocumentNo)
        {
            ChangeAdvanceBalanceLocation advanceBalanceLocation = new ChangeAdvanceBalanceLocation();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentNo", (object)DocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ChangeAdvanceBalanceLocation>("Usp_VendorPayment_CheckValidDocumentForBalLocationChange", (object)dynamicParameters, "VendorPayment - ValidateDocumentIdForAdvanceBalanceLocation").FirstOrDefault<ChangeAdvanceBalanceLocation>();

        }



        public Response ChangeAdvanceBalanceLocation(
          ChangeAdvanceBalanceLocation objChangeAdvanceBalanceLocation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDoc", (object)XmlUtility.XmlSerializeToString((object)objChangeAdvanceBalanceLocation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //return DataBaseFactory.QuerySP<Response>("Usp_VendorPayment_UpdateAdvanceBalanceLocation", (object) dynamicParameters, "Vendor Payment - ChangeAdvanceBalanceLocation").FirstOrDefault<Response>();
            return DataBaseFactory.QuerySP<Response>("Usp_VendorPayment_UpdateMultiAdvanceBalanceLocation", (object)dynamicParameters, "Vendor Payment - ChangeAdvanceBalanceLocation").FirstOrDefault<Response>();
        }

        public Response VendorBillPaymentCancellation(VendorBillPaymentCancellation objVendorBillPaymentCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorBillPaymentCancellation", (object)XmlUtility.XmlSerializeToString((object)objVendorBillPaymentCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBillPaymentCancellation_Insert", (object)dynamicParameters, "Vendor Payment - VendorBillPaymentCancellation").FirstOrDefault<Response>();
        }

        public IEnumerable<VendorBillPaymentCancellation> GetVendorBillPaymentCancellation(
         string PaymentNos,
         DateTime fromDate,
         DateTime toDate,
         DateTime finStartDate,
         DateTime finEndDate,
         short locationId,
         byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaymentNos", (object)PaymentNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillPaymentCancellation>("Usp_VendorBillPaymentCancellation_GetPaymentBillList", (object)dynamicParameters, "Payment Bill Cancellation - GetVendorBillPaymentCancellation");
        }


        public IEnumerable<VendorAdvancePaymentCancellation> GetVendorAdvancePaymentCancellation(
         string PaymentNos,
         DateTime fromDate,
         DateTime toDate,
         DateTime finStartDate,
         DateTime finEndDate,
         short locationId,
         byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaymentNos", (object)PaymentNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorAdvancePaymentCancellation>("Usp_VendorAdvancePaymentCancellation_GetPaymentList", (object)dynamicParameters, "Advance Payment Cancellation - GetVendorAdvancePaymentCancellation");
        }

        public Response VendorAdvancePaymentCancellation(VendorAdvancePaymentCancellation objVendorAdvancePaymentCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendorAdvancePaymentCancellation", (object)XmlUtility.XmlSerializeToString((object)objVendorAdvancePaymentCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorAdvancePaymentCancellation_Insert", (object)dynamicParameters, "Vendor Advance Payment - VendorAdvancePaymentCancellation").FirstOrDefault<Response>();
        }


        public VendorBillUploadInSystem UploadInSystem(
        VendorBillUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"ManualBillNo";
            row1["FieldCaption"] = (object)"ManualBillNo";
            dataTable.Rows.Add(row1);

            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"BillDate";
            row2["FieldCaption"] = (object)"BillDate";
            dataTable.Rows.Add(row2);

            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"BillType";
            row3["FieldCaption"] = (object)"BillType";
            dataTable.Rows.Add(row3);

            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"VendorCode";
            row4["FieldCaption"] = (object)"VendorCode";
            dataTable.Rows.Add(row4);

            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"Vendor";
            row5["FieldCaption"] = (object)"Vendor";
            dataTable.Rows.Add(row5);

            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"BillingLocation";
            row6["FieldCaption"] = (object)"BillingLocation";
            dataTable.Rows.Add(row6);

            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"Amount";
            row7["FieldCaption"] = (object)"Amount";
            dataTable.Rows.Add(row7);

            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"SGST";
            row8["FieldCaption"] = (object)"SGST";
            dataTable.Rows.Add(row8);

            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"GSTRate";
            row12["FieldCaption"] = (object)"GSTRate";
            dataTable.Rows.Add(row12);

            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"CGST";
            row9["FieldCaption"] = (object)"CGST";
            dataTable.Rows.Add(row9);

            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"IGST";
            row10["FieldCaption"] = (object)"IGST";
            dataTable.Rows.Add(row10);

            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"Total";
            row11["FieldCaption"] = (object)"Total";
            dataTable.Rows.Add(row11);

            DataRow row13 = dataTable.NewRow();
            row13["FieldName"] = (object)"ManualRemark";
            row13["FieldCaption"] = (object)"ManualRemark";
            dataTable.Rows.Add(row13);

            VendorBillUploadHelper docketUploadHelper1 = new VendorBillUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "VendorBillUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "VendorBillUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_VendorBill_Upload_InSystem";
            VendorBillUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<VendorBillUploadInSystem>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Bill Upload - UploadInSystem").ToList<VendorBillUploadInSystem>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<VendorBillUploadInSystem>((Func<VendorBillUploadInSystem, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }


        public IEnumerable<ThcAdvBalPaymnt_Details> GetMultiAdvanceBalanceData(string DocumentNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentNo", (object)DocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcAdvBalPaymnt_Details>("Usp_CheckValidDocumentMultiAdvanceForBalLocationChange", (object)dynamicParameters, "Vendor Payment - GetMultiAdvanceBalanceData");
        }

        public Response InsertBillReAssign(LabourDCModule objBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LabourDCNo", (object)objBill.LabourDCNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillLocationId", (object)objBill.BillLocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Remarks", (object)objBill.Remarks, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objBill.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_ManifestLabourDC_ReAssign", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }
        public LabourDCModule CheckValidBillNoForReAssign(string LabourDCNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LabourDCNo", (object)LabourDCNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<LabourDCModule>("CL_ManifestLabourDC_GetBillReAssign", (object)dynamicParameters, "Docket- GetDocketData").FirstOrDefault<LabourDCModule>();
        }

        public Response InsertVendorBillReAssign(VendorBillReAssign objBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillNo", (object)objBill.BillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)objBill.LocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaymentLocationId", (object)objBill.PaymentLocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Remarks", (object)objBill.Remarks, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objBill.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VendorBill_ReAssign", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public VendorBillReAssign CheckValidVendorBillNoForReAssign(string BillNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillNo", (object)BillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillReAssign>("Usp_VendorBill_GetBillReAssign", (object)dynamicParameters, "Docket- GetDocketData").FirstOrDefault<VendorBillReAssign>();
        }

        public AutoCompleteResult IsOtherManualBillNoExist(short vendorId, string manualBillNo, string finYear, short locationId, byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNo", (object)manualBillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VendorBill_IsOtherManualBillNoExist", (object)dynamicParameters, "VendorBill- IsOtherManualBillNoExist").FirstOrDefault<AutoCompleteResult>();
        }

    }
}
