using System.Web.Http;
using System.Web.Http.Cors;

namespace Dramonkiller.CareHomeApp.WebServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors
            var cors = new EnableCorsAttribute("*", "*", "*"); // Allow CORS for all origins. (Caution!)
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
