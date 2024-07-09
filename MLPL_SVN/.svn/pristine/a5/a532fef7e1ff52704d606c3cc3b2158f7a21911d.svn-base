//  
// Type: CodeLock.Areas.Master.Repository.ConsignorConsigneeRepository
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
  public class ConsignorConsigneeRepository : BaseRepository, IConsignorConsigneeRepository, IDisposable
  {
    public MasterConsignorConsigneeMapping GetById(short mappingId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@MappingId", (object) mappingId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterConsignorConsigneeMapping>("Usp_MasterConsignorConsigneeMapping_GetById", (object) dynamicParameters, "ConsignorConsigneeMapping Master - GetById").FirstOrDefault<MasterConsignorConsigneeMapping>();
    }

    public IEnumerable<MasterConsignorConsigneeMapping> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterConsignorConsigneeMapping>("Usp_MasterConsignorConsigneeMapping_GetAll", (object) null, "ConsignorConsigneeMapping Master - GetAll");
    }

    public short Insert(
      MasterConsignorConsigneeMapping objMasterConsignorConsigneeMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCosignorConsignee", (object) XmlUtility.XmlSerializeToString((object) objMasterConsignorConsigneeMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@MappingId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCosignorConsigneeMapping_Insert", (object) dynamicParameters, "ConsignorConsigneeMapping Master - Insert");
      return dynamicParameters.Get<short>("@MappingId");
    }

    public short Update(
      MasterConsignorConsigneeMapping objMasterConsignorConsigneeMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCosignorConsignee", (object) XmlUtility.XmlSerializeToString((object) objMasterConsignorConsigneeMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@MappingId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterCountry>("Usp_MasterConsignorConsigneeMapping_Update", (object) dynamicParameters, "ConsignorConsigneeMapping Master - Update");
      return dynamicParameters.Get<short>("@MappingId");
    }

    public bool IsMappingAvailable(
      short mappingId,
      short consignorId,
      short consigneeId,
      short billingPartyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@MappingId", (object) mappingId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ConsignorId", (object) consignorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ConsigneeId", (object) consigneeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BillingPartyId", (object) billingPartyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterConsignorConsigneeMapping_IsMappingAvailable", (object) dynamicParameters, "ConsignorConsigneeMapping Master - IsMappingAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
