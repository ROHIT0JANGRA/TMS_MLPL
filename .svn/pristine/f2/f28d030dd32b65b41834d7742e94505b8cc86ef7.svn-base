using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CodeLock.Areas.Master.Repository
{
    public class AccountOpeningBalanceRepository : BaseRepository, IAccountOpeningBalanceRepository, IDisposable
    {
        public Response InsetUpdate(MasterAccountOpeningBalance objAccountOpeningBalance)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LedgerBalanceTransferTypeId", (object)objAccountOpeningBalance.LedgerBalanceTransferTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LedgerTypeId", (object)objAccountOpeningBalance.LedgerTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@SubLedgerTypeId", (object)objAccountOpeningBalance.SubLedgerTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ProfitLossLedgerTypeId", (object)objAccountOpeningBalance.ProfitLossLedgerTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)objAccountOpeningBalance.FinYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objAccountOpeningBalance.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)objAccountOpeningBalance.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MasterAccountOpeningBalance_InsertUpdate", (object)dynamicParameters, "Account Opening Balance Master - Insert/Update").FirstOrDefault<Response>();
        }
    }
}