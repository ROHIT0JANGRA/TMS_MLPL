//  
// Type: CodeLock.Areas.Master.Repository.ZoneRepository
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
  public class ZoneRepository : BaseRepository, IZoneRepository, IDisposable
  {
    public IEnumerable<MasterZone> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterZone>("Usp_MasterZone_GetAll", (object) null, "Zone Master - GetAll");
    }

    public MasterZone GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ZoneId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterZone>("Usp_MasterZone_GetById", (object) dynamicParameters, "Zone Master - GetById").FirstOrDefault<MasterZone>();
    }

    public byte Insert(MasterZone objMasterZone)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlZone", (object) XmlUtility.XmlSerializeToString((object) objMasterZone), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ZoneId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterZone_Insert", (object) dynamicParameters, "Zone Master - Insert");
      return dynamicParameters.Get<byte>("@ZoneId");
    }

    public byte Update(MasterZone objMasterZone)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlZone", (object) XmlUtility.XmlSerializeToString((object) objMasterZone), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ZoneId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterZone>("Usp_MasterZone_Update", (object) dynamicParameters, "Zone Master - Update");
      return dynamicParameters.Get<byte>("@ZoneId");
    }

    public bool IsZoneNameAvailable(string zoneName, byte zoneId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ZoneId", (object) zoneId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ZoneName", (object) zoneName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterZone_IsNameAvailable", (object) dynamicParameters, "Zone Master - IsZoneNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetZoneList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCity_GetZoneList", (object) null, "Zone Master - GetZoneList");
    }

    public AutoCompleteResult IsZoneNameExist(string zoneName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ZoneName", (object) zoneName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterZone_IsZoneNameExist", (object) dynamicParameters, "Zone Master - IsZoneNameExist").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteZoneList(
      string zoneName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ZoneName", (object) zoneName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterZone_GetAutoCompleteZoneList", (object) dynamicParameters, "Zone Master - GetAutoCompleteZoneList");
    }
  }
}
