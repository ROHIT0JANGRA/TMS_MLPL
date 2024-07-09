//  
// Type: CodeLock.Areas.Master.Repository.AccountOpeningPartyRepository
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
  public class AccountOpeningPartyRepository : BaseRepository, IAccountOpeningPartyRepository, IDisposable
  {
    public IEnumerable<AutoCompleteResult> GetCustomerAccountList()
    {
      return (IEnumerable<AutoCompleteResult>) new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "1",
          Name = "Bill Debtor",
          Description = "Bill Debtor"
        },
        new AutoCompleteResult()
        {
          Value = "2",
          Name = "UnBill Debtor",
          Description = "UnBill Debtor"
        }
      };
    }

    public IEnumerable<AutoCompleteResult> GetVendorAccountList()
    {
      return (IEnumerable<AutoCompleteResult>) new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "4",
          Name = "Sundry Creditor"
        }
      };
    }

    public Response InsetUpdate(MasterAccountOpeningParty objAccountOpeningParty)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAccountOpeningParty", (object) XmlUtility.XmlSerializeToString((object) objAccountOpeningParty), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterAccountOpeningParty_InsertUpdate", (object) dynamicParameters, "Account Opening Party Master - Insert/Update").FirstOrDefault<Response>();
    }

        public MasterAccountOpeningParty GetCreditDebit(
         short partyType,
         int partyId,
         byte locationId,
         short accountId,
         string finYear)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PartType", (object)partyType, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartyId", (object)partyId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@AccountId", (object)accountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
			dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

			return DataBaseFactory.QuerySP<MasterAccountOpeningParty>("Usp_MasterAccountOpeningParty_GetCreditDebit", (object)dynamicParameters, "Account Opening Party Master - GetCreditDebit").FirstOrDefault<MasterAccountOpeningParty>();
        }
    }
}
