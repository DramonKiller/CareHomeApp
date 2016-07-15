using Dramonkiller.CareHomeApp.Core.Models.Initializer;
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
            UnityConfig.RegisterComponents();

            Database.SetInitializer(new DatabaseContexInitializer());
        }
    }
}
