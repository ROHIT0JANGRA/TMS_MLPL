using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Areas.Master.Repository
{
    public interface IAccountOpeningBalanceRepository: IDisposable
    {
        Response InsetUpdate(MasterAccountOpeningBalance objAccountOpeningBalance);
    }
}
