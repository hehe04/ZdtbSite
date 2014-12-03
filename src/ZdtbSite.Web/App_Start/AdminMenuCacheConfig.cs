using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web
{
    public class AdminMenuCacheConfig
    {
        public static void SetAdminMenuCache()
        {
            ZdtbSite.Core.Repository.AdminMenuRepository repository = new Core.Repository.AdminMenuRepository(new DbContextFactory());
            var list = repository.GetAll().ToList();
            var viewList = AutoMapper.Mapper.Map<List<AdminMenu>, List<AdminMenuViewModel>>(list);
            HttpContext.Current.Application.Add("MenuList", viewList);
        }
    }
}