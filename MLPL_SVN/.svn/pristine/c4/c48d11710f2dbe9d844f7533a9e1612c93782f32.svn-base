//  
// Type: CodeLock.Areas.Master.Repository.LocationHierarchyRepository
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
  public class LocationHierarchyRepository : BaseRepository, ILocationHierarchyRepository, IDisposable
  {
    public IEnumerable<MasterLocationHierarchy> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterLocationHierarchy>("Usp_MasterLocationHierarchy_GetAll", (object) null, "LocationHierarchy Master - GetAll");
    }

    public MasterLocationHierarchy GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationHierarchyId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterLocationHierarchy>("Usp_MasterLocationHierarchy_GetDetailById", (object) dynamicParameters, "LocationHierarchy  Master - GetDetailById").FirstOrDefault<MasterLocationHierarchy>();
    }

    public Response Insert(MasterLocationHierarchy objLocationHierarchy)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLocationHierarchy", (object) XmlUtility.XmlSerializeToString((object) objLocationHierarchy), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterLocationHierarchy_Insert", (object) dynamicParameters, "LocationHierarchy  Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterLocationHierarchy objLocationHierarchy)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLocationHierarchy", (object) XmlUtility.XmlSerializeToString((object) objLocationHierarchy), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterLocationHierarchy_Update", (object) dynamicParameters, "LocationHierarchy  Master - Update").FirstOrDefault<Response>();
    }

    public bool IsLocationHierarchyNameAvailable(
      string LocationHierarchyName,
      byte LocationHierarchyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationHierarchyId", (object) LocationHierarchyId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationHierarchyName", (object) LocationHierarchyName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterLocationHierarchy_IsNameAvailable", (object) dynamicParameters, "LocationHierarchy Master  - IsLocationHierarchyNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetLocationHierarchyList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocations_GetLocationHierarchyList", (object) null, "Locations Master - GetLocationHierarchyList");
    }
  }
}
