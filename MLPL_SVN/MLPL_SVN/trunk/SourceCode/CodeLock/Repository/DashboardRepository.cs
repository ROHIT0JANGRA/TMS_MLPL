//  
// Type: CodeLock.Repository.DashboardRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace CodeLock.Repository
{
  public class DashboardRepository : BaseRepository, IDashboardRepository, IDisposable
  {
        public ChartDetail GetAll(byte companyId, short LocationId, short UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<ChartDetail>("Usp_GetTotal", (object)dynamicParameters, "GetTotal").FirstOrDefault<ChartDetail>();
        }
        public ChartDetail GetFleetTripsheetDetail(byte companyId, short LocationId, short UserId)
        {
            ChartDetail obj = new ChartDetail();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<FleetTrip>, IEnumerable<FleetTrip>, IEnumerable<FleetTrip>> tuple = DataBaseFactory.QueryMultipleSP<FleetTrip, FleetTrip, FleetTrip>("Usp_GetFleetTripsheetDetail", (object)dynamicParameters, "");
            obj.FleetTripTotalGeneratedTripsList = (List<FleetTrip>)tuple.Item1;
            obj.FleetTripPendingforOperationClosureList = (List<FleetTrip>)tuple.Item2;
            obj.FleetTripTripPendingForFinanceClosureList = (List<FleetTrip>)tuple.Item3;
            return obj;
        }
        public ChartDetail GetFinReceDetail(byte companyId, short LocationId, short UserId)
        {
            ChartDetail obj = new ChartDetail();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<CustomerBill>, IEnumerable<CustomerBill>, IEnumerable<CustomerBill>, IEnumerable<CustomerBill>> tuple = DataBaseFactory.QueryMultipleSP<CustomerBill, CustomerBill, CustomerBill, CustomerBill>("Usp_GetFinReceDetail", (object)dynamicParameters, "");
            obj.FinReceTripsBillList = (List<CustomerBill>)tuple.Item1;
            obj.FinReceTBBList = (List<CustomerBill>)tuple.Item2;
            obj.FinRecePaidList = (List<CustomerBill>)tuple.Item3;
            obj.FinReceToPayList = (List<CustomerBill>)tuple.Item4;
            return obj;
        }
        public ChartDetail GetFinCollDetail(byte companyId, short LocationId, short UserId)
        {
            ChartDetail obj = new ChartDetail();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<CustomerBill>, IEnumerable<CustomerBill>, IEnumerable<CustomerBill>, IEnumerable<CustomerBill>> tuple = DataBaseFactory.QueryMultipleSP<CustomerBill, CustomerBill, CustomerBill, CustomerBill>("Usp_GetFinCollDetail", (object)dynamicParameters, "");
            obj.FinCollTripsBillList = (List<CustomerBill>)tuple.Item1;
            obj.FinCollTBBList = (List<CustomerBill>)tuple.Item2;
            obj.FinCollPaidList = (List<CustomerBill>)tuple.Item3;
            obj.FinCollToPayList = (List<CustomerBill>)tuple.Item4;
            return obj;
        }

        public ChartDetail GetOperationalBookingDetail(byte companyId, short LocationId, short UserId)
        {
            ChartDetail obj = new ChartDetail();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Docket>, IEnumerable<Docket>, IEnumerable<Docket>, IEnumerable<Docket>, IEnumerable<Docket>, IEnumerable<Docket>> tuple = DataBaseFactory.QueryMultipleSP<Docket, Docket, Docket, Docket, Docket, Docket>("Usp_GetOperationalBOOKINGDetail", (object)dynamicParameters, "");
            obj.BookedShipmentList = (List<Docket>)tuple.Item1;
            obj.LSPendingForMFList = (List<Docket>)tuple.Item2;
            obj.MFPendingForTHCList = (List<Docket>)tuple.Item3;
            obj.VehiclePendingforUnloadList = (List<Docket>)tuple.Item4;
            obj.ShipmentPendingforDeliveryList = (List<Docket>)tuple.Item5;
            obj.DRSPendingForClosureList = (List<Docket>)tuple.Item6;

            return obj;
        }

        public IEnumerable<PaybaseWiseDocketCount> GetPaybasWiseDocketCount()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<PaybaseWiseDocketCount>("Usp_DashBoard_GetPaybaseWiseDocketCount", (object)dynamicParameters, "Dashboard - GetPaybaseWiseDocketCount");
        }

        public IEnumerable<CustomerSales> GetCustomerBillWiseAmount()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerSales>("Usp_Dashbord_GetCustomerBillWiseAmount", (object)dynamicParameters, "Dashboard - GetCustomerBillWiseAmount");
        }

        public IEnumerable<VendorBillWiseAmount> GetVendorBillWiseAmount()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<VendorBillWiseAmount>("dbo.Usp_Dashbord_GetVendorBillWiseAmount", (object)dynamicParameters, "Dashboard - GetVendoBillWiseAmount");
        }

        public IEnumerable<MonthWiseDocketCount> GetMonthWiseDocketCount()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MonthWiseDocketCount>("dbo.Usp_DashBoard_GetMonthWiseDocketCount", (object)dynamicParameters, "Dashboard - GetMonthWiseDocketCount");
        }

        public IEnumerable<CustomerSales> GetCustomerSales()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerSales>("Usp_Dashbord_GetCustomerSales", (object)dynamicParameters, "Dashboard - GetCustomerSales");
        }

        public IEnumerable<LocationSale> GetLocationSales()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<LocationSale>("Usp_Dashbord_GetLocationSales", (object)dynamicParameters, "Dashboard - GetLocationSales");
        }
        public IEnumerable<DocketDeliveryDetails> GetDocketDeliveryDetails()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketDeliveryDetails>("Usp_Dashbord_GetDocketDeliveryDetails", (object)dynamicParameters, "Dashboard - GetDocketDeliveryDetails");
        }

        public IEnumerable<DocketDeliveryDetails> GetLocationWiseDocketDeliveryDetails()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketDeliveryDetails>("Usp_Dashbord_GetLocationWiseDocketDeliveryDetails", (object)dynamicParameters, "Dashboard - GetLocationWiseDocketDeliveryDetails");
        }

        public DocketDashboardDetails GetDocketDetails()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketDashboardDetails>("Usp_Dashbord_GetDocketDetails_V1", (object)dynamicParameters, "Dashboard - GetDocketDetails").FirstOrDefault();
        }

        public IEnumerable<DocketBillUnBilledDetails> GetDocketBillUnBilledDetails()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FinStartDate", SessionUtility.FinStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", SessionUtility.FinEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DocketBillUnBilledDetails>("Usp_Dashbord_GetDocketBillUnBilledDetails", (object)dynamicParameters, "Dashboard - GetDocketBillUnBilledDetails");
        }
    }
}
