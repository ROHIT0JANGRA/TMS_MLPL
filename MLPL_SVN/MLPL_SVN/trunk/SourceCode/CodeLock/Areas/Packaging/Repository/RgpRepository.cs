using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using ExpressiveAnnotations.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using System.Threading.Tasks;
using CodeLock.Api_Services;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Packaging.Repository
{
    public class RgpRepository : BaseRepository, IRgpRepository, IDisposable
    {
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }


        Task<string> IRgpRepository.GetRGPData()
        {

           


            throw new NotImplementedException();
        }
    }
}