using CarAPI.Entities;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarAPI.Unity;
using Newtonsoft.Json;
using System.Web.Http;
using Unity;

namespace CarAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters
                   .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling
                   = ReferenceLoopHandling.Ignore;

            var unityContainer = RegisterUnityService();
            config.DependencyResolver = new UnityDependencyResolver(unityContainer);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static IUnityContainer RegisterUnityService()
        {
            var container = new UnityContainer().AddExtension(new Diagnostic());
            container.RegisterType<IOwnersService, OwnersService>();
            container.RegisterType<ICarsService, CarsService>();    
            container.RegisterType<IOwnersRepository, OwnersRepository>();
            container.RegisterType<ICarsRepository, CarsRepository>();
            container.RegisterType<ICarsService, CarsService>();
            container.RegisterType<InMemoryContext>();

            container.RegisterType<IPaymentService, WalletService>();

            return container;
        }

    }
}
