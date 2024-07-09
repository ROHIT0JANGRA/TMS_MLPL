//  
// Type: CodeLock.Areas.Master.Repository.BinsRepository
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
  public class BinsRepository : BaseRepository, IBinsRepository, IDisposable
  {
    public IEnumerable<MasterBins> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterBins>("Usp_MasterBins_GetAll", (object) null, "Bins Master - GetAll");
    }

    public MasterBins GetById(int id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BindId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterBins>("Usp_MasterBin_GetById", (object) dynamicParameters, "Bins Master - GetById").FirstOrDefault<MasterBins>();
    }

    public int Insert(MasterBins objMasterBins)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlBins", (object) XmlUtility.XmlSerializeToString((object) objMasterBins), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BindId", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterBins_Insert", (object) dynamicParameters, "Bins Master - Insert");
      return dynamicParameters.Get<Int32>("@BindId");
    }

    public int Update(MasterBins objMasterBins)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlBins", (object) XmlUtility.XmlSerializeToString((object) objMasterBins), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BindId", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterBins>("Usp_MasterBins_Update", (object) dynamicParameters, "Bins Master - Update");
      return dynamicParameters.Get<Int32>("@BindId");
    }

    public bool IsBinCodeAvailable(string binCode, int bindId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BindId", (object) bindId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BinCode", (object) binCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterBin_IsBinCodeAvailable", (object) dynamicParameters, "Labour Master - IsBinCodeAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsBinNameAvailable(string binName, int bindId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BindId", (object) bindId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BinName", (object) binName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterBin_IsBinNameAvailable", (object) dynamicParameters, "Bins Master - IsBinNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public AutoCompleteResult GetParentHierarchy(byte binHierarchyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BinHierarchyId", (object) binHierarchyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterBin_GetParentHierarchy", (object) dynamicParameters, "Bins Master - GetParentHierarchy").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetParentBinList(
      byte binHierarchyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BinHierarchyId", (object) binHierarchyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterLocation_GetParentBinList", (object) dynamicParameters, "Bins Master - GetParentBinList");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string binCode,
      short warehouseId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BinCode", (object) binCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterBin_GetAutoCompleteList", (object) dynamicParameters, "Bins Master - GetAutoCompleteList");
    }

    public AutoCompleteResult IsBinCodeExist(string binCode, short warehouseId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BinCode", (object) binCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@WarehouseId", (object) warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterBin_IsBinCodeExist", (object) dynamicParameters, "Bins Master - IsBinCodeExist").FirstOrDefault<AutoCompleteResult>();
    }

        public IEnumerable<MasterBins> IsBinNameAvailableBySku(
          string SkuId, string BindId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SkuId", (object)SkuId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BindId", (object)BindId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterBins>("Usp_MasterBin_IsBinNameAvailableBySku", (object)dynamicParameters, "BinsName Available By Sku");
        }
    }
}
