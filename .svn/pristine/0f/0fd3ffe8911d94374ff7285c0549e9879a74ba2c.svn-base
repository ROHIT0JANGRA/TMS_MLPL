//  
// Type: CodeLock.Areas.Master.Repository.IRouteRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface IRouteRepository : IDisposable
    {
        Response ValidateRoute(int TransportModeId, int RouteCategoryIsLongHaul, string locationId,short routeId);
        IEnumerable<MasterRoute> GetAll();

        MasterRoute GetById(short id);

        Response Insert(MasterRoute objMasterRoute);

        Response Update(MasterRoute objMasterRoute);

        IEnumerable<AutoCompleteResult> GetAutoCompleteListByLocationCode(
          string locationCode);

        IEnumerable<AutoCompleteResult> GetRouteNameList();

        IEnumerable<AutoCompleteResult> GetRouteListByTransportModeId(
          byte transportModeId,
          short locationId);

        IEnumerable<MasterRouteDetail> GetRouteDetail(short? id);

        bool CheckValidContractAmount(byte routeId, Decimal contractAmount);
        bool IsRouteNameAvailable(short routesId,string routeName);
    }
}
