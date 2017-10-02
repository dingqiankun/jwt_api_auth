using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMACAuthExemple.Areas.BearerAuth.Authorization;

namespace HMACAuthExemple.Areas.JWT.Controllers
{
    public class TokenController : ApiController
    {
        [HttpGet]
        [TokenValidator]
        public string Get()
        {
            return "value";
        }
    }
}
