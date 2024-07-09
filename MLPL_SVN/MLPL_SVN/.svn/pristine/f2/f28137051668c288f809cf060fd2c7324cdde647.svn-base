using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ITyrePositionRepository : IDisposable
    {
        IEnumerable<MasterTyrePosition> GetAll();
        MasterTyrePosition GetById(short id);
        short Insert(MasterTyrePosition objMasterTyrePosition);

        short Update(MasterTyrePosition objMasterTyrePosition);
    }
}
