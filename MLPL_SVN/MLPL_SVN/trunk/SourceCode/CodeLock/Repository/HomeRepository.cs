using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Repository
{
    public class HomeRepository : BaseRepository, IHomeRepository, IDisposable
    {
        public DocketStatus DocketStatusGetByCode(string DocketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            Tuple<IEnumerable<DocketStatus>, IEnumerable<DocketStatusDetail>> tuple = DataBaseFactory.QueryMultipleSP<DocketStatus, DocketStatusDetail>("CL_Docket_Status_GetByCode", (object)dynamicParameters, "Docket Master - ");
            DocketStatus docketStatus = tuple.Item1.FirstOrDefault<DocketStatus>();
            docketStatus.StatusDetail = tuple.Item2.ToList<DocketStatusDetail>();

            return docketStatus;
        }
        public bool IsDocketNoAvailable(string DocketNo, int DocketId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)DocketId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNo", (object)DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_CL_Docket_IsDocketNoAvailable", (object)dynamicParameters, "Docket No - IsDocketNoAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }
        public string GetAppSettingById(short docketNomenclature)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", (object)docketNomenclature, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_AppSetting_GetById", (object)dynamicParameters, nameof(GetAppSettingById)).FirstOrDefault<AutoCompleteResult>().Value;
        }

        public EmailConfig GetEmailConfig()
        {
            return DataBaseFactory.QuerySP<EmailConfig>("Usp_EmailConfig_GetAll", null, nameof(GetEmailConfig)).FirstOrDefault<EmailConfig>();
        }
    }
}
