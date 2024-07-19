using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Areas.Ewaybill.Repository
{
    public interface IEwaybillRepository
    {
        string GenerateEwayBill();
        MasterLocation GetAPIUSER(short LocationId);

        IEnumerable<GetAllStateCredential> GetAllState();

        long Insert(EWBMain rootObj);
    }
}
