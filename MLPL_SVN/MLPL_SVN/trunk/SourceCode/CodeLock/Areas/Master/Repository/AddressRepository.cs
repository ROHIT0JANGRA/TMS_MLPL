//  
// Type: CodeLock.Areas.Master.Repository.AddressRepository
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
  public class AddressRepository : BaseRepository, IAddressRepository, IDisposable
  {
    public IEnumerable<MasterAddress> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterAddress>("Usp_MasterAddress_GetAll", (object) null, "Address Master - GetAll");
    }

    public MasterAddress GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AddressId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterAddress>("Usp_MasterAddress_GetById", (object) dynamicParameters, "Address Master - GetById").FirstOrDefault<MasterAddress>();
    }

    public short Insert(MasterAddress objMasterAddress)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAddress", (object) XmlUtility.XmlSerializeToString((object) objMasterAddress), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AddressId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAddress_Insert", (object) dynamicParameters, "Address Master - Insert");
      return dynamicParameters.Get<short>("@AddressId");
    }

    public short Update(MasterAddress objMasterAddress)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAddress", (object) XmlUtility.XmlSerializeToString((object) objMasterAddress), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AddressId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAddress_Update", (object) dynamicParameters, "Address Master - Update");
      return dynamicParameters.Get<short>("@AddressId");
    }

    public bool IsAddressCodeAvailable(string addressCode, short addressId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AddressId", (object) addressId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AddressCode", (object) addressCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAddress_IsNameAvailable", (object) dynamicParameters, "Address Master - IsCountryNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<MasterAddress> GetAddressByContractId(
      short contractId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ContractId", (object) contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterAddress>("Usp_MasterAddress_GetAddressByContractId", (object) dynamicParameters, "Address Master - GetAddressByContractId");
    }
  }
}
