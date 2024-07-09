//  
// Type: CodeLock.Areas.Operation.Repository.PrsRepository
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

namespace CodeLock.Areas.Operation.Repository
{
    public class PrsRepository : BaseRepository, IPrsRepository, IDisposable
    {
        public Prs GetDocketList(
          string docketNos,
          DateTime fromDate,
          DateTime toDate,
          byte paybasId,
          byte transportModeId,
          byte businessTypeId,
          string isBookedByBa,
          short bookedById,
          short locationId,
          byte companyId,
          bool isPickupThroughSameVehicle)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)businessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBookedByBa", (object)isBookedByBa, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BookedById", (object)bookedById, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsPickupThroughSameVehicle", (object)isPickupThroughSameVehicle, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Prs obj = new Prs();
            Tuple<IEnumerable<PrsDocket>, IEnumerable<PrsDocket>> tuple = DataBaseFactory.QueryMultipleSP<PrsDocket, PrsDocket>("Usp_Prs_GetDocketList", (object)dynamicParameters, "PRS - GetDocketList");

            obj.DocketList = tuple.Item1.ToList<PrsDocket>();
            if (tuple.Item2 != null)
            obj.ErrorList = tuple.Item2.ToList<PrsDocket>();

            return obj;


        }

        public IEnumerable<PrsDocket> GetDocketListForUpdatePrs(
      long prsId,
      string docketNos,
      DateTime fromDate,
      DateTime toDate,
      byte paybasId,
      byte transportModeId,
      byte businessTypeId,
      string isBookedByBa,
      short bookedById,
      short locationId,
      byte companyId,
      bool isPickupThroughSameVehicle)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BusinessTypeId", (object)businessTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBookedByBa", (object)isBookedByBa, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BookedById", (object)bookedById, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsPickupThroughSameVehicle", (object)isPickupThroughSameVehicle, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<PrsDocket>("Usp_Prs_GetDocketListForUpdatePrs", (object)dynamicParameters, "PRS - GetDocketListForUpdatePrs");
        }

        public PrsCharges GetChargeList(long prsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return new PrsCharges()
            {
                OtherChargeList = DataBaseFactory.QuerySP<MasterCharge>("Usp_Prs_GetChargeList", (object)dynamicParameters, "PRS - GetChargesList").ToList<MasterCharge>()
            };
        }

        public Response Insert(Prs objPrs)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlPrs", (object)XmlUtility.XmlSerializeToString((object)objPrs), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Prs_Insert", (object)dynamicParameters, "PRS - Insert").FirstOrDefault<Response>();
        }

        public Response Update(Prs objPrs)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlPrs", (object)XmlUtility.XmlSerializeToString((object)objPrs), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Prs_Update", (object)dynamicParameters, "PRS - Update").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetBookedByList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "0", Name = "Staff" },
        new AutoCompleteResult() { Value = "1", Name = "BA" }
      };
        }

        public AutoCompleteResult CheckValidPrsNo(string prsNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsNo", (object)prsNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Prs_CheckValidPrsNo", (object)dynamicParameters, "Prs - CheckValidPrsNo").FirstOrDefault<AutoCompleteResult>();
        }

        public Prs GetStep2DetailById(long prsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Prs>("Usp_Prs_GetStep2DetailById", (object)dynamicParameters, "Prs - GetStep2DetailById").FirstOrDefault<Prs>();
        }

        public Prs GetStep3DetailById(long prsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Prs>("Usp_Prs_GetStep3DetailById", (object)dynamicParameters, "Prs - GetStep3DetailById").FirstOrDefault<Prs>();
        }

        public Prs GetStep4DetailById(long prsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Prs>("Usp_Prs_GetStep4DetailById", (object)dynamicParameters, "Prs - GetStep4DetailById").FirstOrDefault<Prs>();
        }

        public Prs GetStep5DetailById(long prsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Prs>("Usp_Prs_GetStep5DetailById", (object)dynamicParameters, "Prs - GetStep5DetailById").FirstOrDefault<Prs>();
        }

        public Prs GetStep6DetailById(long prsId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PrsId", (object)prsId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Prs>("Usp_Prs_GetStep6DetailById", (object)dynamicParameters, "Prs - GetStep6DetailById").FirstOrDefault<Prs>();
        }

        public IEnumerable<Prs> GetPrsListForCancellation(
          string prsNos,
          string manualPrsNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualPrsNos", (object)manualPrsNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PrsNos", (object)prsNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Prs>("Usp_Prs_GetPrsListForCancellation", (object)dynamicParameters, "Prs - GetPrsListForCancellation");
        }

        public void Cancellation(PrsCancellation objPrsCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlPrs", (object)XmlUtility.XmlSerializeToString((object)objPrsCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Prs_Cancellation", (object)dynamicParameters, "Prs - Cancel");
        }
    }
}
