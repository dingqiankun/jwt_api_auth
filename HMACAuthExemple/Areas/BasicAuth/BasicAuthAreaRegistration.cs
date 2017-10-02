using System.Web.Mvc;

namespace HMACAuthExemple.Areas.BasicAuth
{
    public class BasicAuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BasicAuth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BasicAuth_default",
                "BasicAuth/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}