using System.Web.Http;
using System.Web.Http.Cors;

namespace Dramonkiller.CareHomeApp.WebServer.App_Start
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

            //http://stackoverflow.com/questions/9569270/custom-method-names-in-asp-net-web-api
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }//,
                //constraints: new { id = @"\d+" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithAction",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { action = "get", id = RouteParameter.Optional },
            //    constraints: new { id = @"\d+" }
            //);
        }
    }
}
