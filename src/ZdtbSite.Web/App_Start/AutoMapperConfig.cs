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
        }
    }
}