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
    public class ThcRepository : BaseRepository, IThcRepository, IDisposable
    {
        public void ChangeDocketAmount(Docket objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_UpdateDocketAmount", (object)dynamicParameters, "Docket - Update");
        }

        public void DocketUpdate(Docket objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Docket_UpdateDocket", (object)dynamicParameters, "Thc - Update");
        }

        public void ThcUpdate(Thc objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Thc_UpdateDocket", (object)dynamicParameters, "Thc - Update");
        }

        public Response Insert(Thc objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Thc_Insert", (object)dynamicParameters, "Thc - Insert").FirstOrDefault<Response>();
        }

        public Response Update(Thc objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Thc_Update", (object)dynamicParameters, "Thc - Update").FirstOrDefault<Response>();
        }

        public Response InsertTrispeed(ThcTrispeed objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThcTrispeed", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_ThcTrispeed_Insert", (object)dynamicParameters, "ThcTrispeed - Insert").FirstOrDefault<Response>();
        }

        public Response UpdateTrispeed(ThcTrispeed objThc)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThcTrispeed", (object)XmlUtility.XmlSerializeToString((object)objThc), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_ThcTrispeed_Update", (object)dynamicParameters, "ThcTrispeed - Update").FirstOrDefault<Response>();
        }



        public List<AutoCompleteResult> GetArrivalConditionList()
        {
            return new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "In Damage Condition"
        },
        new AutoCompleteResult()
        {
          Value = "2",
          Name = "In Good Condition"
        }
      };
        }

        public List<AutoCompleteResult> GetDeliveryProcessList()
        {
            return new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "Delivery by DRS"
        },
        new AutoCompleteResult()
        {
          Value = "2",
          Name = "Delivery on Arrival"
        },
        new AutoCompleteResult()
        {
          Value = "3",
          Name = "Delivery by Gatepass"
        },
        new AutoCompleteResult()
        {
          Value = "4",
          Name = "Delivery to Warehouse"
        }
      };
        }

        public List<AutoCompleteResult> GetLateDeliveryReasonList()
        {
            return new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "Premises Lock"
        },
        new AutoCompleteResult()
        {
          Value = "2",
          Name = "Vehicle get Accident"
        }
      };
        }

        public ThcCharges GetChargeList(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return new ThcCharges()
            {
                OtherChargeList = DataBaseFactory.QuerySP<MasterCharge>("Usp_Thc_GetChargeList", (object)dynamicParameters, "Thc - GetChargesList")
            };
        }

        public IEnumerable<ThcManifestDetail> GetManifestList(
          DateTime fromDate,
          DateTime toDate,
          byte transportModeId,
          short routeId,
          short fromLocationId,
          short toLocationId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteId", (object)routeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)toLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcManifestDetail>("Usp_Thc_GetManifestList", (object)dynamicParameters, "Thc - GetManifestList");
        }

        public IEnumerable<ThcManifestDetail> GetManifestListForUpdateThc(
          long thcId,
          DateTime fromDate,
          DateTime toDate,
          byte transportModeId,
          short routeId,
          short fromLocationId,
          short toLocationId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteId", (object)routeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromLocationId", (object)fromLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToLocationId", (object)toLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcManifestDetail>("Usp_Thc_GetManifestListForUpdateThc", (object)dynamicParameters, "Thc - GetManifestListForUpdateThc");
        }

        public IEnumerable<ThcManifestDetail> GetManifestListByThcId(
          long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcManifestDetail>("Usp_Thc_GetManifestListByThcId", (object)dynamicParameters, "Thc - GetManifestListByThcId");
        }

        public IEnumerable<FinanceSummary> GetDocumentListForUpdate(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string documentNo,
          string manualDocumentNo,
          byte documentTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentNos", (object)documentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualDocumentNos", (object)manualDocumentNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentTypeId", (object)documentTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return (IEnumerable<FinanceSummary>)DataBaseFactory.QuerySP<FinanceSummary>("Usp_Thc_GetDocumentListForUpdate", (object)dynamicParameters, "Thc - GetDocumentListForUpdate").ToList<FinanceSummary>();
        }

        public Thc GetStep1DetailById(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetStep1DetailById", (object)dynamicParameters, "Thc - GetStep1DetailById").FirstOrDefault<Thc>();
        }

        public Thc GetStep2DetailById(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetStep2DetailById", (object)dynamicParameters, "Thc - GetStep2DetailById").FirstOrDefault<Thc>();
        }

        public Thc GetStep3DetailById(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetStep3DetailById", (object)dynamicParameters, "Thc - GetStep3DetailById").FirstOrDefault<Thc>();
        }

        public Thc GetStep4DetailById(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetStep4DetailById", (object)dynamicParameters, "Thc - GetStep4DetailById").FirstOrDefault<Thc>();
        }

        public Thc GetStep5DetailById(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetStep5DetailById", (object)dynamicParameters, "Thc - GetStep5DetailById").FirstOrDefault<Thc>();
        }

        public Thc GetStep6DetailById(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetStep6DetailById", (object)dynamicParameters, "Thc - GetStep6DetailById").FirstOrDefault<Thc>();
        }

        public AutoCompleteResult CheckValidThcCode(string thcNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcNo", (object)thcNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Thc_CheckValidThcCode", (object)dynamicParameters, "Thc - CheckValidThcCode").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<Thc> GetThcListForVehicleArrival(
          string thcNos,
          DateTime fromDate,
          DateTime toDate,
          string vehicleNos,
          string docketNos,
          string arrivalLocations,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleNos", (object)vehicleNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ArrivalLocations", (object)arrivalLocations, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            IEnumerable<Thc> source = DataBaseFactory.QuerySP<Thc>("Usp_VehicleArrival_GetThcList", (object)dynamicParameters, "VehicleArrival - GetThcListForVehicleArrival");
            List<Thc> thcList = new List<Thc>();
            List<Thc> list = source.ToList<Thc>();
            foreach (Thc thc in list)
            {
                thc.ThcSummary = new ThcSummary();
                thc.ThcSummary.ThcDate = thc.ThcDateTime;
                thc.ThcSummary.StartKm = thc.StartKm;
                thc.ThcSummary.OutgoingSealNo = thc.OutgoingSealNo;
                thc.ThcSummary.TotalActualWeight = thc.TotalActualWeight;
                thc.ThcSummary.TotalDocket = thc.TotalDocket;
                thc.ThcSummary.TotalPackages = thc.Packages;
            }
            return (IEnumerable<Thc>)list;
        }

        public Response VehicleArrival(ThcSummary objThcSummary)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVehicleArrival", (object)XmlUtility.XmlSerializeToString((object)objThcSummary), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_VehicleArrival_Insert", (object)dynamicParameters, "VehicleArrival - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<Thc> GetThcListForStockUpdate(
          string thcNos,
          DateTime fromDate,
          DateTime toDate,
          string vehicleNos,
          string docketNos,
          string arrivalLocations,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleNos", (object)vehicleNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ArrivalLocations", (object)arrivalLocations, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_StockUpdate_GetThcList", (object)dynamicParameters, "StockUpdate - GetThcListForStockUpdate");
        }

        public ThcSummary GetThcDetailsForStockUpdate(long thcId, short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcSummary>("Usp_StockUpdate_GetThcDetail", (object)dynamicParameters, "StockUpdate - GetThcDetailsForStockUpdate").FirstOrDefault<ThcSummary>();
        }

        public IEnumerable<StockUpdateDocket> GetThcDocketListForStockUpdate(
          long thcId,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<StockUpdateDocket>("Usp_StockUpdate_GetThcDocketList", (object)dynamicParameters, "StockUpdate - GetThcDocketListForStockUpdate");
        }

        public Response StockUpdate(ThcSummary objThcSummary)
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            dynamicParameters1.Add("@XmlStockUpdate", (object)XmlUtility.XmlSerializeToString((object)objThcSummary), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Response response1 = DataBaseFactory.QuerySP<Response>("Usp_StockUpdate_Insert", (object)dynamicParameters1, "StockUpdateV2 - Insert").FirstOrDefault<Response>();

            int num1 = objThcSummary.ManifestList.Sum<StockUpdateDocket>((Func<StockUpdateDocket, int>)(m => m.DepsDetails.ShortPackages));
            int num2 = objThcSummary.ManifestList.Sum<StockUpdateDocket>((Func<StockUpdateDocket, int>)(m => m.DepsDetails.ExtraPackages));
            int num3 = objThcSummary.ManifestList.Sum<StockUpdateDocket>((Func<StockUpdateDocket, int>)(m => m.DepsDetails.PilferPackages));
            int num4 = objThcSummary.ManifestList.Sum<StockUpdateDocket>((Func<StockUpdateDocket, int>)(m => m.DepsDetails.DamagePackages));
            if (num1 + num2 + num3 + num4 > 0)
            {
                long num5 = 0;
                string str1 = string.Empty;
                long num6 = 0;
                if (num1 > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objThcSummary.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)1;
                    DynamicParameters dynamicParameters2 = new DynamicParameters();
                    dynamicParameters2.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response2 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters2, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response2.DocumentId;
                    str1 = response2.DocumentNo;
                    foreach (StockUpdateDocket stockUpdateDocket in objThcSummary.ManifestList.Where<StockUpdateDocket>((Func<StockUpdateDocket, bool>)(m => m.DepsDetails.ShortPackages > 0)))
                    {
                        DepsDocket depsDocket = new DepsDocket();
                        if (num5 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters3, "DEPS - GetMaxDepsDocketId");
                            num5 = dynamicParameters3.Get<long>("@DepsDocketId");
                        }
                        else
                            ++num5;
                        string str2 = string.Empty;
                        depsDocket.DepsDocketId = num5;
                        depsDocket.DepsId = documentId;
                        depsDocket.DocketId = stockUpdateDocket.DocketId;
                        depsDocket.DocketSuffix = stockUpdateDocket.DocketSuffix;
                        depsDocket.Packages = stockUpdateDocket.DepsDetails.ShortPackages;
                        depsDocket.ReasonId = stockUpdateDocket.DepsDetails.ShortPackagesReasonId;
                        depsDocket.Remark = stockUpdateDocket.DepsDetails.ShortRemark.ConvertToString();
                        depsDocket.DocumentName = stockUpdateDocket.DepsDetails.ShortDocumentName;
                        depsDocket.DepsStatus = (byte)1;
                        DepsHistory depsHistory = new DepsHistory();
                        if (num6 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters3, "DEPS - GetMaxHistoryId");
                            num6 = dynamicParameters3.Get<long>("@HistoryId");
                        }
                        else
                            ++num6;
                        depsHistory.HistoryId = num6;
                        depsHistory.DepsDocketId = num5;
                        depsHistory.LocationId = deps.LocationId;
                        depsHistory.FoundPackages = (byte)0;
                        depsHistory.Remark = "Generated";
                        depsHistory.EntryBy = deps.EntryBy;
                        depsHistory.Packages = stockUpdateDocket.DepsDetails.ShortPackages;
                        depsDocket.History = depsHistory;
                        DynamicParameters dynamicParameters4 = new DynamicParameters();
                        dynamicParameters4.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                        num5 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters4, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                        if (stockUpdateDocket.DepsDetails.ShortDocumentAttachment != null)
                            str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num5.ToString(), SessionUtility.LoginLocationCode, stockUpdateDocket.DepsDetails.ShortDocumentAttachment.FileName) : num5.ToString() + "_" + stockUpdateDocket.DepsDetails.ShortDocumentAttachment.FileName;
                        stockUpdateDocket.DepsDetails.ShortDocumentName = str2;
                        if (stockUpdateDocket.DepsDetails.ShortDocumentName != "")
                        {
                            if (ConfigHelper.IsLocalStorage)
                            {
                                string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                                stockUpdateDocket.DepsDetails.ShortDocumentAttachment.SaveAs(filename);
                            }
                            else
                                AzureStorageHelper.UploadBlob("DEPS", stockUpdateDocket.DepsDetails.ShortDocumentAttachment, str2, str2);
                        }
                    }
                }
                if (num2 > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objThcSummary.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)2;
                    DynamicParameters dynamicParameters2 = new DynamicParameters();
                    dynamicParameters2.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response2 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters2, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response2.DocumentId;
                    str1 = response2.DocumentNo;
                    foreach (StockUpdateDocket stockUpdateDocket in objThcSummary.ManifestList.Where<StockUpdateDocket>((Func<StockUpdateDocket, bool>)(m => m.DepsDetails.ExtraPackages > 0)))
                    {
                        DepsDocket depsDocket = new DepsDocket();
                        if (num5 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters2, "DEPS - GetMaxDepsDocketId");
                            num5 = dynamicParameters3.Get<long>("@DepsDocketId");
                        }
                        else
                            ++num5;
                        string str2 = string.Empty;
                        depsDocket.DepsDocketId = num5;
                        depsDocket.DepsId = documentId;
                        depsDocket.DocketId = stockUpdateDocket.DocketId;
                        depsDocket.DocketSuffix = stockUpdateDocket.DocketSuffix;
                        depsDocket.Packages = stockUpdateDocket.DepsDetails.ExtraPackages;
                        depsDocket.ReasonId = stockUpdateDocket.DepsDetails.ExtraPackagesReasonId;
                        depsDocket.Remark = stockUpdateDocket.DepsDetails.ExtraRemark.ConvertToString();
                        depsDocket.DocumentName = stockUpdateDocket.DepsDetails.ExtraDocumentName;
                        depsDocket.DepsStatus = (byte)1;
                        DepsHistory depsHistory = new DepsHistory();
                        if (num6 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters2, "DEPS - GetMaxHistoryId");
                            num6 = dynamicParameters3.Get<long>("@HistoryId");
                        }
                        else
                            ++num6;
                        depsHistory.HistoryId = num6;
                        depsHistory.DepsDocketId = num5;
                        depsHistory.LocationId = deps.LocationId;
                        depsHistory.FoundPackages = (byte)0;
                        depsHistory.Remark = "Generated";
                        depsHistory.EntryBy = deps.EntryBy;
                        depsHistory.Packages = stockUpdateDocket.DepsDetails.ExtraPackages;
                        depsDocket.History = depsHistory;
                        dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                        num5 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters2, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                        if (stockUpdateDocket.DepsDetails.ExtraDocumentAttachment != null)
                            str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num5.ToString(), SessionUtility.LoginLocationCode, stockUpdateDocket.DepsDetails.ExtraDocumentAttachment.FileName) : num5.ToString() + "_" + stockUpdateDocket.DepsDetails.ExtraDocumentAttachment.FileName;
                        stockUpdateDocket.DepsDetails.ExtraDocumentName = str2;
                        if (stockUpdateDocket.DepsDetails.ExtraDocumentName != "")
                        {
                            if (ConfigHelper.IsLocalStorage)
                            {
                                string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                                stockUpdateDocket.DepsDetails.ExtraDocumentAttachment.SaveAs(filename);
                            }
                            else
                                AzureStorageHelper.UploadBlob("DEPS", stockUpdateDocket.DepsDetails.ExtraDocumentAttachment, str2, str2);
                        }
                    }
                }
                if (num3 > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objThcSummary.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)3;
                    DynamicParameters dynamicParameters2 = new DynamicParameters();
                    dynamicParameters2.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response2 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters2, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response2.DocumentId;
                    str1 = response2.DocumentNo;
                    foreach (StockUpdateDocket stockUpdateDocket in objThcSummary.ManifestList.Where<StockUpdateDocket>((Func<StockUpdateDocket, bool>)(m => m.DepsDetails.PilferPackages > 0)))
                    {
                        DepsDocket depsDocket = new DepsDocket();
                        if (num5 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters3, "DEPS - GetMaxDepsDocketId");
                            num5 = dynamicParameters3.Get<long>("@DepsDocketId");
                        }
                        else
                            ++num5;
                        string str2 = string.Empty;
                        depsDocket.DepsDocketId = num5;
                        depsDocket.DepsId = documentId;
                        depsDocket.DocketId = stockUpdateDocket.DocketId;
                        depsDocket.DocketSuffix = stockUpdateDocket.DocketSuffix;
                        depsDocket.Packages = stockUpdateDocket.DepsDetails.PilferPackages;
                        depsDocket.ReasonId = stockUpdateDocket.DepsDetails.PilferPackagesReasonId;
                        depsDocket.Remark = stockUpdateDocket.DepsDetails.PilferRemark.ConvertToString();
                        depsDocket.DocumentName = stockUpdateDocket.DepsDetails.PilferDocumentName;
                        depsDocket.DepsStatus = (byte)1;
                        DepsHistory depsHistory = new DepsHistory();
                        if (num6 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters3, "DEPS - GetMaxHistoryId");
                            num6 = dynamicParameters3.Get<long>("@HistoryId");
                        }
                        else
                            ++num6;
                        depsHistory.HistoryId = num6;
                        depsHistory.DepsDocketId = num5;
                        depsHistory.LocationId = deps.LocationId;
                        depsHistory.FoundPackages = (byte)0;
                        depsHistory.Remark = "Generated";
                        depsHistory.EntryBy = deps.EntryBy;
                        depsHistory.Packages = stockUpdateDocket.DepsDetails.PilferPackages;
                        depsDocket.History = depsHistory;
                        DynamicParameters dynamicParameters4 = new DynamicParameters();
                        dynamicParameters4.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                        num5 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters4, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                        if (stockUpdateDocket.DepsDetails.PilferDocumentAttachment != null)
                            str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num5.ToString(), SessionUtility.LoginLocationCode, stockUpdateDocket.DepsDetails.PilferDocumentAttachment.FileName) : num5.ToString() + "_" + stockUpdateDocket.DepsDetails.PilferDocumentAttachment.FileName;
                        stockUpdateDocket.DepsDetails.PilferDocumentName = str2;
                        if (stockUpdateDocket.DepsDetails.PilferDocumentName != "")
                        {
                            if (ConfigHelper.IsLocalStorage)
                            {
                                string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                                stockUpdateDocket.DepsDetails.PilferDocumentAttachment.SaveAs(filename);
                            }
                            else
                                AzureStorageHelper.UploadBlob("DEPS", stockUpdateDocket.DepsDetails.PilferDocumentAttachment, str2, str2);
                        }
                    }
                }
                if (num4 > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objThcSummary.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)4;
                    DynamicParameters dynamicParameters2 = new DynamicParameters();
                    dynamicParameters2.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response2 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters2, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response2.DocumentId;
                    str1 = response2.DocumentNo;
                    foreach (StockUpdateDocket stockUpdateDocket in objThcSummary.ManifestList.Where<StockUpdateDocket>((Func<StockUpdateDocket, bool>)(m => m.DepsDetails.DamagePackages > 0)))
                    {
                        DepsDocket depsDocket = new DepsDocket();
                        if (num5 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters3, "DEPS - GetMaxDepsDocketId");
                            num5 = dynamicParameters3.Get<long>("@DepsDocketId");
                        }
                        else
                            ++num5;
                        string str2 = string.Empty;
                        depsDocket.DepsDocketId = num5;
                        depsDocket.DepsId = documentId;
                        depsDocket.DocketId = stockUpdateDocket.DocketId;
                        depsDocket.DocketSuffix = stockUpdateDocket.DocketSuffix;
                        depsDocket.Packages = stockUpdateDocket.DepsDetails.DamagePackages;
                        depsDocket.ReasonId = stockUpdateDocket.DepsDetails.DamagePackagesReasonId;
                        depsDocket.Remark = stockUpdateDocket.DepsDetails.DamageRemark.ConvertToString();
                        depsDocket.DocumentName = stockUpdateDocket.DepsDetails.DamageDocumentName;
                        depsDocket.DepsStatus = (byte)1;
                        DepsHistory depsHistory = new DepsHistory();
                        if (num6 == 0L)
                        {
                            DynamicParameters dynamicParameters3 = new DynamicParameters();
                            dynamicParameters3.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                            DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters3, "DEPS - GetMaxHistoryId");
                            num6 = dynamicParameters3.Get<long>("@HistoryId");
                        }
                        else
                            ++num6;
                        depsHistory.HistoryId = num6;
                        depsHistory.DepsDocketId = num5;
                        depsHistory.LocationId = deps.LocationId;
                        depsHistory.FoundPackages = (byte)0;
                        depsHistory.Remark = "Generated";
                        depsHistory.EntryBy = deps.EntryBy;
                        depsHistory.Packages = stockUpdateDocket.DepsDetails.DamagePackages;
                        depsDocket.History = depsHistory;
                        DynamicParameters dynamicParameters4 = new DynamicParameters();
                        dynamicParameters4.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                        num5 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters4, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                        if (stockUpdateDocket.DepsDetails.DamageDocumentAttachment != null)
                            str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num5.ToString(), SessionUtility.LoginLocationCode, stockUpdateDocket.DepsDetails.DamageDocumentAttachment.FileName) : num5.ToString() + "_" + stockUpdateDocket.DepsDetails.DamageDocumentAttachment.FileName;
                        stockUpdateDocket.DepsDetails.DamageDocumentName = str2;
                        if (stockUpdateDocket.DepsDetails.DamageDocumentName != "")
                        {
                            if (ConfigHelper.IsLocalStorage)
                            {
                                string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                                stockUpdateDocket.DepsDetails.DamageDocumentAttachment.SaveAs(filename);
                            }
                            else
                                AzureStorageHelper.UploadBlob("DEPS", stockUpdateDocket.DepsDetails.DamageDocumentAttachment, str2, str2);
                        }
                    }
                }
            }
            return response1;
        }

        public IEnumerable<DepsDocket> GetDepsListForStockUpdate(
          DateTime fromDate,
          DateTime toDate,
          string docketNo,
          string depsNo,
          short dateType,
          bool isUpdate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DepsNo", (object)depsNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DateType", (object)dateType, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsUpdate", (object)isUpdate, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DepsDocket>("Usp_Deps_GetDepsListForStockUpdate", (object)dynamicParameters, "Deps - GetDepsListForStockUpdate");
        }

        public Response DepsUpdate(ThcSummary objThcSummary)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDepsUpdate", (object)XmlUtility.XmlSerializeToString((object)objThcSummary), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DepsUpdate_Insert", (object)dynamicParameters, "DepsUpdate - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<DepsDocket> GetDepsHistory(long id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DepsDocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DepsDocket>("Usp_Deps_GetDepsHistory", (object)dynamicParameters, "DEPS History - GetDepsHistory");
        }

        public Deps GetDocketDetailsForDeps(string docketNo, long locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            Deps deps = new Deps();
            dynamicParameters.Add("@DocketNo", (object)docketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Deps>("Usp_Deps_GetDocketDetailsForDeps", (object)dynamicParameters, "Deps - GetDocketDetailsForDeps").FirstOrDefault<Deps>() ?? new Deps();
        }

        public Response DepsEntry(Deps objDeps)
        {
            if (objDeps.ShortPackages + objDeps.RejectPackages + objDeps.PilferPackages + objDeps.DamagePackages > 0)
            {
                long num1 = 0;
                string str1 = string.Empty;
                long num2 = 0;
                if (objDeps.ShortPackages > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objDeps.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)1;
                    DynamicParameters dynamicParameters1 = new DynamicParameters();
                    dynamicParameters1.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters1, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response.DocumentId;
                    str1 = response.DocumentNo;
                    long num3;
                    if (num1 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters2, "DEPS - GetMaxDepsDocketId");
                        num3 = dynamicParameters2.Get<long>("@DepsDocketId");
                    }
                    else
                        num3 = num1 + 1L;
                    DepsDocket depsDocket = new DepsDocket();
                    string str2 = string.Empty;
                    depsDocket.DepsDocketId = num3;
                    depsDocket.DepsId = documentId;
                    depsDocket.DocketId = objDeps.DocketId;
                    depsDocket.DocketSuffix = objDeps.DocketSuffix;
                    depsDocket.Packages = objDeps.ShortPackages;
                    depsDocket.ReasonId = objDeps.ShortPackagesReasonId;
                    depsDocket.Remark = objDeps.ShortRemark.ConvertToString();
                    depsDocket.DocumentName = objDeps.ShortDocumentName;
                    depsDocket.DepsStatus = (byte)1;
                    if (num2 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters2, "DEPS - GetMaxHistoryId");
                        num2 = dynamicParameters2.Get<long>("@HistoryId");
                    }
                    else
                        ++num2;
                    DepsHistory depsHistory = new DepsHistory();
                    depsHistory.HistoryId = num2;
                    depsHistory.DepsDocketId = num3;
                    depsHistory.LocationId = deps.LocationId;
                    depsHistory.FoundPackages = (byte)0;
                    depsHistory.Remark = "Generated";
                    depsHistory.EntryBy = deps.EntryBy;
                    depsHistory.Packages = objDeps.ShortPackages;
                    depsDocket.History = depsHistory;
                    DynamicParameters dynamicParameters3 = new DynamicParameters();
                    dynamicParameters3.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    num1 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters3, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                    if (objDeps.ShortDocumentAttachment != null)
                        str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num1.ToString(), SessionUtility.LoginLocationCode, objDeps.ShortDocumentAttachment.FileName) : num1.ToString() + "_" + objDeps.ShortDocumentAttachment.FileName;
                    objDeps.ShortDocumentName = str2;
                    if (objDeps.ShortDocumentName != "")
                    {
                        if (ConfigHelper.IsLocalStorage)
                        {
                            string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                            objDeps.ShortDocumentAttachment.SaveAs(filename);
                        }
                        else
                            AzureStorageHelper.UploadBlob("DEPS", objDeps.ShortDocumentAttachment, str2, str2);
                    }
                }
                if (objDeps.RejectPackages > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objDeps.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)5;
                    DynamicParameters dynamicParameters1 = new DynamicParameters();
                    dynamicParameters1.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters1, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response.DocumentId;
                    str1 = response.DocumentNo;
                    if (num1 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters2, "DEPS - GetMaxDepsDocketId");
                        num1 = dynamicParameters2.Get<long>("@DepsDocketId");
                    }
                    else
                        ++num1;
                    DepsDocket depsDocket = new DepsDocket();
                    string str2 = string.Empty;
                    depsDocket.DepsDocketId = num1;
                    depsDocket.DepsId = documentId;
                    depsDocket.DocketId = objDeps.DocketId;
                    depsDocket.DocketSuffix = objDeps.DocketSuffix;
                    depsDocket.Packages = objDeps.RejectPackages;
                    depsDocket.ReasonId = objDeps.RejectPackagesReasonId;
                    depsDocket.Remark = objDeps.RejectRemark.ConvertToString();
                    depsDocket.DocumentName = objDeps.RejectDocumentName;
                    depsDocket.DepsStatus = (byte)1;
                    if (num2 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters2, "DEPS - GetMaxHistoryId");
                        num2 = dynamicParameters2.Get<long>("@HistoryId");
                    }
                    else
                        ++num2;
                    DepsHistory depsHistory = new DepsHistory();
                    depsHistory.HistoryId = num2;
                    depsHistory.DepsDocketId = num1;
                    depsHistory.LocationId = deps.LocationId;
                    depsHistory.FoundPackages = (byte)0;
                    depsHistory.Remark = "Generated";
                    depsHistory.EntryBy = deps.EntryBy;
                    depsHistory.Packages = objDeps.RejectPackages;
                    depsDocket.History = depsHistory;
                    DynamicParameters dynamicParameters3 = new DynamicParameters();
                    dynamicParameters3.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    num1 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters3, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                    if (objDeps.RejectDocumentAttachment != null)
                        str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num1.ToString(), SessionUtility.LoginLocationCode, objDeps.RejectDocumentAttachment.FileName) : num1.ToString() + "_" + objDeps.RejectDocumentAttachment.FileName;
                    objDeps.RejectDocumentName = str2;
                    if (objDeps.RejectDocumentName != "")
                    {
                        if (ConfigHelper.IsLocalStorage)
                        {
                            string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                            objDeps.RejectDocumentAttachment.SaveAs(filename);
                        }
                        else
                            AzureStorageHelper.UploadBlob("DEPS", objDeps.RejectDocumentAttachment, str2, str2);
                    }
                }
                if (objDeps.PilferPackages > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objDeps.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)3;
                    DynamicParameters dynamicParameters1 = new DynamicParameters();
                    dynamicParameters1.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters1, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response.DocumentId;
                    str1 = response.DocumentNo;
                    if (num1 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters2, "DEPS - GetMaxDepsDocketId");
                        num1 = dynamicParameters2.Get<long>("@DepsDocketId");
                    }
                    else
                        ++num1;
                    DepsDocket depsDocket = new DepsDocket();
                    string str2 = string.Empty;
                    depsDocket.DepsDocketId = num1;
                    depsDocket.DepsId = documentId;
                    depsDocket.DocketId = objDeps.DocketId;
                    depsDocket.DocketSuffix = objDeps.DocketSuffix;
                    depsDocket.Packages = objDeps.PilferPackages;
                    depsDocket.ReasonId = objDeps.PilferPackagesReasonId;
                    depsDocket.Remark = objDeps.PilferRemark.ConvertToString();
                    depsDocket.DocumentName = objDeps.PilferDocumentName;
                    depsDocket.DepsStatus = (byte)1;
                    if (num2 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters2, "DEPS - GetMaxHistoryId");
                        num2 = dynamicParameters2.Get<long>("@HistoryId");
                    }
                    else
                        ++num2;
                    DepsHistory depsHistory = new DepsHistory();
                    depsHistory.HistoryId = num2;
                    depsHistory.DepsDocketId = num1;
                    depsHistory.LocationId = deps.LocationId;
                    depsHistory.FoundPackages = (byte)0;
                    depsHistory.Remark = "Generated";
                    depsHistory.EntryBy = deps.EntryBy;
                    depsHistory.Packages = objDeps.PilferPackages;
                    depsDocket.History = depsHistory;
                    DynamicParameters dynamicParameters3 = new DynamicParameters();
                    dynamicParameters3.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    num1 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters3, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                    if (objDeps.PilferDocumentAttachment != null)
                        str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num1.ToString(), SessionUtility.LoginLocationCode, objDeps.PilferDocumentAttachment.FileName) : num1.ToString() + "_" + objDeps.PilferDocumentAttachment.FileName;
                    objDeps.PilferDocumentName = str2;
                    if (objDeps.PilferDocumentName != "")
                    {
                        if (ConfigHelper.IsLocalStorage)
                        {
                            string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                            objDeps.PilferDocumentAttachment.SaveAs(filename);
                        }
                        else
                            AzureStorageHelper.UploadBlob("DEPS", objDeps.PilferDocumentAttachment, str2, str2);
                    }
                }
                if (objDeps.DamagePackages > 0)
                {
                    Deps deps = new Deps();
                    deps.ThcId = objDeps.ThcId;
                    deps.LocationId = SessionUtility.LoginLocationId;
                    deps.DepsDateTime = SessionUtility.Now;
                    deps.EntryBy = SessionUtility.LoginUserId;
                    deps.DepsType = (byte)4;
                    DynamicParameters dynamicParameters1 = new DynamicParameters();
                    dynamicParameters1.Add("@XmlDepsHeader", (object)XmlUtility.XmlSerializeToString((object)deps), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    Response response = DataBaseFactory.QuerySP<Response>("Usp_Deps_Header_Insert", (object)dynamicParameters1, "Deps Header - Insert").FirstOrDefault<Response>();
                    long documentId = response.DocumentId;
                    str1 = response.DocumentNo;
                    if (num1 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@DepsDocketId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_Detail_GetMaxDepsDocketId", (object)dynamicParameters2, "DEPS - GetMaxDepsDocketId");
                        num1 = dynamicParameters2.Get<long>("@DepsDocketId");
                    }
                    else
                        ++num1;
                    DepsDocket depsDocket = new DepsDocket();
                    string str2 = string.Empty;
                    depsDocket.DepsDocketId = num1;
                    depsDocket.DepsId = documentId;
                    depsDocket.DocketId = objDeps.DocketId;
                    depsDocket.DocketSuffix = objDeps.DocketSuffix;
                    depsDocket.Packages = objDeps.DamagePackages;
                    depsDocket.ReasonId = objDeps.DamagePackagesReasonId;
                    depsDocket.Remark = objDeps.PilferRemark.ConvertToString();
                    depsDocket.DocumentName = objDeps.DamageDocumentName;
                    depsDocket.DepsStatus = (byte)1;
                    long num3;
                    if (num2 == 0L)
                    {
                        DynamicParameters dynamicParameters2 = new DynamicParameters();
                        dynamicParameters2.Add("@HistoryId", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
                        DataBaseFactory.QuerySP("Usp_Deps_History_GetMaxHistoryId", (object)dynamicParameters2, "DEPS - GetMaxHistoryId");
                        num3 = dynamicParameters2.Get<long>("@HistoryId");
                    }
                    else
                        num3 = num2 + 1L;
                    DepsHistory depsHistory = new DepsHistory();
                    depsHistory.HistoryId = num3;
                    depsHistory.DepsDocketId = num1;
                    depsHistory.LocationId = deps.LocationId;
                    depsHistory.FoundPackages = (byte)0;
                    depsHistory.Remark = "Generated";
                    depsHistory.EntryBy = deps.EntryBy;
                    depsHistory.Packages = objDeps.DamagePackages;
                    depsDocket.History = depsHistory;
                    DynamicParameters dynamicParameters3 = new DynamicParameters();
                    dynamicParameters3.Add("@XmlDepsDetail", (object)XmlUtility.XmlSerializeToString((object)depsDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                    num1 = DataBaseFactory.QuerySP<Response>("Usp_Deps_Detail_Insert", (object)dynamicParameters3, "Deps Detail - Insert").FirstOrDefault<Response>().DocumentId;
                    if (objDeps.DamageDocumentAttachment != null)
                        str2 = !ConfigHelper.IsLocalStorage ? AzureStorageHelper.GetFileName("DEPS", "DEPS", num1.ToString(), SessionUtility.LoginLocationCode, objDeps.DamageDocumentAttachment.FileName) : num1.ToString() + "_" + objDeps.DamageDocumentAttachment.FileName;
                    objDeps.DamageDocumentName = str2;
                    if (objDeps.DamageDocumentName != "")
                    {
                        if (ConfigHelper.IsLocalStorage)
                        {
                            string filename = ConfigHelper.LocalStoragePath + "DEPS/" + str2;
                            objDeps.DamageDocumentAttachment.SaveAs(filename);
                        }
                        else
                            AzureStorageHelper.UploadBlob("DEPS", objDeps.DamageDocumentAttachment, str2, str2);
                    }
                }
            }
            Response response1 = new Response();
            response1.IsSuccessfull = true;
            response1.DocumentId = objDeps.DocketId;
            response1.DocumentNo = objDeps.DocketNo;
            return response1;
        }

        public Response ThcDeparture(Departure objThcDeparture)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThcDeparture", (object)XmlUtility.XmlSerializeToString((object)objThcDeparture), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_ThcDeparture_Insert", (object)dynamicParameters, "THC Departure - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<Thc> GetThcListForThcDeparture(
          string thcNos,
          DateTime fromDate,
          DateTime toDate,
          string manifestNos,
          string vehicleNos,
          string docketNos,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManifestNos", (object)manifestNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleNos", (object)vehicleNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_ThcDeparture_GetThcList", (object)dynamicParameters, "THC Departure - GetThcListForThcDeparture");
        }

        public Departure GetThcDetailForThcDeparture(long thcId, short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Departure>, IEnumerable<ThcManifestDetail>> tuple = DataBaseFactory.QueryMultipleSP<Departure, ThcManifestDetail>("Usp_ThcDeparture_GetThcDetail", (object)dynamicParameters, "THC Departure - GetThcDetailForThcDeparture");
            Departure departure1 = new Departure();
            if (tuple == null)
                return departure1;
            Departure departure2 = tuple.Item1.FirstOrDefault<Departure>();
            departure2.ThcDepartureManifestList = tuple.Item2.ToList<ThcManifestDetail>();
            return departure2;
        }

        public IEnumerable<UnloadingDocket> GetUnloadingDocketList(
          string thcNos,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<UnloadingDocket>("Usp_Unloading_GetDocketList", (object)dynamicParameters, "Unloading - GetUnloadingDocketList");
        }

        public Response Unloading(Unloading objUnloading)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlUnloading", (object)XmlUtility.XmlSerializeToString((object)objUnloading), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Unloading_Insert", (object)dynamicParameters, "Unloading - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<Thc> GetThcListForCancellation(
          string thcNos,
          string manualThcNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualThcNos", (object)manualThcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetThcListForCancellation", (object)dynamicParameters, "Thc - GetThcListForCancellation");
        }

        public void Cancellation(ThcCancellation objThcCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThcCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Thc_Cancellation", (object)dynamicParameters, "Thc - Cancel");
        }

        public IEnumerable<DispatchDocketDetail> GetDispatchDocketList(
          short locationId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DispatchDocketDetail>("Usp_Thc_GetDispatchDocketList", (object)dynamicParameters, "THC - GetDispatchDocketList");
        }

        public Response DispatchInsert(DocketDispatch objDocketDispatch)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketDispatch", (object)XmlUtility.XmlSerializeToString((object)objDocketDispatch), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_Docket_Dispatch_Insert", (object)dynamicParameters, "THC - DispatchInsert").FirstOrDefault<Response>();
        }

        public IEnumerable<DepsDocket> GetDepsDocketHistory(long id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DepsDocket>("Usp_Deps_GetDepsHistoryForDocket", (object)dynamicParameters, "DEPS History - GetDepsHistory");
        }
        public IEnumerable<StockUpdateDocket> GetThcDocketListForStockUpdateByManifest(
      long thcId,
      short locationId,
      string manifestId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManifestId", (object)manifestId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<StockUpdateDocket>("Usp_StockUpdate_GetThcDocketListByManifest", (object)dynamicParameters, "StockUpdate - GetThcDocketListForStockUpdate");
        }
        public IEnumerable<ThcManifestDetail> GetManifestListByThcIdForStockUpdate(
      long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcManifestDetail>("Usp_Thc_GetManifestListByThcIdForStockUpdate", (object)dynamicParameters, "Thc - GetManifestListByThcIdForStockUpdate");
        }
        public bool CheckBillIsMade(long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsBill", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Thc_CheckBillIsMade", (object)dynamicParameters, "THC - CheckBillIsMade");
            return dynamicParameters.Get<bool>("@IsBill");
        }
        public IEnumerable<Thc> GetThcListForStockUpdateCancellation(
        string thcNos,
       DateTime fromDate,
        DateTime toDate,
       short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetThcListForStockUpdateCancellation", (object)dynamicParameters, "Thc - GetThcListForStockUpdateCancellation");
        }
        public Response ThcStockUpdateCancellation(
            long thcId,
            string cancelReason,
            DateTime cancelDate,
            short cancelBy,
            short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelReason", (object)cancelReason, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelDate", (object)cancelDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CancelBy", (object)cancelBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_StockUpdate_Close_Cancellation", (object)dynamicParameters, "Thc - ThcStockUpdateCancellation").FirstOrDefault<Response>();
        }
        public IEnumerable<ThcAdvBalPaymnt_Details> GetMultiAdvanceDetail(
         long thcId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ThcId", (object)thcId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ThcAdvBalPaymnt_Details>("Usp_Thc_GetMultiAdvanceDetail", (object)dynamicParameters, "Thc - GetMultiAdvanceDetail");
        }

        public IEnumerable<Thc> GetThcListForVehicleArrivalCancellation(
          string thcNos,
          string manualThcNos,
          DateTime fromDate,
          DateTime toDate,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualThcNos", (object)manualThcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ThcNos", (object)thcNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Thc>("Usp_Thc_GetThcListForVehicleArrivalCancellation", (object)dynamicParameters, "Thc - GetThcListForVehicleArrivalCancellation");
        }

        public void VehicleArrivalCancellation(ThcCancellation objThcCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlThc", (object)XmlUtility.XmlSerializeToString((object)objThcCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Thc_VehicleArrivalCancellation", (object)dynamicParameters, "Thc - Vehicle Arrival Cancel");
        }
    }

}
