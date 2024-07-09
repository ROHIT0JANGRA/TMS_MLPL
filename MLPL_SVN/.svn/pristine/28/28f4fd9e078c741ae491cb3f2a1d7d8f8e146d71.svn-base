//  
// Type: CodeLock.Areas.Master.Repository.FlightRepository
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
  public class FlightRepository : BaseRepository, IFlightRepository, IDisposable
  {
    public IEnumerable<MasterFlight> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterFlight>("Usp_MasterFlight_GetAll", (object) null, "Account Master - GetAll");
    }

    public MasterFlight GetDetailById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FlightId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterFlight>("Usp_MasterFlight_GetDetailById", (object) dynamicParameters, "Flight Master - GetDetailById").FirstOrDefault<MasterFlight>();
    }

    public short Insert(MasterFlight objMasterFlight)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFlight", (object) XmlUtility.XmlSerializeToString((object) objMasterFlight), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FlightId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterFlight_Insert", (object) dynamicParameters, "Flight Master - Insert");
      return dynamicParameters.Get<short>("@FlightId");
    }

    public short Update(MasterFlight objMasterFlight)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFlight", (object) XmlUtility.XmlSerializeToString((object) objMasterFlight), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FlightId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterFlight_Update", (object) dynamicParameters, "Airport Master - Update");
      return dynamicParameters.Get<short>("@FlightId");
    }

    public bool IsFlightNoAvailable(string flightNo, short flightId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FlightId", (object) flightId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FlightNo", (object) flightNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterFlight_IsNoAvailable", (object) dynamicParameters, "Flight Master - IsFlightNoAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<FlightDetail> GetFlightDetail(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FlightId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<FlightDetail>("Usp_MasterFlight_GetFlightDetail", (object) dynamicParameters, "Flight Master - GetFlightDetail");
    }
  }
}
