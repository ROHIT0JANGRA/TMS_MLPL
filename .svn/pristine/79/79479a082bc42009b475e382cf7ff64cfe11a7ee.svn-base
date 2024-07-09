//  
// Type: CodeLock.Areas.Master.Repository.UnitTemperatureRepository
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
  public class UnitTemperatureRepository : BaseRepository, IUnitTemperatureRepository, IDisposable
  {
    public IEnumerable<MasterUnitTemperature> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterUnitTemperature>("Usp_MasterUnitTemperature_GetAll", (object) null, "Master Unit Temperature - GetAll");
    }

    public MasterUnitTemperature GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@UnitId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterUnitTemperature>("Usp_MasterUnitTemperature_GetById", (object) dynamicParameters, "Unit Temperature Master - GetById").FirstOrDefault<MasterUnitTemperature>();
    }

    public short Insert(MasterUnitTemperature objUnitTemperature)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlUnit", (object) XmlUtility.XmlSerializeToString((object) objUnitTemperature), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@UnitId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterUnitTemperature_Insert", (object) dynamicParameters, "Unit Temperature Master - Insert");
      return dynamicParameters.Get<short>("@UnitId");
    }

    public short Update(MasterUnitTemperature objUnitTemperature)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlUnit", (object) XmlUtility.XmlSerializeToString((object) objUnitTemperature), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@UnitId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterUnitTemperature_Update", (object) dynamicParameters, "Unit Temperature Master - Update");
      return dynamicParameters.Get<short>("@UnitId");
    }
  }
}
