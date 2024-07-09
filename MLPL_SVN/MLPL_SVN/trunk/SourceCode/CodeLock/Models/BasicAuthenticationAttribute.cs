using CodeLock.Areas.Master.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CodeLock.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //If the Authorization header is empty or null
            //then return Unauthorized
           if (actionContext.Request.Headers.Authorization == null)
            {
                if(!actionContext.Request.RequestUri.AbsoluteUri.ToLower().Contains("login"))
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                //Get the authentication token from the request header
                string authenticationToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                //Decode the string
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));

                //Convert the string into an string array
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');

                //First element of the array is the username
                string username = usernamePasswordArray[0];

                //Second element of the array is the password
                string password = usernamePasswordArray[1];

                //call the login method to check the username and password

                UserRepository userRepository = new UserRepository();
                if (userRepository.ValidateUser(username, password))
                {
                    var identity = new GenericIdentity(username);

                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;

                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}