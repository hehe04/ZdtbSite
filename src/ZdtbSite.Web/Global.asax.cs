using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZdtbSite.Core.Migrations;
using ZdtbSite.Core.Infrastructure;
using System.Web.Optimization;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;
using ZdtbSite.Model;

namespace ZdtbSite.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.SetAutofacContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());//设置dbConfiguration实例，必须在使用任何实体框架之前设置
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.CreateAllMap();
            AdminMenuCacheConfig.SetAdminMenuCache();

            AutoMapper.Mapper.CreateMap<Admin.ProductTypeViewModel, ProductType>();
            AutoMapper.Mapper.CreateMap<ProductType, Admin.ProductTypeViewModel>();



            AutoMapper.Mapper.CreateMap<Admin.ProductViewModel, Product>();
            AutoMapper.Mapper.CreateMap<Product, Admin.ProductViewModel>();


            AutoMapper.Mapper.CreateMap<Admin.BasicInfoViewModel, BasicInfo>();
            AutoMapper.Mapper.CreateMap<BasicInfo, Admin.BasicInfoViewModel>();


            AutoMapper.Mapper.CreateMap<Admin.RecruitmentViewModel, Recruitment>();
            AutoMapper.Mapper.CreateMap<Recruitment, Admin.RecruitmentViewModel>();
        }
    }
}
