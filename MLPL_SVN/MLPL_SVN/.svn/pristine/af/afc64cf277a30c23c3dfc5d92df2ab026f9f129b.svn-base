using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ITyreSizeRepository : IDisposable
    {
        IEnumerable<MasterTyreSize> GetAll();
        short Insert(MasterTyreSize objMasterTyreSize);
        MasterTyreSize GetById(short id);
        short Update(MasterTyreSize objMasterTyreSize);
        bool IsTyreSizeNameAvailable(string tyreSizeName, short tyreSizeId);
    }
}
