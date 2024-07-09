//  
// Type: CodeLock.Areas.Master.Repository.LocationRepository
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
  public class LocationRepository : BaseRepository, ILocationRepository, IDisposable
  {
    public MasterLocation GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterLocation>("Usp_MasterLocation_GetById", (object) dynamicParameters, "Location Master - GetById").FirstOrDefault<MasterLocation>();
    }

    public IEnumerable<MasterLocation> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterLocation>("Usp_MasterLocation_GetAll", (object) null, "Location Master - GetAll");
    }

    public short Insert(MasterLocation objMasterLocation)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLocation", (object) XmlUtility.XmlSerializeToString((object) objMasterLocation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterLocation_Insert", (object) dynamicParameters, "Location Master - Insert");
      return dynamicParameters.Get<short>("@LocationId");
    }

    public short Update(MasterLocation objMasterLocation)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlLocation", (object) XmlUtility.XmlSerializeToString((object) objMasterLocation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterLocation_Update", (object) dynamicParameters, "Location Master - Update");
      return dynamicParameters.Get<short>("@LocationId");
    }

    public IEnumerable<AutoCompleteResult> GetLocationListByLocationId(
      short loginLocationId,
      short loginUserLocationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LoginLocationId", (object) loginLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LoginUserLocationId", (object) loginUserLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationListByLocationId", (object) dynamicParameters, "Location Master - GetLocationListByLocationId");
    }

    public IEnumerable<AutoCompleteResult> GetLocationListByStateId(
      short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationListByStateId", (object) dynamicParameters, "Location Master - GetLocationListByStateId");
    }

    public IEnumerable<AutoCompleteResult> GetByLocationHierarchy(
      byte locationHierarchy)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@locationHierarchy", (object) locationHierarchy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetByLocationHierarchy", (object) dynamicParameters, "Location Master - GetByLocationHierarchy");
    }

    public bool IsLocationNameAvailable(string locationName, short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationName", (object) locationName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterLocation_IsNameAvailable", (object) dynamicParameters, "Location Master - IsLocationNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsLocationCodeAvailable(string locationCode, short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationCode", (object) locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterLocation_IsLocationCodeAvailable", (object) dynamicParameters, "Location Master - IsLocationCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
        public IEnumerable<AutoCompleteResult> GetLocationList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationList", (object)null, "Location Master - GetLocationList");
        }


        public IEnumerable<AutoCompleteResult> GetLocationListOnlyBranch()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationListOnlyBranch", (object) null, "Location Master - GetLocationList");
    }
        public IEnumerable<AutoCompleteResult> GetLocationAllList(string OwnershipType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@OwnershipType", (object)OwnershipType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationList", (object)dynamicParameters, "Location Master - GetLocationList");
        }

        public IEnumerable<AutoCompleteResult> GetLocationList(string OwnershipType)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@OwnershipType", (object)OwnershipType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationList", (object)dynamicParameters, "Location Master - GetLocationList");
    }
        public IEnumerable<AutoCompleteResult> GetAutoCompleteLocationList(
      string locationCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationCode", (object) locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetAutoCompleteLocationList", (object) dynamicParameters, "Location Master - GetAutoCompleteLocationList");
    }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteLocationListDocketENtry(
        string locationCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationCode", (object)locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetAutoCompleteLocationListDocketENtry", (object)dynamicParameters, "Location Master - GetAutoCompleteLocationListDocketENtry");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteLocationListDocketEntryByDeliveryLocation(
       string locationCode,short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationCode", (object)locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //dynamicParameters.Add("@OwnershipTypeId", (object)OwnershipType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetAutoCompleteLocationListDocketEntryByDeliveryLocation", (object)dynamicParameters, "Location Master - GetAutoCompleteLocationListDocketENtry");
        }


        public IEnumerable<AutoCompleteResult> GetAutoCompleteLocationList(
      string locationCode, string OwnershipType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationCode", (object)locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@OwnershipTypeId", (object)OwnershipType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetAutoCompleteLocationList", (object)dynamicParameters, "Location Master - GetAutoCompleteLocationList");
        }
    public AutoCompleteResult IsLocationCodeExist(string locationCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationCode", (object) locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_IsLocationCodeExist", (object) dynamicParameters, "Location Master - IsLocationCodeExist").FirstOrDefault<AutoCompleteResult>();
    }
    public AutoCompleteResult IsLocationCodeExistOwnership(string locationCode)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@LocationCode", (object)locationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_IsLocationCodeExistOwnership", (object)dynamicParameters, "Location Master - IsLocationCodeExist").FirstOrDefault<AutoCompleteResult>();
    }


     public IEnumerable<AutoCompleteResult> GetLocationHierarchyByLocationId(
      short locationId,
      short virtualLocationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VirtualLocationId", (object) virtualLocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationHierarchyByLocationId", (object) dynamicParameters, "Location Master - GetLocationHierarchyByLocationId");
    }

    public IEnumerable<AutoCompleteResult> GetLocationListByZoneId(
      short zoneId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ZoneId", (object) zoneId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationListByZoneId", (object) dynamicParameters, "Location Master - GetLocationListByZoneId");
    }

    public IEnumerable<AutoCompleteResult> GetLocationByHierarchyId(
      bool isRegion)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@IsRegion", (object) isRegion, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetLocationByHierarchyId", (object) dynamicParameters, "Location Master - GetLocationByHierarchyId");
    }
        public LocationNameById GetLocationNameById(string locationName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationName", (object)locationName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<LocationNameById>("Usp_MasterLocation_IsLocationName", (object)dynamicParameters, "Location Master - IsLocationNameById").FirstOrDefault<LocationNameById>();
        }

        public bool CheckDeliveryLocationByBillingParty(short locationId, short customerId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterLocation_CheckDeliveryLocationByBillingParty", (object)dynamicParameters, "Customer Master - CheckDeliveryLocationByBillingParty");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }
    }
}
