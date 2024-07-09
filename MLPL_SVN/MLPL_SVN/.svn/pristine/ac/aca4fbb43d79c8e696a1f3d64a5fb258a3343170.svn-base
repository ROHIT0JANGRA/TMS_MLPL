using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeLock.Models;

namespace CodeLock.Areas.Master.Repository
{
    public interface ILaneRepository : IDisposable
    {
        IEnumerable<AutoCompleteResult> GetLaneCustomer(long CompanyId);
        List<LaneDetail> GetAll(long CompanyId, long CustomerId, bool? IsActive = null);
        void Insert(long CompanyId, long CustomerId, Lane oLane);
    }
}