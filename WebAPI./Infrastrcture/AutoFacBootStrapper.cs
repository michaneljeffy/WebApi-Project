using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Infrastrcture
{
    public class AutoFacBootStrapper
    {
        public static void CoreAutoFacInit()
        {
            var builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            SetupResolveRules(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
         
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var container = builder.Build();
           
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            var iServices = Assembly.Load("WebAPI.IServices");
            var services = Assembly.Load("WebAPI.Services");
            var iRepository = Assembly.Load("WebAPI.IRepository");
            var repository = Assembly.Load("WebAPI.Repository");
 
            builder.RegisterAssemblyTypes(iServices, services)
             // .Where(t => t.Name.EndsWith("Services"))
              .AsImplementedInterfaces();
        
            builder.RegisterAssemblyTypes(iRepository, repository)
             // .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();
        }
    }
}