//  
// Type: CodeLock.Areas.Operation.Repository.QuickDocketRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CodeLock.Areas.Operation.Repository
{
  public class QuickDocketRepository : BaseRepository, IQuickDocketRepository, IDisposable
  {

        public DocketStep1 GetStep1Detail(short locationId, byte companyId)
        {
            //IDictionary<string, object> item3 = null;
            //KeyValuePair<string, object> keyValuePair = new KeyValuePair<string, object>();

            DynamicParameters dynamicParameter = new DynamicParameters();
            ParameterDirection? nullable = null;
            int? nullable1 = null;
            byte? nullable2 = null;
            byte? nullable3 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@LocationId", locationId, new DbType?(DbType.Int16), nullable, nullable1, nullable3, nullable2);
            nullable = null;
            nullable1 = null;
            nullable2 = null;
            byte? nullable4 = nullable2;
            nullable2 = null;
            dynamicParameter.Add("@CompanyId", companyId, new DbType?(DbType.Byte), nullable, nullable1, nullable4, nullable2);
            Tuple<IEnumerable<DocketStep1>, IEnumerable<AutoCompleteResult>, IEnumerable<object>, IEnumerable<object>> tuple = DataBaseFactory.QueryMultipleSP<DocketStep1, AutoCompleteResult, object, object>("Usp_Docket_GetStep1Detail", dynamicParameter, "Docket - GetStep1Detail");
            DocketStep1 docketStep1 = new DocketStep1();
            docketStep1 = tuple.Item1.FirstOrDefault<DocketStep1>();
            docketStep1.PaybasList = tuple.Item2;
            docketStep1.ConsignorConsigneePartyMappingSetting = new string[docketStep1.PaybasList.Count<AutoCompleteResult>(), 2];
            int num = 0;
            foreach (IDictionary<string, object> item3 in tuple.Item3)
            {
                int num1 = 0;
                foreach (KeyValuePair<string, object> keyValuePair in item3)
                {
                    docketStep1.ConsignorConsigneePartyMappingSetting[num, num1] = keyValuePair.Value.ToString();
                    num1++;
                }
                num++;
            }
            docketStep1.PartySetting = new string[docketStep1.PaybasList.Count<AutoCompleteResult>(), 2];
            int num2 = 0;
            foreach (IDictionary<string, object> item4 in tuple.Item4)
            {
                int num3 = 0;
                foreach (KeyValuePair<string, object> keyValuePair1 in item4)
                {
                    docketStep1.PartySetting[num2, num3] = keyValuePair1.Value.ToString();
                    num3++;
                }
                num2++;
            }
            return docketStep1;
        }

        public Response Insert(Docket objDocket)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDocket", (object) XmlUtility.XmlSerializeToString((object) objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Docket_Insert", (object) dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
    }

    public Response Update(Docket objDocket)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlDocket", (object) XmlUtility.XmlSerializeToString((object) objDocket), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_Docket_Update", (object) dynamicParameters, "Docket - Update").FirstOrDefault<Response>();
    }
  }
}
