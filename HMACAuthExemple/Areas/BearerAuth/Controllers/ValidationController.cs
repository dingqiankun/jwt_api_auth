using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMACAuthExemple.Areas.BearerAuth.Authorization;

namespace HMACAuthExemple.Areas.BearerAuth.Controllers
{
    [RoutePrefix("api/BearerAuth")]
    public class ValidationController : ApiController
    {
        /// TO-DO : Implementar retornos diferentes com base no status do token (OK, invalido, expirado, etc...)
        [TokenValidator]
        [Route("ValidateToken")]
        public string ValidateToken()
        {
            return "value";
        }
    }
}
