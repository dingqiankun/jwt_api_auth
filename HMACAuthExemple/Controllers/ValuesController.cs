using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMACAuthExemple.Areas.BearerAuth.Authorization;


namespace HMACAuthExemple.Controllers
{
    public class ValuesController : ApiController
    {
        [TokenValidator]
        public string Get()
        {
            return "value";
        }
    }
}
