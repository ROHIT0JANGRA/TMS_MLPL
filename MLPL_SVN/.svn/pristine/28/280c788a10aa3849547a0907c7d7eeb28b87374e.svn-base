//  
// Type: CodeLock.Areas.Master.Repository.IWarehouseRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface IWarehouseRepository : IDisposable
    {
        MasterWarehouse GetById(short id);

        IEnumerable<MasterWarehouse> GetAll();

        byte Insert(MasterWarehouse objMasterWarehouse);

        byte Update(MasterWarehouse objMasterWarehouse);

        IEnumerable<AutoCompleteResult> GetVirtualLoginWarehouseList(
          short loginUserId);

        bool IsWarehouseNameAvailable(string warehouseName, short warehouseId);

        IEnumerable<AutoCompleteResult> GetMappedWarehouseListByLocation(
          short locationId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteList(
          string warehouseName);

        AutoCompleteResult IsWarehouseNameExist(string warehouseName);
        IEnumerable<AutoCompleteResult> GetWarehouseList();
    }
}
