//  
// Type: CodeLock.Areas.Master.Repository.AssetRepository
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
  public class AssetRepository : BaseRepository, IAssetRepository, IDisposable
  {
    public IEnumerable<MasterAsset> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterAsset>("Usp_MasterAsset_GetAll", (object) null, "Asset Master - GetAll");
    }

    public MasterAsset GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AssetId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterAsset>("Usp_MasterAsset_GetById", (object) dynamicParameters, "Asset Master - GetById").FirstOrDefault<MasterAsset>();
    }

    public byte Insert(MasterAsset objMasterAsset)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAsset", (object) XmlUtility.XmlSerializeToString((object) objMasterAsset), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AssetId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAsset_Insert", (object) dynamicParameters, "Asset Master - Insert");
      return dynamicParameters.Get<byte>("@AssetId");
    }

    public byte Update(MasterAsset objMasterAsset)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAsset", (object) XmlUtility.XmlSerializeToString((object) objMasterAsset), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AssetId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAsset_Update", (object) dynamicParameters, "Asset Master - Update");
      return dynamicParameters.Get<byte>("@AssetId");
    }

    public bool IsAssetNameAvailable(string assetName, short assetId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@AssetId", (object) assetId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AssetName", (object) assetName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterAsset_IsNameAvailable", (object) dynamicParameters, "Asset Master - IsAssetNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}
