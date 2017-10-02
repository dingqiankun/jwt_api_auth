using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMACAuthExemple.Areas.BearerAuth.Authorization;
using HMACAuthExemple.Areas.BasicAuth.Authorization;

namespace HMACAuthExemple.Areas.BasicAuth.Controllers
{
    [RoutePrefix("api/BasicAuth")]
    public class ValidatorController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        public string Get()
        {
            return "value";
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("GenerateToken")]
        public string GenerateToken(LoginInfo _loginInfo)
        {
            try
            {
                if (BasicManager.DoLogin(_loginInfo.username, _loginInfo.password))
                {
                    return JwtManager.GenerateToken(_loginInfo.username);
                }

                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public class LoginInfo
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
