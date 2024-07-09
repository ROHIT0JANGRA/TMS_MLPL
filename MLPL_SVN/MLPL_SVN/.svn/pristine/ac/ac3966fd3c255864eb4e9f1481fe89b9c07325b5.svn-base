using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface ITyreManufacturerRepository :IDisposable
    {
        MasterTyreManufacturer GetById(byte id);

        IEnumerable<MasterTyreManufacturer> GetAll();

        short Insert(MasterTyreManufacturer objMasterTyreManufacturer);

        short Update(MasterTyreManufacturer objMasterTyreManufacturer);
        IEnumerable<AutoCompleteResult> GetManufacturerList();
    }
}
