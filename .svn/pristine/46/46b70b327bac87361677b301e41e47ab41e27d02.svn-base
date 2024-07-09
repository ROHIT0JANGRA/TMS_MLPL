//  
// Type: CodeLock.Areas.Master.Repository.RouteRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
    public class RouteRepository : BaseRepository, IRouteRepository, IDisposable
    {

        public Response ValidateRoute(int TransportModeId, int RouteCategoryIsLongHaul, string locationId,short routeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TransportModeId", (object)TransportModeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteCategoryIsLongHaul", (object)RouteCategoryIsLongHaul, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteId", (object)routeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterRoute_Validate", (object)dynamicParameters, "Route Master - Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<MasterRoute> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterRoute>("Usp_MasterRoute_GetAll", (object)null, "Route Master - GetAll");
        }

        public MasterRoute GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@RouteId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<MasterRoute>, IEnumerable<MasterRouteDetail>> tuple = DataBaseFactory.QueryMultipleSP<MasterRoute, MasterRouteDetail>("Usp_MasterRoute_GetById", (object)dynamicParameters, "Route Master - GetById");
            MasterRoute masterRoute = new MasterRoute();
            if (tuple != null)
            {
                masterRoute = tuple.Item1.FirstOrDefault<MasterRoute>();
                masterRoute.RouteDetailList = tuple.Item2.ToList<MasterRouteDetail>();
            }
            return masterRoute;
        }

        public Response Insert(MasterRoute objMasterRoute)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlRoute", (object)XmlUtility.XmlSerializeToString((object)objMasterRoute), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterRoute_Insert", (object)dynamicParameters, "Route Master - Insert").FirstOrDefault<Response>();
        }

        public Response Update(MasterRoute objMasterRoute)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlRoute", (object)XmlUtility.XmlSerializeToString((object)objMasterRoute), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterRoute_Update", (object)dynamicParameters, "Route Master - Update").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteListByLocationCode(
          string locationCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationCode", (object)locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRoute_GetAutoCompleteListByLocationCode", (object)dynamicParameters, "Route Master - GetAutoCompleteListByLocationCode");
        }

        public IEnumerable<AutoCompleteResult> GetRouteNameList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRoute_GetRouteNameList", (object)null, "Route Master - GetRouteNameList");
        }

        public IEnumerable<AutoCompleteResult> GetRouteListByTransportModeId(
          byte transportModeId,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRoute_GetRouteListByTransportModeId", (object)dynamicParameters, "Route Master - GetRouteListByTransportModeId");
        }

        public IEnumerable<MasterRouteDetail> GetRouteDetail(short? id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@RouteId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterRouteDetail>("Usp_MasterRoute_GetRouteDetail", (object)dynamicParameters, "Route Master - GetRouteDetail");
        }

        public bool CheckValidContractAmount(byte routeId, Decimal contractAmount)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@RouteId", (object)routeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ContractAmount", (object)contractAmount, new DbType?(DbType.Decimal), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterRoute_CheckValidContractAmount", (object)dynamicParameters, "Route  Master - CheckValidContractAmount");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public bool IsRouteNameAvailable(short routesId, string routeName)
        {
            //var pram = new DynamicParameters();
            //pram.Add("@RouteId", routesId, DbType.Int16);
            //pram.Add("@RouteName", routeName, DbType.String);
            //pram.Add("@IsAvailable", null, DbType.Boolean);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@RouteId", (object)routesId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RouteName", (object)routeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());

            DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterRoute_IsRouteNameAvailable", (object)dynamicParameters, module: "Route Master - IsRouteNameAvailable").FirstOrDefault();
           return dynamicParameters.Get<bool>("@IsAvailable");
        }
    }
}
