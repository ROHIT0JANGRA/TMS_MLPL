//  
// Type: CodeLock.Areas.FMS.Repository.TripsheetRepository
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

namespace CodeLock.Areas.FMS.Repository
{
    public class TripsheetRepository : BaseRepository, ITripsheetRepository, IDisposable
    {

        public Response InsertMilkRunTripsheet(MilkRunLogDetail objTripsheetClosure)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripsheetClosure), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_MilkRunSheet_Insert", (object)dynamicParameters, "Tripsheet - Close").FirstOrDefault<Response>();
        }
        public MilkRunLogDetail GetMilkRunTripsheetDetails(string TripsheetNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetNo", (object)TripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<MilkRunLogDetail>, IEnumerable<VehicleLogDetail>> tuple = DataBaseFactory.QueryMultipleSP<MilkRunLogDetail, VehicleLogDetail>("CL_TripSheet_MilkRun_GetLogDetail", (object)dynamicParameters, "Tripsheet - MilkRun_GetLogDetail");

            MilkRunLogDetail milkRunLogDetail = new MilkRunLogDetail();
            milkRunLogDetail = tuple.Item1.FirstOrDefault<MilkRunLogDetail>();

            if (tuple.Item2 != null && milkRunLogDetail != null)
                milkRunLogDetail.VehicleLogDetail = tuple.Item2.ToList<VehicleLogDetail>();

            return milkRunLogDetail;
        }
        public IEnumerable<Tracking_Details> GetVehicleTrackingId(
        string TripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)TripsheetId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tracking_Details>("CL_Tripsheet_VehicleTracking_GetById", (object)dynamicParameters, "Tripsheet - GetDocketListByVehicleNo");
        }
        public Response VehicleTrackingInsert(VehicleTracking obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Xml", (object)XmlUtility.XmlSerializeToString((object)obj), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_Tripsheet_VehicleTracking_Insert", (object)dynamicParameters, "Asn  - Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<AutoCompleteResult> GetTrispeedListByVehicleNo(
       string vehicleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleId", (object)vehicleId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_GetTripsheetListByVehicleNo", (object)dynamicParameters, "Tripsheet - GetDocketListByVehicleNo");
        }
        public IEnumerable<AutoCompleteResult> GetStatusReason(
         byte VehicleStatus)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleStatus", (object)VehicleStatus, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_GetStatusReasonByStatus", (object)dynamicParameters, "Tripsheet - GetStatusReason");
        }
        public MaintananceList GetMetnatancList(string VehicleNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)VehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<VehicleMaintenanceStatus>, IEnumerable<MaintncTouple>> tuple = DataBaseFactory.QueryMultipleSP<VehicleMaintenanceStatus, MaintncTouple>("Usp_GetMetnatancList", (object)dynamicParameters, "Tripsheet - GetMetnatancList");

            MaintananceList GetMetnatancListobj = new MaintananceList();
            GetMetnatancListobj.MntncLst = tuple.Item1;
            GetMetnatancListobj.MntncLst2 = tuple.Item2;
            return GetMetnatancListobj;
        }

        public string GetNextFileName()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return DataBaseFactory.QuerySP<string>("Usp_GetNxtFileNmVehMaintanance", (object)dynamicParameters, "Tripsheet - GetNextFileName").FirstOrDefault<string>();
        }
        public Response VehicleMaintenanceInsert(VehicleMaintenanceStatus objVehicleMaintenanceStatus)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVehicleMaintenanceStatus", (object)XmlUtility.XmlSerializeToString((object)objVehicleMaintenanceStatus), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<Response>("Usp_VehicleMaintenanceInsert", (object)dynamicParameters, "Tripsheet - VehicleMaintenanceInsert").FirstOrDefault<Response>();
        }
        public Response VehicleStatusInsert(VehicleStatusDetail objVehicleStatusDetail, short LoginUserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVehicleStatusDetail", (object)XmlUtility.XmlSerializeToString((object)objVehicleStatusDetail), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LoginUserId", (object)LoginUserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VehicleStatusDetailInsert", (object)dynamicParameters, "Tripsheet - VehicleStatusDetailInsert").FirstOrDefault<Response>();
        }
        public VehicleStatusDetail GetVehicleStatus(string VehicleNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)VehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VehicleStatusDetail>("Usp_GetGetVehicleStatus", (object)dynamicParameters, "Tripsheet - Usp_Docket_GetStep2DetailById").FirstOrDefault<VehicleStatusDetail>();
        }

        public Response Insert(Tripsheet objTripsheet)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripsheet), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Id", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@No", (object)null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(25));
            dynamicParameters.Add("@IsSuccessfull", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Tripsheet_Insert", (object)dynamicParameters, "Tripsheet - Generate");
            Response response = new Response();
            response.DocumentId = dynamicParameters.Get<long>("@Id");
            response.DocumentNo = dynamicParameters.Get<string>("@No");
            response.IsSuccessfull = dynamicParameters.Get<bool>("@IsSuccessfull");
            return response;
        }

        public Response Close(TripsheetClosure objTripsheetClosure)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripsheetClosure), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_Close", (object)dynamicParameters, "Tripsheet - Close").FirstOrDefault<Response>();
        }

        public Response DriverSettlement(DriverSettlement objDriverSettlement)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objDriverSettlement), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_DriverSettlement", (object)dynamicParameters, "Tripsheet - DriverSettlement").FirstOrDefault<Response>();
        }

        public IEnumerable<DocketDetail> GetDocketListByVehicleNo(
          string vehicleNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketDetail>("Usp_Tripsheet_GetDocketListByVehicleNo", (object)dynamicParameters, "Tripsheet - GetDocketListByVehicleNo");
        }

        public IEnumerable<ChecklistDetail> GetCheckList()
        {
            return (IEnumerable<ChecklistDetail>)DataBaseFactory.QuerySP<ChecklistDetail>("Usp_Tripsheet_GetCheckList", (object)null, "Tripsheet - GetCheckList").ToList<ChecklistDetail>();
        }

        public bool IsFuelSlipNoAvailable(string fuelSlipNo, long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FuelSlipNo", (object)fuelSlipNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Tripsheet_IsFuelSlipNoAvailable", (object)dynamicParameters, "Tripsheet Master - IsFuelSlipNoAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<Tripsheet> GetTripsheetListForClose(
          byte tripsheetAction,
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetAction", (object)tripsheetAction, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@SearchBy", (object)searchBy, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetTripsheetListForClose", (object)dynamicParameters, "Tripsheet - GetTripsheetListForClose");
        }

        public TripsheetClosure GetById(long id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetClosure>("Usp_Tripsheet_GetById", (object)dynamicParameters, "Tripsheet - GetById").FirstOrDefault<TripsheetClosure>();
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteChargeList(
          string chargeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ChargeName", (object)chargeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_GetAutoCompleteChargeList", (object)dynamicParameters, "Tripsheet - GetAutoCompleteChargeList");
        }

        public AutoCompleteResult IsChargeNameExist(string chargeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ChargeName", (object)chargeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_IsChargeNameExist", (object)dynamicParameters, "Tripsheet - IsChargeNameExist").FirstOrDefault<AutoCompleteResult>();
        }
        public AutoCompleteResult IsChargeNameExistTripSheet(string chargeName, string TripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ChargeName", (object)chargeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetId", (object)TripsheetId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_IsChargeNameExistInTripSheet", (object)dynamicParameters, "Tripsheet - IsChargeNameExist").FirstOrDefault<AutoCompleteResult>();
        }
        public IEnumerable<TripsheetAdvance> GetAdvanceDetail(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetAdvance>("Usp_Tripsheet_GetAdvanceDetail", (object)dynamicParameters, "Tripsheet - GetAdvanceDetail");
        }

        public IEnumerable<Tripsheet> GetTripsheetListForDriverSettlement(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SearchBy", (object)searchBy, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetTripsheetListForDriverSettlement", (object)dynamicParameters, "Tripsheet - GetTripsheetListForDriverSettlement");
        }

        public IEnumerable<OilExpenses> GetTripsheetOilExpenseList(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<OilExpenses>("Usp_Tripsheet_GetTripsheetOilExpenseList", (object)dynamicParameters, "Tripsheet - GetTripsheetOilExpenseList");
        }

        public IEnumerable<ThcDetail> GetTripsheetThcDetailList(long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcDetail>("Usp_Tripsheet_GetTripsheetThcDetailList", (object)dynamicParameters, "Tripsheet - GetTripsheetThcDetailList");
        }

        public IEnumerable<ThcFieldDetail> GetTripsheetThcFieldDetailList(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcFieldDetail>("Usp_Tripsheet_GetTripsheetThcFieldDetailList", (object)dynamicParameters, "Tripsheet - GetTripsheetThcFieldDetailList");
        }
        public IEnumerable<TripsheetLaneDetail> GetTripsheetLaneFieldDetailList(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetLaneDetail>("Usp_Tripsheet_GetTripsheetLaneFieldDetailList", (object)dynamicParameters, "Tripsheet - GetTripsheetLaneFieldDetailList");
        }
        public IEnumerable<EnRouteExpenses> GetTripsheetEnrouteExpenseList(
           long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<EnRouteExpenses>("Usp_Tripsheet_GetTripsheetEnrouteExpenseList", (object)dynamicParameters, "Tripsheet - GetTripsheetEnrouteExpenseList");
        }

        public IEnumerable<VehicleLogDetail> GetTripsheetVehicleLogList(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VehicleLogDetail>("Usp_Tripsheet_GetTripsheetVehicleLogList", (object)dynamicParameters, "Tripsheet - GetTripsheetVehicleLogList");
        }

        public IEnumerable<OilExpenses> GetOilExpenseDetailAgaintsCash(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<OilExpenses>("Usp_Tripsheet_GetOilExpenseDetailAgaintsCash", (object)dynamicParameters, "Tripsheet - GetOilExpenseDetailAgaintsCash");
        }

        public IEnumerable<EnRouteExpenses> GetEnRouteExpenseDetail(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<EnRouteExpenses>("Usp_Tripsheet_GetEnRouteExpenseDetail", (object)dynamicParameters, "Tripsheet - GetEnRouteExpenseDetail");
        }

        public IEnumerable<Tripsheet> GetTripsheetListForDriverAdvance(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SearchBy", (object)searchBy, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetTripsheetListForDriverAdvance", (object)dynamicParameters, "Tripsheet - GetTripsheetListForDriverAdvance");
        }

        public Response DriverAdvanceInsert(DriverAdvance objDriverAdvance)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDriverAdvance", (object)XmlUtility.XmlSerializeToString((object)objDriverAdvance), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_DriverAdvanceInsert", (object)dynamicParameters, "Tripsheet - DriverAdvanceInsert").FirstOrDefault<Response>();
        }

        public AutoCompleteResult IsTripsheetNoExist(string tripsheetNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_IsTripsheetNoExist", (object)dynamicParameters, "Tripsheet - IsTripsheetNoExist").FirstOrDefault<AutoCompleteResult>();
        }

        public List<TripsheetLaneDetail> GetLaneList(short companyId, short customerId, long? laneId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LaneId", laneId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var lst = DataBaseFactory.QuerySP<TripsheetLaneDetail>("Usp_TripsheetClosure_GetLaneList", (object)dynamicParameters, "Tripsheet Closure - GetLaneList");
            return lst.ToList();
        }
        public List<TripsheetLaneDetail> GetLaneDetail(short companyId, short customerId, long laneId, DateTime? TrisheeetDate)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LaneId", laneId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetDate", TrisheeetDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            var lst = DataBaseFactory.QuerySP<TripsheetLaneDetail>("Usp_TripsheetClosure_GetLaneDetail", (object)dynamicParameters, "Tripsheet Closure - GetLaneList");
            return lst.ToList();
        }
        public List<TripsheetLaneDetail> GetFSCRateContractDetail(short companyId, short customerId, long? laneId, long VehicleId, DateTime? StartDate, short? ContractID)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Int16));
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16));
            dynamicParameters.Add("@LaneId", laneId, new DbType?(DbType.Int64));
            dynamicParameters.Add("@VehicleId", VehicleId, new DbType?(DbType.Int64));
            dynamicParameters.Add("@StartDate", StartDate, new DbType?(DbType.DateTime));
            dynamicParameters.Add("@ContractID", ContractID, new DbType?(DbType.Int64));
            var lst = DataBaseFactory.QuerySP<TripsheetLaneDetail>("Usp_TripsheetClosure_GetLaneContractDetail", (object)dynamicParameters, "Tripsheet Closure - GetFSCRateContractDetail");
            return lst.ToList();
        }
        public IEnumerable<AutoCompleteResult> GetCardListByTripsheetId(
          long tripsheetId,
          bool isFuelCard)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsFuelCard", (object)isFuelCard, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Tripsheet_GetCardListByTripsheetId", (object)dynamicParameters, "City Master - GetCityListByStateId");
        }

        public IEnumerable<Tripsheet> GetTripsheetListForFuelSlip(
          string manualTripsheetNo,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          string vehicleNo)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ManualTripsheetNo", (object)manualTripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleNo", (object)vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetTripsheetListForFuelSlip", (object)dynamicParameters, "Tripsheet - GetTripsheetListForFuelSlip");
        }

        public IEnumerable<FuelSlipDetail> GetFuelSlipDetailByTripsheetId(
          long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<FuelSlipDetail>("Usp_Tripsheet_GetFuelSlipDetailByTripsheetId", (object)dynamicParameters, "Tripsheet - GetFuelSlipDetailByTripsheetId");
        }

        public Response FuelSlipInsert(FuelSlip objFuelSlip)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlFuelSlip", (object)XmlUtility.XmlSerializeToString((object)objFuelSlip), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_FuelSlipInsert", (object)dynamicParameters, "Tripsheet - FuelSlipInsert").FirstOrDefault<Response>();
        }

        public IEnumerable<Tripsheet> GetCancelledTripsheetList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string tripsheetNos,
          string manualTripsheetNos)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNos", (object)tripsheetNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualTripsheetNos", (object)manualTripsheetNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetCancelledTripsheetList", (object)dynamicParameters, "Tripsheet - GetCancelledTripsheetList");
        }

        public Response Cancellation(TripsheetCancellation objTripsheetCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripsheetCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_Cancellation", (object)dynamicParameters, "Cancel Tripsheet").FirstOrDefault<Response>();
        }

        public IEnumerable<TripsheetExpectedExpense> GetTripsheetListForExpectedExpense(
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetExpectedExpense>("Usp_Tripsheet_GetTripsheetListForExpectedExpense", (object)dynamicParameters, "Tripsheet - GetTripsheetListForExpectedExpense");
        }

        public Response ExpectedExpense(
          TripsheetExpectedExpense objTripsheetExpectedExpense)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheetExpectedExpense", (object)XmlUtility.XmlSerializeToString((object)objTripsheetExpectedExpense), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_ExpectedExpense", (object)dynamicParameters, "Tripsheet - Expected Expense").FirstOrDefault<Response>();
        }

        public IEnumerable<Tripsheet> GetTripsheetListForExpectedDriverAdvance(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          DateTime finStartDate,
          DateTime finEndDate)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SearchBy", (object)searchBy, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetTripsheetListForExpectedDriverAdvance", (object)dynamicParameters, "Tripsheet - GetTripsheetListForDriverAdvance");
        }

        public IEnumerable<ExpectedDriverAdvanceDetails> GetExpectedDriverAdvanceDetailById(
          long id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ExpectedDriverAdvanceDetails>("Usp_Tripsheet_GetExpectedDriverAdvanceDetailById", (object)dynamicParameters, "Tripsheet  - Usp_Tripsheet_GetExpectedDriverAdvanceDetailById");
        }

        public Response ExpectedDriverAdvanceInsert(
          ExpectedDriverAdvance objExpectedDriverAdvance)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlExpectedDriverAdvance", (object)XmlUtility.XmlSerializeToString((object)objExpectedDriverAdvance), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_ExpectedDriverAdvanceInsert", (object)dynamicParameters, "Tripsheet - DriverAdvanceInsert").FirstOrDefault<Response>();
        }
        public IEnumerable<GetVehicleStatusList> GetVehicleStatusListDtl()
        {
            return DataBaseFactory.QuerySP<GetVehicleStatusList>("Usp_GetVehicleStatusHeaderList", (object)null, "Tripsheet - GetVehicleStatusListDtl");
        }

        public IEnumerable<GetVehicleStatusList> GetVehicleStatusListDtl(long userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@userId", (object)userId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<GetVehicleStatusList>("Usp_GetVehicleStatusHeaderList", (object)dynamicParameters, "Tripsheet - GetVehicleStatusListDtl");
        }
        public IEnumerable<GetVehicleStatusList> GetVehicleStatusDtl(long userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@userId", (object)userId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<GetVehicleStatusList>("Usp_GetVehicleStatusHeaderListDetail", (object)dynamicParameters, "Tripsheet - GetVehicleStatusListDtl");
        }
        public IEnumerable<GetVehicleListForMaintanance> VehicleMaintananceUpdateDataList(long id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<GetVehicleListForMaintanance>("Usp_GetVehicleMaintananceUpdateDataList", (object)dynamicParameters, "Tripsheet - VehicleMaintananceUpdateDataList");
        }

        public Response VehicleStatusListUpdateInsert(VehicleMaintananceUpdateData objVehicleMaintananceUpdateData)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVehicleMaintananceUpdateData", (object)XmlUtility.XmlSerializeToString((object)objVehicleMaintananceUpdateData), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VehicleMaintenanceInsertVer2", (object)dynamicParameters, "Tripsheer - VehicleStatusListUpdateInsert").FirstOrDefault<Response>();
        }


        public IEnumerable<FuelSlipDetail> GetFuelSlipDetail(
            long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<FuelSlipDetail>("Usp_Tripsheet_GetFuelSlipDetail", (object)dynamicParameters, "Tripsheet - FuelSlipDetail");
        }

        public IEnumerable<Tripsheet> GetAdvanceCancelTripsheetList(
         short locationId,
         DateTime fromDate,
         DateTime toDate,
         string tripsheetNos,
         string manualTripsheetNos, string voucherNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNos", (object)tripsheetNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualTripsheetNos", (object)manualTripsheetNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VoucherNo", (object)voucherNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Tripsheet>("Usp_Tripsheet_GetAdvanceCancelTripsheetList", (object)dynamicParameters, "Tripsheet - GetAdvanceCancelTripsheetList");
        }

        public IEnumerable<TripsheetAdvance> GetAdvanceCancelDriverAdvanceList(long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetAdvance>("Usp_Tripsheet_GetAdvanceCancelDriverAdvanceList", (object)dynamicParameters, "Tripsheet - GetAdvanceCancelDriverAdvanceList");
        }

        public Response AdvanceCancellation(TripsheetAdvanceCancellation tripsheetAdvanceCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetAdvanceCancellation.TripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VoucherId", (object)tripsheetAdvanceCancellation.VoucherId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelDate", (object)tripsheetAdvanceCancellation.CancelDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelBy", (object)tripsheetAdvanceCancellation.CancelBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelReason", (object)tripsheetAdvanceCancellation.CancelReason, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_DriverAdvanceCancellation", (object)dynamicParameters, "Cancel Tripsheet Driver Advance").FirstOrDefault<Response>();
        }
        public DocketListByTripsheetApi GetDocketListByTripsheet(string tripsheetNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            List<DocketListByTripsheetApiResponse> DocketListByTripsheetApiResponseList = new List<DocketListByTripsheetApiResponse>();
            DocketListByTripsheetApiResponseList = DataBaseFactory.QuerySP<DocketListByTripsheetApiResponse>("Usp_GetDocketListByTripsheetNo", dynamicParameters, module: "Tripsheet - GetDocketListByTripsheet").ToList();
            DocketListByTripsheetApi docketListByTripsheetApiResponse = new DocketListByTripsheetApi();
            if (DocketListByTripsheetApiResponseList.Count() > 0)
            {
                docketListByTripsheetApiResponse.IsSuccess = true;
                docketListByTripsheetApiResponse.Message = "Docket Details Successfully Fetched.";
                docketListByTripsheetApiResponse.TripsheetDocketDetails = DocketListByTripsheetApiResponseList;

                foreach (var docketDetail in docketListByTripsheetApiResponse.TripsheetDocketDetails)
                {
                    DocketCarton docketCarton = new DocketCarton();
                    dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    dynamicParameters.Add("@DocketId", (object)docketDetail.DocketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    docketDetail.DocketCartonList = DataBaseFactory.QuerySP<DocketCarton>("Usp_GetCartonNoListByTripsheetNo", dynamicParameters, module: "Tripsheet - GetDocketListByTripsheet").ToList();
                }
            }
            else
            {
                docketListByTripsheetApiResponse.IsSuccess = false;
                docketListByTripsheetApiResponse.Message = "Invalid Tripsheet No.";
            }
            return docketListByTripsheetApiResponse;

        }

        public DocketCartonListByTripsheetResponse GetDocketCartonListByTripsheet(string tripsheetNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            List<TripsheetDocketCarton> tripsheetDocketCartonList = new List<TripsheetDocketCarton>();
            tripsheetDocketCartonList = DataBaseFactory.QuerySP<TripsheetDocketCarton>("Usp_GetDocketCartonListByTripsheetNo", dynamicParameters, module: "Tripsheet - GetDocketCartonListByTripsheet").ToList();
            DocketCartonListByTripsheetResponse docketCartonListByTripsheetResponse = new DocketCartonListByTripsheetResponse();
            if (tripsheetDocketCartonList.Count() > 0)
            {
                docketCartonListByTripsheetResponse.IsSuccess = true;
                docketCartonListByTripsheetResponse.Message = "Docket Details Successfully Fetched.";
                docketCartonListByTripsheetResponse.TripsheetDocketCartonList = tripsheetDocketCartonList;
            }
            else
            {
                docketCartonListByTripsheetResponse.IsSuccess = false;
                docketCartonListByTripsheetResponse.Message = "Invalid Tripsheet No.";
            }
            return docketCartonListByTripsheetResponse;
        }
        public ApiSubmitScanResponse SubmitScanDocket(ApiSubmitScanRequest apiSubmitScanRequest)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)apiSubmitScanRequest.DocketId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketSuffix", (object)apiSubmitScanRequest.DocketSuffix, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Response result = new Response();
            result = DataBaseFactory.QuerySP<Response>("Usp_SubmitScanDocket", dynamicParameters, module: "Tripsheet - SubmitScanDocket").FirstOrDefault();
            ApiSubmitScanResponse apiSubmitScanResponse = new ApiSubmitScanResponse();
            if (result.IsSuccessfull)
            {
                apiSubmitScanResponse.IsSuccess = true;
                apiSubmitScanResponse.Message = "Scan Successfullly.";
            }
            else
            {
                apiSubmitScanResponse.IsSuccess = false;
                apiSubmitScanResponse.Message = "Not Scanned.";
            }
            return apiSubmitScanResponse;

        }

        public ApiSubmitScanResponse SubmitScanDocketCarton(ApiSubmitScanRequest apiSubmitScanRequest)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)apiSubmitScanRequest.DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CartonNo", (object)apiSubmitScanRequest.CartonNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Response result = new Response();
            result = DataBaseFactory.QuerySP<Response>("Usp_SubmitScanDocketCarton", dynamicParameters, module: "Tripsheet - SubmitScanDocket").FirstOrDefault();
            ApiSubmitScanResponse apiSubmitScanResponse = new ApiSubmitScanResponse();
            if (result.IsSuccessfull)
            {
                apiSubmitScanResponse.IsSuccess = true;
                apiSubmitScanResponse.Message = "Scan Successfullly.";
            }
            else
            {
                apiSubmitScanResponse.IsSuccess = false;
                apiSubmitScanResponse.Message = "Not Scanned.";
            }
            return apiSubmitScanResponse;

        }

        public IEnumerable<TripsheetSettlementCancellation> GetTripsheetListForTripsheetSettlementCancellation(
  byte searchBy,
  string tripsheetNo,
  DateTime fromDate,
  DateTime toDate,
   byte tripsheetAction,
  DateTime finStartDate,
  DateTime finEndDate,
  short locationId)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SearchBy", (object)searchBy, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetAction", (object)tripsheetAction, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetSettlementCancellation>("Usp_Tripsheet_GetTripsheetListForTripsheetSettlementCancellation", (object)dynamicParameters, "Tripsheet - GetTripsheetListForTripsheetSettlementCancellation");
        }
        public Response TripsheetSettlementCancellation(TripsheetSettlementCancellation objTripsheetSettlementCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripsheetSettlementCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_TripsheetSettlementCancellation", (object)dynamicParameters, "Tripsheet - TripsheetSettlementCancellation").FirstOrDefault<Response>();
        }

        public IEnumerable<TripsheetSettlementCancellation> GetTripsheetListForTripsheetFuelSlipCancellation(
  byte searchBy,
  string tripsheetNo,
  DateTime fromDate,
  DateTime toDate,
  DateTime finStartDate,
  DateTime finEndDate,
  short locationId)
        {
            if (toDate > DateTime.Now)
                toDate = DateTime.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SearchBy", (object)searchBy, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)tripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripsheetSettlementCancellation>("Usp_Tripsheet_GetTripsheetListForFuelSlipCancellation", (object)dynamicParameters, "Tripsheet - GetTripsheetListForFuelSlipCancellation");
        }

        public IEnumerable<FuelSlipDetail> GetFuelSlipListForTripsheetFuelSlipCancellation(long tripsheetId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetId", (object)tripsheetId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<FuelSlipDetail>("Usp_Tripsheet_GetFuelSlipListForTripsheetFuelSlipCancellation", (object)dynamicParameters, "Tripsheet - GetFuelSlipListForTripsheetFuelSlipCancellation");
        }

        public Response TripsheetFuelSlipCancellation(FuelSlip objFuelSlip)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objFuelSlip), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelBy", (object)objFuelSlip.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Tripsheet_TripsheetFuelSlipCancellation", (object)dynamicParameters, "Tripsheet - TripsheetFuelSlipCancellation").FirstOrDefault<Response>();
        }
    }
}