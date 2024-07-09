﻿using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Areas.Master.Repository
{
    public interface IPartRepository : IDisposable
    {
        IEnumerable<MasterPart> GetAll();
        long Insert(MasterPart objMasterPart);
        bool IsPartNameAvailable(string partName, long partId);
        bool IsPartNoAvailable(string partNo, long partId);
        long Update(MasterPart objMasterPart);
        MasterPart GetById(long id);
        IEnumerable<AutoCompleteResult> GetPartListByConsignorIdAndConsigneeId(short consignorId, short consigneeId);
        IEnumerable<AutoCompleteResult> GetPartListByCustomerId(short customerId);
        IEnumerable<AutoCompleteResult> GetPackingTypeListByPartId(short partId, short consignorId, short consigneeId);
        MasterPartDetail GetPartDetailByPartIdAndPackingTypeId(long partId, short packingTypeId, short consignorId, short consigneeId);

        IEnumerable<MasterPart> GetPartByPagination(int pageNo, int pageSize, string sorting, string search);




    }
}