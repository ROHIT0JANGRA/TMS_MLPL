//  
// Type: CodeLock.Areas.Master.Repository.SupervisorRepository
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
  public class SupervisorRepository : BaseRepository, ISupervisorRepository, IDisposable
  {
    public IEnumerable<MasterSupervisor> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterSupervisor>("Usp_MasterSupervisor_GetAll", (object) null, "Supervisor Master - GetAll");
    }

    public MasterSupervisor GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupervisorId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSupervisor>("Usp_MasterSupervisor_GetById", (object) dynamicParameters, "Supervisor Master - GetById").FirstOrDefault<MasterSupervisor>();
    }

    public byte Insert(MasterSupervisor objMasterSupervisor)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSupervisor", (object) XmlUtility.XmlSerializeToString((object) objMasterSupervisor), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupervisorId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSupervisor_Insert", (object) dynamicParameters, "Supervisor Master - Insert");
      return dynamicParameters.Get<byte>("@SupervisorId");
    }

    public byte Update(MasterSupervisor objMasterSupervisor)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSupervisor", (object) XmlUtility.XmlSerializeToString((object) objMasterSupervisor), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupervisorId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterSupervisor>("Usp_MasterSupervisor_Update", (object) dynamicParameters, "Supervisor Master - Update");
      return dynamicParameters.Get<byte>("@SupervisorId");
    }

    public bool IsSupervisorNameAvailable(string SupervisorName, short SupervisorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupervisorId", (object) SupervisorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SupervisorName", (object) SupervisorName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSupervisor_IsNameAvailable", (object) dynamicParameters, "Supervisor Master - IsSupervisorNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string supervisorName,
      short warehouseId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupervisorName", (object) supervisorName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSupervisor_SupervisorAutoComplete", (object) dynamicParameters, "Supervisor Master - GetAutoCompleteList");
    }

    public AutoCompleteResult IsSupervisorNameExist(
      string supervisorName,
      short warehouseId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SupervisorName", (object) supervisorName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSupervisor_IsSupervisorNameExist", (object) dynamicParameters, "Supervisor Master - IsSupervisorNameExist").FirstOrDefault<AutoCompleteResult>();
    }
  }
}
