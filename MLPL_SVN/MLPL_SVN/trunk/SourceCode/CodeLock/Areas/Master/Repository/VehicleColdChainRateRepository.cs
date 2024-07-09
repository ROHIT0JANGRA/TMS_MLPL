//  
// Type: CodeLock.Areas.Master.Repository.VehicleColdChainRateRepository
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
  public class VehicleColdChainRateRepository : BaseRepository, IVehicleColdChainRateRepository, IDisposable
  {
    public MasterVehicleColdChainRate GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterVehicleColdChainRate>("Usp_MasterVehicle_ColdChainRate_GetById", (object) dynamicParameters, "Vehicle Cold Chain Rate Master - GetById").FirstOrDefault<MasterVehicleColdChainRate>();
    }

    public IEnumerable<MasterVehicleColdChainRate> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterVehicleColdChainRate>("Usp_MasterVehicle_ColdChainRate_GetAll", (object) null, "Vehicle Cold Chain Rate Master - GetAll");
    }

    public void InsertUpdate(
      MasterVehicleColdChainRate objMasterVehicleColdChainRate)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicleColdChainRate", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicleColdChainRate), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleId", (object) objMasterVehicleColdChainRate.VehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_ColdChainRate_InsertUpdate", (object) dynamicParameters, "Vehicle Cold Chain Rate Master - InsertUpdate");
    }
  }
}
