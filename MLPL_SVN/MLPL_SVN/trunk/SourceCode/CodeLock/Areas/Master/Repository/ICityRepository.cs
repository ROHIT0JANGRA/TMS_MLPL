//  
// Type: CodeLock.Areas.Master.Repository.ICityRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ICityRepository : IDisposable
  {
    IEnumerable<MasterCity> GetAll(string StateId, string CityName, string flag);

    MasterCity GetById(long id);

    short Insert(MasterCity objMasterCity);

    short Update(MasterCity objMasterCity);

    bool IsCityNameAvailable(string cityName, long cityId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteCityList(
      string cityName);

    IEnumerable<AutoCompleteResult> GetCityListByStateId(short stateId);

    IEnumerable<AutoCompleteResult> GetCityListByLocationId(
      short locationId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteCityNameListByStateId(
      short stateId,
      string cityName);

    AutoCompleteResult GetCityByLocationId(short locationId);

    IEnumerable<AutoCompleteResult> GetCityList();

    AutoCompleteResult IsCityNameExist(string cityName);
        short GetCityIdByStateId(short stateId, string cityName);
  }
}
