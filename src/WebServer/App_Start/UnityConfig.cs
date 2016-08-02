using AutoMapper;
using Dramonkiller.CareHomeApp.DataAccess.Repositories;
using Dramonkiller.CareHomeApp.Domain.Infrastructure;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Dramonkiller.CareHomeApp.WebServer.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterInstance(AutoMapperBootstrap.Mapper); 
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}