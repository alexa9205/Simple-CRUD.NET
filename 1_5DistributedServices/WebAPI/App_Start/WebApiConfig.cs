using Business.IServices;
using Business;
using Domain.IRepositories;
using InfrastructureData;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebAPI
{
    //public static class WebApiConfig
    //{
    //    public static void Register(HttpConfiguration config)
    //    {
    //        // Configuración y servicios de Web API

    //        // Rutas de Web API
    //        config.MapHttpAttributeRoutes();

    //        config.Routes.MapHttpRoute(
    //            name: "DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );
    //    }
    //}
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configuración del contenedor IoC (Unity)
            var container = new UnityContainer();
            // Registra tus tipos e implementaciones aquí
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            // Configuración de la resolución de dependencias con Unity
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
