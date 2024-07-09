//  
// Type: CodeLock.Areas.Master.Repository.IUserRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface IUserRepository : IDisposable
    {
        MasterUser GetById(short id);

        MasterUser GetByUserName(string userName);

        IEnumerable<MasterUser> GetAll();

        short Insert(MasterUser objMasterUser);

        short Update(MasterUser objMasterUser);

        Response ChangePassword(ChangePassword objChangePassword);

        bool IsUserNameAvailable(string userName, short userId);

        IEnumerable<AutoCompleteResult> GetUserList();

        IEnumerable<AutoCompleteResult> GetAutoCompleteUserList(
          string userName,
          byte userTypeId);
        IEnumerable<AutoCompleteResult> GetAutoCompleteUserCodeList(
               string userName,
             byte userTypeId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteUserListByLocationId(
      short locationId,
      string userName);

        AutoCompleteResult IsUserNameExistByLocation(
          short locationId,
          string userName);

        AutoCompleteResult IsUserNameExist(string userName, byte userTypeId);

        AutoCompleteResult IsUserCodeExist(string userName, byte userTypeId);


        IEnumerable<AutoCompleteResult> GetUserNameListByLocationId(
          short locationId);

        IEnumerable<AutoCompleteResult> GetAutoCompleteUserListByRoleId(
          string userName,
          byte roleId);

        AutoCompleteResult IsUserNameExistByRoleId(string userName, byte roleId);

        IEnumerable<AutoCompleteResult> GetLocationListByUserId(int userId);
        MasterUserDetail GetDetailByUserName(string userName);
        bool ValidateUser(string userName, string password);
        ApiLoginResultResponse GetApiForLogin(ApiLoginRequest apiLoginRequest);
        MasterUserDetail GetDetailById(short id);
    }
}
