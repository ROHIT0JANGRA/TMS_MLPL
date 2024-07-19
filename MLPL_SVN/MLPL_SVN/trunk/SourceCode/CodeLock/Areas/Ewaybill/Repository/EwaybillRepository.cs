using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Dapper.SqlMapper;

namespace CodeLock.Areas.Ewaybill.Repository
{
    public class EwaybillRepository : IEwaybillRepository, IDisposable
    {
        private readonly IEwaybillRepository ewayBillInterface;
        private readonly IDisposable disposable1;
        public EwaybillRepository(IEwaybillRepository ewayBillInterfaces, IDisposable disposable) { 
            this.ewayBillInterface = ewayBillInterfaces;
            this.disposable1 = disposable;
        }

        public EwaybillRepository() { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GenerateEwayBill()
        {
            throw new NotImplementedException();
        }
        public MasterLocation GetAPIUSER(short LocationId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)LocationId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MasterLocation>("Usp_MasterLocation_GetById", (object)dynamicParameters, "MasterLocation - GetAPIUser").FirstOrDefault<MasterLocation>();
        }

        public IEnumerable<GetAllStateCredential> GetAllState()
        {
            return DataBaseFactory.QuerySP<GetAllStateCredential>("Usp_Webtel_API_Credential_Detail_Get", (object)null, "State Master - GetAll");
        }

        public long Insert(EWBMain rootObj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlData", (object)XmlUtility.XmlSerializeToString((object)rootObj), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            // dynamicParameters.Add("@EWB_Header_Id", dbType: DbType.Int64, direction: ParameterDirection.Output);

            dynamicParameters.Add("@EWB_Header_Id", (object)null, new DbType?(DbType.Int64), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
           var result= DataBaseFactory.QuerySP("Usp_EWB_Insert", (object)dynamicParameters, "Ewaybill Detail - Insert");
            return dynamicParameters.Get<long>("@EWB_Header_Id");

        }


    }
}