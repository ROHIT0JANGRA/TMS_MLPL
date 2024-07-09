﻿//  
// Type: CodeLock.Areas.Master.Repository.VendorRepository
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
  public class VendorRepository : BaseRepository, IVendorRepository, IDisposable
  {
        public MasterVendor GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<MasterVendor>, IEnumerable<MasterVendorDetail>> tuple = DataBaseFactory.QueryMultipleSP<MasterVendor, MasterVendorDetail>("Usp_MasterVendor_GetById", (object)dynamicParameters, "Vendor Master - GetById");
            MasterVendor masterVendor1 = new MasterVendor();
            MasterVendor masterVendor2 = tuple.Item1.FirstOrDefault<MasterVendor>();
            masterVendor2.MasterVendorDetail = tuple.Item2.FirstOrDefault<MasterVendorDetail>();
            return masterVendor2;
        }

        public IEnumerable<AutoCompleteResult> GetVendorNameList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetVendorList", (object) null, "Vendor Master - GetVendorNameList");
    }

    public IEnumerable<MasterVendorDetails> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterVendorDetails>("Usp_MasterVendor_GetAll", (object) null, "Vendor Master - GetAll");
    }

    public short Insert(MasterVendor objMasterVendor)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVendor", (object) XmlUtility.XmlSerializeToString((object) objMasterVendor), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVendor_Insert", (object) dynamicParameters, "Vendor Master - Insert");
      return dynamicParameters.Get<short>("@VendorId");
    }

     public short Update(MasterVendor objMasterVendor)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlVendor", (object)XmlUtility.XmlSerializeToString((object)objMasterVendor), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP<MasterVendor>("Usp_MasterVendor_Update", (object)dynamicParameters, "Vendor Master - Update");
            return dynamicParameters.Get<short>("@VendorId");
        }

        public IEnumerable<AutoCompleteResult> GetVendorListByVendorTypeId(
      byte vendorTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetVendorListByVendorTypeId", (object) dynamicParameters, "Vendor Master - GetVendorListByVendorTypeId");
    }

    public bool IsVendorNameAvailable(string vendorName, short vendorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorName", (object) vendorName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVendor_IsNameAvailable", (object) dynamicParameters, "Vendor Master - IsVendorNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteVendorList(
      string vendorCode,
      byte vendorTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorCode", (object) vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetAutoCompleteVendorList", (object) dynamicParameters, "Vendor Master - GetAutoCompleteVendorList");
    }

    public IEnumerable<AutoCompleteResult> GetVendorNameByVendorTypeId(
      short vendorTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetVendorNameByVendorTypeId", (object) dynamicParameters, "Vendor Master - GetVendorNameByVendorTypeId");
    }

    public IEnumerable<AutoCompleteResult> GetVendorServiceByVendorId(
      short vendorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetVendorServiceByVendorId", (object) dynamicParameters, "Vendor Master - GetVendorServiceByVendorId");
    }

    public AutoCompleteResult IsVendorCodeExist(
      string vendorCode,
      byte vendorTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorCode", (object) vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_IsVendorCodeExist", (object) dynamicParameters, "Vendor Master - IsVendorCodeExist").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteListForFuelPumpVendor(
      string vendorCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorCode", (object) vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetAutoCompleteListForFuelPumpVendor", (object) dynamicParameters, "Vendor Master - GetAutoCompleteListForFuelPumpVendor");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteVendorListByLocation(
      string vendorCode,
      byte vendorTypeId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorCode", (object) vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetAutoCompleteVendorListByLocation", (object) dynamicParameters, "Vendor Master - GetAutoCompleteVendorListByLocation");
    }

    public AutoCompleteResult IsVendorCodeExistByLocation(
      string vendorCode,
      byte vendorTypeId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorCode", (object) vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_IsVendorCodeExistByLocation", (object) dynamicParameters, "Vendor Master - IsVendorCodeExistByLocation").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetLocationListByVendorId(
      short VendorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorId", (object) VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetLocationListByVendorId", (object) dynamicParameters, "Vendor Master - GetLocationListByVendorId");
    }

    public IEnumerable<AutoCompleteResult> GetVenderTypeByVehicleId(
      short vehicleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@vehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetVenderTypeByVehicleId", (object) dynamicParameters, "Vendor Master - GetVenderTypeByVehicleId");
    }

    public IEnumerable<AutoCompleteResult> GetCustomerList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCustomer_GetCustomerList", (object)null, "Customer Master - GetAutoCompleteCustomerList");
        }
   public bool CheckDate(short contractId, short customerId, byte paybasId, bool isCustomerContract, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
   public bool CheckDateIsValid(short contractId, short customerId, byte paybasId, bool isCustomerContract, DateTime contractDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendorExcelData> GetVendorExcelData()
        {
            return DataBaseFactory.QuerySP<VendorExcelData>("Usp_MasterVendor_GetAll", (object)null, "Vendor Master - GetVendorExcelData");
        }

        public IEnumerable<AutoCompleteResult> GetWarehouseListByVendorId(
      short VendorId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVendor_GetWarehouseListByVendorId", (object)dynamicParameters, "Vendor Master - GetWarehouseListByVendorId");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompleteVendorListByLocationforFuel(short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@VendorCode", (object)vendorCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //dynamicParameters.Add("@VendorTypeId", (object)vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_GetVendorListForFuel", (object)dynamicParameters, "Vendor Master - GetAutoCompleteVendorListByLocationforFuel");
        }
        public IEnumerable<MasterVendorDetails> GetVendorsByPagination(int pageNo, int pageSize, string sorting, string search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterVendorDetails>("Usp_MasterVendor_GetVendorByPagination", (object)dynamicParameters, "Vendor Master - GetVendorsByPagination");
        }
    }
}
