//  
// Type: CodeLock.Areas.Master.Repository.AirportRepository
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
  public class AirportRepository : BaseRepository, IAirportRepository, IDisposable
  {
    public IEnumerable<MasterAirport> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterAirport>("Usp_MasterAirport_GetAll", (object) null, "Airport Master - GetAll");
    }

    public MasterAirport GetDetailById(byte airportId, byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirportId", (object) airportId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterAirport>("Usp_MasterAirport_GetDetailById", (object) dynamicParameters, "Airport Master - GetById").FirstOrDefault<MasterAirport>();
    }

    public byte Insert(MasterAirport objMasterAirport)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAirport", (object) XmlUtility.XmlSerializeToString((object) objMasterAirport), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AirportId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAirport_Insert", (object) dynamicParameters, "Airport Master - Insert");
      return dynamicParameters.Get<byte>("@AirportId");
    }

    public byte Update(MasterAirport objMasterAirport)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAirport", (object) XmlUtility.XmlSerializeToString((object) objMasterAirport), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AirportId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAirport_Update", (object) dynamicParameters, "Airport Master - Update");
      return dynamicParameters.Get<byte>("@AirportId");
    }

    public bool IsAirportNoAvailable(string airportNo, byte airportId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirportId", (object) airportId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AirportNo", (object) airportNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAirport_IsNoAvailable", (object) dynamicParameters, "Airport Master - IsAirportNoAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsAirportNameAvailable(string airportName, byte airportId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirportId", (object) airportId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AirportName", (object) airportName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAirport_IsNameAvailable", (object) dynamicParameters, "Airport Master - IsAirportNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAirPortList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAirport_GetAirPortList", (object) null, "AirPort Master - GetAirPortList");
    }

    public IEnumerable<AutoCompleteResult> GetAirLineList(
      byte airportId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirportId", (object) airportId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAirport_GetAirLineList", (object) dynamicParameters, "AirPort Master - GetAirLineList");
    }

    public IEnumerable<AutoCompleteResult> GetFlightList(
      byte airlineId,
      DateTime dateTime)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirlineId", (object) airlineId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DateTime", (object) dateTime, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAirport_GetFlightList", (object) dynamicParameters, "AirPort Master - GetFlightList");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string airportNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirportNo", (object) airportNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAirport_GetAutoCompleteList", (object) dynamicParameters, "Airport Master - GetAutoCompleteList");
    }

    public AutoCompleteResult CheckValidAirportNo(string airportNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AirportNo", (object) airportNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterAirport_CheckValidAirportNo", (object) dynamicParameters, "Airport Master - CheckValidAirportNo").FirstOrDefault<AutoCompleteResult>();
    }
  }
}
