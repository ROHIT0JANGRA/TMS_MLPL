using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ITyreModelRepository : IDisposable
    {
        IEnumerable<MasterTyreModel> GetAll();
        MasterTyreModel GetById(short id);
        short Insert(MasterTyreModel objMasterTyreModel);
        short Update(MasterTyreModel objMasterTyreModel);
    }
}
