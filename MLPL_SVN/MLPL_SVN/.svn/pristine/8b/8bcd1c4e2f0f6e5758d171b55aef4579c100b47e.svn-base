using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeLock.Models;

namespace CodeLock.Areas.Master.Repository
{
    public interface IFSCRateRepository : IDisposable
    {
        IEnumerable<FSCRateDetail> GetLaneList(short companyId, short? customerId, long? laneId);
        IEnumerable<FSCRateDetail> GetFSCRateList(short companyId, short? customerId);

        void Insert(FSCRate oData);
    }
}