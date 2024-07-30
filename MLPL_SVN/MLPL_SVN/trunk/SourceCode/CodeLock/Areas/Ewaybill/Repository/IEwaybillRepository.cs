using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeLock.Areas.Ewaybill.Repository
{
    public interface IEwaybillRepository :IDisposable
    {
        string GenerateEwayBill();
        MasterLocation GetAPIUSER(short LocationId);

        IEnumerable<GetAllStateCredential> GetAllState();
        IEnumerable<EwaybillSummary> GetSummary();

        long Insert(EWBMain rootObj);
        IEnumerable<EWBDetail> GetAllEwaybillDetailByPagination(int pageNo, int pageSize, string sorting, string search);
        Task<JsonResult> SubmitDataInDbAllStates(EwaybillGetDetailFromWebNoAndDate model);

        //*******************  Task Sechdular Methods ******************

        void Start();
        void Stop();
        void ExecuteTask(object state);
        bool IsRunning();
        bool GetUpdateIsSchedulerActiveOrUpdate(string schedulerName, string Type, bool IsActive);
    }
}
