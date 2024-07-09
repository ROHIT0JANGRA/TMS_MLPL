//  
// Type: CodeLock.Areas.Master.Repository.GstRepository
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
  public class GstRepository : BaseRepository, IGstRepository, IDisposable
  {
        public Response ValidateGSTState(long GstId, long OwnerId, long StateId, byte OwnerType)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@GstId", (object)GstId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@OwnerId", (object)OwnerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@StateId", (object)StateId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@OwnerType", (object)OwnerType, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<Response>("Usp_MasterGst_ValidateGSTState", (object)dynamicParameters, "Gst Master - GetById").FirstOrDefault<Response>();
        }
        public IEnumerable<GstRegistration> GetListByOwnerType(byte ownerType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetListByOwnerType", (object) dynamicParameters, "Gst Master - GetListByOwnerType");
    }

    public GstRegistration GetById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GstId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetById", (object) dynamicParameters, "Gst Master - GetById").FirstOrDefault<GstRegistration>();
    }

    public Response Insert(GstRegistration objGstRegistration)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGst", (object) XmlUtility.XmlSerializeToString((object) objGstRegistration), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterGst_Insert", (object) dynamicParameters, "Gst Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(GstRegistration objGstRegistration)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGst", (object) XmlUtility.XmlSerializeToString((object) objGstRegistration), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterGst_Update", (object) dynamicParameters, "Gst Master - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<AutoCompleteResult> GetStateListByOwnerTypeIdAndOwnerId(
      byte ownerType,
      long ownerId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_GetStateListByOwnerTypeIdAndOwnerId", (object) dynamicParameters, "Gst Master - GetStateListByOwnerTypeIdAndOwnerId");
    }

    public bool IsStateNameAvailable(string stateName, byte ownerType, long ownerId, long gstId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@StateName", (object) stateName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@GstId", (object) gstId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterGst_IsStateNameAvailable", (object) dynamicParameters, "Gst Master - IsStateNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public IEnumerable<AutoCompleteResult> GetGstServiceTypeIdBySacId(
      byte sacId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacId", (object) sacId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGst_GetGstServiceTypeIdBySacId", (object) dynamicParameters, "Gst Master - GetGstServiceTypeIdBySacId");
    }

    public IEnumerable<GstRegistration> GetGstRegistrationByOwnerId(
      byte ownerType,
      int ownerId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetGstRegistrationByOwnerId", (object) dynamicParameters, "Gst Master - GetGstRegistrationByOwnerId");
    }

    public IEnumerable<AutoCompleteResult> GetGstStateList(
      byte ownerType,
      long ownerId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGst_GetGstStateList", (object) dynamicParameters, "Gst Master - GetGstStateList");
    }

        public IEnumerable<TransportModeToServiceMapping> GetGstServiceAndSacCategoryByTransportModeId(
      byte transportModeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@TransportModeId", (object) transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<TransportModeToServiceMapping>("Usp_MasterGst_GetGstServiceAndSacCategoryByTransportModeId", (object) dynamicParameters, "Gst Master - GetGstServiceAndSacCategoryByTransportModeId");
    }

    public MasterSac GetGstDetailByGstServiceTypeId(byte gstServiceTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@GstServiceTypeId", (object) gstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSac>("Usp_MasterGst_GetGstDetailByGstServiceTypeId", (object) dynamicParameters, "Gst Master - GetGstDetailByGstServiceTypeId").FirstOrDefault<MasterSac>();
    }

    public IEnumerable<AutoCompleteResult> GetCategoryList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGst_GetCategoryList", (object) null, "Gst Master - GetCategoryList");
    }

    public IEnumerable<AutoCompleteResult> GetGstServiceTypeList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGst_GetGstServiceTypeList", (object) null, "Gst Master - GetGstServiceTypeList");
    }

    public IEnumerable<AutoCompleteResult> GetSacList()
    {
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGst_GetSacList", (object) null, "Gst Master - GetSacList");
    }

    public GstRegistration GetGstDetailByOwnerAndState(
      byte ownerType,
      long ownerId,
      short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetGstDetailByOwnerAndState", (object) dynamicParameters, "Gst Master - GetGstDetailByOwnerAndState").FirstOrDefault<GstRegistration>();
    }

    public GstRegistration GetGstDetailByOwnerAndCity(
      byte ownerType,
      long ownerId,
      int cityId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityId", (object) cityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetGstDetailByOwnerAndCity", (object) dynamicParameters, "Gst Master - GetGstDetailByOwnerAndCity").FirstOrDefault<GstRegistration>();
    }

    public GstRegistration GetCustomerGstDetailByCustomerIdAndCityId(
      short customerId,
      int cityId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CustomerId", (object) customerId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityId", (object) cityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetCustomerGstDetailByCustomerIdAndCityId", (object) dynamicParameters, "Gst Master - GetCustomerGstDetailByCustomerIdAndCityId").FirstOrDefault<GstRegistration>();
    }

    public GstRegistration GetGstDetailByLocationIdAndOwnerType(
      short locationId,
      byte ownerType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_GetGstDetailByLocationIdAndOwnerType", (object) dynamicParameters, "Gst Master - GetGstDetailByLocationIdAndOwnerType").FirstOrDefault<GstRegistration>();
    }

    public MasterSac GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacId", (object) id, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSac>("Usp_SAC_GetById", (object) dynamicParameters, "Gst Master - GetDetailById").FirstOrDefault<MasterSac>();
    }

    public IEnumerable<AutoCompleteResult> GetCityListByOwnerAndState(
      byte ownerType,
      long ownerId,
      short stateId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGst_GetCityListByOwnerAndState", (object) dynamicParameters, "Gst Master - GetCityListByOwnerAndState");
    }

    public GstRegistration GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity(
      byte ownerType,
      long ownerId,
      short stateId,
      int cityId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CityId", (object) cityId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity", (object) dynamicParameters, "Gst Master - GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity").FirstOrDefault<GstRegistration>();
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteSacList(
      string sacCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacCode", (object) sacCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_GetAutoCompleteSacList", (object) dynamicParameters, "SAC Master - GetAutoCompleteSacList");
    }

    public AutoCompleteResult IsSacCodeExist(string sacCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SacCode", (object) sacCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterSac_IsSacCodeExist", (object) dynamicParameters, "SAC Master - IsSacCodeExist").FirstOrDefault<AutoCompleteResult>();
    }

    public GstRegistration GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation(
      byte ownerType,
      long ownerId,
      short stateId,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@OwnerType", (object) ownerType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@OwnerId", (object) ownerId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@StateId", (object) stateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<GstRegistration>("Usp_MasterGst_GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation", (object) dynamicParameters, "Gst Master - GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation").FirstOrDefault<GstRegistration>();
    }
  }
}
