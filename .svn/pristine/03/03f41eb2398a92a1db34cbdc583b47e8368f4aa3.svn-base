//  
// Type: CodeLock.Areas.Master.Repository.IStateRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IStateRepository : IDisposable
  {
    IEnumerable<MasterState> GetAll();

    IEnumerable<AutoCompleteResult> GetStateList();

    MasterState GetById(byte id);

    byte Insert(MasterState objMasterState);

    byte Update(MasterState objMasterState);

    bool IsStateNameAvailable(string stateName, short stateId);

    bool IsStateCodeAvailable(byte stateCode, short stateId);

    IEnumerable<AutoCompleteResult> GetStateListByCountryId(
      byte CountryId);

    short GetStateByLocation(short locationId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteStateList(
      string stateName);

    CheckIsState CheckIsStateOrUnionTerritory(short stateId);

    AutoCompleteResult IsStateNameExist(string stateName);
  }
}
