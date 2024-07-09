//  
// Type: CodeLock.Areas.Master.Repository.SacRepository
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
  public class SacRepository : BaseRepository, ISacRepository, IDisposable
  {
    public MasterSac GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSac>("Usp_MasterSac_GetById", (object) dynamicParameters, "Sac Master - GetById").FirstOrDefault<MasterSac>();
    }

    public IEnumerable<MasterSac> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterSac>("Usp_MasterSac_GetAll", (object) null, "Sac Master - GetAll");
    }

    public byte Insert(MasterSac objMasterSac)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSac", (object) XmlUtility.XmlSerializeToString((object) objMasterSac), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SacId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSac_Insert", (object) dynamicParameters, "Sac Master - Insert");
      return dynamicParameters.Get<byte>("@SacId");
    }

    public byte Update(MasterSac objMasterSac)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSac", (object) XmlUtility.XmlSerializeToString((object) objMasterSac), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SacId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSac_Update", (object) dynamicParameters, "Sac Master - Update");
      return dynamicParameters.Get<byte>("@SacId");
    }

    public bool IsSacNameAvailable(string sacName, byte sacId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacId", (object) sacId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SacName", (object) sacName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSac_IsNameAvailable", (object) dynamicParameters, "Sac Master - IsSacNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsSacCodeAvailable(string sacCode, byte sacId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacId", (object) sacId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@SacCode", (object) sacCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterSac_IsCodeAvailable", (object) dynamicParameters, "Sac Master - IsSacCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<ServiceTypeToSacMapping> ServiceTypeToSacMapping(
      IEnumerable<ServiceTypeToSacMapping> objServiceTypeToSacMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlServiceTypeToSacMapping", (object) XmlUtility.XmlSerializeToString((object) objServiceTypeToSacMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsSuccessful", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ServiceTypeToSacMapping>("Usp_ServiceTypeToSacMapping", (object) dynamicParameters, "ServiceTypeToSacMapping - Insert");
    }

    public IEnumerable<TransportModeToServiceMapping> TransportModeToServiceMapping(
      IEnumerable<TransportModeToServiceMapping> objTransportModeToServiceMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTransportModeToServiceMapping", (object) XmlUtility.XmlSerializeToString((object) objTransportModeToServiceMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsSuccessful", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<TransportModeToServiceMapping>("Usp_TransportModeToServiceMapping", (object) dynamicParameters, "TransportModeToServiceMapping - Insert");
    }

    public IEnumerable<ServiceTypeToSacMapping> GetServiceTypeToSacMapping()
    {
      return DataBaseFactory.QuerySP<ServiceTypeToSacMapping>("Usp_ServiceTypeToSacMapping_GetServiceTypeToSacMapping", (object) null, "ServiceTypeToSacMapping - GetServiceTypeToSacMapping");
    }

    public IEnumerable<TransportModeToServiceMapping> GetTransportModeToServiceMapping()
    {
      return DataBaseFactory.QuerySP<TransportModeToServiceMapping>("Usp_ServiceTypeToSacMapping_GetTransportModeToServiceMapping", (object) null, "TransportModeToServiceMapping - GetTransportModeToServiceMapping");
    }

    public IEnumerable<AutoCompleteResult> GetSacCategoryList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_GetSacCategoryList", (object) null, "Sac Master - GetSacCategoryList");
    }

    public IEnumerable<AutoCompleteResult> GetSacList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_GetSacList", (object) null, "Sac Master - GetSacList");
    }

    public IEnumerable<AutoCompleteResult> GetServiceList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_GetServiceList", (object) null, "Sac Master - GetServiceList");
    }

    public IEnumerable<AutoCompleteResult> GetGstRateList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_GetGstRateList", (object) null, "Sac Master - GetGstRateList");
    }
  }
}
