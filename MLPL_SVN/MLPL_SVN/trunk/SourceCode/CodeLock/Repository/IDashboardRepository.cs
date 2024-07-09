//  
// Type: CodeLock.Repository.IDashboardRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Repository
{
  public interface IDashboardRepository : IDisposable
  {
        ChartDetail GetAll(byte companyId, short LocationId, short UserId);
        ChartDetail GetFleetTripsheetDetail(byte companyId, short LocationId, short UserId);
        ChartDetail GetFinReceDetail(byte companyId, short LocationId, short UserId);
        ChartDetail GetFinCollDetail(byte companyId, short LocationId, short UserId);
        ChartDetail GetOperationalBookingDetail(byte companyId, short LocationId, short UserId);
        IEnumerable<PaybaseWiseDocketCount> GetPaybasWiseDocketCount();
        IEnumerable<CustomerSales> GetCustomerBillWiseAmount();
        IEnumerable<VendorBillWiseAmount> GetVendorBillWiseAmount();
        IEnumerable<MonthWiseDocketCount> GetMonthWiseDocketCount();
        IEnumerable<CustomerSales> GetCustomerSales();
        IEnumerable<LocationSale> GetLocationSales();
        IEnumerable<DocketDeliveryDetails> GetDocketDeliveryDetails();
        IEnumerable<DocketDeliveryDetails> GetLocationWiseDocketDeliveryDetails();
        DocketDashboardDetails GetDocketDetails();
        IEnumerable<DocketBillUnBilledDetails> GetDocketBillUnBilledDetails();
    }
}
