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
    public class TyreManufacturerRepository : BaseRepository, ITyreManufacturerRepository, IDisposable
    {
        public MasterTyreManufacturer GetById(byte id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ManufacturerId", (object)id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterTyreManufacturer>("Usp_MasterTyreManufacturer_GetById", (object)dynamicParameters, "TyreManufacturer Master - GetById").FirstOrDefault<MasterTyreManufacturer>();
        }

        public IEnumerable<MasterTyreManufacturer> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterTyreManufacturer>("Usp_MasterTyreManufacturer_GetAll", (object)null, "TyreManufacturer Master - GetAll");
        }

        public short Insert(MasterTyreManufacturer objMasterTyreManufacturer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyreManufacturer", (object)XmlUtility.XmlSerializeToString((object)objMasterTyreManufacturer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManufacturerId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyreManufacturer_Insert", (object)dynamicParameters, "TyreManufacturer Master - Insert");
            return dynamicParameters.Get<short>("@ManufacturerId");
        }

        public short Update(MasterTyreManufacturer objMasterTyreManufacturer)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTyreManufacturer", (object)XmlUtility.XmlSerializeToString((object)objMasterTyreManufacturer), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManufacturerId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterTyreManufacturer_Update", (object)dynamicParameters, "TyreManufacturer Master - Update");
            return dynamicParameters.Get<short>("@ManufacturerId");
        }
        public IEnumerable<AutoCompleteResult> GetManufacturerList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_Master_GetTyreManufacturerList", (object)null, "TyreManufacturer Master - GetManufacturerList");
        }
    }
}