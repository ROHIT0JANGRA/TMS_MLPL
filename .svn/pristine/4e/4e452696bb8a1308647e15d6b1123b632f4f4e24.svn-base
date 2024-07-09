//  
// Type: CodeLock.Areas.Master.Repository.UserRepository
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
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Repository
{
    public class UserRepository : BaseRepository, IUserRepository, IDisposable
    {
        public MasterUser GetById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterUser>("Usp_MasterUser_GetById", (object)dynamicParameters, "User Master - GetById").FirstOrDefault<MasterUser>();
        }

        public MasterUser GetByUserName(string userName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterUser>("Usp_MasterUser_GetByUserName", (object)dynamicParameters, "User Master - GetByUserName").FirstOrDefault<MasterUser>();
        }

        public IEnumerable<MasterUser> GetAll()
        {
            return DataBaseFactory.QuerySP<MasterUser>("Usp_MasterUser_GetAll", (object)null, (string)null);
        }

        public short Insert(MasterUser objMasterUser)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlUser", (object)XmlUtility.XmlSerializeToString((object)objMasterUser), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterUser_Insert", (object)dynamicParameters, "User Master - Insert");
            return dynamicParameters.Get<short>("@UserId");
        }

        public short Update(MasterUser objMasterUser)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlUser", (object)XmlUtility.XmlSerializeToString((object)objMasterUser), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserId", (object)null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterUser_Update", (object)dynamicParameters, "User Master - Update");
            return dynamicParameters.Get<short>("@UserId");
        }

        public bool IsUserNameAvailable(string userName, short userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterUser_CheckUser", (object)dynamicParameters, "User Master - IsUserNameAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<AutoCompleteResult> GetUserList()
        {
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetUserList", (object)null, "User Master - GetUserList");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteUserList(
          string userName,
          byte userTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserTypeId", (object)userTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetAutoCompleteUserList", (object)dynamicParameters, "User Master - GetUserListByLocationId");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteUserCodeList(
              string userName,
              byte userTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserTypeId", (object)userTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetAutoCompleteUserCodeList", (object)dynamicParameters, "User Master - GetUserListByLocationId");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteUserListByLocationId(
      short locationId,
      string userName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetUserListByLocationId", (object)dynamicParameters, "User Master - GetUserListByLocationId");
        }

        public AutoCompleteResult IsUserNameExistByLocation(
          short locationId,
          string userName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_IsUserNameExistByLocation", (object)dynamicParameters, "User Master - IsUserNameExistByLocation").FirstOrDefault<AutoCompleteResult>();
        }



        public AutoCompleteResult IsUserNameExist(string userName, byte userTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserTypeId", (object)userTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_IsUserNameExist", (object)dynamicParameters, "User Master - IsUserNameExist").FirstOrDefault<AutoCompleteResult>();
        }

        public AutoCompleteResult IsUserCodeExist(string userName, byte userTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UserTypeId", (object)userTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_IsUserCodeExist", (object)dynamicParameters, "User Master - IsUserNameExist").FirstOrDefault<AutoCompleteResult>();
        }

        public Response ChangePassword(ChangePassword objChangePassword)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)objChangePassword.UserId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@NewPassword", (object)objChangePassword.NewPassword, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UpdateBy", (object)objChangePassword.UpdateBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)objChangePassword.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterUser_ChangePassword", (object)dynamicParameters, "User Master - ChangePassword").FirstOrDefault<Response>();
        }

        public IEnumerable<AutoCompleteResult> GetUserNameListByLocationId(
          short locationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetUserNameListByLocationId", (object)dynamicParameters, "User Master - GetUserNameListByLocationId");
        }

        public IEnumerable<AutoCompleteResult> GetAutoCompleteUserListByRoleId(
          string userName,
          byte roleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RoleId", (object)roleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetAutoCompleteUserListByRoleId", (object)dynamicParameters, "User Master - GetAutoCompleteUserListByRoleId");
        }

        public AutoCompleteResult IsUserNameExistByRoleId(
          string userName,
          byte roleId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@RoleId", (object)roleId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_IsUserNameExistByRoleId", (object)dynamicParameters, "User Master - IsUserNameExistByRoleId").FirstOrDefault<AutoCompleteResult>();
        }

        public IEnumerable<AutoCompleteResult> GetLocationListByUserId(int userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)userId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterUser_GetLocationListByUserId", (object)dynamicParameters, "User Master - GetLocationListByUserId");
        }

        public MasterUserDetail GetDetailByUserName(string userName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterUserDetail>("Usp_MasterUser_GetDetailByUserName", (object)dynamicParameters, "User Master - GetDetailByUserName").FirstOrDefault<MasterUserDetail>();
        }

        public bool ValidateUser(string userName, string password)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", (object)userName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Password", (object)password, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_MasterUser_ValidateUser", (object)dynamicParameters, "User Master - ValidateUser");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public ApiLoginResultResponse GetApiForLogin(ApiLoginRequest apiLoginRequest)
        {
            ApiLoginResultResponse apiLoginResultResponse = new ApiLoginResultResponse();
            DynamicParameters dynamicParameters = new DynamicParameters();
            ApiLoginResponseData apiLoginResponseData = new ApiLoginResponseData();
            dynamicParameters.Add("@UserName", apiLoginRequest.UserName, DbType.String);
            var byUserName = DataBaseFactory.QuerySP<ApiLoginRequest>("Usp_MasterUser_GetByUserName", dynamicParameters, module: "User Master - GetByUserName").FirstOrDefault();
            if (byUserName == null)
            {
                apiLoginResultResponse.Flag = false;
                apiLoginResultResponse.FlagMessage = "Invalid User Name";
            }
            else if (byUserName.IsActive)
            {
                if (byUserName.Password != apiLoginRequest.Password)
                {
                    apiLoginResultResponse.Flag = false;
                    apiLoginResultResponse.FlagMessage = "Invalid Password";

                }
                else
                {
                    apiLoginResultResponse.Flag = true;
                    apiLoginResultResponse.FlagMessage = "Successfully Login";
                    apiLoginResponseData.UserId = byUserName.UserId;
                    apiLoginResponseData.UserName = byUserName.UserName;
                    apiLoginResponseData.LocationCode = byUserName.LocationCode;
                    apiLoginResponseData.CompanyName = byUserName.DefaultCompanyName;
                    apiLoginResponseData.UserRole = byUserName.RoleName;
                    apiLoginResultResponse.Data = apiLoginResponseData;
                }

            }
            else
            {
                apiLoginResultResponse.Flag = false;
                apiLoginResultResponse.FlagMessage = "Inactive User";
            }
            return apiLoginResultResponse;
        }

        public MasterUserDetail GetDetailById(short id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterUserDetail>("Usp_MasterUser_GetById", (object)dynamicParameters, "User Master - GetById").FirstOrDefault<MasterUserDetail>();
        }
    }
}
