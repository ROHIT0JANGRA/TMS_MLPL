//  
// Type: CodeLock.Areas.Master.Repository.PincodeRepository
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
  public class PincodeRepository : BaseRepository, IPincodeRepository, IDisposable
  {
    public MasterPincode IsPincodeExist(string Pincode)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@Pincode", (object)Pincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<MasterPincode>("Usp_MasterPincode_IsPincodeExist", (object)dynamicParameters, "Vehicle Master - IsVehicleNoExist").FirstOrDefault<MasterPincode>();
    }

   public IEnumerable<AutoCompleteResult> GetAutoCompletePincodeList(
    string Pincode)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@Pincode", (object)Pincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
        return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompletePincodeList", (object)dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleList");
    }

    public IEnumerable<MasterPincode> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterPincode>("Usp_MasterPincode_GetAll", (object) null, "Pincode Master - GetAll");
    }

    public MasterPincode GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PincodeId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterPincode>("Usp_MasterPincode_GetById", (object) dynamicParameters, "Pincode Master - GetById").FirstOrDefault<MasterPincode>();
    }

    public byte Insert(MasterPincode objMasterPincode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPincode", (object) XmlUtility.XmlSerializeToString((object) objMasterPincode), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PincodeId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterPincode_Insert", (object) dynamicParameters, "Pincode Master - Insert");
      return dynamicParameters.Get<byte>("@PincodeId");
    }

    public byte Update(MasterPincode objMasterPincode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPincode", (object) XmlUtility.XmlSerializeToString((object) objMasterPincode), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PincodeId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterPincode>("Usp_MasterPincode_Update", (object) dynamicParameters, "Pincode Master - Update");
      return dynamicParameters.Get<byte>("@PincodeId");
    }

    public bool IsPincodeAvailable(string pincode, int pincodeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PincodeId", (object) pincodeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Pincode", (object) pincode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterPincode_IsPincodeAvailable", (object) dynamicParameters, "Pincode Master - IsPincodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
