using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Areas.Packaging.Repository
{
    public interface IRgpRepository : IDisposable
    {

        Task<string> GetRGPData();
        
    }
}
