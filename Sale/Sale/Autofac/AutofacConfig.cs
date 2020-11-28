using System.Reflection;
using System.Web.Http;
using Administration;
using Autofac;
using Autofac.Integration.WebApi;
using User.Autofac;

namespace Sale.Autofac
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            var apiAssembly = Assembly.Load("Administration");           
            builder.RegisterAssemblyModules(apiAssembly);
            apiAssembly = Assembly.Load("User");           
            builder.RegisterAssemblyModules(apiAssembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}