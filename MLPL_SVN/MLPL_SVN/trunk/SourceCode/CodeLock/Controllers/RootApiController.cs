using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CodeLock.Controllers
{
    [RoutePrefix("")]
    public class RootApiController : ApiController
    {
        private readonly IUserRepository userRepository;

        public RootApiController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpPost]
        [Route(nameof(login))]
        public HttpResponseMessage login([FromBody] ApiLoginRequest apiLoginRequest)
        {
            HttpResponseMessage response = null;
            ApiLoginResultResponse apiLoginResultResponse = new ApiLoginResultResponse();
            string json = string.Empty;
            apiLoginResultResponse = userRepository.GetApiForLogin(apiLoginRequest);
            json = JsonConvert.SerializeObject(apiLoginResultResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
