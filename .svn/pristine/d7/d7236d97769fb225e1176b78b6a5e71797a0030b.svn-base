//  
// Type: CodeLock.Areas.Master.Repository.WarehouseRepository
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
    public class WarehouseRepository : BaseRepository, IWarehouseRepository, IDisposable
    {
        public MasterWarehouse GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@WarehouseId", (object)id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterWarehouse>("Usp_MasterWarehouse_GetById", (object)dynamicParameters, "Warehouse Master - GetById").FirstOrDefault<MasterWarehouse>();
        }

        public IEnumerable<MasterWarehouse> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterWarehouse>("Usp_MasterWarehouse_GetAll", (object)null, "Warehouse Master - GetAll");
        }

        public byte Insert(MasterWarehouse objMasterWarehouse)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlWarehouse", (object)XmlUtility.XmlSerializeToString((object)objMasterWarehouse), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@WarehouseId", (object)null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP<MasterWarehouse>("Usp_MasterWarehouse_Insert", (object)dynamicParameters, "Warehouse Master - Insert");
            return dynamicParameters.Get<byte>("@WarehouseId");
        }

        public byte Update(MasterWarehouse objMasterWarehouse)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlWarehouse", (object)XmlUtility.XmlSerializeToString((object)objMasterWarehouse), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@WarehouseId", (object)null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterWarehouse_Update", (object)dynamicParameters, "Warehouse Master - Update");
            return dynamicParameters.Get<byte>("@WarehouseId");
        }

        public IEnumerable<AutoCompleteResult> GetVirtualLoginWarehouseList(
          short loginUserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)loginUserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_VirtualLogin_GetWarehouse", (object)dynamicParameters, "Warehouse Master - GetVirtualLoginWarehouseList");
        }

        public bool IsWarehouseNameAvailable(string warehouseName, short warehouseId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@WarehouseId", (object)warehouseId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@WarehouseName", (object)warehouseName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterWarehouse_CheckWarehouse", (object)dynamicParameters, "Warehouse Master - IsWarehouseNameAvailable");
            return dynamicParameters.Get<bool>("@@IsAvailable");
        }

        public IEnumerable<AutoCompleteResult> GetMappedWarehouseListByLocation(
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterWarehouse_GetMappedWarehouseListByLocation", (object)dynamicParameters, "Warehouse Master - GetMappedWarehouseListByLocation");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteList(
          string warehouseName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@WarehouseName", (object)warehouseName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterWarehouse_GetAutoCompleteList", (object)dynamicParameters, "Warehouse Master - GetAutoCompleteList");
        }

        public AutoCompleteResult IsWarehouseNameExist(string warehouseName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@WarehouseName", (object)warehouseName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterWarehouse_IsWarehouseNameExist", (object)dynamicParameters, "Warehouse Master - IsWarehouseNameExist").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetWarehouseList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterWarehouse_GetWarehouseList", (object)null, "Warehouse Master - GetWarehouseList");
        }
    }
}
