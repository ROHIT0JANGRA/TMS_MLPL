//  
// Type: CodeLock.Areas.Master.Repository.VehicleTypeRepository
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
  public class VehicleTypeRepository : BaseRepository, IVehicleTypeRepository, IDisposable
  {
    public IEnumerable<MasterVehicleType> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterVehicleType>("Usp_MasterVehicleType_GetAll", (object) null, "VehicleType Master - GetAll");
    }

    public MasterVehicleType GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleTypeId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterVehicleType>("Usp_MasterVehicleType_GetById", (object) dynamicParameters, "VehicleType Master - GetById").FirstOrDefault<MasterVehicleType>();
    }

    public byte Insert(MasterVehicleType objMasterVehicleType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicleType", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicleType), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleTypeId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicleType_Insert", (object) dynamicParameters, "VehicleType Master - Insert");
      return dynamicParameters.Get<byte>("@VehicleTypeId");
    }

    public byte Update(MasterVehicleType objMasterVehicleType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicleType", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicleType), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleTypeId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicleType_Update", (object) dynamicParameters, "VehicleType Master - Update");
      return dynamicParameters.Get<byte>("@VehicleTypeId");
    }

    public bool IsVehicleTypeNameAvailable(short vehicleTypeId, string vehicleTypeName)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleTypeId", (object) vehicleTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleTypeName", (object) vehicleTypeName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicleType_IsVehicleTypeNameAvailable", (object) dynamicParameters, "VehicleType Master - IsVehicleNoAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleTypeList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicleType_GetVehicleTypeList", (object) null, "VehicleType Master - GetVehicleTypeList");
    }
  }
}
