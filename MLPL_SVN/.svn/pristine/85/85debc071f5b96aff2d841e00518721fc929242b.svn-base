//  
// Type: CodeLock.Areas.Master.Repository.BinHierarchyRepository
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
  public class BinHierarchyRepository : BaseRepository, IBinHierarchyRepository, IDisposable
  {
    public IEnumerable<MasterBinHierarchy> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterBinHierarchy>("Usp_MasterBinHierarchy_GetAll", (object) null, "BinHierarchy Master - GetAll");
    }

    public MasterBinHierarchy GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BinHierarchyId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterBinHierarchy>("Usp_MasterBinHierarchy_GetDetailById", (object) dynamicParameters, "BinHierarchy Master - GetById").FirstOrDefault<MasterBinHierarchy>();
    }

    public byte Insert(MasterBinHierarchy objMasterBinHierarchy)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlBinHierarchy", (object) XmlUtility.XmlSerializeToString((object) objMasterBinHierarchy), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BinHierarchyId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterBinHierarchy_Insert", (object) dynamicParameters, "BinHierarchy Master - Insert");
      return dynamicParameters.Get<byte>("@BinHierarchyId");
    }

    public byte Update(MasterBinHierarchy objMasterBinHierarchy)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlBinHierarchy", (object) XmlUtility.XmlSerializeToString((object) objMasterBinHierarchy), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BinHierarchyId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterBinHierarchy>("Usp_MasterBinHierarchy_Update", (object) dynamicParameters, "BinHierarchy Master - Update");
      return dynamicParameters.Get<byte>("@BinHierarchyId");
    }

    public bool IsBinHierarchyNameAvailable(string binHierarchyName, short binHierarchyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BinHierarchyId", (object) binHierarchyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BinHierarchyName", (object) binHierarchyName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterBinHierarchy_IsNameAvailable", (object) dynamicParameters, "BinHierarchy Master  - IsBinHierarchyNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetBinHierarchyList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterBins_GetBinHierarchyList", (object) null, "Bins Master - GetBinHierarchyList");
    }
  }
}
