﻿//  
// Type: CodeLock.Areas.Master.Repository.VehicleRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
  public class VehicleRepository : BaseRepository, IVehicleRepository, IDisposable
  {
        public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleForMaintanance(
          string vehicleNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleListForMaintenance", (object)dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleForMaintanance");
        }
        public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListForStatus(
            string vehicleNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleListForStatus", (object)dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleListForStatus");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListForStatus(
            string vehicleNo, long userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleNo", (object)vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@userId", (object)userId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleListForStatus", (object)dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleListForStatus");
        }
        public MasterVehicle GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      Tuple<IEnumerable<MasterVehicle>, IEnumerable<MasterVehicleDetail>> tuple = DataBaseFactory.QueryMultipleSP<MasterVehicle, MasterVehicleDetail>("Usp_MasterVehicle_GetById", (object) dynamicParameters, "Vehicle Master - GetById");
      MasterVehicle masterVehicle1 = new MasterVehicle();
            masterVehicle1 = tuple.Item1.FirstOrDefault<MasterVehicle>();
      MasterVehicle masterVehicle2 = tuple.Item1.FirstOrDefault<MasterVehicle>();
      masterVehicle2.MasterVehicleDetail = tuple.Item2.FirstOrDefault<MasterVehicleDetail>();
      return masterVehicle2;
    }

    public IEnumerable<MasterVehicleDetails> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterVehicleDetails>("Usp_MasterVehicle_GetAll", (object) null, "Vehicle Master - GetAll");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleList", (object) null, "Vehicle Master - GetVehicleList");
    }

    public short Insert(MasterVehicle objMasterVehicle)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicle", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicle), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_Insert", (object) dynamicParameters, "Vehicle Master - Insert");
      return dynamicParameters.Get<short>("@VehicleId");
    }

    public short Update(MasterVehicle objMasterVehicle)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVehicle", (object) XmlUtility.XmlSerializeToString((object) objMasterVehicle), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_Update", (object) dynamicParameters, "Vehicle Master - Update");
      return dynamicParameters.Get<short>("@VehicleId");
    }

    public bool IsVehicleNoAvailable(string vehicleNo, short vehicleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_IsNameAvailable", (object) dynamicParameters, "Vehicle Master - IsVehicleNoAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListByLocation(
      string vehicleNo,
      string locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleListByLocation", (object) dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleListByLocation");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleListByVendorTypeByLocation(
      string vehicleNo,
      byte vendorTypeId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleListByVendorTypeByLocation", (object) dynamicParameters, "Vehicle Master - GetVehicleListByVendorTypeByLocation");
    }

    public AutoCompleteResult IsVehicleNoExistByVendorTypeByLocation(
      string vehicleNo,
      byte vendorTypeId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorTypeId", (object) vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_IsVehicleNoExistByVendorTypeByLocation", (object) dynamicParameters, "Vehicle Master - IsVehicleNoExistByLocation").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListByLocationForTripsheet(
      string vehicleNo,
      string locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleListByLocationForTripsheet", (object) dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleListByLocation");
    }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleListByForTripsheetCloser(
          string TripsheetNo, string TripsheetAction, string searchBy, string locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TripsheetAction", (object)TripsheetAction, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@searchBy", (object)searchBy, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)TripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleListByForTripsheetCloser", (object)dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleListByLocation");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteVehicleList(
      string vehicleNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteVehicleList", (object) dynamicParameters, "Vehicle Master - GetAutoCompleteVehicleList");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleListByVendorId(
      short vendorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleListByVendorId", (object) dynamicParameters, "Vehicle Master - GetVehicleListByVendorId");
    }

    public AutoCompleteResult IsVehicleNoExistByLocation(
      string vehicleNo,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_IsVehicleNoExistByLocation", (object) dynamicParameters, "Vehicle Master - IsVehicleNoExistByLocation").FirstOrDefault<AutoCompleteResult>();
    }

    public AutoCompleteResult IsVehicleNoExistForTripsheet(
      string vehicleNo,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_IsVehicleNoExistForTripsheet", (object) dynamicParameters, "Vehicle Master - IsVehicleNoExistForTripsheet").FirstOrDefault<AutoCompleteResult>();
    }

    public AutoCompleteResult IsVehicleNoExist(string vehicleNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_IsVehicleNoExist", (object) dynamicParameters, "Vehicle Master - IsVehicleNoExist").FirstOrDefault<AutoCompleteResult>();
    }

    public int GetStartKmByVehicleId(short vehicleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StartKm", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_GetStartKmByVehicleId", (object) dynamicParameters, "Vehicle Master - IsVehicleNoAvailable");
      return dynamicParameters.Get<int>("@StartKm");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleByFtlTypeId(
      byte ftlTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FtlTypeId", (object) ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleByFtlTypeId", (object) dynamicParameters, "Vehicle Master - GetVehicleByFtlTypeId");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleByVendorIdFtlTypeId(
      byte ftlTypeId,
      short vendorId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FtlTypeId", (object) ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleByVendorIdFtlTypeId", (object) dynamicParameters, "Vehicle Master - GetVehicleByVendorIdFtlTypeId");
    }

    public IEnumerable<AutoCompleteResult> GetTripsheetByVehicleId(
      short vehicleId, DateTime documentDateTime)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentDateTime", (object)documentDateTime, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetTripsheetByVehicleId", (object) dynamicParameters, "Vehicle Master - GetTripsheetByVehicleId");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteListForJobOrder(
      string vehicleNo,
      string locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetAutoCompleteListForJobOrder", (object) dynamicParameters, "Vehicle Master - GetAutoCompleteListForJobOrder");
    }

    public AutoCompleteResult CheckValidVehicleNoForJobOrder(
      string vehicleNo,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_CheckValidVehicleNoForJobOrder", (object) dynamicParameters, "Vehicle Master - CheckValidVehicleNoForJobOrder").FirstOrDefault<AutoCompleteResult>();
    }

    public IEnumerable<AutoCompleteResult> GetVehicleListByCardType(
      bool isFuelCard)
    {
      new DynamicParameters().Add("@IsFuelCard", (object) isFuelCard, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleListByCardType", (object) null, "Vehicle Master - GetVehicleListByCardType");
    }

    public int GetStartKm(short vehicleId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StartKm", (object) null, new DbType?(DbType.Int32), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterVehicle_GetStartKm", (object) dynamicParameters, "Vehicle Master - GetStartKm");
      return dynamicParameters.Get<int>("@StartKm");
    }

   public IEnumerable<MasterServiceVehicle> GetAllData()
    {
        return DataBaseFactory.QuerySP<MasterServiceVehicle>("Usp_MasterVehicle_GetAll", (object)null, "Vehicle Master - GetAll");
    }

        public IEnumerable<MasterServiceVehicle> GetAllDataVehicleServiceKM()
        {
            return DataBaseFactory.QuerySP<MasterServiceVehicle>("Usp_Tripsheet_KM_Mapping_GetAll", (object)null, "Vehicle Master - GetAll");
        }
        public bool IsVehicleAvailable(short VehicleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleId", (object)VehicleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Tripsheet_KM_Mapping_IsTaskAvailable", (object)dynamicParameters, "Job Order Task  Master - IsTaskAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<AutoCompleteResult> GetCompanyVehicleList(short VehicleTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VehicleTypeId", (object)VehicleTypeId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetListByVehicleTypeId", (object)dynamicParameters, "Vehicle Master - GetVehicleList");
        }
        public short InsertKmMapping(MasterServiceVehicle objMasterVehicle)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheetKMMappingServices", (object)XmlUtility.XmlSerializeToString((object)objMasterVehicle), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MappingId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Tripsheet_KM_Mapping_InsertServices", (object)dynamicParameters, "Vehicle KM Mapping - Insert");
            return dynamicParameters.Get<short>("@MappingId");
        }

        public MasterServiceVehicle GetKmMappingByMappingId(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MappingId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            IEnumerable<MasterServiceVehicle> tuple = DataBaseFactory.QuerySP<MasterServiceVehicle>("Usp_Tripsheet_KM_Mapping_GetById", (object)dynamicParameters, "Vehicle Service Km - GetById");

            MasterServiceVehicle vehicleKmMapping = new MasterServiceVehicle();
            if (tuple != null)
                vehicleKmMapping = tuple.FirstOrDefault<MasterServiceVehicle>();

            return vehicleKmMapping;
        }

      public short UpdateKmMapping(MasterServiceVehicle objMasterVehicle)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlTripsheetKMMappingServices", (object)XmlUtility.XmlSerializeToString((object)objMasterVehicle), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MappingId", (object)objMasterVehicle.MappingId, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_Tripsheet_KM_Mapping_UpdateServices", (object)dynamicParameters, "Vehicle KM Mapping - Insert");
            return dynamicParameters.Get<short>("@MappingId");
        }

        public IEnumerable<AutoCompleteResult> GetVehicleListByVendorTypeId(
      short vendorTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@VendorTypeId", (object)vendorTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterVehicle_GetVehicleListByVendorTypeId", (object)dynamicParameters, "Vehicle Master - GetVehicleListByVendorTypeId");
        }

        public IEnumerable<MasterVehicleDetails> GetVehiclesByPagination(int pageNo, int pageSize, string sorting, string search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PageNo", 1, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());

          //  dynamicParameters.Add("@PageNo", (object)pageNo, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PageSize", (object)pageSize, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Sorting", (object)sorting, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Search", (object)search, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterVehicleDetails>("Usp_MasterVehicle_GetVehicleByPagination", (object)dynamicParameters, "Vehicle Master - GetVehiclesByPagination");
        }


    }
}