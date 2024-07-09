//  
// Type: CodeLock.Areas.Master.Repository.VehicleDocumentTypeRepository
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
  public class VehicleDocumentTypeRepository : BaseRepository, IVehicleDocumentTypeRepository, IDisposable
  {
    public MasterVehicleDocumentType GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleDocumentId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterVehicleDocumentType>("Usp_MasterVehicleDocument_GetById", (object) dynamicParameters, "Vehicle Document Master - GetById").FirstOrDefault<MasterVehicleDocumentType>();
    }

    public IEnumerable<MasterVehicleDocumentType> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterVehicleDocumentType>("Usp_MasterVehicleDocument_GetAll", (object) null, "Vehicle Document Master - GetAll");
    }

    public short Insert(
      MasterVehicleDocumentType objMasterVehicleDocumentType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicleDocument", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicleDocumentType), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleDocumentId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicleDocument_Insert", (object) dynamicParameters, "Vehicle Document Master - Insert");
      return dynamicParameters.Get<short>("@VehicleDocumentId");
    }

    public short Update(
      MasterVehicleDocumentType objMasterVehicleDocumentType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicleDocument", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicleDocumentType), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleDocumentId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterVendor>("Usp_MasterVehicleDocument_Update", (object) dynamicParameters, "Vehicle Document Master - Update");
      return dynamicParameters.Get<short>("@VehicleDocumentId");
    }

    public bool IsDocumentAvailable(string VehicleDocument, short VehicleDocumentId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleDocumentId", (object) VehicleDocumentId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Document", (object) VehicleDocument, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicleDocument_IsNameAvailable", (object) dynamicParameters, "Vehicle Document Master - IsVehicleDocumentAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
