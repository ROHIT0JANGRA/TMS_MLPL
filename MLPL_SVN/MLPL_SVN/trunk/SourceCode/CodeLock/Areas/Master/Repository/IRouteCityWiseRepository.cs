//  
// Type: CodeLock.Areas.Master.Repository.IRouteCityWiseRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IRouteCityWiseRepository : IDisposable
  {
    Response ValidateRoute(int TransportModeId, int RouteCategoryIsLongHaul, string locationId);
    Response StandardRouteChargeUpdate(MasterStandardRouteCharge objMasterRouteCityWise);
    MasterStandardRouteCharge StandardRouteChargeView(string RouteId, string VehicleTypeId);
    IEnumerable<AutoCompleteResult> GetAllList();
    IEnumerable<MasterRouteCityWise> GetAll();

    MasterRouteCityWise GetDetailById(short id);

    Response Insert(MasterRouteCityWise objMasterRouteCityWise);

    Response Update(MasterRouteCityWise objMasterRouteCityWise);

    AutoCompleteResult IsRouteNameExist(string routeName);

    IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string routeName);

    MasterRouteCityWise GetRouteTransitTime(short routeId);
  }
}
