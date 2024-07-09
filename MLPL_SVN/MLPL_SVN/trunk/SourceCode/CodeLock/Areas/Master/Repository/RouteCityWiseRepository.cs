//  
// Type: CodeLock.Areas.Master.Repository.RouteCityWiseRepository
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

namespace CodeLock.Areas.Master.Repository
{
  public class RouteCityWiseRepository : BaseRepository, IRouteCityWiseRepository, IDisposable
  {
    public Response ValidateRoute(int TransportModeId, int RouteCategoryIsLongHaul, string locationId)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@TransportModeId", (object)TransportModeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        dynamicParameters.Add("@RouteCategoryIsLongHaul", (object)RouteCategoryIsLongHaul, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<Response>("Usp_MasterRouteCitywise_Validate", (object)dynamicParameters, "Route Master - Insert").FirstOrDefault<Response>();
    }
    public IEnumerable<MasterRouteCityWise> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterRouteCityWise>("Usp_MasterRouteCityWise_GetAll", (object) null, "RouteCityWise Master - GetAll");
    }
    public IEnumerable<AutoCompleteResult> GetAllList()
    {
        return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRoutrCityWise_GetAllList", (object)null, "RouteCityWise Master - GetAll");
    }
    public MasterRouteCityWise GetDetailById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RouteId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      Tuple<IEnumerable<MasterRouteCityWise>, IEnumerable<MasterRouteCityWiseDetail>> tuple = DataBaseFactory.QueryMultipleSP<MasterRouteCityWise, MasterRouteCityWiseDetail>("Usp_MasterRouteCityWise_GetDetailById", (object) dynamicParameters, "Route City Wise Master - GetById");
      MasterRouteCityWise masterRouteCityWise = new MasterRouteCityWise();
      if (tuple != null)
      {
        masterRouteCityWise = tuple.Item1.FirstOrDefault<MasterRouteCityWise>();
        masterRouteCityWise.RouteDetailList = tuple.Item2.ToList<MasterRouteCityWiseDetail>();
      }
      return masterRouteCityWise;
    }

    public Response Insert(MasterRouteCityWise objMasterRouteCityWise)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlRoute", (object) XmlUtility.XmlSerializeToString((object) objMasterRouteCityWise), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterRouteCityWise_Insert", (object) dynamicParameters, "Route City Wise Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterRouteCityWise objMasterRouteCityWise)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlRoute", (object) XmlUtility.XmlSerializeToString((object) objMasterRouteCityWise), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterRouteCityWise_Update", (object) dynamicParameters, "Route City Wise Master - Update").FirstOrDefault<Response>();
    }
    public Response StandardRouteChargeUpdate(MasterStandardRouteCharge objMasterRouteCityWise)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@Xml", (object)XmlUtility.XmlSerializeToString((object)objMasterRouteCityWise), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<Response>("Usp_MasterStandardRouteCharge_Update", (object)dynamicParameters, "Route City Wise Master - Update").FirstOrDefault<Response>();
    }
        public AutoCompleteResult IsRouteNameExist(string routeName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RouteName", (object) routeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRouteCityWise_IsRouteNameExist", (object) dynamicParameters, "RouteCityWise Master - IsRouteNameExist").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string routeName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RouteName", (object) routeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRoutrCityWise_GetAutoCompleteRouteList", (object) dynamicParameters, "RouteCityWise Master - GetAutoCompleteRouteList");
    }

    public MasterRouteCityWise GetRouteTransitTime(short routeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RouteId", (object) routeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterRouteCityWise>("Usp_MasterRouteCityWise_GetRouteTransitTime", (object) dynamicParameters, "RouteCityWise Master - GetRouteTransitTime").FirstOrDefault<MasterRouteCityWise>();
    }

    public MasterStandardRouteCharge StandardRouteChargeView(string RouteId, string VehicleTypeId)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@RouteId", (object)RouteId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        dynamicParameters.Add("@VehicleTypeId", (object)VehicleTypeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

        Tuple<IEnumerable<MasterStandardRouteCharge>, IEnumerable<MasterStandardRouteChargeExpense>> tuple = DataBaseFactory.QueryMultipleSP<MasterStandardRouteCharge, MasterStandardRouteChargeExpense>("Usp_MasterStandardRouteCharge_View_New", (object)dynamicParameters, "Docket");
        MasterStandardRouteCharge RouteCharge = tuple.Item1.FirstOrDefault<MasterStandardRouteCharge>();
        RouteCharge.ChargeList = tuple.Item2.ToList<MasterStandardRouteChargeExpense>();

      return RouteCharge;
    }

    }
}
