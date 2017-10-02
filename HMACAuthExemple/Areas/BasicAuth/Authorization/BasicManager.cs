using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMACAuthExemple.Areas.BasicAuth.Authorization
{
    public static class BasicManager
    {
        public static bool DoLogin(string user, string pass)
        {
            return true;
        }
    }
}