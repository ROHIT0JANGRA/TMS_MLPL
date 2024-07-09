﻿//  
// Type: CodeLock.Areas.Master.Repository.DriverRepository
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
  public class DriverRepository : BaseRepository, IDriverRepository, IDisposable
  {
    public IEnumerable<AutoCompleteResult> GetDriverList()
    {
        return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetDriverList", null, module: "Driver Master - GetDriverList");
    }
    public IEnumerable<MasterDriver> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterDriver>("Usp_MasterDriver_GetAll", (object) null, "Driver Master - GetAll");
    }

        public MasterDriver GetById(int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DriverId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<MasterDriver>, IEnumerable<DriverDocument>> tuple = DataBaseFactory.QueryMultipleSP<MasterDriver, DriverDocument>("Usp_MasterDriver_GetById", (object)dynamicParameters, "Driver Master - GetById");
            MasterDriver masterDriver = new MasterDriver();
            if (tuple != null)
            {
                masterDriver = tuple.Item1.FirstOrDefault<MasterDriver>();
                masterDriver.DocumentDetails = tuple.Item2.ToList<DriverDocument>();
            }
            return masterDriver;
        }

        public Response Insert(MasterDriver objMasterDriver)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDriver", (object) XmlUtility.XmlSerializeToString((object) objMasterDriver), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterDriver_Insert", (object) dynamicParameters, "Driver Master - Insert").FirstOrDefault<Response>();
    }

    public Response DocumentInsert(DriverDocument objDriverDocument)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDriverDocument", (object) XmlUtility.XmlSerializeToString((object) objDriverDocument), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterDriver_DocumentInsert", (object) dynamicParameters, "Driver Master - DocumentInsert").FirstOrDefault<Response>();
    }

    public Response Update(MasterDriver objMasterDriver)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDriver", (object) XmlUtility.XmlSerializeToString((object) objMasterDriver), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterDriver_Update", (object) dynamicParameters, "Driver Master - Update").FirstOrDefault<Response>();
    }

    public short DocumentUpdate(DriverDocument objDriverDocument)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDocumentUpdate", (object) XmlUtility.XmlSerializeToString((object) objDriverDocument), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DriverId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterDriver_DocumentUpdate", (object) dynamicParameters, "Master Driver - DocumentUpdate");
      return dynamicParameters.Get<short>("@DriverId");
    }

    public IEnumerable<AutoCompleteResult> GetDriverListByLocation(
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetDriverListByLocation", (object) dynamicParameters, "Driver Master - GetDriverListByLocation");
    }

    public IEnumerable<AutoCompleteResult> GetDriverListByTripSheetRule(
      short locationId,
      short? vehicleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetDriverListByTripSheetRule", (object) dynamicParameters, "Driver Master - GetDriverListByTripSheetRule");
    }

    public MasterDriver GetDriverDetailByVehicleId(short locationId, short vehicleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterDriver>("Usp_MasterDriver_GetDriverDetailByVehicleId", (object) dynamicParameters, "Driver Master - GetDriverDetailByVehicleId").FirstOrDefault<MasterDriver>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteDriverListByLocation(
      string driverName,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@DriverName", (object) driverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetAutoCompleteDriverListByLocation", (object) dynamicParameters, "Driver Master - GetAutoCompleteDriverListByLocation");
    }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteDriverCodeListByLocation(
          string driverName,
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DriverName", (object)driverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetAutoCompleteDriverCodeListByLocation", (object)dynamicParameters, "Driver Master - GetAutoCompleteDriverListByLocation");
        }

        public AutoCompleteResult IsDriverNameExistByLocation(
      string driverName,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@DriverName", (object) driverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_IsDriverNameExistByLocation", (object) dynamicParameters, "Driver Master - IsDriverNameExistByLocation").FirstOrDefault<AutoCompleteResult>();
    }

  public AutoCompleteResult IsDriverCodeExistByLocation(
   string driverName,
   short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DriverName", (object)driverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_IsDriverCodeExistByLocation", (object)dynamicParameters, "Driver Master - IsDriverCodeExistByLocation").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteDriverList(
          string driverName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DriverName", (object)driverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetAutoCompleteDriverList", (object)dynamicParameters, "Driver Master - GetAutoCompleteDriverListByLocation");
        }

        public AutoCompleteResult IsDriverNameExist(
          string driverName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DriverName", (object)driverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_IsDriverNameExist", (object)dynamicParameters, "Driver Master - IsDriverNameExistByLocation").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetLocationListByDriverId(int driverId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DriverId", (object)driverId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterDriver_GetLocationListByDriverId", (object)dynamicParameters, "Driver Master - GetLocationListByDriverId");
        }

        public IEnumerable<MasterDriver> GetDriversByPagination(int pageNo, int pageSize, string sorting, string search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterDriver>("Usp_MasterDriver_GetDriverByPagination", (object)dynamicParameters, "Driver Master - GetDriversByPagination");
        }

    }
}