using Dramonkiller.CareHomeApp.Core.Models.Initializer;
using Dramonkiller.CareHomeApp.WebServer.App_Start;
using System.Data.Entity;
using System.Web;
using System.Web.Http;

namespace Dramonkiller.CareHomeApp.WebServer
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperBootstrap.Initialize();
            UnityConfig.RegisterComponents();

            Database.SetInitializer(new DatabaseContexInitializer());
        }
    }
}
