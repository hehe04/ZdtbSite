using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Core.Repository;
using ZdtbSite.Web.ActionFilters;

namespace ZdtbSite.Web
{
    public static class AutofacConfig
    {
        public static IContainer Container { get; set; }

        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserInfoRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}