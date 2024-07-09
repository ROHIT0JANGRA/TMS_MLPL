//  
// Type: CodeLock.Areas.Master.Repository.CityRepository
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
  public class CityRepository : BaseRepository, ICityRepository, IDisposable
  {
    public IEnumerable<MasterCity> GetAll(string StateId, string CityName, string flag)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@StateId", (object)StateId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        dynamicParameters.Add("@CityName", (object)CityName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        dynamicParameters.Add("@flag", (object)flag, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<MasterCity>("Usp_MasterCity_GetAll", (object)dynamicParameters, "City Master - GetAll");
    }

    public MasterCity GetById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CityId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCity>("Usp_MasterCity_GetById", (object) dynamicParameters, "City Master - GetById").FirstOrDefault<MasterCity>();
    }

    public short Insert(MasterCity objMasterCity)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCity", (object) XmlUtility.XmlSerializeToString((object) objMasterCity), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCity_Insert", (object) dynamicParameters, "City Master - Insert");
      return dynamicParameters.Get<short>("@CityId");
    }

    public short Update(MasterCity objMasterCity)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCity", (object) XmlUtility.XmlSerializeToString((object) objMasterCity), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCity_Update", (object) dynamicParameters, "City Master - Update");
      return dynamicParameters.Get<short>("@CityId");
    }

    public bool IsCityNameAvailable(string cityName, long cityId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CityId", (object) cityId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityName", (object) cityName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCity_IsNameAvailable", (object) dynamicParameters, "City Master - IsCityNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteCityList(
      string cityName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CityName", (object) cityName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetAutoCompleteCityList", (object) dynamicParameters, "City Master - GetAutoCompleteCityList");
    }

    public IEnumerable<AutoCompleteResult> GetCityListByStateId(
      short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetCityListByStateId", (object) dynamicParameters, "City Master - GetCityListByStateId");
    }

    public IEnumerable<AutoCompleteResult> GetCityListByLocationId(
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetCityListByLocationId", (object) dynamicParameters, "City Master - GetCityListByLocationId");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteCityNameListByStateId(
      short stateId,
      string cityName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityName", (object) cityName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetAutoCompleteCityNameListByStateId", (object) dynamicParameters, "City Master - GetAutoCompleteCityNameListByStateId");
    }

    public AutoCompleteResult GetCityByLocationId(short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetCityByLocationId", (object) dynamicParameters, "City Master - GetCityByLocationId").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetCityList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetCityList", (object) null, "City Master - GetCityList");
    }

    public AutoCompleteResult IsCityNameExist(string cityName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CityName", (object) cityName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_IsCityNameExist", (object) dynamicParameters, "City Master - IsCityNameExist").FirstOrDefault<AutoCompleteResult>();
    }
  }
}
