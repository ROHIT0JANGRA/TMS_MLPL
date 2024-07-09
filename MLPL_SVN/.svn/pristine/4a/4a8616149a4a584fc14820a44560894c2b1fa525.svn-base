//  
// Type: CodeLock.Areas.Master.Repository.VehicleCapacityRateRepository
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
  public class VehicleCapacityRateRepository : BaseRepository, IVehicleCapacityRateRepository, IDisposable
  {
    public MasterVehicleCapacityRate GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      Tuple<IEnumerable<MasterVehicleCapacityRate>, IEnumerable<VehicleCapacityRateDetail>> tuple = DataBaseFactory.QueryMultipleSP<MasterVehicleCapacityRate, VehicleCapacityRateDetail>("Usp_MasterVehicle_CapacityRate_GetById", (object) dynamicParameters, "Vehicle Capacity Rate Master - GetById");
      MasterVehicleCapacityRate vehicleCapacityRate1 = new MasterVehicleCapacityRate();
      MasterVehicleCapacityRate vehicleCapacityRate2 = tuple.Item1.FirstOrDefault<MasterVehicleCapacityRate>();
      vehicleCapacityRate2.Details = tuple.Item2.ToList<VehicleCapacityRateDetail>();
      return vehicleCapacityRate2;
    }

    public IEnumerable<MasterVehicleCapacityRate> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterVehicleCapacityRate>("Usp_MasterVehicle_CapacityRate_GetAll", (object) null, "Vehicle Capacity Rate Master - GetAll");
    }

    public void InsertUpdate(
      MasterVehicleCapacityRate objMasterVehicleCapacityRate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicleCapacityRate", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicleCapacityRate), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) objMasterVehicleCapacityRate.VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_CapacityRate_InsertUpdate", (object) dynamicParameters, "Vehicle Capacity Rate Master - InsertUpdate");
    }

    public bool IsVendorAvailable(string vendorCode, short vendorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorCode", (object) vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_CapacityRate_IsVendorAvailable", (object) dynamicParameters, "Vehicle Capacity Rate Master - IsVendorAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
