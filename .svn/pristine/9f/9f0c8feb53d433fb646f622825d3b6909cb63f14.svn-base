//  
// Type: CodeLock.Areas.Master.Repository.FuelBrandRepository
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
  public class FuelBrandRepository : BaseRepository, IFuelBrandRepository, IDisposable
  {
    public IEnumerable<MasterFuelBrand> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterFuelBrand>("Usp_MasterFuelBrand_GetAll", (object) null, "FuelBrand Master - GetAll");
    }

    public MasterFuelBrand GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FuelBrandId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterFuelBrand>("Usp_MasterFuelBrand_GetDetailById", (object) dynamicParameters, "FuelBrand Master - GetDetailById").FirstOrDefault<MasterFuelBrand>();
    }

    public byte Insert(MasterFuelBrand objMasterFuelBrand)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFuelBrand", (object) XmlUtility.XmlSerializeToString((object) objMasterFuelBrand), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FuelBrandId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterFuelBrand_Insert", (object) dynamicParameters, "FuelBrand Master - Insert");
      return dynamicParameters.Get<byte>("@FuelBrandId");
    }

    public byte Update(MasterFuelBrand objMasterFuelBrand)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFuelBrand", (object) XmlUtility.XmlSerializeToString((object) objMasterFuelBrand), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FuelBrandId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterFuelBrand_Update", (object) dynamicParameters, "FuelBrand Master - Update");
      return dynamicParameters.Get<byte>("@FuelBrandId");
    }

    public IEnumerable<AutoCompleteResult> GetListByFuelTypeId(
      byte fuelTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FuelTypeId", (object) fuelTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterFuelBrand_GetListByFuelTypeId ", (object) dynamicParameters, "FuelBrand Master - GetListByFuelTypeId");
    }

    public bool IsFuelBrandNameAvailable(string fuelBrandName, byte fuelBrandId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FuelBrandId", (object) fuelBrandId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FuelBrandName", (object) fuelBrandName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterFuelBrand_IsNameAvailable", (object) dynamicParameters, "FuelBrand Master - IsFuelBrandNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public AutoCompleteResult CheckValidFuelBrandName(string fuelBrandName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FuelBrandName", (object) fuelBrandName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterFuelBrand_CheckValidFuelBrandName", (object) dynamicParameters, "FuelBrand Master - CheckValidFuelBrandName").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string fuelBrandName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FuelBrandName", (object) fuelBrandName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterFuelBrand_GetAutoCompleteList", (object) dynamicParameters, "FuelBrand Master - GetAutoCompleteList");
    }
  }
}
