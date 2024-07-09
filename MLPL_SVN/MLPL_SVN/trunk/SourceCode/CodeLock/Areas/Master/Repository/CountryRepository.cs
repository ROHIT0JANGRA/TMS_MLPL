//  
// Type: CodeLock.Areas.Master.Repository.CountryRepository
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
  public class CountryRepository : BaseRepository, ICountryRepository, IDisposable
  {
    public MasterCountry GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CountryId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCountry>("Usp_MasterCountry_GetById", (object) dynamicParameters, "Country Master - GetById").FirstOrDefault<MasterCountry>();
    }

    public IEnumerable<MasterCountry> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterCountry>("Usp_MasterCountry_GetAll", (object) null, "Country Master - GetAll");
    }

    public byte Insert(MasterCountry objMasterCountry)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCountry", (object) XmlUtility.XmlSerializeToString((object) objMasterCountry), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CountryId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCountry_Insert", (object) dynamicParameters, "Country Master - Insert");
      return dynamicParameters.Get<byte>("@CountryId");
    }

    public byte Update(MasterCountry objMasterCountry)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCountry", (object) XmlUtility.XmlSerializeToString((object) objMasterCountry), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CountryId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterCountry>("Usp_MasterCountry_Update", (object) dynamicParameters, "Country Master - Update");
      return dynamicParameters.Get<byte>("@CountryId");
    }

    public bool IsCountryNameAvailable(string countryName, byte countryId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CountryId", (object) countryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CountryName", (object) countryName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCountry_IsNameAvailable", (object) dynamicParameters, "Country Master - IsCountryNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetCountryList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCountry_GetCountryList", (object) null, "Country Master - GetCountryList");
    }
  }
}
