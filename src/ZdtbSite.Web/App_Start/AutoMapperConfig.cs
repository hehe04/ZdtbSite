using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web
{
    public class AutoMapperConfig
    {
        public static void CreateAllMap()
        {
            AutoMapper.Mapper.CreateMap<Admin.UserViewModel, UserInfo>();
            AutoMapper.Mapper.CreateMap<UserInfo, Admin.UserViewModel>();

            AutoMapper.Mapper.CreateMap<AdminMenu, Admin.AdminMenuViewModel>();

            AutoMapper.Mapper.CreateMap<ContentType, Admin.ContentTypeViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.ContentTypeViewModel, ContentType>();

            AutoMapper.Mapper.CreateMap<Article, Admin.ArticleViewModel>();
            AutoMapper.Mapper.CreateMap<Admin.ArticleViewModel, Article>();

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