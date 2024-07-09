using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ITyrePatternRepository : IDisposable
    {
        IEnumerable<MasterTyrePattern> GetAll();
        short Insert(MasterTyrePattern objMasterTyrePattern);
        MasterTyrePattern GetById(short id);
        short Update(MasterTyrePattern objMasterTyrePattern);
        bool IsTyrePatternAvailable(string TyrePatternCode, byte countryId);
    }
}
