//  
// Type: CodeLock.Areas.Master.Repository.PackagingMeasurementRepository
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
  public class PackagingMeasurementRepository : BaseRepository, IPackagingMeasurementRepository, IDisposable
  {
    public IEnumerable<MasterPackagingMeasurement> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterPackagingMeasurement>("Usp_MasterPackagingMeasurement_GetAll", (object) null, "PackagingMeasurement Master - GetAll");
    }

    public MasterPackagingMeasurement GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PackagingMeasurementId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterPackagingMeasurement>("Usp_MasterPackagingMeasurement_GetById", (object) dynamicParameters, "PackagingMeasurement Master - GetById").FirstOrDefault<MasterPackagingMeasurement>();
    }

    public Response Insert(
      MasterPackagingMeasurement objMasterPackagingMeasurement)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPackagingMeasurement", (object) XmlUtility.XmlSerializeToString((object) objMasterPackagingMeasurement), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterPackagingMeasurement_Insert", (object) dynamicParameters, "PackagingMeasurement Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(
      MasterPackagingMeasurement objMasterPackagingMeasurement)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPackagingMeasurement", (object) XmlUtility.XmlSerializeToString((object) objMasterPackagingMeasurement), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterPackagingMeasurement_Update", (object) dynamicParameters, "PackagingMeasurement Master - Update").FirstOrDefault<Response>();
    }

    public bool IsPackagingTypeAvailable(string packagingType, short packagingTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PackagingType", (object) packagingType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PackagingTypeId", (object) packagingTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterPackagingMeasurement_IsPackagingTypeAvailable", (object) dynamicParameters, "PackagingMeasurement Master - IsPackagingTypeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
