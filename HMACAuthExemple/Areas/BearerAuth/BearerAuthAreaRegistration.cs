using System.Web.Mvc;

namespace HMACAuthExemple.Areas.BearerAuth
{
    public class BearerAuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BearerAuth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BearerAuth_default",
                "BearerAuth/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}