//  
// Type: CodeLock.Areas.Finance.Repository.BankingRepository
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

namespace CodeLock.Areas.Finance.Repository
{
  public class BankingRepository : BaseRepository, IBankingRepository, IDisposable
  {
    public Cheque GetChequeDetail(DateTime chequeDate, string chequeNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ChequeDate", (object) chequeDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ChequeNo", (object) chequeNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Cheque>("Usp_Bank_GetChequeDetail", (object) dynamicParameters, "Bank Master - GetChequeDetail").FirstOrDefault<Cheque>();
    }

    public Response ChequeDeposit(Cheque objCheque)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlChequeDeposit", (object) XmlUtility.XmlSerializeToString((object) objCheque), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinYear", (object) objCheque.FinYear, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) objCheque.CompanyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) objCheque.LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationCode", (object) objCheque.LocationCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DepositBy", (object) objCheque.DepositBy, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Bank_ChequeDeposit", (object) dynamicParameters, "Bank Master - ChequeDeposit").FirstOrDefault<Response>();
    }

    public IEnumerable<BankReconcilationChequeDetails> GetChequeDetailsForBankReconciliation(
      BankReconcilation objBankReconcilation)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) objBankReconcilation.LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object)objBankReconcilation.FromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object)objBankReconcilation.ToDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Finyear", (object) SessionUtility.CalenderYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BankAccountId", (object) objBankReconcilation.BankAccountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ReconcileStatus", (object) objBankReconcilation.ReconcileStatus, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AmountConsederation", (object) objBankReconcilation.AmountConsederation, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<BankReconcilationChequeDetails>("Usp_BankReconcilation_GetChequeDetails", (object) dynamicParameters, "Bank Reconciliation - GetChequeDetailsForBankReconciliation");
    }

    public Response BankReconcilationUpdate(BankReconcilation objBankReconcilation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BankReconciliationxml", (object)XmlUtility.XmlSerializeToString((object)objBankReconcilation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@UpdateBy", (object)objBankReconcilation.UpdateBy, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_BankReconcilation_Update", (object)dynamicParameters, "Bank Master - BankReconcilationUpdate").FirstOrDefault<Response>();
        }
     public BankReccoOpng GetOpeningBalDtl(short LocationId, DateTime FromDate, DateTime ToDate,short BankAccountId )
        {
            bool cumltv = true;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)FromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)ToDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Finyear", (object)@SessionUtility.CalenderYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BankAccountId", (object)BankAccountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsCumulative", (object)cumltv, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<BankReccoOpng>("Usp_BankOpeningBalance", (object)dynamicParameters, "Bank Master - GetOpeningBalDtl").FirstOrDefault<BankReccoOpng>();

        }


        

    }
}
