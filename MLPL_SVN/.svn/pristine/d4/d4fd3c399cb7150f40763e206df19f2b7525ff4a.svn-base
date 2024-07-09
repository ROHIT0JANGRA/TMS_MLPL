//  
// Type: CodeLock.Areas.Master.Repository.StateRepository
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
  public class StateRepository : BaseRepository, IStateRepository, IDisposable
  {
    public IEnumerable<MasterState> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterState>("Usp_MasterState_GetAll", (object) null, "State Master - GetAll");
    }

    public IEnumerable<AutoCompleteResult> GetStateList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterState_GetStateList", (object) null, "State Master - GetStateList");
    }

    public MasterState GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      Tuple<IEnumerable<MasterState>, IEnumerable<MasterStateDocument>> tuple = DataBaseFactory.QueryMultipleSP<MasterState, MasterStateDocument>("Usp_MasterState_GetById", (object) dynamicParameters, "State Master - GetById");
      MasterState masterState = new MasterState();
      if (tuple != null)
      {
        masterState = tuple.Item1.FirstOrDefault<MasterState>();
        masterState.MasterStateDocumentList = tuple.Item2.ToList<MasterStateDocument>();
      }
      return masterState;
    }

    public byte Insert(MasterState objMasterState)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlState", (object) XmlUtility.XmlSerializeToString((object) objMasterState), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterState_Insert", (object) dynamicParameters, "State Master - Insert");
      return dynamicParameters.Get<byte>("@StateId");
    }

    public byte Update(MasterState objMasterState)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlState", (object) XmlUtility.XmlSerializeToString((object) objMasterState), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterState_Update", (object) dynamicParameters, "State Master - Update");
      return dynamicParameters.Get<byte>("@StateId");
    }

    public bool IsStateNameAvailable(string stateName, short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateName", (object) stateName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterState_CheckState", (object) dynamicParameters, "State Master - IsStateNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsStateCodeAvailable(byte stateCode, short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateCode", (object) stateCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterState_IsStateCodeAvailable", (object) dynamicParameters, "State Master - IsStateCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetStateListByCountryId(
      byte CountryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CountryId", (object) CountryId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterState_GetStateListByCountryId", (object) dynamicParameters, "State Master - GetStateListByCountryId");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteStateList(
      string stateName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateName", (object) stateName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterState_GetAutoCompleteList", (object) dynamicParameters, "State Master - GetAutoCompleteStateList");
    }

    public CheckIsState CheckIsStateOrUnionTerritory(short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<CheckIsState>("Usp_MasterState_CheckIsStateOrUnionTerritory", (object) dynamicParameters, "State Master - CheckIsStateOrUnionTerritory").FirstOrDefault<CheckIsState>();
    }

    public AutoCompleteResult IsStateNameExist(string stateName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateName", (object) stateName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterState_IsStateNameExist", (object) dynamicParameters, "State Master - IsStateNameExist").FirstOrDefault<AutoCompleteResult>();
    }

    public short GetStateByLocation(short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterState_GetStateByLocation", (object) dynamicParameters, "State Master - GetStateByLocation");
      return dynamicParameters.Get<short>("@StateId");
    }
  }
}
