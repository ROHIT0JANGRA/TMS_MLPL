//  
// Type: CodeLock.Areas.Master.Repository.UserCompanyRepository
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
    public class UserCompanyRepository : BaseRepository, IUserCompanyRepository, IDisposable
    {
        public IEnumerable<MasterUserVehicleMapping> GetUserVehicleMapping()
        {
            return DataBaseFactory.QuerySP<MasterUserVehicleMapping>("CL_Master_User_Vehicle_Mapping_GetAll", (object)null, "MasterUserCompanyMapping");
        }
        public IEnumerable<MasterUserVehicleMapping> GetVahicleMappingByUserId(
            long userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@userId", (object)userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterUserVehicleMapping>("CL_Master_User_Vehicle_Mapping_GetById", (object)dynamicParameters, "MasterUserCompanyMapping - GetById");
        }


        public IEnumerable<MasterUserCompanyMapping> GetMapping()
        {
            return DataBaseFactory.QuerySP<MasterUserCompanyMapping>("Usp_MasterUserCompanyMapping", (object)null, "MasterUserCompanyMapping");
        }

        public IEnumerable<MasterUserCompanyMapping> GetMappingByUserId(
          short userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterUserCompanyMapping>("Usp_MasterUserCompanyMapping_GetById", (object)dynamicParameters, "MasterUserCompanyMapping - GetById");
        }

        public Response Mapping(
          MasterUserCompanyMapping objMasterUserCompanyMapping)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlUserCompanyMapping", (object)XmlUtility.XmlSerializeToString((object)objMasterUserCompanyMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterUserCompanyMapping_Update", (object)dynamicParameters, "UserCompanyMapping").FirstOrDefault<Response>();
        }

        public Response VehicleMapping(
            MasterUserVehicleMapping objMasterUserCompanyMapping)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlUserCompanyMapping", (object)XmlUtility.XmlSerializeToString((object)objMasterUserCompanyMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("CL_Master_User_Vehicle_Mapping_Update", (object)dynamicParameters, "UserCompanyMapping").FirstOrDefault<Response>();
        }


    }
}
