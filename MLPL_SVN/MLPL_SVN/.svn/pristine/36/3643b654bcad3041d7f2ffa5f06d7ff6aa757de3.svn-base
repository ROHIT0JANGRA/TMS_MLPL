//  
// Type: CodeLock.Areas.Operation.Repository.DrsRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using ExpressiveAnnotations.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls.WebParts;

namespace CodeLock.Areas.Operation.Repository
{
    public class DrsRepository : BaseRepository, IDrsRepository, IDisposable
    {
        public IEnumerable<AutoCompleteResult> GetBookedByList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "False", Name = "Staff" },
        new AutoCompleteResult() { Value = "True", Name = "BA" }
      };
        }

        public DrsCharges GetChargeList(long drsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return new DrsCharges()
            {
                OtherChargeList = DataBaseFactory.QuerySP<MasterCharge>("Usp_Drs_GetChargeList", (object)dynamicParameters, "DRS - GetChargesList").ToList<MasterCharge>()
            };
        }

        public Drs GetDocketList(
          DateTime fromDate,
          DateTime toDate,
          byte paybasId,
          byte transportModeId,
          byte businessTypeId,
          bool isOda,
          string docketNos,
          short vendorId,
          short locationId,
          byte companyId,
          bool isDeliveryThroughSameVehicle)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)businessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsOda", (object)isOda, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDeliveryThroughSameVehicle", (object)isDeliveryThroughSameVehicle, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Drs obj = new Drs();
            Tuple<IEnumerable<DrsDocket>, IEnumerable<DrsDocket>> tuple = DataBaseFactory.QueryMultipleSP<DrsDocket, DrsDocket>("Usp_Drs_GetDocketList", (object)dynamicParameters, "DRS - GetDocketList");

            obj.DrsDocketList = tuple.Item1.ToList<DrsDocket>();
            if (tuple.Item2 != null)
                obj.ErrorList = tuple.Item2.ToList<DrsDocket>();

            return obj;
        }

        public IEnumerable<DrsDocket> GetDocketListForUpdateDrs(
          long drsId,
          DateTime fromDate,
          DateTime toDate,
          byte paybasId,
          byte transportModeId,
          byte businessTypeId,
          bool isOda,
          string docketNos,
          short vendorId,
          short locationId,
          byte companyId,
          bool isDeliveryThroughSameVehicle)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)businessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsOda", (object)isOda, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsDeliveryThroughSameVehicle", (object)isDeliveryThroughSameVehicle, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DrsDocket>("Usp_Drs_GetDocketListForUpdateDrs", (object)dynamicParameters, "DRS - GetDocketListForUpdateDrs");
        }

        public Response Insert(Drs objDrs)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDrs", (object)XmlUtility.XmlSerializeToString((object)objDrs), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Drs_Insert", (object)dynamicParameters, "DRS - Insert").FirstOrDefault<Response>();
        }

        public Drs GetStep2DetailById(long drsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetStep2DetailById", (object)dynamicParameters, "Drs - GetStep2DetailById").FirstOrDefault<Drs>();
        }

        public Drs GetStep3DetailById(long drsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetStep3DetailById", (object)dynamicParameters, "Drs - GetStep3DetailById").FirstOrDefault<Drs>();
        }

        public Drs GetStep4DetailById(long drsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetStep4DetailById", (object)dynamicParameters, "Drs - GetStep4DetailById").FirstOrDefault<Drs>();
        }

        public Drs GetStep5DetailById(long drsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetStep5DetailById", (object)dynamicParameters, "Drs - GetStep5DetailById").FirstOrDefault<Drs>();
        }

        public Drs GetStep6DetailById(long drsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetStep6DetailById", (object)dynamicParameters, "Drs - GetStep6DetailById").FirstOrDefault<Drs>();
        }

        public AutoCompleteResult CheckValidDrsNo(string drsNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsNo", (object)drsNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Drs_CheckValidDrsNo", (object)dynamicParameters, "Drs - CheckValidDrsNo").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<Drs> GetDrsListForDrsUpdate(
          string drsNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DrsNos", (object)drsNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_DrsUpdate_GetDrsList", (object)dynamicParameters, "DRS - GetDrsListForDrsUpdate");
        }

        public Drs GetDrsDocketListById(long drsId, short locationId, byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Drs>, IEnumerable<DrsDocket>> tuple = DataBaseFactory.QueryMultipleSP<Drs, DrsDocket>("Usp_DrsUpdate_GetDrsDocketListById", (object)dynamicParameters, "DRS - GetDrsDocketListById");
            Drs drs1 = new Drs();
            if (tuple == null)
                return drs1;
            Drs drs2 = tuple.Item1.FirstOrDefault<Drs>();
            if (tuple.Item2 != null)
                drs2.DrsDocketList.AddRange(tuple.Item2);
            return drs2;
        }

        public Response Close(DrsClose objDrs)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDrsClose", (object)XmlUtility.XmlSerializeToString((object)objDrs), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Drs_Close", (object)dynamicParameters, "Drs - Close").FirstOrDefault<Response>();
        }

        public Response Update(Drs objDrs)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDrsUpdate", (object)XmlUtility.XmlSerializeToString((object)objDrs), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Drs_Update", (object)dynamicParameters, "Drs - Update").FirstOrDefault<Response>();
        }

        public IEnumerable<Drs> GetDrsListForCancellation(
          string drsNos,
          string manualDrsNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsNos", (object)drsNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDrsNos", (object)manualDrsNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetDrsListForCancellation", (object)dynamicParameters, "Drs - GetDrsListForCancellation");
        }

        public Response Cancellation(DrsCancellation objDrsCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDrs", (object)XmlUtility.XmlSerializeToString((object)objDrsCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Drs_Cancellation", (object)dynamicParameters, "Drs - Cancellation").FirstOrDefault<Response>();
        }
        public IEnumerable<Docket> GetOrderDeliveryDocketList(
          string docketNo,
          DateTime fromDate,
          DateTime toDate)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_OrderDelivery_GetDocketListForDeliverOrder", (object)dynamicParameters, "DRS - GetDocketListForDeliverOrder");
        }

        public IEnumerable<DeliverOrderInvoiceDetail> GetOrderDeliveryPartListForDocket(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@docketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DeliverOrderInvoiceDetail>("Usp_OrderDelivery_GetPartListForDocket", (object)dynamicParameters, "DRS - GetPartListForDeliverOrder");
        }
        public DeliverOrder GetOrderDeliveryDocketPartDetail(long docketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)docketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DeliverOrder>("Usp_OrderDelivery_GetDocketPartDetail", (object)dynamicParameters, "DRS - GetDocketDetailForDeliverOrder").FirstOrDefault();
        }
        public Response OrderDeliveryInsert(DeliverOrder deliverOrder)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDrsDeliverOrder", (object)XmlUtility.XmlSerializeToString((object)deliverOrder), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_OrderDelivery_Insert", (object)dynamicParameters, "Drs - DeliverOrder").FirstOrDefault<Response>();
        }
        public IEnumerable<Drs> GetDrsListForDrsCloseCancellation(
          string drsNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsNos", (object)drsNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Drs>("Usp_Drs_GetDrsListForDrsCloseCancellation", (object)dynamicParameters, "Drs - GetDrsListForDrsCloseCancellation");
        }
        public Response DrsCloseCancellation(
            long drsId,
            string cancelReason,
            DateTime cancelDate,
            short cancelBy,
            short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DrsId", (object)drsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@@CancelReason", (object)cancelReason, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelDate", (object)cancelDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelBy", (object)cancelBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Drs_Close_Cancellation", (object)dynamicParameters, "Drs - DrsCloseCancellation").FirstOrDefault<Response>();
        }
    }
}
